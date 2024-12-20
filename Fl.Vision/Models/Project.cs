using System;
using System.Collections.Generic;
using VM.Core;

namespace FL.Vision.Models
{
    [Serializable]
    public class Project
    {
        public Project()
        {
            SolutionPath = VmSolution.Instance.SolutionPath;
            SolutionVersion=VmSolution.Instance.GetSolutionVersion(SolutionPath, "");
            HasPassword= VmSolution.Instance.HasPassword(SolutionPath);
            InitProjectInfo();
            ProcessCount = (int)ProcessInfoList.nNum;
        }
        /// <summary>
        /// 方案路径
        /// </summary>
        public string SolutionPath {  get; }
        /// <summary>
        /// 方案版本
        /// </summary>
        public string SolutionVersion {  get; }
        /// <summary>
        /// 有无密码
        /// </summary>

        public bool HasPassword { get;}
        /// <summary>
        /// 流程数量
        /// </summary>
        public int ProcessCount { get; }
        /// <summary>
        /// 所有流程列表
        /// </summary>

        public ProcessInfoList ProcessInfoList { set; get; }
        /// <summary>
        /// 所有模块列表
        /// </summary>

        public ModuleInfoList ModuleInfoList { set; get; }
        /// <summary>
        /// 流程集合
        /// </summary>

        public List<Process> Processes { set; get; }

        public void InitProjectInfo() {
            ProcessInfoList = VmSolution.Instance.GetAllProcedureList();

            ModuleInfoList = VmSolution.Instance.GetAllModuleList();
            Processes = new List<Process>();
            Processes.Clear();
            foreach (var item in ProcessInfoList.astProcessInfo)
            {
                if (string.IsNullOrEmpty(item.strProcessName)) break;
                Processes.Add(new Process()
                {
                    Name = item.strProcessName,
                    VmProcedure = (VmProcedure)VmSolution.Instance[item.strProcessName],
                    RenderControl = new Tools.RenderControl((VmProcedure)VmSolution.Instance[item.strProcessName])
                });
            }
        }
    }
}