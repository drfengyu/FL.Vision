using FL.Vision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FL.Vision.Tools
{
    public partial class WindowShow : UserControl
    {
        public WindowShow()
        {
            InitializeComponent();
        }
        private TableLayoutPanel _myLayout = null;

        private void GetShowPanel(int count)
        {
            tp1.Visible = false;
            tp2.Visible = false;
            tp4.Visible = false;
            tp6.Visible = false;
            tp8.Visible = false;
            _myLayout?.Controls.Clear();
            switch (count)
            {
                case 1:
                    tp1.Visible = true;
                    _myLayout = tp1;
                    break;
                case 2:
                    tp2.Visible = true;
                    _myLayout = tp2;
                    break;
                case 3:
                case 4:
                    tp4.Visible = true;
                    _myLayout = tp4;
                    break;
                case 5:
                case 6:
                    tp6.Visible = true;
                    _myLayout = tp6;
                    break;
                case 7:
                case 8:
                    tp8.Visible = true;
                    _myLayout = tp8;
                    break;
                default:
                    tp1.Visible = true;
                    _myLayout = tp1;
                    break;
            }
            _myLayout.BringToFront();
            _myLayout.Controls.Clear();
            _myLayout.Dock = DockStyle.Fill;
        }

        public void ShowUnit(string name = "All")
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }
            if (name == "All")


            {
                GetShowPanel(VisionManager.Instance.ProjectData.ProcessCount);
                for (var i = 0; i < VisionManager.Instance.ProjectData.ProcessCount; i++)
                {
                    
                        AddControl(_myLayout, VisionManager.Instance.ProjectData.Processes[i].RenderControl, i + 1);
                    
                }
            }
            else
            {
                GetShowPanel(1);

                AddControl(_myLayout, VisionManager.Instance.ProjectData.Processes.Find(x => x.Name == name).RenderControl, 1);
            }
        }

        /// <summary>
        /// 添加控件
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="control"></param>
        /// <param name="index"></param>
        private void AddControl(TableLayoutPanel panel, UserControl control, int index)
        {
            int row, col;
            switch (index)
            {
                case 1:
                    row = 0;
                    col = 0;
                    break;
                case 2:
                    row = 0;
                    col = 1;
                    break;
                case 3:
                    if (VisionManager.Instance.ProjectData.ProcessCount > 4)
                    {
                        row = 0;
                        col = 2;
                    }
                    else
                    {
                        row = 1;
                        col = 0;
                    }
                    break;
                case 4:
                    if (VisionManager.Instance.ProjectData.ProcessCount > 4)
                    {
                        row = 0;
                        col = 3;
                    }
                    else
                    {
                        row = 1;
                        col = 1;
                    }
                    break;
                case 5:
                    if (VisionManager.Instance.ProjectData.ProcessCount > 6)
                    {
                        row = 1;
                        col = 0;
                    }
                    else
                    {
                        row = 1;
                        col = 0;
                    }
                    break;
                case 6:
                    if (VisionManager.Instance.ProjectData.ProcessCount > 6)
                    {
                        row = 1;
                        col = 1;
                    }
                    else
                    {
                        row = 1;
                        col = 1;
                    }
                    break;
                case 7:
                    row = 1;
                    col = 2;
                    break;
                case 8:
                    row = 1;
                    col = 3;
                    break;
                default:
                    row = 0;
                    col = 0;
                    break;
            }

            control.Dock = DockStyle.Fill;
            panel.Controls.Add(control, col, row);
        }
    }
}
