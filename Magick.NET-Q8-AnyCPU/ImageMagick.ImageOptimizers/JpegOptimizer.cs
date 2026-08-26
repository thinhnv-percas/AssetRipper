using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageMagick.ImageOptimizers;

public sealed class JpegOptimizer : IImageOptimizer
{
	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr JpegOptimizer_Compress(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr JpegOptimizer_Compress(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality);
		}
	}

	private static class NativeJpegOptimizer
	{
		static NativeJpegOptimizer()
		{
			Environment.Initialize();
		}

		public static int Compress(string input, string output, bool progressive, bool lossless, int quality)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(input);
			using INativeInstance nativeInstance2 = UTF8Marshaler.CreateInstance(output);
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.JpegOptimizer_Compress(nativeInstance.Instance, nativeInstance2.Instance, progressive, lossless, (UIntPtr)(ulong)quality);
			}
			return (int)(uint)NativeMethods.X86.JpegOptimizer_Compress(nativeInstance.Instance, nativeInstance2.Instance, progressive, lossless, (UIntPtr)(ulong)quality);
		}
	}

	public MagickFormatInfo Format => MagickNET.GetFormatInformation(MagickFormat.Jpeg);

	public bool OptimalCompression { get; set; }

	public bool Progressive { get; set; }

	public JpegOptimizer()
	{
		Progressive = true;
	}

	public bool Compress(FileInfo file)
	{
		return Compress(file, 0);
	}

	public bool Compress(FileInfo file, int quality)
	{
		Throw.IfNull("file", file);
		return DoCompress(file, lossless: false, quality);
	}

	public bool Compress(string fileName)
	{
		return Compress(fileName, 0);
	}

	public bool Compress(string fileName, int quality)
	{
		string value = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", value);
		return DoCompress(new FileInfo(fileName), lossless: false, quality);
	}

	public bool LosslessCompress(FileInfo file)
	{
		Throw.IfNull("file", file);
		return DoCompress(file, lossless: true, 0);
	}

	public bool LosslessCompress(string fileName)
	{
		string value = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", value);
		return DoCompress(new FileInfo(fileName), lossless: true, 0);
	}

	private static bool DoCompress(FileInfo file, FileInfo output, bool progressive, bool lossless, int quality)
	{
		switch (NativeJpegOptimizer.Compress(file.FullName, output.FullName, progressive, lossless, quality))
		{
		case 1:
			throw new MagickCorruptImageErrorException("Unable to decompress the jpeg file.");
		case 2:
			throw new MagickCorruptImageErrorException("Unable to compress the jpeg file.");
		default:
			return false;
		case 0:
			output.Refresh();
			return true;
		}
	}

	private bool DoCompress(FileInfo file, bool lossless, int quality)
	{
		using TemporaryFile temporaryFile = new TemporaryFile();
		if (!DoCompress(file, temporaryFile, Progressive, lossless, quality))
		{
			return false;
		}
		if (OptimalCompression)
		{
			using TemporaryFile temporaryFile2 = new TemporaryFile();
			if (!DoCompress(file, temporaryFile2, Progressive, lossless, quality))
			{
				return false;
			}
			if (temporaryFile2.Length < file.Length && temporaryFile2.Length < temporaryFile.Length)
			{
				temporaryFile2.CopyTo(file);
				return false;
			}
		}
		if (temporaryFile.Length >= file.Length)
		{
			return false;
		}
		temporaryFile.CopyTo(file);
		return true;
	}
}
