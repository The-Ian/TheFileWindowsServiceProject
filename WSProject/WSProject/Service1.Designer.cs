﻿namespace WSProject
{
    partial class Service1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.timer1 = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).BeginInit();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000D;
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Elapsed);
            // 
            // Service1
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timer1)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Timers.Timer timer1;
    }
}
