using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class OpenCLDevice
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
			public static extern double OpenCLDevice_BenchmarkScore_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr OpenCLDevice_DeviceType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool OpenCLDevice_IsEnabled_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OpenCLDevice_IsEnabled_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_Name_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_Version_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_GetKernelProfileRecords(IntPtr Instance, out UIntPtr length);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_GetKernelProfileRecord(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OpenCLDevice_SetProfileKernels(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double OpenCLDevice_BenchmarkScore_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr OpenCLDevice_DeviceType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool OpenCLDevice_IsEnabled_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OpenCLDevice_IsEnabled_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_Name_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_Version_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_GetKernelProfileRecords(IntPtr Instance, out UIntPtr length);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr OpenCLDevice_GetKernelProfileRecord(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void OpenCLDevice_SetProfileKernels(IntPtr Instance, [MarshalAs(UnmanagedType.Bool)] bool value);
		}
	}

	private sealed class NativeOpenCLDevice : ConstNativeInstance
	{
		protected override string TypeName => "OpenCLDevice";

		public double BenchmarkScore
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLDevice_BenchmarkScore_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLDevice_BenchmarkScore_Get(base.Instance);
			}
		}

		public OpenCLDeviceType DeviceType
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.OpenCLDevice_DeviceType_Get(base.Instance) : NativeMethods.X64.OpenCLDevice_DeviceType_Get(base.Instance));
				return (OpenCLDeviceType)(uint)uIntPtr;
			}
		}

		public bool IsEnabled
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.OpenCLDevice_IsEnabled_Get(base.Instance);
				}
				return NativeMethods.X86.OpenCLDevice_IsEnabled_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.OpenCLDevice_IsEnabled_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.OpenCLDevice_IsEnabled_Set(base.Instance, value);
				}
			}
		}

		public string Name
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.OpenCLDevice_Name_Get(base.Instance) : NativeMethods.X64.OpenCLDevice_Name_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public string Version
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.OpenCLDevice_Version_Get(base.Instance) : NativeMethods.X64.OpenCLDevice_Version_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		static NativeOpenCLDevice()
		{
			Environment.Initialize();
		}

		public IntPtr GetKernelProfileRecords(out UIntPtr length)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.OpenCLDevice_GetKernelProfileRecords(base.Instance, out length);
			}
			return NativeMethods.X86.OpenCLDevice_GetKernelProfileRecords(base.Instance, out length);
		}

		public static IntPtr GetKernelProfileRecord(IntPtr list, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.OpenCLDevice_GetKernelProfileRecord(list, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.OpenCLDevice_GetKernelProfileRecord(list, (UIntPtr)(ulong)index);
		}

		public void SetProfileKernels(bool value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.OpenCLDevice_SetProfileKernels(base.Instance, value);
			}
			else
			{
				NativeMethods.X86.OpenCLDevice_SetProfileKernels(base.Instance, value);
			}
		}
	}

	private NativeOpenCLDevice _instance;

	private bool _profileKernels;

	public double BenchmarkScore => _instance.BenchmarkScore;

	public OpenCLDeviceType DeviceType => _instance.DeviceType;

	public string Name => _instance.Name;

	public bool IsEnabled
	{
		get
		{
			return _instance.IsEnabled;
		}
		set
		{
			_instance.IsEnabled = value;
		}
	}

	public IEnumerable<OpenCLKernelProfileRecord> KernelProfileRecords
	{
		get
		{
			IntPtr kernelProfileRecords = _instance.GetKernelProfileRecords(out var length);
			Collection<OpenCLKernelProfileRecord> collection = new Collection<OpenCLKernelProfileRecord>();
			if (kernelProfileRecords == IntPtr.Zero)
			{
				return collection;
			}
			for (int i = 0; i < (int)(uint)length; i++)
			{
				OpenCLKernelProfileRecord openCLKernelProfileRecord = OpenCLKernelProfileRecord.CreateInstance(NativeOpenCLDevice.GetKernelProfileRecord(kernelProfileRecords, i));
				if (openCLKernelProfileRecord != null)
				{
					collection.Add(openCLKernelProfileRecord);
				}
			}
			return collection;
		}
	}

	public bool ProfileKernels
	{
		get
		{
			return _profileKernels;
		}
		set
		{
			_instance.SetProfileKernels(value);
			_profileKernels = value;
		}
	}

	public string Version => _instance.Version;

	private OpenCLDevice(IntPtr instance)
	{
		_instance = new NativeOpenCLDevice();
		_instance.Instance = instance;
		_profileKernels = false;
	}

	internal static OpenCLDevice CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		return new OpenCLDevice(instance);
	}
}
