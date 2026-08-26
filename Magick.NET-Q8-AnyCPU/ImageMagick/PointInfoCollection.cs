using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

internal sealed class PointInfoCollection : IDisposable, INativeInstance
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
			public static extern IntPtr PointInfoCollection_Create(UIntPtr length);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PointInfoCollection_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PointInfoCollection_Set(IntPtr Instance, UIntPtr index, double x, double y);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PointInfoCollection_Create(UIntPtr length);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PointInfoCollection_Dispose(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PointInfoCollection_Set(IntPtr Instance, UIntPtr index, double x, double y);
		}
	}

	private sealed class NativePointInfoCollection : NativeInstance
	{
		protected override string TypeName => "PointInfoCollection";

		static NativePointInfoCollection()
		{
			Environment.Initialize();
		}

		protected override void Dispose(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PointInfoCollection_Dispose(instance);
			}
			else
			{
				NativeMethods.X86.PointInfoCollection_Dispose(instance);
			}
		}

		public NativePointInfoCollection(int length)
		{
			if (NativeLibrary.Is64Bit)
			{
				base.Instance = NativeMethods.X64.PointInfoCollection_Create((UIntPtr)(ulong)length);
			}
			else
			{
				base.Instance = NativeMethods.X86.PointInfoCollection_Create((UIntPtr)(ulong)length);
			}
			if (base.Instance == IntPtr.Zero)
			{
				throw new InvalidOperationException();
			}
		}

		public void Set(int index, double x, double y)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PointInfoCollection_Set(base.Instance, (UIntPtr)(ulong)index, x, y);
			}
			else
			{
				NativeMethods.X86.PointInfoCollection_Set(base.Instance, (UIntPtr)(ulong)index, x, y);
			}
		}
	}

	private NativePointInfoCollection _nativeInstance;

	public int Count { get; private set; }

	IntPtr INativeInstance.Instance => _nativeInstance.Instance;

	public PointInfoCollection(IList<PointD> coordinates)
		: this(coordinates.Count)
	{
		for (int i = 0; i < coordinates.Count; i++)
		{
			PointD pointD = coordinates[i];
			_nativeInstance.Set(i, pointD.X, pointD.Y);
		}
	}

	private PointInfoCollection(int count)
	{
		_nativeInstance = new NativePointInfoCollection(count);
		Count = count;
	}

	public void Dispose()
	{
		_nativeInstance.Dispose();
	}
}
