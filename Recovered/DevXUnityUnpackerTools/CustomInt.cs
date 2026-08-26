using System;

internal struct CustomInt : IDisposable, IEquatable<CustomInt>
{
	internal int _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A;

	internal int _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A;

	internal bool _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A
	{
		get
		{
			return (_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A ^ _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A) == 111;
		}
		set
		{
			_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = ((value ? 111 : 100) ^ _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A);
		}
	}

	internal CustomInt(bool value = false)
	{
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A = _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020();
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = ((value ? 111 : 100) ^ _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A);
	}

	internal CustomInt(int endrypted_value, int secret)
	{
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A = secret;
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = endrypted_value;
	}

	public void Dispose()
	{
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A = 0;
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = 0;
	}

	public override string ToString()
	{
		return _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A.ToString();
	}

	public string ToString(IFormatProvider formatProvider)
	{
		return _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A.ToString(formatProvider);
	}

	public override int GetHashCode()
	{
		return _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is CustomInt)
		{
			CustomInt customInt = (CustomInt)obj;
			if (_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A == (customInt._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A ^ _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A ^ customInt._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A))
			{
				return true;
			}
			return false;
		}
		if (obj is bool)
		{
			bool flag = (bool)obj;
			if (_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A == flag)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	bool IEquatable<CustomInt>.Equals(CustomInt v)
	{
		return _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A == (v._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A ^ _0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A ^ v._0020_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A);
	}

	public static bool operator ==(CustomInt val1, CustomInt val2)
	{
		if ((object)val1 == null && (object)val2 == null)
		{
			return true;
		}
		return val1.Equals(val2);
	}

	public static bool operator !=(CustomInt val1, CustomInt val2)
	{
		if ((object)val1 == null && (object)val2 == null)
		{
			return false;
		}
		return !val1.Equals(val2);
	}

	public static bool operator ==(CustomInt val1, bool val2)
	{
		return val1.Equals(val2);
	}

	public static bool operator !=(CustomInt val1, bool val2)
	{
		return !val1.Equals(val2);
	}

	public static bool operator ==(bool val2, CustomInt val1)
	{
		return val1.Equals(val2);
	}

	public static bool operator !=(bool val2, CustomInt val1)
	{
		return !val1.Equals(val2);
	}

	public static CustomInt operator |(CustomInt f1, CustomInt f2)
	{
		return new CustomInt(f1._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A | f2._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A);
	}

	public static CustomInt operator &(CustomInt f1, CustomInt f2)
	{
		return new CustomInt(f1._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A & f2._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A);
	}

	public static CustomInt operator ^(CustomInt f1, CustomInt f2)
	{
		return new CustomInt(f1._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A ^ f2._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A);
	}

	public static CustomInt operator !(CustomInt f1)
	{
		return new CustomInt(!f1._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A);
	}

	public static implicit operator bool(CustomInt d)
	{
		return d._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;
	}

	public static implicit operator CustomInt(bool d)
	{
		return new CustomInt(d);
	}
}
