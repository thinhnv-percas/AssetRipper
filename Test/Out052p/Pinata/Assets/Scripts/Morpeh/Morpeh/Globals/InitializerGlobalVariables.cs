using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[Token(Token = "0x200001E")]
	internal static class InitializerGlobalVariables
	{
		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x15F80A8", Offset = "0x15F80A8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EFDAE8]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A065]) = v35;\nL_0014:\n\tv39 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v39, \"MORPEH__HOOK_APPLICATION_FOCUS\");\n\tv50 = UnityEngine.GameObject::AddComponent(v39);\n\tUnityEngine.Object::set_hideFlags(v39, 0x3D);\n\tgoto L_0038;\n\tv77 = *([v58 @ X0_v9+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0038;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v58, v53, v55, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0038:\n\tUnityEngine.Object::DontDestroyOnLoad(v39);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void Initialize()
		{
			GameObject gameObject = new GameObject("MORPEH__HOOK_APPLICATION_FOCUS");
			MApplicationFocusHook mApplicationFocusHook = gameObject.AddComponent<MApplicationFocusHook>();
			gameObject.hideFlags = HideFlags.HideAndDontSave;
			Object.DontDestroyOnLoad(gameObject);
		}
	}
}
