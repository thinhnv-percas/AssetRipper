using System;

namespace ARMD
{
	public static class Disassembler
	{
		internal static int? _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020;

		internal static int? _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A;

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(uint _0020)
		{
			switch (_0020)
			{
			case 2u:
				return "OSHST";
			case 3u:
				return "OSH";
			case 6u:
				return "NSHST";
			case 7u:
				return "NSH";
			case 10u:
				return "ISHST";
			case 11u:
				return "ISH";
			case 14u:
				return "ST";
			case 15u:
				return "SY";
			default:
				return "Invalid barrier option.";
			}
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020(uint _0020)
		{
			uint num = _0020.ExtractBits(4, 5);
			string str = _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(_0020.ExtractBits(0, 3));
			switch (num)
			{
			case 0u:
				return "DSB " + str;
			case 1u:
				return "DMB " + str;
			case 2u:
				return "ISB " + str;
			default:
				return "Invalid barrier instruction";
			}
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			uint num = _0020.ExtractBits(0, 3);
			uint num2 = _0020.ExtractBits(7, 11);
			uint num3 = _0020.ExtractBits(16, 20) - num2 + 1;
			if (num == 15)
			{
				return $"BFC{text} {text2}, #{num2}, #{num3}";
			}
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			return $"BFI{text} {text2}, {text3}, #{num2}, #{num3}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBits(7, 11);
			uint num2 = _0020.ExtractBits(16, 20) + 1;
			string text4 = _0020.IsBitSet(22) ? "UBFX" : "SBFX";
			return $"{text4}{text} {text2}, {text3}, #{num}, #{num2}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			int num = (int)((_0020.ExtractBits(0, 23) << 2).SignExtend(26) + 8);
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 = num;
			return $"B{arg} {num.SignBitToChar()}#0x{Math.Abs(num):X8}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020(uint _0020)
		{
			if (((int)_0020 & -268435456) == -268435456)
			{
				uint num = _0020.ExtractBit(24);
				int num2 = (int)(((_0020.ExtractBits(0, 23) << 2) | (num << 1)).SignExtend(26) + 8);
				_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 = num2;
				return $"BLX {num2.SignBitToChar()}#0x{Math.Abs(num2):X8}";
			}
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			int num3 = (int)((_0020.ExtractBits(0, 23) << 2).SignExtend(26) + 8);
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 = num3;
			return $"BL{arg} {num3.SignBitToChar()}#0x{Math.Abs(num3):X8}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string str2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "BLX" + str + " " + str2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string str2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "BX" + str + " " + str2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string str2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "BXJ" + str + " " + str2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020(uint _0020)
		{
			if (_0020.ExtractBits(28, 31) == 15)
			{
				return "2";
			}
			return _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020(_0020);
			uint num = _0020.ExtractBits(20, 23);
			uint num2 = _0020.ExtractBits(5, 7);
			uint num3 = _0020.ExtractBits(12, 15);
			uint num4 = _0020.ExtractBits(0, 3);
			uint num5 = _0020.ExtractBits(16, 19);
			uint num6 = _0020.ExtractBits(8, 11);
			string text2 = (num2 == 0) ? "" : $", {{{num2}}}";
			return $"CDP{text} p{num6}, {num}, cr{num3}, cr{num5}, cr{num4}{text2}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint num = _0020.ExtractBits(12, 15);
			uint num2 = _0020.ExtractBits(8, 11);
			uint num3 = _0020.ExtractBits(0, 7) << 2;
			bool num4 = _0020.IsBitSet(24);
			bool flag = _0020.IsBitSet(23);
			string text3 = flag ? "" : "-";
			string text4 = _0020.IsBitSet(22) ? "L" : "";
			bool flag2 = _0020.IsBitSet(21);
			string text5 = _0020.IsBitSet(20) ? "LDC" : "STC";
			string text6 = "";
			if (num4)
			{
				if (flag2)
				{
					text6 = $"[{text2}, #{text3}{num3}]!";
				}
				else
				{
					string str = (num3 == 0) ? "" : $", #{text3}{num3}";
					text6 = "[" + text2 + str + "]";
				}
			}
			else if (flag2)
			{
				text6 = $"[{text2}], #{text3}{num3}";
			}
			else if (flag)
			{
				text6 = $"[{text2}], {{{num3}}}";
			}
			return $"{text5}{text}{text4} p{num2}, cr{num}, {text6}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020(_0020);
			uint num = _0020.ExtractBits(21, 23);
			uint num2 = _0020.ExtractBits(5, 7);
			uint num3 = _0020.ExtractBits(0, 3);
			uint num4 = _0020.ExtractBits(16, 19);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			uint num5 = _0020.ExtractBits(8, 11);
			string text3 = _0020.IsBitSet(20) ? "MRC" : "MCR";
			string text4 = (num2 == 0) ? "" : $", {{{num2}}}";
			return $"{text3}{text} p{num5}, {num}, {text2}, cr{num4}, cr{num3}{text4}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020(_0020);
			uint num = _0020.ExtractBits(4, 7);
			uint num2 = _0020.ExtractBits(0, 3);
			uint num3 = _0020.ExtractBits(8, 11);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text4 = _0020.IsBitSet(20) ? "MRRC" : "MCRR";
			return $"{text4}{text} p{num3}, {num}, {text2}, {text3}, cr{num2}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			uint num = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ExpandARMImmediate(_0020_000A.ExtractBits(0, 11));
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			string text4 = _0020_000A.IsBitSet(20) ? "S" : "";
			return $"{_0020}{text4}{text} {text2}, {text3}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			uint num = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ExpandARMImmediate(_0020_000A.ExtractBits(0, 11));
			return $"{_0020}{text} {text2}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			uint num = (_0020_000A.ExtractBits(16, 19) << 12) | _0020_000A.ExtractBits(0, 11);
			return $"{_0020}{text} {text2}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			string text5 = _0020_000A.IsBitSet(20) ? "S" : "";
			uint immediate = _0020_000A.ExtractBits(7, 11);
			string text6 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(_0020_000A.ExtractBits(5, 6), immediate);
			return _0020 + text5 + text + " " + text3 + ", " + text2 + ", " + text4 + text6;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			uint immediate = _0020_000A.ExtractBits(7, 11);
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(_0020_000A.ExtractBits(5, 6), immediate);
			return _0020 + text + " " + text2 + ", " + text3 + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			string text5 = _0020_000A.IsBitSet(20) ? "S" : "";
			uint register = _0020_000A.ExtractBits(8, 11);
			string text6 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRegisterShift(_0020_000A.ExtractBits(5, 6), register);
			return _0020 + text5 + text + " " + text2 + ", " + text4 + ", " + text3 + text6;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			uint register = _0020_000A.ExtractBits(8, 11);
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRegisterShift(_0020_000A.ExtractBits(5, 6), register);
			return _0020 + text + " " + text3 + ", " + text2 + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			uint num = _0020_000A.ExtractBits(5, 6);
			uint num2 = _0020_000A.ExtractBits(7, 11);
			string text4 = _0020_000A.IsBitSet(20) ? "S" : "";
			if (num == 2 && num2 == 0)
			{
				num2 = 32u;
			}
			return $"{_0020}{text4}{text} {text2}, {text3}, #{num2}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(0, 3));
			string text5 = _0020_000A.IsBitSet(20) ? "S" : "";
			return _0020 + text5 + text + " " + text2 + ", " + text4 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("ADC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("ADC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("ADC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("ADD", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("ADD", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("ADD", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("AND", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("AND", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("AND", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020("ASR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A("ASR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("BIC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("BIC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("BIC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020("CMN", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A("CMN", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A("CMN", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020("CMP", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A("CMP", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A("CMP", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("EOR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("EOR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("EOR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020("LSL", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A("LSL", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020("LSR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A("LSR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020.IsBitSet(20) ? "S" : "";
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			uint num = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ExpandARMImmediate(_0020.ExtractBits(0, 11));
			return $"MOV{text2}{text} {text3}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020.IsBitSet(20) ? "S" : "";
			return "MOV" + text4 + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A("MOVT", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A("MOVW", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			uint num = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ExpandARMImmediate(_0020.ExtractBits(0, 11));
			string text3 = _0020.IsBitSet(20) ? "S" : "";
			return $"MVN{text3}{text} {text2}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint immediate = _0020.ExtractBits(7, 11);
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(_0020.ExtractBits(5, 6), immediate);
			string text5 = _0020.IsBitSet(20) ? "S" : "";
			return "MVN" + text5 + text + " " + text2 + ", " + text3 + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020.IsBitSet(20) ? "S" : "";
			uint register = _0020.ExtractBits(8, 11);
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRegisterShift(_0020.ExtractBits(5, 6), register);
			return "MVN" + text4 + text + " " + text2 + ", " + text3 + text5;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("ORR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("ORR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("ORR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020("ROR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A("ROR", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020.IsBitSet(20) ? "S" : "";
			return "RRX" + text4 + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("RSB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("RSB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("RSB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("RSC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("RSC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("RSC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("SBC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("SBC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("SBC", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A("SUB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020("SUB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020("SUB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020("TEQ", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A("TEQ", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A("TEQ", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020("TST", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A("TST", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A("TST", _0020);
		}

		public static string Disassemble(uint opcode)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 = null;
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A = null;
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A.Decode(opcode);
			if (_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.IsValid && _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.DisassemblyFunction != null)
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A.DisassemblyFunction(opcode);
			}
			return $"Invalid opcode: 0x{opcode:X8}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020(uint _0020)
		{
			string text = _0020.IsBitSet(21) ? "UDIV" : "SDIV";
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return text + text2 + " " + text3 + ", " + text5 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(uint _0020)
		{
			switch (_0020)
			{
			case 0u:
				return "";
			case 1u:
				return ", ROR #8";
			case 2u:
				return ", ROR #16";
			case 3u:
				return ", ROR #24";
			default:
				throw new ArgumentException("Invalid rotation value.", "rotation");
			}
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(_0020.ExtractBits(10, 11));
			uint num = _0020.ExtractBits(20, 22);
			string text5 = "";
			switch (num)
			{
			case 0u:
				text5 = "SXTB16";
				break;
			case 2u:
				text5 = "SXTB";
				break;
			case 3u:
				text5 = "SXTH";
				break;
			case 4u:
				text5 = "UXTB16";
				break;
			case 6u:
				text5 = "UXTB";
				break;
			case 7u:
				text5 = "UXTH";
				break;
			}
			return text5 + text + " " + text2 + ", " + text3 + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text5 = _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(_0020.ExtractBits(10, 11));
			uint num = _0020.ExtractBits(20, 22);
			string text6 = "";
			switch (num)
			{
			case 0u:
				text6 = "SXTAB16";
				break;
			case 2u:
				text6 = "SXTAB";
				break;
			case 3u:
				text6 = "SXTAH";
				break;
			case 4u:
				text6 = "UXTAB16";
				break;
			case 6u:
				text6 = "UXTAB";
				break;
			case 7u:
				text6 = "UXTAH";
				break;
			}
			return text6 + text + " " + text2 + ", " + text4 + ", " + text3 + text5;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBit(5);
			uint num2 = _0020.ExtractBits(21, 22);
			char c = (num == 1) ? 'T' : 'B';
			char c2 = _0020.IsBitSet(6) ? 'T' : 'B';
			switch (num2)
			{
			case 3u:
				return $"SMUL{c}{c2}{text} {text2}, {text4}, {text3}";
			case 1u:
				if (num == 1)
				{
					return $"SMULW{c2}{text} {text2}, {text4}, {text3}";
				}
				break;
			}
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			if (num2 == 1 && num == 0)
			{
				return $"SMLAW{c2}{text} {text2}, {text4}, {text3}, {text5}";
			}
			if (num2 == 0)
			{
				return $"SMLA{c}{c2}{text} {text2}, {text4}, {text3}, {text5}";
			}
			return $"SMLAL{c}{c2}{text} {text5}, {text2}, {text4}, {text3}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(0, 3);
			return $"DBG{arg} #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "NOP" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A(uint _0020)
		{
			uint num = _0020.ExtractBits(0, 11);
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text2 = _0020.IsBitSet(22) ? "" : "W";
			char c = _0020.IsBitSet(23) ? '+' : '-';
			return $"PLD{text2} [{text}, #{c}0x{num:X3}]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020.IsBitSet(22) ? "" : "W";
			char c = _0020.IsBitSet(23) ? '+' : '-';
			uint type = _0020.ExtractBits(5, 6);
			uint immediate = _0020.ExtractBits(7, 11);
			return $"PLD{text3} [{text2}, {c}{text}{_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(type, immediate)}]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A(uint _0020)
		{
			uint num = _0020.ExtractBits(0, 11);
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			char c = _0020.IsBitSet(23) ? '+' : '-';
			return $"PLI [{arg}, #{c}0x{num:X3}]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint immediate = _0020.ExtractBits(7, 11);
			uint type = _0020.ExtractBits(5, 6);
			char c = _0020.IsBitSet(23) ? '+' : '-';
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(type, immediate);
			return $"PLI [{text2}, {c}{text}{text3}]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "SEV" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "WFE" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_000A(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "WFI" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "YIELD" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(uint _0020)
		{
			bool num = _0020.IsBitSet(24);
			bool flag = _0020.IsBitSet(23);
			bool flag2 = _0020.IsBitSet(21);
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text2 = flag ? "" : "-";
			bool num2 = (_0020 & 0xC000000) == 0;
			uint num3 = 0u;
			num3 = ((!num2) ? _0020.ExtractBits(0, 11) : ((_0020.ExtractBits(8, 11) << 4) | _0020.ExtractBits(0, 3)));
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A = (int)(flag ? num3 : (0 - num3));
			if (num)
			{
				if (flag2)
				{
					return $"[{text}, #{text2}{num3}]!";
				}
				string str = (num3 == 0) ? "" : $", #{text2}{num3}";
				return "[" + text + str + "]";
			}
			string str2 = (num3 == 0) ? "" : $", #{text2}{num3}";
			return "[" + text + "]" + str2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(uint _0020)
		{
			bool num = _0020.IsBitSet(24);
			bool num2 = _0020.IsBitSet(23);
			bool flag = _0020.IsBitSet(21);
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = num2 ? "" : "-";
			bool num3 = (_0020 & 0xC000000) == 0;
			string text4 = "";
			if (!num3)
			{
				text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(immediate: _0020.ExtractBits(7, 11), type: _0020.ExtractBits(5, 6));
			}
			if (num)
			{
				string text5 = flag ? "!" : "";
				return "[" + text2 + ", " + text3 + text + text4 + "]" + text5;
			}
			return "[" + text2 + "], " + text3 + text + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDR" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDR" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
			return "LDRD" + text + " " + text2 + ", " + text3 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
			return "LDRD" + text + " " + text2 + ", " + text3 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "LDRSHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STR" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STR" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRB" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRBT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
			return "STRD" + text + " " + text2 + ", " + text3 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
			return "STRD" + text + " " + text2 + ", " + text3 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRH" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			return "STRHT" + text + " " + text2 + ", " + _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A(string _0020, uint _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020_000A);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020_000A.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRegisterList(_0020_000A);
			string text4 = _0020_000A.IsBitSet(21) ? "!" : "";
			return _0020 + text + " " + text2 + text4 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("LDMDA", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("LDMDB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("LDMIA", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("LDMIB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("STMDA", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("STMDB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("STMIA", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A("STMIB", _0020);
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = (_0020.ExtractBits(8, 19) << 4) | _0020.ExtractBits(0, 3);
			return $"BKPT{arg} #0x{num:X4}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A(uint _0020)
		{
			return "CLREX";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "CLZ" + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020.IsBitSet(8) ? "A" : "";
			string text2 = _0020.IsBitSet(7) ? "I" : "";
			string text3 = _0020.IsBitSet(6) ? "F" : "";
			bool flag = _0020.IsBitSet(17);
			uint num = _0020.ExtractBits(18, 19);
			string text4 = "";
			switch (num)
			{
			case 2u:
				text4 = "IE";
				break;
			case 3u:
				text4 = "ID";
				break;
			}
			uint num2 = _0020.ExtractBits(0, 4);
			string text5 = "";
			text5 = ((flag && num == 0) ? $"#{num2}" : (flag ? $", #{num2}" : ""));
			return "CPS" + text4 + " " + text + text2 + text3 + text5;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(uint _0020)
		{
			string str = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			return "ERET" + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = (_0020.ExtractBits(8, 19) << 4) | _0020.ExtractBits(0, 3);
			return $"HVC{arg} #0x{num:X4}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020.IsBitSet(22) ? "SPSR" : "CPSR";
			return "MRS" + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			bool readSPSR = _0020.IsBitSet(22);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeBankedRegister((_0020.ExtractBit(8) << 4) | _0020.ExtractBits(16, 19), readSPSR);
			return "MRS" + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ExpandARMImmediate(_0020.ExtractBits(0, 11));
			string arg2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeMSRMask(_0020);
			return $"MSR{arg} {arg2}, #0x{num:X}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeMSRMask(_0020);
			return "MSR" + text + " " + text3 + ", " + text2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			bool readSPSR = _0020.IsBitSet(22);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeBankedRegister((_0020.ExtractBit(8) << 4) | _0020.ExtractBits(16, 19), readSPSR);
			return "MSR" + text + " " + text3 + ", " + text2;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			return "QADD" + text + " " + text2 + ", " + text3 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			return "QDADD" + text + " " + text2 + ", " + text3 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			return "QSUB" + text + " " + text2 + ", " + text3 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			return "QDSUB" + text + " " + text2 + ", " + text3 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A(uint _0020)
		{
			string text = _0020.IsBitSet(21) ? "!" : "";
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRFSOrSRSAccessMode(_0020);
			return "RFE" + text3 + " " + text2 + text;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020(uint _0020)
		{
			string str = _0020.IsBitSet(9) ? "BE" : "LE";
			return "SETEND " + str;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(0, 3);
			return $"SMC{arg} #0x{num:X}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020(uint _0020)
		{
			string arg = _0020.IsBitSet(21) ? "1" : "";
			string arg2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeRFSOrSRSAccessMode(_0020);
			uint num = _0020.ExtractBits(0, 3);
			return $"SRS{arg2}, sp{arg}, #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A(uint _0020)
		{
			string arg = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(0, 23);
			return $"SVC{arg} #0x{num:X}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020(uint _0020)
		{
			uint num = (_0020.ExtractBits(8, 19) << 4) | _0020.ExtractBits(0, 3);
			return $"UDF #{num}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint num = _0020.ExtractBits(12, 15);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text5 = _0020.IsBitSet(20) ? "S" : "";
			if (num == 0)
			{
				return "MUL" + text5 + text + " " + text2 + ", " + text4 + ", " + text3;
			}
			string text6 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			if (_0020.IsBitSet(22))
			{
				return "MLS" + text + " " + text2 + ", " + text4 + ", " + text3 + ", " + text6;
			}
			return "MLA" + text5 + text + " " + text2 + ", " + text4 + ", " + text3 + ", " + text6;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text6 = _0020.IsBitSet(20) ? "S" : "";
			string text7 = _0020.IsBitSet(21) ? "MLAL" : "MULL";
			char c = _0020.IsBitSet(22) ? 'S' : 'U';
			return $"{c}{text7}{text6}{text} {text2}, {text3}, {text4}, {text5}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 16));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "UMAAL" + text + " " + text3 + ", " + text2 + ", " + text5 + ", " + text4;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020(uint _0020)
		{
			switch (_0020.ExtractBits(5, 7))
			{
			case 0u:
				return "ADD16";
			case 1u:
				return "ASX";
			case 2u:
				return "SAX";
			case 3u:
				return "SUB16";
			case 4u:
				return "ADD8";
			case 7u:
				return "SUB8";
			default:
				return "Invalid";
			}
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(uint _0020, string _0020_000A)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text5 = _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020(_0020);
			return _0020_000A + text5 + text + " " + text2 + ", " + text4 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "S");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "U");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "Q");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "UQ");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "SH");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(uint _0020)
		{
			return _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A(_0020, "UH");
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			return "RBIT" + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBits(20, 22);
			uint num2 = _0020.ExtractBits(5, 7);
			string text4 = "";
			if (num == 7 && num2 == 5)
			{
				text4 = "REVSH";
			}
			else if (num == 3)
			{
				switch (num2)
				{
				case 1u:
					text4 = "REV";
					break;
				case 5u:
					text4 = "REV16";
					break;
				}
			}
			return text4 + text + " " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBits(16, 20);
			uint immediate = _0020.ExtractBits(7, 11);
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(_0020.ExtractBit(6) << 1, immediate);
			string text5 = "USAT";
			if (!_0020.IsBitSet(22))
			{
				text5 = "SSAT";
				num++;
			}
			return $"{text5}{text} {text2}, #{num}, {text3}{text4}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBits(16, 19);
			string text4 = "USAT16";
			if (!_0020.IsBitSet(22))
			{
				text4 = "SSAT16";
				num++;
			}
			return $"{text4}{text} {text2}, #{num}, {text3}";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			return "SEL" + text + " " + text2 + ", " + text4 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint immediate = _0020.ExtractBits(7, 11);
			uint num = _0020.ExtractBit(6);
			string text5 = (num == 1) ? "TB" : "BT";
			string text6 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.DecodeImmediateShift(num << 1, immediate);
			return "PKH" + text5 + text + " " + text2 + ", " + text4 + ", " + text3 + text6;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text5 = _0020.IsBitSet(5) ? "X" : "";
			uint num2 = _0020.ExtractBits(6, 7);
			string text6 = "";
			switch (num2)
			{
			case 0u:
				text6 = ((num != 15) ? "SMLAD" : "SMUAD");
				break;
			case 1u:
				text6 = ((num != 15) ? "SMLSD" : "SMUSD");
				break;
			}
			if (num == 15)
			{
				return text6 + text5 + text + " " + text2 + ", " + text4 + ", " + text3;
			}
			string text7 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			return text6 + text5 + text + " " + text2 + ", " + text4 + ", " + text3 + ", " + text7;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text6 = _0020.IsBitSet(5) ? "X" : "";
			string text7 = (_0020.ExtractBits(6, 7) == 0) ? "SMLALD" : "SMLSLD";
			return text7 + text6 + text + " " + text4 + ", " + text5 + ", " + text2 + ", " + text3;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			uint num = _0020.ExtractBits(12, 15);
			string text5 = _0020.IsBitSet(5) ? "R" : "";
			uint num2 = _0020.ExtractBits(6, 7);
			if (num2 == 0 && num == 15)
			{
				return "SMMUL" + text5 + text + " " + text2 + ", " + text4 + ", " + text3;
			}
			string text6 = "";
			switch (num2)
			{
			case 0u:
				text6 = "SMMLA";
				break;
			case 3u:
				text6 = "SMMLS";
				break;
			}
			string text7 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			return text6 + text5 + text + " " + text2 + ", " + text4 + ", " + text3 + ", " + text7;
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			string text5 = _0020.IsBitSet(22) ? "B" : "";
			return "SWP" + text5 + text + " " + text3 + ", " + text4 + ", [" + text2 + "]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint num = _0020.ExtractBits(12, 15);
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			uint num2 = _0020.ExtractBits(20, 23);
			if (num2 == 11)
			{
				string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
				return "LDREXD" + text + " " + text3 + ", " + text4 + ", [" + text2 + "]";
			}
			string text5 = "";
			switch (num2)
			{
			case 9u:
				text5 = "LDREX";
				break;
			case 13u:
				text5 = "LDREXB";
				break;
			case 15u:
				text5 = "LDREXH";
				break;
			}
			return text5 + text + " " + text3 + ", [" + text2 + "]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(12, 15));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			uint num = _0020.ExtractBits(0, 3);
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			uint num2 = _0020.ExtractBits(20, 23);
			if (num2 == 10)
			{
				string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num + 1);
				return "STREXD" + text + " " + text2 + ", " + text4 + ", " + text5 + ", [" + text3 + "]";
			}
			string text6 = "";
			switch (num2)
			{
			case 8u:
				text6 = "STREX";
				break;
			case 12u:
				text6 = "STREXB";
				break;
			case 14u:
				text6 = "STREXH";
				break;
			}
			return text6 + text + " " + text2 + ", " + text4 + ", [" + text3 + "]";
		}

		internal static string _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(uint _0020)
		{
			string text = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.ARMConditionCode(_0020);
			uint num = _0020.ExtractBits(12, 15);
			string text2 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(16, 19));
			string text3 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(8, 11));
			string text4 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(_0020.ExtractBits(0, 3));
			if (num == 15)
			{
				return "USAD8" + text + " " + text2 + ", " + text4 + ", " + text3;
			}
			string text5 = _0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020.RegisterName(num);
			return "USADA8" + text + " " + text2 + ", " + text4 + ", " + text3 + ", " + text5;
		}
	}
}
