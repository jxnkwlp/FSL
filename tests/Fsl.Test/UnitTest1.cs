using Fsl.Abstractions.Logging;
using Fsl.Logging.Log4net;
using NUnit.Framework;

namespace Fsl.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLogging()
        {
			ILogger logger = new Log4netAdapate();
			//LoggerExtensions.Info(logger,"","test");
			LoggerExtensions.Info(logger, "", "test 111111");

			ILogger<Tests> logger1 = new Log4netAdapate<Tests>();

			logger1.Info("test22222222222");
		}
    }
}
