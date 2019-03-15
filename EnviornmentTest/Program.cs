using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EnviornmentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string tempFilePath = Path.GetTempFileName().Replace(".tmp", ".pdf");
            Console.WriteLine("Locale Settings: " + System.Globalization.CultureInfo.CurrentCulture);
            Console.WriteLine("Temporary File Path: " + tempFilePath);
            Console.WriteLine("OSVersion.Version.Major: " + System.Environment.OSVersion.Version.Major);
            Console.WriteLine("OSVersion.Version.Minor: " + System.Environment.OSVersion.Version.Minor);
            Console.WriteLine("Filepath contains C:\\Windows\\Temp: " + tempFilePath.Contains("C:\\Windows\\Temp"));
            Console.WriteLine("UserProfile Path: " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            string forcedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                "\\AppData\\Local\\Temp\\test.tmp";
            bool writeToForcedPathFailed = true;
            Console.WriteLine("Forced Path: " + forcedPath);
            string exceptionMessageReceived = "";
            try
            {
                File.Create(forcedPath);
                writeToForcedPathFailed = false;
            }
            catch (Exception e)
            {
                writeToForcedPathFailed = true;
                exceptionMessageReceived = e.ToString();
            }
            
            Console.WriteLine("Write to Force Path Failed: " + writeToForcedPathFailed);
            if (writeToForcedPathFailed)
            {
                
                Console.WriteLine("Exception Message: " + exceptionMessageReceived);
            }
            Console.WriteLine();
            Console.WriteLine("Press return to exit.");
            Console.ReadLine();
        }
    }
}
