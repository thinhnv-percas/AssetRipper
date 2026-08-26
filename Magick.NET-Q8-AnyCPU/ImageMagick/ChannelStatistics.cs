using System;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class ChannelStatistics : IEquatable<ChannelStatistics>
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
			public static extern UIntPtr ChannelStatistics_Depth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Entropy_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Kurtosis_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Maximum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Mean_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Minimum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Skewness_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_StandardDeviation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Sum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumCubed_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumFourthPower_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumSquared_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Variance_Get(IntPtr instance);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern UIntPtr ChannelStatistics_Depth_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Entropy_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Kurtosis_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Maximum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Mean_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Minimum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Skewness_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_StandardDeviation_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Sum_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumCubed_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumFourthPower_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_SumSquared_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelStatistics_Variance_Get(IntPtr instance);
		}
	}

	private sealed class NativeChannelStatistics : ConstNativeInstance
	{
		protected override string TypeName => "ChannelStatistics";

		public int Depth
		{
			get
			{
				UIntPtr uIntPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.ChannelStatistics_Depth_Get(base.Instance) : NativeMethods.X64.ChannelStatistics_Depth_Get(base.Instance));
				return (int)(uint)uIntPtr;
			}
		}

		public double Entropy
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Entropy_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Entropy_Get(base.Instance);
			}
		}

		public double Kurtosis
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Kurtosis_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Kurtosis_Get(base.Instance);
			}
		}

		public double Maximum
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Maximum_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Maximum_Get(base.Instance);
			}
		}

		public double Mean
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Mean_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Mean_Get(base.Instance);
			}
		}

		public double Minimum
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Minimum_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Minimum_Get(base.Instance);
			}
		}

		public double Skewness
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Skewness_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Skewness_Get(base.Instance);
			}
		}

		public double StandardDeviation
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_StandardDeviation_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_StandardDeviation_Get(base.Instance);
			}
		}

		public double Sum
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Sum_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Sum_Get(base.Instance);
			}
		}

		public double SumCubed
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_SumCubed_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_SumCubed_Get(base.Instance);
			}
		}

		public double SumFourthPower
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_SumFourthPower_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_SumFourthPower_Get(base.Instance);
			}
		}

		public double SumSquared
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_SumSquared_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_SumSquared_Get(base.Instance);
			}
		}

		public double Variance
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.ChannelStatistics_Variance_Get(base.Instance);
				}
				return NativeMethods.X86.ChannelStatistics_Variance_Get(base.Instance);
			}
		}

		static NativeChannelStatistics()
		{
			Environment.Initialize();
		}

		public NativeChannelStatistics(IntPtr instance)
		{
			base.Instance = instance;
		}
	}

	public PixelChannel Channel { get; private set; }

	public int Depth { get; private set; }

	public double Entropy { get; private set; }

	public double Kurtosis { get; private set; }

	public double Maximum { get; private set; }

	public double Mean { get; private set; }

	public double Minimum { get; private set; }

	public double Skewness { get; private set; }

	public double StandardDeviation { get; private set; }

	public double Sum { get; private set; }

	public double SumCubed { get; private set; }

	public double SumFourthPower { get; private set; }

	public double SumSquared { get; private set; }

	public double Variance { get; private set; }

	private ChannelStatistics(PixelChannel channel, IntPtr instance)
	{
		Channel = channel;
		NativeChannelStatistics nativeChannelStatistics = new NativeChannelStatistics(instance);
		Depth = nativeChannelStatistics.Depth;
		Entropy = nativeChannelStatistics.Entropy;
		Kurtosis = nativeChannelStatistics.Kurtosis;
		Maximum = nativeChannelStatistics.Maximum;
		Mean = nativeChannelStatistics.Mean;
		Minimum = nativeChannelStatistics.Minimum;
		Skewness = nativeChannelStatistics.Skewness;
		StandardDeviation = nativeChannelStatistics.StandardDeviation;
		Sum = nativeChannelStatistics.Sum;
		SumCubed = nativeChannelStatistics.SumCubed;
		SumFourthPower = nativeChannelStatistics.SumFourthPower;
		SumSquared = nativeChannelStatistics.SumSquared;
		Variance = nativeChannelStatistics.Variance;
	}

	public static bool operator ==(ChannelStatistics left, ChannelStatistics right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ChannelStatistics left, ChannelStatistics right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		return Equals(obj as ChannelStatistics);
	}

	public bool Equals(ChannelStatistics other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Depth.Equals(other.Depth) && Entropy.Equals(other.Entropy) && Kurtosis.Equals(other.Kurtosis) && Maximum.Equals(other.Maximum) && Mean.Equals(other.Mean) && Minimum.Equals(other.Minimum) && Skewness.Equals(other.Skewness) && StandardDeviation.Equals(other.StandardDeviation) && Sum.Equals(other.Sum) && SumCubed.Equals(other.SumCubed) && SumFourthPower.Equals(other.SumFourthPower) && SumSquared.Equals(other.SumSquared))
		{
			return Variance.Equals(other.Variance);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Depth.GetHashCode() ^ Entropy.GetHashCode() ^ Kurtosis.GetHashCode() ^ Maximum.GetHashCode() ^ Mean.GetHashCode() ^ Minimum.GetHashCode() ^ Skewness.GetHashCode() ^ StandardDeviation.GetHashCode() ^ Sum.GetHashCode() ^ SumCubed.GetHashCode() ^ SumFourthPower.GetHashCode() ^ SumSquared.GetHashCode() ^ Variance.GetHashCode();
	}

	internal static ChannelStatistics Create(PixelChannel channel, IntPtr instance)
	{
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		return new ChannelStatistics(channel, instance);
	}
}
