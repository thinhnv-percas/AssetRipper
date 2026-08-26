using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class Statistics : IEquatable<Statistics>
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
			public static extern void Statistics_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr Statistics_GetInstance(IntPtr list, UIntPtr channel);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void Statistics_DisposeList(IntPtr list);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr Statistics_GetInstance(IntPtr list, UIntPtr channel);
		}
	}

	private static class NativeStatistics
	{
		static NativeStatistics()
		{
			Environment.Initialize();
		}

		public static void DisposeList(IntPtr list)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.Statistics_DisposeList(list);
			}
			else
			{
				NativeMethods.X86.Statistics_DisposeList(list);
			}
		}

		public static IntPtr GetInstance(IntPtr list, PixelChannel channel)
		{
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.Statistics_GetInstance(list, (UIntPtr)(ulong)channel);
			}
			return NativeMethods.X86.Statistics_GetInstance(list, (UIntPtr)(ulong)channel);
		}
	}

	private readonly Dictionary<PixelChannel, ChannelStatistics> _channels;

	internal Statistics(MagickImage image, IntPtr list)
	{
		if (list == IntPtr.Zero)
		{
			return;
		}
		_channels = new Dictionary<PixelChannel, ChannelStatistics>();
		foreach (PixelChannel channel in image.Channels)
		{
			AddChannel(list, channel);
		}
		AddChannel(list, PixelChannel.Composite);
	}

	public static bool operator ==(Statistics left, Statistics right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Statistics left, Statistics right)
	{
		return !object.Equals(left, right);
	}

	public ChannelStatistics Composite()
	{
		return GetChannel(PixelChannel.Composite);
	}

	public ChannelStatistics GetChannel(PixelChannel channel)
	{
		_channels.TryGetValue(channel, out var value);
		return value;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		return Equals(obj as Statistics);
	}

	public bool Equals(Statistics other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (_channels.Count != other._channels.Count)
		{
			return false;
		}
		foreach (PixelChannel key in _channels.Keys)
		{
			if (!other._channels.ContainsKey(key))
			{
				return false;
			}
			if (!_channels[key].Equals(other._channels[key]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = _channels.GetHashCode();
		foreach (PixelChannel key in _channels.Keys)
		{
			num ^= _channels[key].GetHashCode();
		}
		return num;
	}

	internal static void DisposeList(IntPtr list)
	{
		if (list != IntPtr.Zero)
		{
			NativeStatistics.DisposeList(list);
		}
	}

	private void AddChannel(IntPtr list, PixelChannel channel)
	{
		IntPtr instance = NativeStatistics.GetInstance(list, channel);
		ChannelStatistics channelStatistics = ChannelStatistics.Create(channel, instance);
		if (channelStatistics != null)
		{
			_channels.Add(channelStatistics.Channel, channelStatistics);
		}
	}
}
