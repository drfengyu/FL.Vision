using Apps.Localization;
using Apps.UIHelper.Extern;
using FL.Vision;
using FL.Vision.Functions;
using FL.Vision.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.PlatformSDKCS;

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
            //AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
            // 指示应用程序如何响应未经处理的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // 处理UI线程异常
            Application.ThreadException += Application_ThreadException;
            // 处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Mutex mutex = new Mutex(false, "VisionMaster", out var createNew);

            if (!createNew)
            {
                MessageBox.Show("软件已经打开");
                Environment.Exit(1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            string assemblyPath = AppDomain.CurrentDomain.BaseDirectory;
            string assemblyName = new AssemblyName(args.Name).Name.Replace(".resources","") + ".dll";
            string fullPath = Path.Combine(assemblyPath, assemblyName);

            if (File.Exists(fullPath))
            {
                return Assembly.LoadFrom(fullPath);
            }

            return null; // 返回 null 以继续使用默认的加载机制
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {

            if (e.ExceptionObject is VmException) {
                ShowMessage.ShowVmExceptionMessage(e.ExceptionObject as VmException);
                VisionManager.Instance?.RightControl?.LogFunction(AppLocalizationService.GetLang(ErrorCodeInfo.GetErrorInfo((e.ExceptionObject as VmException).errorCode)));
            } else {
                VisionManager.Instance?.RightControl?.LogFunction(e.ExceptionObject.ToString());
            }


            
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is VmException)
            {
                ShowMessage.ShowVmExceptionMessage(e.Exception as VmException);
                VisionManager.Instance?.RightControl?.LogFunction(AppLocalizationService.GetLang(ErrorCodeInfo.GetErrorInfo((e.Exception as VmException).errorCode)));
            }
            else
            {
                VisionManager.Instance?.RightControl?.LogFunction(e.Exception.Message);
            }
        }
    }
}
