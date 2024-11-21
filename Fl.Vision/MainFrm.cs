using FL.Vision.Functions;
using FL.Vision.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using VM.Core;

namespace Fl.Vision
{
    public partial class MainFrm : Form
    {
        public string FilePath { set; get; }
        public string SaveAsPath { set; get; }
        public string SamplePath { set; get; }
        public MainFrm()
        {
            InitializeComponent();
            WindowShow windowShow = new WindowShow();

            //panel2.Controls.Clear();
            //GlobalToolControl globalTool=new GlobalToolControl();
            
            //panel2.Controls.Add(globalTool);
            //this.Width = Screen.PrimaryScreen.WorkingArea.Width;//获取当前屏幕显示区域大小，让窗体长宽等于这个值，这里不包含任务栏哦
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;//这样窗体打开的时候直接就是屏幕的大小了
                
        }

        private void 打开方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "VM Sol File|*.sol*";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (DialogResult.OK == dialogResult)
            {
                FilePath = openFileDialog.FileName;
            }
            if (string.IsNullOrEmpty(FilePath)) return;
            VmSolution.Load(FilePath);
            
        }

        private void 打开示例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SamplePath=SystemInfo.GetSystemEnvironmentVariable("MVCAM_COMMON_RUNENV");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "VM Sol File|*.sol*";
            openFileDialog.InitialDirectory = SamplePath;
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (DialogResult.OK == dialogResult)
            {
                FilePath = openFileDialog.FileName;
            }
            if (string.IsNullOrEmpty(FilePath)) return;
            VmSolution.Load(FilePath);
        }

        private void 新建方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 保存方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VmSolution.Save();
        }

        private void 方案另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "VM Sol File|*.sol*";
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (DialogResult.OK == dialogResult)
            {
                SaveAsPath = openFileDialog.FileName;
            }
            VmSolution.SaveAs(SaveAsPath);
        }

        private void 项目配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
