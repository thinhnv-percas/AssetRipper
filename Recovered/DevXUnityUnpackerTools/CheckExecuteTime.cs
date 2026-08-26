using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class CheckExecuteTime : IDisposable
{
	private static bool _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A = !_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A._0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A;

	public DateTime StartTimeLocal;

	[CompilerGenerated]
	private string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A;

	public Dictionary<string, long> LineCounter = new Dictionary<string, long>();

	public string CurrentLine;

	[CompilerGenerated]
	private string _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020;

	public string Name
	{
		get;
		set;
	}

	public string Line
	{
		set
		{
			CurrentLine = value;
			if (LineCounter == null)
			{
				LineCounter = new Dictionary<string, long>();
			}
			if (!LineCounter.ContainsKey(value))
			{
				LineCounter[value] = 1L;
			}
			else
			{
				LineCounter[value]++;
			}
		}
	}

	public string StackTrace
	{
		get;
		set;
	}

	public TimeSpan TimeSpan => DateTime.Now - StartTimeLocal;

	public static string StackTraceMinimized
	{
		get
		{
			string stackTrace = Environment.StackTrace;
			string text = "";
			string[] array = stackTrace.Replace("\r\n", "\n").Split('\n');
			foreach (string text2 in array)
			{
				if (!string.IsNullOrEmpty(text2) && !text2.Contains("at System.") && !text2.Contains("в System.") && !text2.Contains("CheckExecuteTime"))
				{
					text = text + text2 + "\r\n";
				}
			}
			return text;
		}
	}

	public static CheckExecuteTime Start(string name, bool is_fast = false)
	{
		return new CheckExecuteTime(name, is_fast);
	}

	internal CheckExecuteTime(string name, bool is_fast = false)
	{
		if (_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A)
		{
			StartTimeLocal = DateTime.Now;
			Name = name;
			try
			{
				if (!is_fast)
				{
					StackTrace = StackTraceMinimized;
				}
			}
			catch
			{
			}
		}
	}

	public void Dispose()
	{
		if (_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A)
		{
			TimeSpan timeSpan = TimeSpan;
			if (timeSpan.TotalSeconds >= 1.0)
			{
				ConsoleManager._0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020.WriteLine("CheckTime: " + Name + " sec=" + timeSpan.TotalSeconds);
			}
		}
	}
}
