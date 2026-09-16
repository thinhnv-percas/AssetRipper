using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000040")]
	public class TMP_SpriteCharacter : TMP_TextElement
	{
		[SerializeField]
		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x28")]
		private string m_Name;

		[SerializeField]
		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x30")]
		private int m_HashCode;

		[Token(Token = "0x170000BD")]
		public string name
		{
			[Token(Token = "0x6000345")]
			[Address(RVA = "0x93DED4", Offset = "0x93DED4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000346")]
			[Address(RVA = "0x93DD00", Offset = "0x93DD00", Length = "0x94")]
			set
			{
			}
		}

		[Token(Token = "0x170000BE")]
		public int hashCode
		{
			[Token(Token = "0x6000347")]
			[Address(RVA = "0x93DEDC", Offset = "0x93DEDC", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x93DEE4", Offset = "0x93DEE4", Length = "0x2C")]
		public TMP_SpriteCharacter()
		{
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x93DC9C", Offset = "0x93DC9C", Length = "0x64")]
		public TMP_SpriteCharacter(uint unicode, TMP_SpriteGlyph glyph)
		{
		}
	}
}
