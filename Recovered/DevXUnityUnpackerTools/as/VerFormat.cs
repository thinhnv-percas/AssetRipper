using System;

namespace @as
{
	internal class VerFormat
	{
		internal int i1;

		internal int i2;

		internal int? i3;

		internal string _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A;

		internal string _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020;

		internal VerFormat(int major, int minor, byte? path = default(byte?), string build = null)
		{
			i1 = major;
			i2 = minor;
			if (i3.HasValue)
			{
				i3 = i3.Value;
			}
			_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A = build;
		}

		internal VerFormat(string version)
		{
			try
			{
				if (version.Contains("."))
				{
					string[] array = version.Split('.');
					i1 = _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(array[0]);
					i2 = _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(array[1]);
					if (array.Length >= 3 && array[2].Length > 0)
					{
						string obj = array[2];
						string text = "";
						_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A = "";
						bool flag = true;
						string text2 = obj;
						for (int i = 0; i < text2.Length; i++)
						{
							char c = text2[i];
							if ((flag && char.IsDigit(c)) || c == 'x' || c == 'X')
							{
								text += c.ToString();
							}
							else
							{
								flag = false;
								_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A += c.ToString();
							}
						}
						i3 = (byte)_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(text);
					}
				}
				else
				{
					i1 = _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(version.Substring(0, 1));
					i2 = _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(version.Substring(2, 3));
					string text3 = version.Substring(4);
					if (text3.Length > 0)
					{
						string text4 = "";
						_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A = "";
						bool flag2 = true;
						string text2 = text3;
						for (int i = 0; i < text2.Length; i++)
						{
							char c2 = text2[i];
							if ((flag2 && char.IsDigit(c2)) || c2 == 'x' || c2 == 'X')
							{
								text4 += c2.ToString();
							}
							else
							{
								flag2 = false;
								_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A += c2.ToString();
							}
						}
						i3 = (byte)_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(text4);
					}
				}
			}
			catch (Exception)
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 = version;
			}
		}

		internal VerFormat()
		{
			string text = "1.0.0f1";
			try
			{
				i1 = 1;
				i2 = 0;
				i3 = 0;
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A = "f1";
			}
			catch (Exception)
			{
				_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 = text;
			}
		}

		private int _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(string _0020)
		{
			if (_0020.Equals("x"))
			{
				return -1;
			}
			return int.Parse(_0020);
		}

		private string _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(int _0020)
		{
			if (_0020 == -1)
			{
				return "x";
			}
			return _0020.ToString();
		}

		internal bool _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020()
		{
			return true;
		}

		public override string ToString()
		{
			if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 != null)
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020;
			}
			return _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i1) + "." + _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i2) + "." + _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i3.HasValue ? i3.Value : 0) + _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A;
		}

		internal string _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A()
		{
			return _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i1) + "." + _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i2);
		}

		internal string ToStr()
		{
			return _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i1) + "." + _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i2) + "." + _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A(i3.HasValue ? i3.Value : 0);
		}

		internal int _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020()
		{
			if (_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 != null)
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A();
			}
			int num = 5;
			num = 97 * num + i1;
			num = 97 * num + i2;
			num = 97 * num + (i3.HasValue ? i3.Value : 0);
			return 97 * num + _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A();
		}

		public override int GetHashCode()
		{
			return _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020();
		}

		public bool IsEqual(int major, int minor, string build)
		{
			if (i1 == major && i2 == minor)
			{
				return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A == build;
			}
			return false;
		}

		public bool IsEqual(int major, int minor)
		{
			if (i1 == major)
			{
				return i2 == minor;
			}
			return false;
		}

		public bool IsEqual(int major)
		{
			return i1 == major;
		}

		public bool IsLess(int major, int minor = 0)
		{
			return this < new VerFormat(major, minor);
		}

		public bool IsGreaterEqual(int major, int minor = 0)
		{
			return this >= new VerFormat(major, minor);
		}

		public bool IsGreater(int major, int minor = 0)
		{
			return this > new VerFormat(major, minor);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is VerFormat))
			{
				return false;
			}
			VerFormat _0020 = (VerFormat)obj;
			if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(_0020) == 0)
			{
				return true;
			}
			return false;
		}

		internal int _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(VerFormat _0020)
		{
			if (i1 < _0020.i1)
			{
				return 1;
			}
			if (i1 > _0020.i1)
			{
				return -1;
			}
			if (i2 < _0020.i2)
			{
				return 1;
			}
			if (i2 > _0020.i2)
			{
				return -1;
			}
			if (i3.HasValue && _0020.i3.HasValue)
			{
				if (i3.Value < _0020.i3.Value)
				{
					return 1;
				}
				if (i3.Value > _0020.i3.Value)
				{
					return -1;
				}
			}
			if (_0020._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A == null || _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A == null)
			{
				return 0;
			}
			return _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A.CompareTo(_0020._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A);
		}

		internal bool _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A(VerFormat _0020)
		{
			return _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(_0020) == 1;
		}

		internal bool _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020(VerFormat _0020)
		{
			return _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(_0020) >= 0;
		}

		internal bool _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A(VerFormat _0020)
		{
			return _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(_0020) == -1;
		}

		internal bool _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020(VerFormat _0020)
		{
			return _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020(_0020) <= 0;
		}

		public static bool operator ==(VerFormat val1, VerFormat val2)
		{
			if ((object)val1 == null && (object)val2 == null)
			{
				return true;
			}
			return val1.Equals(val2);
		}

		public static bool operator !=(VerFormat val1, VerFormat val2)
		{
			if ((object)val1 == null && (object)val2 == null)
			{
				return false;
			}
			return !val1.Equals(val2);
		}

		public static bool operator >(VerFormat f1, VerFormat f2)
		{
			return f1._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A(f2);
		}

		public static bool operator <(VerFormat f1, VerFormat f2)
		{
			return f1._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A(f2);
		}

		public static bool operator <=(VerFormat f1, VerFormat f2)
		{
			return f1._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020(f2);
		}

		public static bool operator >=(VerFormat f1, VerFormat f2)
		{
			return f1._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020(f2);
		}
	}
}
