using FL.Vision.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using Vision.Functions;
using VM.Core;
using VM.PlatformSDKCS;

namespace FL.Vision.Models
{
    public class VisionManager
    {
        
        private static VisionManager _instance;
        public static VisionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VisionManager();
                }
                return _instance;
            }
        }
        private Project _project;
        /// <summary>
        /// Project数据
        /// </summary>
        public Project ProjectData
        {
            get => _project;
            set => _project = value;
        }

        

        public VisionManager() {
            RightControl=new MessageControl();
            CheckDirectory();
        }
        

        
        public bool IsSolLoaded { set; get; }

        public bool IsLoaded { set; get; }
        
        /// <summary>
        /// 项目根目录
        /// </summary>
        public string ProjectDir { set; get; }=Path.Combine(Directory.GetCurrentDirectory(), "Project");
        /// <summary>
        /// 项目配置文件
        /// </summary>
        public string ProjectPath { set; get; } = Path.Combine(Directory.GetCurrentDirectory(), "Project", "proj.vpr");

        //public string SolTempPath { set; get; } = Path.Combine(Directory.GetCurrentDirectory(),"NewSol");
        /// <summary>
        /// 方案路径
        /// </summary>
        public string SolPath { set; get; } = Path.Combine(Directory.GetCurrentDirectory(), "Project","masklogo.sol");

        private string logPath;//日志路径
        

        /// <summary>
        /// 日志路径
        /// </summary>
        public string LogPath { get => logPath; set => logPath = value; }

        
        /// <summary>
        /// 侧边功能配置+日志区
        /// </summary>
        public MessageControl RightControl { get;  }

        /// <summary>
        /// 打开项目,并加载执行一次
        /// </summary>
        public void OpenProject()
        {
            string strMsg = null;
            IsSolLoaded=false;
            if (!Directory.Exists(ProjectDir))
            {
                Directory.CreateDirectory(ProjectDir);
            }

            if (!File.Exists(SolPath)||SolPath==null)
            {
                //VmSolution.CreatSolInstance();
                strMsg = "未找到方案";
                RightControl.LogFunction(strMsg,false);
                IsSolLoaded = false;
            }
            try
            {
                VmSolution.Load(SolPath);
                strMsg = "方案加载成功";
                RightControl.LogFunction(strMsg,false);
                IsSolLoaded = true;
                Project data = new Project();
                VmSolution.Instance.SyncRun();
                strMsg = "方案执行一次成功";
                RightControl.LogFunction(strMsg, false);
                if (data != null)
                {
                    _project = data;
                    IsLoaded = true;
                }
            }
            catch (VmException ex)
            {
                IsLoaded = false;
                IsSolLoaded = false;
                strMsg = "加载方案出错. Error Code: " + Convert.ToString(ex.errorCode, 16);
                RightControl.LogFunction(strMsg, false);
                return;
            }
            catch (Exception ex) {
                IsLoaded = false;
                IsSolLoaded = false;
                strMsg = "加载方案出错:" + ex.ToString();
                RightControl.LogFunction(strMsg,false);
                return;
            }
        }

        /// <summary>
        /// 新建/打开方案时初始化
        /// </summary>
        /// <param name="IsNew">如果为true,代表是新建的方案,否则为打开的方案/示例</param>
        public void InitNewProject(bool IsNew=false) {
          
            ProjectData = new Project();
            SolPath = ProjectData.SolutionPath;
            ProjectDir = Path.GetDirectoryName(ProjectData.SolutionPath);
            RightControl.LogFunction($"项目路径:" + ProjectDir);
            RightControl.LogFunction($"方案名称:" +Path.GetFileName(SolPath));
            RightControl.LogFunction(IsNew?"新建方案成功":"打开方案成功");
        }

        public void SaveSolProject(bool IsSaveAs=false) {
            string path = "";
            if (!IsSaveAs)
            {
                VmSolution.Save();
                RightControl.LogFunction("方案保存成功");
            }
            else {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "VM Sol File|*.sol*";
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (DialogResult.OK == dialogResult)
                {
                    path = openFileDialog.FileName;
                }
                else
                {
                    return;
                }
                VmSolution.SaveAs(path);
                RightControl.LogFunction("方案另存成功");
                InitNewProject();
            }
            
        }

        private void CheckDirectory() {
            if (!Directory.Exists(ProjectDir))
            {
                Directory.CreateDirectory(ProjectDir);
            }
        }
    }
}
