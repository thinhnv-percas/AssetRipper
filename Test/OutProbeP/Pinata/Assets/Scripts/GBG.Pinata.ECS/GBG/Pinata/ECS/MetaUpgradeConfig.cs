using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x2000034")]
	public class MetaUpgradeConfig
	{
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x10")]
		public List<MetaUpgradeData> Data;

		[Token(Token = "0x6000061")]
		[Address(RVA = "0xCC2870", Offset = "0xCC2870", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeConfig()
		{
		}
	}
}
