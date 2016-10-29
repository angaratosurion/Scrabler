using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScriptRunner
{
    public partial class AddAllias : Form
    {
        public AddAllias()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Allias al = new Allias();
                al.AddAlliaces(txtAllias.Text, txtComnd.Text);
                this.Close();
                



            }
            catch (Exception ex)
            {


                Program.errorreporting(ex);
            }
        }
    }
}