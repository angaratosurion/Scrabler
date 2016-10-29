using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scrabler;
using System.Diagnostics;
using System.Timers;

namespace Scrabler.Tools
{
    /// <summary>
    /// A class made ot watch over a process
    /// </summary>
    public class ProcessWatcher 
    {
      Process proc;
        Timer timer;
        /// <summary>
        /// It creates the process watcher class and takes a timer class
        /// </summary>
        /// <param name="tmr">timer witch you want to use</param>
        public ProcessWatcher( Timer tmr)
        {

            try
            {

                if (tmr != null)
                {



                   
                    timer = tmr;
                }


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
            }


        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProcessWatcher()
        {

            try
            {

                


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
            }


        }
        /// <summary>
        /// Creates the processwatcher class for the given process to watch over 
        /// </summary>
        /// <param name="tproc">process to watch over</param>
       public ProcessWatcher ( Process tproc)
        {

            try
            {

                if (tproc != null)
                {

                 

                    proc = tproc;
                   
                    timer = new Timer(1000);

                }


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
            }


        }
        /// <summary>
       ///  Creates the processwatcher class for the given process to watch over  and a timer
        /// </summary>
       /// <param name="tproc">process to watch over</param>
       /// <param name="tmr">timer witch you want to use</param>
     public ProcessWatcher(Process tproc,Timer tmr)
        {

            try
            {

                if ((tproc != null) &&(tmr!=null))
                {



                    proc = tproc;
                    timer = tmr;
                }


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
            }


        }
        /// <summary>
        /// kills the process whitch it watches
        /// 
        /// </summary>
        public void Kill()
        {

            try
            {

                if (proc != null)
                {



                    proc.Kill();
                }


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
            }


        }
        /// <summary>
        /// Starts the process it watches
        /// </summary>
        /// <returns>Starts the process it watches and returns true on succes</returns>
        public bool Start()
        {


            try
            { 

                if (proc != null)
                {



                 return    proc.Start();
                }
                return false;


            }
            catch (Exception ex)
            {

                Program.Bugtracking(ex);
                return false;
            }

        }
        /// <summary>
        /// Returns prioritty of the process
        /// </summary>
        public  int  BasePrioirty
        {

            get { return proc.BasePriority; }

        }
        /// <summary>
        /// Returns or sets the proecces
        /// </summary>
        public Process Process
        {
            get { return proc; }
            set { proc = value; }
        }
        /// <summary>
        /// gets or sets the timer
        /// </summary>
        public Timer Timer
        {
            get { return timer; }
            set { timer = value; }
        }
        
       
    }
}
