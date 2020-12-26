using Selene.Forms;
using System;
using System.IO;
using System.Windows.Forms;
using Selene.Manage;

namespace Selene
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateDataDir();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TreeTest01());
            Application.Run(new LoginForm());
        }

        private static void CreateDataDir()
        {
            CommonMessage.data_path = Application.StartupPath + CommonMessage.data_path;

            String fullDataDir = CommonMessage.data_path;
            if (!Directory.Exists(fullDataDir))
            {
                Directory.CreateDirectory(fullDataDir);
            }
        }
    }
}
