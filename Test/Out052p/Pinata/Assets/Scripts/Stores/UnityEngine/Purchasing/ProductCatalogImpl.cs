using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200006C")]
	internal class ProductCatalogImpl : IProductCatalogImpl
	{
		[Token(Token = "0x600018E")]
		[Address(RVA = "0xC6B6A4", Offset = "0xC6B6A4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EC91C0]);\n\tv15 = *([v14 @ X8_v19]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023395]) = v35;\nL_0015:\n\tv40 = UnityEngine.Resources::Load(\"IAPProductCatalog\");\n\tv41 = v40 == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0043;\n\tv94 = v94_asT == 0;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tgoto L_004C;\n\tv120 = *([v116 @ X0_v4+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tgoto L_004C;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v38, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_004C:\n\tv130 = UnityEngine.Object::op_Inequality(v111, 0);\n\tv132 = v130 == 0;\n\tif (v132) goto L_005A;\n\treturnVal1 = UnityEngine.Purchasing.ProductCatalog::FromTextAsset(v111);\n\treturn returnVal1;\nL_005A:\n\tv141 = new UnityEngine.Purchasing.ProductCatalog();\n\tUnityEngine.Purchasing.ProductCatalog::.ctor(v141);\n\treturn v141;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductCatalog LoadDefaultCatalog()
		{
			Object obj = Resources.Load("IAPProductCatalog");
			Object obj2;
			if ((object)obj == null)
			{
				obj2 = null;
			}
			else
			{
				TextAsset textAsset = obj as TextAsset;
				obj2 = (((object)textAsset == null) ? null : obj);
			}
			if (obj2 != null)
			{
				return ProductCatalog.FromTextAsset((TextAsset)obj2);
			}
			return new ProductCatalog();
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xC6B37C", Offset = "0xC6B37C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductCatalogImpl()
		{
		}
	}
}
