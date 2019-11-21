using Fsl.Abstractions.Logging;
using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fsl.Logging.Log4net
{
	public class Log4netAdapate : ILogger
	{
		ILog log;
		public Log4netAdapate()
		{
			ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
			
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
			XmlConfigurator.Configure(repository, new System.IO.FileInfo(path));

			log = LogManager.GetLogger(repository.Name, "NETCorelog4net");
		}
		
		public void Log(string category, LogLevel level, Exception ex, string message, params string[] args)
		{
			switch (level)
			{
				case LogLevel.Debug:
					log.DebugFormat(message,args);
					break;
				case LogLevel.Information:
					log.InfoFormat(message, args);
					break;
				case LogLevel.Warning:
					log.WarnFormat(message, args);
					break;
				case LogLevel.Error:
					log.ErrorFormat(message, ex, args);
					break;
				case LogLevel.Critical:
					log.FatalFormat(message, args);
					break;
			}
		}
	}
}
