using System;
using System.Diagnostics;
using System.IO;

internal class crunch17Manager
{
	internal const string txt = "crunch_2017";

	internal static string path
	{
		get
		{
			string _0020 = FileManager.FormatPath(DevXSystemInfo.StreamingAssets, "Crunch2017", "Win");
			string text;
			if (Environment.Is64BitProcess)
			{
				text = FileManager.FormatPath(_0020, "crunch_2017_x64.exe");
				if (File.Exists(text))
				{
					return text;
				}
			}
			text = FileManager.FormatPath(_0020, "crunch_2017_x86.exe");
			if (File.Exists(text))
			{
				return text;
			}
			text = FileManager.FormatPath(_0020, "crunch_2017_x32.exe");
			if (File.Exists(text))
			{
				return text;
			}
			text = FileManager.FormatPath(_0020, "crunch_2017.exe");
			if (File.Exists(text))
			{
				return text;
			}
			return null;
		}
	}

	public static void Decode(byte[] inputBytes, out byte[] pngBytes)
	{
		pngBytes = null;
		try
		{
			if (!FileManager.Exists(path))
			{
				ConsoleManager.Write("crunch_2017 no find");
			}
			else
			{
				pngBytes = null;
				Process process = new Process();
				process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
				process.StartInfo.FileName = path;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.RedirectStandardOutput = true;
				string text = TempManager.MakeTempFileName(".crn");
				string text2 = TempManager.MakeTempFileName(".png");
				FileManager.Write(text, inputBytes);
				process.StartInfo.Arguments = " -file \"" + text + "\" -fileformat png -out \"" + text2 + "\"";
				process.Start();
				process.WaitForExit();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(text2))
				{
					byte[] buff = File.ReadAllBytes(text2);
					File.Delete(text2);
					ImageData imageData = new ImageData(buff);
					ImageData imageData2 = imageData.MakeMirroredData();
					imageData.Dispose();
					pngBytes = imageData2.ToPNG();
					imageData2.Dispose();
				}
				else
				{
					ConsoleManager.Write("convert failed");
				}
			}
		}
		catch (Exception _0020)
		{
			ConsoleManager.WriteEx45(_0020);
		}
	}
}
