using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7572D8", Offset = "0x7572D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7572D8", Offset = "0x7572D8")]
	[Token(Token = "0x200021C")]
	public class GUILayoutBox : GUILayoutAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B25A8", Offset = "0x7B25A8")]
		[Token(Token = "0x4001503")]
		[FieldOffset(Offset = "0x60")]
		public FsmTexture image;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B25E0", Offset = "0x7B25E0")]
		[Token(Token = "0x4001504")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2618", Offset = "0x7B2618")]
		[Token(Token = "0x4001505")]
		[FieldOffset(Offset = "0x70")]
		public FsmString tooltip;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2650", Offset = "0x7B2650")]
		[Token(Token = "0x4001506")]
		[FieldOffset(Offset = "0x78")]
		public FsmString style;

		[Token(Token = "0x6000ACB")]
		[Address(RVA = "0xB79C3C", Offset = "0xB79C3C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC9600]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022951]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.image = 0;\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.tooltip = v47;\n\tv50 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v50;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = "";
			image = null;
			text = fsmString;
			FsmString fsmString2 = "";
			tooltip = fsmString2;
			FsmString fsmString3 = "";
			style = fsmString3;
		}

		[Token(Token = "0x6000ACC")]
		[Address(RVA = "0xB79CBC", Offset = "0xB79CBC", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EB8238]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022952]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv83 = System.String::IsNullOrEmpty(v50);\n\tv132 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv135 = HutongGames.PlayMaker.FsmTexture::get_Value(this.image);\n\tv144 = HutongGames.PlayMaker.FsmString::get_Value(this.tooltip);\n\tv148 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v148, v132, v135, v144);\n\tv117 = v83 == 0;\n\tif (v117) goto L_0056;\n\tv151 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Box(v148, v151);\n\treturn;\nL_0056:\n\tv153 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0067;\n\tv160 = *([v123 @ X8_v13+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0067;\n\tv168 = v123;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v168, v152, v56, v54, v52, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0067:\n\tv167 = UnityEngine.GUIStyle::op_Implicit(v153);\n\tv171 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Box(v148, v167, v171);\n\treturn;\n\tv71 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			string value2 = text.Value;
			Texture value3 = image.Value;
			string value4 = tooltip.Value;
			GUIContent content = new GUIContent(value2, value3, value4);
			if (flag)
			{
				GUILayoutOption[] array = base.LayoutOptions;
				GUILayout.Box(content, array);
				return;
			}
			string value5 = style.Value;
			GUIStyle gUIStyle = value5;
			GUILayoutOption[] array2 = base.LayoutOptions;
			GUILayout.Box(content, gUIStyle, array2);
		}

		[Token(Token = "0x6000ACD")]
		[Address(RVA = "0xB79E34", Offset = "0xB79E34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBox()
		{
		}
	}
}
