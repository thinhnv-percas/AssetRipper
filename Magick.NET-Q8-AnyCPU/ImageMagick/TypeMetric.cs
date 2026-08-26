using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class TypeMetric
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
			public static extern void TypeMetric_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_Ascent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_Descent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_TextHeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_TextWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void TypeMetric_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_Ascent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_Descent_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_TextHeight_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_TextWidth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
		}
	}

	private sealed class NativeTypeMetric : NativeInstance
	{
		protected override string TypeName => "TypeMetric";

		public double Ascent
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_Ascent_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_Ascent_Get(base.Instance);
			}
		}

		public double Descent
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_Descent_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_Descent_Get(base.Instance);
			}
		}

		public double MaxHorizontalAdvance
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_MaxHorizontalAdvance_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_MaxHorizontalAdvance_Get(base.Instance);
			}
		}

		public double TextHeight
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_TextHeight_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_TextHeight_Get(base.Instance);
			}
		}

		public double TextWidth
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_TextWidth_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_TextWidth_Get(base.Instance);
			}
		}

		public double UnderlinePosition
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_UnderlinePosition_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_UnderlinePosition_Get(base.Instance);
			}
		}

		public double UnderlineThickness
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.TypeMetric_UnderlineThickness_Get(base.Instance);
				}
				return NativeMethods.X86.TypeMetric_UnderlineThickness_Get(base.Instance);
			}
		}

		static NativeTypeMetric()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			DisposeInstance(instance);
		}

		public static void DisposeInstance(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.TypeMetric_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.TypeMetric_Dispose(instance);
			}
		}

		public NativeTypeMetric(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public double Ascent { get; private set; }

	public double Descent { get; private set; }

	public double MaxHorizontalAdvance { get; private set; }

	public double TextHeight { get; private set; }

	public double TextWidth { get; private set; }

	public double UnderlinePosition { get; private set; }

	public double UnderlineThickness { get; private set; }

	internal static TypeMetric CreateInstance(IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		using NativeTypeMetric instance2 = new NativeTypeMetric(instance);
		return new TypeMetric(instance2);
	}

	private TypeMetric(NativeTypeMetric instance)
	{
		Ascent = instance.Ascent;
		Descent = instance.Descent;
		MaxHorizontalAdvance = instance.MaxHorizontalAdvance;
		TextHeight = instance.TextHeight;
		TextWidth = instance.TextWidth;
		UnderlinePosition = instance.UnderlinePosition;
		UnderlineThickness = instance.UnderlineThickness;
	}

	internal static void Dispose(IntPtr instance)
	{
		NativeTypeMetric.DisposeInstance(instance);
	}
}
