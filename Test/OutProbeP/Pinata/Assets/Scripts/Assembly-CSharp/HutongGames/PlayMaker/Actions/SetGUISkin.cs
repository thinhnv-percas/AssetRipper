using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756E50", Offset = "0x756E50")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756E50", Offset = "0x756E50")]
	[Token(Token = "0x200020F")]
	public class SetGUISkin : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014D3")]
		[FieldOffset(Offset = "0x50")]
		public GUISkin skin;

		[Token(Token = "0x40014D4")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool applyGlobally;

		[Token(Token = "0x6000A9D")]
		[Address(RVA = "0x994464", Offset = "0x994464", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skin = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.applyGlobally = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			skin = null;
			FsmBool fsmBool = true;
			applyGlobally = fsmBool;
		}

		[Token(Token = "0x6000A9E")]
		[Address(RVA = "0x994494", Offset = "0x994494", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EAB318]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021748]) = v42;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = UnityEngine.Object::op_Inequality(this.skin, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_003D;\n\tgoto L_0038;\n\tv81 = *([v66 @ X0_v22+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0038;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v66, v58, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0038:\n\tUnityEngine.GUI::set_skin(this.skin);\nL_003D:\n\tv87 = HutongGames.PlayMaker.FsmBool::get_Value(this.applyGlobally);\n\tv90 = v87 == 0;\n\tif (v90) goto L_0078;\n\tgoto L_0052;\n\tv124 = *([v94 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0052;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v94, v86, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0052:\n\tgoto L_005D;\n\tv136 = *([1EC28D8]);\n\tv137 = *([v136 @ X8_v17]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v86, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([2021819]) = v141;\nL_005D:\n\tgoto L_0067;\n\tv146 = *([v142 @ X0_v13 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tgoto L_0067;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v142, v86, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv150 = PlayMakerGUI;\nL_0067:\n\tv119.guiSkin = this.skin;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			if (skin != null)
			{
				GUI.skin = skin;
			}
			if (applyGlobally.Value)
			{
				PlayMakerGUI.guiSkin = skin;
				Finish();
			}
		}

		[Token(Token = "0x6000A9F")]
		[Address(RVA = "0x9945E0", Offset = "0x9945E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUISkin()
		{
		}
	}
}
