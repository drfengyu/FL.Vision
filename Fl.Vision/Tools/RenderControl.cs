using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VM.Core;

namespace FL.Vision.Tools
{
    public partial class RenderControl : UserControl
    {
        private readonly VmProcedure _vmProcedure;
        public RenderControl(VmProcedure vmProcedure)
        {
            InitializeComponent();
            _vmProcedure = vmProcedure;
        }

        private void vmRenderControl1_Load(object sender, EventArgs e)
        {
            vmRenderControl1.ModuleSource = _vmProcedure;
        }
    }
}
