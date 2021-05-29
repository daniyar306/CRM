using System;
using System.Collections.Generic;
using System.Text;

namespace NanoSat.Service
{
    /// <summary>
    /// Записывает информацию в файл
    /// </summary>
    public class cLogger
    {
        ///// <summary>
        ///// Создает новый экземпляр логера
        ///// </summary>
        ///// <param name="logfilename">Имя файла лога</param>
        public cLogger(string logfilename)
        {
            var _path = System.IO.Path.Combine(GetAppPath(), logfilename);
            LogFileName = new Uri(_path).LocalPath; 
        }

        /// <summary>
        /// Создает новый экземпляр логера
        /// </summary>
        /// <param name="logfilename">Имя файла лога</param>
        /// <param name="isCEPlatform">Используется WinCE</param>
        public cLogger(string logfilename, bool isCEPlatform)
        {
            var _path = System.IO.Path.Combine(GetAppPath(), logfilename);

            if (isCEPlatform)
            {
                if (_path.StartsWith("\\"))
                {
                    LogFileName = _path.Substring(1);
                }
                else
                {
                    LogFileName = _path;
                }
            }
            else
            {
                LogFileName = new Uri(_path).LocalPath;
            }

        }

        static string LogFileName;
        bool isBusy = false;

        private string GetAppPath()
        {
            string codeBase = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            return System.IO.Path.GetDirectoryName(codeBase);
        }

        /// <summary>
        /// Добавить запись в лог
        /// </summary>
        /// <param name="message">Добавляемая запись</param>
        public void AppendToLog(string message)
        {
            try
            {
                System.IO.FileInfo info = new System.IO.FileInfo(LogFileName);
                if (info.Exists && info.Length > 104857600)
                {
                    info.Delete();

                    var rewriter = info.CreateText();
                    rewriter.WriteLine(DateTime.Now.ToString() + " > Log cleared after oversize!");
                    rewriter.Flush();
                    rewriter.Close();
                    rewriter.Dispose();
                }

                var writer = info.AppendText();
                writer.WriteLine(DateTime.Now.ToString() + " > " + message);
                writer.Flush();
                writer.Close();
                writer.Dispose();

            }
            catch //(Exception)
            {

            }
        }

    }
}
