using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

namespace GoogleMobileAds.Unity
{
	[Token(Token = "0x200000E")]
	public class ResponseInfoDummyClient : IResponseInfoClient
	{
		[Token(Token = "0x600005F")]
		[Address(RVA = "0x13406B0", Offset = "0x13406B0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Dummy Mediation Adapter Class Name\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36769]) = v34;\nL_0016:\n\treturn \"Dummy Mediation Adapter Class Name\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetMediationAdapterClassName()
		{
			return "Dummy Mediation Adapter Class Name";
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x134186C", Offset = "0x134186C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Dummy Response ID\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3676A]) = v34;\nL_0016:\n\treturn \"Dummy Response ID\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetResponseId()
		{
			return "Dummy Response ID";
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x13406A8", Offset = "0x13406A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResponseInfoDummyClient()
		{
		}
	}
}
