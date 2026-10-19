using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.RewardSystem;

namespace Systems.RewardSystem.UnityBindings
{
	[Token(Token = "0x2000004")]
	public class GenericElementFallbackState : GenericElementVisualizerState
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81D43C8", Offset = "0x81D43C8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Systems.RewardSystem.UnityBindings.GenericElementFallbackState::Visualize(this, data);\n\treturn;\n")]
		public void Visualize(ShopItemData data, Exception e)
		{
			Visualize(data);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81D43D4", Offset = "0x81D43D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Visualize(ShopItemData data)
		{
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x49830C4", Offset = "0x49830C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		public override bool IsTypeOf<T>(T shopItemData)
		{
			return true;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81D43D8", Offset = "0x81D43D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public GenericElementFallbackState()
		{
		}
	}
}
