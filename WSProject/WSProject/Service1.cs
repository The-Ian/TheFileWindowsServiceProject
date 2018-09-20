using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WSProject;
using WSProject.Properties;

namespace WSProject
{
    public partial class Service1 : ServiceBase
    {
        
       
        Queue<string> fileQueue = new Queue<string>();
        DateTime lastSearch;

        public Service1()
        {
            InitializeComponent();
        }

        private void LoadDirectory()
        {
            StreamReader sRead = new StreamReader(@"C:\Users\Cyberadmin\Desktop\WSProject\WSProject\Resources\DirList.csv");
            FileSystemWatcher Watch = new FileSystemWatcher();
            while (!sRead.EndOfStream)
            {
                Watch.Path = sRead.ReadLine();
            }
            

            Watch.EnableRaisingEvents = true;
            Watch.Changed += fileSystemWatcher1_Changed;
            Watch.Created += fileSystemWatcher1_Created;
            Watch.Deleted += fileSystemWatcher1_Deleted;
            Watch.Renamed += fileSystemWatcher1_Renamed;

        }

        private void LogIt(string[] Message)
        {
            StreamWriter sWrite = new StreamWriter("FileWatcherLog.txt", true);

            foreach (string line in Message)
            {
                sWrite.WriteLine(line);            
            }
                sWrite.WriteLine("");
                sWrite.Flush();
                sWrite.Close();
        }

       // private void CopyFileToBackup()

        internal void TestRun(string[] args)
        {
            OnStart(args);
            while(timer1.Enabled)
            {
                Console.ReadLine();
            }
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            string Pls = "Program started at ";
            LogIt(new string[] { Pls + DateTime.Now + "." });
            LoadDirectory();
           
        }

        protected override void OnStop()
        {
            string Pls = "Program stopped at ";
            LogIt(new string[] { Pls + DateTime.Now + "." });
            
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {
            string changedFile = e.FullPath + " " + e.ChangeType;

            LogIt(new string[] { changedFile});
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string createdFile = e.FullPath + " has been created at " 
                + DateTime.Now + ".";

            LogIt(new string[] {createdFile});
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            string deletedFile = e.FullPath + " has been deleted at " 
                + DateTime.Now + ".";

            LogIt(new string[] { deletedFile });
        }

        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            string renamed = e.Name;
            string oldName = e.OldName;

            string LogEvent;
            LogEvent = "The file " + oldName + " has been renamed to "
                + renamed + " at " + DateTime.Now + ".";

            LogIt(new string[] { LogEvent });
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
           
          
            
            lastSearch = DateTime.Now;
            
        }
    }
}
