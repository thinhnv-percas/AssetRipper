using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756BD0", Offset = "0x756BD0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756BD0", Offset = "0x756BD0")]
	[Token(Token = "0x2000207")]
	public class ResetGUIMatrix : FsmStateAction
	{
		[Token(Token = "0x6000A83")]
		[Address(RVA = "0xB24088", Offset = "0xB24088", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0019;\n\tv18 = *([1EEB7F8]);\n\tv19 = *([v18 @ X8_v27]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20225CE]) = v39;\nL_0019:\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv55 = UnityEngine.Matrix4x4::get_identity();\n\tv59 = *([v10 @ X29_v1-A0]);\n\tgoto L_0040;\n\tv70 = *([v66 @ X0_v6+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0040;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v22, v23, v24, v25, v26, v27, v58, v57, v60, v59, v32, v33, v34, v35);\nL_0040:\n\tUnityEngine.GUI::set_matrix(&v59 @ V3_v1);\n\tgoto L_0059;\n\tv93 = *([v89 @ X0_v9+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0059;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v89, v83, v22, v23, v24, v25, v26, v27, v78, v77, v80, v79, v32, v33, v34, v35);\nL_0059:\n\tgoto L_0065;\n\tv113 = *([1ED14F8]);\n\tv114 = *([v113 @ X8_v21]);\n\tv115 = \"il2cpp_codegen_initialize_method\"(v114, v83, v22, v23, v24, v25, v26, v27, v102, v101, v104, v103, v32, v33, v34, v35);\n\tv118 = 0 | 1;\n\t*([202262E]) = v118;\nL_0065:\n\t*([v10 @ X29_v1-40]) = *([v10 @ X29_v1-80]);\n\t*([v10 @ X29_v1-30]) = *([v10 @ X29_v1-70]);\n\t*([v10 @ X29_v1-60]) = v59;\n\t*([v10 @ X29_v1-50]) = *([v10 @ X29_v1-90]);\n\tgoto L_0073;\n\tv127 = *([v123 @ X0_v12 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tgoto L_0073;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v123, v83, v22, v23, v24, v25, v26, v27, v120, v119, v122, v121, v32, v33, v34, v35);\n\tv131 = PlayMakerGUI;\nL_0073:\n\tv134 = *([v130 @ X0_v13 (Il2CppClass<PlayMakerGUI>)+B8]);\n\t*([v134 @ X8_v18 (Il2CppStaticFields<PlayMakerGUI>)+A0]) = *([v10 @ X29_v1-30]);\n\t*([v134 @ X8_v18 (Il2CppStaticFields<PlayMakerGUI>)+90]) = *([v10 @ X29_v1-40]);\n\t*([v134 @ X8_v18 (Il2CppStaticFields<PlayMakerGUI>)+80]) = *([v10 @ X29_v1-50]);\n\tv134.guiMatrix = *([v10 @ X29_v1-60]);\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnGUI()
		{
			//IL_0026: Expected O, but got I
			//IL_0034: Expected O, but got Ref
			//IL_007d: Expected I, but got O
			//IL_008b: Expected I, but got O
			//IL_00c3: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Matrix4x4 identity = Matrix4x4.identity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-A0]");
			object obj3 = 0;
			GUI.matrix = (Matrix4x4)(&obj3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-90]");
			_ = 0;
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)PlayMakerGUI.fsmList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-30]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-60]");
			PlayMakerGUI.guiMatrix = (Matrix4x4)0;
		}

		[Token(Token = "0x6000A84")]
		[Address(RVA = "0xB241F0", Offset = "0xB241F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ResetGUIMatrix()
		{
		}
	}
}
