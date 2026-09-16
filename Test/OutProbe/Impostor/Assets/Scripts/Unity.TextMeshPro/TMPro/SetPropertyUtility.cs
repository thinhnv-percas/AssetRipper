using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000063")]
	internal static class SetPropertyUtility
	{
		[Token(Token = "0x6000382")]
		[Address(RVA = "0x1601DCC", Offset = "0x1601DCC", Length = "0x48")]
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			return false;
		}

		[Token(Token = "0x6000383")]
		[Address(RVA = "0xCA247C", Offset = "0xCA247C", Length = "0x198")]
		public static bool SetEquatableStruct<T>(ref T currentValue, T newValue) where T : IEquatable<T>
		{
			return false;
		}

		[Token(Token = "0x6000384")]
		[Address(RVA = "0xCA2614", Offset = "0xCA2614", Length = "0xA4")]
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			return false;
		}

		[Token(Token = "0x6000385")]
		[Address(RVA = "0xCA242C", Offset = "0xCA242C", Length = "0x50")]
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			return false;
		}
	}
}
