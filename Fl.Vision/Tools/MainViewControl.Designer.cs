namespace FL.Vision.Tools
{
    partial class MainViewControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.vmMainViewConfigControl1 = new VMControls.Winform.Release.VmMainViewConfigControl();
            this.vmGlobalToolControl1 = new VMControls.Winform.Release.VmGlobalToolControl();
            this.SuspendLayout();
            // 
            // vmMainViewConfigControl1
            // 
            this.vmMainViewConfigControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vmMainViewConfigControl1.Location = new System.Drawing.Point(0, 89);
            this.vmMainViewConfigControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.vmMainViewConfigControl1.Name = "vmMainViewConfigControl1";
            this.vmMainViewConfigControl1.Size = new System.Drawing.Size(1083, 505);
            this.vmMainViewConfigControl1.TabIndex = 0;
// TODO: “”的代码生成失败，原因是出现异常“无效的基元类型: System.IntPtr。请考虑使用 CodeObjectCreateExpression。”。
            // 
            // vmGlobalToolControl1
            // 
            this.vmGlobalToolControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.vmGlobalToolControl1.Location = new System.Drawing.Point(0, 0);
            this.vmGlobalToolControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmGlobalToolControl1.Name = "vmGlobalToolControl1";
            this.vmGlobalToolControl1.Size = new System.Drawing.Size(1086, 83);
            this.vmGlobalToolControl1.TabIndex = 1;
            // 
            // MainViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vmGlobalToolControl1);
            this.Controls.Add(this.vmMainViewConfigControl1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainViewControl";
            this.Size = new System.Drawing.Size(1086, 596);
            this.ResumeLayout(false);

        }

        #endregion

        private VMControls.Winform.Release.VmMainViewConfigControl vmMainViewConfigControl1;
        private VMControls.Winform.Release.VmGlobalToolControl vmGlobalToolControl1;
    }
}
