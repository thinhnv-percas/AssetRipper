using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000082")]
	internal class FakeMicrosoftExtensions : IMicrosoftExtensions, IStoreExtension
	{
		[Token(Token = "0x600021F")]
		[Address(RVA = "0xC5F03C", Offset = "0xC5F03C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void RestoreTransactions()
		{
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0xC5F040", Offset = "0xC5F040", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeMicrosoftExtensions()
		{
		}
	}
}
