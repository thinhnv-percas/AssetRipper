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
		try
		{
			// DevXUnityUnpackerMain is now a direct build reference instead of the XOR+GZip
			// "0000000000" payload Memrestore/DeCompess below decode — see ROADMAP.md P7a.
			// Those two methods are kept for reference; they document the original packer format.
			Assembly.LoadFrom(Path.Combine(Application.StartupPath, "DevXUnityUnpackerMain.exe")).EntryPoint.Invoke(null, null);
		}
		catch (Exception)
		{
			MessageBox.Show("Error on start");
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
