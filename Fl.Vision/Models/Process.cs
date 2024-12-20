using VM.Core;
using VMControls.Interface;
using VM.PlatformSDKCS;
using FL.Vision.Tools;
using System;

namespace FL.Vision.Models
{
    [Serializable]
    public class Process
    {
        public Process()
        {

        }

        public string Name { set; get; }
        
        public VmProcedure VmProcedure { set; get; }
        
        public RenderControl RenderControl { set; get; }

        
    }
}