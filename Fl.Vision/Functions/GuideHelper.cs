using Apps.Localization;
using FL.Vision.MenuView.Settings;
using FL.Vision.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VM.Utility;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using Process = System.Diagnostics.Process;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
namespace FL.Vision.Functions
{
    public static class GuideHelper
    {
        private const string GuideSettingNode = "GuideSetting";

        internal const string ShowEnableNode = "ShowEnable";

        private const string LocalHelpNode = "LocalHelp";

        private const string OnlineHelpNode = "OnlineHelp";

        private const string HelpDocNode = "HelpDoc";

        private const string HelpDocStd = "HelpDocStd";

        private const string HelpDocNeu = "HelpDocNeu";
        private const string NewSol = "Project";

        public static bool IsGuideWindowShow()
        {
            return bool.Parse(ConfigurationHelper.GetConfig("ShowEnable"));
        }

        private static XElement GetElement(XDocument xDoc, string nodename)
        {
            if (xDoc.Root == null)
            {
                return null;
            }
            return xDoc.Root.Elements().SingleOrDefault((XElement p) => p.Name == "GuideSetting")?.Elements().SingleOrDefault((XElement p) => p.Name == nodename);
        }

        private static XElement GetHelpElement(XDocument xDoc, string nodename)
        {
            if (xDoc.Root == null)
            {
                return null;
            }
            return xDoc.Root.Elements().SingleOrDefault((XElement p) => p.Name == "HelpDoc")?.Elements().SingleOrDefault((XElement p) => p.Name == nodename);
        }

        public static void SetGuideWindowOn()
        {
            ConfigurationHelper.SaveConfig("ShowEnable", "true");
        }

        public static void SetGuideWindowOff()
        {
            ConfigurationHelper.SaveConfig("ShowEnable", "false");
        }

        public static bool OpenSolution(bool opendemo,out string filename, bool IsNew = false)
        {
            if (IsNew)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = string.Format("{0}|*.sol", "新建方案") };
                try
                {
                    saveFileDialog.InitialDirectory=Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Project");
                    saveFileDialog.ShowDialog();
                    filename = saveFileDialog.FileName;
                    saveFileDialog.Dispose();
                    if (string.IsNullOrEmpty(filename))
                    {
                        return false;
                    }
                    return true;
                }
                finally {
                    saveFileDialog.Dispose();
                }
            }
            else { 

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = string.Format("{0}|*.sol", opendemo ? AppLocalizationService.GetLang("示例方案") :AppLocalizationService.GetLang("方案"))
            };
            try
            {
                if (opendemo)
                {
                    string config = ConfigurationHelper.GetConfig("demo");
                    DirectoryInfo directoryInfo = new DirectoryInfo(ConfigurationHelper.GetConfig("ApplicationPath") + config);
                    if (directoryInfo.Exists)
                    {
                        openFileDialog.InitialDirectory = directoryInfo.FullName;
                    }
                }
                openFileDialog.ShowDialog();
                filename = openFileDialog.FileName;
                openFileDialog.Dispose();
                if (string.IsNullOrEmpty(filename))
                {
                    return false;
                }
                return true;
            }
            finally
            {
                openFileDialog.Dispose();
            }

            }
        }

        public static void GetHelp(bool local)
        {
            if (local)
            {
                string text = "";
               
                text = AppLocalizationService.GetLang(GetHelpPathFile(false));
               
                try
                {
                    ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    string currentDirectory = Environment.CurrentDirectory;
                    processStartInfo.FileName = currentDirectory + text;
                    processStartInfo.UseShellExecute = true;
                    processStartInfo.CreateNoWindow = true;
                    processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    processStartInfo.RedirectStandardOutput = false;
                    processStartInfo.WorkingDirectory = text;
                    Process.Start(processStartInfo);
                    return;
                }
                catch (Exception)
                {
                    MessageBox.Show(AppLocalizationService.GetLang("Lang_HelpFileLack"));
                    VisionManager.Instance.RightControl.LogFunction("帮助文档缺失");
                    return;
                }
            }
            string text2 = ConfigurationHelper.GetConfig(local ? "LocalHelp" : "OnlineHelp");
            if (AppLocalizationService.GetLang("Language") == "English")
            {
                text2 += "en";
            }
           
                Process.Start(text2);
           
        }

        public static string GetHelpPathFile(bool ifMeu = false)
        {
            return ConfigurationHelper.GetConfig(ifMeu ? "HelpDocNeu" : "HelpDocStd");
        }
    }

}
