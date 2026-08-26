using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace McMaster.Extensions.CommandLineUtils;

public static class DebugHelper
{
	public static void HandleDebugSwitch(ref string[] args)
	{
		HandleDebugSwitch(ref args, 30);
	}

	public static void HandleDebugSwitch(ref string[] args, int maxWaitSeconds)
	{
		if (args.Length == 0 || !string.Equals("--debug", args[0], StringComparison.OrdinalIgnoreCase))
		{
			return;
		}
		args = args.Skip(1).ToArray();
		if (!Debugger.IsAttached)
		{
			Console.WriteLine("Waiting for debugger to attach.");
			Console.WriteLine($"Process ID: {Process.GetCurrentProcess().Id}");
			int num = maxWaitSeconds * 1000 / 250;
			while (!Debugger.IsAttached && (num > 0 || maxWaitSeconds <= 0))
			{
				num--;
				Thread.Sleep(TimeSpan.FromMilliseconds(250.0));
			}
			if (!Debugger.IsAttached)
			{
				Console.WriteLine($"Timed out waiting for {maxWaitSeconds} seconds for debugger to attach. Continuing execution.");
			}
		}
	}
}
