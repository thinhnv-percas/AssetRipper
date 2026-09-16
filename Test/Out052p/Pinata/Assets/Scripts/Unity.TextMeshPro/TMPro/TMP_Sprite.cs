using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200003D")]
	public class TMP_Sprite : TMP_TextElement_Legacy
	{
		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x38")]
		public string name;

		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x40")]
		public int hashCode;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x44")]
		public int unicode;

		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x48")]
		public Vector2 pivot;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x50")]
		public Sprite sprite;

		[Token(Token = "0x6000326")]
		[Address(RVA = "0x93B98C", Offset = "0x93B98C", Length = "0x8")]
		public TMP_Sprite()
		{
		}
	}
}
