using Fsl.Abstractions.Logging;
using log4net;
using log4net.Config;
using System.Collections.Concurrent;
using System.IO;

namespace Fsl.Logging.Log4net
{
	public class Log4netLoggerProvider : ILoggerProvider
	{
		private readonly ConcurrentDictionary<string, ILogger> _logs = new ConcurrentDictionary<string, ILogger>();
		private readonly string _configFileName;
		private readonly string _repository;

		public Log4netLoggerProvider(string configFileName, string repository)
		{
			if (string.IsNullOrWhiteSpace(configFileName))
			{
				throw new System.ArgumentException("message", nameof(configFileName));
			}

			if (string.IsNullOrWhiteSpace(repository))
			{
				throw new System.ArgumentException("message", nameof(repository));
			}

			_configFileName = configFileName;
			_repository = repository;

			var loggerRepository = LogManager.CreateRepository(_repository);
			XmlConfigurator.Configure(loggerRepository, new FileInfo(configFileName));
		}

		public ILogger CreateLogger(string categoryName)
		{
			return _logs.GetOrAdd(categoryName, CreateLoggerInternal);
		}

		private ILogger CreateLoggerInternal(string name)
		{
			return new Log4netLogger(new Log4netLoggerOptions()
			{
				ConfigFileName = _configFileName,
				Repository = _repository,
				Name = name
			});
		}
	}
}
