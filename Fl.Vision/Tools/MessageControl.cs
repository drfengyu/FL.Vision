using FL.Vision.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FL.Vision.Tools
{
    public partial class MessageControl : UserControl
    {
        private readonly string LogPath= Application.StartupPath + "/Log/Message";
        public MessageControl()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="strMsg"></param>
        public void LogFunction(string strMsg,bool Show=true)
        {
            if (Show) {
                this.BeginInvoke(new Action(() =>
                {
                    ListViewItem listViewItem = new ListViewItem();
                    listViewItem.SubItems.Add("");
                    listViewItem.SubItems[0].Text = DateTime.Now.ToString();
                    listViewItem.SubItems[1].Text = strMsg;
                    listViewLog.Items.Insert(0, listViewItem);
                }));
            }
            SaveLog(strMsg);
        }

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewLog.Items.Clear();
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="str"></param>
        private void SaveLog(string str)
        {
            
            Task.Run(() =>
            {
                try
                {
                    if (!Directory.Exists(LogPath))//如果日志目录不存在就创建
                    {
                        Directory.CreateDirectory(LogPath);
                    }
                    string filename = LogPath + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名
                    StreamWriter mySw = File.AppendText(filename);
                    mySw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss::ffff\t") + str);
                    mySw.Close();
                }
                catch
                {
                    return;
                }
            });
        }

        
    }
}
