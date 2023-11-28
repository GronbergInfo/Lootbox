using System;
using System.Diagnostics;
using System.IO;

namespace LootBox.classes;

public class Logging
{
    // public class FileLogging
    //{
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
            
            if (!Directory.Exists(logFilePath)) Directory.CreateDirectory(logFilePath);
            
            
            logFilePath = Path.Combine(logFilePath, $"{DateTime.UtcNow:yyyy-MM-dd HH-00-00}.log");


            string logEntry = $"{DateTime.Now} " + level.ToString().PadLeft(15,char.Parse(" ")) + ": " + message;
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
           
        }
        catch (Exception ex)
        {
            //Console.WriteLine(ex.Message);
            Debug.WriteLine(ex.Message);
           
        }

       
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