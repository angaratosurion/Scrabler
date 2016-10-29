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
using Scrabler.IDE;

namespace Scrabler
{ 
    public  class ScriptRepo
    {
        const string ctemp = "temp";
        const string scriptrepofolder = "Repository";
        const string binary = "Binary";
        const string code = "Code";
        string rep, temp,bin ;
        /// <summary>
        /// Default constracotr
        /// </summary>
        public ScriptRepo()
        {
            this.Init(null);


        }
        /// <summary>
        /// Constracts and gives the initial values for script repository to work
        /// </summary>
        /// <param name="mainfold">folder of script repo will be installe</param>
        public  ScriptRepo(string mainfold)
        {
            this.Init(mainfold);

        }
        /// <summary>
        /// Set or returns the path of the temp folder
        /// </summary>
        public string Temp
        {

        get { return temp; }
            set { temp = value; }
        }
        /// <summary>
        /// Set or returns the path of the script repository  folder
        /// </summary>
        public string Repository
        {

            get { return rep; }
            set { rep = value; }

        }
        /// <summary>
        /// Init the script repo options
        /// </summary>
        /// <param name="mainfolder">folder of script repo will be installed</param>
        public void Init(string mainfolder)
        {

            try
            {
                if (mainfolder != null)
                {

                    this.Temp = Path.Combine(mainfolder, ctemp);
                    this.Repository = Path.Combine(mainfolder, scriptrepofolder);
                     this.Binaryfolder = Path.Combine(mainfolder, binary);
                    
                }
                else
                {

                    string tmp = Path.GetDirectoryName(Application.ExecutablePath);
                    this.Temp = Path.Combine(tmp, ctemp);
                    this.Repository = Path.Combine(tmp, scriptrepofolder);
                    this.Binaryfolder= Path.Combine(tmp,binary );
                }
                Directory.CreateDirectory(this.Temp);
                Directory.CreateDirectory(this.Repository);
                Directory.CreateDirectory(this.Binaryfolder);

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);

            }

        }
        /// <summary>
        /// Clears the Temp directory
        /// </summary>
        public void ClearTempfolder()
        {
            try
            {
                if((this.temp !=null) ||(Directory.Exists(this.Temp) == true) )
                {
                    Directory.Delete(this.Temp, true);


                }

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);

            }

        }
        /// <summary>
        /// The folder of binariy files in repo
        /// </summary>
        public string Binaryfolder
        {
            get { return bin; }
            set { bin=value;}
        }


    
        /// <summary>
        /// Returns the full path of the executable filles in script repository
        /// </summary>
        /// <returns>Returns the full path of the executable filles in script repository
        /// null on fail </returns>
        public string [] Executables()
        {
            try
            {
                string[] exc=null;
                if((Directory.Exists(this.rep)==true) &&(Directory.Exists(Path.Combine(rep,binary))==true))
                {
                    exc = Directory.GetFiles (Path.Combine(rep, binary));
                  
                 



                }



                return exc;

            }
            catch (Exception e)
            {

                Program.Bugtracking(e);
                return null;

            }





        }
        
        
    }
}
