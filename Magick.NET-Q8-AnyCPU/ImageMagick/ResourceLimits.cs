using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public static class ResourceLimits
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
			public static extern ulong ResourceLimits_Disk_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Disk_Set(ulong value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Height_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Height_Set(ulong value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Memory_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Memory_Set(ulong value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Throttle_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Throttle_Set(ulong value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Width_Get();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Width_Set(ulong value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Disk_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Disk_Set(ulong value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Height_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Height_Set(ulong value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Memory_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Memory_Set(ulong value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Throttle_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Throttle_Set(ulong value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong ResourceLimits_Width_Get();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ResourceLimits_Width_Set(ulong value);
		}
	}

	private static class NativeResourceLimits
	{
		public static ulong Disk
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ResourceLimits_Disk_Get();
				}
				return NativeMethods.X86.ResourceLimits_Disk_Get();
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.ResourceLimits_Disk_Set(value);
				}
				else
				{
					NativeMethods.X86.ResourceLimits_Disk_Set(value);
				}
			}
		}

		public static ulong Height
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ResourceLimits_Height_Get();
				}
				return NativeMethods.X86.ResourceLimits_Height_Get();
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.ResourceLimits_Height_Set(value);
				}
				else
				{
					NativeMethods.X86.ResourceLimits_Height_Set(value);
				}
			}
		}

		public static ulong Memory
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ResourceLimits_Memory_Get();
				}
				return NativeMethods.X86.ResourceLimits_Memory_Get();
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.ResourceLimits_Memory_Set(value);
				}
				else
				{
					NativeMethods.X86.ResourceLimits_Memory_Set(value);
				}
			}
		}

		public static ulong Throttle
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ResourceLimits_Throttle_Get();
				}
				return NativeMethods.X86.ResourceLimits_Throttle_Get();
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.ResourceLimits_Throttle_Set(value);
				}
				else
				{
					NativeMethods.X86.ResourceLimits_Throttle_Set(value);
				}
			}
		}

		public static ulong Width
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ResourceLimits_Width_Get();
				}
				return NativeMethods.X86.ResourceLimits_Width_Get();
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.ResourceLimits_Width_Set(value);
				}
				else
				{
					NativeMethods.X86.ResourceLimits_Width_Set(value);
				}
			}
		}

		static NativeResourceLimits()
		{
			Environment.Initialize();
		}
	}

	[CLSCompliant(false)]
	public static ulong Disk
	{
		get
		{
			return NativeResourceLimits.Disk;
		}
		set
		{
			NativeResourceLimits.Disk = value;
		}
	}

	[CLSCompliant(false)]
	public static ulong Height
	{
		get
		{
			return NativeResourceLimits.Height;
		}
		set
		{
			NativeResourceLimits.Height = value;
		}
	}

	[CLSCompliant(false)]
	public static ulong Memory
	{
		get
		{
			return NativeResourceLimits.Memory;
		}
		set
		{
			NativeResourceLimits.Memory = value;
		}
	}

	[CLSCompliant(false)]
	public static ulong Throttle
	{
		get
		{
			return NativeResourceLimits.Throttle;
		}
		set
		{
			NativeResourceLimits.Throttle = value;
		}
	}

	[CLSCompliant(false)]
	public static ulong Width
	{
		get
		{
			return NativeResourceLimits.Width;
		}
		set
		{
			NativeResourceLimits.Width = value;
		}
	}
}
