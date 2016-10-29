namespace Scrabler.IDE
{
    partial class ScriptEditor
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabScriptInfo = new System.Windows.Forms.TabPage();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.lblScriptName = new System.Windows.Forms.Label();
            this.tabDevelopmentInfo = new System.Windows.Forms.TabPage();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstRefs = new System.Windows.Forms.ListBox();
            this.lblRefs = new System.Windows.Forms.Label();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.lblFunction = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.lblClass = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.tabCampability = new System.Windows.Forms.TabPage();
            this.txtMaxAppver = new System.Windows.Forms.TextBox();
            this.lblMaxAppVer = new System.Windows.Forms.Label();
            this.txtLowerappVer = new System.Windows.Forms.TextBox();
            this.lblLowerAppVer = new System.Windows.Forms.Label();
            this.txtScrablerVersion = new System.Windows.Forms.TextBox();
            this.lblScrablerVersion = new System.Windows.Forms.Label();
            this.openFileDialogdll = new System.Windows.Forms.OpenFileDialog();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblScriptVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabScriptInfo.SuspendLayout();
            this.tabDevelopmentInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabCampability.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scriptOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // scriptOptionsToolStripMenuItem
            // 
            this.scriptOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referencesToolStripMenuItem});
            this.scriptOptionsToolStripMenuItem.Name = "scriptOptionsToolStripMenuItem";
            this.scriptOptionsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.scriptOptionsToolStripMenuItem.Text = "Script Options";
            // 
            // referencesToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.Name = "referencesToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.referencesToolStripMenuItem.Text = "References";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "All files(*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "All files(*.*)|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textEditorControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(699, 391);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabScriptInfo);
            this.tabControl1.Controls.Add(this.tabDevelopmentInfo);
            this.tabControl1.Controls.Add(this.tabCampability);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(699, 199);
            this.tabControl1.TabIndex = 0;
            // 
            // tabScriptInfo
            // 
            this.tabScriptInfo.Controls.Add(this.txtVersion);
            this.tabScriptInfo.Controls.Add(this.lblScriptVersion);
            this.tabScriptInfo.Controls.Add(this.txtAuthor);
            this.tabScriptInfo.Controls.Add(this.lblAuthor);
            this.tabScriptInfo.Controls.Add(this.txtCopyright);
            this.tabScriptInfo.Controls.Add(this.lblCopyright);
            this.tabScriptInfo.Controls.Add(this.txtDescription);
            this.tabScriptInfo.Controls.Add(this.lblDescription);
            this.tabScriptInfo.Controls.Add(this.txtScriptName);
            this.tabScriptInfo.Controls.Add(this.lblScriptName);
            this.tabScriptInfo.Location = new System.Drawing.Point(4, 22);
            this.tabScriptInfo.Name = "tabScriptInfo";
            this.tabScriptInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabScriptInfo.Size = new System.Drawing.Size(691, 181);
            this.tabScriptInfo.TabIndex = 0;
            this.tabScriptInfo.Text = "Script Info";
            this.tabScriptInfo.UseVisualStyleBackColor = true;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(74, 96);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 7;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(6, 96);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 6;
            this.lblAuthor.Text = "Author";
            // 
            // txtCopyright
            // 
            this.txtCopyright.Location = new System.Drawing.Point(74, 65);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(100, 20);
            this.txtCopyright.TabIndex = 5;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(6, 68);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 39);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 42);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description";
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(74, 10);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(100, 20);
            this.txtScriptName.TabIndex = 1;
            // 
            // lblScriptName
            // 
            this.lblScriptName.AutoSize = true;
            this.lblScriptName.Location = new System.Drawing.Point(3, 13);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(65, 13);
            this.lblScriptName.TabIndex = 0;
            this.lblScriptName.Text = "Script Name";
            // 
            // tabDevelopmentInfo
            // 
            this.tabDevelopmentInfo.AutoScroll = true;
            this.tabDevelopmentInfo.Controls.Add(this.txtLanguage);
            this.tabDevelopmentInfo.Controls.Add(this.lblLanguage);
            this.tabDevelopmentInfo.Controls.Add(this.panel1);
            this.tabDevelopmentInfo.Controls.Add(this.txtFunction);
            this.tabDevelopmentInfo.Controls.Add(this.lblFunction);
            this.tabDevelopmentInfo.Controls.Add(this.txtClass);
            this.tabDevelopmentInfo.Controls.Add(this.lblClass);
            this.tabDevelopmentInfo.Controls.Add(this.txtNamespace);
            this.tabDevelopmentInfo.Controls.Add(this.lblNamespace);
            this.tabDevelopmentInfo.Location = new System.Drawing.Point(4, 22);
            this.tabDevelopmentInfo.Name = "tabDevelopmentInfo";
            this.tabDevelopmentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevelopmentInfo.Size = new System.Drawing.Size(691, 173);
            this.tabDevelopmentInfo.TabIndex = 1;
            this.tabDevelopmentInfo.Text = "Development";
            this.tabDevelopmentInfo.UseVisualStyleBackColor = true;
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(130, 111);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(100, 20);
            this.txtLanguage.TabIndex = 9;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(5, 111);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(119, 13);
            this.lblLanguage.TabIndex = 8;
            this.lblLanguage.Text = "Programming Language";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.lstRefs);
            this.panel1.Controls.Add(this.lblRefs);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(395, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 167);
            this.panel1.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(183, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(183, 108);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstRefs
            // 
            this.lstRefs.FormattingEnabled = true;
            this.lstRefs.Location = new System.Drawing.Point(8, 32);
            this.lstRefs.Name = "lstRefs";
            this.lstRefs.Size = new System.Drawing.Size(169, 147);
            this.lstRefs.TabIndex = 7;
            // 
            // lblRefs
            // 
            this.lblRefs.AutoSize = true;
            this.lblRefs.Location = new System.Drawing.Point(3, 9);
            this.lblRefs.Name = "lblRefs";
            this.lblRefs.Size = new System.Drawing.Size(62, 13);
            this.lblRefs.TabIndex = 6;
            this.lblRefs.Text = "References";
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(73, 73);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.Size = new System.Drawing.Size(100, 20);
            this.txtFunction.TabIndex = 5;
            // 
            // lblFunction
            // 
            this.lblFunction.AutoSize = true;
            this.lblFunction.Location = new System.Drawing.Point(-4, 76);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(71, 13);
            this.lblFunction.TabIndex = 4;
            this.lblFunction.Text = "Main function";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(73, 40);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(100, 20);
            this.txtClass.TabIndex = 3;
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Location = new System.Drawing.Point(13, 40);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(32, 13);
            this.lblClass.TabIndex = 2;
            this.lblClass.Text = "Class";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Location = new System.Drawing.Point(73, 12);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(100, 20);
            this.txtNamespace.TabIndex = 1;
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(3, 15);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(64, 13);
            this.lblNamespace.TabIndex = 0;
            this.lblNamespace.Text = "Namesapce";
            // 
            // tabCampability
            // 
            this.tabCampability.Controls.Add(this.txtMaxAppver);
            this.tabCampability.Controls.Add(this.lblMaxAppVer);
            this.tabCampability.Controls.Add(this.txtLowerappVer);
            this.tabCampability.Controls.Add(this.lblLowerAppVer);
            this.tabCampability.Controls.Add(this.txtScrablerVersion);
            this.tabCampability.Controls.Add(this.lblScrablerVersion);
            this.tabCampability.Location = new System.Drawing.Point(4, 22);
            this.tabCampability.Name = "tabCampability";
            this.tabCampability.Size = new System.Drawing.Size(691, 196);
            this.tabCampability.TabIndex = 2;
            this.tabCampability.Text = "Campability";
            this.tabCampability.UseVisualStyleBackColor = true;
            // 
            // txtMaxAppver
            // 
            this.txtMaxAppver.Location = new System.Drawing.Point(146, 79);
            this.txtMaxAppver.Name = "txtMaxAppver";
            this.txtMaxAppver.Size = new System.Drawing.Size(100, 20);
            this.txtMaxAppver.TabIndex = 5;
            // 
            // lblMaxAppVer
            // 
            this.lblMaxAppVer.AutoSize = true;
            this.lblMaxAppVer.Location = new System.Drawing.Point(8, 79);
            this.lblMaxAppVer.Name = "lblMaxAppVer";
            this.lblMaxAppVer.Size = new System.Drawing.Size(119, 13);
            this.lblMaxAppVer.TabIndex = 4;
            this.lblMaxAppVer.Text = "Max Application version";
            // 
            // txtLowerappVer
            // 
            this.txtLowerappVer.Location = new System.Drawing.Point(146, 46);
            this.txtLowerappVer.Name = "txtLowerappVer";
            this.txtLowerappVer.Size = new System.Drawing.Size(100, 20);
            this.txtLowerappVer.TabIndex = 3;
            // 
            // lblLowerAppVer
            // 
            this.lblLowerAppVer.AutoSize = true;
            this.lblLowerAppVer.Location = new System.Drawing.Point(8, 49);
            this.lblLowerAppVer.Name = "lblLowerAppVer";
            this.lblLowerAppVer.Size = new System.Drawing.Size(128, 13);
            this.lblLowerAppVer.TabIndex = 2;
            this.lblLowerAppVer.Text = "Lower Application version";
            // 
            // txtScrablerVersion
            // 
            this.txtScrablerVersion.Location = new System.Drawing.Point(146, 11);
            this.txtScrablerVersion.Name = "txtScrablerVersion";
            this.txtScrablerVersion.Size = new System.Drawing.Size(100, 20);
            this.txtScrablerVersion.TabIndex = 1;
            // 
            // lblScrablerVersion
            // 
            this.lblScrablerVersion.AutoSize = true;
            this.lblScrablerVersion.Location = new System.Drawing.Point(8, 11);
            this.lblScrablerVersion.Name = "lblScrablerVersion";
            this.lblScrablerVersion.Size = new System.Drawing.Size(84, 13);
            this.lblScrablerVersion.TabIndex = 0;
            this.lblScrablerVersion.Text = "Scrabler Version";
            // 
            // openFileDialogdll
            // 
            this.openFileDialogdll.Filter = "component Files(*.tlb;*.olb;*.ocx;*.exe;.manifest)|*.tlb;*.olb;*.ocx;*.exe;*.mani" +
                "fest";
            this.openFileDialogdll.Multiselect = true;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.AutoScroll = true;
            this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(699, 188);
            this.textEditorControl1.TabIndex = 0;
            // 
            // lblScriptVersion
            // 
            this.lblScriptVersion.AutoSize = true;
            this.lblScriptVersion.Location = new System.Drawing.Point(195, 13);
            this.lblScriptVersion.Name = "lblScriptVersion";
            this.lblScriptVersion.Size = new System.Drawing.Size(42, 13);
            this.lblScriptVersion.TabIndex = 8;
            this.lblScriptVersion.Text = "Version";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(278, 6);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(100, 20);
            this.txtVersion.TabIndex = 9;
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 415);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ScriptEditor";
            this.Text = "ScriptEditor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabScriptInfo.ResumeLayout(false);
            this.tabScriptInfo.PerformLayout();
            this.tabDevelopmentInfo.ResumeLayout(false);
            this.tabDevelopmentInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabCampability.ResumeLayout(false);
            this.tabCampability.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabScriptInfo;
        private System.Windows.Forms.TabPage tabDevelopmentInfo;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label lblClass;
        private System.Windows.Forms.Label lblRefs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstRefs;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialogdll;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCampability;
        private System.Windows.Forms.TextBox txtScrablerVersion;
        private System.Windows.Forms.Label lblScrablerVersion;
        private System.Windows.Forms.TextBox txtLowerappVer;
        private System.Windows.Forms.Label lblLowerAppVer;
        private System.Windows.Forms.Label lblMaxAppVer;
        private System.Windows.Forms.TextBox txtMaxAppver;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblScriptVersion;
    }
}