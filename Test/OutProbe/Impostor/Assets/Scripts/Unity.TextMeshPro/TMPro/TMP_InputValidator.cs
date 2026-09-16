using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000064")]
	public abstract class TMP_InputValidator : ScriptableObject
	{
		[Token(Token = "0x6000386")]
		public abstract char Validate(ref string text, ref int pos, char ch);

		[Token(Token = "0x6000387")]
		[Address(RVA = "0x1601E14", Offset = "0x1601E14", Length = "0x8")]
		protected TMP_InputValidator()
		{
		}
	}
}
