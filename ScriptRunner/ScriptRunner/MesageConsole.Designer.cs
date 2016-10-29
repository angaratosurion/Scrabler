namespace ScriptRunner
{
    partial class MesageConsole
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.Commands = new System.Windows.Forms.RichTextBox();
            this.NotIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.alliasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommandBox
            // 
            this.CommandBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommandBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.CommandBox.Location = new System.Drawing.Point(0, 174);
            this.CommandBox.Multiline = true;
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CommandBox.Size = new System.Drawing.Size(292, 99);
            this.CommandBox.TabIndex = 0;
            this.CommandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandBox_KeyDown);
            // 
            // Commands
            // 
            this.Commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Commands.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.Commands.Location = new System.Drawing.Point(0, 0);
            this.Commands.Name = "Commands";
            this.Commands.Size = new System.Drawing.Size(292, 273);
            this.Commands.TabIndex = 1;
            this.Commands.Text = "";
            // 
            // NotIcon
            // 
            this.NotIcon.ContextMenuStrip = this.menu;
            this.NotIcon.Visible = true;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Restore,
            this.alliasToolStripMenuItem,
            this.Exit});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(153, 92);
            // 
            // Restore
            // 
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(152, 22);
            this.Restore.Text = "Restore";
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(152, 22);
            this.Exit.Text = "Close";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // alliasToolStripMenuItem
            // 
            this.alliasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.showToolStripMenuItem});
            this.alliasToolStripMenuItem.Name = "alliasToolStripMenuItem";
            this.alliasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.alliasToolStripMenuItem.Text = "Allias";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // MesageConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.CommandBox);
            this.Controls.Add(this.Commands);
            this.Name = "MesageConsole";
            this.Text = "MesageConsole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MesageConsole_FormClosed);
            this.Load += new System.EventHandler(this.MesageConsole_Load);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox Commands;
        public System.Windows.Forms.TextBox CommandBox;
        public System.Windows.Forms.NotifyIcon NotIcon;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem Restore;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripMenuItem alliasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;

    }
}