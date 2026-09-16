using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x200000B")]
	public class PayoutDefinition
	{
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		private PayoutType m_Type;

		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x18")]
		private string m_Subtype;

		[SerializeField]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x20")]
		private double m_Quantity;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x28")]
		private string m_Data;

		[Token(Token = "0x400000F")]
		public const int MaxSubtypeLength = 64;

		[Token(Token = "0x4000010")]
		public const int MaxDataLength = 1024;

		[Token(Token = "0x17000005")]
		private PayoutType type
		{
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x160E87C", Offset = "0x160E87C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000006")]
		private string subtype
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x160E6BC", Offset = "0x160E6BC", Length = "0xE0")]
			set
			{
			}
		}

		[Token(Token = "0x17000007")]
		private double quantity
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x160E884", Offset = "0x160E884", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000008")]
		private string data
		{
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x160E79C", Offset = "0x160E79C", Length = "0xE0")]
			set
			{
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x160E48C", Offset = "0x160E48C", Length = "0x6C")]
		public PayoutDefinition()
		{
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x160E4F8", Offset = "0x160E4F8", Length = "0x1C4")]
		public PayoutDefinition(string typeString, string subtype, double quantity, string data)
		{
		}
	}
}
