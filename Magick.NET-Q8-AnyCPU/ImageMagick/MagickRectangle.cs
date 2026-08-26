using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal sealed class MagickRectangle
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
			public static extern IntPtr MagickRectangle_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickRectangle_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_X_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickRectangle_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Y_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickRectangle_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Width_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickRectangle_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Height_Set(IntPtr instance, UIntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickRectangle_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickRectangle_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_X_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickRectangle_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Y_Set(IntPtr instance, IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickRectangle_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Width_Set(IntPtr instance, UIntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickRectangle_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickRectangle_Height_Set(IntPtr instance, UIntPtr value);
		}
	}

	private sealed class NativeMagickRectangle : NativeInstance
	{
		protected override string TypeName => "MagickRectangle";

		public int X
		{
			get
			{
				IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickRectangle_X_Get(base.Instance) : NativeMethods.X64.MagickRectangle_X_Get(base.Instance));
				return (int)intPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickRectangle_X_Set(base.Instance, (IntPtr)value);
				}
				else
				{
					NativeMethods.X86.MagickRectangle_X_Set(base.Instance, (IntPtr)value);
				}
			}
		}

		public int Y
		{
			get
			{
				IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickRectangle_Y_Get(base.Instance) : NativeMethods.X64.MagickRectangle_Y_Get(base.Instance));
				return (int)intPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickRectangle_Y_Set(base.Instance, (IntPtr)value);
				}
				else
				{
					NativeMethods.X86.MagickRectangle_Y_Set(base.Instance, (IntPtr)value);
				}
			}
		}

		public int Width
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickRectangle_Width_Get(base.Instance) : NativeMethods.X64.MagickRectangle_Width_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickRectangle_Width_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickRectangle_Width_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		public int Height
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickRectangle_Height_Get(base.Instance) : NativeMethods.X64.MagickRectangle_Height_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickRectangle_Height_Set(base.Instance, (UIntPtr)(ulong)value);
				}
				else
				{
					NativeMethods.X86.MagickRectangle_Height_Set(base.Instance, (UIntPtr)(ulong)value);
				}
			}
		}

		static NativeMagickRectangle()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickRectangle_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MagickRectangle_Dispose(instance);
			}
		}

		public NativeMagickRectangle()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MagickRectangle_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.MagickRectangle_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public NativeMagickRectangle(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public int Height { get; set; }

	public int Width { get; set; }

	public int X { get; set; }

	public int Y { get; set; }

	internal static INativeInstance CreateInstance(MagickRectangle instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	internal static MagickRectangle CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		using NativeMagickRectangle instance2 = new NativeMagickRectangle(instance);
		return new MagickRectangle(instance2);
	}

	public MagickRectangle(int x, int y, int width, int height)
	{
		X = x;
		Y = y;
		Width = width;
		Height = height;
	}

	private MagickRectangle(NativeMagickRectangle instance)
	{
		X = instance.X;
		Y = instance.Y;
		Width = instance.Width;
		Height = instance.Height;
	}

	public static MagickRectangle FromGeometry(MagickGeometry geometry, MagickImage image)
	{
		if (geometry == null)
		{
			return null;
		}
		int width = geometry.Width;
		int height = geometry.Height;
		if (geometry.IsPercentage)
		{
			width = image.Width * new Percentage(geometry.Width);
			height = image.Height * new Percentage(geometry.Height);
		}
		return new MagickRectangle(geometry.X, geometry.Y, width, height);
	}

	internal static INativeInstance CreateInstance()
	{
		return new NativeMagickRectangle();
	}

	internal static MagickRectangle CreateInstance(INativeInstance nativeInstance)
	{
		return new MagickRectangle((nativeInstance as NativeMagickRectangle) ?? throw new InvalidOperationException());
	}

	private NativeMagickRectangle CreateNativeInstance()
	{
		return new NativeMagickRectangle
		{
			X = X,
			Y = Y,
			Width = Width,
			Height = Height
		};
	}
}
