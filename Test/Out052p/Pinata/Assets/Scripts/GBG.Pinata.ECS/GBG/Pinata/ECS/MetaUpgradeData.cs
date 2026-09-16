using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000035")]
	public class MetaUpgradeData
	{
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x10")]
		public int BoostValue;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x14")]
		public int NextUpgradeCost;

		[Token(Token = "0x6000062")]
		[Address(RVA = "0xCC28C8", Offset = "0xCC28C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeData()
		{
		}
	}
}
