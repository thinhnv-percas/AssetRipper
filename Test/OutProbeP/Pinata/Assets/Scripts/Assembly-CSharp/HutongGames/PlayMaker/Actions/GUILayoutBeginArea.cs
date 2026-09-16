using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7570F8", Offset = "0x7570F8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7570F8", Offset = "0x7570F8")]
	[Token(Token = "0x2000216")]
	public class GUILayoutBeginArea : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B22E8", Offset = "0x7B22E8")]
		[Token(Token = "0x40014E5")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect screenRect;

		[Token(Token = "0x40014E6")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat left;

		[Token(Token = "0x40014E7")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat top;

		[Token(Token = "0x40014E8")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat width;

		[Token(Token = "0x40014E9")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat height;

		[Token(Token = "0x40014EA")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool normalized;

		[Token(Token = "0x40014EB")]
		[FieldOffset(Offset = "0x80")]
		public FsmString style;

		[Token(Token = "0x40014EC")]
		[FieldOffset(Offset = "0x88")]
		private Rect rect;

		[Token(Token = "0x6000AB8")]
		[Address(RVA = "0xB78D10", Offset = "0xB78D10", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EB6A40]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022947]) = v40;\nL_0016:\n\tthis.screenRect = 0;\n\tv43 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.left = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.top = v46;\n\tv50 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.width = v50;\n\tv53 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.height = v53;\n\tv56 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalized = v56;\n\tv61 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.style = v61;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			screenRect = null;
			FsmFloat fsmFloat = 0f;
			left = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			top = fsmFloat2;
			FsmFloat fsmFloat3 = 1f;
			width = fsmFloat3;
			FsmFloat fsmFloat4 = 1f;
			height = fsmFloat4;
			FsmBool fsmBool = true;
			normalized = fsmBool;
			FsmString fsmString = "";
			style = fsmString;
		}

		[Token(Token = "0x6000AB9")]
		[Address(RVA = "0xB78DC8", Offset = "0xB78DC8", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F03AC0]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022948]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenRect);\n\tv105 = v50 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_002C;\n\tv128 = this.screenRect;\n\tv58 = v128.value;\n\tv56 = v128.value.m_YMin;\n\tv54 = v128.value.m_Width;\n\tv52 = v128.value.m_Height;\nL_002C:\n\tthis.rect = v58;\n\tthis.rect.m_YMin = v56;\n\tthis.rect.m_Width = v54;\n\tthis.rect.m_Height = v52;\n\tv139 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.left);\n\tv181 = v139 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0045;\n\tv188 = this + 0x88;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.left);\n\tv186 = 0x10CCFBC(v188, 0, v30, v31, v32, v33, v34, v35, v62, v56, v54, v52, v40, v41, v42, v43);\nL_0045:\n\tv190 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.top);\n\tv193 = v190 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0057;\n\tv200 = this + 0x88;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.top);\n\tv198 = 0x10CCFCC(v200, 0, v30, v31, v32, v33, v34, v35, v62, v56, v54, v52, v40, v41, v42, v43);\nL_0057:\n\tv202 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.width);\n\tv205 = v202 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0069;\n\tv212 = this + 0x88;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv210 = 0x10CD180(v212, 0, v30, v31, v32, v33, v34, v35, v62, v56, v54, v52, v40, v41, v42, v43);\nL_0069:\n\tv214 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv217 = v214 == 0;\n\tv218 = ~v217;\n\tif (v218) goto L_007B;\n\tv224 = this + 0x88;\n\tv62 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv222 = 0x10CD190(v224, 0, v30, v31, v32, v33, v34, v35, v62, v56, v54, v52, v40, v41, v42, v43);\nL_007B:\n\tv227 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv230 = v227 == 0;\n\tif (v230) goto L_00B6;\n\tv231 = this + 0x88;\n\tv234 = 0x10CCFB4(v231, 0, v30, v31, v32, v33, v34, v35, v62, v56, v54, v52, v40, v41, v42, v43);\n\tv249 = UnityEngine.Screen::get_width();\n\tv257 = v62 * v249;\n\tv260 = 0x10CCFBC(v231, 0, v30, v31, v32, v33, v34, v35, v257, v56, v54, v52, v40, v41, v42, v43);\n\tv269 = 0x10CD178(v231, 0, v30, v31, v32, v33, v34, v35, v257, v56, v54, v52, v40, v41, v42, v43);\n\tv278 = UnityEngine.Screen::get_width();\n\tv288 = v257 * v278;\n\tv291 = 0x10CD180(v231, 0, v30, v31, v32, v33, v34, v35, v288, v56, v54, v52, v40, v41, v42, v43);\n\tv295 = 0x10CCFC4(v231, 0, v30, v31, v32, v33, v34, v35, v288, v56, v54, v52, v40, v41, v42, v43);\n\tv298 = UnityEngine.Screen::get_height();\n\tv300 = v288 * v298;\n\tv303 = 0x10CCFCC(v231, 0, v30, v31, v32, v33, v34, v35, v300, v56, v54, v52, v40, v41, v42, v43);\n\tv306 = 0x10CD188(v231, 0, v30, v31, v32, v33, v34, v35, v300, v56, v54, v52, v40, v41, v42, v43);\n\tv308 = UnityEngine.Screen::get_height();\n\tv237 = v300 * v308;\n\tv240 = 0x10CD190(v231, 0, v30, v31, v32, v33, v34, v35, v237, v56, v54, v52, v40, v41, v42, v43);\nL_00B6:\n\tgoto L_00C4;\n\tv250 = *([v243 @ X0_v24 (Il2CppClass<UnityEngine.GUIContent>)+E0]);\n\tv251 = v250 == 0;\n\tv252 = ~v251;\n\t// 186 ConditionalJump @b63, v252 @ TEMP_v44\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v243, v121, v30, v31, v32, v33, v34, v35, v119, v56, v54, v52, v40, v41, v42, v43);\n\tv253 = UnityEngine.GUIContent;\nL_00C4:\n\tv266 = HutongGames.PlayMaker.FsmString::get_Value(this.style);\n\tgoto L_00D5;\n\tv279 = *([v175 @ X8_v11+E0]);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\n\tif (v281) goto L_00D5;\n\tv292 = v175;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v292, v264, v30, v31, v32, v33, v34, v35, v119, v56, v54, v52, v40, v41, v42, v43);\nL_00D5:\n\tv286 = UnityEngine.GUIStyle::op_Implicit(v266);\n\t// 230 MakeStruct v141 @ AGGB79080_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tUnityEngine.GUILayout::BeginArea(v141, v262.none, v286);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_0108: Expected O, but got I
			//IL_016e: Expected O, but got I
			//IL_01d4: Expected O, but got I
			//IL_023a: Expected O, but got I
			//IL_0295: Expected O, but got I
			bool isNone = screenRect.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = 0f;
			float num2 = 0f;
			float y = 0f;
			Rect rect = default(Rect);
			if (!flag2)
			{
				FsmRect fsmRect = screenRect;
				rect = fsmRect.value;
				y = fsmRect.value.y;
				num2 = fsmRect.value.width;
				num = fsmRect.value.height;
			}
			this.rect = rect;
			this.rect.y = y;
			this.rect.width = num2;
			this.rect.height = num;
			bool isNone2 = left.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float num3 = rect.x;
			if (!flag4)
			{
				object obj = (long)(IntPtr)this + 136L;
				num3 = left.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			}
			if (!top.IsNone)
			{
				object obj2 = (long)(IntPtr)this + 136L;
				num3 = top.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			}
			if (!width.IsNone)
			{
				object obj3 = (long)(IntPtr)this + 136L;
				num3 = width.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			}
			if (!height.IsNone)
			{
				object obj4 = (long)(IntPtr)this + 136L;
				num3 = height.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			}
			if (normalized.Value)
			{
				object obj5 = (long)(IntPtr)this + 136L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				int num4 = Screen.width;
				float num5 = num3 * (float)num4;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				int num6 = Screen.width;
				float num7 = num5 * (float)num6;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				int num8 = Screen.height;
				float num9 = num7 * (float)num8;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				int num10 = Screen.height;
				float num11 = num9 * (float)num10;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			}
			string value = style.Value;
			GUIStyle gUIStyle = value;
			Rect rect2 = default(Rect);
			rect2.x = this.rect.x;
			rect2.y = this.rect.y;
			rect2.width = this.rect.width;
			rect2.height = this.rect.height;
			GUILayout.BeginArea(rect2, GUIContent.none, gUIStyle);
		}

		[Token(Token = "0x6000ABA")]
		[Address(RVA = "0xB79090", Offset = "0xB79090", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBeginArea()
		{
		}
	}
}
