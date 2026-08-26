using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal static class MagickExceptionHelper
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
			public static extern IntPtr MagickExceptionHelper_Description(IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickExceptionHelper_Dispose(IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickExceptionHelper_Message(IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickExceptionHelper_Related(IntPtr exception, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickExceptionHelper_RelatedCount(IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickExceptionHelper_Severity(IntPtr exception);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickExceptionHelper_Description(IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickExceptionHelper_Dispose(IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickExceptionHelper_Message(IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickExceptionHelper_Related(IntPtr exception, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickExceptionHelper_RelatedCount(IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickExceptionHelper_Severity(IntPtr exception);
		}
	}

	private static class NativeMagickExceptionHelper
	{
		static NativeMagickExceptionHelper()
		{
			Environment.Initialize();
		}

		public static string Description(IntPtr exception)
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickExceptionHelper_Description(exception));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickExceptionHelper_Description(exception));
		}

		public static void Dispose(IntPtr exception)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickExceptionHelper_Dispose(exception);
			}
			else
			{
				NativeMethods.X86.MagickExceptionHelper_Dispose(exception);
			}
		}

		public static string Message(IntPtr exception)
		{
			if (NativeLibrary.Is64Bit)
			{
				return UTF8Marshaler.NativeToManaged(NativeMethods.X64.MagickExceptionHelper_Message(exception));
			}
			return UTF8Marshaler.NativeToManaged(NativeMethods.X86.MagickExceptionHelper_Message(exception));
		}

		public static IntPtr Related(IntPtr exception, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickExceptionHelper_Related(exception, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.MagickExceptionHelper_Related(exception, (UIntPtr)(ulong)index);
		}

		public static int RelatedCount(IntPtr exception)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.MagickExceptionHelper_RelatedCount(exception);
			}
			return (int)(uint)NativeMethods.X86.MagickExceptionHelper_RelatedCount(exception);
		}

		public static int Severity(IntPtr exception)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.MagickExceptionHelper_Severity(exception);
			}
			return (int)(uint)NativeMethods.X86.MagickExceptionHelper_Severity(exception);
		}
	}

	public static MagickException Check(IntPtr exception)
	{
		MagickException ex = Create(exception);
		if (IsError(ex))
		{
			throw ex;
		}
		return ex;
	}

	public static MagickException Create(IntPtr exception)
	{
		if (exception == IntPtr.Zero)
		{
			return null;
		}
		MagickException result = CreateException(exception);
		NativeMagickExceptionHelper.Dispose(exception);
		return result;
	}

	public static MagickException CreateException(IntPtr exception)
	{
		int severity = NativeMagickExceptionHelper.Severity(exception);
		string text = NativeMagickExceptionHelper.Message(exception);
		string text2 = NativeMagickExceptionHelper.Description(exception);
		if (!string.IsNullOrEmpty(text2))
		{
			text = text + " (" + text2 + ")";
		}
		List<MagickException> relatedException = CreateRelatedExceptions(exception);
		MagickException ex = Create((ExceptionSeverity)severity, text);
		ex.SetRelatedException(relatedException);
		return ex;
	}

	public static bool IsError(MagickException exception)
	{
		if (exception == null)
		{
			return false;
		}
		return exception is MagickErrorException;
	}

	private static List<MagickException> CreateRelatedExceptions(IntPtr exception)
	{
		int num = NativeMagickExceptionHelper.RelatedCount(exception);
		if (num == 0)
		{
			return null;
		}
		List<MagickException> list = new List<MagickException>();
		for (int i = 0; i < num; i++)
		{
			IntPtr exception2 = NativeMagickExceptionHelper.Related(exception, i);
			list.Add(CreateException(exception2));
		}
		return list;
	}

	private static MagickException Create(ExceptionSeverity severity, string message)
	{
		switch (severity)
		{
		case ExceptionSeverity.BlobWarning:
			return new MagickBlobWarningException(message);
		case ExceptionSeverity.CacheWarning:
			return new MagickCacheWarningException(message);
		case ExceptionSeverity.CoderWarning:
			return new MagickCoderWarningException(message);
		case ExceptionSeverity.ConfigureWarning:
			return new MagickConfigureWarningException(message);
		case ExceptionSeverity.CorruptImageWarning:
			return new MagickCorruptImageWarningException(message);
		case ExceptionSeverity.DelegateWarning:
			return new MagickDelegateWarningException(message);
		case ExceptionSeverity.DrawWarning:
			return new MagickDrawWarningException(message);
		case ExceptionSeverity.FileOpenWarning:
			return new MagickFileOpenWarningException(message);
		case ExceptionSeverity.ImageWarning:
			return new MagickImageWarningException(message);
		case ExceptionSeverity.MissingDelegateWarning:
			return new MagickMissingDelegateWarningException(message);
		case ExceptionSeverity.ModuleWarning:
			return new MagickModuleWarningException(message);
		case ExceptionSeverity.OptionWarning:
			return new MagickOptionWarningException(message);
		case ExceptionSeverity.PolicyWarning:
			return new MagickPolicyWarningException(message);
		case ExceptionSeverity.RegistryWarning:
			return new MagickRegistryWarningException(message);
		case ExceptionSeverity.Warning:
			return new MagickResourceLimitWarningException(message);
		case ExceptionSeverity.StreamWarning:
			return new MagickStreamWarningException(message);
		case ExceptionSeverity.TypeWarning:
			return new MagickTypeWarningException(message);
		case ExceptionSeverity.BlobError:
			return new MagickBlobErrorException(message);
		case ExceptionSeverity.CacheError:
			return new MagickCacheErrorException(message);
		case ExceptionSeverity.CoderError:
			return new MagickCoderErrorException(message);
		case ExceptionSeverity.ConfigureError:
			return new MagickConfigureErrorException(message);
		case ExceptionSeverity.CorruptImageError:
			return new MagickCorruptImageErrorException(message);
		case ExceptionSeverity.DelegateError:
			return new MagickDelegateErrorException(message);
		case ExceptionSeverity.DrawError:
			return new MagickDrawErrorException(message);
		case ExceptionSeverity.FileOpenError:
			return new MagickFileOpenErrorException(message);
		case ExceptionSeverity.ImageError:
			return new MagickImageErrorException(message);
		case ExceptionSeverity.MissingDelegateError:
			return new MagickMissingDelegateErrorException(message);
		case ExceptionSeverity.ModuleError:
			return new MagickModuleErrorException(message);
		case ExceptionSeverity.OptionError:
			return new MagickOptionErrorException(message);
		case ExceptionSeverity.PolicyError:
			return new MagickPolicyErrorException(message);
		case ExceptionSeverity.RegistryError:
			return new MagickRegistryErrorException(message);
		case ExceptionSeverity.Error:
			return new MagickResourceLimitErrorException(message);
		case ExceptionSeverity.StreamError:
			return new MagickStreamErrorException(message);
		case ExceptionSeverity.TypeError:
			return new MagickTypeErrorException(message);
		default:
			if (severity < ExceptionSeverity.Error)
			{
				return new MagickWarningException(message);
			}
			return new MagickErrorException(message);
		}
	}
}
