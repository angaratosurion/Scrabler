using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Hydrobase;
using HydrobaseSDK;
using WareForms;

//using pigeon;
//using HydroMultyUser;
using Scrabler;
using System.Reflection;

namespace ScriptRunner
{
   public  class Allias
    {
       public const string optionsfolder = "Options";
       public static string[] AlliasTag ={"alias","Command" };
       public static string ApplicationsFolder;
       public const string alliasfile="allias.xml";
       public DataSet alliasset= new DataSet();
       public static DataTable alliastable = new DataTable();
       //string [] allias= new string[2];
       //public static string []  allias;
       hydrobaseADO ado = new hydrobaseADO();

       public static void FindOptionsFolder()
       {

           try
           {

               ApplicationsFolder = "C:\\Documents and Settings\\" + Environment.UserName + "\\Application Data\\" + Application.ProductName + "\\" + optionsfolder;


           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);

           }




       }
       public void LoadAlliaces()
       {

           try
           {
               if (ApplicationsFolder != null)
               {
                   
                   ado.AttachDataBaseinDataSet(alliasset, ApplicationsFolder + "\\" + alliasfile);
                   alliastable = alliasset.Tables[0];


               }

           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);

           }
       }
           public void CreateOptions()
       {

           try
           {
               FindOptionsFolder();
               if (ApplicationsFolder != null)
               {
                   if(Directory.Exists(ApplicationsFolder)!=true )
                   {

                       Directory.CreateDirectory(ApplicationsFolder);


                   }
                   ado.TableCreation(ApplicationsFolder+"\\"+alliasfile ,AlliasTag,Application.ProductName +" - "+ Application.ProductVersion );




               }

           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);

           }

       }
       public void AddAlliaces(string allias, string command)
       {
            try
           {
               if ((ApplicationsFolder != null) &&(allias !=null )&&(command !=null))
               {
                   this.LoadAlliaces();
                   object [] vals = new object[2];
                   vals[0]=allias;
                   vals[1]=command;
                   alliasset.Tables[0].Rows.Add(vals);
                   ado.SaveTable(alliasset, ApplicationsFolder + "\\" + alliasfile,0,Application.ProductName + " - "+ Application.ProductVersion );

               }

           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);

           }
       }
       public string  ReplaceAllias(string cmd)
       {
           try
           {
               int i=0;
               string ap=null;
               this.LoadAlliaces();
               if (cmd != null)
               {
                // MessageBox.Show(cmd);
                   for (i = 0; i < alliastable.Rows.Count; i++)
                   {
                       object[] vals = alliastable.Rows[i].ItemArray;
                       if ((cmd.Contains(Convert.ToString(vals[0])) == true))
                       {
                           ap = cmd.Replace(Convert.ToString(vals[0]), Convert.ToString(vals[1]));

                           //MessageBox.Show(ap);
                           return ap;

                       }
                       else
                       {


                           ap = cmd;
                       }


                   }

               }
               return ap;

               

           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);
               return null;
           }



       }
       public void ShowAllias()
       {
           try
           {
               int i = 0;

               this.LoadAlliaces();

               // MessageBox.Show(cmd);
               Program.Console.WriteLine("Existed Allias: \n \n Allias \t| Commands\n");
               for (i = 0; i < alliastable.Rows.Count; i++)
               {
                   object[] vals = alliastable.Rows[i].ItemArray;
                   Program.Console.WriteLine(Convert.ToString(vals[0]) + "\t| " + Convert.ToString(vals[1]));




               }



           }
           catch (Exception ex)
           {


               Program.errorreporting(ex);

           }


       }




       }
    }

