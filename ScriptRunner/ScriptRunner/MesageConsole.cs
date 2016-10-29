using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScriptRunner
{
    public partial class MesageConsole : Form
    {
        public MesageConsole()
        {
            InitializeComponent();
            
        }

        private void MesageConsole_Load(object sender, EventArgs e)
        {
            this.NotIcon.Icon = this.Icon;
            this.Hide();
            this.Text = Application.ProductName + "- Message Console -";
            Program.Console = this;
            this.WriteLine(this.Text + Environment.NewLine + "Version :" + Application.ProductVersion);
            this.WriteLine(Application.CompanyName+ "\n");
            
        }
        public void WriteLine(string line)
        {


            try
            {

                this.Commands.Text += Environment.NewLine + line;

            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }

        }

       

        private void MesageConsole_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Application.Exit();
                


            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }

        }

        private void CommandBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                if ((e.Control==true ) &&(e.KeyCode== Keys.Enter))
                {
                    
                    Core tcore = new Core();
                    this.WriteLine(CommandBox.Text);
                    tcore.ExecuteCommand(CommandBox.Text);
                    


                    this.CommandBox.Text = "";

                }


            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {

                    Core core = new Core();
                    core.ExecuteCommand(Core.exit);




                }
                catch (Exception ex)
                {
                    Program.errorreporting(ex);

                }


            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.Visible == false)
                {

                    this.Show();
                }
                else
                {
                    this.Hide();

                }


            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Core core = new Core();
                core.ExecuteCommand(Core.addAllias);

                


            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                Core core = new Core();
                core.ExecuteCommand(Core.showAllias);




            }
            catch (Exception ex)
            {
                Program.errorreporting(ex);

            }

        }

       
    }
}