using Systems.FeatureSystem.Data;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.FeatureSystem.Core
{
	[Token(Token = "0x200002C")]
	public class FeatureService
	{
		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x3C67434", Offset = "0x3C67434", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		public bool IsFeatureEnabled(FeatureType featureType)
		{
			return true;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x3C67424", Offset = "0x3C67424", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public FeatureService()
		{
		}
	}
}
