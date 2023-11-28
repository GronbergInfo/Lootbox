using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LootBox.classes;

public class Logging
{


    public class FileLogging
    {
        public string _logFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location) + @"\logs\";

        
        public Boolean Log(LogLevel level, string message)
        {
            var success = false;

            try
            {
                if (level < 0)
                    return false;
                string logFilePath = _logFolder;
                logFilePath = Path.Combine(logFilePath, string.Format("info{0}.log",DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss")));
                
                // switch (level)
                // {
                //     case LogLevel.Information:
                //         logFilePath = Path.Combine(logFilePath, "info.log");
                //         break;
                //     case LogLevel.Warning:
                //         logFilePath = Path.Combine(logFilePath, "warning.log");
                //         break;
                //     case LogLevel.Error:
                //         logFilePath = Path.Combine(logFilePath, "error.log");
                //         break;
                //     
                //     
                // }


                string logEntry = $"{DateTime.Now} [{level}] {message}";
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
                success = true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                success = false;
            }

            return success;
        }

        // private string GetLogFilePath()
        // {
        //     string fileName = $"{_logFileName}_{DateTime.Now:yyyyMMdd}.log";
        //     string filePath = Path.Combine(_logDirectory, fileName);
        //
        //     return filePath;
        // }
    }

    public enum LogLevel
    {
        Information,
        Warning,
        Error
    }

}

// Example How to Log
/*
    FileLogger logger = new FileLogger("C:\\Logs", "app_log", LogLevel.Information);
    logger.Log(LogLevel.Information, "This is an information log.");
    logger.Log(LogLevel.Warning, "This is a warning log.");
    logger.Log(LogLevel.Error, "This is an error log.");
*/