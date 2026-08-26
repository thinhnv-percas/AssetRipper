using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class MagickGeometry
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
			public static extern IntPtr MagickGeometry_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickGeometry_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickGeometry_Initialize(IntPtr Instance, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickGeometry_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickGeometry_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_X_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Y_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Width_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double MagickGeometry_Height_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr MagickGeometry_Initialize(IntPtr Instance, IntPtr value);
		}
	}

	private sealed class NativeMagickGeometry : NativeInstance
	{
		protected override string TypeName => "MagickGeometry";

		public double X
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickGeometry_X_Get(base.Instance);
				}
				return NativeMethods.X86.MagickGeometry_X_Get(base.Instance);
			}
		}

		public double Y
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickGeometry_Y_Get(base.Instance);
				}
				return NativeMethods.X86.MagickGeometry_Y_Get(base.Instance);
			}
		}

		public double Width
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickGeometry_Width_Get(base.Instance);
				}
				return NativeMethods.X86.MagickGeometry_Width_Get(base.Instance);
			}
		}

		public double Height
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickGeometry_Height_Get(base.Instance);
				}
				return NativeMethods.X86.MagickGeometry_Height_Get(base.Instance);
			}
		}

		static NativeMagickGeometry()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickGeometry_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MagickGeometry_Dispose(instance);
			}
		}

		public NativeMagickGeometry()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MagickGeometry_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.MagickGeometry_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public NativeMagickGeometry(IntPtr instance)
		{
			base.Instance = instance;
		}

		public GeometryFlags Initialize(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				return (GeometryFlags)(uint)NativeMethods.X64.MagickGeometry_Initialize(base.Instance, nativeInstance.Instance);
			}
			return (GeometryFlags)(uint)NativeMethods.X86.MagickGeometry_Initialize(base.Instance, nativeInstance.Instance);
		}
	}

	public bool FillArea { get; set; }

	public bool Greater { get; set; }

	public int Height { get; set; }

	public bool IgnoreAspectRatio { get; set; }

	public bool IsPercentage { get; set; }

	public bool Less { get; set; }

	public bool LimitPixels { get; set; }

	public int Width { get; set; }

	public int X { get; set; }

	public int Y { get; set; }

	public MagickGeometry(Rectangle rectangle)
	{
		Initialize(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, isPercentage: false);
	}

	public static explicit operator MagickGeometry(Rectangle rectangle)
	{
		return new MagickGeometry(rectangle);
	}

	internal static MagickGeometry CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		using NativeMagickGeometry instance2 = new NativeMagickGeometry(instance);
		return new MagickGeometry(instance2);
	}

	public MagickGeometry()
	{
		Initialize(0, 0, 0, 0, isPercentage: false);
	}

	public MagickGeometry(int widthAndHeight)
	{
		Initialize(0, 0, widthAndHeight, widthAndHeight, isPercentage: false);
	}

	public MagickGeometry(int width, int height)
	{
		Initialize(0, 0, width, height, isPercentage: false);
	}

	public MagickGeometry(int x, int y, int width, int height)
	{
		Initialize(x, y, width, height, isPercentage: false);
	}

	public MagickGeometry(Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		Initialize(0, 0, (int)percentageWidth, (int)percentageHeight, isPercentage: true);
	}

	public MagickGeometry(int x, int y, Percentage percentageWidth, Percentage percentageHeight)
	{
		Throw.IfNegative("percentageWidth", percentageWidth);
		Throw.IfNegative("percentageHeight", percentageHeight);
		Initialize(x, y, (int)percentageWidth, (int)percentageHeight, isPercentage: true);
	}

	public MagickGeometry(string value)
	{
		Throw.IfNullOrEmpty("value", value);
		using NativeMagickGeometry nativeMagickGeometry = new NativeMagickGeometry();
		GeometryFlags flags = nativeMagickGeometry.Initialize(value);
		Initialize(nativeMagickGeometry, flags);
	}

	private MagickGeometry(NativeMagickGeometry instance)
	{
		Initialize(instance);
	}

	public static explicit operator MagickGeometry(string value)
	{
		return new MagickGeometry(value);
	}

	public static bool operator ==(MagickGeometry left, MagickGeometry right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(MagickGeometry left, MagickGeometry right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(MagickGeometry left, MagickGeometry right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(MagickGeometry left, MagickGeometry right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(MagickGeometry left, MagickGeometry right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(MagickGeometry left, MagickGeometry right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public int CompareTo(MagickGeometry other)
	{
		if ((object)other == null)
		{
			return 1;
		}
		int num = Width * Height;
		int num2 = other.Width * other.Height;
		if (num == num2)
		{
			return 0;
		}
		if (num >= num2)
		{
			return 1;
		}
		return -1;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as MagickGeometry);
	}

	public bool Equals(MagickGeometry other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Width == other.Width && Height == other.Height && X == other.X && Y == other.Y && IsPercentage == other.IsPercentage && IgnoreAspectRatio == other.IgnoreAspectRatio && Less == other.Less && Greater == other.Greater && FillArea == other.FillArea)
		{
			return LimitPixels == other.LimitPixels;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Width.GetHashCode() ^ Height.GetHashCode() ^ X.GetHashCode() ^ Y.GetHashCode() ^ IsPercentage.GetHashCode() ^ IgnoreAspectRatio.GetHashCode() ^ Less.GetHashCode() ^ Greater.GetHashCode() ^ FillArea.GetHashCode() ^ LimitPixels.GetHashCode();
	}

	public PointD ToPoint()
	{
		return new PointD(X, Y);
	}

	public override string ToString()
	{
		string text = null;
		if (Width > 0)
		{
			text += Width;
		}
		if (Height > 0)
		{
			text = text + "x" + Height;
		}
		if (X != 0 || Y != 0)
		{
			if (X >= 0)
			{
				text += "+";
			}
			text += X;
			if (Y >= 0)
			{
				text += "+";
			}
			text += Y;
		}
		if (IsPercentage)
		{
			text += "%";
		}
		if (IgnoreAspectRatio)
		{
			text += "!";
		}
		if (Greater)
		{
			text += ">";
		}
		if (Less)
		{
			text += "<";
		}
		if (FillArea)
		{
			text += "^";
		}
		if (LimitPixels)
		{
			text += "@";
		}
		return text;
	}

	internal static MagickGeometry Clone(MagickGeometry value)
	{
		if (value == null)
		{
			return null;
		}
		return new MagickGeometry
		{
			FillArea = value.FillArea,
			Greater = value.Greater,
			Height = value.Height,
			IgnoreAspectRatio = value.IgnoreAspectRatio,
			IsPercentage = value.IsPercentage,
			Less = value.Less,
			LimitPixels = value.LimitPixels,
			Width = value.Width,
			X = value.X,
			Y = value.Y
		};
	}

	internal static MagickGeometry FromRectangle(MagickRectangle rectangle)
	{
		if (rectangle == null)
		{
			return null;
		}
		return new MagickGeometry(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
	}

	internal static MagickGeometry FromString(string value)
	{
		if (value != null)
		{
			return new MagickGeometry(value);
		}
		return null;
	}

	internal static string ToString(MagickGeometry value)
	{
		return value?.ToString();
	}

	private NativeMagickGeometry CreateNativeInstance()
	{
		NativeMagickGeometry nativeMagickGeometry = new NativeMagickGeometry();
		nativeMagickGeometry.Initialize(ToString());
		return nativeMagickGeometry;
	}

	private void Initialize(int x, int y, int width, int height, bool isPercentage)
	{
		X = x;
		Y = y;
		Width = width;
		Height = height;
		IsPercentage = isPercentage;
	}

	private void Initialize(NativeMagickGeometry instance)
	{
		X = (int)instance.X;
		Y = (int)instance.Y;
		Width = (int)instance.Width;
		Height = (int)instance.Height;
	}

	private void Initialize(NativeMagickGeometry instance, GeometryFlags flags)
	{
		Throw.IfTrue("flags", flags == GeometryFlags.NoValue, "Invalid geometry specified.");
		Initialize(instance);
		IsPercentage = EnumHelper.HasFlag(flags, GeometryFlags.PercentValue);
		IgnoreAspectRatio = EnumHelper.HasFlag(flags, GeometryFlags.IgnoreAspectRatio);
		FillArea = EnumHelper.HasFlag(flags, GeometryFlags.FillArea);
		Greater = EnumHelper.HasFlag(flags, GeometryFlags.Greater);
		Less = EnumHelper.HasFlag(flags, GeometryFlags.Less);
		LimitPixels = EnumHelper.HasFlag(flags, GeometryFlags.LimitPixels);
	}
}
