using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000016")]
	public static class TMP_Math
	{
		[Token(Token = "0x400009B")]
		public const float FLOAT_MAX = 32767f;

		[Token(Token = "0x400009C")]
		public const float FLOAT_MIN = -32767f;

		[Token(Token = "0x400009D")]
		public const int INT_MAX = int.MaxValue;

		[Token(Token = "0x400009E")]
		public const int INT_MIN = -2147483647;

		[Token(Token = "0x400009F")]
		public const float FLOAT_UNSET = -32767f;

		[Token(Token = "0x40000A0")]
		public const int INT_UNSET = -32767;

		[Token(Token = "0x40000A1")]
		public static Vector2 MAX_16BIT;

		[Token(Token = "0x40000A2")]
		public static Vector2 MIN_16BIT;

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x15CF674", Offset = "0x15CF674", Length = "0x30")]
		public static bool Approximately(float a, float b)
		{
			return false;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x15CF6A4", Offset = "0x15CF6A4", Length = "0x14")]
		public static int Mod(int a, int b)
		{
			return 0;
		}
	}
}
