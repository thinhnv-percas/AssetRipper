namespace McMaster.Extensions.CommandLineUtils;

public class NullReporter : IReporter
{
	public static IReporter Singleton { get; } = new NullReporter();

	private NullReporter()
	{
	}

	public void Verbose(string message)
	{
	}

	public void Output(string message)
	{
	}

	public void Warn(string message)
	{
	}

	public void Error(string message)
	{
	}
}
