using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000089")]
	internal class FakeTizenStoreConfiguration : ITizenStoreConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x6000236")]
		[Address(RVA = "0xC61180", Offset = "0xC61180", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void SetGroupId(string group)
		{
		}

		[Token(Token = "0x6000237")]
		[Address(RVA = "0xC61184", Offset = "0xC61184", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeTizenStoreConfiguration()
		{
		}
	}
}
