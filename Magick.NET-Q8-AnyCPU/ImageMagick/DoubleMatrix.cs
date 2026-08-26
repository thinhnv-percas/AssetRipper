using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public abstract class DoubleMatrix
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
			public static extern IntPtr DoubleMatrix_Create(double[] values, UIntPtr order);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DoubleMatrix_Dispose(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr DoubleMatrix_Create(double[] values, UIntPtr order);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void DoubleMatrix_Dispose(IntPtr instance);
		}
	}

	private sealed class NativeDoubleMatrix : NativeInstance
	{
		protected override string TypeName => "DoubleMatrix";

		static NativeDoubleMatrix()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.DoubleMatrix_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.DoubleMatrix_Dispose(instance);
			}
		}

		public NativeDoubleMatrix(double[] values, int order)
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.DoubleMatrix_Create(values, (UIntPtr)(ulong)order);
			}
			else
			{
				base.Instance = NativeMethods.X86.DoubleMatrix_Create(values, (UIntPtr)(ulong)order);
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}
	}

	private readonly double[] _values;

	public int Order { get; private set; }

	public double this[int x, int y]
	{
		get
		{
			return GetValue(x, y);
		}
		set
		{
			SetValue(x, y, value);
		}
	}

	internal static INativeInstance CreateInstance(DoubleMatrix instance)
	{
		if (instance == null)
		{
			return NativeInstance.Zero;
		}
		return instance.CreateNativeInstance();
	}

	protected DoubleMatrix(int order, double[] values)
	{
		Order = order;
		_values = new double[Order * Order];
		if (values != null)
		{
			Throw.IfFalse("values", Order * Order == values.Length, "Invalid number of values specified");
			Array.Copy(values, _values, _values.Length);
		}
	}

	public double GetValue(int x, int y)
	{
		return _values[GetIndex(x, y)];
	}

	public void SetColumn(int x, params double[] values)
	{
		Throw.IfOutOfRange("x", x, Order);
		Throw.IfNull("values", values);
		Throw.IfTrue("values", values.Length != Order, "Invalid length");
		for (int i = 0; i < Order; i++)
		{
			SetValue(x, i, values[i]);
		}
	}

	public void SetRow(int y, params double[] values)
	{
		Throw.IfOutOfRange("y", y, Order);
		Throw.IfNull("values", values);
		Throw.IfTrue("values", values.Length != Order, "Invalid length");
		for (int i = 0; i < Order; i++)
		{
			SetValue(i, y, values[i]);
		}
	}

	public void SetValue(int x, int y, double value)
	{
		_values[GetIndex(x, y)] = value;
	}

	public double[] ToArray()
	{
		return _values;
	}

	private INativeInstance CreateNativeInstance()
	{
		return new NativeDoubleMatrix(_values, Order);
	}

	private int GetIndex(int x, int y)
	{
		Throw.IfOutOfRange("x", x, Order);
		Throw.IfOutOfRange("y", y, Order);
		return y * Order + x;
	}
}
