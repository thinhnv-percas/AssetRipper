using System.Collections.Generic;
using System.Diagnostics;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000F")]
	public class ProductDefinition
	{
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		private List<PayoutDefinition> m_Payouts;

		[Token(Token = "0x17000011")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72656C", Offset = "0x72656C")]
		[field: Token(Token = "0x4000021")]
		[field: FieldOffset(Offset = "0x10")]
		public string id
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x160EE90", Offset = "0x160EE90", Length = "0x8")]
			get;
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x160EE98", Offset = "0x160EE98", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000012")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7265A8", Offset = "0x7265A8")]
		[field: Token(Token = "0x4000022")]
		[field: FieldOffset(Offset = "0x18")]
		public string storeSpecificId
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x160EEA0", Offset = "0x160EEA0", Length = "0x8")]
			get;
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x160EEA8", Offset = "0x160EEA8", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000013")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7265E4", Offset = "0x7265E4")]
		[field: Token(Token = "0x4000023")]
		[field: FieldOffset(Offset = "0x20")]
		public ProductType type
		{
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x160EEB0", Offset = "0x160EEB0", Length = "0x8")]
			get;
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x160EEB8", Offset = "0x160EEB8", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000014")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726620", Offset = "0x726620")]
		[field: Token(Token = "0x4000024")]
		[field: FieldOffset(Offset = "0x24")]
		public bool enabled
		{
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x160EEC0", Offset = "0x160EEC0", Length = "0x8")]
			get;
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x160EEC8", Offset = "0x160EEC8", Length = "0xC")]
			private set;
		}

		[Token(Token = "0x17000015")]
		public IEnumerable<PayoutDefinition> payouts
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x160EFA8", Offset = "0x160EFA8", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x160DF10", Offset = "0x160DF10", Length = "0xC")]
		public ProductDefinition(string id, string storeSpecificId, ProductType type)
		{
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x160EDB4", Offset = "0x160EDB4", Length = "0xC")]
		public ProductDefinition(string id, string storeSpecificId, ProductType type, bool enabled)
		{
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x160EDC0", Offset = "0x160EDC0", Length = "0xB8")]
		public ProductDefinition(string id, string storeSpecificId, ProductType type, bool enabled, IEnumerable<PayoutDefinition> payouts)
		{
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x160EE78", Offset = "0x160EE78", Length = "0x18")]
		public ProductDefinition(string id, ProductType type)
		{
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x160EED4", Offset = "0x160EED4", Length = "0xB4")]
		public override bool Equals(object obj)
		{
			return false;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x160EF88", Offset = "0x160EF88", Length = "0x20")]
		public override int GetHashCode()
		{
			return 0;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x160DF1C", Offset = "0x160DF1C", Length = "0x94")]
		internal void SetPayouts(IEnumerable<PayoutDefinition> newPayouts)
		{
		}
	}
}
