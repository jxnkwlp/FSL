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
			logger.Info("info","test");
		}
    }
}
