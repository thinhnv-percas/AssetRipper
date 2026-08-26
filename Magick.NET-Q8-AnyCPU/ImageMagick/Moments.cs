using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class Moments
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
			public static extern void Moments_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr Moments_GetInstance(IntPtr list, UIntPtr channel);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void Moments_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr Moments_GetInstance(IntPtr list, UIntPtr channel);
		}
	}

	private static class NativeMoments
	{
		static NativeMoments()
		{
			Environment.Initialize();
		}

		public static void DisposeList(IntPtr list)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.Moments_DisposeList(list);
			}
			else
			{
				NativeMethods.X86.Moments_DisposeList(list);
			}
		}

		public static IntPtr GetInstance(IntPtr list, PixelChannel channel)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.Moments_GetInstance(list, (UIntPtr)(ulong)channel);
			}
			return NativeMethods.X86.Moments_GetInstance(list, (UIntPtr)(ulong)channel);
		}
	}

	private readonly Dictionary<PixelChannel, ChannelMoments> _channels;

	internal Moments(MagickImage image, IntPtr list)
	{
		if (list == IntPtr.Zero)
		{
			return;
		}
		_channels = new Dictionary<PixelChannel, ChannelMoments>();
		foreach (PixelChannel channel in image.Channels)
		{
			AddChannel(list, channel);
		}
	}

	public ChannelMoments Composite()
	{
		return GetChannel(PixelChannel.Composite);
	}

	public ChannelMoments GetChannel(PixelChannel channel)
	{
		_channels.TryGetValue(channel, out var value);
		return value;
	}

	internal static void DisposeList(IntPtr list)
	{
		if (list != IntPtr.Zero)
		{
			NativeMoments.DisposeList(list);
		}
	}

	private void AddChannel(IntPtr list, PixelChannel channel)
	{
		IntPtr instance = NativeMoments.GetInstance(list, channel);
		ChannelMoments channelMoments = ChannelMoments.Create(channel, instance);
		if (channelMoments != null)
		{
			_channels.Add(channelMoments.Channel, channelMoments);
		}
	}
}
