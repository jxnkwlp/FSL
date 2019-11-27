namespace Fsl.Abstractions.Logging
{
	public interface ILoggerProvider
	{
		ILogger CreateLogger(string categoryName);
	}
}
