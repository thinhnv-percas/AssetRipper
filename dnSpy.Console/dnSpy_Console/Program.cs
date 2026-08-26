using System;
using System.Text;
using dnlib;

namespace dnSpy_Console;

internal static class Program
{
	private static int Main(string[] args)
	{
		if (!Settings.IsThreadSafe)
		{
			Console.WriteLine("dnlib wasn't compiled with THREAD_SAFE defined");
			return 1;
		}
		Encoding outputEncoding = Console.OutputEncoding;
		try
		{
			Console.OutputEncoding = Encoding.UTF8;
			return new DnSpyDecompiler().Run(args);
		}
		catch (Exception ex)
		{
			Console.Error.WriteLine(ex.ToString());
			return 1;
		}
		finally
		{
			Console.OutputEncoding = outputEncoding;
		}
	}
}
