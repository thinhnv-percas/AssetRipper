using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000010")]
	internal class MetaData
	{
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x10")]
		public string friendlyName;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x18")]
		public string overlay;

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x3F45F7C", Offset = "0x3F45F7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MetaData()
		{
		}
	}
}
