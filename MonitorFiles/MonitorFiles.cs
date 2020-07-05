using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

class Program
{
    public class MonitorFiles
    {
        private static Timer timer;
        private static int numberOfFiles;
        private static int numberOfFilesFound;
        private static string monitoredDir;
        private static bool FilesFound;

        public static void MonitorDirectory(string _monitoredDir, int _numberOfFIles)
        {
            numberOfFiles = _numberOfFIles;
            monitoredDir = _monitoredDir;
            FilesFound = false;

            timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

            if (FilesFound)
            {
                return;
            }

            Console.WriteLine("Press the Enter key to exit anytime... ");
            Console.ReadLine();
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Check directory for number of files
            numberOfFilesFound = Directory.GetFiles(monitoredDir, "*", SearchOption.TopDirectoryOnly).Length;
            Console.WriteLine("Directory Checked: {0} number of files {1}", e.SignalTime, numberOfFilesFound);
            if (numberOfFiles == numberOfFilesFound)
            {
                FilesFound = true;
            }
        }
    }

    static void Main()
    {
        MonitorFiles.MonitorDirectory(@"C:\Temp", 7);
    }
}
