using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EdiTools
{
	public abstract class EdiValue
	{
		public abstract string Value
		{
			get;
			set;
		}

		public DateTime DateValue
		{
			get
			{
				string text = Regex.Replace(Value, "[^0-9]", string.Empty);
				string format;
				if (text.Length == 6)
				{
					format = "yyMMdd";
				}
				else
				{
					if (text.Length != 8)
					{
						throw new FormatException();
					}
					format = "yyyyMMdd";
				}
				return DateTime.ParseExact(text, format, null);
			}
		}

		public DateTime TimeValue
		{
			get
			{
				string text = Regex.Replace(Value, "[^0-9]", string.Empty);
				string format;
				if (text.Length == 4)
				{
					format = "HHmm";
				}
				else
				{
					if (text.Length < 6)
					{
						throw new FormatException();
					}
					format = "HHmmss".PadRight(text.Length, 'f');
				}
				return DateTime.ParseExact(text, format, null);
			}
		}

		public decimal RealValue
		{
			get
			{
				string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
				return decimal.Parse(Regex.Replace(Value, "[^-0-9" + Regex.Escape(numberDecimalSeparator) + "]", numberDecimalSeparator));
			}
		}

		public string IsoDate => DateValue.ToString("yyyy-MM-dd");

		public string IsoTime
		{
			get
			{
				string text = Regex.Replace(Value, "[^0-9]", string.Empty);
				if (text.Length == 4)
				{
					return DateTime.ParseExact(text, "HHmm", null).ToString("HH:mm");
				}
				if (text.Length == 6)
				{
					return DateTime.ParseExact(text, "HHmmss", null).ToString("HH:mm:ss");
				}
				if (text.Length > 6)
				{
					string str = string.Empty.PadLeft(text.Length - 6, 'f');
					return DateTime.ParseExact(text, "HHmmss" + str, null).ToString("HH:mm:ss." + str);
				}
				throw new FormatException();
			}
		}

		public static string Date(int length, DateTime value)
		{
			switch (length)
			{
			case 6:
				return value.ToString("yyMMdd");
			case 8:
				return value.ToString("yyyyMMdd");
			default:
				throw new ArgumentOutOfRangeException("length");
			}
		}

		public static string Time(int length, DateTime value)
		{
			if (length == 4)
			{
				return value.ToString("HHmm");
			}
			if (length >= 6)
			{
				string format = "HHmmss".PadRight(length, 'f');
				return value.ToString(format);
			}
			throw new ArgumentOutOfRangeException("length");
		}

		public static string Numeric(int decimals, decimal value)
		{
			string text = Math.Abs(value).ToString("f" + decimals, CultureInfo.InvariantCulture).Replace(".", string.Empty)
				.TrimStart('0');
			if (text == string.Empty)
			{
				return "0";
			}
			if (value < decimal.Zero)
			{
				return "-" + text;
			}
			return text;
		}

		public static string Real(decimal value)
		{
			string text = value.ToString(CultureInfo.InvariantCulture);
			if (text.Contains("."))
			{
				text = text.TrimEnd('0').TrimEnd('.');
			}
			return text;
		}

		public decimal NumericValue(int decimals)
		{
			string text = Regex.Replace(Value, "[^-0-9]", string.Empty).PadLeft(decimals + 1, '0');
			int num = text.Length - decimals;
			return decimal.Parse(text.Substring(0, num) + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator + text.Substring(num));
		}
	}
}
