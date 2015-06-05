using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastedFileDeepCloneTool
{
    public partial class LastedFileDeepCloneTool : Form
    {
        private const string versionBetaAuthor = "Version 1.2beta\r\nAuthor：白义麟 \r\n欢迎提出各种改进建议!";
        private const string ConfigFile = "config.ini";
        private const string XmlConfigFile = "config.xml";
        private readonly List<string> defectiveFiles;
        private string sourceFolderPath, outputFolderPath, outputFolderPathWithDate;
        private int progress;
        private bool userCancel;
        private readonly BackgroundWorker backgroundWorker;
        private DateTime beginDateTime = DateTime.Now;
        private LocalPersistenceConfig config;
        private bool pressCtrl = false;
        public LastedFileDeepCloneTool()
        {
            InitializeComponent();
            backgroundWorker = new BackgroundWorker { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
            backgroundWorker.DoWork += backgroundWorkDoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorkRunWorkerCompleted;
            backgroundWorker.ProgressChanged += backgroundWorkerProgressChanged;
            chkCustomFolder.Checked = true;
            defectiveFiles = new List<string>();
            config = new LocalPersistenceConfig();
            if (File.Exists(XmlConfigFile))
            {
                
                //config = IOTool.DeserializeObject<LocalPersistenceConfig>(File.ReadAllBytes(ConfigFile));
                config = IOTool.XmlDeserializeObject<LocalPersistenceConfig>(XmlConfigFile);
                if (config != null)
                {
                    chkCustomFolder.Checked = config.CustomFolderChkState;
                    sourceFolderPath = config.LastSourcePath;
                    outputFolderPath = config.LastOutputPath;
                    txtHour.Text = config.MinusHour;
                    chkExcludeSuffix.Checked = config.ExcludeSuffixChkState;
                    txtExcludeSuffix.Text = config.ExcludeSuffixTxt;
                    txtDetectedPath.Text = sourceFolderPath;
                    txtOutputPath.Text = outputFolderPath;
                    txtExcludeSuffix.Enabled = chkExcludeSuffix.Checked;
                    txtExcludeFolder.Text = config.ExcludeFolderTxt;
                    chkExcludeFolder.Checked = config.ExcludeFolderChkState;
                }
            }
            this.KeyPreview = true;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (this.pressCtrl)
            {
                System.Diagnostics.Process.Start("Explorer.exe", sourceFolderPath);
                pressCtrl = false;
            }
            else
            {
                folderBrowserDialog1.Description = "请选择待检索目标文件夹";
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.SelectedPath = sourceFolderPath;
                if (string.IsNullOrEmpty(sourceFolderPath))
                    folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    sourceFolderPath = folderBrowserDialog1.SelectedPath;
                }
                if (!string.IsNullOrEmpty(sourceFolderPath))
                {
                    progress = 0;
                    userCancel = false;
                    txtDetectedPath.Text = sourceFolderPath;
                }
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            defectiveFiles.Clear();
            if (string.IsNullOrEmpty(outputFolderPath) || string.IsNullOrEmpty(sourceFolderPath)) return;
            AllButtonDisable();
            if (!string.IsNullOrEmpty(sourceFolderPath))
            {
                progress = 0;
                userCancel = false;
            }
            int hour;
            int.TryParse(txtHour.Text, out hour);
            beginDateTime = dtpBeginDate.Value.AddHours(-hour);

            if (chkCustomFolder.Checked)
            {
                outputFolderPathWithDate = string.Empty;

                int sign = outputFolderPath.IndexOf(DateTime.Now.ToString("yyyy"));
                if (sign > -1)
                {
                    outputFolderPath = outputFolderPath.Replace(outputFolderPath.Substring(sign), string.Empty);
                }
                outputFolderPathWithDate = Path.Combine(outputFolderPath, DateTime.Now.ToString("yyyy_MM_dd_HH_mm"));
                outputFolderPath = outputFolderPathWithDate;
                if (!Directory.Exists(outputFolderPath))
                    Directory.CreateDirectory(outputFolderPath);
            }
            txtOutputPath.Text = outputFolderPath;
            backgroundWorker.RunWorkerAsync();
            richTextBox1.Clear();
        }

        private void AllButtonDisable()
        {
            btnChooseSource.Enabled = false;
            btnChooseOutput.Enabled = false;
            btnLaunch.Enabled = false;
        }
        private void AllButtonEnable()
        {
            btnChooseSource.Enabled = true;
            btnChooseOutput.Enabled = true;
            btnLaunch.Enabled = true;
        }

        private void DetectFolders(string folderPath, bool isRoot)
        {
            var directoryInfo = new DirectoryInfo(folderPath);

            if (isRoot)
            {
                if (HandleDirInfo(directoryInfo, isRoot)) return;
            }
            foreach (DirectoryInfo dirInfo in directoryInfo.GetDirectories())
            {
                //忽略掉设置了明确过滤指定名称的文件夹
                if (chkExcludeFolder.Checked && IOTool.IsSpecifiedFolder(dirInfo, txtExcludeFolder.Text)) { continue; }
                if (HandleDirInfo(dirInfo, false)) return;
                DetectFolders(dirInfo.FullName, false);
            }
        }

        private bool HandleDirInfo(DirectoryInfo dirInfo, bool isRoot)
        {
         
            foreach (FileInfo fileInfo in dirInfo.GetFiles())
            {
                if (backgroundWorker.CancellationPending)
                {
                    return true;
                }         
                //忽略掉设置了明确过滤后缀名的文件
                if (chkExcludeSuffix.Checked&& IOTool.IsSpecifiedSuffix(fileInfo, txtExcludeSuffix.Text)) {continue;}
                if (IOTool.IsLastedFile(fileInfo, beginDateTime))
                {
                    defectiveFiles.Add(fileInfo.FullName);
                    if (dirInfo.FullName != sourceFolderPath)
                    {

                        var outputFolderDir = outputFolderPath + dirInfo.FullName.Replace(sourceFolderPath, string.Empty);
                        if (!Directory.Exists(outputFolderDir))
                            Directory.CreateDirectory(outputFolderDir);
                    }
                    var finalOutputPath = outputFolderPath + fileInfo.FullName.Replace(sourceFolderPath, string.Empty);
                    File.Copy(fileInfo.FullName, finalOutputPath, true);
                    backgroundWorker.ReportProgress(progress++, new DirProgressWrapper
                    {
                        IsDir = false,
                        Value =
                            string.Format("-->【{0}】：{1}{2}",
                                          defectiveFiles.Count.ToString(),
                                         finalOutputPath,
                                          Environment.NewLine)
                    });
                }
            }
            return false;
        }

        private void backgroundWorkDoWork(object sender, DoWorkEventArgs e)
        {
            DetectFolders(sourceFolderPath, true);
        }
        private void backgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var dirProgress = e.UserState as DirProgressWrapper;
            if (dirProgress != null)
                richTextBox1.AppendText(dirProgress.Value);
        }
        private void backgroundWorkRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ConfigruationPersistence();
            richTextBox1.AppendText("Done!");
            AllButtonEnable();
        }

        private void ConfigruationPersistence()
        {
            config.LastSourcePath = sourceFolderPath;
            config.LastOutputPath = outputFolderPath;
            config.CustomFolderChkState = chkCustomFolder.Checked;
            config.MinusHour = txtHour.Text;
            config.ExcludeSuffixChkState = chkExcludeSuffix.Checked;
            config.ExcludeSuffixTxt = txtExcludeSuffix.Text;
            config.ExcludeFolderChkState = chkExcludeFolder.Checked;
            config.ExcludeFolderTxt = txtExcludeFolder.Text;
            //File.WriteAllBytes(ConfigFile, IOTool.SerializeObject<LocalPersistenceConfig>(config));
            IOTool.XmlSerializeObject<LocalPersistenceConfig>(config,XmlConfigFile);
        }

        private void btnChooseOutput_Click(object sender, EventArgs e)
        {
            if (this.pressCtrl)
            {
                System.Diagnostics.Process.Start("Explorer.exe", outputFolderPath);
                pressCtrl = false;
            }
            else
            {
                folderBrowserDialog1.Description = "请选择输出目标文件夹";
                folderBrowserDialog1.ShowNewFolderButton = true;
                folderBrowserDialog1.SelectedPath = outputFolderPath;
                if (string.IsNullOrEmpty(sourceFolderPath)) folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    outputFolderPath = folderBrowserDialog1.SelectedPath;
                    txtOutputPath.Text = outputFolderPath;
                }
            }


        }

        private void txtHour_KeyPress(object sender, KeyPressEventArgs e)
        {
            //只允许输入数字
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
            base.OnKeyPress(e);
        }

        private void LastedFileDeepCloneTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfigruationPersistence();
        }

        private void LastedFileDeepCloneTool_Load(object sender, EventArgs e)
        {

        }

        private void LastedFileDeepCloneTool_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            MessageBox.Show(versionBetaAuthor);
        }

        private void LastedFileDeepCloneTool_KeyDown(object sender, KeyEventArgs e)
        {
            //Ctrl
            if (e.KeyValue == 17)
            {
                pressCtrl = true;
            }
            else
            {
                pressCtrl = false;
            }
        }

        private void chkExcludeSuffix_CheckedChanged(object sender, EventArgs e)
        {
            txtExcludeSuffix.Enabled = chkExcludeSuffix.Checked;
        }

        private void chkExcludeFolder_CheckedChanged(object sender, EventArgs e)
        {
            txtExcludeFolder.Enabled = chkExcludeFolder.Checked;
        }






    }

    [Serializable]
    public class LocalPersistenceConfig
    {
        public string LastSourcePath { get; set; }
        public string LastOutputPath { get; set; }
        public bool CustomFolderChkState { get; set; }
        public string MinusHour { get; set; }
        public bool ExcludeSuffixChkState { get; set; }
        public string ExcludeSuffixTxt { get; set; }
        public bool ExcludeFolderChkState { get; set; }
        public string ExcludeFolderTxt { get; set; }
    }

    public class DirProgressWrapper
    {
        public bool IsDir { get; set; }
        public string Value { get; set; }
    }
}
