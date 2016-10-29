using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Scrabler;
using System.Diagnostics;
using System.Timers;

namespace Scrabler.Tools
{
    /// <summary>
    /// Manages the tasks which are controled by thr processwatcher classes
    /// processes here mean compiled scripts.
    /// </summary>
   public  class TaskManager
   {
       Timer TmrManagerLstUpd = new Timer(1000);
       List<ProcessWatcher> List = new List<ProcessWatcher>();
       public   TaskManager()
       {
           try
           {

               Process[] proc = Process.GetProcesses();
               if (proc != null)
               {

                   foreach (Process pr in proc)
                   {
                       ProcessWatcher pw = new ProcessWatcher(pr);
                       

                       this.List.Add(pw);
                   }

               }
               TmrManagerLstUpd.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
               TmrManagerLstUpd.Enabled = true;
               TmrManagerLstUpd.Start();
           }
           catch (Exception ex)
           {



           }

       }
      /// <summary>
      /// Find process (compiled scripts) byit's  name and returns it
      /// </summary>
      /// <param name="name">name of process</param>
       /// <returns>Find process by its name and returns it</returns>
       public ProcessWatcher FindProcessByName(string name)
       {

           try
           {

               ProcessWatcher ap = null;
               if (name != null)
               {


                   foreach (ProcessWatcher pw in this.List)
                   {
                       if (pw.Process.ProcessName == name)
                       {


                           ap = pw;
                           break;
                       }


                   }
               }




               return ap;

           }
           catch (Exception ex)
           {
               return null;


           }

       }
       /// <summary>
       /// Find all process (compiled scripts) with the  name and returns it
       /// </summary>
       /// <param name="name">>Find process by its name and returns it</param>
       /// <returns>Find all process (compiled scripts) with the  name and returns it</returns>
       public List< ProcessWatcher> FindProcesessByName(string name)
       {

           try
           {

               List<ProcessWatcher > ap = new List<ProcessWatcher>();
               if (name != null)
               {


                   foreach (ProcessWatcher pw in this.List)
                   {
                       if (pw.Process.ProcessName == name)
                       {


                           ap.Add( pw);
                          // break;
                       }


                   }
               }




               return ap;

           }
           catch (Exception ex)
           {
               return null;


           }

       }
       /// <summary>
       /// Kill (compiled script) with the given name
       /// </summary>
       /// <param name="name">name of the process (compiled script)</param>
       /// <returns>true if succesfully killed the  proecess(compiled script)</returns>
       public bool KillByName(string name)
       {

           try
           {
               bool ap = false;


               foreach (ProcessWatcher pw in List)
               {

                   if (pw.Process.ProcessName == name)
                   {

                       pw.Kill();
                       List.Remove(pw);
                       ap = true;
                   }

               }


               return ap;

           }
           catch (Exception ex)
           {
               return false ;


           }

       }
       /// <summary>
       /// Kill (compiled script) with the given id
       /// </summary>
       /// <param name="id">id of the (process (compiled script)</param>
       /// <returns>true if succesfully killed the  proecess(compiled script)</returns>
       public bool KillById(int id)
       {

           try
           {
               bool ap = false;


               foreach (ProcessWatcher pw in List)
               {

                   if (pw.Process.Id == id)
                   {


                       pw.Kill();
                       List.Remove(pw);
                       ap = true;
                   }

               }


               return ap;

           }
           catch (Exception ex)
           {
               return false;


           }

       }
       /// <summary>
       /// Adds a proccesswatcher to the taskmanager list
       /// </summary>
       /// <param name="pw">processwatcher object</param>
       /// <returns>true if it succeds</returns>
       public bool AddProcessWatcher(ProcessWatcher pw)
       {
            try
           {
               bool ap = false;
               if ((pw != null) &&(pw.Process !=null))
               {
                   foreach (ProcessWatcher tpw in List)
                   {
                       if (tpw.Process.ProcessName != pw.Process.ProcessName)
                       {
                           List.Add(pw);
                           ap = true;

                       }



                   }


               }
               return ap;

           }
            catch (Exception ex)
            {
                return false;


            }




       }
       private void OnTimedEvent(object source, ElapsedEventArgs e)
       {
           try
           {
               Process[] proc = Process.GetProcesses();
               if (proc != null)
               {

                   foreach (Process pr in proc)
                   {
                       ProcessWatcher pw = new ProcessWatcher(pr);


                       this.AddProcessWatcher(pw);
                   }

               }
           }
           catch (Exception ex)
            {
               // return false;


            }
       }
      
    }
}
