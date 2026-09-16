using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000060")]
	public static class TMPro_ExtensionMethods
	{
		[Token(Token = "0x6000529")]
		[Address(RVA = "0xC908E4", Offset = "0xC908E4", Length = "0xCC")]
		public static string ArrayToString(this char[] chars)
		{
			return null;
		}

		[Token(Token = "0x600052A")]
		[Address(RVA = "0xC909B0", Offset = "0xC909B0", Length = "0xCC")]
		public static string IntToString(this int[] unicodes)
		{
			return null;
		}

		[Token(Token = "0x600052B")]
		[Address(RVA = "0xC90A7C", Offset = "0xC90A7C", Length = "0x154")]
		public static string IntToString(this int[] unicodes, int start, int length)
		{
			return null;
		}

		[Token(Token = "0x600052C")]
		[Address(RVA = "0xBABE28", Offset = "0xBABE28", Length = "0xBC")]
		public static int FindInstanceID<T>(this List<T> list, T target) where T : Object
		{
			return 0;
		}

		[Token(Token = "0x600052D")]
		[Address(RVA = "0xC90BD0", Offset = "0xC90BD0", Length = "0x44")]
		public static bool Compare(this Color32 a, Color32 b)
		{
			return false;
		}

		[Token(Token = "0x600052E")]
		[Address(RVA = "0xC90C14", Offset = "0xC90C14", Length = "0x38")]
		public static bool CompareRGB(this Color32 a, Color32 b)
		{
			return false;
		}

		[Token(Token = "0x600052F")]
		[Address(RVA = "0xC90C4C", Offset = "0xC90C4C", Length = "0x30")]
		public static bool Compare(this Color a, Color b)
		{
			return false;
		}

		[Token(Token = "0x6000530")]
		[Address(RVA = "0xC90C7C", Offset = "0xC90C7C", Length = "0x28")]
		public static bool CompareRGB(this Color a, Color b)
		{
			return false;
		}

		[Token(Token = "0x6000531")]
		[Address(RVA = "0xC90CA4", Offset = "0xC90CA4", Length = "0xC4")]
		public static Color32 Multiply(this Color32 c1, Color32 c2)
		{
			return default(Color32);
		}

		[Token(Token = "0x6000532")]
		[Address(RVA = "0xC90D68", Offset = "0xC90D68", Length = "0xC4")]
		public static Color32 Tint(this Color32 c1, Color32 c2)
		{
			return default(Color32);
		}

		[Token(Token = "0x6000533")]
		[Address(RVA = "0xC90E2C", Offset = "0xC90E2C", Length = "0x14C")]
		public static Color32 Tint(this Color32 c1, float tint)
		{
			return default(Color32);
		}

		[Token(Token = "0x6000534")]
		[Address(RVA = "0xC90F78", Offset = "0xC90F78", Length = "0x58")]
		public static bool Compare(this Vector3 v1, Vector3 v2, int accuracy)
		{
			return false;
		}

		[Token(Token = "0x6000535")]
		[Address(RVA = "0xC90FD0", Offset = "0xC90FD0", Length = "0x74")]
		public static bool Compare(this Quaternion q1, Quaternion q2, int accuracy)
		{
			return false;
		}
	}
}
