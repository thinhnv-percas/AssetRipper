using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756EA0", Offset = "0x756EA0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756EA0", Offset = "0x756EA0")]
	[Token(Token = "0x2000210")]
	public class SetMouseCursor : FsmStateAction
	{
		[Token(Token = "0x40014D5")]
		[FieldOffset(Offset = "0x50")]
		public FsmTexture cursorTexture;

		[Token(Token = "0x40014D6")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool hideCursor;

		[Token(Token = "0x40014D7")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool lockCursor;

		[Token(Token = "0x6000AA0")]
		[Address(RVA = "0x997D20", Offset = "0x997D20", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cursorTexture = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.hideCursor = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.lockCursor = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			cursorTexture = null;
			FsmBool fsmBool = false;
			hideCursor = fsmBool;
			FsmBool fsmBool2 = false;
			lockCursor = fsmBool2;
		}

		[Token(Token = "0x6000AA1")]
		[Address(RVA = "0x997D60", Offset = "0x997D60", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EDDF78]);\n\tv23 = *([v22 @ X8_v34]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021781]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmBool::get_Value(this.lockCursor);\n\tgoto L_002C;\n\tv76 = *([v72 @ X8_v4+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_002C;\n\tv107 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v107, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tgoto L_0037;\n\tv109 = *([1EABE88]);\n\tv110 = *([v109 @ X8_v30]);\n\tv111 = \"il2cpp_codegen_initialize_method\"(v110, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv114 = 0 | 1;\n\t*([202181A]) = v114;\nL_0037:\n\tgoto L_0040;\n\tv119 = *([v115 @ X0_v8 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tgoto L_0040;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v115, v45, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv123 = PlayMakerGUI;\nL_0040:\n\tv65.<LockCursor>k__BackingField = v46;\n\tv127 = HutongGames.PlayMaker.FsmBool::get_Value(this.hideCursor);\n\tgoto L_0056;\n\tv132 = *([1EEBC70]);\n\tv133 = *([v132 @ X8_v26]);\n\tv134 = \"il2cpp_codegen_initialize_method\"(v133, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv137 = 0 | 1;\n\t*([202181B]) = v137;\nL_0056:\n\tgoto L_005F;\n\tv142 = *([v138 @ X0_v13 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tgoto L_005F;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v138, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv146 = PlayMakerGUI;\nL_005F:\n\tv66.<HideCursor>k__BackingField = v127;\n\tv151 = HutongGames.PlayMaker.FsmTexture::get_Value(this.cursorTexture);\n\tgoto L_0075;\n\tv158 = *([1EB5E80]);\n\tv159 = *([v158 @ X8_v22]);\n\tv160 = \"il2cpp_codegen_initialize_method\"(v159, v150, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv163 = 0 | 1;\n\t*([202181C]) = v163;\nL_0075:\n\tgoto L_007F;\n\tv168 = *([v164 @ X0_v18 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tgoto L_007F;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v164, v150, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv172 = PlayMakerGUI;\nL_007F:\n\tv102.<MouseCursor>k__BackingField = v151;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = lockCursor.Value;
			PlayMakerGUI.LockCursor = value;
			bool value2 = hideCursor.Value;
			PlayMakerGUI.HideCursor = value2;
			Texture value3 = cursorTexture.Value;
			PlayMakerGUI.MouseCursor = value3;
			Finish();
		}

		[Token(Token = "0x6000AA2")]
		[Address(RVA = "0x997EF4", Offset = "0x997EF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMouseCursor()
		{
		}
	}
}
