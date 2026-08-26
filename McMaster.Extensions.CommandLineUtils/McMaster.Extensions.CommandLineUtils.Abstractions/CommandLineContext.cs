using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

public abstract class CommandLineContext
{
	private string[] _args = new string[0];

	private string _workDir = Directory.GetCurrentDirectory();

	private IConsole _console = PhysicalConsole.Singleton;

	public string[] Arguments
	{
		get
		{
			return _args;
		}
		protected set
		{
			_args = value ?? throw new ArgumentNullException("value");
		}
	}

	public string WorkingDirectory
	{
		get
		{
			return _workDir;
		}
		protected set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new ArgumentNullException("value");
			}
			if (!Path.IsPathRooted(value))
			{
				throw new ArgumentException("File path must not be relative.", "value");
			}
			_workDir = value;
		}
	}

	public IConsole Console
	{
		get
		{
			return _console;
		}
		protected set
		{
			_console = value ?? throw new ArgumentNullException("value");
		}
	}
}
