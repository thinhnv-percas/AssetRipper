using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200002C")]
	public abstract class TMP_InputValidator : ScriptableObject
	{
		[Token(Token = "0x60002B5")]
		public abstract char Validate(ref string text, ref int pos, char ch);

		[Token(Token = "0x60002B6")]
		[Address(RVA = "0x935354", Offset = "0x935354", Length = "0x2B0")]
		protected TMP_InputValidator()
		{
		}
	}
}
