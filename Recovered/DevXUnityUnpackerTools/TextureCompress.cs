using @as;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

internal class TextureCompress
{
	private const string astcencTxt = "astcenc";

	private const int num = 1554098963;

	private static string astcencPath
	{
		get
		{
			string path = FileManager.FormatPath(DevXSystemInfo.StreamingAssets, "astcenc", "Win");
			string text;
			if (Environment.Is64BitProcess)
			{
				text = Path.Combine(path, "astcenc_x64.exe");
				if (File.Exists(text))
				{
					return text;
				}
			}
			text = Path.Combine(path, "astcenc_x86.exe");
			if (File.Exists(text))
			{
				return text;
			}
			text = Path.Combine(path, "astcenc_x32.exe");
			if (File.Exists(text))
			{
				return text;
			}
			text = Path.Combine(path, "astcenc.exe");
			if (File.Exists(text))
			{
				return text;
			}
			return null;
		}
	}

	public static void EncodeASTC(byte[] argb_inputBytes, int width, int height, int block_xsize, int block_ysize, out byte[] dstBytes)
	{
		dstBytes = null;
		try
		{
			if (!FileManager.Exists(astcencPath))
			{
				ConsoleManager.Info.Write("astcenc no find");
			}
			else
			{
				for (int i = 0; i < argb_inputBytes.Length / 4; i++)
				{
					byte b = argb_inputBytes[i * 4];
					argb_inputBytes[i * 4] = argb_inputBytes[i * 4 + 2];
					argb_inputBytes[i * 4 + 2] = b;
				}
				dstBytes = null;
				string text = TempManager.MakeTempFileName(".astc");
				string text2 = TempManager.MakeTempFileName(".png");
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				ARGB_RAW aRGB_RAW = new ARGB_RAW(width, height, argb_inputBytes);
				aRGB_RAW.ToRGBA();
				ImageData imageData = new ImageData(aRGB_RAW);
				FileManager.Write(text2, imageData.ToPNG());
				imageData.Dispose();
				if (File.Exists(text2))
				{
					Process process = new Process();
					process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
					process.StartInfo.FileName = astcencPath;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.RedirectStandardError = true;
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.Arguments = string.Format(Environment.Is64BitProcess ? "-cl \"{0}\" \"{1}\" {2}x{3}x1 -medium -2partitionlimitfactor 1.2 -yflip -refinementlimit 2 -2planelimitcorrelation 0.75 -blockmodelimit 75" : "-c \"{0}\" \"{1}\" {2}x{3} -medium", text2, text, block_xsize, block_ysize);
					process.Start();
					process.WaitForExit();
				}
				if (File.Exists(text))
				{
					using (FileStream fileStream = File.Open(text, FileMode.Open))
					{
						dstBytes = new byte[(int)fileStream.Length - 16];
						fileStream.Seek(16L, SeekOrigin.Begin);
						fileStream.Read(dstBytes, 0, (int)fileStream.Length - 16);
					}
				}
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
			}
		}
		catch (Exception ex)
		{
			string str = "ASTC: ";
			ConsoleManager.LogExeption(str + ex?.ToString());
		}
	}

	public static void DecodeASTC(byte[] raw_text_inputBytes, int width, int height, int block_xsize, int block_ysize, out byte[] dstBytes)
	{
		dstBytes = null;
		try
		{
			if (astcencPath != null && FileManager.Exists(astcencPath))
			{
				string text = TempManager.MakeTempFileName(".astc");
				string text2 = TempManager.MakeTempFileName(".tga");
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
				dstBytes = null;
				CreateTempFile(raw_text_inputBytes, width, height, block_xsize, block_ysize, text);
				if (File.Exists(text))
				{
					Process process = new Process();
					process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
					process.StartInfo.FileName = astcencPath;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					process.StartInfo.Arguments = $"-dl \"{text}\" \"{text2}\"";
					process.Start();
					process.WaitForExit();
				}
				if (File.Exists(text2))
				{
					try
					{
						Type type = Assembly.LoadFile(FileManager.FormatPath(DevXSystemInfo.StreamingAssets, "Magick.NET", "Magick.NET-Q8-AnyCPU.dll"))?.GetType("ImageMagick.MagickImage", throwOnError: false);
						if (type != null)
						{
							object obj = Activator.CreateInstance(type, text2);
							type.GetMethod("Flip").Invoke(obj, null);
							object obj2 = type.GetMethod("GetPixels").Invoke(obj, null);
							MethodInfo methodInfo = null;
							MethodInfo[] methods = obj2.GetType().GetMethods();
							foreach (MethodInfo methodInfo2 in methods)
							{
								if (methodInfo2.Name == "ToByteArray" && methodInfo2.GetParameters().Length == 5)
								{
									methodInfo = methodInfo2;
									break;
								}
							}
							dstBytes = (byte[])methodInfo.Invoke(obj2, new object[5]
							{
								0,
								0,
								width,
								height,
								"RGBA"
							});
							if (dstBytes != null)
							{
								for (int j = 0; j < dstBytes.Length / 4; j++)
								{
									ARGB_RAW.SwapByte(dstBytes, j * 4);
								}
							}
						}
					}
					catch (Exception _0020)
					{
						ConsoleManager.WriteEx45(_0020);
					}
				}
				else
				{
					ConsoleManager.WriteInfo("ERR: astcenc.exe encoding error");
				}
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
			}
		}
		catch (Exception arg)
		{
			ConsoleOver.LogEx(string.Concat(arg));
		}
	}

	private static void CreateTempFile(byte[] raw_text_inputBytes, int width, int height, int block_xsize, int block_ysize, string path)
	{
		using (FileStream fileStream = File.Create(path))
		{
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write(1554098963);
				binaryWriter.Write(block_xsize + block_ysize * 256 + 65536);
				binaryWriter.Seek(-1, SeekOrigin.Current);
				binaryWriter.Write(width);
				binaryWriter.Seek(-1, SeekOrigin.Current);
				binaryWriter.Write(height);
				binaryWriter.Seek(-1, SeekOrigin.Current);
				binaryWriter.Write(1);
				binaryWriter.Seek(-1, SeekOrigin.Current);
				binaryWriter.Write(raw_text_inputBytes);
			}
			fileStream.Close();
		}
	}
}
