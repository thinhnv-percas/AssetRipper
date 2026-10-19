using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.RewardSystem;

namespace Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000041")]
	public class ShopItemRemote
	{
		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x10")]
		public int dailyLimit;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x18")]
		public LootDrop lootDrop;

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x3C67D84", Offset = "0x3C67D84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ShopItemRemote()
		{
		}
	}
}
