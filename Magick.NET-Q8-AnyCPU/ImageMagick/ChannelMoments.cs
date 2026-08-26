using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class ChannelMoments
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
			public static extern IntPtr ChannelMoments_Centroid_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseAngle_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ChannelMoments_EllipseAxis_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseEccentricity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseIntensity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_GetHuInvariants(IntPtr Instance, UIntPtr index);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ChannelMoments_Centroid_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseAngle_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr ChannelMoments_EllipseAxis_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseEccentricity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_EllipseIntensity_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelMoments_GetHuInvariants(IntPtr Instance, UIntPtr index);
		}
	}

	private sealed class NativeChannelMoments : ConstNativeInstance
	{
		protected override string TypeName => "ChannelMoments";

		public PointInfo Centroid
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.ChannelMoments_Centroid_Get(base.Instance) : NativeMethods.X64.ChannelMoments_Centroid_Get(base.Instance));
				return PointInfo.CreateInstance(instance);
			}
		}

		public double EllipseAngle
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelMoments_EllipseAngle_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelMoments_EllipseAngle_Get(base.Instance);
			}
		}

		public PointInfo EllipseAxis
		{
			get
			{
				IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.ChannelMoments_EllipseAxis_Get(base.Instance) : NativeMethods.X64.ChannelMoments_EllipseAxis_Get(base.Instance));
				return PointInfo.CreateInstance(instance);
			}
		}

		public double EllipseEccentricity
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelMoments_EllipseEccentricity_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelMoments_EllipseEccentricity_Get(base.Instance);
			}
		}

		public double EllipseIntensity
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelMoments_EllipseIntensity_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelMoments_EllipseIntensity_Get(base.Instance);
			}
		}

		static NativeChannelMoments()
		{
			Environment.Initialize();
		}

		public NativeChannelMoments(IntPtr instance)
		{
			base.Instance = instance;
		}

		public double GetHuInvariants(int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.ChannelMoments_GetHuInvariants(base.Instance, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.ChannelMoments_GetHuInvariants(base.Instance, (UIntPtr)(ulong)index);
		}
	}

	private double[] _huInvariants;

	public PointD Centroid { get; private set; }

	public PixelChannel Channel { get; private set; }

	public PointD EllipseAxis { get; private set; }

	public double EllipseAngle { get; private set; }

	public double EllipseEccentricity { get; private set; }

	public double EllipseIntensity { get; private set; }

	private ChannelMoments(PixelChannel channel, IntPtr instance)
	{
		Channel = channel;
		NativeChannelMoments nativeChannelMoments = new NativeChannelMoments(instance);
		Centroid = PointD.FromPointInfo(nativeChannelMoments.Centroid);
		EllipseAngle = nativeChannelMoments.EllipseAngle;
		EllipseAxis = PointD.FromPointInfo(nativeChannelMoments.EllipseAxis);
		EllipseEccentricity = nativeChannelMoments.EllipseEccentricity;
		EllipseIntensity = nativeChannelMoments.EllipseIntensity;
		SetHuInvariants(nativeChannelMoments);
	}

	public double HuInvariants(int index)
	{
		Throw.IfOutOfRange("index", index, 8);
		return _huInvariants[index];
	}

	internal static ChannelMoments Create(PixelChannel channel, IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		return new ChannelMoments(channel, instance);
	}

	private void SetHuInvariants(NativeChannelMoments nativeInstance)
	{
		_huInvariants = new double[8];
		for (int i = 0; i < 8; i++)
		{
			_huInvariants[i] = nativeInstance.GetHuInvariants(i);
		}
	}
}
