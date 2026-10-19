using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ResourceSystem;

namespace Unco.RewardSystem
{
	[Token(Token = "0x200001A")]
	public class ResourceItemData : ShopItemData
	{
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x40")]
		public ResourceType ResourceType;

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x81D660C", Offset = "0x81D660C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ResourceItemData()
		{
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x81D6614", Offset = "0x81D6614", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.ResourceType = this.ResourceType;\n\tv45.sourceType = this.sourceType;\n\tv45.Amount = this.Amount;\n\tv45.customTransactionData = this.customTransactionData;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.RewardSystem.ResourceItemData();\n\tSystem.Object::.ctor(v45);\n")]
		public override ShopItemData Copy()
		{
			ResourceItemData resourceItemData = new ResourceItemData();
			resourceItemData.ResourceType = ResourceType;
			resourceItemData.sourceType = sourceType;
			resourceItemData.Amount = Amount;
			resourceItemData.customTransactionData = customTransactionData;
			return resourceItemData;
		}
	}
}
