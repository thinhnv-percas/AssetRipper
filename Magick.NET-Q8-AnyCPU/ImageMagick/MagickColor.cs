using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class MagickColor : IEquatable<MagickColor>, IComparable<MagickColor>
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
			public static extern IntPtr MagickColor_Create();

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong MagickColor_Count_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Red_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Red_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Green_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Green_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Blue_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Blue_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Alpha_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Alpha_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Black_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Black_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_IsCMYK_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_FuzzyEquals(IntPtr Instance, IntPtr other, byte fuzz);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_Initialize(IntPtr Instance, IntPtr value);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickColor_Create();

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern ulong MagickColor_Count_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Red_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Red_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Green_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Green_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Blue_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Blue_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Alpha_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Alpha_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern byte MagickColor_Black_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickColor_Black_Set(IntPtr instance, byte value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_IsCMYK_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_FuzzyEquals(IntPtr Instance, IntPtr other, byte fuzz);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickColor_Initialize(IntPtr Instance, IntPtr value);
		}
	}

	private sealed class NativeMagickColor : NativeInstance
	{
		protected override string TypeName => "MagickColor";

		public ulong Count
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Count_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Count_Get(base.Instance);
			}
		}

		public byte Red
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Red_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Red_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickColor_Red_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickColor_Red_Set(base.Instance, value);
				}
			}
		}

		public byte Green
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Green_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Green_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickColor_Green_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickColor_Green_Set(base.Instance, value);
				}
			}
		}

		public byte Blue
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Blue_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Blue_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickColor_Blue_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickColor_Blue_Set(base.Instance, value);
				}
			}
		}

		public byte Alpha
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Alpha_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Alpha_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickColor_Alpha_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickColor_Alpha_Set(base.Instance, value);
				}
			}
		}

		public byte Black
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_Black_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_Black_Get(base.Instance);
			}
			set
			{
				if (NativeLibrary.Is64Bit)
				{
					NativeMethods.X64.MagickColor_Black_Set(base.Instance, value);
				}
				else
				{
					NativeMethods.X86.MagickColor_Black_Set(base.Instance, value);
				}
			}
		}

		public bool IsCMYK
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickColor_IsCMYK_Get(base.Instance);
				}
				return NativeMethods.X86.MagickColor_IsCMYK_Get(base.Instance);
			}
		}

		static NativeMagickColor()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickColor_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.MagickColor_Dispose(instance);
			}
		}

		public NativeMagickColor()
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.MagickColor_Create();
			}
			else
			{
				base.Instance = NativeMethods.X86.MagickColor_Create();
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public NativeMagickColor(IntPtr instance)
		{
			base.Instance = instance;
		}

		public bool FuzzyEquals(MagickColor other, byte fuzz)
		{
			using INativeInstance nativeInstance = CreateInstance(other);
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickColor_FuzzyEquals(base.Instance, nativeInstance.Instance, fuzz);
			}
			return NativeMethods.X86.MagickColor_FuzzyEquals(base.Instance, nativeInstance.Instance, fuzz);
		}

		public bool Initialize(string value)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(value);
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickColor_Initialize(base.Instance, nativeInstance.Instance);
			}
			return NativeMethods.X86.MagickColor_Initialize(base.Instance, nativeInstance.Instance);
		}
	}

	private bool _isCmyk;

	public byte A { get; set; }

	public byte B { get; set; }

	public byte G { get; set; }

	public byte K { get; set; }

	public byte R { get; set; }

	internal int Count { get; private set; }

	public MagickColor(Color color)
	{
		Initialize(color.R, color.G, color.B, color.A);
	}

	public static implicit operator Color(MagickColor color)
	{
		return color?.ToColor() ?? Color.Empty;
	}

	public static implicit operator MagickColor(Color color)
	{
		return new MagickColor(color);
	}

	public Color ToColor()
	{
		return Color.FromArgb(Quantum.ScaleToByte(A), Quantum.ScaleToByte(R), Quantum.ScaleToByte(G), Quantum.ScaleToByte(B));
	}

	internal static INativeInstance CreateInstance(MagickColor instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	internal static MagickColor CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		using NativeMagickColor instance2 = new NativeMagickColor(instance);
		return new MagickColor(instance2);
	}

	public MagickColor()
	{
	}

	public MagickColor(MagickColor color)
	{
		Throw.IfNull("color", color);
		R = color.R;
		G = color.G;
		B = color.B;
		A = color.A;
		K = color.K;
		_isCmyk = color._isCmyk;
	}

	public MagickColor(byte red, byte green, byte blue)
	{
		Initialize(red, green, blue, Quantum.Max);
	}

	public MagickColor(byte red, byte green, byte blue, byte alpha)
	{
		Initialize(red, green, blue, alpha);
	}

	public MagickColor(byte cyan, byte magenta, byte yellow, byte black, byte alpha)
	{
		Initialize(cyan, magenta, yellow, alpha);
		K = black;
		_isCmyk = true;
	}

	public MagickColor(string color)
	{
		Throw.IfNullOrEmpty("color", color);
		if (color.Equals("transparent", StringComparison.OrdinalIgnoreCase))
		{
			Initialize(Quantum.Max, Quantum.Max, Quantum.Max, 0);
			return;
		}
		if (color[0] == '#')
		{
			ParseHexColor(color);
			return;
		}
		using NativeMagickColor nativeMagickColor = new NativeMagickColor();
		Throw.IfFalse("color", nativeMagickColor.Initialize(color), "Invalid color specified");
		Initialize(nativeMagickColor);
	}

	private MagickColor(NativeMagickColor instance)
	{
		Initialize(instance);
	}

	public static bool operator ==(MagickColor left, MagickColor right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(MagickColor left, MagickColor right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(MagickColor left, MagickColor right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(MagickColor left, MagickColor right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(MagickColor left, MagickColor right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(MagickColor left, MagickColor right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public static MagickColor FromRgb(byte red, byte green, byte blue)
	{
		MagickColor magickColor = new MagickColor();
		magickColor.Initialize(red, green, blue, byte.MaxValue);
		return magickColor;
	}

	public static MagickColor FromRgba(byte red, byte green, byte blue, byte alpha)
	{
		MagickColor magickColor = new MagickColor();
		magickColor.Initialize(red, green, blue, alpha);
		return magickColor;
	}

	public MagickColor Clone()
	{
		return new MagickColor(this);
	}

	public int CompareTo(MagickColor other)
	{
		if ((object)other == null)
		{
			return 1;
		}
		if (R < other.R)
		{
			return -1;
		}
		if (R > other.R)
		{
			return 1;
		}
		if (G < other.G)
		{
			return -1;
		}
		if (G > other.G)
		{
			return 1;
		}
		if (B < other.B)
		{
			return -1;
		}
		if (B > other.B)
		{
			return 1;
		}
		if (K < other.K)
		{
			return -1;
		}
		if (K > other.K)
		{
			return 1;
		}
		if (A < other.A)
		{
			return -1;
		}
		if (A > other.A)
		{
			return 1;
		}
		return 0;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as MagickColor);
	}

	public bool Equals(MagickColor other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (_isCmyk == other._isCmyk && A == other.A && B == other.B && G == other.G && R == other.R)
		{
			return K == other.K;
		}
		return false;
	}

	public bool FuzzyEquals(MagickColor other, Percentage fuzz)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		using NativeMagickColor nativeMagickColor = CreateNativeInstance();
		return nativeMagickColor.FuzzyEquals(other, fuzz.ToQuantumType());
	}

	public override int GetHashCode()
	{
		return _isCmyk.GetHashCode() ^ A.GetHashCode() ^ B.GetHashCode() ^ G.GetHashCode() ^ K.GetHashCode() ^ R.GetHashCode();
	}

	public override string ToString()
	{
		if (_isCmyk)
		{
			return string.Format(CultureInfo.InvariantCulture, "cmyka({0},{1},{2},{3},{4:0.0###})", R, G, B, K, (double)(int)A / (double)(int)Quantum.Max);
		}
		return string.Format(CultureInfo.InvariantCulture, "#{0:X2}{1:X2}{2:X2}{3:X2}", R, G, B, A);
	}

	internal static MagickColor Clone(MagickColor value)
	{
		if (value == null)
		{
			return value;
		}
		return new MagickColor
		{
			R = value.R,
			G = value.G,
			B = value.B,
			A = value.A,
			K = value.K,
			_isCmyk = value._isCmyk
		};
	}

	internal static string ToString(MagickColor value)
	{
		return value?.ToString();
	}

	internal string ToShortString()
	{
		if (A != Quantum.Max)
		{
			return ToString();
		}
		if (_isCmyk)
		{
			return string.Format(CultureInfo.InvariantCulture, "cmyk({0},{1},{2},{3})", R, G, B, K);
		}
		return string.Format(CultureInfo.InvariantCulture, "#{0:X2}{1:X2}{2:X2}", new object[3] { R, G, B });
	}

	private NativeMagickColor CreateNativeInstance()
	{
		return new NativeMagickColor
		{
			Red = R,
			Green = G,
			Blue = B,
			Alpha = A,
			Black = K
		};
	}

	private void Initialize(NativeMagickColor instance)
	{
		R = instance.Red;
		G = instance.Green;
		B = instance.Blue;
		A = instance.Alpha;
		K = instance.Black;
		_isCmyk = instance.IsCMYK;
		Count = (int)instance.Count;
	}

	private void Initialize(byte red, byte green, byte blue, byte alpha)
	{
		R = red;
		G = green;
		B = blue;
		A = alpha;
		K = 0;
	}

	private void ParseHexColor(string color)
	{
		List<byte> list = HexColor.Parse(color);
		if (list.Count == 1)
		{
			Initialize(list[0], list[0], list[0], Quantum.Max);
		}
		else if (list.Count == 3)
		{
			Initialize(list[0], list[1], list[2], Quantum.Max);
		}
		else
		{
			Initialize(list[0], list[1], list[2], list[3]);
		}
	}
}
