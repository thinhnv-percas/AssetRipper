using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class MagickImageCollection : IMagickImageCollection, IDisposable, IList<IMagickImage>, ICollection<IMagickImage>, IEnumerable<IMagickImage>, IEnumerable
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate int ReadWriteStreamDelegate(IntPtr data, UIntPtr length, IntPtr user_data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate long SeekStreamDelegate(long offset, IntPtr whence, IntPtr user_data);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	private delegate long TellStreamDelegate(IntPtr user_data);

	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Append(IntPtr image, [MarshalAs(UnmanagedType.Bool)] bool stack, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Coalesce(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Combine(IntPtr image, UIntPtr colorSpace, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Deconstruct(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Dispose(IntPtr value);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Evaluate(IntPtr image, UIntPtr evaluateOperator, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Flatten(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Map(IntPtr image, IntPtr settings, IntPtr remapImage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Merge(IntPtr image, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Montage(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Morph(IntPtr image, UIntPtr frames, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Optimize(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_OptimizePlus(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_OptimizeTransparency(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Quantize(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadBlob(IntPtr settings, byte[] data, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadFile(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadStream(IntPtr settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Smush(IntPtr image, IntPtr offset, [MarshalAs(UnmanagedType.Bool)] bool stack, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_WriteFile(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_WriteStream(IntPtr image, IntPtr settings, ReadWriteStreamDelegate reader, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Append(IntPtr image, [MarshalAs(UnmanagedType.Bool)] bool stack, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Coalesce(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Combine(IntPtr image, UIntPtr colorSpace, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Deconstruct(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Dispose(IntPtr value);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Evaluate(IntPtr image, UIntPtr evaluateOperator, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Flatten(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Map(IntPtr image, IntPtr settings, IntPtr remapImage, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Merge(IntPtr image, UIntPtr method, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Montage(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Morph(IntPtr image, UIntPtr frames, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Optimize(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_OptimizePlus(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_OptimizeTransparency(IntPtr image, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_Quantize(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadBlob(IntPtr settings, byte[] data, UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadFile(IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_ReadStream(IntPtr settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_Smush(IntPtr image, IntPtr offset, [MarshalAs(UnmanagedType.Bool)] bool stack, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickImageCollection_WriteFile(IntPtr image, IntPtr settings, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickImageCollection_WriteStream(IntPtr image, IntPtr settings, ReadWriteStreamDelegate reader, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller, out IntPtr exception);
		}
	}

	private sealed class NativeMagickImageCollection : NativeHelper
	{
		static NativeMagickImageCollection()
		{
			Environment.Initialize();
		}

		public IntPtr Append(IMagickImage image, bool stack)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Append(image.GetInstance(), stack, out exception) : NativeMethods.X64.MagickImageCollection_Append(image.GetInstance(), stack, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Coalesce(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Coalesce(image.GetInstance(), out exception) : NativeMethods.X64.MagickImageCollection_Coalesce(image.GetInstance(), out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Combine(IMagickImage image, ColorSpace colorSpace)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Combine(image.GetInstance(), (UIntPtr)(ulong)colorSpace, out exception) : NativeMethods.X64.MagickImageCollection_Combine(image.GetInstance(), (UIntPtr)(ulong)colorSpace, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Deconstruct(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Deconstruct(image.GetInstance(), out exception) : NativeMethods.X64.MagickImageCollection_Deconstruct(image.GetInstance(), out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public static void Dispose(IntPtr value)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImageCollection_Dispose(value);
			}
			else
			{
				NativeMethods.X86.MagickImageCollection_Dispose(value);
			}
		}

		public IntPtr Evaluate(IMagickImage image, EvaluateOperator evaluateOperator)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Evaluate(image.GetInstance(), (UIntPtr)(ulong)evaluateOperator, out exception) : NativeMethods.X64.MagickImageCollection_Evaluate(image.GetInstance(), (UIntPtr)(ulong)evaluateOperator, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Flatten(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Flatten(image.GetInstance(), out exception) : NativeMethods.X64.MagickImageCollection_Flatten(image.GetInstance(), out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void Map(IMagickImage image, QuantizeSettings settings, IMagickImage remapImage)
		{
			using INativeInstance nativeInstance = QuantizeSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImageCollection_Map(image.GetInstance(), nativeInstance.Instance, remapImage.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.MagickImageCollection_Map(image.GetInstance(), nativeInstance.Instance, remapImage.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public IntPtr Merge(IMagickImage image, LayerMethod method)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Merge(image.GetInstance(), (UIntPtr)(ulong)method, out exception) : NativeMethods.X64.MagickImageCollection_Merge(image.GetInstance(), (UIntPtr)(ulong)method, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Montage(IMagickImage image, MontageSettings settings)
		{
			using INativeInstance nativeInstance = MontageSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Montage(image.GetInstance(), nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImageCollection_Montage(image.GetInstance(), nativeInstance.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Morph(IMagickImage image, int frames)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Morph(image.GetInstance(), (UIntPtr)(ulong)frames, out exception) : NativeMethods.X64.MagickImageCollection_Morph(image.GetInstance(), (UIntPtr)(ulong)frames, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Optimize(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Optimize(image.GetInstance(), out exception) : NativeMethods.X64.MagickImageCollection_Optimize(image.GetInstance(), out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr OptimizePlus(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_OptimizePlus(image.GetInstance(), out exception) : NativeMethods.X64.MagickImageCollection_OptimizePlus(image.GetInstance(), out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void OptimizeTransparency(IMagickImage image)
		{
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImageCollection_OptimizeTransparency(image.GetInstance(), out exception);
			}
			else
			{
				NativeMethods.X86.MagickImageCollection_OptimizeTransparency(image.GetInstance(), out exception);
			}
			CheckException(exception);
		}

		public void Quantize(IMagickImage image, QuantizeSettings settings)
		{
			using INativeInstance nativeInstance = QuantizeSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImageCollection_Quantize(image.GetInstance(), nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImageCollection_Quantize(image.GetInstance(), nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public IntPtr ReadBlob(MagickSettings settings, byte[] data, int length)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_ReadBlob(nativeInstance.Instance, data, (UIntPtr)(ulong)length, out exception) : NativeMethods.X64.MagickImageCollection_ReadBlob(nativeInstance.Instance, data, (UIntPtr)(ulong)length, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr ReadFile(MagickSettings settings)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_ReadFile(nativeInstance.Instance, out exception) : NativeMethods.X64.MagickImageCollection_ReadFile(nativeInstance.Instance, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr ReadStream(MagickSettings settings, ReadWriteStreamDelegate reader, SeekStreamDelegate seeker, TellStreamDelegate teller)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_ReadStream(nativeInstance.Instance, reader, seeker, teller, out exception) : NativeMethods.X64.MagickImageCollection_ReadStream(nativeInstance.Instance, reader, seeker, teller, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public IntPtr Smush(IMagickImage image, int offset, bool stack)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_Smush(image.GetInstance(), (IntPtr)offset, stack, out exception) : NativeMethods.X64.MagickImageCollection_Smush(image.GetInstance(), (IntPtr)offset, stack, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public void WriteFile(IMagickImage image, MagickSettings settings)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickImageCollection_WriteFile(image.GetInstance(), nativeInstance.Instance, out exception);
			}
			else
			{
				NativeMethods.X86.MagickImageCollection_WriteFile(image.GetInstance(), nativeInstance.Instance, out exception);
			}
			CheckException(exception);
		}

		public IntPtr WriteStream(IMagickImage image, MagickSettings settings, ReadWriteStreamDelegate reader, ReadWriteStreamDelegate writer, SeekStreamDelegate seeker, TellStreamDelegate teller)
		{
			using INativeInstance nativeInstance = MagickSettings.CreateInstance(settings);
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickImageCollection_WriteStream(image.GetInstance(), nativeInstance.Instance, reader, writer, seeker, teller, out exception) : NativeMethods.X64.MagickImageCollection_WriteStream(image.GetInstance(), nativeInstance.Instance, reader, writer, seeker, teller, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					Dispose(intPtr);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}
	}

	private readonly List<IMagickImage> _images;

	private readonly NativeMagickImageCollection _nativeInstance;

	private EventHandler<WarningEventArgs> _warning;

	public int Count => _images.Count;

	public bool IsReadOnly => false;

	public IMagickImage this[int index]
	{
		get
		{
			return _images[index];
		}
		set
		{
			_images[index] = value;
		}
	}

	public event EventHandler<WarningEventArgs> Warning
	{
		add
		{
			_warning = (EventHandler<WarningEventArgs>)Delegate.Combine(_warning, value);
		}
		remove
		{
			_warning = (EventHandler<WarningEventArgs>)Delegate.Remove(_warning, value);
		}
	}

	public Bitmap ToBitmap()
	{
		return ToBitmap(ImageFormat.Tiff);
	}

	public Bitmap ToBitmap(ImageFormat imageFormat)
	{
		SetFormat(imageFormat);
		MemoryStream memoryStream = new MemoryStream();
		Write(memoryStream);
		memoryStream.Position = 0L;
		return new Bitmap(memoryStream);
	}

	private void SetFormat(ImageFormat format)
	{
		SetFormat(MagickFormatInfo.GetFormat(format));
	}

	public MagickImageCollection()
	{
		_images = new List<IMagickImage>();
		_nativeInstance = new NativeMagickImageCollection();
		_nativeInstance.Warning += OnWarning;
	}

	public MagickImageCollection(byte[] data)
		: this()
	{
		Read(data);
	}

	public MagickImageCollection(byte[] data, MagickReadSettings readSettings)
		: this()
	{
		Read(data, readSettings);
	}

	public MagickImageCollection(FileInfo file)
		: this()
	{
		Read(file);
	}

	public MagickImageCollection(FileInfo file, MagickReadSettings readSettings)
		: this()
	{
		Read(file, readSettings);
	}

	public MagickImageCollection(IEnumerable<IMagickImage> images)
		: this()
	{
		Throw.IfNull("images", images);
		foreach (IMagickImage image in images)
		{
			Add(image);
		}
	}

	public MagickImageCollection(Stream stream)
		: this()
	{
		AddRange(stream);
	}

	public MagickImageCollection(Stream stream, MagickReadSettings readSettings)
		: this()
	{
		AddRange(stream, readSettings);
	}

	public MagickImageCollection(string fileName)
		: this()
	{
		AddRange(fileName);
	}

	public MagickImageCollection(string fileName, MagickReadSettings readSettings)
		: this()
	{
		AddRange(fileName, readSettings);
	}

	~MagickImageCollection()
	{
		Dispose(disposing: false);
	}

	public static explicit operator byte[](MagickImageCollection collection)
	{
		Throw.IfNull("collection", collection);
		return collection.ToByteArray();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _images.GetEnumerator();
	}

	public void Add(IMagickImage item)
	{
		_images.Add(item);
	}

	public void Add(string fileName)
	{
		_images.Add(new MagickImage(fileName));
	}

	public void AddRange(byte[] data)
	{
		AddRange(data, null);
	}

	public void AddRange(byte[] data, MagickReadSettings readSettings)
	{
		Throw.IfNullOrEmpty("data", data);
		AddImages(data, data.Length, readSettings, ping: false);
	}

	public void AddRange(IEnumerable<IMagickImage> images)
	{
		Throw.IfNull("images", images);
		foreach (IMagickImage image in images)
		{
			Add(image);
		}
	}

	public void AddRange(IMagickImageCollection images)
	{
		Throw.IfNull("images", images);
		int count = images.Count;
		for (int i = 0; i < count; i++)
		{
			Add(images[i].Clone());
		}
	}

	public void AddRange(string fileName)
	{
		AddRange(fileName, null);
	}

	public void AddRange(string fileName, MagickReadSettings readSettings)
	{
		AddImages(fileName, readSettings, ping: false);
	}

	public void AddRange(Stream stream)
	{
		AddRange(stream, null);
	}

	public void AddRange(Stream stream, MagickReadSettings readSettings)
	{
		AddImages(stream, readSettings, ping: false);
	}

	public IMagickImage AppendHorizontally()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Append(_images[0], stack: false), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public IMagickImage AppendVertically()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Append(_images[0], stack: true), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Coalesce()
	{
		ThrowIfEmpty();
		MagickSettings settings = _images[0].Settings.Clone();
		IntPtr images;
		try
		{
			AttachImages();
			images = _nativeInstance.Coalesce(_images[0]);
		}
		finally
		{
			DetachImages();
		}
		Clear();
		foreach (MagickImage item in MagickImage.CreateList(images, settings))
		{
			Add(item);
		}
	}

	public void Clear()
	{
		foreach (MagickImage image in _images)
		{
			if (image != null)
			{
				image.Dispose();
			}
		}
		_images.Clear();
	}

	public IMagickImageCollection Clone()
	{
		IMagickImageCollection magickImageCollection = new MagickImageCollection();
		using IEnumerator<IMagickImage> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			MagickImage magickImage = (MagickImage)enumerator.Current;
			magickImageCollection.Add(magickImage.Clone());
		}
		return magickImageCollection;
	}

	public IMagickImage Combine()
	{
		return Combine(ColorSpace.sRGB);
	}

	public IMagickImage Combine(ColorSpace colorSpace)
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Combine(_images[0], colorSpace), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public bool Contains(IMagickImage item)
	{
		return _images.Contains(item);
	}

	public void CopyTo(IMagickImage[] array, int arrayIndex)
	{
		if (_images.Count != 0)
		{
			Throw.IfNull("array", array);
			Throw.IfOutOfRange("arrayIndex", arrayIndex, _images.Count);
			Throw.IfOutOfRange("arrayIndex", arrayIndex, array.Length);
			int num = 0;
			int num2 = Math.Min(array.Length, _images.Count);
			for (int i = arrayIndex; i < num2; i++)
			{
				array[i] = _images[num++].Clone();
			}
		}
	}

	public void Deconstruct()
	{
		ThrowIfEmpty();
		MagickSettings settings = _images[0].Settings.Clone();
		IntPtr images;
		try
		{
			AttachImages();
			images = _nativeInstance.Deconstruct(_images[0]);
		}
		finally
		{
			DetachImages();
		}
		Clear();
		foreach (IMagickImage item in MagickImage.CreateList(images, settings))
		{
			Add(item);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	public IMagickImage Evaluate(EvaluateOperator evaluateOperator)
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Evaluate(_images[0], evaluateOperator), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public IMagickImage Flatten()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Flatten(_images[0]), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public IEnumerator<IMagickImage> GetEnumerator()
	{
		return _images.GetEnumerator();
	}

	public int IndexOf(IMagickImage item)
	{
		return _images.IndexOf(item);
	}

	public void Insert(int index, IMagickImage item)
	{
		_images.Insert(index, item);
	}

	public void Insert(int index, string fileName)
	{
		_images.Insert(index, new MagickImage(fileName));
	}

	public void Map(IMagickImage image)
	{
		Map(image, new QuantizeSettings());
	}

	public void Map(IMagickImage image, QuantizeSettings settings)
	{
		ThrowIfEmpty();
		Throw.IfNull("image", image);
		Throw.IfNull("settings", settings);
		try
		{
			AttachImages();
			_nativeInstance.Map(_images[0], settings, image);
		}
		finally
		{
			DetachImages();
		}
	}

	public IMagickImage Merge()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Merge(_images[0], LayerMethod.Merge), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public IMagickImage Montage(MontageSettings settings)
	{
		ThrowIfEmpty();
		Throw.IfNull("settings", settings);
		IntPtr images;
		try
		{
			AttachImages();
			if (!string.IsNullOrEmpty(settings.Label))
			{
				_images[0].Label = settings.Label;
			}
			images = _nativeInstance.Montage(_images[0], settings);
		}
		finally
		{
			DetachImages();
		}
		using IMagickImageCollection magickImageCollection = new MagickImageCollection();
		magickImageCollection.AddRange(MagickImage.CreateList(images, _images[0].Settings));
		if (settings.TransparentColor != null)
		{
			foreach (IMagickImage item in magickImageCollection)
			{
				item.Transparent(settings.TransparentColor);
			}
		}
		return magickImageCollection.Merge();
	}

	public void Morph(int frames)
	{
		ThrowIfCountLowerThan(2);
		MagickSettings settings = _images[0].Settings.Clone();
		IntPtr images;
		try
		{
			AttachImages();
			images = _nativeInstance.Morph(_images[0], frames);
		}
		finally
		{
			DetachImages();
		}
		Clear();
		foreach (IMagickImage item in MagickImage.CreateList(images, settings))
		{
			Add(item);
		}
	}

	public IMagickImage Mosaic()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Merge(_images[0], LayerMethod.Mosaic), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Optimize()
	{
		ThrowIfEmpty();
		MagickSettings settings = _images[0].Settings.Clone();
		IntPtr images;
		try
		{
			AttachImages();
			images = _nativeInstance.Optimize(_images[0]);
		}
		finally
		{
			DetachImages();
		}
		Clear();
		foreach (IMagickImage item in MagickImage.CreateList(images, settings))
		{
			Add(item);
		}
	}

	public void OptimizePlus()
	{
		ThrowIfEmpty();
		MagickSettings settings = _images[0].Settings.Clone();
		IntPtr images;
		try
		{
			AttachImages();
			images = _nativeInstance.OptimizePlus(_images[0]);
		}
		finally
		{
			DetachImages();
		}
		Clear();
		foreach (IMagickImage item in MagickImage.CreateList(images, settings))
		{
			Add(item);
		}
	}

	public void OptimizeTransparency()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			_nativeInstance.OptimizeTransparency(_images[0]);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Ping(byte[] data)
	{
		Ping(data, null);
	}

	public void Ping(byte[] data, MagickReadSettings readSettings)
	{
		Throw.IfNullOrEmpty("data", data);
		Clear();
		AddImages(data, data.Length, readSettings, ping: true);
	}

	public void Ping(FileInfo file)
	{
		Throw.IfNull("file", file);
		Ping(file.FullName);
	}

	public void Ping(FileInfo file, MagickReadSettings readSettings)
	{
		Throw.IfNull("file", file);
		Ping(file.FullName, readSettings);
	}

	public void Ping(Stream stream)
	{
		Ping(stream, null);
	}

	public void Ping(Stream stream, MagickReadSettings readSettings)
	{
		Clear();
		AddImages(stream, readSettings, ping: true);
	}

	public void Ping(string fileName)
	{
		Clear();
		AddImages(fileName, null, ping: true);
	}

	public void Ping(string fileName, MagickReadSettings readSettings)
	{
		Clear();
		AddImages(fileName, readSettings, ping: true);
	}

	public MagickErrorInfo Quantize()
	{
		return Quantize(new QuantizeSettings());
	}

	public MagickErrorInfo Quantize(QuantizeSettings settings)
	{
		ThrowIfEmpty();
		Throw.IfNull("settings", settings);
		try
		{
			AttachImages();
			_nativeInstance.Quantize(_images[0], settings);
		}
		finally
		{
			DetachImages();
		}
		if (settings.MeasureErrors)
		{
			return _images[0].CreateErrorInfo();
		}
		return null;
	}

	public void Read(FileInfo file)
	{
		Throw.IfNull("file", file);
		Read(file.FullName);
	}

	public void Read(FileInfo file, MagickReadSettings readSettings)
	{
		Throw.IfNull("file", file);
		Read(file.FullName, readSettings);
	}

	public void Read(byte[] data)
	{
		Read(data, null);
	}

	public void Read(byte[] data, MagickReadSettings readSettings)
	{
		Throw.IfNullOrEmpty("data", data);
		Clear();
		AddImages(data, data.Length, readSettings, ping: false);
	}

	public void Read(Stream stream)
	{
		Read(stream, null);
	}

	public void Read(Stream stream, MagickReadSettings readSettings)
	{
		Clear();
		AddImages(stream, readSettings, ping: false);
	}

	public void Read(string fileName)
	{
		Read(fileName, null);
	}

	public void Read(string fileName, MagickReadSettings readSettings)
	{
		Clear();
		AddImages(fileName, readSettings, ping: false);
	}

	public bool Remove(IMagickImage item)
	{
		return _images.Remove(item);
	}

	public void RemoveAt(int index)
	{
		_images.RemoveAt(index);
	}

	public void RePage()
	{
		foreach (IMagickImage image in _images)
		{
			image.RePage();
		}
	}

	public void Reverse()
	{
		_images.Reverse();
	}

	public IMagickImage SmushHorizontal(int offset)
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Smush(_images[0], offset, stack: false), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public IMagickImage SmushVertical(int offset)
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			return MagickImage.Create(_nativeInstance.Smush(_images[0], offset, stack: true), _images[0].Settings);
		}
		finally
		{
			DetachImages();
		}
	}

	public byte[] ToByteArray()
	{
		using MemoryStream memoryStream = new MemoryStream();
		Write(memoryStream);
		return memoryStream.ToArray();
	}

	public byte[] ToByteArray(IWriteDefines defines)
	{
		SetDefines(defines);
		return ToByteArray(defines);
	}

	public byte[] ToByteArray(MagickFormat format)
	{
		SetFormat(format);
		return ToByteArray();
	}

	public string ToBase64()
	{
		byte[] array = ToByteArray();
		if (array == null)
		{
			return string.Empty;
		}
		return Convert.ToBase64String(array);
	}

	public string ToBase64(MagickFormat format)
	{
		byte[] array = ToByteArray(format);
		if (array == null)
		{
			return string.Empty;
		}
		return Convert.ToBase64String(array);
	}

	public void TrimBounds()
	{
		ThrowIfEmpty();
		try
		{
			AttachImages();
			_nativeInstance.Merge(_images[0], LayerMethod.Trimbounds);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Write(FileInfo file)
	{
		Throw.IfNull("file", file);
		Write(file.FullName);
		file.Refresh();
	}

	public void Write(FileInfo file, IWriteDefines defines)
	{
		SetDefines(defines);
		Write(file);
	}

	public void Write(Stream stream)
	{
		Throw.IfNull("stream", stream);
		if (_images.Count == 0)
		{
			return;
		}
		MagickSettings magickSettings = _images[0].Settings.Clone();
		magickSettings.FileName = null;
		try
		{
			AttachImages();
			using StreamWrapper streamWrapper = StreamWrapper.CreateForWriting(stream);
			ReadWriteStreamDelegate reader = streamWrapper.Read;
			ReadWriteStreamDelegate writer = streamWrapper.Write;
			SeekStreamDelegate seeker = null;
			TellStreamDelegate teller = null;
			if (stream.CanSeek)
			{
				seeker = streamWrapper.Seek;
				teller = streamWrapper.Tell;
			}
			_nativeInstance.WriteStream(_images[0], magickSettings, reader, writer, seeker, teller);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Write(Stream stream, IWriteDefines defines)
	{
		SetDefines(defines);
		SetFormat(defines.Format);
		Write(stream);
	}

	public void Write(Stream stream, MagickFormat format)
	{
		SetFormat(format);
		Write(stream);
	}

	public void Write(string fileName)
	{
		FileHelper.CheckForBaseDirectory(fileName);
		if (_images.Count == 0)
		{
			return;
		}
		MagickSettings magickSettings = _images[0].Settings.Clone();
		magickSettings.FileName = fileName;
		try
		{
			AttachImages();
			_nativeInstance.WriteFile(_images[0], magickSettings);
		}
		finally
		{
			DetachImages();
		}
	}

	public void Write(string fileName, IWriteDefines defines)
	{
		SetDefines(defines);
		Write(fileName);
	}

	private static MagickSettings CreateSettings(MagickReadSettings readSettings)
	{
		if (readSettings == null)
		{
			return new MagickSettings();
		}
		Throw.IfTrue("readSettings", readSettings.PixelStorage != null, "Settings the pixel storage is not supported for images with multiple frames/layers.");
		return new MagickReadSettings(readSettings);
	}

	private void AddImages(byte[] data, int length, MagickReadSettings readSettings, bool ping)
	{
		MagickSettings magickSettings = CreateSettings(readSettings);
		magickSettings.Ping = ping;
		IntPtr result = _nativeInstance.ReadBlob(magickSettings, data, length);
		AddImages(result, magickSettings);
	}

	private void AddImages(string fileName, MagickReadSettings readSettings, bool ping)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		MagickSettings magickSettings = CreateSettings(readSettings);
		magickSettings.FileName = text;
		magickSettings.Ping = ping;
		IntPtr result = _nativeInstance.ReadFile(magickSettings);
		AddImages(result, magickSettings);
	}

	private void AddImages(Stream stream, MagickReadSettings readSettings, bool ping)
	{
		Throw.IfNull("stream", stream);
		Bytes bytes = Bytes.FromStreamBuffer(stream);
		if (bytes != null)
		{
			AddImages(bytes.Data, bytes.Length, readSettings, ping);
			return;
		}
		MagickSettings magickSettings = CreateSettings(readSettings);
		magickSettings.Ping = ping;
		magickSettings.FileName = null;
		using StreamWrapper streamWrapper = StreamWrapper.CreateForReading(stream);
		ReadWriteStreamDelegate reader = streamWrapper.Read;
		SeekStreamDelegate seeker = null;
		TellStreamDelegate teller = null;
		if (stream.CanSeek)
		{
			seeker = streamWrapper.Seek;
			teller = streamWrapper.Tell;
		}
		IntPtr result = _nativeInstance.ReadStream(magickSettings, reader, seeker, teller);
		AddImages(result, magickSettings);
	}

	private void AddImages(IntPtr result, MagickSettings settings)
	{
		foreach (IMagickImage item in MagickImage.CreateList(result, settings))
		{
			_images.Add(item);
		}
	}

	private void AttachImages()
	{
		for (int i = 0; i < _images.Count - 1; i++)
		{
			_images[i].SetNext(_images[i + 1]);
		}
	}

	private void DetachImages()
	{
		for (int num = _images.Count - 2; num > 0; num--)
		{
			_images[num].SetNext(null);
		}
	}

	private void Dispose(bool disposing)
	{
		if (_nativeInstance != null)
		{
			_nativeInstance.Warning -= OnWarning;
		}
		if (disposing)
		{
			Clear();
		}
	}

	private void OnWarning(object sender, WarningEventArgs arguments)
	{
		if (_warning != null)
		{
			_warning(this, arguments);
		}
	}

	private void SetDefines([ValidatedNotNull] IWriteDefines defines)
	{
		foreach (IMagickImage image in _images)
		{
			image.Settings.SetDefines(defines);
		}
	}

	private void SetFormat(MagickFormat format)
	{
		foreach (IMagickImage image in _images)
		{
			image.Format = format;
		}
	}

	private void ThrowIfEmpty()
	{
		if (_images.Count == 0)
		{
			throw new InvalidOperationException("Operation requires at least one image.");
		}
	}

	private void ThrowIfCountLowerThan(int count)
	{
		if (_images.Count < count)
		{
			throw new InvalidOperationException("Operation requires at least " + count + " images.");
		}
	}
}
