using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;

namespace Scrabler
{
    public partial class ErrorWindow : Form
    {
        CompilerErrorCollection compilererrcol;
        string code;
        bool saveerr;
        public ErrorWindow()
        {
            InitializeComponent();
        }
        public ErrorWindow(CompilerErrorCollection cerrcol,string tcode)
        {
            InitializeComponent();
            compilererrcol = cerrcol;
            code = tcode;
            this.SaveErrorrs();
        }
        public ErrorWindow(CompilerErrorCollection cerrcol, string tcode, bool tsaveerrorrep)
        {
            InitializeComponent();
            compilererrcol = cerrcol;
            code = tcode;
            saveerr = tsaveerrorrep;
            this.SaveErrorrs();
          

        }
        public void SaveErrorrs()
        {

            try
            {
                if (compilererrcol != null)
                {

                    StreamWriter wr = new StreamWriter(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace(@"file:\", "") + "\\errrors.txt",true,Encoding.UTF8);
                    foreach (CompilerError err in compilererrcol)
                    {

                        wr.WriteLine();
                        wr.WriteLine(err.ToString());
                    }
                    wr.Flush();
                    wr.Close();

                }
               
            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {

                this.Close();

            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }
        }

        private void listErrors_Click(object sender, EventArgs e)
        {
            try
            {

                if ((listErrors.SelectedItem != null) &&(compilererrcol !=null))
                {
                    this.txtCode.Text = compilererrcol[listErrors.SelectedIndex].ToString();
                  //  code ="";
                   if ((compilererrcol[listErrors.SelectedIndex].FileName != null) || (File.Exists(compilererrcol[listErrors.SelectedIndex].FileName) == true))
                    {
                        //StreamReader rd = new StreamReader(compilererrcol[listErrors.SelectedIndex].FileName);
                        //code = rd.ReadToEnd();
                    this.txtCode.Text += Environment.NewLine + code;
                      
                    }
                    

                }

            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }
        }

        private void listErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listErrors_Click(sender, e);
        }

        private void ErrorWindow_Load(object sender, EventArgs e)
        {
            try
            {

                if (compilererrcol != null)
                {

                    foreach (CompilerError er in compilererrcol)
                    {

                        listErrors.Items.Add("ERROR in line " + er.Line + ": " + er.ErrorText);
                    }
                }
            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }
        }

        private void ErrorWindow_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                if (saveerr == true)
                {
                    DataSet set = new DataSet(Hydrobase.BaseClass.tabletag);
                    Hydrobase.hydrobaseADO ado = new Hydrobase.hydrobaseADO();
                    set.Tables.Add();
                    set.Tables[0].TableName = Hydrobase.BaseClass.recordtag;
                    set.Tables[0].Columns.Add("Error_Text");
                    set.Tables[0].Columns.Add("Error_Number");
                    set.Tables[0].Columns.Add("Filename");
                    set.Tables[0].Columns.Add("Line");
                    set.Tables[0].Columns.Add("Column");
                    set.Tables[0].Columns.Add("Code");
                    foreach (CompilerError er in compilererrcol)
                    {
                        object[] vals = new object[set.Tables[0].Columns.Count];
                        vals[0] = er.ErrorText;
                        vals[1] = er.ErrorNumber;
                        vals[2] = er.FileName;
                        vals[3] = er.Line;
                        vals[4] = er.Column;
                        vals[5] = code;
                        ado.SaveTable(set, Path.GetFileNameWithoutExtension(er.FileName) + ".errors", 0, " - ");



                    }
                }

            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                //return null;
            }
        }
    }
}