using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757238", Offset = "0x757238")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757238", Offset = "0x757238")]
	[Token(Token = "0x200021A")]
	public class GUILayoutBeginScrollView : GUILayoutAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B23F8", Offset = "0x7B23F8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B23F8", Offset = "0x7B23F8")]
		[Token(Token = "0x40014F8")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 scrollPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2458", Offset = "0x7B2458")]
		[Token(Token = "0x40014F9")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool horizontalScrollbar;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2490", Offset = "0x7B2490")]
		[Token(Token = "0x40014FA")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool verticalScrollbar;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B24C8", Offset = "0x7B24C8")]
		[Token(Token = "0x40014FB")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool useCustomStyle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2500", Offset = "0x7B2500")]
		[Token(Token = "0x40014FC")]
		[FieldOffset(Offset = "0x80")]
		public FsmString horizontalStyle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2538", Offset = "0x7B2538")]
		[Token(Token = "0x40014FD")]
		[FieldOffset(Offset = "0x88")]
		public FsmString verticalStyle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B2570", Offset = "0x7B2570")]
		[Token(Token = "0x40014FE")]
		[FieldOffset(Offset = "0x90")]
		public FsmString backgroundStyle;

		[Token(Token = "0x6000AC5")]
		[Address(RVA = "0xB798B0", Offset = "0xB798B0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GUILayoutAction::Reset(this);\n\tthis.backgroundStyle = 0;\n\tthis.verticalScrollbar = 0;\n\tthis.horizontalStyle = 0;\n\tthis.scrollPosition = 0;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			backgroundStyle = null;
			verticalScrollbar = null;
			horizontalStyle = null;
			scrollPosition = null;
		}

		[Token(Token = "0x6000AC6")]
		[Address(RVA = "0xB798E0", Offset = "0xB798E0", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EC14D0]);\n\tv33 = *([v32 @ X8_v14]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202294E]) = v52;\nL_001E:\n\tv56 = HutongGames.PlayMaker.FsmBool::get_Value(this.useCustomStyle);\n\tv75 = this.scrollPosition;\n\tv102 = HutongGames.PlayMaker.FsmBool::get_Value(this.horizontalScrollbar);\n\tv164 = HutongGames.PlayMaker.FsmBool::get_Value(this.verticalScrollbar);\n\tv166 = v56 == 0;\n\tif (v166) goto L_006E;\n\tv170 = HutongGames.PlayMaker.FsmString::get_Value(this.horizontalStyle);\n\tgoto L_004A;\n\tv187 = *([v182 @ X8_v9+E0]);\n\tv188 = v187 == 0;\n\tv189 = ~v188;\n\tif (v189) goto L_004A;\n\tv208 = v182;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v208, v169, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_004A:\n\tv103 = UnityEngine.GUIStyle::op_Implicit(v170);\n\tv211 = HutongGames.PlayMaker.FsmString::get_Value(this.verticalStyle);\n\tv104 = UnityEngine.GUIStyle::op_Implicit(v211);\n\tv214 = HutongGames.PlayMaker.FsmString::get_Value(this.backgroundStyle);\n\tv216 = UnityEngine.GUIStyle::op_Implicit(v214);\n\tv218 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\t// 105 MakeStruct v194 @ AGGB79A28_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v75.value (UnityEngine.Vector2), v75.value.y (System.Single)\n\tv130 = UnityEngine.GUILayout::BeginScrollView(v194, v102, v164, v103, v104, v216, v218);\n\tv128 = v130.y;\n\tgoto L_0078;\nL_006E:\n\tv168 = HutongGames.PlayMaker.Actions.GUILayoutAction::get_LayoutOptions(this);\n\t// 117 MakeStruct v177 @ AGGB79A50_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v75.value (UnityEngine.Vector2), v75.value.y (System.Single)\n\tv130 = UnityEngine.GUILayout::BeginScrollView(v177, v102, v164, v168);\n\tv128 = v130.y;\nL_0078:\n\tv75.value = v130;\n\tv75.value.y = v128;\n\treturn;\n\tv80 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			bool value = useCustomStyle.Value;
			FsmVector2 fsmVector = scrollPosition;
			bool value2 = horizontalScrollbar.Value;
			bool value3 = verticalScrollbar.Value;
			Vector2 value7;
			float y;
			if (value)
			{
				string value4 = horizontalStyle.Value;
				GUIStyle gUIStyle = value4;
				string value5 = verticalStyle.Value;
				GUIStyle gUIStyle2 = value5;
				string value6 = backgroundStyle.Value;
				GUIStyle background = value6;
				GUILayoutOption[] array = base.LayoutOptions;
				Vector2 vector = default(Vector2);
				vector.x = fsmVector.value.x;
				vector.y = fsmVector.value.y;
				value7 = GUILayout.BeginScrollView(vector, value2, value3, gUIStyle, gUIStyle2, background, array);
				y = value7.y;
			}
			else
			{
				GUILayoutOption[] array2 = base.LayoutOptions;
				Vector2 vector2 = default(Vector2);
				vector2.x = fsmVector.value.x;
				vector2.y = fsmVector.value.y;
				value7 = GUILayout.BeginScrollView(vector2, value2, value3, array2);
				y = value7.y;
			}
			fsmVector.value = value7;
			fsmVector.value.y = y;
		}

		[Token(Token = "0x6000AC7")]
		[Address(RVA = "0xB79A80", Offset = "0xB79A80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBeginScrollView()
		{
		}
	}
}
