using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using ImageMagick.Configuration;

namespace ImageMagick;

public static class MagickNET
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate void LogDelegate(UIntPtr type, IntPtr value);

	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_Features_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_GetFontFamilies(out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_GetFontFamily(IntPtr instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_DisposeFontFamilies(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetLogDelegate(LogDelegate method);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetLogEvents(IntPtr events);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetRandomSeed(long value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_Features_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_GetFontFamilies(out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickNET_GetFontFamily(IntPtr instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_DisposeFontFamilies(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetLogDelegate(LogDelegate method);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetLogEvents(IntPtr events);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickNET_SetRandomSeed(long value);
		}
	}

	private static class NativeMagickNET
	{
		public static string Features
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickNET_Features_Get() : NativeMethods.X64.MagickNET_Features_Get());
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		static NativeMagickNET()
		{
			Environment.Initialize();
		}

		public static IntPtr GetFontFamilies(out UIntPtr length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickNET_GetFontFamilies(out length, out exception) : NativeMethods.X64.MagickNET_GetFontFamilies(out length, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					DisposeFontFamilies(intPtr);
				}
				throw ex;
			}
			return intPtr;
		}

		public static string GetFontFamily(IntPtr instance, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickNET_GetFontFamily(instance, (UIntPtr)(ulong)index));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickNET_GetFontFamily(instance, (UIntPtr)(ulong)index));
		}

		public static void DisposeFontFamilies(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickNET_DisposeFontFamilies(instance);
			}
			else
			{
				NativeMethods.X86.MagickNET_DisposeFontFamilies(instance);
			}
		}

		public static void SetLogDelegate(LogDelegate method)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickNET_SetLogDelegate(method);
			}
			else
			{
				NativeMethods.X86.MagickNET_SetLogDelegate(method);
			}
		}

		public static void SetLogEvents(string events)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(events);
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickNET_SetLogEvents(nativeInstance.Instance);
			}
			else
			{
				NativeMethods.X86.MagickNET_SetLogEvents(nativeInstance.Instance);
			}
		}

		public static void SetRandomSeed(long value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickNET_SetRandomSeed(value);
			}
			else
			{
				NativeMethods.X86.MagickNET_SetRandomSeed(value);
			}
		}
	}

	private static LogDelegate _nativeLog;

	private static EventHandler<LogEventArgs> _log;

	private static LogEvents _logEvents;

	public static string Features => NativeMagickNET.Features;

	public static IEnumerable<MagickFormatInfo> SupportedFormats => MagickFormatInfo.All;

	public static IEnumerable<string> FontFamilies
	{
		get
		{
			List<string> list = new List<string>();
			IntPtr intPtr = IntPtr.Zero;
			UIntPtr length = (UIntPtr)0uL;
			try
			{
				intPtr = NativeMagickNET.GetFontFamilies(out length);
				for (int i = 0; i < (int)(uint)length; i++)
				{
					string fontFamily = NativeMagickNET.GetFontFamily(intPtr, i);
					if (!string.IsNullOrEmpty(fontFamily))
					{
						list.Add(fontFamily);
					}
				}
				return list;
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					NativeMagickNET.DisposeFontFamilies(intPtr);
				}
			}
		}
	}

	public static string Version
	{
		get
		{
			AssemblyTitleAttribute customAttribute = TypeHelper.GetCustomAttribute<AssemblyTitleAttribute>(typeof(MagickNET));
			return string.Concat(str2: TypeHelper.GetCustomAttribute<AssemblyFileVersionAttribute>(typeof(MagickNET)).Version, str0: customAttribute.Title, str1: " ");
		}
	}

	public static event EventHandler<LogEventArgs> Log
	{
		add
		{
			if (_log == null)
			{
				_nativeLog = OnLog;
				NativeMagickNET.SetLogDelegate(_nativeLog);
				SetLogEvents();
			}
			_log = (EventHandler<LogEventArgs>)Delegate.Combine(_log, value);
		}
		remove
		{
			_log = (EventHandler<LogEventArgs>)Delegate.Remove(_log, value);
			if (_log == null)
			{
				NativeMagickNET.SetLogDelegate(null);
				NativeMagickNET.SetLogEvents("None");
				_nativeLog = null;
			}
		}
	}

	public static MagickFormatInfo GetFormatInformation(FileInfo file)
	{
		return MagickFormatInfo.Create(file);
	}

	public static MagickFormatInfo GetFormatInformation(MagickFormat format)
	{
		return MagickFormatInfo.Create(format);
	}

	public static MagickFormatInfo GetFormatInformation(string fileName)
	{
		return MagickFormatInfo.Create(fileName);
	}

	public static void Initialize(string path)
	{
		CheckImageMagickFiles(FileHelper.GetFullPath(path));
		Environment.SetEnv("MAGICK_CONFIGURE_PATH", path);
	}

	public static string Initialize(ConfigurationFiles configFiles)
	{
		Throw.IfNull("configFiles", configFiles);
		string text = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
		Directory.CreateDirectory(text);
		InitializePrivate(configFiles, text);
		return text;
	}

	public static void Initialize(ConfigurationFiles configFiles, string path)
	{
		Throw.IfNull("configFiles", configFiles);
		string fullPath = FileHelper.GetFullPath(path);
		InitializePrivate(configFiles, fullPath);
	}

	public static void SetLogEvents(LogEvents events)
	{
		_logEvents = events;
		if (_log != null)
		{
			SetLogEvents();
		}
	}

	public static void SetGhostscriptDirectory(string path)
	{
		Environment.SetEnv("MAGICK_GHOSTSCRIPT_PATH", FileHelper.GetFullPath(path));
	}

	public static void SetGhostscriptFontDirectory(string path)
	{
		Environment.SetEnv("MAGICK_GHOSTSCRIPT_FONT_PATH", FileHelper.GetFullPath(path));
	}

	public static void SetTempDirectory(string path)
	{
		Environment.SetEnv("MAGICK_TEMPORARY_PATH", FileHelper.GetFullPath(path));
	}

	public static void SetRandomSeed(int seed)
	{
		NativeMagickNET.SetRandomSeed(seed);
	}

	private static void CheckImageMagickFiles(string path)
	{
		foreach (IConfigurationFile file in ConfigurationFiles.Default.Files)
		{
			string text = Path.Combine(path, file.FileName);
			Throw.IfFalse("path", File.Exists(text), "Unable to find file: {0}", text);
		}
	}

	private static void InitializePrivate(ConfigurationFiles configFiles, string newPath)
	{
		configFiles.WriteInDirectory(newPath);
		Environment.SetEnv("MAGICK_CONFIGURE_PATH", newPath);
	}

	private static void OnLog(UIntPtr type, IntPtr text)
	{
		if (_log != null)
		{
			string message = UTF8Marshaler.NativeToManaged(text);
			_log(null, new LogEventArgs((LogEvents)(uint)type, message));
		}
	}

	private static void SetLogEvents()
	{
		string text = null;
		text = ((!EnumHelper.HasFlag(_logEvents, LogEvents.All)) ? EnumHelper.ConvertFlags(_logEvents) : ((!EnumHelper.HasFlag(_logEvents, LogEvents.Trace)) ? "All" : "All,Trace"));
		NativeMagickNET.SetLogEvents(text);
	}
}
