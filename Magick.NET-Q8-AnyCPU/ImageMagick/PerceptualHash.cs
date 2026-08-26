using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class PerceptualHash
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
			public static extern void PerceptualHash_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PerceptualHash_GetInstance(IntPtr image, IntPtr list, UIntPtr channel);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void PerceptualHash_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr PerceptualHash_GetInstance(IntPtr image, IntPtr list, UIntPtr channel);
		}
	}

	private static class NativePerceptualHash
	{
		static NativePerceptualHash()
		{
			Environment.Initialize();
		}

		public static void DisposeList(IntPtr list)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.PerceptualHash_DisposeList(list);
			}
			else
			{
				NativeMethods.X86.PerceptualHash_DisposeList(list);
			}
		}

		public static IntPtr GetInstance(IMagickImage image, IntPtr list, PixelChannel channel)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.PerceptualHash_GetInstance(image.GetInstance(), list, (UIntPtr)(ulong)channel);
			}
			return NativeMethods.X86.PerceptualHash_GetInstance(image.GetInstance(), list, (UIntPtr)(ulong)channel);
		}
	}

	private readonly Dictionary<PixelChannel, ChannelPerceptualHash> _channels;

	internal bool Isvalid
	{
		get
		{
			if (_channels.ContainsKey(PixelChannel.Red) && _channels.ContainsKey(PixelChannel.Green))
			{
				return _channels.ContainsKey(PixelChannel.Blue);
			}
			return false;
		}
	}

	public PerceptualHash(string perceptualHash)
		: this()
	{
		Throw.IfNullOrEmpty("perceptualHash", perceptualHash);
		Throw.IfFalse("perceptualHash", perceptualHash.Length == 210, "Invalid hash size.");
		_channels[PixelChannel.Red] = new ChannelPerceptualHash(PixelChannel.Red, perceptualHash.Substring(0, 70));
		_channels[PixelChannel.Green] = new ChannelPerceptualHash(PixelChannel.Green, perceptualHash.Substring(70, 70));
		_channels[PixelChannel.Blue] = new ChannelPerceptualHash(PixelChannel.Blue, perceptualHash.Substring(140, 70));
	}

	internal PerceptualHash(MagickImage image, IntPtr list)
		: this()
	{
		if (!(list == IntPtr.Zero))
		{
			AddChannel(image, list, PixelChannel.Red);
			AddChannel(image, list, PixelChannel.Green);
			AddChannel(image, list, PixelChannel.Blue);
		}
	}

	private PerceptualHash()
	{
		_channels = new Dictionary<PixelChannel, ChannelPerceptualHash>();
	}

	public ChannelPerceptualHash GetChannel(PixelChannel channel)
	{
		_channels.TryGetValue(channel, out var value);
		return value;
	}

	public double SumSquaredDistance(PerceptualHash other)
	{
		Throw.IfNull("other", other);
		return _channels[PixelChannel.Red].SumSquaredDistance(other._channels[PixelChannel.Red]) + _channels[PixelChannel.Green].SumSquaredDistance(other._channels[PixelChannel.Green]) + _channels[PixelChannel.Blue].SumSquaredDistance(other._channels[PixelChannel.Blue]);
	}

	public override string ToString()
	{
		return _channels[PixelChannel.Red].ToString() + _channels[PixelChannel.Green].ToString() + _channels[PixelChannel.Blue].ToString();
	}

	internal static void DisposeList(IntPtr list)
	{
		if (list != IntPtr.Zero)
		{
			NativePerceptualHash.DisposeList(list);
		}
	}

	private static ChannelPerceptualHash CreateChannelPerceptualHash(MagickImage image, IntPtr list, PixelChannel channel)
	{
		IntPtr instance = NativePerceptualHash.GetInstance(image, list, channel);
		if (instance == IntPtr.Zero)
		{
			return null;
		}
		return new ChannelPerceptualHash(channel, instance);
	}

	private void AddChannel(MagickImage image, IntPtr list, PixelChannel channel)
	{
		ChannelPerceptualHash channelPerceptualHash = CreateChannelPerceptualHash(image, list, channel);
		if (channelPerceptualHash != null)
		{
			_channels.Add(channelPerceptualHash.Channel, channelPerceptualHash);
		}
	}
}
