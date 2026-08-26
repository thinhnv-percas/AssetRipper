using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class ConnectedComponent
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
			public static extern void ConnectedComponent_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ConnectedComponent_GetArea(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetCentroid(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetColor(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr ConnectedComponent_GetHeight(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetId(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetInstance(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr ConnectedComponent_GetWidth(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetX(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetY(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void ConnectedComponent_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ConnectedComponent_GetArea(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetCentroid(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetColor(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr ConnectedComponent_GetHeight(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetId(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetInstance(IntPtr list, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr ConnectedComponent_GetWidth(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetX(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ConnectedComponent_GetY(IntPtr instance);
		}
	}

	private static class NativeConnectedComponent
	{
		static NativeConnectedComponent()
		{
			Environment.Initialize();
		}

		public static void DisposeList(IntPtr list)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.ConnectedComponent_DisposeList(list);
			}
			else
			{
				NativeMethods.X86.ConnectedComponent_DisposeList(list);
			}
		}

		public static double GetArea(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.ConnectedComponent_GetArea(instance);
			}
			return NativeMethods.X86.ConnectedComponent_GetArea(instance);
		}

		public static PointInfo GetCentroid(IntPtr instance)
		{
			IntPtr instance2 = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.ConnectedComponent_GetCentroid(instance) : NativeMethods.X64.ConnectedComponent_GetCentroid(instance));
			return PointInfo.CreateInstance(instance2);
		}

		public static MagickColor GetColor(IntPtr instance)
		{
			IntPtr instance2 = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.ConnectedComponent_GetColor(instance) : NativeMethods.X64.ConnectedComponent_GetColor(instance));
			return MagickColor.CreateInstance(instance2);
		}

		public static int GetHeight(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.ConnectedComponent_GetHeight(instance);
			}
			return (int)(uint)NativeMethods.X86.ConnectedComponent_GetHeight(instance);
		}

		public static int GetId(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)NativeMethods.X64.ConnectedComponent_GetId(instance);
			}
			return (int)NativeMethods.X86.ConnectedComponent_GetId(instance);
		}

		public static IntPtr GetInstance(IntPtr list, int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.ConnectedComponent_GetInstance(list, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.ConnectedComponent_GetInstance(list, (UIntPtr)(ulong)index);
		}

		public static int GetWidth(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)(uint)NativeMethods.X64.ConnectedComponent_GetWidth(instance);
			}
			return (int)(uint)NativeMethods.X86.ConnectedComponent_GetWidth(instance);
		}

		public static int GetX(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)NativeMethods.X64.ConnectedComponent_GetX(instance);
			}
			return (int)NativeMethods.X86.ConnectedComponent_GetX(instance);
		}

		public static int GetY(IntPtr instance)
		{
			if (NativeLibrary.Is64Bit)
			{
				return (int)NativeMethods.X64.ConnectedComponent_GetY(instance);
			}
			return (int)NativeMethods.X86.ConnectedComponent_GetY(instance);
		}
	}

	public PointD Centroid { get; private set; }

	public MagickColor Color { get; private set; }

	public int Height { get; private set; }

	public int Id { get; private set; }

	public int Width { get; private set; }

	public int X { get; private set; }

	public int Y { get; private set; }

	private ConnectedComponent(IntPtr instance)
	{
		Centroid = PointD.FromPointInfo(NativeConnectedComponent.GetCentroid(instance));
		Color = NativeConnectedComponent.GetColor(instance);
		Height = NativeConnectedComponent.GetHeight(instance);
		Id = NativeConnectedComponent.GetId(instance);
		Width = NativeConnectedComponent.GetWidth(instance);
		X = NativeConnectedComponent.GetX(instance);
		Y = NativeConnectedComponent.GetY(instance);
	}

	public MagickGeometry ToGeometry()
	{
		return new MagickGeometry(X, Y, Width, Height);
	}

	public MagickGeometry ToGeometry(int extent)
	{
		int num = checked(extent * 2);
		return new MagickGeometry(X - extent, Y - extent, Width + num, Height + num);
	}

	internal static IEnumerable<ConnectedComponent> Create(IntPtr list, int length)
	{
		Collection<ConnectedComponent> collection = new Collection<ConnectedComponent>();
		if (list == IntPtr.Zero)
		{
			return collection;
		}
		for (int i = 0; i < length; i++)
		{
			IntPtr instance = NativeConnectedComponent.GetInstance(list, i);
			if (!(instance == IntPtr.Zero) && !(NativeConnectedComponent.GetArea(instance) < double.Epsilon))
			{
				collection.Add(new ConnectedComponent(instance));
			}
		}
		return collection;
	}

	internal static void DisposeList(IntPtr list)
	{
		if (list != IntPtr.Zero)
		{
			NativeConnectedComponent.DisposeList(list);
		}
	}
}
