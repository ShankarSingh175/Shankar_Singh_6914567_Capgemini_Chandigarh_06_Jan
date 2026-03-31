using System;
using System.Reflection;
using log4net;
using log4net.Config;

namespace ECommerceAPI.Helpers   // ✅ important: namespace must match your project
{
    public static class Logger
    {
        private static readonly ILog log;

        static Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
            log = LogManager.GetLogger(typeof(Logger));
        }

        public static void LogInfo(string message)
        {
            log.Info(message);
        }

        public static void LogWarn(string message)
        {
            log.Warn(message);
        }

        public static void LogError(string message, Exception ex = null)
        {
            if (ex != null)
                log.Error(message, ex);
            else
                log.Error(message);
        }
    }
}