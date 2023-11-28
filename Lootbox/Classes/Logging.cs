using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LootBox.classes;

public class Logging
{
    private string level = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location) +
                           @"\logs\";


    public class FileLogging
    {
        
        public Boolean Log(LogLevel level, string message)
        {
            var success = false;

            try
            {
                if (level < 0)
                    return false;
                string logFilePath = level;
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

        private string GetLogFilePath()
        {
            string fileName = $"{_logFileName}_{DateTime.Now:yyyyMMdd}.log";
            string filePath = Path.Combine(_logDirectory, fileName);

            return filePath;
        }
    }

    public enum LogLevel
    {
        Information,
        Warning,
        Error
    }

    public enum LogFile
    {
        Auth,
        Error,
        Unknown
    }
}

// Example How to Log
/*
    FileLogger logger = new FileLogger("C:\\Logs", "app_log", LogLevel.Information);
    logger.Log(LogLevel.Information, "This is an information log.");
    logger.Log(LogLevel.Warning, "This is a warning log.");
    logger.Log(LogLevel.Error, "This is an error log.");
*/