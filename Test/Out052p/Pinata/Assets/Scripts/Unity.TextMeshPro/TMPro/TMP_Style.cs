using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000042")]
	public class TMP_Style
	{
		[SerializeField]
		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x10")]
		private string m_Name;

		[SerializeField]
		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0x18")]
		private int m_HashCode;

		[SerializeField]
		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x20")]
		private string m_OpeningDefinition;

		[SerializeField]
		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x28")]
		private string m_ClosingDefinition;

		[SerializeField]
		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x30")]
		private int[] m_OpeningTagArray;

		[SerializeField]
		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x38")]
		private int[] m_ClosingTagArray;

		[Token(Token = "0x170000BF")]
		public string name
		{
			[Token(Token = "0x600034D")]
			[Address(RVA = "0x93E0A0", Offset = "0x93E0A0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600034E")]
			[Address(RVA = "0x93E0A8", Offset = "0x93E0A8", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x170000C0")]
		public int hashCode
		{
			[Token(Token = "0x600034F")]
			[Address(RVA = "0x93E0E4", Offset = "0x93E0E4", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000350")]
			[Address(RVA = "0x93E0EC", Offset = "0x93E0EC", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x170000C1")]
		public string styleOpeningDefinition
		{
			[Token(Token = "0x6000351")]
			[Address(RVA = "0x93E100", Offset = "0x93E100", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C2")]
		public string styleClosingDefinition
		{
			[Token(Token = "0x6000352")]
			[Address(RVA = "0x93E108", Offset = "0x93E108", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C3")]
		public int[] styleOpeningTagArray
		{
			[Token(Token = "0x6000353")]
			[Address(RVA = "0x93E110", Offset = "0x93E110", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000C4")]
		public int[] styleClosingTagArray
		{
			[Token(Token = "0x6000354")]
			[Address(RVA = "0x93E118", Offset = "0x93E118", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0x93E120", Offset = "0x93E120", Length = "0x178")]
		public void RefreshStyle()
		{
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0x93E298", Offset = "0x93E298", Length = "0x8")]
		public TMP_Style()
		{
		}
	}
}
