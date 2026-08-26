using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public class PrimaryInfo : IEquatable<PrimaryInfo>
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
			public static extern IntPtr PrimaryInfo_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_X_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Y_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_Z_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Z_Set(IntPtr instance, double value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PrimaryInfo_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_X_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Y_Set(IntPtr instance, double value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double PrimaryInfo_Z_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PrimaryInfo_Z_Set(IntPtr instance, double value);
		}
	}

	private sealed class NativePrimaryInfo : NativeInstance
	{
		protected override string TypeName => "PrimaryInfo";

		public double X
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.PrimaryInfo_X_Get(base.Instance);
				}
				return NativeMethods.X86.PrimaryInfo_X_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.PrimaryInfo_X_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.PrimaryInfo_X_Set(base.Instance, value);
				}
			}
		}

		public double Y
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.PrimaryInfo_Y_Get(base.Instance);
				}
				return NativeMethods.X86.PrimaryInfo_Y_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.PrimaryInfo_Y_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.PrimaryInfo_Y_Set(base.Instance, value);
				}
			}
		}

		public double Z
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.PrimaryInfo_Z_Get(base.Instance);
				}
				return NativeMethods.X86.PrimaryInfo_Z_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.PrimaryInfo_Z_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.PrimaryInfo_Z_Set(base.Instance, value);
				}
			}
		}

		static NativePrimaryInfo()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PrimaryInfo_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.PrimaryInfo_Dispose(instance);
			}
		}

		public NativePrimaryInfo()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.PrimaryInfo_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.PrimaryInfo_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public NativePrimaryInfo(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public double X { get; private set; }

	public double Y { get; private set; }

	public double Z { get; private set; }

	internal static INativeInstance CreateInstance(PrimaryInfo instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	internal static PrimaryInfo CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		using NativePrimaryInfo instance2 = new NativePrimaryInfo(instance);
		return new PrimaryInfo(instance2);
	}

	public PrimaryInfo(double x, double y, double z)
	{
		X = x;
		Y = y;
		Z = z;
	}

	private PrimaryInfo(NativePrimaryInfo instance)
	{
		X = instance.X;
		Y = instance.Y;
		Z = instance.Z;
	}

	public bool Equals(PrimaryInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (X == other.X && Y == other.Y)
		{
			return Z == other.Z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
	}

	private INativeInstance CreateNativeInstance()
	{
		return new NativePrimaryInfo
		{
			X = X,
			Y = Y,
			Z = Z
		};
	}
}
