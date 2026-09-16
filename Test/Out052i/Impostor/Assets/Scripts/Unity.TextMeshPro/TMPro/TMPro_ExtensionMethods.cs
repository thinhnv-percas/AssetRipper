using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000015")]
	public static class TMPro_ExtensionMethods
	{
		[Token(Token = "0x6000101")]
		[Address(RVA = "0x15CEE2C", Offset = "0x15CEE2C", Length = "0xB4")]
		public static int[] ToIntArray(this string text)
		{
			return null;
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x15CEEE0", Offset = "0x15CEEE0", Length = "0xE8")]
		public static string ArrayToString(this char[] chars)
		{
			return null;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x15CEFC8", Offset = "0x15CEFC8", Length = "0xB0")]
		public static string IntToString(this int[] unicodes)
		{
			return null;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x15CF078", Offset = "0x15CF078", Length = "0xD8")]
		internal static string UintToString(this List<uint> unicodes)
		{
			return null;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x15CF150", Offset = "0x15CF150", Length = "0x110")]
		public static string IntToString(this int[] unicodes, int start, int length)
		{
			return null;
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0xCAC594", Offset = "0xCAC594", Length = "0xA4")]
		public static int FindInstanceID<T>(this List<T> list, T target) where T : Object
		{
			return 0;
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x15CF260", Offset = "0x15CF260", Length = "0x10")]
		public static bool Compare(this Color32 a, Color32 b)
		{
			return false;
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x15CF270", Offset = "0x15CF270", Length = "0x10")]
		public static bool CompareRGB(this Color32 a, Color32 b)
		{
			return false;
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x15CF280", Offset = "0x15CF280", Length = "0x28")]
		public static bool Compare(this Color a, Color b)
		{
			return false;
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x15CF2A8", Offset = "0x15CF2A8", Length = "0x20")]
		public static bool CompareRGB(this Color a, Color b)
		{
			return false;
		}

		[Token(Token = "0x600010B")]
		[Address(RVA = "0x15CF2C8", Offset = "0x15CF2C8", Length = "0xB8")]
		public static Color32 Multiply(this Color32 c1, Color32 c2)
		{
			return default(Color32);
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x15CF380", Offset = "0x15CF380", Length = "0xB8")]
		public static Color32 Tint(this Color32 c1, Color32 c2)
		{
			return default(Color32);
		}

		[Token(Token = "0x600010D")]
		[Address(RVA = "0x15CF438", Offset = "0x15CF438", Length = "0xDC")]
		public static Color32 Tint(this Color32 c1, float tint)
		{
			return default(Color32);
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x15CF514", Offset = "0x15CF514", Length = "0xC")]
		public static Color MinAlpha(this Color c1, Color c2)
		{
			return default(Color);
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x15CF520", Offset = "0x15CF520", Length = "0x94")]
		public static bool Compare(this Vector3 v1, Vector3 v2, int accuracy)
		{
			return false;
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x15CF5B4", Offset = "0x15CF5B4", Length = "0xC0")]
		public static bool Compare(this Quaternion q1, Quaternion q2, int accuracy)
		{
			return false;
		}
	}
}
