using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace My
{
    public class MyLogger
    {

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"logs\", @"logfile" + DateTime.Now.ToString("dd-MM-yy") + ".txt");
        public MyLogger()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"logs\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"logs\");
            }
        }

        /// <summary>
        /// for Testing to log
        /// </summary>
        /// <param name="SystemName">Input System Name , e.g. "SIS"</param>
        /// <param name="SubSystemName">"Stock" or "Sales"</param>
        /// <param name="functionName"></param>
        /// <param name="message"></param>
        public void Info(string SystemName, string SubSystemName, string functionName, string message)
        {
            bool IsTesting = false;
            try
            {
                IsTesting = bool.Parse(ConfigurationManager.AppSettings["IsTestToLog"]);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "App.config not found Key(IsTestToLog)  ,Exception:" + ex.Message;
                IsTesting = false;
            }

            if (IsTesting)
            {
                WriteInfo(String.Format("[System:{0}] SubSystem:{1},Function:{2},Message:{3}", SystemName, SubSystemName, functionName, message));
            }
        }

        public void Error(string functionName, string message)
        {
            bool IsTesting = false;
            try
            {
                IsTesting = bool.Parse(ConfigurationManager.AppSettings["IsTestToLog"]);
            }
            catch (Exception ex)
            {
                string ErrorMessage = "App.config not found Key(IsTestToLog)  ,Exception:" + ex.Message;
                IsTesting = false;
            }

            if (IsTesting)
            {
                WriteInfo(String.Format("[Function:{0},Message:{1}", functionName, message));
            }
        }



        public void WriteInfo(string message)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(message);
                sw.Close();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
           


    }
}
