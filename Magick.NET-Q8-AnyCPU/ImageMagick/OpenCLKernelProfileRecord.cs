using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class OpenCLKernelProfileRecord
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
			public static extern long OpenCLKernelProfileRecord_Count_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_MaximumDuration_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_MinimumDuration_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLKernelProfileRecord_Name_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_TotalDuration_Get(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_Count_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_MaximumDuration_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_MinimumDuration_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLKernelProfileRecord_Name_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern long OpenCLKernelProfileRecord_TotalDuration_Get(IntPtr instance);
		}
	}

	private sealed class NativeOpenCLKernelProfileRecord : ConstNativeInstance
	{
		protected override string TypeName => "OpenCLKernelProfileRecord";

		public long Count
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLKernelProfileRecord_Count_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLKernelProfileRecord_Count_Get(base.Instance);
			}
		}

		public long MaximumDuration
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLKernelProfileRecord_MaximumDuration_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLKernelProfileRecord_MaximumDuration_Get(base.Instance);
			}
		}

		public long MinimumDuration
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLKernelProfileRecord_MinimumDuration_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLKernelProfileRecord_MinimumDuration_Get(base.Instance);
			}
		}

		public string Name
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.OpenCLKernelProfileRecord_Name_Get(base.Instance) : NativeMethods.X64.OpenCLKernelProfileRecord_Name_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public long TotalDuration
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLKernelProfileRecord_TotalDuration_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLKernelProfileRecord_TotalDuration_Get(base.Instance);
			}
		}

		static NativeOpenCLKernelProfileRecord()
		{
			Environment.Initialize();
		}
	}

	public long AverageDuration
	{
		get
		{
			if (Count == 0L)
			{
				return 0L;
			}
			return TotalDuration / Count;
		}
	}

	public long Count { get; private set; }

	public long MaximumDuration { get; private set; }

	public long MinimumDuration { get; private set; }

	public string Name { get; private set; }

	public long TotalDuration { get; private set; }

	private OpenCLKernelProfileRecord(NativeOpenCLKernelProfileRecord instance)
	{
		Name = instance.Name;
		Count = instance.Count;
		MaximumDuration = instance.MaximumDuration;
		MinimumDuration = instance.MinimumDuration;
		TotalDuration = instance.TotalDuration;
	}

	internal static OpenCLKernelProfileRecord CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		return new OpenCLKernelProfileRecord(new NativeOpenCLKernelProfileRecord
		{
			Instance = instance
		});
	}
}
