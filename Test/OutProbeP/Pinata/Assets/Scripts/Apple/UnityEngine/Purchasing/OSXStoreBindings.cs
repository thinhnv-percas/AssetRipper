using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000004")]
	public class OSXStoreBindings : INativeAppleStore, INativeStore
	{
		[Token(Token = "0x17000005")]
		public string appReceipt
		{
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x167E9AC", Offset = "0x167E9AC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F011A0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55F]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NotImplementedException ex = new NotImplementedException();
				return (string)(object)new TypeLoadException();
			}
		}

		[Token(Token = "0x17000006")]
		public bool simulateAskToBuy
		{
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x167EA10", Offset = "0x167EA10", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EADF18]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B560]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				NotImplementedException ex = new NotImplementedException();
				throw new TypeLoadException();
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x167E6F0", Offset = "0x167E6F0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EF0E30]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, AsyncCallback, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B558]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetUnityPurchasingCallback(UnityPurchasingCallback AsyncCallback)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x167E754", Offset = "0x167E754", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EAA850]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B559]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreTransactions()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x167E7B8", Offset = "0x167E7B8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EA5258]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55A]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RefreshAppReceipt()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x167E81C", Offset = "0x167E81C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EE9FE0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55B]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddTransactionObserver()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x167E880", Offset = "0x167E880", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EA5F88]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, json, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55C]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(string json)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x167E8E4", Offset = "0x167E8E4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECB9C0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, developerPayload, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55D]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Purchase(string productJSON, string developerPayload)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x167E948", Offset = "0x167E948", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1F0C428]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productJSON, transactionID, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B55E]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(string productJSON, string transactionID)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x167EA74", Offset = "0x167EA74", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EBE2A8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, json, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B561]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStorePromotionOrder(string json)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x167EAD8", Offset = "0x167EAD8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ECE0E8]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, productId, visibility, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B562]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStorePromotionVisibility(string productId, string visibility)
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x167EB3C", Offset = "0x167EB3C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EC6468]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B563]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void InterceptPromotionalPurchases()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x167EBA0", Offset = "0x167EBA0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EFE5F0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([202B564]) = v34;\nL_0014:\n\tv38 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ContinuePromotionalPurchases()
		{
			NotImplementedException ex = new NotImplementedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x167EC04", Offset = "0x167EC04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OSXStoreBindings()
		{
		}
	}
}
