using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[Token(Token = "0x2000084")]
	public class TMP_StyleSheet : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x400043F")]
		[FieldOffset(Offset = "0x18")]
		private List<TMP_Style> m_StyleList;

		[Token(Token = "0x4000440")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<int, TMP_Style> m_StyleLookupDictionary;

		[Token(Token = "0x170000F0")]
		internal List<TMP_Style> styles
		{
			[Token(Token = "0x6000447")]
			[Address(RVA = "0x160D5F0", Offset = "0x160D5F0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000448")]
		[Address(RVA = "0x160D5F8", Offset = "0x160D5F8", Length = "0x4")]
		private void Reset()
		{
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0x160D8FC", Offset = "0x160D8FC", Length = "0x88")]
		public TMP_Style GetStyle(int hashCode)
		{
			return null;
		}

		[Token(Token = "0x600044A")]
		[Address(RVA = "0x160D984", Offset = "0x160D984", Length = "0xB8")]
		public TMP_Style GetStyle(string name)
		{
			return null;
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0x160DA3C", Offset = "0x160DA3C", Length = "0x4")]
		public void RefreshStyles()
		{
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0x160D5FC", Offset = "0x160D5FC", Length = "0x300")]
		private void LoadStyleDictionaryInternal()
		{
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0x160DA40", Offset = "0x160DA40", Length = "0x80")]
		public TMP_StyleSheet()
		{
		}
	}
}
