using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.NestedScrollers
{
	[Token(Token = "0x2000042")]
	public class MasterData
	{
		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x10")]
		public float normalizedScrollPosition;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x18")]
		public List<DetailData> childData;

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x4028C2C", Offset = "0x4028C2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MasterData()
		{
		}
	}
}
