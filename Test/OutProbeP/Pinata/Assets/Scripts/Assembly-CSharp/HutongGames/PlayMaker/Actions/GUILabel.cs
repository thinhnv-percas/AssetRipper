using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756AE0", Offset = "0x756AE0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x756AE0", Offset = "0x756AE0")]
	[Token(Token = "0x2000204")]
	public class GUILabel : GUIContentAction
	{
		[Token(Token = "0x6000A7B")]
		[Address(RVA = "0xB78A38", Offset = "0xB78A38", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ED81E0]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022944]) = v46;\nL_0018:\n\tHutongGames.PlayMaker.Actions.GUIContentAction::OnGUI(this);\n\tv51 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv69 = System.String::IsNullOrEmpty(v51);\n\tv71 = v69 == 0;\n\tif (v71) goto L_004A;\n\tgoto L_0043;\n\tv137 = *([v133 @ X0_v19+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0043;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v61, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0043:\n\t// 67 MakeStruct v81 @ AGGB78AEC_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tUnityEngine.GUI::Label(v81, this.content);\n\treturn;\nL_004A:\n\tv143 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_005B;\n\tv151 = *([v147 @ X8_v5+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_005B;\n\tv161 = v147;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v161, v142, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_005B:\n\tv160 = UnityEngine.GUIStyle::op_Implicit(v143);\n\tgoto L_007A;\n\tv168 = *([v124 @ X8_v8+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_007A;\n\tv173 = v124;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v173, v159, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007A:\n\t// 122 MakeStruct v74 @ AGGB78B88_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tUnityEngine.GUI::Label(v74, this.content, v160);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			base.OnGUI();
			string value = style.Value;
			if (string.IsNullOrEmpty(value))
			{
				Rect position = default(Rect);
				position.x = rect.x;
				position.y = rect.y;
				position.width = rect.width;
				position.height = rect.height;
				GUI.Label(position, content);
			}
			else
			{
				string value2 = style.Value;
				GUIStyle gUIStyle = value2;
				Rect position2 = default(Rect);
				position2.x = rect.x;
				position2.y = rect.y;
				position2.width = rect.width;
				position2.height = rect.height;
				GUI.Label(position2, content, gUIStyle);
			}
		}

		[Token(Token = "0x6000A7C")]
		[Address(RVA = "0xB78B90", Offset = "0xB78B90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILabel()
		{
		}
	}
}
