// Debug tracing for the IL2CPP -> C# pipeline. NOT part of the original product:
// added so a run can be diagnosed from a log file afterwards. Every write is a
// separate open/append/close so nothing is lost if the process dies mid-run.
//
// Log file: <exe dir>\il2cpp-debug.log, or %TEMP%\il2cpp-debug.log if the exe
// directory is not writable. The first line of every session states which.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

public static class DbgLog
{
	private const string LogFileName = "il2cpp-debug.log";

	private static readonly object gate = new object();
	private static readonly Dictionary<string, int> tagCounts = new Dictionary<string, int>();
	private static readonly Stopwatch clock = Stopwatch.StartNew();

	private static string resolvedPath;
	private static bool headerWritten;

	// Re-entrancy guard. The caller hooks AppDomain.FirstChanceException, and file I/O
	// in here can itself throw — without this, one failed write recurses until the
	// stack overflows.
	[ThreadStatic]
	private static bool busy;

	/// <summary>Full path of the log file actually being written.</summary>
	public static string LogPath
	{
		get
		{
			if (resolvedPath != null)
			{
				return resolvedPath;
			}
			if (busy)
			{
				return LogFileName;
			}
			busy = true;
			try
			{
				lock (gate)
				{
					if (resolvedPath == null)
					{
						resolvedPath = Resolve();
					}
					return resolvedPath;
				}
			}
			finally
			{
				busy = false;
			}
		}
	}

	private static string Resolve()
	{
		string[] candidates = new string[2]
		{
			SafeCombine(AppDomain.CurrentDomain.BaseDirectory, LogFileName),
			SafeCombine(Path.GetTempPath(), LogFileName)
		};
		foreach (string candidate in candidates)
		{
			if (candidate == null)
			{
				continue;
			}
			try
			{
				File.AppendAllText(candidate, string.Empty, Encoding.UTF8);
				return candidate;
			}
			catch
			{
			}
		}
		return LogFileName;
	}

	private static string SafeCombine(string dir, string file)
	{
		try
		{
			return string.IsNullOrEmpty(dir) ? null : Path.Combine(dir, file);
		}
		catch
		{
			return null;
		}
	}

	/// <summary>Write one tagged line.</summary>
	public static void W(string tag, string message)
	{
		Emit(tag, message);
	}

	/// <summary>Write one tagged line, but at most <paramref name="max"/> times for this tag.</summary>
	public static void Lim(string tag, string message, int max)
	{
		int seen;
		lock (gate)
		{
			tagCounts.TryGetValue(tag, out seen);
			seen++;
			tagCounts[tag] = seen;
		}
		if (seen <= max)
		{
			Emit(tag, message);
		}
		else if (seen == max + 1)
		{
			Emit(tag, "(further '" + tag + "' entries suppressed)");
		}
	}

	/// <summary>Write an exception with its full type/message/stack chain.</summary>
	public static void Ex(string tag, string message, Exception ex)
	{
		StringBuilder sb = new StringBuilder();
		sb.Append(message);
		Exception current = ex;
		int depth = 0;
		while (current != null && depth < 6)
		{
			sb.Append("\n    ");
			if (depth > 0)
			{
				sb.Append("---> ");
			}
			sb.Append(current.GetType().FullName).Append(": ").Append(current.Message);
			if (!string.IsNullOrEmpty(current.StackTrace))
			{
				sb.Append("\n").Append(current.StackTrace);
			}
			current = current.InnerException;
			depth++;
		}
		Emit(tag, sb.ToString());
	}

	/// <summary>Report a path: whether it exists, and for files how big it is.</summary>
	public static void Probe(string tag, string label, string path)
	{
		string state;
		try
		{
			if (string.IsNullOrEmpty(path))
			{
				state = "<null-or-empty>";
			}
			else if (Directory.Exists(path))
			{
				state = "DIR ok";
			}
			else if (File.Exists(path))
			{
				state = "FILE ok, " + new FileInfo(path).Length + " bytes";
			}
			else
			{
				state = "*** MISSING ***";
			}
		}
		catch (Exception ex)
		{
			state = "probe failed: " + ex.GetType().Name + " " + ex.Message;
		}
		Emit(tag, label + " = " + (path ?? "<null>") + "   [" + state + "]");
	}

	private static void Emit(string tag, string message)
	{
		if (busy)
		{
			return;
		}
		string path = LogPath;
		busy = true;
		try
		{
			StringBuilder sb = new StringBuilder();
			lock (gate)
			{
				if (!headerWritten)
				{
					headerWritten = true;
					sb.Append("\n========================================================\n");
					sb.Append("session start ").Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
					sb.Append("  pid=").Append(Process.GetCurrentProcess().Id);
					sb.Append("  64bit=").Append(Environment.Is64BitProcess);
					sb.Append("\nlog file: ").Append(path);
					sb.Append("\n========================================================\n");
				}
				sb.Append(DateTime.Now.ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture));
				sb.Append(" +").Append(clock.ElapsedMilliseconds.ToString(CultureInfo.InvariantCulture)).Append("ms");
				sb.Append(" [t").Append(Thread.CurrentThread.ManagedThreadId).Append("] ");
				sb.Append(tag).Append(": ").Append(message).Append("\n");
				File.AppendAllText(path, sb.ToString(), Encoding.UTF8);
			}
		}
		catch
		{
			// logging must never change program behaviour
		}
		finally
		{
			busy = false;
		}
	}
}
