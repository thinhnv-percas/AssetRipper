using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.XR;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000024")]
	internal class GooglePlayAndroidJavaStore : AndroidJavaStore
	{
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x18")]
		private IUtil m_Util;

		[Token(Token = "0x6000095")]
		[Address(RVA = "0xC61690", Offset = "0xC61690", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB05C0]);\n\tv27 = *([v26 @ X8_v31]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, store, util, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023337]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.m_Store = store;\n\tthis.m_Util = util;\n\tgoto L_0030;\n\tv59 = *([v49 @ X0_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0030;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, v46, util, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0030:\n\tv68 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.PurchaseFailureReason);\n\tgoto L_0044;\n\tv76 = *([v72 @ X8_v12+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0044;\n\tv89 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v89, v67, util, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0044:\n\tv88 = System.Enum::IsDefined(v68, \"DuplicateTransaction\");\n\tv91 = v88 == 0;\n\tif (v91) goto L_0054;\n\tv97 = System.String::Concat(\"\", \"supportsPurchaseFailureReasonDuplicateTransaction\");\nL_0054:\n\t// 84 NewArr v109 @ X0_v12 (System.Object[]), typeof(System.Object[]), 1\n\tv112 = v101 == 0;\n\tif (v112) goto L_0061;\n\t// 93 IsInst v117 @ X0_v25, typeof(System.Object), v101 @ X20_v3 (System.String)\nL_0061:\n\tv124 = v109.Length == 0;\n\tif (v124) goto L_0076;\n\tv109[0] = v101;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Store, \"SetFeatures\", v109);\n\treturn;\n\tv113 = new System.NullReferenceException();\nL_0076:\n\tv129 = new System.IndexOutOfRangeException();\n\tgoto L_007D;\n\tv133 = new System.NullReferenceException();\n\tv136 = new System.ArrayTypeMismatchException();\nL_007D:\n\tthrow v151;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GooglePlayAndroidJavaStore(AndroidJavaObject store, IUtil util)
		{
			m_Store = store;
			m_Util = util;
			Type typeFromHandle = typeof(PurchaseFailureReason);
			bool flag = Enum.IsDefined(typeFromHandle, "DuplicateTransaction");
			bool flag2 = !flag;
			string text = "";
			if (!flag2)
			{
				string text2 = "" + "supportsPurchaseFailureReasonDuplicateTransaction";
				text = text2;
			}
			object[] array = new object[1];
			if (text != null)
			{
				object obj = text as object;
			}
			if (array.Length != 0)
			{
				array[0] = text;
				m_Store.Call("SetFeatures", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0xC61818", Offset = "0xC61818", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1EE0200]);\n\tv31 = *([v30 @ X8_v21]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, productJSON, developerPayload, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023338]) = v48;\nL_0020:\n\tv55 = System.String::Contains(developerPayload, \"iapPromo\");\n\tv84 = v55 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0051;\n\t// 42 NewArr v102 @ X0_v14 (System.Object[]), typeof(System.Object[]), 1\n\tv55 = UnityEngine.XR.XRSettings::get_enabled();\n\t// 53 Box v55 @ X0_v10 (System.Boolean), typeof(System.Boolean), &v55 @ X0_v10 (System.Boolean)\n\tv168 = v55 == 0;\n\tif (v168) goto L_0042;\n\t// 62 IsInst v55 @ X0_v10 (System.Boolean), typeof(System.Object), v55 @ X0_v10 (System.Boolean)\nL_0042:\n\tv94 = v102.Length == 0;\n\tif (v94) goto L_005E;\n\tv102[0] = v55;\n\tUnityEngine.AndroidJavaObject::Call(this.m_Store, \"SetUnityVrEnabled\", v102);\nL_0051:\n\tUnityEngine.Purchasing.AndroidJavaStore::Purchase(this, productJSON, developerPayload);\n\treturn;\n\tv82 = new System.NullReferenceException();\nL_005E:\n\tv97 = new System.IndexOutOfRangeException();\n\tgoto L_0063;\n\tv140 = new System.ArrayTypeMismatchException();\nL_0063:\n\tthrow v139;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Purchase(string productJSON, string developerPayload)
		{
			//IL_0068: Expected I4, but got O
			//IL_0093: Expected O, but got I4
			//IL_0097: Expected I4, but got O
			//IL_00cd: Expected O, but got I4
			if (!developerPayload.Contains("iapPromo"))
			{
				object[] array = new object[1];
				bool enabled = XRSettings.enabled;
				enabled = (byte)(int)(object)enabled != 0;
				if (enabled)
				{
					enabled = (byte)(int)(enabled as object) != 0;
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				array[0] = enabled;
				m_Store.Call("SetUnityVrEnabled", array);
			}
			base.Purchase(productJSON, developerPayload);
		}
	}
}
