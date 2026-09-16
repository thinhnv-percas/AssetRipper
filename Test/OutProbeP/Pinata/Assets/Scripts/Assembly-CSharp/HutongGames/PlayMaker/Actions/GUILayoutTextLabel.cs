using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757918", Offset = "0x757918")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757918", Offset = "0x757918")]
	[Token(Token = "0x2000230")]
	public class GUILayoutTextLabel : GUILayoutAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2E40", Offset = "0x7B2E40")]
		[Token(Token = "0x400153D")]
		[FieldOffset(Offset = "0x60")]
		public FsmString text;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2E78", Offset = "0x7B2E78")]
		[Token(Token = "0x400153E")]
		[FieldOffset(Offset = "0x68")]
		public FsmString style;

		[Token(Token = "0x6000B06")]
		[Address(RVA = "0xB7B8B0", Offset = "0xB7B8B0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE2518]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202296A]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tv44 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.text = v44;\n\tv47 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v47;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmString fsmString = "";
			text = fsmString;
			FsmString fsmString2 = "";
			style = fsmString2;
		}

		[Token(Token = "0x6000B07")]
		[Address(RVA = "0xB7B920", Offset = "0xB7B920", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1F075A0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202296B]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tv65 = System.String::IsNullOrEmpty(v46);\n\tv80 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tv121 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v121, v80);\n\tv105 = v65 == 0;\n\tif (v105) goto L_0042;\n\tv124 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v121, v124);\n\treturn;\nL_0042:\n\tv126 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_0053;\n\tv133 = *([v111 @ X8_v11+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0053;\n\tv141 = v111;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v141, v125, v48, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0053:\n\tv140 = UnityEngine.GUIStyle::op_Implicit(v126);\n\tv144 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\tUnityEngine.GUILayout::Label(v121, v140, v144);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			string value = style.Value;
			bool flag = string.IsNullOrEmpty(value);
			string value2 = text.Value;
			GUIContent content = new GUIContent(value2);
			if (flag)
			{
				GUILayoutOption[] array = base.LayoutOptions;
				GUILayout.Label(content, array);
				return;
			}
			string value3 = style.Value;
			GUIStyle gUIStyle = value3;
			GUILayoutOption[] array2 = base.LayoutOptions;
			GUILayout.Label(content, gUIStyle, array2);
		}

		[Token(Token = "0x6000B08")]
		[Address(RVA = "0xB7BA54", Offset = "0xB7BA54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutTextLabel()
		{
		}
	}
}
