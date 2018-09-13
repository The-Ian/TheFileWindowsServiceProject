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

namespace WSProject
{
    public partial class Service1 : ServiceBase
    {
        StreamWriter sWrite = new StreamWriter("FileWatcherLog.txt");
        StreamReader sRead = new StreamReader("DirectoryList.csv");
        
        bool activeMonitor;
        Queue<string> fileQueue = new Queue<string>();
        DateTime lastSearch;

        public Service1()
        {
            InitializeComponent();
        }

        private void LoadDirectory()
        {
            FileSystemWatcher Watch = new FileSystemWatcher();
            Watch.Path = sRead.ReadLine();

            Watch.Changed += fileSystemWatcher1_Changed;
            Watch.Created += fileSystemWatcher1_Created;
            Watch.Deleted += fileSystemWatcher1_Deleted;
            Watch.Renamed += fileSystemWatcher1_Renamed;

        }
        

        protected override void OnStart(string[] args)
        {
            activeMonitor = true;
        }

        protected override void OnStop()
        {
            activeMonitor = false;
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {   
            string changedFile = e.FullPath + " " + e.ChangeType;
            sWrite.WriteLine(changedFile);
            sWrite.Close();
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string createdFile = e.FullPath + " has been created at " 
                + DateTime.Now + ".";
            sWrite.WriteLine(createdFile);
            sWrite.Close();
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            string deletedFile = e.FullPath + " has been deleted at " 
                + DateTime.Now + ".";
            sWrite.WriteLine(deletedFile);
            sWrite.Close();
        }

        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            string renamed = e.Name;
            string oldName = e.OldName;

            string LogEvent;
            LogEvent = "The file " + oldName + " has been renamed to "
                + renamed + " at " + DateTime.Now + ".";
            sWrite.WriteLine(LogEvent);
            sWrite.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            lastSearch = DateTime.Now;
            timer1.Enabled = activeMonitor;
        }
    }
}
