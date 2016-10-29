using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Globalization;
//using System.Timers;
using Hydrobase;
using HydrobaseSDK;
// 

using WareForms;
using Scrabler.IDE;

using Scrabler;


namespace Scrabler
{
    public partial class LoadedScripts : Form
    {
        public LoadedScripts()
        {
            InitializeComponent();
            
        }

        List<ScriptInfo> scrinf = ScrablerCore.AssemblyCol.ScriptInfoCollection();

        private void LoadedScripts_Load(object sender, EventArgs e)
        {
            try
            {

                CultureInfo grcult = new CultureInfo("el");
                CultureInfo grcult2 = new CultureInfo("el-GR");
                if ((Application.CurrentCulture != grcult) &&
                    (Application.CurrentCulture != grcult2))
                {
                    this.Text = "Loaded Scripts";

                }
                else
                {
                    this.Text = "Φορτωμένα Scripts";


                }
                if (scrinf != null)
                {


                    //version, description, copyright, LowerappVer, MaxappVer, scrablerVersion;

                    dataScriptsInfo.Columns.Add("title", "Title");
                    dataScriptsInfo.Columns.Add("description", "Description");
                    dataScriptsInfo.Columns.Add("language", "Programming Language");
                    dataScriptsInfo.Columns.Add("version", "Version");
                    dataScriptsInfo.Columns.Add("author", "Athor");
                    dataScriptsInfo.Columns.Add("copyright", "Copyright");
                    dataScriptsInfo.Columns.Add("File Name", "File Name");
                    

                    foreach (ScriptInfo scr in scrinf)
                    {
                        object[] val = new object[7];
                        val[0] = scr.Title;
                        val[1] = scr.Description;
                        val[2] = scr.Language;
                        val[3] = scr.Version;
                        val[4] = scr.Author;
                        val[5] = scr.Copyright;
                        val[6] = scr.Filename;
                        dataScriptsInfo.Rows.Add(val);


                    }



                }

            }
            catch (Exception ex)
            {
                Program.Bugtracking(ex);

            }
        }

        private void editScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataScriptsInfo.SelectedRows != null)
                {
                    if (dataScriptsInfo.SelectedRows[0] != null)
                    {
                        int i;
                        i = dataScriptsInfo.Columns["File Name"].Index;
                        Scrabler.IDE.ScriptEditor editor = new Scrabler.IDE.ScriptEditor(dataScriptsInfo.SelectedRows[0].Cells[i].Value.ToString());
                        editor.Show();

                        
                        
                    }

                }

            }
            catch (Exception ex)
            {
                Program.Bugtracking(ex);

            }
        }
        
    }
}