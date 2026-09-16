using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000003")]
	internal class AndroidJavaStore : INativeStore
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		internal AndroidJavaObject m_Store;

		[Token(Token = "0x6000013")]
		[Address(RVA = "0xC5787C", Offset = "0xC5787C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Store;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected AndroidJavaObject GetStore()
		{
			return m_Store;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0xC57884", Offset = "0xC57884", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Store = store;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidJavaStore(AndroidJavaObject store)
		{
			m_Store = store;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0xC578B0", Offset = "0xC578B0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBABA8]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, json, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20232E3]) = v41;\nL_001A:\n\t// 26 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv50 = json == 0;\n\tif (v50) goto L_0027;\n\t// 35 IsInst v55 @ X0_v16, typeof(System.Object), json @ X1 (System.String)\nL_0027:\n\tv62 = v47.Length == 0;\n\tif (v62) goto L_003B;\n\tv47[0] = json;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Store, \"RetrieveProducts\", v47);\n\treturn;\n\tv51 = new System.NullReferenceException();\nL_003B:\n\tv67 = new System.IndexOutOfRangeException();\n\tgoto L_0042;\n\tv71 = new System.NullReferenceException();\n\tv74 = new System.ArrayTypeMismatchException();\nL_0042:\n\tthrow v88;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RetrieveProducts(string json)
		{
			object[] array = new object[1];
			if (json != null)
			{
				object obj = json as object;
			}
			if (array.Length != 0)
			{
				array[0] = json;
				m_Store.Call("RetrieveProducts", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0xC57980", Offset = "0xC57980", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ECEFE0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productJSON, developerPayload, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20232E4]) = v44;\nL_001C:\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = productJSON == 0;\n\tif (v53) goto L_0028;\n\t// 37 IsInst v95 @ X0_v21, typeof(System.Object), productJSON @ X1 (System.String)\nL_0028:\n\tv129 = v50.Length;\n\tv102 = v50.Length == 0;\n\tif (v102) goto L_0053;\n\tv50[0] = productJSON;\n\tv132 = developerPayload == 0;\n\tif (v132) goto L_0035;\n\t// 49 IsInst v151 @ X0_v19, typeof(System.Object), developerPayload @ X2 (System.String)\n\tv129 = v50.Length;\nL_0035:\n\tv159 = v129 < 1;\n\tv120 = ~v159;\n\tv118 = v129 - 1;\n\tv114 = v118 == 0;\n\tv160 = ~v120;\n\tv104 = v160 | v114;\n\tif (v104) goto L_0053;\n\tv50[1] = developerPayload;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Store, \"Purchase\", v50);\n\treturn;\nL_0053:\n\tv147 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv156 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v194;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Purchase(string productJSON, string developerPayload)
		{
			//IL_003e: Expected O, but got I4
			//IL_0128: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (productJSON != null)
			{
				object obj = productJSON as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = productJSON;
				if (developerPayload != null)
				{
					object obj3 = developerPayload as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = developerPayload;
					m_Store.Call("Purchase", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0xC57A7C", Offset = "0xC57A7C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EAABC0]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productJSON, transactionID, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20232E5]) = v44;\nL_001C:\n\t// 28 NewArr v50 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv53 = productJSON == 0;\n\tif (v53) goto L_0028;\n\t// 37 IsInst v95 @ X0_v21, typeof(System.Object), productJSON @ X1 (System.String)\nL_0028:\n\tv129 = v50.Length;\n\tv102 = v50.Length == 0;\n\tif (v102) goto L_0053;\n\tv50[0] = productJSON;\n\tv132 = transactionID == 0;\n\tif (v132) goto L_0035;\n\t// 49 IsInst v151 @ X0_v19, typeof(System.Object), transactionID @ X2 (System.String)\n\tv129 = v50.Length;\nL_0035:\n\tv159 = v129 < 1;\n\tv120 = ~v159;\n\tv118 = v129 - 1;\n\tv114 = v118 == 0;\n\tv160 = ~v120;\n\tv104 = v160 | v114;\n\tif (v104) goto L_0053;\n\tv50[1] = transactionID;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Store, \"FinishTransaction\", v50);\n\treturn;\nL_0053:\n\tv147 = new System.IndexOutOfRangeException();\n\tgoto L_0058;\n\tv156 = new System.ArrayTypeMismatchException();\nL_0058:\n\tthrow v194;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FinishTransaction(string productJSON, string transactionID)
		{
			//IL_003e: Expected O, but got I4
			//IL_0128: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (productJSON != null)
			{
				object obj = productJSON as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = productJSON;
				if (transactionID != null)
				{
					object obj3 = transactionID as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = transactionID;
					m_Store.Call("FinishTransaction", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
