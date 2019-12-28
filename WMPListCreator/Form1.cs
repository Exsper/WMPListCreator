using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace WMPListCreator
{
    /* 已知问题：
     * 1.在访问前未检查目标文件夹权限导致访问出错
     * 
     * 2016.4.24 By Exsper
    */

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool iscreating;
        private System.Text.StringBuilder state = new System.Text.StringBuilder();//用stringbuffer显示状态

        private void SelectFolderBotton_Click(object sender, EventArgs e)
        {
            StatusLabel.Text = "选择文件夹";
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "请选择文件夹";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string foldPath = dialog.SelectedPath;
                    if (FolderTextBox.Text == "")
                    {
                        FolderTextBox.Text = foldPath;
                    }
                    else
                    {
                        FolderTextBox.Text = FolderTextBox.Text + "|" + foldPath;
                    }
                }
            }
            StatusLabel.Text = "就绪";
        }

        private void ResetFileTypeButton_Click(object sender, EventArgs e)
        {
            FileTypeTextBox.Text = "wma|wav|mp3|mid|midi|m4a|aac|ogg|alac|flac|ape|aiff|wv";
        }

        /// <summary>
        /// 根据文件名返回文件名的后缀名，不包括前面的"."，如果文件没有后缀名则返回空字符串
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns> 后缀名，不包括前面的"."，如果文件没有后缀名则返回空字符串 </returns>
        private static string GetFileNameExt(string fileName)
        {
            string ext;
            int extindex;
            try
            {
                extindex = fileName.LastIndexOf('.');
                if (extindex >= 0)
                {
                    ext = fileName.Substring(extindex + 1);
                }
                else
                {
                    ext = "";
                }
            }
            catch
            {
                ext = "";
            }
            return ext;
        }

        private bool FileTypeCheck(string fpath)
        {
            string fe = GetFileNameExt(fpath);
            string[] filetype = FileTypeTextBox.Text.Split(new char[] {'|'},StringSplitOptions.RemoveEmptyEntries);
            foreach (string type in filetype)
            {
                if (type.Equals(fe, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }
            return false;
        }

        private void WriteFile(List<String> songpathlist,string listfilepath)
        {
            if (File.Exists(listfilepath))
            {
                StatusLabel.Text = "检测到文件名重名";
                DialogResult dr = MessageBox.Show("是否要覆盖原文件？", "文件名重名", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.No)
                {
                    iscreating = false;
                    StatusLabel.Text = "任务已取消";
                    return;
                }
            }
            string filename = listfilepath.Substring(listfilepath.LastIndexOf("\\") + 1);//有后缀的列表文件名
            int c = filename.Length;
            string ffolder = listfilepath.Substring(0, listfilepath.Length - c);//列表文件所在目录路径
            if (Directory.Exists(ffolder) == false) //列表文件所在目录不存在时创建目录
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(ffolder);
                directoryInfo.Create();
            }
            filename = filename.Substring(0, filename.LastIndexOf("."));//无后缀的列表文件名
            string realname;//包含路径的写入格式
            StatusLabel.Text = "创建写入文件";
            int listnum = songpathlist.Count;
            int filenum = 0;
            FileStream fs1 = new FileStream(listfilepath, FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs1);
            sw.WriteLine("<?wpl version=\"1.0\"?>");
            sw.WriteLine("<smil>");
            sw.WriteLine("    <head>");
            sw.WriteLine("        <meta name=\"Generator\" content=\"WMPListCreator 1.2 By Exsper\"/>");
            sw.WriteLine("        <meta name=\"ItemCount\" content=\""+listnum.ToString()+"\"/>");
            sw.WriteLine("        <title>" + filename + "</title>");
            sw.WriteLine("    </head>");
            sw.WriteLine("    <body>");
            sw.WriteLine("        <seq>");
            StateTimer.Start();
            if (AbsoluteRadioButton.Checked == true) //绝对路径
            {
                foreach (string s in songpathlist)
                {
                    realname = "            <media src=\"" + s + "\"/>";
                    //替换文件名
                    realname = realname.Replace("&", "&amp;");//& -> &amp;
                    realname = realname.Replace("'", "&apos;");//' -> &apos;
                    //----------
                    sw.WriteLine(realname);
                    filenum++;
                    //StatusLabel.Text = "正在生成 " + filenum.ToString() + "/" + listnum.ToString();
                    state.Clear();
                    state.Append("正在生成 " + filenum.ToString() + "/" + listnum.ToString());
                }
            }
            else //相对路径
            {
                foreach (string songpath in songpathlist)
                {
                    //绝对路径转换为相对路径
                    /*
                     * 路径会当成地址处理，特殊字符会进行转换，不可行
                    System.Uri uri1 = new Uri(songpath);
                    System.Uri uri2 = new Uri(listfilepath);
                    Uri relativeUri = uri2.MakeRelativeUri(uri1);
                    realname = "            <media src=\"" + relativeUri.ToString() + "\"/>";
                    */
                    realname = "            <media src=\"" + AbsolutePath2RelativePath.A2R(ffolder, songpath) + "\"/>";
                    //替换文件名
                    realname = realname.Replace("&", "&amp;");//& -> &amp;
                    realname = realname.Replace("'", "&apos;");//' -> &apos;
                    //----------
                    sw.WriteLine(realname);
                    filenum++;
                    //StatusLabel.Text = "正在生成 " + filenum.ToString() + "/" + listnum.ToString();
                    state.Clear();
                    state.Append("正在生成 " + filenum.ToString() + "/" + listnum.ToString());
                }
            }
            StateTimer.Stop();
            sw.WriteLine("        </seq>");
            sw.WriteLine("    </body>");
            sw.WriteLine("</smil>");
            sw.Flush();
            sw.Close();
            fs1.Close();
            iscreating = false;
            StatusLabel.Text = "文件创建完成！共添加 " + songpathlist.Count.ToString() + " 首曲目";
        }

        private void SendToWriteFile(List<String> l, string fp)
        {
            l = l.Distinct().ToList();//删除重复项
            if (l.Count <= 0)
            {
                StatusLabel.Text = "未搜寻到任何音乐";
                iscreating = false;
                return;
            }
            else
            {
                StatusLabel.Text = "搜寻完毕，正在生成文件";
                WriteFile(l, fp);
            }
        }

        private List<string> AddSongsI(string fo)
        {
            /*
            List<String> list = new List<string>();
            StatusLabel.Text = "开始遍历文件夹";
            DirectoryInfo theFolder = new DirectoryInfo(fo);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.AllDirectories);
            StateTimer.Start();
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
            {
                if (FileTypeCheck(NextFile.FullName) == true)
                {
                    list.Add(NextFile.FullName);
                    //StatusLabel.Text = "搜寻到音乐 " + list.Count.ToString() + " " + NextFile.FullName;
                    state.Clear();
                    state.Append("搜寻到音乐 " + list.Count.ToString() + " " + NextFile.FullName);
                }
            }
            StateTimer.Stop();
            return list;
            */

            List<String> list = new List<string>();
            StatusLabel.Text = "开始遍历文件夹";
            Stack<string> skDir = new Stack<string>();
            skDir.Push(fo);
            while (skDir.Count > 0)
            {
                fo = skDir.Pop();
                string[] subDirs = Directory.GetDirectories(fo);
                string[] subFiles = Directory.GetFiles(fo);
                if (subDirs != null)
                {
                    for (int i = 0; i < subDirs.Length; i++)
                    {
                        //string dirName = Path.GetFileName(subDirs[i]);
                        skDir.Push(subDirs[i]);
                        state.Clear();
                        state.Append("搜索文件夹 " + subDirs[i]);
                    }
                }
                if (subFiles != null)
                {
                    for (int i = 0; i < subFiles.Length; i++)
                    {
                        //string fileName = Path.GetFileName(subFiles[i]);
                        // 处理文件
                        //Console.WriteLine(subFiles[i]);
                        if (FileTypeCheck(subFiles[i]) == true)
                        {
                            list.Add(subFiles[i]);
                            state.Clear();
                            state.Append("搜寻到音乐 " + list.Count.ToString() + " " + subFiles[i]);
                        }
                    }
                }
            }
            return list;

        }

        private List<string> AddSongs(string fo)
        {
            List<String> list = new List<string>();
            StatusLabel.Text = "开始遍历文件夹";
            DirectoryInfo theFolder = new DirectoryInfo(fo);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            StateTimer.Start();
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
            {
                if (FileTypeCheck(NextFile.FullName) == true)
                {
                    list.Add(NextFile.FullName);
                    //StatusLabel.Text = "搜寻到音乐 " + list.Count.ToString() + " " + NextFile.FullName;
                    state.Clear();
                    state.Append("搜寻到音乐 " + list.Count.ToString() + " " + NextFile.FullName);
                }
            }
            StateTimer.Stop();
            return list;
        }

        private void MainCreator()
        {
            string[] FolderList = FolderTextBox.Text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string SavePath = FileNameTextBox.Text;
            List<String> list = new List<string>();
            if (IncludeSubFolder.Checked == false)//不包含子文件夹
            {
                foreach (string folder in FolderList)
                {
                    list.AddRange(AddSongs(folder));
                }
            }
            else
            {
                foreach (string folder in FolderList)
                {
                    list.AddRange(AddSongsI(folder));
                }
            }
            SendToWriteFile(list, SavePath);
        }

        private void CreateWPLButton_Click(object sender, EventArgs e)
        {
            //检测任务
            if (iscreating == true)
            {
                MessageBox.Show("请先等待上一个任务完成", "请等待", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //文件夹地址分割并检查
            string[] FolderList = FolderTextBox.Text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Folder in FolderList)
            {
                if (Directory.Exists(Folder) == false)
                {
                    MessageBox.Show(Folder + " 文件夹路径错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (FolderList.Length <= 0)
            {
                MessageBox.Show("请至少选择一个文件夹", "选择搜寻文件夹");
                return;
            }
            //检查文件保存路径
            /*
            if (string.IsNullOrWhiteSpace(FileNameTextBox.Text))
            {
                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Filter = "WPL文件   (*.wpl)|*.wpl";
                SaveFile.RestoreDirectory = true;
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    if (SaveFile.OpenFile() != null)
                    {
                        FileNameTextBox.Text = SaveFile.FileName.ToString();
                    }
                }
            }
            */
            //获取文件名，不带路径
            string fileNameExt = FileNameTextBox.Text.Substring(FileNameTextBox.Text.LastIndexOf("\\") + 1);
            if (string.IsNullOrWhiteSpace(fileNameExt))
            {
                MessageBox.Show("保存文件名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (fileNameExt.IndexOfAny(Path.GetInvalidFileNameChars()) >=0)
            {
                MessageBox.Show("保存文件名不合法！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //没有后缀名则添上一个
            if (Path.GetExtension(fileNameExt) == "")
            {
                FileNameTextBox.Text += ".wpl";
            }
            //获取文件路径，不带文件名
            string FilePath = FileNameTextBox.Text.Substring(0, FileNameTextBox.Text.LastIndexOf("\\"));
            if (string.IsNullOrWhiteSpace(FilePath))
            {
                MessageBox.Show("保存文件路径不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FilePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
            {
                MessageBox.Show("保存文件路径不合法！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //文件夹地址确认
            if (FolderList.Length > 1)
            {
                DialogResult dr = MessageBox.Show("即将添加下列文件夹内的音乐文件：\n" + string.Join("\n", FolderList), "文件夹确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (dr == DialogResult.No)
                {
                    return;
                }
            }
            //开始生成
            iscreating = true;
            Thread fThread = new Thread(new ThreadStart(MainCreator));//开辟一个新的线程
            StatusLabel.Text = "运行中";
            fThread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iscreating = false;
            state.Capacity = 50;//最大长度50
            StatusLabel.Text = "就绪";
            FileTypeTextBox.Text = "wma|wav|mp3|mid|midi|m4a|aac|ogg|alac|flac|ape|aiff|wv";
        }

        private void FolderTextBox_Enter(object sender, EventArgs e)
        {
            StatusLabel.Text = "输入文件夹路径。多文件夹之间用 | 分割";
        }

        private void FileTypeTextBox_Enter(object sender, EventArgs e)
        {
            StatusLabel.Text = "输入搜寻的文件名后缀。多文件名后缀之间用 | 分割";
        }

        private void FileNameTextBox_Enter(object sender, EventArgs e)
        {
            StatusLabel.Text = "输入生成Wpl文件的完整路径。";
        }

        private void SelectFolderBotton_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "选择要搜寻的文件夹。";
        }

        private void CreateWPLButton_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "开始生成文件。";
        }

        private void FolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FolderTextBox.Text) == false)
            {
                string[] FolderList = FolderTextBox.Text.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                FileNameTextBox.Text = FolderList[0] + "\\新建播放列表.wpl";
            }
        }

        private void IncludeSubFolder_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "勾选后，搜寻文件夹时也搜寻其内部的子文件夹。";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (iscreating == true)
            {
                if (DialogResult.No == MessageBox.Show("文件尚在生成中，你确定退出吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    e.Cancel = true;
                }
            }
        }

        private void ResetFileTypeButton_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "恢复到默认的搜寻文件名后缀。";
        }

        private void StateTimer_Tick(object sender, EventArgs e)
        {
            StatusLabel.Text = state.ToString();
        }

        private void AbsoluteRadioButton_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "文件使用绝对路径，可以自由移动播放列表文件，但不能移动包含在列表内的音乐文件。";
        }

        private void RelativeRadioButton_MouseEnter(object sender, EventArgs e)
        {
            StatusLabel.Text = "文件使用相对路径，如果播放列表与音乐文件在同一文件夹内，则可以自由移动该文件夹。";
        }

        private void FolderTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void FolderTextBox_DragDrop(object sender, DragEventArgs e)
        {
            StringBuilder foldersName = new StringBuilder("");
            Array file = (System.Array)e.Data.GetData(DataFormats.FileDrop); //多文件夹拖拽

            foreach (object I in file)
            {
                string str = I.ToString();

                System.IO.FileInfo info = new System.IO.FileInfo(str);
                if ((info.Attributes & System.IO.FileAttributes.Directory) != 0) //判断为文件夹
                {
                    if (!str.Equals("")) foldersName.Append((foldersName.Length == 0 ? "" : "|") + str);
                }

                FolderTextBox.Text = foldersName.ToString();
            }
        }
    }
}
