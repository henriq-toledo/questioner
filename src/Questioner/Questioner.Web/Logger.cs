using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;

namespace Questioner.Web
{
    public class Logger
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Logger));

        static Logger()
        {
            var log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("web.config"));

            var repository = LogManager.CreateRepository(
                Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));

            var configuration = log4netConfig["configuration"];
            var log4net = configuration["log4net"];

            if (log4net == null)
            {
                throw new Exception("The log4net node must be configured in the configuration node from the web.config file.");
            }
                
            XmlConfigurator.Configure(repository, log4net);
        }
    }
}