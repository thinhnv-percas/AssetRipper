using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x7DCCDC", Offset = "0x7DCCDC")]
	[Token(Token = "0x2000005")]
	public class DemoInventory : MonoBehaviour
	{
		[Token(Token = "0x600002A")]
		[Address(RVA = "0x160C964", Offset = "0x160C964", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED1460]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, productId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A1FD]) = v38;\nL_0018:\n\tv44 = System.String::op_Equality(productId, \"100.gold.coins\");\n\tv46 = v44 == 0;\n\tif (v46) goto L_0031;\n\tgoto L_FFFFFFFF;\n\tv59 = *([v49 @ X0_v11+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_FFFFFFFF;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_0047;\nL_0031:\n\tv81 = System.String::Format(\"Unrecognized productId \\\"{0}\\\"\", productId);\n\tgoto L_0047;\n\tv92 = *([v72 @ X8_v10+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\t// 61 ConditionalJump @b14, v94 @ TEMP_v11\n\tv97 = v72;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v97, v55, v56, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0047:\n\tUnityEngine.Debug::Log(v81);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Fulfill(string productId)
		{
			string message = ((!(productId == "100.gold.coins")) ? $"Unrecognized productId \"{productId}\"" : "You Got Money!");
			Debug.Log(message);
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x160CA38", Offset = "0x160CA38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DemoInventory()
		{
		}
	}
}
