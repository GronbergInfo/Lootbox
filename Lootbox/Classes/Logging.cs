using System;
using System.Diagnostics;
using System.IO;

namespace LootBox.classes;

public class Logging
{
    //Declarations
    private readonly string _logFolder =
        Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location) + @"\logs\";

    
    public void Log(LogLevel level, string message)
    {
        try
        {
            if (level < 0) return;    // If level is less than 0,
                                            // it means that the log level is not set.
                                            // So, we exit the function with false.
            
            string logFilePath = _logFolder;
            
            if (!Directory.Exists(logFilePath)) Directory.CreateDirectory(logFilePath); // Create the log directory if it does not exist.
            
            logFilePath = Path.Combine(logFilePath, $"{DateTime.UtcNow:yyyy-MM-dd HH-00-00}.log"); // Create the log file name.


            string logEntry = $"{DateTime.Now} " + level.ToString().PadLeft(15,char.Parse(" ")) + ": " + message;
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
           
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            Debug.WriteLine(ex.Message);
        }

       
    }

    public enum LogLevel
    {
        Information,
        Warning,
        Error
    }
}
