using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200005E")]
	public class IAPProduct
	{
		[Serializable]
		[Token(Token = "0x200012E")]
		public class StoreSpecificId
		{
			[Token(Token = "0x400051E")]
			[FieldOffset(Offset = "0x10")]
			public IAPStore store;

			[Token(Token = "0x400051F")]
			[FieldOffset(Offset = "0x18")]
			public string id;

			[Token(Token = "0x600099C")]
			[Address(RVA = "0xBF5310", Offset = "0xBF5310", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public StoreSpecificId()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x10")]
		private string _name;

		[SerializeField]
		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x18")]
		private IAPProductType _type;

		[SerializeField]
		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x20")]
		private string _id;

		[SerializeField]
		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x28")]
		private string _price;

		[SerializeField]
		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x30")]
		private string _description;

		[SerializeField]
		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x38")]
		private StoreSpecificId[] _storeSpecificIds;

		[Token(Token = "0x17000153")]
		public string Name
		{
			[Token(Token = "0x600048F")]
			[Address(RVA = "0xBF52D8", Offset = "0xBF52D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000154")]
		public string Id
		{
			[Token(Token = "0x6000490")]
			[Address(RVA = "0xBF52E0", Offset = "0xBF52E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Id;
			}
		}

		[Token(Token = "0x17000155")]
		public IAPProductType Type
		{
			[Token(Token = "0x6000491")]
			[Address(RVA = "0xBF52E8", Offset = "0xBF52E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._type;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Type;
			}
		}

		[Token(Token = "0x17000156")]
		public string Price
		{
			[Token(Token = "0x6000492")]
			[Address(RVA = "0xBF52F0", Offset = "0xBF52F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._price;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Price;
			}
		}

		[Token(Token = "0x17000157")]
		public string Description
		{
			[Token(Token = "0x6000493")]
			[Address(RVA = "0xBF52F8", Offset = "0xBF52F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._description;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Description;
			}
		}

		[Token(Token = "0x17000158")]
		public StoreSpecificId[] StoreSpecificIds
		{
			[Token(Token = "0x6000494")]
			[Address(RVA = "0xBF5300", Offset = "0xBF5300", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._storeSpecificIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StoreSpecificIds;
			}
		}

		[Token(Token = "0x6000495")]
		[Address(RVA = "0xBF5308", Offset = "0xBF5308", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IAPProduct()
		{
		}
	}
}
