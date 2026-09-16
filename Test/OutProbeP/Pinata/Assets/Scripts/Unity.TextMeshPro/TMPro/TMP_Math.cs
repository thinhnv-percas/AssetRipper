using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000061")]
	public static class TMP_Math
	{
		[Token(Token = "0x4000415")]
		public const float FLOAT_MAX = 32767f;

		[Token(Token = "0x4000416")]
		public const float FLOAT_MIN = -32767f;

		[Token(Token = "0x4000417")]
		public const int INT_MAX = int.MaxValue;

		[Token(Token = "0x4000418")]
		public const int INT_MIN = -2147483647;

		[Token(Token = "0x4000419")]
		public const float FLOAT_UNSET = -32767f;

		[Token(Token = "0x400041A")]
		public const int INT_UNSET = -32767;

		[Token(Token = "0x400041B")]
		public static Vector2 MAX_16BIT;

		[Token(Token = "0x400041C")]
		public static Vector2 MIN_16BIT;

		[Token(Token = "0x6000536")]
		[Address(RVA = "0x938240", Offset = "0x938240", Length = "0x30")]
		public static bool Approximately(float a, float b)
		{
			return false;
		}
	}
}
