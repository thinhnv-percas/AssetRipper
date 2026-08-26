using System.IO;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Internal;

internal class DefaultCommandLineContext : CommandLineContext
{
	public DefaultCommandLineContext()
	{
	}

	public DefaultCommandLineContext(IConsole console)
	{
		base.Console = console;
	}

	public DefaultCommandLineContext(IConsole console, string workDir)
		: this(console)
	{
		if (!Path.IsPathRooted(workDir))
		{
			workDir = Path.GetFullPath(workDir);
		}
		base.WorkingDirectory = workDir;
	}

	public DefaultCommandLineContext(IConsole console, string workDir, string[] args)
		: this(console, workDir)
	{
		base.Arguments = args;
	}
}
