using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace Testapp
{   
    public struct FileInfos
    {
        public Int32 Index;             // index souboru
        public string  FileName;        // nazaev souboru
        public Int64 FileSize;          // velikost souboru
        public bool Duplicity;

    }

    

    public partial class Form1 : Form
    {
        public const int DiskTypeSSD = 16;
        public const int DiskTypeHDD = 2;
        public List<FileInfos> ProcFileList = new List<FileInfos>();
        public Int32 FilesCount;
        public CountdownEvent thrcounter = new CountdownEvent(1);
        public Int32 DuplicityFilesCount = 0;

        // porovnani obsahu svou souboru
        private static bool CompareByReadFiles(string filename1, string filename2)
        {
            const Int32 BLOCK_SIZE = 65538;  
            byte[] blockfile1 = new byte[BLOCK_SIZE];
            byte[] blockfile2 = new byte[BLOCK_SIZE];
            bool duplfinded = true;
            try
            {
                using (FileStream stream1 = File.OpenRead(filename1))
                using (FileStream stream2 = File.OpenRead(filename2))
                    while (true)
                    {

                        int rdlen1 = stream1.Read(blockfile1, 0, BLOCK_SIZE);
                        int rdlen2 = stream2.Read(blockfile2, 0, BLOCK_SIZE);
                        if (!blockfile1.SequenceEqual(blockfile2))
                        {
                            duplfinded = false;
                            break;
                        }
                        if (rdlen1 == 0 || rdlen2 == 0) break;
                    }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }


            return duplfinded;
        }
        


        // vlakno pro porovnani obsahu dvou soboru
        private void Comparefiles(Int32 Index)
        {
            Int16 addindex = 1;
            var file1 = new FileInfosWrapper { onerec = ProcFileList[Index] };
            var file2 = new FileInfosWrapper { onerec = ProcFileList[Index + addindex] };
            thrcounter.AddCount();
            do
            {
                file1.onerec.Duplicity = CompareByReadFiles(file1.onerec.FileName, file2.onerec.FileName);

                if (file1.onerec.Duplicity)
                {
                    TextBoxResult.Invoke((MethodInvoker)delegate
                    {
                        TextBoxResult.AppendText("Duplicity files: " + file1.onerec.FileName + " and " + file2.onerec.FileName + "\r\n");
                        DuplicityFilesCount++;
                    });
                    Application.DoEvents();
                }
                addindex++;
                if ((Index+addindex)==FilesCount) {
                    break;
                }
                file2.onerec = ProcFileList[Index + addindex];
            } while (file1.onerec.FileSize == file2.onerec.FileSize);
            thrcounter.Signal();
            
        }

        // zjisteni poctu souboru, jecjich velikosti a vytvoreni seznamu souboru, ktere maji byt porovnany       
        public void GetFilesInfo(string Path, bool InclSubDirs, List<FileInfos> FilesInfoList)
        {
            FileInfos CurFileInfo = new FileInfos();
            Int32 findex = 0;
            try
            {
                if (InclSubDirs)
                {                  
                    foreach (string curfile in System.IO.Directory.GetFiles(Path, "*", SearchOption.AllDirectories))
                    {
                        CurFileInfo.FileSize = new FileInfo(curfile).Length;
                        CurFileInfo.FileName = curfile;
                        CurFileInfo.Index = findex;
                        CurFileInfo.Duplicity = false;
                        FilesInfoList.Add(CurFileInfo);
                        findex++;
                    }

                } else
                {
                    foreach (string curfile in System.IO.Directory.GetFiles(Path, "*"))
                    {
                        CurFileInfo.FileSize = new FileInfo(curfile).Length;
                        CurFileInfo.FileName = curfile;                       
                        CurFileInfo.Index = findex;
                        CurFileInfo.Duplicity = false;
                        FilesInfoList.Add(CurFileInfo);
                        findex++;
                    }
                }
                
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // vyber adresare pro hledani duplicitnich souboru
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedFolderText.Text = SelectFolderDialog.SelectedPath;
            }
        }


        // spusteni procesu vyhledavani duplicit
        private void button2_Click(object sender, EventArgs e)
        {
            Int32 ActIndex = 0;
            bool InclSubDirs;
            String PathFolder = SelectedFolderText.Text;
            int outhtr, outaastthr, outthr1, outaastthr1,actthr;
            int maxthrcount = 0;
            Stopwatch FindProcTimer = new Stopwatch();
            TimeSpan ElapsedTime;
            string TotTimeStr;
            toolStripStatFileCount.Visible = false;
            toolStripDuplicityFound.Visible = false;
            toolStripStatTime.Visible = false;
            toolStripStatusPrg.Text = "Status: Counting Files";
            TextBoxResult.Clear();
            TextBoxResult.Refresh();
            StatBar.Refresh();
            FindProcTimer.Start();
            if (!System.IO.Directory.Exists(PathFolder))
            {
                MessageBox.Show("Folder does not exists", "Folder error", MessageBoxButtons.OK);
                return;
            }
            if (ChkInclSubdirs.Checked)
            {
                FilesCount = System.IO.Directory.GetFiles(PathFolder, "*", SearchOption.AllDirectories).Count();
                InclSubDirs = true;

            } else
            {
                FilesCount = System.IO.Directory.EnumerateFiles(PathFolder).Count();
                InclSubDirs = false;
            }
            
            string totalfiles = FilesCount.ToString();           
            toolStripStatFileCount.Visible = true;
            toolStripStatFileCount.Text = "Total files: " + totalfiles;
            toolStripStatusPrg.Text = "Status: Listing files";
            StatBar.Refresh();
            
            if (ProcFileList.Count>0)
            {
                ProcFileList.Clear();
            }            
            GetFilesInfo(PathFolder, InclSubDirs,ProcFileList);

            ProcFileList.Sort((s1,s2) => s1.FileSize.CompareTo(s2.FileSize));     // serazeni souboru dle velikosti souboru
            if (ChkSsdDisk.Checked)                                               // maximalni pocet vlaken pro dle typu disku> HDD/SSD
            {
                ThreadPool.SetMinThreads(1, 1);
                ThreadPool.SetMaxThreads(DiskTypeSSD, DiskTypeSSD);
                maxthrcount = DiskTypeSSD;
            } else
            {
                ThreadPool.SetMinThreads(1, 1);
                ThreadPool.SetMaxThreads(DiskTypeHDD, DiskTypeHDD);
                maxthrcount = DiskTypeHDD;
            }
            toolStripStatTime.Visible = true;
            DuplicityFilesCount = 0;
            toolStripStatusPrg.Text = "Status: Processing";
            TextBoxResult.AppendText("******** Duplicity Files ********\r\n");

            // porovnavani souboru dle velikosti
            do
            {
                if (ProcFileList[ActIndex].FileSize == ProcFileList[ActIndex + 1].FileSize)
                {
                    ThreadPool.QueueUserWorkItem(Index => Comparefiles((Int32)Index), ActIndex);       // vlakno pro porovnani

                    ThreadPool.GetAvailableThreads(out outhtr, out outaastthr);
                    ThreadPool.GetMaxThreads(out outthr1, out outaastthr1);
                    actthr = maxthrcount - outhtr;
                    StatBar.Refresh();
                    ActIndex++;
                }
                else
                {
                    ActIndex++;
                }
                if ((ActIndex % 1000) == 0 && (FilesCount>8000)) {
                    ElapsedTime = FindProcTimer.Elapsed;
                    TotTimeStr = String.Format("{0:00}:{1:00}:{2:00}", ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds);
                    toolStripStatTime.Text = "Elapsed time: " + TotTimeStr;
                    StatBar.Refresh();
                }

            } while (ActIndex < FilesCount-1);
            do                                          // cekani na dokonceni vsech threadu
            {
                Application.DoEvents();
                Thread.Sleep(200);
                ElapsedTime = FindProcTimer.Elapsed;
                TotTimeStr = String.Format("{0:00}:{1:00}:{2:00}", ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds);
                toolStripStatTime.Text = "Elapsed time: " + TotTimeStr;
                StatBar.Refresh();
                
            } while (thrcounter.CurrentCount > 1);

            FindProcTimer.Stop();

            toolStripStatusPrg.Text = "State: Idle";
            toolStripStatFileCount.Visible = false;
            toolStripStatTime.Visible = false;
            toolStripDuplicityFound.Text = "Duplicity files count: " + DuplicityFilesCount.ToString();
            toolStripDuplicityFound.Visible = true;
            StatBar.Refresh();
            ElapsedTime = FindProcTimer.Elapsed;
            TotTimeStr = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ElapsedTime.Hours, ElapsedTime.Minutes, ElapsedTime.Seconds, ElapsedTime.Milliseconds / 10);
            MessageBox.Show("Finished\r\n" + "Total time:" + TotTimeStr, "Process Finished", MessageBoxButtons.OK);
        }
    }


    public class FileInfosWrapper
    {
        public FileInfos onerec;
    }
}
