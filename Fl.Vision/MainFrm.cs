using FL.Vision.Functions;
using FL.Vision.MenuView.Settings;
using FL.Vision.Models;
using FL.Vision.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using VM.Core;
using VM.PlatformSDKCS;
using VM.Utility;
using VMControls.Interface;
using VMControls.Winform.Release;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using UserControl = System.Windows.Forms.UserControl;

namespace Fl.Vision
{
    public partial class MainFrm : Form
    {
        private WindowShow windowShow;
        private MainViewControl mainViewControl;
        public ProcessInfoList vmProcessInfoList = new ProcessInfoList();//流程列表
        public MainFrm()
        {
            InitializeComponent();
            windowShow = new WindowShow();
            mainViewControl=new MainViewControl();
            buttonRender.BackColor = Color.Orange;
            buttonConfig.BackColor = Color.Gray;
            //VM回调事件
            VmSolution.OnWorkStatusEvent += VmSolution_OnWorkStatusEvent;//工作状态
            VmSolution.OnProcessStatusStartEvent += VmSolution_OnProcessStatusStartEvent;   // 开始连续执行状态回调
            VmSolution.OnProcessStatusStopEvent += VmSolution_OnProcessStatusStopEvent; // 结束连续执行状态回调
        }

        /// <summary>
        /// 流程执行回调
        /// </summary>
        /// <param name="workStatusInfo"></param>
        private void VmSolution_OnWorkStatusEvent(ImvsSdkDefine.IMVS_MODULE_WORK_STAUS workStatusInfo)
        {
            if (workStatusInfo.nWorkStatus == 0)//0为执行完毕，1为正在执行
            {
                try
                {
                    //switch (workStatusInfo.nProcessID)
                    //{
                    //    case 10000:
                    //        if (vmProcessInfoList.nNum == 0) return;
                    //        VmProcedure vmProcedure = (VmProcedure)VmSolution.Instance[vmProcessInfoList.astProcessInfo[0].strProcessName];
                    //        if (vmProcedure == null) return;
                    //        List<VmDynamicIODefine.IoNameInfo> ioNameInfos = vmProcedure.ModuResult.GetAllOutputNameInfo();
                    //        foreach (var item in ioNameInfos)
                    //        {
                    //            if (item.Name == "out" && item.TypeName != IMVS_MODULE_BASE_DATA_TYPE.IMVS_GRAP_TYPE_STRING)
                    //            {
                    //                Task.Run(() =>
                    //                {
                    //                    //UpdateResult("结果类型不一致！");

                    //                });
                    //                return;
                    //            }
                    //        }
                    //        var vmResult = vmProcedure.ModuResult.GetOutputString("out").astStringVal[0].strValue;
                    //        //开线程处理结果数据
                    //        Task.Run(() =>
                    //        {
                    //            //UpdateResult(vmResult);
                    //            ShowMessageInfo("执行成功，流程耗时:" + vmProcedure.ProcessTime.ToString() + "ms");
                    //        });
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                catch (VmException ex)
                {
                    ShowMessageInfo("回调出错:" + Convert.ToString(ex.errorCode, 16));
                    return;
                }
                catch (Exception ex)
                {
                    ShowMessageInfo("回调出错:" + ex.ToString());
                    return;
                }
            }
        }

        private void VmSolution_OnProcessStatusStartEvent(ImvsSdkDefine.IMVS_STATUS_PROCESS_START_CONTINUOUSLY_INFO statusInfo)
        {
            this.Invoke(new Action(() =>
            {
                if (statusInfo.nStatus == 0)
                {
                    string strMessage = null;
                    //buttonContiRun.Text = "停止运行";

                    //禁用按钮
                    //buttonSelectSolu.Enabled = false;
                    //buttonRunOnce.Enabled = false;
                    //buttonLoadSolu.Enabled = false;
                    //buttonSaveSolu.Enabled = false;
                    //comboProcedure.Enabled = false;

                    strMessage = "开始连续运行！";
                    ShowMessageInfo(strMessage);
                }
            }));
        }

        /// <summary>
        /// 结束连续执行状态回调
        /// </summary>
        /// <param name="statusInfo">结束执行状态</param>
        private void VmSolution_OnProcessStatusStopEvent(ImvsSdkDefine.IMVS_STATUS_PROCESS_STOP_INFO statusInfo)
        {
            this.Invoke(new Action(() =>
            {
                if (statusInfo.nStopAction == 1)
                {
                    string strMessage = null;
                    //buttonContiRun.Text = "连续运行";

                    ////启用按钮
                    //buttonSelectSolu.Enabled = true;
                    //buttonRunOnce.Enabled = true;
                    //buttonLoadSolu.Enabled = true;
                    //buttonSaveSolu.Enabled = true;
                    //comboProcedure.Enabled = true;

                    strMessage = "运行结束！";
                    ShowMessageInfo(strMessage);
                }
            }));
        }

        private void Init() {
            InitRightControl(VisionManager.Instance.RightControl);
            if (!VisionManager.Instance.IsLoaded) return;
            InitMainControl(MainControlType.Image);
        }
        /// <summary>
        /// 加载主控件
        /// </summary>
        /// <param name="IsImage">IsImage为true时,主界面显示各工位图像,否则显示主控区</param>
        private void InitMainControl(MainControlType type)
        {
            MainPannel.Controls.Clear();
            switch (type)
            {
                case MainControlType.Image:
                    windowShow.Dock = DockStyle.Fill;
                    MainPannel.Controls.Add(windowShow);
                    windowShow.ShowUnit();
                    buttonRender.BackColor = Color.Orange;
                    buttonConfig.BackColor = Color.Gray;
                    break;
                case MainControlType.MainConfig:
                    mainViewControl.Dock=DockStyle.Fill;
                    MainPannel.Controls.Add(mainViewControl);
                    buttonRender.BackColor = Color.Gray;
                    buttonConfig.BackColor = Color.Orange;
                    break;
                default:
                    windowShow.Dock = DockStyle.Fill;
                    MainPannel.Controls.Add(windowShow);
                    windowShow.ShowUnit();
                    buttonRender.BackColor = Color.Orange;
                    buttonConfig.BackColor = Color.Gray;
                    break;
            }

        }
        
        /// <summary>
        /// 添加右侧控件
        /// </summary>
        /// <param name="control"></param>
        private void InitRightControl(UserControl control)
        {
            RightPannel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            RightPannel.Controls.Add(control);
        }

        #region 文件
        private void 新建方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionManager.Instance.IsSolLoaded = false;
            VmSolution.Instance.ContinuousRunEnable = false;

            if (!GuideHelper.OpenSolution(false, out var filename, true)) return;
            VmSolution.CreatSolInstance();
            VmSolution.SaveAs(filename);
            VmSolution.Load(filename);
            VisionManager.Instance.IsSolLoaded = true;
            VisionManager.Instance.InitNewProject(true);
            InitMainControl(MainControlType.MainConfig);
        }
        
        private void 打开方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionManager.Instance.IsSolLoaded = false;
            VmSolution.Instance.ContinuousRunEnable = false;
            if (!GuideHelper.OpenSolution(false, out var filename)) return;
            VmSolution.Load(filename);
            VisionManager.Instance.IsSolLoaded = true;
            VisionManager.Instance.InitNewProject();
            InitMainControl(MainControlType.MainConfig);
        }

        private void 打开示例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionManager.Instance.IsSolLoaded = false;
            VmSolution.Instance.ContinuousRunEnable = false;
            if (!GuideHelper.OpenSolution(true, out var filename)) return;
            VmSolution.Load(filename);
            VisionManager.Instance.IsSolLoaded = true;
            VisionManager.Instance.InitNewProject();
            InitMainControl(MainControlType.MainConfig);
           
        }
        private void 保存方案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionManager.Instance.SaveSolProject();
        }

        private void 方案另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisionManager.Instance.SaveSolProject(true);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        

        private void MainFrm_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 图像显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRender_Click(object sender, EventArgs e)
        {
            if (!VisionManager.Instance.IsSolLoaded) { ShowMessageInfo("未加载方案,请加载方案后再试"); return; }
            InitMainControl(MainControlType.Image);
            ShowMessageInfo("切换图像显示完成");
            buttonRender.BackColor = Color.Orange;
            buttonConfig.BackColor = Color.Gray;
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            if (!VisionManager.Instance.IsSolLoaded) { ShowMessageInfo("未加载方案,请加载方案后再试"); return; }
            InitMainControl(MainControlType.MainConfig);
            ShowMessageInfo("切换参数配置完成");
            buttonRender.BackColor = Color.Gray;
            buttonConfig.BackColor = Color.Orange;
        }

        private void RunOnce_Click(object sender, EventArgs e)
        {
            if (!VisionManager.Instance.IsSolLoaded) { ShowMessageInfo("未加载方案,请加载方案后再试"); return; }
            VmSolution.Instance.SyncRun();
            ShowMessageInfo("运行一次成功");
        }

        private void RunContinus_Click(object sender, EventArgs e)
        {
            if (!VisionManager.Instance.IsSolLoaded) { ShowMessageInfo("未加载方案,请加载方案后再试"); return; }
            if (!VmSolution.Instance.ContinuousRunEnable)
            {
                VmSolution.Instance.ContinuousRunEnable = true;
                ShowMessageInfo("开始连续运行");
            }
            else {
                VmSolution.Instance.ContinuousRunEnable = false;
                ShowMessageInfo("连续运行结束");
            }
               
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuideHelper.GetHelp(local: true);
        }

        


        #region 设置

        #endregion

        private void ProduceCombox_DropDown(object sender, EventArgs e)
        {
            string strMsg = null;
            try
            {
                if (VisionManager.Instance.IsSolLoaded)
                {
                    ProduceCombox.Items.Clear();
                   var vmProcessInfoList = VmSolution.Instance.GetAllProcedureList();//获取所有流程列
                    for (int item = 0; item < vmProcessInfoList.nNum; item++)
                    {
                        ProduceCombox.Items.Add(vmProcessInfoList.astProcessInfo[item].strProcessName);
                    }
                    if (!string.IsNullOrEmpty(ProduceCombox.Text)&& !ProduceCombox.Items.Contains(ProduceCombox.Text))
                    {
                        ProduceCombox.SelectedIndex = -1;
                    }
                }
                else
                {
                    strMsg = "请先加载方案！";
                    ShowMessageInfo(strMsg);
                }
            }
            catch (VmException ex)
            {
                strMsg = "获取流程列表失败. Error Code: " + Convert.ToString(ex.errorCode, 16);
                ShowMessageInfo(strMsg);
                return;
            }
            catch (Exception ex)
            {
                strMsg = "获取流程列表失败. Error Code: " + ex.ToString();
                ShowMessageInfo(strMsg);
                return;
            }
        }

        private void ModuleCombox_DropDown(object sender, EventArgs e)
        {
            string strMsg = null;
            try
            {
                if (VisionManager.Instance.IsSolLoaded)
                {
                    ModuleCombox.Items.Clear();
                    if (string.IsNullOrEmpty(ProduceCombox.Text)) {
                        strMsg = "流程列表为空或未选择流程";
                        ShowMessageInfo(strMsg);
                        return; }
                    VmProcedure vmProcedure = (VmProcedure)VmSolution.Instance[ProduceCombox.Text];
                    if (vmProcedure == null) { ShowMessageInfo("流程选择错误,请重新选择"); return; }
                    ModuleInfoList stModuList = vmProcedure.GetAllModuleList(); // 获取所有模块列表
                    for (int item = 0; item < stModuList.nNum; item++)
                    {
                        ModuleCombox.Items.Add(stModuList.astModuleInfo[item].strDisplayName);
                    }
                    if (!string.IsNullOrEmpty(ModuleCombox.Text) && !ModuleCombox.Items.Contains(ModuleCombox.Text))
                    {
                        ModuleCombox.SelectedIndex = -1;
                    }
                }
                else
                {
                    strMsg = "请先加载方案！";
                    ShowMessageInfo(strMsg);
                }
            }
            catch (VmException ex)
            {
                strMsg = "获取模块列表失败. Error Code: " + Convert.ToString(ex.errorCode, 16);
                ShowMessageInfo(strMsg);
                return;
            }
            catch (Exception ex)
            {
                strMsg = "获取模块列表失败. Error Code: " + ex.ToString();
                ShowMessageInfo(strMsg);
                return;
            }
        }

        private void ParamSettingBtn_Click(object sender, EventArgs e)
        {
            //var a=ConfigurationHelper.INIGetStringValue("OpenSol");
            //if (!string.IsNullOrEmpty(a)) {
            //    ConfigurationHelper.INISetStringValue("OpenSol","123");
            //    a = ConfigurationHelper.INIGetStringValue("OpenSol");
            //}
            if (string.IsNullOrEmpty(ProduceCombox.Text) || string.IsNullOrEmpty(ModuleCombox.Text)) {
                ShowMessageInfo("未选择流程或模块");
                return;
            }
            if (ProduceCombox.Items.Count != VisionManager.Instance.ProjectData.ProcessInfoList.nNum
                || ModuleCombox.Items.Count != VisionManager.Instance.ProjectData.ModuleInfoList.nNum
                ||!ProduceCombox.Items.Contains(ProduceCombox.Text)||
                !ModuleCombox.Items.Contains(ModuleCombox.Text)) {
                ProduceCombox_DropDown(sender,e);
                ModuleCombox_DropDown(sender,e);
            }
            VmModule vmModule = (VmModule)VmSolution.Instance[ProduceCombox.Text + "." + ModuleCombox.Text];
            if (vmModule == null) { ShowMessageInfo("参数配置时获取模块错误,请重新选择流程或模块"); return; }
            VmParamsWithRenderForm vmParamsWithRenderForm = new VmParamsWithRenderForm();
            vmParamsWithRenderForm.MaximizeBox = false;
            vmParamsWithRenderForm.Dock = DockStyle.Fill;
            vmParamsWithRenderForm.ModuleSource = vmModule;
            vmParamsWithRenderForm.ShowDialog();
        }

        private void ShowMessageInfo(string message, bool show = true)
        {
            VisionManager.Instance.RightControl?.LogFunction(message, show);
        }
    }
}
