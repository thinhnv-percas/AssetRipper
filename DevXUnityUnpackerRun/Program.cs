using System;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;

internal class Program
{
	[STAThread]
	private static void Main(string[] args)
	{
		InstallDebugHooks();
		DbgLog.W("RUN.start", "exe=" + Application.ExecutablePath + "  args=[" + string.Join(" ", args) + "]  cwd=" + Directory.GetCurrentDirectory());
		DbgLog.Probe("RUN.start", "StartupPath", Application.StartupPath);
		DbgLog.Probe("RUN.start", "DevXUnityUnpackerMain.exe", Path.Combine(Application.StartupPath, "DevXUnityUnpackerMain.exe"));
		try
		{
			// DevXUnityUnpackerMain is now a direct build reference instead of the XOR+GZip
			// "0000000000" payload Memrestore/DeCompess below decode — see ROADMAP.md P7a.
			// Those two methods are kept for reference; they document the original packer format.
			Assembly.LoadFrom(Path.Combine(Application.StartupPath, "DevXUnityUnpackerMain.exe")).EntryPoint.Invoke(null, null);
			DbgLog.W("RUN.exit", "Main returned normally");
		}
		catch (Exception ex)
		{
			DbgLog.Ex("RUN.startfail", "EntryPoint.Invoke threw", ex);
			MessageBox.Show("Error on start");
		}
	}

	// Debug tracing only — see DbgLog. FirstChanceException fires before any handler
	// runs, so it is the only way to see exceptions the obfuscated chain swallows
	// with an empty catch {} (ROADMAP.md P3 used the same trick).
	private static void InstallDebugHooks()
	{
		try
		{
			AppDomain.CurrentDomain.FirstChanceException += delegate(object s, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
			{
				DbgLog.Lim("FCE." + e.Exception.GetType().Name, e.Exception.Message + "\n" + e.Exception.StackTrace, 5);
			};
			AppDomain.CurrentDomain.UnhandledException += delegate(object s, UnhandledExceptionEventArgs e)
			{
				DbgLog.Ex("RUN.unhandled", "terminating=" + e.IsTerminating, e.ExceptionObject as Exception);
			};
			AppDomain.CurrentDomain.AssemblyResolve += delegate(object s, ResolveEventArgs e)
			{
				DbgLog.Lim("RUN.resolvefail", "could not resolve: " + e.Name, 40);
				return null;
			};
		}
		catch
		{
		}
	}

	internal static byte[] Memrestore(byte[] in_buff)
	{
		if (in_buff == null || in_buff.Length <= 1)
		{
			return null;
		}
		byte[] array = new byte[in_buff.Length];
		int num = 0;
		int num2 = 10;
		int num3 = 1;
		while (num < array.Length)
		{
			array[num] = (byte)(in_buff[num] ^ (byte)(num2 + num3));
			num++;
			num2 += 13;
			num3 += 1317;
		}
		Application.Exit();
		return DeCompess(array);
	}

	internal static byte[] DeCompess(byte[] buff)
	{
		using GZipStream input_stream = new GZipStream(new MemoryStream(buff), CompressionMode.Decompress);
		MemoryStream memoryStream = new MemoryStream();
		Copy(input_stream, memoryStream);
		buff = memoryStream.ToArray();
		return buff;
	}

	internal static void Copy(Stream input_stream, Stream out_stream, byte[] buffer = null)
	{
		if (buffer == null)
		{
			buffer = new byte[4096];
		}
		int num;
		do
		{
			num = input_stream.Read(buffer, 0, buffer.Length);
			out_stream.Write(buffer, 0, num);
		}
		while (num > 0);
	}

	static Program()
	{
	}
}
