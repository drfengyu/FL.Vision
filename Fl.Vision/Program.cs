using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fl.Vision
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 指示应用程序如何响应未经处理的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // 处理UI线程异常
            Application.ThreadException += Application_ThreadException;
            // 处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Mutex mutex = new Mutex(false, "MaskLogo", out var createNew);

            if (!createNew)
            {
                MessageBox.Show("软件已经打开");
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
