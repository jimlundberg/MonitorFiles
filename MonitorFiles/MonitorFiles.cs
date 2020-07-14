using System;
using System.IO;
using System.Threading;

class Program
{
    public class MonitorDirectoryFiles
    {
        public static bool MonitorDirectory(string monitoredDir, int numberOfFilesNeeded, int timeout)
        {
            bool filesFound = false;
            int numberOfSeconds = 0;

            do
            {
                int numberOfFilesFound = Directory.GetFiles(monitoredDir, "*", SearchOption.TopDirectoryOnly).Length;
                Console.WriteLine("{0} has {1} files at {2} seconds", monitoredDir, numberOfFilesFound, numberOfSeconds);
                if (numberOfFilesFound >= numberOfFilesNeeded)
                {
                    return true;
                }

                Thread.Sleep(1000);
                numberOfSeconds++;

            } while ((filesFound == false) && (numberOfSeconds < timeout));

            return false;
        }
    }

    static void Main()
    {
        String JobDirectory = @"C:\SSMCharacterizationHandler\Input Buffer";
        String Job = "1307106_202002181303";
        String InputBufferDir = JobDirectory + @"\" + Job;
        MonitorDirectoryFiles.MonitorDirectory(InputBufferDir, 6, 60);
        Console.WriteLine("File list complete");
    }
}
