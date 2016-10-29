using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.CSharp;
using System.Data;
using System.Security;
using System.Security.Permissions;


using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;
using WareForms;
using Hydrobase;
using HydrobaseSDK;
// 

using System.Configuration;
using ICSharpCode.TextEditor ;
using ICSharpCode.TextEditor.Document;
using Scrabler;

namespace Scrabler.IDE
{
    public partial class ScriptEditor : Form
    { 
        ScrablerCore core = new ScrablerCore();
        ScriptInfo info = new ScriptInfo();
        public ScriptEditor()
        {
            InitializeComponent();
        }
        public ScriptEditor(string filename)
        {
            InitializeComponent();
            this.LOadScript(filename);

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs ev)
        {
            try
            {
               
                int i;
             
            if((saveFileDialog1.ShowDialog() == DialogResult.OK ) 
                ||(saveFileDialog1.FileName !=null ))
             {
                 info = new ScriptInfo();
                 
                string refs="";//,namespc="   ",func=" ";
                 info.Title = txtScriptName.Text;
                 info.Copyright = txtCopyright.Text;
                 info.Description = txtDescription.Text;
              info.Language = txtLanguage.Text;
                 info.Author = txtAuthor.Text;
                 info.LowerApplicationVersion = txtLowerappVer.Text;
                 info.MaxApplicationVersion = txtMaxAppver.Text;
                 info.ScrablerVersion = txtScrablerVersion.Text;
                 info.Version = txtVersion.Text;
                
              //   string[] refsar = new string[lstRefs.Items.Count];
                 for (i = 0; i < lstRefs.Items.Count; i ++)
                 {
                     refs +=  lstRefs.Items[i].ToString()+"|";

                 }
                

                 //MessageBox.Show(txtClass.Text);
                core.SaveScript(saveFileDialog1.FileName,textEditorControl1.Text, refs, 
                    txtNamespace.Text, txtFunction.Text,txtClass.Text, info);
             }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs ev)
        {
            this.Close();
        }

        private void btnRemove_Click(object sender, EventArgs ev)
        {
            try
            {
               int i;

                   if(lstRefs.SelectedItems!=null)
                   {
                       for(i=0; i<lstRefs.SelectedItems.Count;i++)
                       {
                           lstRefs.Items.Remove(lstRefs.SelectedItems[i]);

                       }
                       
                   }
                }

            
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs ev)
        {
            try
            {
                
                if ((openFileDialogdll.ShowDialog()!= DialogResult.OK )
                    ||(openFileDialogdll.FileNames!=null))
                {
                    lstRefs.Items.AddRange(openFileDialog1.FileNames);
                    
                  
                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }
        }
        void LOadScript(string file)
        {
            try
            {

                if (file != null)
                {
                    info = new ScriptInfo();
                    lstRefs.Items.Clear();
                    core.ReadScript(file, true);
                    info = core.GetScriptInfo(ScrablerCore.ScriptsSet);
                    txtScriptName.Text = info.Title;
                    txtAuthor.Text = info.Author;
                    txtClass.Text = core.GetClass(ScrablerCore.ScriptsSet);
                    txtCopyright.Text = info.Copyright;
                    txtDescription.Text = info.Description;
                    txtLanguage.Text = core.GetLanguage(ScrablerCore.ScriptsSet);
                    txtLowerappVer.Text = info.LowerApplicationVersion;
                    txtMaxAppver.Text = info.MaxApplicationVersion;
                    txtScrablerVersion.Text = info.ScrablerVersion;
                    txtNamespace.Text = core.GetNameSace(ScrablerCore.ScriptsSet);
                    txtFunction.Text = core.GetFunction(ScrablerCore.ScriptsSet);                 
                    this.textEditorControl1.Text = core.GetCode(ScrablerCore.ScriptsSet);
                    txtVersion.Text = info.Version;
                   
                   // MessageBox.Show(core.GetCode(ScrablerCore.ScriptsSet));
                    string[] refs = core.GetReferences(ScrablerCore.ScriptsSet);
                    lstRefs.Items.AddRange(refs);
                    if (txtLanguage.Text != null)
                    {
                        textEditorControl1.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter(txtLanguage.Text);
                    }
                    else
                    {
                        textEditorControl1.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("C#");
                    }
                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs ev)
        {
            try
            {

                if ((openFileDialog1.ShowDialog() != DialogResult.OK)
                    || (openFileDialog1.FileNames != null))
                {
                    this.LOadScript(openFileDialog1.FileName);
                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                //return null;
            }
        }
    }
}
