using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Management.Automation.Host;
using System.Management.Automation.Provider;
using System.Globalization;

namespace Scrabler.Controls
{
    public partial class ConsoleBox : UserControl
    {

        

        public static RichTextBox PowerShellOutput;
   //   private static PowerShellWorkBenchHost host = new PowerShellWorkBenchHost();
        //PSHost host = new PSHost();
        string scedir;
        public string SecureDirs
        {

            get { return scedir; }
            set { scedir = value; }

        }


     
    private Runspace r = RunspaceFactory.CreateRunspace();
   ScriptRepo repo  ;
        public ConsoleBox()
        {
            InitializeComponent();
            repo= new ScriptRepo();
            PowerShellOutput = txtOutput ;
            r.ThreadOptions = PSThreadOptions.UseCurrentThread;
            r.Open();
          
           
        }

        private void TxtIn_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
              
                    if (e.KeyCode == Keys.Enter) 
                    {
                        //    PowerShellWorkBenchHost host = new PowerShellWorkBenchHost();
                        /*RunspaceConfiguration conf = RunspaceConfiguration.Create();
                    
                        Runspace r = RunspaceFactory.CreateRunspace();
                    
                        r.Open();*/

                        Pipeline p = r.CreatePipeline(txtIn.Text);
                        p.Commands.Add(new Command("out-string"));

                        

                        Collection<PSObject> output = null;
                        output = p.Invoke();
                        Collection<object> er = p.Error.ReadToEnd();
                        if(er!=null)
                        {
                           foreach( object et in er)
                           {

                               txtOutput.AppendText(et.ToString() + Environment.NewLine);

                           }

                        }
                        foreach (PSObject o in output)
                        {
                            txtOutput.AppendText(o.ToString() + Environment.NewLine);
                        }


                        this.txtIn.Text = "";


                    }
                  
                
              


            }
            catch (Exception)
            {


            }
        }

        private void ConsoleBox_Load(object sender, EventArgs e)
        {
            string tsecdir = "$env:path+=\";" + repo.Binaryfolder + "\""+ this.scedir;
            Pipeline p = r.CreatePipeline(tsecdir);
     
            p.Commands.Add(new Command("out-string"));
            Collection<PSObject> output = null;
          
            output = p.Invoke();
            foreach (PSObject o in output)
            {
                txtOutput.AppendText(o.ToString() +  Environment.NewLine);
            }
        }
    }
    
}


