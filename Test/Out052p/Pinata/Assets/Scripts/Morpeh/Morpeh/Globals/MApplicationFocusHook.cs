using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[Token(Token = "0x200001F")]
	internal class MApplicationFocusHook : MonoBehaviour
	{
		[Token(Token = "0x400004C")]
		internal static Action OnApplicationFocusLost;

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x15F8164", Offset = "0x15F8164", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EBAB50]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, hasFocus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202A066]) = v38;\nL_0014:\n\tv40 = hasFocus == 0;\n\tif (v40) goto L_0022;\n\treturn;\nL_0022:\n\tgoto L_0033;\n\tv68 = *([v47 @ X0_v2 (Il2CppClass<Morpeh.Globals.MApplicationFocusHook>)+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\t// 38 ConditionalJump @b15, v70 @ TEMP_v11\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v47, hasFocus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv72 = Morpeh.Globals.MApplicationFocusHook;\nL_0033:\n\tSystem.Action::Invoke(v63.OnApplicationFocusLost);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool hasFocus)
		{
			if (!hasFocus)
			{
				OnApplicationFocusLost();
			}
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x15F81EC", Offset = "0x15F81EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MApplicationFocusHook()
		{
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x15F81F4", Offset = "0x15F81F4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EEF818]);\n\tv17 = *([v16 @ X8_v14]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202A067]) = v37;\nL_0018:\n\tgoto L_0024;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Morpeh.Globals.MApplicationFocusHook+<>c>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Morpeh.Globals.MApplicationFocusHook+<>c;\nL_0024:\n\tv56 = new System.Action();\n\tSystem.Action::.ctor(v56, v52.<>9, Il2CppMethodInfo);\n\tv67.OnApplicationFocusLost = v56;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static MApplicationFocusHook()
		{
			Action onApplicationFocusLost = delegate
			{
			};
			OnApplicationFocusLost = onApplicationFocusLost;
		}
	}
}
