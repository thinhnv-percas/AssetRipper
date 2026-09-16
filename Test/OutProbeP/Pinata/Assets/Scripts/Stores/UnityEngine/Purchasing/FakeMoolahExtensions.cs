using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000014")]
	internal class FakeMoolahExtensions : IMoolahExtension, IStoreExtension
	{
		[Token(Token = "0x6000046")]
		[Address(RVA = "0xC5F064", Offset = "0xC5F064", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EED838]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, result, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202332B]) = v38;\nL_001F:\n\tSystem.Action`1<UnityEngine.Purchasing.RestoreTransactionIDState>::Invoke(result, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactionID(Action<RestoreTransactionIDState> result)
		{
			result(RestoreTransactionIDState.RestoreSucceed);
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xC5F0C4", Offset = "0xC5F0C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FakeMoolahExtensions()
		{
		}
	}
}
