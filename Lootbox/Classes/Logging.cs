using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace LootBox.classes;

public class Logging
{
    // public class FileLogging
    //{
    private string _logFolder =
        Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()!.Location) + @"\logs\";


    public Boolean Log(LogLevel level, string message)
    {
        var success = false;

        try
        {
            if (level < 0)
                return false;
            string logFilePath = _logFolder;
            
            if (!Directory.Exists(logFilePath)) Directory.CreateDirectory(logFilePath);
            
            
            logFilePath = Path.Combine(logFilePath,
                $"{DateTime.UtcNow.ToString("yyyy-MM-dd HH-00-00")}.log");

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


            string logEntry = $"{DateTime.Now} " + level.ToString().PadLeft(15,Char.Parse(" ")) + " " + message;
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
    // }

    public void Dispose()
    {
        // Clean up any resources here
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
using (var logger = new Logging())
{
    // Use the logger here
    logger.Log(LogLevel.Information, "Logging information");
    logger.Log(LogLevel.Warning, "Logging warning");
    logger.Log(LogLevel.Error, "Logging error");
}
*/