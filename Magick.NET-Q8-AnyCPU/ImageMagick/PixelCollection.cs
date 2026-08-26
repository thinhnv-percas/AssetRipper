using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class PixelCollection : IDisposable, IEnumerable<Pixel>, IEnumerable
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
			public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PixelCollection_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, byte[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_ToShortArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PixelCollection_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, byte[] values, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PixelCollection_ToShortArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
		}
	}

	private sealed class NativePixelCollection : NativeInstance
	{
		protected override string TypeName => "PixelCollection";

		static NativePixelCollection()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PixelCollection_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.PixelCollection_Dispose(instance);
			}
		}

		public NativePixelCollection(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.PixelCollection_Create(image.GetInstance(), out exception);
			}
			else
			{
				base.Instance = NativeMethods.X86.PixelCollection_Create(image.GetInstance(), out exception);
			}
			CheckException(exception, base.Instance);
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public IntPtr GetArea(int x, int y, int width, int height)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr result = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.PixelCollection_GetArea(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception) : NativeMethods.X64.PixelCollection_GetArea(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, out exception));
			CheckException(exception);
			return result;
		}

		public void SetArea(int x, int y, int width, int height, byte[] values, int length)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PixelCollection_SetArea(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, values, (UIntPtr)(ulong)length, out exception);
			}
			else
			{
				NativeMethods.X86.PixelCollection_SetArea(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, values, (UIntPtr)(ulong)length, out exception);
			}
			CheckException(exception);
		}

		public IntPtr ToByteArray(int x, int y, int width, int height, string mapping)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(mapping);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.PixelCollection_ToByteArray(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, out exception) : NativeMethods.X64.PixelCollection_ToByteArray(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					MagickMemory.Relinquish(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr ToShortArray(int x, int y, int width, int height, string mapping)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(mapping);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.PixelCollection_ToShortArray(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, out exception) : NativeMethods.X64.PixelCollection_ToShortArray(base.Instance, (UIntPtr)(ulong)x, (UIntPtr)(ulong)y, (UIntPtr)(ulong)width, (UIntPtr)(ulong)height, nativeInstance.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					MagickMemory.Relinquish(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}
	}

	private NativePixelCollection _nativeInstance;

	private readonly MagickImage _image;

	public int Channels => _image.ChannelCount;

	public Pixel this[int x, int y] => GetPixel(x, y);

	internal PixelCollection(MagickImage image)
	{
		_image = image;
		_nativeInstance = new NativePixelCollection(image);
	}

	public void Dispose()
	{
		_nativeInstance.Dispose();
	}

	public byte[] GetArea(int x, int y, int width, int height)
	{
		CheckArea(x, y, width, height);
		return GetAreaUnchecked(x, y, width, height);
	}

	public byte[] GetArea(MagickGeometry geometry)
	{
		Throw.IfNull("geometry", geometry);
		return GetArea(geometry.X, geometry.Y, geometry.Width, geometry.Height);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public IEnumerator<Pixel> GetEnumerator()
	{
		return new PixelCollectionEnumerator(this, _image.Width, _image.Height);
	}

	public int GetIndex(PixelChannel channel)
	{
		return _image.ChannelOffset(channel);
	}

	public Pixel GetPixel(int x, int y)
	{
		CheckIndex(x, y);
		return Pixel.Create(this, x, y, GetAreaUnchecked(x, y, 1, 1));
	}

	public byte[] GetValue(int x, int y)
	{
		CheckIndex(x, y);
		return GetAreaUnchecked(x, y, 1, 1);
	}

	public byte[] GetValues()
	{
		return GetAreaUnchecked(0, 0, _image.Width, _image.Height);
	}

	public void Set(Pixel pixel)
	{
		Throw.IfNull("pixel", pixel);
		SetPixel(pixel.X, pixel.Y, pixel.Value);
	}

	public void Set(IEnumerable<Pixel> pixels)
	{
		Throw.IfNull("pixels", pixels);
		IEnumerator<Pixel> enumerator = pixels.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Set(enumerator.Current);
		}
	}

	public void Set(int x, int y, byte[] value)
	{
		Throw.IfNullOrEmpty("value", value);
		SetPixel(x, y, value);
	}

	public void Set(double[] values)
	{
		CheckValues(values);
		byte[] values2 = CastArray(values, Quantum.Convert);
		SetAreaUnchecked(0, 0, _image.Width, _image.Height, values2);
	}

	public void Set(int[] values)
	{
		CheckValues(values);
		byte[] values2 = CastArray(values, Quantum.Convert);
		SetAreaUnchecked(0, 0, _image.Width, _image.Height, values2);
	}

	public void Set(byte[] values)
	{
		CheckValues(values);
		SetAreaUnchecked(0, 0, _image.Width, _image.Height, values);
	}

	public void SetArea(int x, int y, int width, int height, double[] values)
	{
		CheckValues(x, y, width, height, values);
		byte[] values2 = CastArray(values, Quantum.Convert);
		SetAreaUnchecked(x, y, width, height, values2);
	}

	public void SetArea(int x, int y, int width, int height, int[] values)
	{
		CheckValues(x, y, width, height, values);
		byte[] values2 = CastArray(values, Quantum.Convert);
		SetAreaUnchecked(x, y, width, height, values2);
	}

	public void SetArea(int x, int y, int width, int height, byte[] values)
	{
		CheckValues(x, y, width, height, values);
		SetAreaUnchecked(x, y, width, height, values);
	}

	public byte[] ToArray()
	{
		return GetValues();
	}

	public byte[] ToByteArray(int x, int y, int width, int height, string mapping)
	{
		Throw.IfNullOrEmpty("mapping", mapping);
		CheckArea(x, y, width, height);
		IntPtr intPtr = IntPtr.Zero;
		byte[] array = null;
		try
		{
			intPtr = _nativeInstance.ToByteArray(x, y, width, height, mapping);
			return ByteConverter.ToArray(intPtr, width * height * mapping.Length);
		}
		finally
		{
			MagickMemory.Relinquish(intPtr);
		}
	}

	public byte[] ToByteArray(MagickGeometry geometry, string mapping)
	{
		Throw.IfNull("geometry", geometry);
		return ToByteArray(geometry.X, geometry.Y, geometry.Width, geometry.Height, mapping);
	}

	public byte[] ToByteArray(string mapping)
	{
		return ToByteArray(0, 0, _image.Width, _image.Height, mapping);
	}

	[CLSCompliant(false)]
	public ushort[] ToShortArray(int x, int y, int width, int height, string mapping)
	{
		Throw.IfNullOrEmpty("mapping", mapping);
		CheckArea(x, y, width, height);
		IntPtr intPtr = IntPtr.Zero;
		ushort[] array = null;
		try
		{
			intPtr = _nativeInstance.ToShortArray(x, y, width, height, mapping);
			return ShortConverter.ToArray(intPtr, width * height * mapping.Length);
		}
		finally
		{
			MagickMemory.Relinquish(intPtr);
		}
	}

	[CLSCompliant(false)]
	public ushort[] ToShortArray(MagickGeometry geometry, string mapping)
	{
		Throw.IfNull("geometry", geometry);
		return ToShortArray(geometry.X, geometry.Y, geometry.Width, geometry.Height, mapping);
	}

	[CLSCompliant(false)]
	public ushort[] ToShortArray(string mapping)
	{
		return ToShortArray(0, 0, _image.Width, _image.Height, mapping);
	}

	internal byte[] GetAreaUnchecked(int x, int y, int width, int height)
	{
		IntPtr area = _nativeInstance.GetArea(x, y, width, height);
		if (area == IntPtr.Zero)
		{
			throw new InvalidOperationException("Image contains no pixel data.");
		}
		int length = width * height * _image.ChannelCount;
		return QuantumConverter.ToArray(area, length);
	}

	internal void SetPixelUnchecked(int x, int y, byte[] value)
	{
		SetAreaUnchecked(x, y, 1, 1, value);
	}

	private static byte[] CastArray<T>(T[] values, Func<T, byte> convertMethod)
	{
		byte[] array = new byte[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = convertMethod(values[i]);
		}
		return array;
	}

	private void CheckArea(int x, int y, int width, int height)
	{
		CheckIndex(x, y);
		Throw.IfOutOfRange("width", 0, _image.Width - x, width, "Invalid width: {0}.", width);
		Throw.IfOutOfRange("height", 0, _image.Height - y, height, "Invalid height: {0}.", height);
	}

	private void CheckIndex(int x, int y)
	{
		Throw.IfOutOfRange("x", 0, _image.Width - 1, x, "Invalid X coordinate: {0}.", x);
		Throw.IfOutOfRange("y", 0, _image.Height - 1, y, "Invalid Y coordinate: {0}.", y);
	}

	private void CheckValues<T>(T[] values)
	{
		CheckValues(0, 0, values);
	}

	private void CheckValues<T>(int x, int y, T[] values)
	{
		CheckValues(x, y, _image.Width, _image.Height, values);
	}

	private void CheckValues<T>(int x, int y, int width, int height, T[] values)
	{
		CheckIndex(x, y);
		Throw.IfNullOrEmpty("values", values);
		Throw.IfFalse("values", values.Length % Channels == 0, "Values should have {0} channels.", Channels);
		int num = values.Length;
		int num2 = width * height * Channels;
		Throw.IfTrue("values", num > num2, "Too many values specified.");
		num = x * y * Channels + num;
		num2 = _image.Width * _image.Height * Channels;
		Throw.IfTrue("values", num > num2, "Too many values specified.");
	}

	private void SetAreaUnchecked(int x, int y, int width, int height, byte[] values)
	{
		_nativeInstance.SetArea(x, y, width, height, values, values.Length);
	}

	private void SetPixel(int x, int y, byte[] value)
	{
		CheckIndex(x, y);
		SetAreaUnchecked(x, y, 1, 1, value);
	}
}
