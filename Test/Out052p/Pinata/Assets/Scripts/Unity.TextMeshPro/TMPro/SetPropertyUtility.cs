using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200002B")]
	internal static class SetPropertyUtility
	{
		[Token(Token = "0x60002B1")]
		[Address(RVA = "0x9198D0", Offset = "0x9198D0", Length = "0x48")]
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			return false;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xD6B750", Offset = "0xD6B750", Length = "0xCC")]
		public static bool SetEquatableStruct<T>(ref T currentValue, T newValue) where T : IEquatable<T>
		{
			return false;
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xD6B81C", Offset = "0xD6B81C", Length = "0x74")]
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			return false;
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xD6B6FC", Offset = "0xD6B6FC", Length = "0x54")]
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			return false;
		}
	}
}
