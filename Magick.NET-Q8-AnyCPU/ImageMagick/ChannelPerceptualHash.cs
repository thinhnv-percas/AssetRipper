using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ImageMagick;

public class ChannelPerceptualHash
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
			public static extern double ChannelPerceptualHash_GetSrgbHuPhash(IntPtr Instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelPerceptualHash_GetHclpHuPhash(IntPtr Instance, UIntPtr index);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelPerceptualHash_GetSrgbHuPhash(IntPtr Instance, UIntPtr index);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern double ChannelPerceptualHash_GetHclpHuPhash(IntPtr Instance, UIntPtr index);
		}
	}

	private sealed class NativeChannelPerceptualHash : ConstNativeInstance
	{
		protected override string TypeName => "ChannelPerceptualHash";

		static NativeChannelPerceptualHash()
		{
			Environment.Initialize();
		}

		public NativeChannelPerceptualHash(IntPtr instance)
		{
			base.Instance = instance;
		}

		public double GetSrgbHuPhash(int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.ChannelPerceptualHash_GetSrgbHuPhash(base.Instance, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.ChannelPerceptualHash_GetSrgbHuPhash(base.Instance, (UIntPtr)(ulong)index);
		}

		public double GetHclpHuPhash(int index)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.ChannelPerceptualHash_GetHclpHuPhash(base.Instance, (UIntPtr)(ulong)index);
			}
			return NativeMethods.X86.ChannelPerceptualHash_GetHclpHuPhash(base.Instance, (UIntPtr)(ulong)index);
		}
	}

	private readonly double[] _srgbHuPhash;

	private readonly double[] _hclpHuPhash;

	private string _hash;

	public PixelChannel Channel { get; private set; }

	public ChannelPerceptualHash(PixelChannel channel, double[] srgbHuPhash, double[] hclpHuPhash, string hash)
	{
		Channel = channel;
		_srgbHuPhash = srgbHuPhash;
		_hclpHuPhash = hclpHuPhash;
		_hash = hash;
	}

	internal ChannelPerceptualHash(PixelChannel channel)
	{
		Channel = channel;
		_hclpHuPhash = new double[7];
		_srgbHuPhash = new double[7];
	}

	internal ChannelPerceptualHash(PixelChannel channel, IntPtr instance)
		: this(channel)
	{
		NativeChannelPerceptualHash nativeChannelPerceptualHash = new NativeChannelPerceptualHash(instance);
		SetSrgbHuPhash(nativeChannelPerceptualHash);
		SetHclpHuPhash(nativeChannelPerceptualHash);
		SetHash();
	}

	internal ChannelPerceptualHash(PixelChannel channel, string hash)
		: this(channel)
	{
		ParseHash(hash);
	}

	public double SrgbHuPhash(int index)
	{
		Throw.IfOutOfRange("index", index, 7);
		return _srgbHuPhash[index];
	}

	public double HclpHuPhash(int index)
	{
		Throw.IfOutOfRange("index", index, 7);
		return _hclpHuPhash[index];
	}

	public double SumSquaredDistance(ChannelPerceptualHash other)
	{
		Throw.IfNull("other", other);
		double num = 0.0;
		for (int i = 0; i < 7; i++)
		{
			num += (_srgbHuPhash[i] - other._srgbHuPhash[i]) * (_srgbHuPhash[i] - other._srgbHuPhash[i]);
			num += (_hclpHuPhash[i] - other._hclpHuPhash[i]) * (_hclpHuPhash[i] - other._hclpHuPhash[i]);
		}
		return num;
	}

	public override string ToString()
	{
		return _hash;
	}

	private void ParseHash(string hash)
	{
		_hash = hash;
		for (int i = 0; i < 14; i++)
		{
			if (!int.TryParse(hash.Substring(i * 5, 5), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
			{
				throw new ArgumentException("Invalid hash specified", "hash");
			}
			double num = (double)(int)(ushort)result / Math.Pow(10.0, result >> 17);
			if ((result & 0x10000) != 0)
			{
				num = 0.0 - num;
			}
			if (i < 7)
			{
				_srgbHuPhash[i] = num;
			}
			else
			{
				_hclpHuPhash[i - 7] = num;
			}
		}
	}

	private void SetHash()
	{
		_hash = string.Empty;
		for (int i = 0; i < 14; i++)
		{
			double num = ((i >= 7) ? _hclpHuPhash[i - 7] : _srgbHuPhash[i]);
			int j;
			for (j = 0; j < 7; j++)
			{
				if (!(Math.Abs(num * 10.0) < 65536.0))
				{
					break;
				}
				num *= 10.0;
			}
			j <<= 1;
			if (num < 0.0)
			{
				j |= 1;
			}
			_hash += ((j << 16) + (int)((num < 0.0) ? (0.0 - (num - 0.5)) : (num + 0.5))).ToString("x", CultureInfo.InvariantCulture);
		}
	}

	private void SetHclpHuPhash(NativeChannelPerceptualHash instance)
	{
		for (int i = 0; i < 7; i++)
		{
			_hclpHuPhash[i] = instance.GetHclpHuPhash(i);
		}
	}

	private void SetSrgbHuPhash(NativeChannelPerceptualHash instance)
	{
		for (int i = 0; i < 7; i++)
		{
			_srgbHuPhash[i] = instance.GetSrgbHuPhash(i);
		}
	}
}
