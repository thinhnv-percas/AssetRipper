using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000026")]
	internal class GooglePlayStoreCallback : AndroidJavaProxy
	{
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x20")]
		private Action<bool> callback;

		[Token(Token = "0x6000098")]
		[Address(RVA = "0xC61958", Offset = "0xC61958", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB98A8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023339]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, callback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.purchasing.googleplay.IGooglePlayStoreCallback\");\n\tthis.callback = callback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GooglePlayStoreCallback(Action<bool> callback)
			: base("com.unity.purchasing.googleplay.IGooglePlayStoreCallback")
		{
			this.callback = callback;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0xC619E0", Offset = "0xC619E0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECBE48]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, result, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202333A]) = v41;\nL_0016:\n\tv43 = this.callback == 0;\n\tif (v43) goto L_002A;\n\tSystem.Action`1<System.Boolean>::Invoke(this.callback, result);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnTransactionsRestored(bool result)
		{
			if (callback != null)
			{
				callback(result);
			}
		}
	}
}
