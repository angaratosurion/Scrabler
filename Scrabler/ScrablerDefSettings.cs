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
namespace Scrabler
{
    /// <summary>
    /// Scrabler default settings managment class
    /// </summary>
   public   class ScrablerDefSettings
   {
       bool userrepo,keepassembly;

       static string[] cells = {"use_repo","keep_assembly"};
       const string scrblerconf="scrabler_conf.xml";
       string filename = Path.Combine(Application.StartupPath, scrblerconf);
       DataSet set = new DataSet();
       hydrobaseADO ado = new hydrobaseADO();
       /// <summary>
       /// Read the default configuration of scrabler library
       /// </summary>
       public void Readconfig()
       {
           try
           {
               if (File.Exists(filename) == true)
               {
                   ado.AttachDataBaseinDataSet(set, filename);
                   object[] vals = new object[cells.Length];
                   userrepo = Convert.ToBoolean(vals[0]);
                   keepassembly = Convert.ToBoolean(vals[1]);


                   

               }
               else
               {


                   CreateConfig();

               }
           }
           catch (Exception e)
           {

               Program.Bugtracking(e);
               //return null;
           }

       }
       /// <summary>
       /// Creates the default configuration of the scrabler library
       /// </summary>
       public void CreateConfig()
       {

           try
           {

               ado.TableCreation(filename, cells, "");
              
           }
           catch (Exception e)
           {

               Program.Bugtracking(e);
               //return null;
           }

       }
       
    }
}
