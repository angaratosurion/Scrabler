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
using System.Collections;

using WareForms;
using Hydrobase;
using HydrobaseSDK;
// 

namespace Scrabler
{
    /// <summary>
    /// This class keeps the info the script
    ///  @authorKiparissis Koutsioukis(Angarato Surion)
    /// </summary>
    public class ScriptInfo
    {
        string title, author, version, description, copyright, LowerappVer
            , MaxappVer, scrablerVersion,filename,language;
        /// <summary>
        /// The title of the script
        /// </summary>
        public string Title
        {
            get
            {

                return title;
            }
            set
            {

                title = value;
            }


        }
        
        /// <summary>
       /// The author of the script
       /// </summary>
        public string Author
        {

            get
            {

                return author;
            }
            set
            {


                author = value;
            }


        }
        /// <summary>
        /// Version of the script
        /// </summary>
        public string Version
        {

            get
            {

                return version;
            }
            set
            {

                version = value;
            }


        }
        /// <summary>
        /// Description of the script
        /// </summary>
        public string Description
        {


            get
            {

                return description;
            }
            set
            {

                description = value;

            }
        }
        /// <summary>
        /// Programing language that script is written
        /// </summary>
        public string Language
        {
            get { return language; }
            set { language = value; }

        }
        /// <summary>
        /// Copyright info of the script
        /// </summary>
        public string Copyright
        {
            get
            {

                return copyright;
            }
            set
            {

                copyright = value;
            }


        }
        /// <summary>
        /// The lowest version that the script is written for.
        /// </summary>
        public string LowerApplicationVersion
        {
            get
            {

                return LowerappVer;
            }
            set
            {

                LowerappVer = value;
            }



        }
        /// <summary>
        /// The maximum version of the application that is written for.
        /// </summary>
        public string MaxApplicationVersion
        {
            get
            {

                return MaxappVer;
            }
            set
            {

                MaxappVer = value;
            }


        }
        /// <summary>
        /// The Version of the Scrabler version that is able to run the script.
        /// </summary>
        public string ScrablerVersion
        {

            get
            {

                return scrablerVersion;
            }
            set
            {

                scrablerVersion = value;

            }

        }
        /// <summary>
        /// The filename of the script
        /// </summary>
        public string Filename
        {
            get { return filename; }
            set { filename = value; }

        }
    }
}
