using System;
using System.Text;

namespace ImageMagick;

public sealed class IptcValue : IEquatable<IptcValue>
{
	private byte[] _data;

	private Encoding _encoding;

	public Encoding Encoding
	{
		get
		{
			return _encoding;
		}
		set
		{
			if (value != null)
			{
				_encoding = value;
			}
		}
	}

	public IptcTag Tag { get; private set; }

	public string Value
	{
		get
		{
			return _encoding.GetString(_data);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				_data = new byte[0];
			}
			else
			{
				_data = _encoding.GetBytes(value);
			}
		}
	}

	internal int Length => _data.Length;

	internal IptcValue(IptcTag tag, byte[] value)
	{
		Throw.IfNull("value", value);
		Tag = tag;
		_data = value;
		_encoding = Encoding.UTF8;
	}

	internal IptcValue(IptcTag tag, Encoding encoding, string value)
	{
		Tag = tag;
		_encoding = encoding;
		Value = value;
	}

	public static bool operator ==(IptcValue left, IptcValue right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(IptcValue left, IptcValue right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as IptcValue);
	}

	public bool Equals(IptcValue other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Tag != other.Tag)
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
		return _data.GetHashCode() ^ Tag.GetHashCode();
	}

	public byte[] ToByteArray()
	{
		byte[] array = new byte[_data.Length];
		_data.CopyTo(array, 0);
		return array;
	}

	public override string ToString()
	{
		return Value;
	}

	public string ToString(Encoding encoding)
	{
		Throw.IfNull("encoding", encoding);
		return encoding.GetString(_data);
	}
}
