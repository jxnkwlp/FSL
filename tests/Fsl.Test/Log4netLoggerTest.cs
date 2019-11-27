using Fsl.Abstractions.Logging;
using Fsl.Logging.Log4net;
using NUnit.Framework;
using System;

namespace Fsl.Test
{
	public class Log4netLoggerTest
	{
		ILogger _logger;

		[SetUp]
		public void Setup()
		{
			var provider = new Log4netLoggerProvider("log4net.config", "Fsl");

			_logger = provider.CreateLogger("category");
		}

		[Test]
		public void TestProvider()
		{
			Assert.IsNotNull(_logger);

			Assert.AreEqual(_logger.GetType(), typeof(Log4netLogger));
		}

		[Test]
		public void TestWriteLog()
		{
			_logger.Info("test", "This is test message");
			_logger.Info("test", "This is test message with params in {0}", DateTime.Now);
		}
	}
}
