using PractLogger.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PractLogger.Logger
{
    public class Log : ILog
    {
        private string todayCurrentDir;
        public Log() 
        {
            todayCurrentDir = Directory.GetCurrentDirectory() + "/" + DateTime.Now.ToString("dd-MM-yy");
            CreateTodayFolder(todayCurrentDir);
        }
        public void Debug(string message)
        {
            LogWrite(LogType.Debug, message);
        }

        public void Debug(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION : {e.Message}";
            LogWrite(LogType.Debug, printMessage);
        }

        public void DebugFormat(string message, params object[] args)
        {
            string printMessage = $" {message}; args-{String.Join(";", args)}";
            LogWrite(LogType.Debug, printMessage);
        }

        public void Error(string message)
        {
            LogWrite(LogType.Error, " "+message);
        }

        public void Error(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION - {e.Message}";
            LogWrite(LogType.Error, printMessage);
        }

        public void Error(Exception ex)
        {
            string printMessage = $" EXСEPTION - {ex.Message}";
            LogWrite(LogType.Error, printMessage);
        }

        public void ErrorUnique(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION - {e.Message}";
            if(!CheckUnique(LogType.Error,printMessage))
                LogWrite(LogType.Error, printMessage);
        }

        public void Fatal(string message)
        {
            string printMessage = $" {message}";
            LogWrite(LogType.Fatal, printMessage);
        }

        public void Fatal(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION : {e.Message}";
            LogWrite(LogType.Fatal, printMessage);
        }

        public void Info(string message)
        {
            LogWrite(LogType.Info, " " + message);
        }

        public void Info(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION : {e.Message}";
            LogWrite(LogType.Info, printMessage);
        }

        public void Info(string message, params object[] args)
        {
            string printMessage = $" {message}; args-{String.Join(";", args)}";
            LogWrite(LogType.Info, printMessage);
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            LogWrite(LogType.SystemInfo, message, properties);
        }

        public void Warning(string message)
        {
            LogWrite(LogType.Warning, " " + message);
        }

        public void Warning(string message, Exception e)
        {
            string printMessage = $" {message}; EXСEPTION : {e.Message}";
            LogWrite(LogType.Warning, printMessage);
        }

        public void WarningUnique(string message)
        {
            string printMessage = $" {message}";
            if (!CheckUnique( LogType.Warning,printMessage))
                LogWrite(LogType.Warning, printMessage);
        }

        private void CreateTodayFolder(string currentDir) 
        {
            Directory.CreateDirectory(currentDir);
        }

        private void LogWrite(LogType logType, string message, Dictionary<object, object> properties = null) 
        {
            using (StreamWriter writer = new StreamWriter($"{todayCurrentDir}/{logType}.log", true))
            {
                writer.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {logType} :{message}");
                if (properties != null) 
                {
                    foreach (var key in properties.Keys)
                    {
                        writer.WriteLine($"\t{key}-{properties[key]}");
                    }
                }
            }
        }

        private bool CheckUnique(LogType logType,string checkMessage) 
        {
            using (StreamReader reader = new StreamReader($"{todayCurrentDir}/{logType}.log")) 
            {
                while (!reader.EndOfStream) 
                {
                    var parseMess = reader.ReadLine().Split(":");
                    if (parseMess.Last().Equals(checkMessage)) 
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
            return false;
        }
        private enum LogType
        {
            Debug,
            Info,
            Warning,
            Fatal,
            Error,
            SystemInfo
        }
    }
}
