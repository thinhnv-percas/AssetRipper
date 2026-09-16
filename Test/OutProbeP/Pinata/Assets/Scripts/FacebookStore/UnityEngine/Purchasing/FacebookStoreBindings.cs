using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000003")]
	public class FacebookStoreBindings : INativeFacebookStore, INativeStore
	{
		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1680B10", Offset = "0x1680B10", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Check()
		{
			return false;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x1680B18", Offset = "0x1680B18", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB32C8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B5B8]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x1680B7C", Offset = "0x1680B7C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED4198]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, AsyncCallback, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B5B9]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x1680BE0", Offset = "0x1680BE0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EB7A10]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, json, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B5BA]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(string json)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1680C44", Offset = "0x1680C44", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EAAF60]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, developerPayload, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B5BB]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Purchase(string productJSON, string developerPayload)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1680CA8", Offset = "0x1680CA8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EED9F0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, transactionID, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B5BC]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(string productJSON, string transactionID)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1680D0C", Offset = "0x1680D0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FacebookStoreBindings()
		{
		}
	}
}
