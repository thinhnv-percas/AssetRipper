using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.NestedLinkedScrollers
{
	[Token(Token = "0x2000038")]
	public class MasterData
	{
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x10")]
		public float normalizedScrollPosition;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x14")]
		public float linkedScrollPosition;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x18")]
		public List<DetailData> childData;

		[Token(Token = "0x600014D")]
		[Address(RVA = "0x402786C", Offset = "0x402786C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MasterData()
		{
		}
	}
}
