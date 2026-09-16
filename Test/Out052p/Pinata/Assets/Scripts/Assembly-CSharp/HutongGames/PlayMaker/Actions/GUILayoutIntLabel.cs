using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757738", Offset = "0x757738")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757738", Offset = "0x757738")]
	[Token(Token = "0x200022A")]
	public class GUILayoutIntLabel : GUILayoutAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2C18", Offset = "0x7B2C18")]
		[Token(Token = "0x4001526")]
		[FieldOffset(Offset = "0x60")]
		public FsmString prefix;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B2C50", Offset = "0x7B2C50")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2C50", Offset = "0x7B2C50")]
		[Token(Token = "0x4001527")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt intVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2CB0", Offset = "0x7B2CB0")]
		[Token(Token = "0x4001528")]
		[FieldOffset(Offset = "0x70")]
		public FsmString style;

		[Token(Token = "0x6000AF4")]
		[Address(RVA = "0xB7ADB0", Offset = "0xB7ADB0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE24B8]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022960]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.prefix = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.intVariable = 0;\n\tthis.style = v47;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = "";
			prefix = fsmString;
			FsmString fsmString2 = "";
			intVariable = null;
			style = fsmString2;
		}

		[Token(Token = "0x6000AF5")]
		[Address(RVA = "0xB7AE20", Offset = "0xB7AE20", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EAF5C8]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022961]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv70 = System.String::IsNullOrEmpty(v44);\n\tv105 = HutongGames.PlayMaker.FsmString::get_Value(this.prefix);\n\tv113 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv117 = v70 == 0;\n\tif (v117) goto L_004C;\n\t// 50 Box v122 @ X0_v32 (System.Object), typeof(System.Int32), &v113 @ X0_v13 (System.Int32)\n\tv130 = System.String::Concat(v105, v122);\n\tv140 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v140, v130);\n\tv149 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v140, v149);\n\tgoto L_007F;\nL_004C:\n\t// 76 Box v126 @ X0_v16 (System.Object), typeof(System.Int32), &v113 @ X0_v13 (System.Int32)\n\tv134 = System.String::Concat(v105, v126);\n\tv144 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v144, v134);\n\tv154 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0070;\n\tv171 = *([v158 @ X8_v16+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0070;\n\tv179 = v158;\n\tv175 = \"il2cpp_codegen_runtime_class_init\"(v179, v153, v49, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0070:\n\tv178 = UnityEngine.GUIStyle::op_Implicit(v154);\n\tv181 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v144, v178, v181);\nL_007F:\n\treturn;\n\tv57 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			string value2 = prefix.Value;
			int value3 = intVariable.Value;
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

		[Token(Token = "0x6000AF6")]
		[Address(RVA = "0xB7AFE0", Offset = "0xB7AFE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutIntLabel()
		{
		}
	}
}
