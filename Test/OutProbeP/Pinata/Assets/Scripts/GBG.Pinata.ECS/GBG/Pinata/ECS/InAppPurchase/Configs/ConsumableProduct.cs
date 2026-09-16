using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GBG.Pinata.ECS.InAppPurchase.Configs
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x2000058")]
	public struct ConsumableProduct
	{
		[Token(Token = "0x40000F1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string productName;

		[Token(Token = "0x40000F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int reward;

		[Token(Token = "0x40000F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public int extraReward;

		[Token(Token = "0x40000F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public RewardType rewardType;

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x84CD3C", Offset = "0x84CD3C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rewardType = productName;\n\t*([this @ X0 (GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct)+18]) = reward;\n\t*([this @ X0 (GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct)+1C]) = extraReward;\n\t*([this @ X0 (GBG.Pinata.ECS.InAppPurchase.Configs.ConsumableProduct)+20]) = rewardType;\n\treturn;\n")]
		public ConsumableProduct(string productName, int reward, int extraReward, RewardType rewardType)
		{
			//IL_000a: Expected I4, but got O
			this.rewardType = (RewardType)productName;
		}
	}
}
