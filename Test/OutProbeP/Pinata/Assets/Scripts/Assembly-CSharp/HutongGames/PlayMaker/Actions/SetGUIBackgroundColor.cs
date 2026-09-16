using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756D10", Offset = "0x756D10")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756D10", Offset = "0x756D10")]
	[Token(Token = "0x200020B")]
	public class SetGUIBackgroundColor : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014CC")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor backgroundColor;

		[Token(Token = "0x40014CD")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool applyGlobally;

		[Token(Token = "0x6000A90")]
		[Address(RVA = "0x993EF4", Offset = "0x993EF4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.backgroundColor = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			Color white = Color.white;
			FsmColor fsmColor = white;
			backgroundColor = fsmColor;
		}

		[Token(Token = "0x6000A91")]
		[Address(RVA = "0x993F24", Offset = "0x993F24", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F0E338]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021744]) = v46;\nL_0017:\n\tv47 = this.backgroundColor;\n\tgoto L_002F;\n\tv60 = *([v55 @ X0_v5+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_002F;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002F:\n\t// 47 MakeStruct v72 @ AGG993FA4_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v47.value (UnityEngine.Color), v47.value.g (System.Single), v47.value.b (System.Single), v47.value.a (System.Single)\n\tUnityEngine.GUI::set_backgroundColor(v72);\n\tv93 = HutongGames.PlayMaker.FsmBool::get_Value(this.applyGlobally);\n\tv128 = v93 == 0;\n\tif (v128) goto L_007C;\n\tgoto L_0044;\n\tv152 = *([v129 @ X0_v11+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_0044;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v129, v92, v30, v31, v32, v33, v34, v35, v67, v68, v69, v70, v40, v41, v42, v43);\nL_0044:\n\tv136 = UnityEngine.GUI::get_backgroundColor();\n\tgoto L_005C;\n\tv165 = *([v161 @ X0_v14+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_005C;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v161, v92, v30, v31, v32, v33, v34, v35, v136, v135, v134, v133, v40, v41, v42, v43);\nL_005C:\n\tgoto L_FFFFFFFF;\n\tv176 = *([1EDA728]);\n\tv177 = *([v176 @ X8_v18]);\n\tv178 = \"il2cpp_codegen_initialize_method\"(v177, v92, v30, v31, v32, v33, v34, v35, v136, v135, v134, v133, v40, v41, v42, v43);\n\tv181 = 0 | 1;\n\t*([2021817]) = v181;\n\tgoto L_006E;\n\tv186 = *([v182 @ X0_v17 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tgoto L_006E;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v182, v92, v30, v31, v32, v33, v34, v35, v136, v135, v134, v133, v40, v41, v42, v43);\n\tv189 = PlayMakerGUI;\nL_006E:\n\tv149 = *([v145 @ X0_v18 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv149.guiBackgroundColor = v136;\n\t*([v149 @ X8_v15 (Il2CppStaticFields<PlayMakerGUI>)+54]) = v136.g;\n\t*([v149 @ X8_v15 (Il2CppStaticFields<PlayMakerGUI>)+58]) = v136.b;\n\t*([v149 @ X8_v15 (Il2CppStaticFields<PlayMakerGUI>)+5C]) = v136.a;\nL_007C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_00d6: Expected I, but got O
			//IL_00e4: Expected I, but got O
			FsmColor fsmColor = backgroundColor;
			Color color = default(Color);
			color.r = fsmColor.value.r;
			color.g = fsmColor.value.g;
			color.b = fsmColor.value.b;
			color.a = fsmColor.value.a;
			GUI.backgroundColor = color;
			if (applyGlobally.Value)
			{
				Color guiBackgroundColor = GUI.backgroundColor;
				IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
				IntPtr intPtr2 = (IntPtr)PlayMakerGUI.fsmList;
				PlayMakerGUI.guiBackgroundColor = guiBackgroundColor;
				_ = guiBackgroundColor.g;
				_ = guiBackgroundColor.b;
				_ = guiBackgroundColor.a;
			}
		}

		[Token(Token = "0x6000A92")]
		[Address(RVA = "0x994074", Offset = "0x994074", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUIBackgroundColor()
		{
		}
	}
}
