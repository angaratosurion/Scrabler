using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Scrabler;

using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Scrabler.Controls;


namespace Scrabler.Controls
{
    public partial class TabConsoleControl : UserControl
    {
       // List< ProcessHost> process = new List< ProcessHost>();
       
       // List< TextBox> prompts = new List<TextBox>();

        ScrablerCore scrabl;
        ScriptRepo rep;
        PowerShell powshell;
        Keys[] keysToingore;
        string scedir;
        public string SecureDirs
        {

            get { return scedir; }
            set { scedir = value; }

        }
        public Keys[] IngoreKeys
        {


            get { return keysToingore; }
            set { keysToingore = value; }
        }
       

        public TabConsoleControl()
        {
            InitializeComponent();
          scrabl = new ScrablerCore();
            rep = new ScriptRepo(Path.GetDirectoryName(Application.ExecutablePath));
            tabControl1.TabPages.Clear();

           // this.consoleBox1.Dispose();
            this.toolStripNewTab_Click(null, null);
          
        }
        public TabControl TabControl
        {

            get { return tabControl1; }
        }
        /// <summary>
        /// Creates a new session of console
        /// </summary>
        public void createNewTabSession()
        {
            try 
            {


                tabControl1.TabPages.Add("Console" + tabControl1.TabPages.Count);


                Panel pnl = new Panel();


                pnl.Dock = DockStyle.Bottom;
                // Scrabler.Controls.ConsoleBox
                ConsoleBox cox = new ConsoleBox();
                cox.Dock = DockStyle.Fill;
                cox.SecureDirs = scedir;
                tabControl1.TabPages[tabControl1.TabPages.Count - 1].Controls.Add(cox);







            }
            catch (Exception)
            {


            }


        }
        
        private void toolStripNewTab_Click(object sender, EventArgs e)
        {
            //try 
            {


                this.createNewTabSession();


            }
           // catch (Exception)
            {


            }
        }
        /// <summary>
        /// Closes the active  session
        /// </summary>
        public void CloseSession()
        {




        }

        private void toolStripCloseTab_Click(object sender, EventArgs e)
        {
            try
            {
                this.CloseSession();

            }
            catch (Exception ex)
            {

                //Program.errorreporting(ex);
                //return null;
            }
        }

   
        private void timer1_Tick(object sender, EventArgs e)
        {
           // prompts[tabControl1.SelectedIndex].Text += "jjjj";//+ Environment.NewLine + process[tabControl1.SelectedIndex].StandardOut;
                       
         //   tabControl1_Selected(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
