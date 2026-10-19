using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EnhancedScrollerDemos.SnappingDemo
{
	[Token(Token = "0x2000066")]
	public class SlotData
	{
		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x10")]
		public Sprite sprite;

		[Token(Token = "0x6000200")]
		[Address(RVA = "0x402E398", Offset = "0x402E398", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SlotData()
		{
		}
	}
}
