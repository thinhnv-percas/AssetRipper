namespace McMaster.Extensions.CommandLineUtils;

public interface IReporter
{
	void Verbose(string message);

	void Output(string message);

	void Warn(string message);

	void Error(string message);
}
