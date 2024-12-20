using Fl.Vision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionMasterMain;

namespace FL.Vision.MenuView.Settings
{
    public class GlobalSettings
    {
        public static string ApplicationPath { set; get; } = "F:\\App\\hkvision\\VisionMaster4.2.0\\Applications\\";
        public static void SoftwareSetDlgShow()
        {
            SoftwareSetDlg softwareSetDlg = new SoftwareSetDlg();
            softwareSetDlg.ShowDialog();
        }
    }
}
