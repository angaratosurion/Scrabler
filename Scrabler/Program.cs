using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using NLog;
///// 

namespace Scrabler
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       // internal static Logger logman = NLog.LogManager.GetCurrentClassLogger();
        internal static Logger logman = NLog.LogManager.GetLogger("scraber");

        //scraber
        //public 
        /// <summary>
        /// The value that has the gui of the excutiing application.
        /// </summary>
        public static Form MainForm;
        
        

   /// <summary>
   /// Handling of the exception
   /// </summary>
   /// <param name="e">Execption</param>

        public static void Bugtracking (Exception e)
        {
            //ScrablerCore core = new ScrablerCore();
            Exception test = new Exception("System.NullReferenceException: Object reference not set to an instance of an object.\nat Scrabler.ScrablerCore.Eval(String sCSCode, String scriptname, String NameSapce, String Clas, String func, String[] refs, WareForm winGUI)");
         //   DataException;

            if ((e.ToString().Equals("System.NullReferenceException: Object reference not set to an instance of an object.\n at Scrabler.ScrablerCore.Eval(String sCSCode, String scriptname, String NameSapce, String Clas, String func, String[] refs, WareForm winGUI)")==false ) &&(e.Message!= test.Message )  &&(e.ToString() != test.ToString()))
            {
               // Bugger.TakeTheException2XmlLog(e, "Scrabler", ScrablerCore.GetVersion());

                //MessageBox.Show(e.Message ); logman.TraceException(e.Message, e);
            } 
            
            else
            {
                logman.TraceException(e.Message, e);
                //Bugger.TakeTheException2(e, "Scrabler", ScrablerCore.GetVersion(),true,true );
            }

        }
    }
}