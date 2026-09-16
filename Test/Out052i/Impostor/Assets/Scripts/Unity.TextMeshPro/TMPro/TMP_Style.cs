using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000083")]
	public class TMP_Style
	{
		[Token(Token = "0x4000436")]
		internal static TMP_Style k_NormalStyle;

		[SerializeField]
		[Token(Token = "0x4000437")]
		[FieldOffset(Offset = "0x10")]
		private string m_Name;

		[SerializeField]
		[Token(Token = "0x4000438")]
		[FieldOffset(Offset = "0x18")]
		private int m_HashCode;

		[SerializeField]
		[Token(Token = "0x4000439")]
		[FieldOffset(Offset = "0x20")]
		private string m_OpeningDefinition;

		[SerializeField]
		[Token(Token = "0x400043A")]
		[FieldOffset(Offset = "0x28")]
		private string m_ClosingDefinition;

		[SerializeField]
		[Token(Token = "0x400043B")]
		[FieldOffset(Offset = "0x30")]
		private int[] m_OpeningTagArray;

		[SerializeField]
		[Token(Token = "0x400043C")]
		[FieldOffset(Offset = "0x38")]
		private int[] m_ClosingTagArray;

		[SerializeField]
		[Token(Token = "0x400043D")]
		[FieldOffset(Offset = "0x40")]
		internal uint[] m_OpeningTagUnicodeArray;

		[SerializeField]
		[Token(Token = "0x400043E")]
		[FieldOffset(Offset = "0x48")]
		internal uint[] m_ClosingTagUnicodeArray;

		[Token(Token = "0x170000E9")]
		public static TMP_Style NormalStyle
		{
			[Token(Token = "0x600043C")]
			[Address(RVA = "0x160D17C", Offset = "0x160D17C", Length = "0xB4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000EA")]
		public string name
		{
			[Token(Token = "0x600043D")]
			[Address(RVA = "0x160D2C0", Offset = "0x160D2C0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600043E")]
			[Address(RVA = "0x160D2C8", Offset = "0x160D2C8", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000EB")]
		public int hashCode
		{
			[Token(Token = "0x600043F")]
			[Address(RVA = "0x160D300", Offset = "0x160D300", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000440")]
			[Address(RVA = "0x160D308", Offset = "0x160D308", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x170000EC")]
		public string styleOpeningDefinition
		{
			[Token(Token = "0x6000441")]
			[Address(RVA = "0x160D31C", Offset = "0x160D31C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000ED")]
		public string styleClosingDefinition
		{
			[Token(Token = "0x6000442")]
			[Address(RVA = "0x160D324", Offset = "0x160D324", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000EE")]
		public int[] styleOpeningTagArray
		{
			[Token(Token = "0x6000443")]
			[Address(RVA = "0x160D32C", Offset = "0x160D32C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000EF")]
		public int[] styleClosingTagArray
		{
			[Token(Token = "0x6000444")]
			[Address(RVA = "0x160D334", Offset = "0x160D334", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0x160D230", Offset = "0x160D230", Length = "0x90")]
		internal TMP_Style(string styleName, string styleOpeningDefinition, string styleClosingDefinition)
		{
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0x160D3F8", Offset = "0x160D3F8", Length = "0x1F8")]
		public void RefreshStyle()
		{
		}
	}
}
