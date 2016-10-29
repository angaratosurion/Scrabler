using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scrabler;


namespace ScrablerScriptsRunner
{
    public partial class Form1 : LoadedScripts
    {
        ScrablerService.ScrablerServiceClient client = new ScrablerScriptsRunner.ScrablerService.ScrablerServiceClient();
        public Form1()
        {
           
           // Scrabler.LoadedScripts;
            InitializeComponent();

           if (client.State != System.ServiceModel.CommunicationState.Opened)
            {
                client.Open();
                client.createScriptsDirectory(Environment.UserName);
                client.Autoexecutescripts(Environment.UserName ,2);
            }
     else
            {
                client.createScriptsDirectory(Environment.UserName);
                client.Autoexecutescripts(Environment.UserName,2);
                
            }
            
           
       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.Text = Application.ProductName;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Text = Application.ProductName;
            notifyIcon1.Visible = true;
            this.Text = client.GetServiceVersion();
            ScriptInfo [] scr =(ScriptInfo [])client.GetLoadedScripts();
            if (scr != null)
            {
                  foreach(ScriptInfo s in scr )
                  {
                      object[] vals = new object[this.dataScriptsInfo.ColumnCount];
                      int i;
                     
                      vals[0] = s.Title;
                      vals[1] = s.Description;
                      vals[2] = s.Language;
                      vals[3] = s.Version;
                      vals[4] = s.Author;                      
                      vals[5] = s.Copyright;                      
                      vals[6] = s.Filename;
                   
                      
                  
                   
                    this.dataScriptsInfo.Rows.Add(vals);

                }

            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (client.State != System.ServiceModel.CommunicationState.Opened)
            {
                client.Open();
                client.createScriptsDirectory(Environment.UserName);
                client.Autoexecutescripts(Environment.UserName,2);
            }

        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (client.State == System.ServiceModel.CommunicationState.Opened)
            {
                client.Close();
                
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
