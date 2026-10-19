using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Systems.PaymentSystem.Data;

namespace Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000047")]
	public class ShopGroupRemote
	{
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x10")]
		public string groupKey;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x18")]
		public string viewType;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x20")]
		public ShopItemRemote[] shopItems;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x28")]
		public string groupVisualName;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x30")]
		public CostData costData;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x38")]
		public ShopItemVisualData ItemVisualData;

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x3C681B8", Offset = "0x3C681B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopGroupRemote()
		{
		}
	}
}
