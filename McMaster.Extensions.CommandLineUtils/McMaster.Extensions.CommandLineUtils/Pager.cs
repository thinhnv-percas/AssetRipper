using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

public class Pager : IDisposable
{
	private readonly Lazy<Process> _less;

	private readonly TextWriter _fallbackWriter;

	private bool _enabled;

	private bool _disposed;

	private string _prompt = "Use arrow keys to scroll\\. Press 'q' to exit\\.";

	public string Prompt
	{
		get
		{
			return _prompt;
		}
		set
		{
			if (_less.IsValueCreated)
			{
				throw new InvalidOperationException("Cannot set the prompt on the pager after the pager has begun");
			}
			_prompt = value;
		}
	}

	public TextWriter Writer
	{
		get
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("Pager");
			}
			return _less.Value?.StandardInput ?? _fallbackWriter;
		}
	}

	public Pager()
		: this(PhysicalConsole.Singleton)
	{
	}

	public Pager(IConsole console)
	{
		if (console == null)
		{
			throw new ArgumentNullException("console");
		}
		_enabled = Type.GetType("Mono.Runtime") != null;
		_less = new Lazy<Process>(CreateWriter);
		_fallbackWriter = console.Out;
	}

	public void WaitForExit()
	{
		Dispose();
	}

	public void Kill()
	{
		if (_less.IsValueCreated)
		{
			_less.Value.Kill();
		}
	}

	private Process CreateWriter()
	{
		if (!_enabled)
		{
			return null;
		}
		List<string> args = new List<string>
		{
			"-K",
			"--prompt=" + Prompt
		};
		Process process = new Process
		{
			StartInfo = 
			{
				FileName = "less",
				Arguments = ArgumentEscaper.EscapeAndConcatenate(args),
				RedirectStandardInput = true,
				UseShellExecute = false
			}
		};
		try
		{
			process.Start();
			return process;
		}
		catch (Exception ex)
		{
			if (DotNetCliContext.IsGlobalVerbose())
			{
				Console.Error.WriteLine("debug: Failed to start pager: " + ex.ToString());
			}
			_enabled = false;
			return null;
		}
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		_disposed = true;
		if (_less.IsValueCreated)
		{
			Process value = _less.Value;
			if (value != null)
			{
				value.StandardInput.Dispose();
				value.WaitForExit();
				value.Dispose();
			}
		}
	}
}
