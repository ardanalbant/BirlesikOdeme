using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Business
{
    public class LoggerBL
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static LoggerBL instance = null;
        public static LoggerBL GetInstance()
        {
            if (instance == null)
            {
                initializeLog();
                instance = new LoggerBL();
                return instance;
            }

            return instance;
        }

        private static void initializeLog()
        {
            string logFileName = string.Format("{0:yyyyMMdd}_log.txt", DateTime.Now);
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.GetRepository();
            foreach (log4net.Appender.IAppender appender in repository.GetAppenders())
            {
                if (appender.Name.CompareTo("FileAppender") == 0 && appender is log4net.Appender.FileAppender)
                {
                    log4net.Appender.FileAppender fileAppender = (log4net.Appender.FileAppender)appender;
                    fileAppender.File = System.IO.Path.Combine(ConfigurationManager.AppSettings["LogFolder"], "Log", logFileName);
                    fileAppender.ActivateOptions();
                }
            }
        }

        public void Info(string message)
        {
            if (log.IsInfoEnabled)
            {
                log.Info(message);
            }
        }

        public void Debug(string message)
        {
            if (log.IsDebugEnabled)
            {
                log.Debug(message);
            }
        }

        public void Error(string message, Exception ex)
        {
            if (log.IsErrorEnabled)
            {
                log.Error(message, ex);
            }
        }
    }
}