using System;
using System.Collections.Generic;

namespace ImageMagick;

public sealed class Pixel : IEquatable<Pixel>
{
	private PixelCollection _collection;

	public int Channels => Value.Length;

	public int X { get; private set; }

	public int Y { get; private set; }

	internal byte[] Value { get; private set; }

	public byte this[int channel]
	{
		get
		{
			return GetChannel(channel);
		}
		set
		{
			SetChannel(channel, value);
		}
	}

	public Pixel(int x, int y, byte[] value)
	{
		Throw.IfNull("value", value);
		CheckChannels(value.Length);
		Initialize(x, y, value);
	}

	public Pixel(int x, int y, int channels)
	{
		CheckChannels(channels);
		Initialize(x, y, new byte[channels]);
	}

	private Pixel(PixelCollection collection)
	{
		_collection = collection;
	}

	public static bool operator ==(Pixel left, Pixel right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(Pixel left, Pixel right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as Pixel);
	}

	public bool Equals(Pixel other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Channels != other.Channels)
		{
			return false;
		}
		for (int i = 0; i < Value.Length; i++)
		{
			if (Value[i] != other.Value[i])
			{
				return false;
			}
		}
		return true;
	}

	public byte GetChannel(int channel)
	{
		if (channel < 0 || channel >= Value.Length)
		{
			return 0;
		}
		return Value[channel];
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public void Set(byte[] values)
	{
		if (values != null && values.Length == Value.Length)
		{
			Array.Copy(values, 0, Value, 0, Value.Length);
			UpdateCollection();
		}
	}

	public void SetChannel(int channel, byte value)
	{
		if (channel >= 0 && channel < Value.Length)
		{
			Value[channel] = value;
			UpdateCollection();
		}
	}

	public MagickColor ToColor()
	{
		byte[] valueWithoutIndexChannel = GetValueWithoutIndexChannel();
		if (valueWithoutIndexChannel.Length == 0)
		{
			return null;
		}
		if (valueWithoutIndexChannel.Length == 1)
		{
			return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[0], valueWithoutIndexChannel[0]);
		}
		if (valueWithoutIndexChannel.Length == 2)
		{
			return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[0], valueWithoutIndexChannel[0], valueWithoutIndexChannel[1]);
		}
		bool num = _collection != null && _collection.GetIndex(PixelChannel.Black) != -1;
		bool flag = _collection != null && _collection.GetIndex(PixelChannel.Alpha) != -1;
		if (num)
		{
			if (valueWithoutIndexChannel.Length == 4 || !flag)
			{
				return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[1], valueWithoutIndexChannel[2], valueWithoutIndexChannel[3], Quantum.Max);
			}
			return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[1], valueWithoutIndexChannel[2], valueWithoutIndexChannel[3], valueWithoutIndexChannel[4]);
		}
		if (valueWithoutIndexChannel.Length == 3 || !flag)
		{
			return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[1], valueWithoutIndexChannel[2]);
		}
		return new MagickColor(valueWithoutIndexChannel[0], valueWithoutIndexChannel[1], valueWithoutIndexChannel[2], valueWithoutIndexChannel[3]);
	}

	internal static Pixel Create(PixelCollection collection, int x, int y, byte[] value)
	{
		Pixel pixel = new Pixel(collection);
		pixel.Initialize(x, y, value);
		return pixel;
	}

	private static void CheckChannels(int channels)
	{
		Throw.IfTrue("channels", channels < 1 || channels > 5, "Invalid number of channels (supported sizes are 1-5).");
	}

	private byte[] GetValueWithoutIndexChannel()
	{
		if (_collection == null)
		{
			return Value;
		}
		int index = _collection.GetIndex(PixelChannel.Index);
		if (index == -1)
		{
			return Value;
		}
		List<byte> list = new List<byte>(Value);
		list.RemoveAt(index);
		return list.ToArray();
	}

	private void Initialize(int x, int y, byte[] value)
	{
		X = x;
		Y = y;
		Value = value;
	}

	private void UpdateCollection()
	{
		if (_collection != null)
		{
			_collection.SetPixelUnchecked(X, Y, Value);
		}
	}
}
