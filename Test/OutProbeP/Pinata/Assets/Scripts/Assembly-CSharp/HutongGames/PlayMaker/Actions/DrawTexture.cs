using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75686C", Offset = "0x75686C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75686C", Offset = "0x75686C")]
	[Token(Token = "0x20001FC")]
	public class DrawTexture : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1954", Offset = "0x7B1954")]
		[Token(Token = "0x400148D")]
		[FieldOffset(Offset = "0x50")]
		public FsmTexture texture;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B19A0", Offset = "0x7B19A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B19A0", Offset = "0x7B19A0")]
		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x7B19A0", Offset = "0x7B19A0")]
		[Token(Token = "0x400148E")]
		[FieldOffset(Offset = "0x58")]
		public FsmRect screenRect;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1A14", Offset = "0x7B1A14")]
		[Token(Token = "0x400148F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat left;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1A4C", Offset = "0x7B1A4C")]
		[Token(Token = "0x4001490")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat top;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1A84", Offset = "0x7B1A84")]
		[Token(Token = "0x4001491")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat width;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1ABC", Offset = "0x7B1ABC")]
		[Token(Token = "0x4001492")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat height;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1AF4", Offset = "0x7B1AF4")]
		[Token(Token = "0x4001493")]
		[FieldOffset(Offset = "0x80")]
		public ScaleMode scaleMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1B2C", Offset = "0x7B1B2C")]
		[Token(Token = "0x4001494")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool alphaBlend;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1B64", Offset = "0x7B1B64")]
		[Token(Token = "0x4001495")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat imageAspect;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1B9C", Offset = "0x7B1B9C")]
		[Token(Token = "0x4001496")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool normalized;

		[Token(Token = "0x4001497")]
		[FieldOffset(Offset = "0xA0")]
		private Rect rect;

		[Token(Token = "0x6000A62")]
		[Address(RVA = "0xB70D44", Offset = "0xB70D44", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.texture = 0;\n\tthis.screenRect = 0;\n\tv14 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.left = v14;\n\tv17 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.top = v17;\n\tv21 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.width = v21;\n\tv24 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.height = v24;\n\tthis.scaleMode = 0;\n\tv27 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.alphaBlend = v27;\n\tv30 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.imageAspect = v30;\n\tv33 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalized = v33;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			texture = null;
			screenRect = null;
			FsmFloat fsmFloat = 0f;
			left = fsmFloat;
			FsmFloat fsmFloat2 = 0f;
			top = fsmFloat2;
			FsmFloat fsmFloat3 = 1f;
			width = fsmFloat3;
			FsmFloat fsmFloat4 = 1f;
			height = fsmFloat4;
			scaleMode = default(ScaleMode);
			FsmBool fsmBool = true;
			alphaBlend = fsmBool;
			FsmFloat fsmFloat5 = 0f;
			imageAspect = fsmFloat5;
			FsmBool fsmBool2 = true;
			normalized = fsmBool2;
		}

		[Token(Token = "0x6000A63")]
		[Address(RVA = "0xB70DE4", Offset = "0xB70DE4", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EA5528]);\n\tv31 = *([v30 @ X8_v19]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20228FD]) = v50;\nL_001D:\n\tv54 = HutongGames.PlayMaker.FsmTexture::get_Value(this.texture);\n\tgoto L_002F;\n\tv168 = *([v112 @ X8_v7+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_002F;\n\tv176 = v112;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v176, v53, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002F:\n\tv175 = UnityEngine.Object::op_Equality(v54, 0);\n\tv178 = v175 == 0;\n\tif (v178) goto L_0043;\n\treturn;\nL_0043:\n\tv151 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenRect);\n\tv236 = v151 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0054;\n\tv161 = this.screenRect;\n\tv62 = v161.value;\n\tv60 = v161.value.m_YMin;\n\tv58 = v161.value.m_Width;\n\tv56 = v161.value.m_Height;\nL_0054:\n\tthis.rect = v62;\n\tthis.rect.m_YMin = v60;\n\tthis.rect.m_Width = v58;\n\tthis.rect.m_Height = v56;\n\tv243 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.left);\n\tv245 = v243 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_006D;\n\tv252 = this + 0xA0;\n\tv66 = HutongGames.PlayMaker.FsmFloat::get_Value(this.left);\n\tv250 = 0x10CCFBC(v252, 0, 0, v35, v36, v37, v38, v39, v66, v60, v58, v56, v44, v45, v46, v47);\nL_006D:\n\tv254 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.top);\n\tv257 = v254 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_007F;\n\tv264 = this + 0xA0;\n\tv66 = HutongGames.PlayMaker.FsmFloat::get_Value(this.top);\n\tv262 = 0x10CCFCC(v264, 0, 0, v35, v36, v37, v38, v39, v66, v60, v58, v56, v44, v45, v46, v47);\nL_007F:\n\tv266 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.width);\n\tv269 = v266 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_0091;\n\tv276 = this + 0xA0;\n\tv66 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv274 = 0x10CD180(v276, 0, 0, v35, v36, v37, v38, v39, v66, v60, v58, v56, v44, v45, v46, v47);\nL_0091:\n\tv278 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv281 = v278 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00A3;\n\tv288 = this + 0xA0;\n\tv66 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv286 = 0x10CD190(v288, 0, 0, v35, v36, v37, v38, v39, v66, v60, v58, v56, v44, v45, v46, v47);\nL_00A3:\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv294 = v291 == 0;\n\tif (v294) goto L_00DC;\n\tv295 = this + 0xA0;\n\tv298 = 0x10CCFB4(v295, 0, 0, v35, v36, v37, v38, v39, v66, v60, v58, v56, v44, v45, v46, v47);\n\tv306 = UnityEngine.Screen::get_width();\n\tv308 = v66 * v306;\n\tv311 = 0x10CCFBC(v295, 0, 0, v35, v36, v37, v38, v39, v308, v60, v58, v56, v44, v45, v46, v47);\n\tv314 = 0x10CD178(v295, 0, 0, v35, v36, v37, v38, v39, v308, v60, v58, v56, v44, v45, v46, v47);\n\tv318 = UnityEngine.Screen::get_width();\n\tv320 = v308 * v318;\n\tv323 = 0x10CD180(v295, 0, 0, v35, v36, v37, v38, v39, v320, v60, v58, v56, v44, v45, v46, v47);\n\tv329 = 0x10CCFC4(v295, 0, 0, v35, v36, v37, v38, v39, v320, v60, v58, v56, v44, v45, v46, v47);\n\tv339 = UnityEngine.Screen::get_height();\n\tv346 = v320 * v339;\n\tv349 = 0x10CCFCC(v295, 0, 0, v35, v36, v37, v38, v39, v346, v60, v58, v56, v44, v45, v46, v47);\n\tv352 = 0x10CD188(v295, 0, 0, v35, v36, v37, v38, v39, v346, v60, v58, v56, v44, v45, v46, v47);\n\tv354 = UnityEngine.Screen::get_height();\n\tv299 = v346 * v354;\n\tv303 = 0x10CD190(v295, 0, 0, v35, v36, v37, v38, v39, v299, v60, v58, v56, v44, v45, v46, v47);\nL_00DC:\n\tv152 = HutongGames.PlayMaker.FsmTexture::get_Value(this.texture);\n\tv153 = HutongGames.PlayMaker.FsmBool::get_Value(this.alphaBlend);\n\tv326 = HutongGames.PlayMaker.FsmFloat::get_Value(this.imageAspect);\n\tgoto L_010D;\n\tv340 = *([v333 @ X0_v34+E0]);\n\tv341 = v340 == 0;\n\tv342 = ~v341;\n\tif (v342) goto L_010D;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v333, v325, v71, v35, v36, v37, v38, v39, v326, v60, v58, v56, v44, v45, v46, v47);\nL_010D:\n\t// 269 MakeStruct v181 @ AGGB71110_0_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.rect (UnityEngine.Rect), this.rect.m_YMin (System.Single), this.rect.m_Width (System.Single), this.rect.m_Height (System.Single)\n\tUnityEngine.GUI::DrawTexture(v181, v152, this.scaleMode, v153, v326);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 182 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_0148: Expected O, but got I
			//IL_01ae: Expected O, but got I
			//IL_0214: Expected O, but got I
			//IL_027a: Expected O, but got I
			//IL_02d5: Expected O, but got I
			Texture value = texture.Value;
			if (!(value == null))
			{
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
					object obj = (long)(IntPtr)this + 160L;
					num3 = left.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
				}
				if (!top.IsNone)
				{
					object obj2 = (long)(IntPtr)this + 160L;
					num3 = top.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
				}
				if (!width.IsNone)
				{
					object obj3 = (long)(IntPtr)this + 160L;
					num3 = width.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				}
				if (!height.IsNone)
				{
					object obj4 = (long)(IntPtr)this + 160L;
					num3 = height.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
				}
				if (normalized.Value)
				{
					object obj5 = (long)(IntPtr)this + 160L;
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
				Texture value2 = texture.Value;
				bool value3 = alphaBlend.Value;
				float value4 = imageAspect.Value;
				Rect position = default(Rect);
				position.x = this.rect.x;
				position.y = this.rect.y;
				position.width = this.rect.width;
				position.height = this.rect.height;
				GUI.DrawTexture(position, value2, scaleMode, value3, value4);
			}
		}

		[Token(Token = "0x6000A64")]
		[Address(RVA = "0xB71120", Offset = "0xB71120", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawTexture()
		{
		}
	}
}
