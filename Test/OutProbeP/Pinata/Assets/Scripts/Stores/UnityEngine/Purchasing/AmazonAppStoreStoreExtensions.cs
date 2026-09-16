using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000F")]
	public class AmazonAppStoreStoreExtensions : IAmazonExtensions, IStoreExtension, IAmazonConfiguration, IStoreConfiguration
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject android;

		[Token(Token = "0x1700000E")]
		public string amazonUserId
		{
			[Token(Token = "0x600003C")]
			[Address(RVA = "0xC577F8", Offset = "0xC577F8", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED3D80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20232E2]) = v38;\nL_0018:\n\t// 24 NewArr v44 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.android, \"getAmazonUserId\", v44);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				object[] args = new object[0];
				return android.Call<string>("getAmazonUserId", args);
			}
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0xC5742C", Offset = "0xC5742C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.android = a;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AmazonAppStoreStoreExtensions(AndroidJavaObject a)
		{
			android = a;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0xC57458", Offset = "0xC57458", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F04FB0]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, products, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232E1]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = UnityEngine.Purchasing.JSONSerializer::SerializeProductDefs(products);\n\tv53 = v50 == 0;\n\tif (v53) goto L_002A;\n\t// 38 IsInst v67 @ X0_v16, typeof(System.Object), v50 @ X0_v5 (System.String)\nL_002A:\n\tv71 = v47.Length == 0;\n\tif (v71) goto L_003F;\n\tv47[0] = v50;\n\tUnityEngine.AndroidJavaObject::Call(this.android, \"writeSandboxJSON\", v47);\n\treturn;\n\tv63 = new System.NullReferenceException();\nL_003F:\n\tv76 = new System.IndexOutOfRangeException();\n\tgoto L_0044;\n\tv77 = new System.ArrayTypeMismatchException();\nL_0044:\n\tthrow v90;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void WriteSandboxJSON(HashSet<ProductDefinition> products)
		{
			object[] array = new object[1];
			string text = JSONSerializer.SerializeProductDefs(products);
			if (text != null)
			{
				object obj = text as object;
			}
			if (array.Length != 0)
			{
				array[0] = text;
				android.Call("writeSandboxJSON", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
