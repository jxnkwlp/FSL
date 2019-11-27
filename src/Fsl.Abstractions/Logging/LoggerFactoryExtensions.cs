namespace Fsl.Abstractions.Logging
{
	public static class LoggerFactoryExtensions
	{
		public static ILogger CreateLogger<T>(this ILoggerFactory loggerFactory)
		{
			return loggerFactory.CreateLogger(nameof(T));
		}
	}
}
