using System;
using System.Globalization;

namespace Humanizer.Bytes;

public struct ByteSize : IComparable<ByteSize>, IEquatable<ByteSize>, IComparable
{
	public static readonly ByteSize MinValue = FromBits(long.MinValue);

	public static readonly ByteSize MaxValue = FromBits(long.MaxValue);

	public const long BitsInByte = 8L;

	public const long BytesInKilobyte = 1024L;

	public const long BytesInMegabyte = 1048576L;

	public const long BytesInGigabyte = 1073741824L;

	public const long BytesInTerabyte = 1099511627776L;

	public const string BitSymbol = "b";

	public const string ByteSymbol = "B";

	public const string KilobyteSymbol = "KB";

	public const string MegabyteSymbol = "MB";

	public const string GigabyteSymbol = "GB";

	public const string TerabyteSymbol = "TB";

	public long Bits { get; private set; }

	public double Bytes { get; private set; }

	public double Kilobytes { get; private set; }

	public double Megabytes { get; private set; }

	public double Gigabytes { get; private set; }

	public double Terabytes { get; private set; }

	public string LargestWholeNumberSymbol
	{
		get
		{
			if (Math.Abs(Terabytes) >= 1.0)
			{
				return "TB";
			}
			if (Math.Abs(Gigabytes) >= 1.0)
			{
				return "GB";
			}
			if (Math.Abs(Megabytes) >= 1.0)
			{
				return "MB";
			}
			if (Math.Abs(Kilobytes) >= 1.0)
			{
				return "KB";
			}
			if (Math.Abs(Bytes) >= 1.0)
			{
				return "B";
			}
			return "b";
		}
	}

	public double LargestWholeNumberValue
	{
		get
		{
			if (Math.Abs(Terabytes) >= 1.0)
			{
				return Terabytes;
			}
			if (Math.Abs(Gigabytes) >= 1.0)
			{
				return Gigabytes;
			}
			if (Math.Abs(Megabytes) >= 1.0)
			{
				return Megabytes;
			}
			if (Math.Abs(Kilobytes) >= 1.0)
			{
				return Kilobytes;
			}
			if (Math.Abs(Bytes) >= 1.0)
			{
				return Bytes;
			}
			return Bits;
		}
	}

	public ByteSize(double byteSize)
	{
		this = default(ByteSize);
		Bits = (long)Math.Ceiling(byteSize * 8.0);
		Bytes = byteSize;
		Kilobytes = byteSize / 1024.0;
		Megabytes = byteSize / 1048576.0;
		Gigabytes = byteSize / 1073741824.0;
		Terabytes = byteSize / 1099511627776.0;
	}

	public static ByteSize FromBits(long value)
	{
		return new ByteSize((double)value / 8.0);
	}

	public static ByteSize FromBytes(double value)
	{
		return new ByteSize(value);
	}

	public static ByteSize FromKilobytes(double value)
	{
		return new ByteSize(value * 1024.0);
	}

	public static ByteSize FromMegabytes(double value)
	{
		return new ByteSize(value * 1048576.0);
	}

	public static ByteSize FromGigabytes(double value)
	{
		return new ByteSize(value * 1073741824.0);
	}

	public static ByteSize FromTerabytes(double value)
	{
		return new ByteSize(value * 1099511627776.0);
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", new object[2] { LargestWholeNumberValue, LargestWholeNumberSymbol });
	}

	public string ToString(string format)
	{
		if (!format.Contains("#") && !format.Contains("0"))
		{
			format = "0.## " + format;
		}
		Func<string, bool> func = (string s) => format.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1;
		Func<double, string> func2 = (double n) => n.ToString(format);
		if (func("TB"))
		{
			return func2(Terabytes);
		}
		if (func("GB"))
		{
			return func2(Gigabytes);
		}
		if (func("MB"))
		{
			return func2(Megabytes);
		}
		if (func("KB"))
		{
			return func2(Kilobytes);
		}
		if (format.IndexOf("B", StringComparison.Ordinal) != -1)
		{
			return func2(Bytes);
		}
		if (format.IndexOf("b", StringComparison.Ordinal) != -1)
		{
			return func2(Bits);
		}
		string text = LargestWholeNumberValue.ToString(format);
		text = (text.Equals(string.Empty) ? "0" : text);
		return string.Format("{0} {1}", new object[2] { text, LargestWholeNumberSymbol });
	}

	public override bool Equals(object value)
	{
		if (value == null)
		{
			return false;
		}
		if (!(value is ByteSize value2))
		{
			return false;
		}
		return Equals(value2);
	}

	public bool Equals(ByteSize value)
	{
		return Bits == value.Bits;
	}

	public override int GetHashCode()
	{
		return Bits.GetHashCode();
	}

	public int CompareTo(object obj)
	{
		if (obj == null)
		{
			return 1;
		}
		if (!(obj is ByteSize))
		{
			throw new ArgumentException("Object is not a ByteSize");
		}
		return CompareTo((ByteSize)obj);
	}

	public int CompareTo(ByteSize other)
	{
		return Bits.CompareTo(other.Bits);
	}

	public ByteSize Add(ByteSize bs)
	{
		return new ByteSize(Bytes + bs.Bytes);
	}

	public ByteSize AddBits(long value)
	{
		return this + FromBits(value);
	}

	public ByteSize AddBytes(double value)
	{
		return this + FromBytes(value);
	}

	public ByteSize AddKilobytes(double value)
	{
		return this + FromKilobytes(value);
	}

	public ByteSize AddMegabytes(double value)
	{
		return this + FromMegabytes(value);
	}

	public ByteSize AddGigabytes(double value)
	{
		return this + FromGigabytes(value);
	}

	public ByteSize AddTerabytes(double value)
	{
		return this + FromTerabytes(value);
	}

	public ByteSize Subtract(ByteSize bs)
	{
		return new ByteSize(Bytes - bs.Bytes);
	}

	public static ByteSize operator +(ByteSize b1, ByteSize b2)
	{
		return new ByteSize(b1.Bytes + b2.Bytes);
	}

	public static ByteSize operator ++(ByteSize b)
	{
		return new ByteSize(b.Bytes + 1.0);
	}

	public static ByteSize operator -(ByteSize b)
	{
		return new ByteSize(0.0 - b.Bytes);
	}

	public static ByteSize operator --(ByteSize b)
	{
		return new ByteSize(b.Bytes - 1.0);
	}

	public static bool operator ==(ByteSize b1, ByteSize b2)
	{
		return b1.Bits == b2.Bits;
	}

	public static bool operator !=(ByteSize b1, ByteSize b2)
	{
		return b1.Bits != b2.Bits;
	}

	public static bool operator <(ByteSize b1, ByteSize b2)
	{
		return b1.Bits < b2.Bits;
	}

	public static bool operator <=(ByteSize b1, ByteSize b2)
	{
		return b1.Bits <= b2.Bits;
	}

	public static bool operator >(ByteSize b1, ByteSize b2)
	{
		return b1.Bits > b2.Bits;
	}

	public static bool operator >=(ByteSize b1, ByteSize b2)
	{
		return b1.Bits >= b2.Bits;
	}

	public static bool TryParse(string s, out ByteSize result)
	{
		if (string.IsNullOrWhiteSpace(s))
		{
			throw new ArgumentNullException("s", "String is null or whitespace");
		}
		result = default(ByteSize);
		s = s.TrimStart(new char[0]);
		bool flag = false;
		char c = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
		int i;
		for (i = 0; i < s.Length; i++)
		{
			if (!char.IsDigit(s[i]) && s[i] != c)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return false;
		}
		int num = i;
		string s2 = s.Substring(0, num).Trim();
		string text = s.Substring(num, s.Length - num).Trim();
		if (!double.TryParse(s2, out var result2))
		{
			return false;
		}
		switch (text.ToUpper())
		{
		case "B":
			if (text == "b")
			{
				if (result2 % 1.0 != 0.0)
				{
					return false;
				}
				result = FromBits((long)result2);
			}
			else
			{
				result = FromBytes(result2);
			}
			break;
		case "KB":
			result = FromKilobytes(result2);
			break;
		case "MB":
			result = FromMegabytes(result2);
			break;
		case "GB":
			result = FromGigabytes(result2);
			break;
		case "TB":
			result = FromTerabytes(result2);
			break;
		}
		return true;
	}

	public static ByteSize Parse(string s)
	{
		if (TryParse(s, out var result))
		{
			return result;
		}
		throw new FormatException("Value is not in the correct format");
	}
}
