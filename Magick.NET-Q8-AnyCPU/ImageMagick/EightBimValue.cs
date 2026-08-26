using System;
using System.Text;

namespace ImageMagick;

public sealed class EightBimValue : IEquatable<EightBimValue>
{
	private readonly byte[] _data;

	public short ID { get; private set; }

	internal EightBimValue(short id, byte[] data)
	{
		ID = id;
		_data = data;
	}

	public static bool operator ==(EightBimValue left, EightBimValue right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(EightBimValue left, EightBimValue right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as EightBimValue);
	}

	public bool Equals(EightBimValue other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (ID != other.ID)
		{
			return false;
		}
		if (_data == null)
		{
			return other._data == null;
		}
		if (other._data == null)
		{
			return false;
		}
		if (_data.Length != other._data.Length)
		{
			return false;
		}
		for (int i = 0; i < _data.Length; i++)
		{
			if (_data[i] != other._data[i])
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return _data.GetHashCode() ^ ID.GetHashCode();
	}

	public byte[] ToByteArray()
	{
		byte[] array = new byte[_data.Length];
		Array.Copy(_data, 0, array, 0, _data.Length);
		return array;
	}

	public override string ToString()
	{
		return ToString(Encoding.UTF8);
	}

	public string ToString(Encoding encoding)
	{
		Throw.IfNull("encoding", encoding);
		return encoding.GetString(_data);
	}
}
