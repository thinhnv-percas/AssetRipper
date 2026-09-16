using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000081")]
	public class TMP_SpriteCharacter : TMP_TextElement
	{
		[SerializeField]
		[Token(Token = "0x4000433")]
		[FieldOffset(Offset = "0x30")]
		private string m_Name;

		[SerializeField]
		[Token(Token = "0x4000434")]
		[FieldOffset(Offset = "0x38")]
		private int m_HashCode;

		[Token(Token = "0x170000E7")]
		public string name
		{
			[Token(Token = "0x6000432")]
			[Address(RVA = "0x160CE84", Offset = "0x160CE84", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000433")]
			[Address(RVA = "0x160CCB4", Offset = "0x160CCB4", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x170000E8")]
		public int hashCode
		{
			[Token(Token = "0x6000434")]
			[Address(RVA = "0x160CEF8", Offset = "0x160CEF8", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000435")]
		[Address(RVA = "0x160CC94", Offset = "0x160CC94", Length = "0x20")]
		public TMP_SpriteCharacter()
		{
		}

		[Token(Token = "0x6000436")]
		[Address(RVA = "0x160CF08", Offset = "0x160CF08", Length = "0x54")]
		public TMP_SpriteCharacter(uint unicode, TMP_SpriteGlyph glyph)
		{
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0x160CF5C", Offset = "0x160CF5C", Length = "0x60")]
		public TMP_SpriteCharacter(uint unicode, TMP_SpriteAsset spriteAsset, TMP_SpriteGlyph glyph)
		{
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0x160CFBC", Offset = "0x160CFBC", Length = "0x40")]
		internal TMP_SpriteCharacter(uint unicode, uint glyphIndex)
		{
		}
	}
}
