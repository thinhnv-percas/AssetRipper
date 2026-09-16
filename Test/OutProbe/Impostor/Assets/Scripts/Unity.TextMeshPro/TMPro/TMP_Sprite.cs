using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200007C")]
	public class TMP_Sprite : TMP_TextElement_Legacy
	{
		[Token(Token = "0x400040C")]
		[FieldOffset(Offset = "0x38")]
		public string name;

		[Token(Token = "0x400040D")]
		[FieldOffset(Offset = "0x40")]
		public int hashCode;

		[Token(Token = "0x400040E")]
		[FieldOffset(Offset = "0x44")]
		public int unicode;

		[Token(Token = "0x400040F")]
		[FieldOffset(Offset = "0x48")]
		public Vector2 pivot;

		[Token(Token = "0x4000410")]
		[FieldOffset(Offset = "0x50")]
		public Sprite sprite;

		[Token(Token = "0x6000405")]
		[Address(RVA = "0x160A650", Offset = "0x160A650", Length = "0x8")]
		public TMP_Sprite()
		{
		}
	}
}
