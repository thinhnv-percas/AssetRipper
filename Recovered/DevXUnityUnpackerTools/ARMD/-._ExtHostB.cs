using @as;
using DMP4;
using DSMCaps;
using DSMCaps.Arm;
using DSMCaps.Arm64;
using DSMCaps.X86;
using FMOD;
using SpirV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unreal;
using Wasm;
using Wasm.Interpret;

namespace ARMD
{
	internal static class ARMD___ExtHostB1
	{
	internal static int BitSize(this sbyte integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this byte integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this short integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this ushort integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this int integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this uint integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this long integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static int BitSize(this ulong integral)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.BitSize(integral);
	}
	internal static sbyte ExtractBit(this sbyte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static byte ExtractBit(this byte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static short ExtractBit(this short integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static int ExtractBit(this int integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static uint ExtractBit(this uint integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static long ExtractBit(this long integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static ulong ExtractBit(this ulong integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBit(integral, bit);
	}
	internal static sbyte ExtractBits(this sbyte integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static byte ExtractBits(this byte integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static short ExtractBits(this short integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static ushort ExtractBits(this ushort integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static int ExtractBits(this int integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static uint ExtractBits(this uint integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static long ExtractBits(this long integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static ulong ExtractBits(this ulong integral, int start, int end)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.ExtractBits(integral, start, end);
	}
	internal static bool IsBitSet(this sbyte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this byte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this short integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this ushort integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this int integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this uint integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this long integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static bool IsBitSet(this ulong integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.IsBitSet(integral, bit);
	}
	internal static sbyte SignExtend(this sbyte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static byte SignExtend(this byte integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static short SignExtend(this short integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static ushort SignExtend(this ushort integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static int SignExtend(this int integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static uint SignExtend(this uint integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static long SignExtend(this long integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static ulong SignExtend(this ulong integral, int bit)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignExtend(integral, bit);
	}
	internal static char SignBitToChar(this sbyte val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this byte val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this short val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this ushort val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this int val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this uint val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this long val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static char SignBitToChar(this ulong val)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.SignBitToChar(val);
	}
	internal static byte RotateLeft(this byte value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateLeft(value, count);
	}
	internal static ushort RotateLeft(this ushort value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateLeft(value, count);
	}
	internal static uint RotateLeft(this uint value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateLeft(value, count);
	}
	internal static ulong RotateLeft(this ulong value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateLeft(value, count);
	}
	internal static byte RotateRight(this byte value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateRight(value, count);
	}
	internal static ushort RotateRight(this ushort value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateRight(value, count);
	}
	internal static uint RotateRight(this uint value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateRight(value, count);
	}
	internal static ulong RotateRight(this ulong value, int count)
	{
		return _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020.RotateRight(value, count);
	}
	}
}
