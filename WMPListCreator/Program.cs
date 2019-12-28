using System;
using System.Windows.Forms;

namespace WMPListCreator
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool ret;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, Application.ProductName, out ret);
            if (ret)
            {
                Application.EnableVisualStyles();
                //Application.DoEvents();   //不使用以保证效率
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show(null,"当前已有一个相同的应用程序在运行，请不要同时运行多个本程序。", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit(); 
            }
        }
    }
}
