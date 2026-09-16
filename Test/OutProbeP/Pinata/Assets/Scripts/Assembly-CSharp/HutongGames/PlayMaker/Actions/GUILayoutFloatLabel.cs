using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757648", Offset = "0x757648")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757648", Offset = "0x757648")]
	[Token(Token = "0x2000227")]
	public class GUILayoutFloatLabel : GUILayoutAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2A2C", Offset = "0x7B2A2C")]
		[Token(Token = "0x400151C")]
		[FieldOffset(Offset = "0x60")]
		public FsmString prefix;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2A64", Offset = "0x7B2A64")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2A64", Offset = "0x7B2A64")]
		[Token(Token = "0x400151D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat floatVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2AC4", Offset = "0x7B2AC4")]
		[Token(Token = "0x400151E")]
		[FieldOffset(Offset = "0x70")]
		public FsmString style;

		[Token(Token = "0x6000AEB")]
		[Address(RVA = "0xB7A780", Offset = "0xB7A780", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA3AD0]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202295B]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.prefix = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.floatVariable = 0;\n\tthis.style = v47;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = "";
			prefix = fsmString;
			FsmString fsmString2 = "";
			floatVariable = null;
			style = fsmString2;
		}

		[Token(Token = "0x6000AEC")]
		[Address(RVA = "0xB7A7F0", Offset = "0xB7A7F0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE5AE0]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202295C]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv72 = System.String::IsNullOrEmpty(v44);\n\tv108 = HutongGames.PlayMaker.FsmString::get_Value(this.prefix);\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv119 = v72 == 0;\n\tif (v119) goto L_004A;\n\t// 49 Box v123 @ X0_v31 (System.Object), typeof(System.Single), &v51 @ V0_v2 (System.Single)\n\tv130 = System.String::Concat(v108, v123);\n\tv140 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v140, v130);\n\tv149 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v140, v149);\n\tgoto L_007D;\nL_004A:\n\t// 74 Box v126 @ X0_v15 (System.Object), typeof(System.Single), &v51 @ V0_v2 (System.Single)\n\tv134 = System.String::Concat(v108, v126);\n\tv144 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v144, v134);\n\tv154 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_006E;\n\tv171 = *([v158 @ X8_v15+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_006E;\n\tv179 = v158;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v179, v153, v49, v25, v26, v27, v28, v29, v51, v31, v32, v33, v34, v35, v36, v37);\nL_006E:\n\tv178 = UnityEngine.GUIStyle::op_Implicit(v154);\n\tv181 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v144, v178, v181);\nL_007D:\n\treturn;\n\tv59 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			string value2 = prefix.Value;
			float value3 = floatVariable.Value;
			if (flag)
			{
				object obj = value3;
				string text = value2 + obj;
				GUIContent content = new GUIContent(text);
				GUILayoutOption[] array = base.LayoutOptions;
				GUILayout.Label(content, array);
			}
			else
			{
				object obj2 = value3;
				string text2 = value2 + obj2;
				GUIContent content2 = new GUIContent(text2);
				string value4 = style.Value;
				GUIStyle gUIStyle = value4;
				GUILayoutOption[] array2 = base.LayoutOptions;
				GUILayout.Label(content2, gUIStyle, array2);
			}
		}

		[Token(Token = "0x6000AED")]
		[Address(RVA = "0xB7A9A8", Offset = "0xB7A9A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutFloatLabel()
		{
		}
	}
}
