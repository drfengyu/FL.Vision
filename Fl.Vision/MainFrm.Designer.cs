namespace Fl.Vision
{
    partial class MainFrm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开示例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存方案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.方案另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vmGlobalToolControl1 = new VMControls.Winform.Release.VmGlobalToolControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.项目配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 493);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(948, 114);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.工具ToolStripMenuItem,
            this.系统ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建方案ToolStripMenuItem,
            this.打开方案ToolStripMenuItem,
            this.打开示例ToolStripMenuItem,
            this.保存方案ToolStripMenuItem,
            this.方案另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建方案ToolStripMenuItem
            // 
            this.新建方案ToolStripMenuItem.Name = "新建方案ToolStripMenuItem";
            this.新建方案ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.新建方案ToolStripMenuItem.Text = "新建方案";
            this.新建方案ToolStripMenuItem.Click += new System.EventHandler(this.新建方案ToolStripMenuItem_Click);
            // 
            // 打开方案ToolStripMenuItem
            // 
            this.打开方案ToolStripMenuItem.Name = "打开方案ToolStripMenuItem";
            this.打开方案ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.打开方案ToolStripMenuItem.Text = "打开方案";
            this.打开方案ToolStripMenuItem.Click += new System.EventHandler(this.打开方案ToolStripMenuItem_Click);
            // 
            // 打开示例ToolStripMenuItem
            // 
            this.打开示例ToolStripMenuItem.Name = "打开示例ToolStripMenuItem";
            this.打开示例ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.打开示例ToolStripMenuItem.Text = "打开示例";
            this.打开示例ToolStripMenuItem.Click += new System.EventHandler(this.打开示例ToolStripMenuItem_Click);
            // 
            // 保存方案ToolStripMenuItem
            // 
            this.保存方案ToolStripMenuItem.Name = "保存方案ToolStripMenuItem";
            this.保存方案ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.保存方案ToolStripMenuItem.Text = "保存方案";
            this.保存方案ToolStripMenuItem.Click += new System.EventHandler(this.保存方案ToolStripMenuItem_Click);
            // 
            // 方案另存为ToolStripMenuItem
            // 
            this.方案另存为ToolStripMenuItem.Name = "方案另存为ToolStripMenuItem";
            this.方案另存为ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.方案另存为ToolStripMenuItem.Text = "方案另存为";
            this.方案另存为ToolStripMenuItem.Click += new System.EventHandler(this.方案另存为ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目配置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 36);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 74);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vmGlobalToolControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 74);
            this.panel2.TabIndex = 0;
            // 
            // vmGlobalToolControl1
            // 
            this.vmGlobalToolControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vmGlobalToolControl1.Location = new System.Drawing.Point(0, 0);
            this.vmGlobalToolControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.vmGlobalToolControl1.Name = "vmGlobalToolControl1";
            this.vmGlobalToolControl1.Size = new System.Drawing.Size(942, 74);
            this.vmGlobalToolControl1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(948, 367);
            this.panel3.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 471);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(954, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 项目配置ToolStripMenuItem
            // 
            this.项目配置ToolStripMenuItem.Name = "项目配置ToolStripMenuItem";
            this.项目配置ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.项目配置ToolStripMenuItem.Text = "项目配置";
            this.项目配置ToolStripMenuItem.Click += new System.EventHandler(this.项目配置ToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 493);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainFrm";
            this.Text = "XX视觉检测项目";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开示例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存方案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 方案另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private VMControls.Winform.Release.VmGlobalToolControl vmGlobalToolControl1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem 项目配置ToolStripMenuItem;
    }
}

