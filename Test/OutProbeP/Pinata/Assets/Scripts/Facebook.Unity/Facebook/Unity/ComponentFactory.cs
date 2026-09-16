using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity
{
	[Token(Token = "0x2000008")]
	internal class ComponentFactory
	{
		[Token(Token = "0x2000009")]
		internal enum IfNotExist
		{
			[Token(Token = "0x400001B")]
			AddNew = 0,
			[Token(Token = "0x400001C")]
			ReturnNull = 1
		}

		[Token(Token = "0x4000019")]
		private static GameObject facebookGameObject;

		[Token(Token = "0x1700000B")]
		private static GameObject FacebookGameObject
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0xD25140", Offset = "0xD25140", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = *([1EA9930]);\n\tv17 = *([v16 @ X8_v17]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023BA4]) = v37;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v44 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv59 = UnityEngine.Object::op_Equality(v43.facebookGameObject, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003F;\n\tv65 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v65, \"UnityFacebookSDKPlugin\");\n\tv72.facebookGameObject = v65;\nL_003F:\n\treturn v78.facebookGameObject;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (facebookGameObject == null)
				{
					GameObject gameObject = new GameObject("UnityFacebookSDKPlugin");
					facebookGameObject = gameObject;
				}
				return facebookGameObject;
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0xB88590", Offset = "0xB88590", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAFA30]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022A01]) = v43;\nL_0017:\n\tv45 = Facebook.Unity.ComponentFactory::get_FacebookGameObject();\n\tv52 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0031;\n\tv61 = *([v56 @ X8_v7+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0031;\n\tv72 = v56;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v72, v50, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0031:\n\tv71 = UnityEngine.Object::op_Equality(v52, 0);\n\tv73 = ifNotExist == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_004C;\n\tv91 = v71 == 0;\n\tif (v91) goto L_004C;\n\tv86 = Il2CppMethodInfo;\n\tv79 = *([v86 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 67 IndirectJump v79 @ X2_v2, v45 @ X0_v3 (UnityEngine.GameObject), v45 @ X0_v3 (UnityEngine.GameObject), methodof(UnityEngine.GameObject::AddComponent), v79 @ X2_v2, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_004C:\n\treturn v52;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetComponent<T>(IfNotExist ifNotExist = IfNotExist.AddNew) where T : MonoBehaviour
		{
			//IL_0078: Expected O, but got I
			GameObject gameObject = FacebookGameObject;
			UnityEngine.Object component = gameObject.GetComponent<T>();
			bool flag = component == null;
			if (ifNotExist == IfNotExist.AddNew && flag)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v79 @ X2_v2 (should have been resolved before IL gen)");
			}
			return (T)component;
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0xB88558", Offset = "0xB88558", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Facebook.Unity.ComponentFactory::get_FacebookGameObject();\n\tv16 = Il2CppMethodInfo;\n\tv17 = *([v16 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 17 IndirectJump v17 @ X2_v1, v11 @ X0_v2 (UnityEngine.GameObject), v11 @ X0_v2 (UnityEngine.GameObject), methodof(UnityEngine.GameObject::AddComponent), v17 @ X2_v1, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T AddComponent<T>() where T : MonoBehaviour
		{
			//IL_001c: Expected O, but got I
			GameObject gameObject = FacebookGameObject;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X2_v1 (should have been resolved before IL gen)");
			return null;
		}
	}
}
