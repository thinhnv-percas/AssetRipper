using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000043")]
	public class TMP_StyleSheet : ScriptableObject
	{
		[Token(Token = "0x4000278")]
		private static TMP_StyleSheet s_Instance;

		[SerializeField]
		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0x18")]
		private List<TMP_Style> m_StyleList;

		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<int, TMP_Style> m_StyleDictionary;

		[Token(Token = "0x170000C5")]
		public static TMP_StyleSheet instance
		{
			[Token(Token = "0x6000357")]
			[Address(RVA = "0x93E2A0", Offset = "0x93E2A0", Length = "0x160")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0x93E590", Offset = "0x93E590", Length = "0x4")]
		public static TMP_StyleSheet LoadDefaultStyleSheet()
		{
			return null;
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0x93E594", Offset = "0x93E594", Length = "0x2C")]
		public static TMP_Style GetStyle(int hashCode)
		{
			return null;
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0x93E5C0", Offset = "0x93E5C0", Length = "0x80")]
		private TMP_Style GetStyleInternal(int hashCode)
		{
			return null;
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0x93E640", Offset = "0x93E640", Length = "0xE4")]
		public void UpdateStyleDictionaryKey(int old_key, int new_key)
		{
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0x93E724", Offset = "0x93E724", Length = "0x50")]
		public static void UpdateStyleSheet()
		{
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0x93E774", Offset = "0x93E774", Length = "0x1C")]
		public static void RefreshStyles()
		{
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0x93E400", Offset = "0x93E400", Length = "0x190")]
		private void LoadStyleDictionaryInternal()
		{
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x93E790", Offset = "0x93E790", Length = "0x9C")]
		public TMP_StyleSheet()
		{
		}
	}
}
