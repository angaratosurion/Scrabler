namespace Scrabler.Controls
{
    partial class TabConsoleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Console1 = new System.Windows.Forms.TabPage();
            this.consoleBox1 = new Scrabler.Controls.ConsoleBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripNewTab = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripCloseTab = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Console1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Console1
            // 
            this.Console1.Controls.Add(this.consoleBox1);
            this.Console1.Location = new System.Drawing.Point(4, 22);
            this.Console1.Name = "Console1";
            this.Console1.Padding = new System.Windows.Forms.Padding(3);
            this.Console1.Size = new System.Drawing.Size(858, 422);
            this.Console1.TabIndex = 0;
            this.Console1.Text = "Console 1";
            this.Console1.UseVisualStyleBackColor = true;
            // 
            // consoleBox1
            // 
            this.consoleBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleBox1.Location = new System.Drawing.Point(3, 3);
            this.consoleBox1.Name = "consoleBox1";
            this.consoleBox1.Size = new System.Drawing.Size(852, 416);
            this.consoleBox1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.tabControl1.Controls.Add(this.Console1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(866, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNewTab,
            this.toolStripCloseTab});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripNewTab
            // 
            this.toolStripNewTab.Name = "toolStripNewTab";
            this.toolStripNewTab.Size = new System.Drawing.Size(152, 22);
            this.toolStripNewTab.Text = "New Tab";
            this.toolStripNewTab.Click += new System.EventHandler(this.toolStripNewTab_Click);
            // 
            // toolStripCloseTab
            // 
            this.toolStripCloseTab.Name = "toolStripCloseTab";
            this.toolStripCloseTab.Size = new System.Drawing.Size(152, 22);
            this.toolStripCloseTab.Text = "Close Tab";
            this.toolStripCloseTab.Click += new System.EventHandler(this.toolStripCloseTab_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TabConsoleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "TabConsoleControl";
            this.Size = new System.Drawing.Size(866, 448);
            this.Console1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Console1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripNewTab;
        private System.Windows.Forms.ToolStripMenuItem toolStripCloseTab;
        private System.Windows.Forms.Timer timer1;
        private ConsoleBox consoleBox1;

    }
}
