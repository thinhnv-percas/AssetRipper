using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x200000F")]
	internal class SimulationDevice
	{
		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x10")]
		public MetaData Meta;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x18")]
		public ScreenData[] Screens;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x20")]
		public SystemInfoData SystemInfo;

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x3F45F58", Offset = "0x3F45F58", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.Meta;\n\treturn v0.friendlyName;\n")]
		public override string ToString()
		{
			MetaData meta = Meta;
			return meta.friendlyName;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x3F45F74", Offset = "0x3F45F74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SimulationDevice()
		{
		}
	}
}
