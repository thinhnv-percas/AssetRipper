using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75690C", Offset = "0x75690C")]
	[Token(Token = "0x20001FE")]
	public abstract class GUIAction : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1C0C", Offset = "0x7B1C0C")]
		[Token(Token = "0x4001499")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect screenRect;

		[Token(Token = "0x400149A")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat left;

		[Token(Token = "0x400149B")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat top;

		[Token(Token = "0x400149C")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat width;

		[Token(Token = "0x400149D")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat height;

		[RequiredField]
		[Token(Token = "0x400149E")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool normalized;

		[Token(Token = "0x400149F")]
		[FieldOffset(Offset = "0x80")]
		internal Rect rect;

		[Token(Token = "0x6000A68")]
		[Address(RVA = "0xB77C88", Offset = "0xB77C88", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.screenRect = 0;\n\tv14 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.left = v14;\n\tv17 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.top = v17;\n\tv21 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.width = v21;\n\tv24 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.height = v24;\n\tv27 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalized = v27;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		}

		[Token(Token = "0x6000A69")]
		[Address(RVA = "0xB77D04", Offset = "0xB77D04", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenRect);\n\tv88 = v17 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_001D;\n\tv92 = this.screenRect;\n\tv37 = v92.value;\n\tv34 = v92.value.m_YMin;\n\tv31 = v92.value.m_Width;\n\tv28 = v92.value.m_Height;\nL_001D:\n\tthis.rect = v37;\n\tthis.rect.m_YMin = v34;\n\tthis.rect.m_Width = v31;\n\tthis.rect.m_Height = v28;\n\tv108 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.left);\n\tv139 = v108 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0036;\n\tv141 = this + 0x80;\n\tv41 = HutongGames.PlayMaker.FsmFloat::get_Value(this.left);\n\tv146 = 0x10CCFBC(v141, 0, v73, v74, v75, v76, v77, v78, v41, v34, v31, v28, v79, v80, v81, v82);\nL_0036:\n\tv148 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.top);\n\tv151 = v148 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0048;\n\tv153 = this + 0x80;\n\tv41 = HutongGames.PlayMaker.FsmFloat::get_Value(this.top);\n\tv158 = 0x10CCFCC(v153, 0, v73, v74, v75, v76, v77, v78, v41, v34, v31, v28, v79, v80, v81, v82);\nL_0048:\n\tv160 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.width);\n\tv163 = v160 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_005A;\n\tv165 = this + 0x80;\n\tv41 = HutongGames.PlayMaker.FsmFloat::get_Value(this.width);\n\tv170 = 0x10CD180(v165, 0, v73, v74, v75, v76, v77, v78, v41, v34, v31, v28, v79, v80, v81, v82);\nL_005A:\n\tv172 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.height);\n\tv175 = v172 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_006C;\n\tv177 = this + 0x80;\n\tv41 = HutongGames.PlayMaker.FsmFloat::get_Value(this.height);\n\tv182 = 0x10CD190(v177, 0, v73, v74, v75, v76, v77, v78, v41, v34, v31, v28, v79, v80, v81, v82);\nL_006C:\n\tv131 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv128 = v131 == 0;\n\tif (v128) goto L_00AA;\n\tv186 = this + 0x80;\n\tv189 = 0x10CCFB4(v186, 0, v73, v74, v75, v76, v77, v78, v41, v34, v31, v28, v79, v80, v81, v82);\n\tv192 = UnityEngine.Screen::get_width();\n\tv194 = v41 * v192;\n\tv197 = 0x10CCFBC(v186, 0, v73, v74, v75, v76, v77, v78, v194, v34, v31, v28, v79, v80, v81, v82);\n\tv200 = 0x10CD178(v186, 0, v73, v74, v75, v76, v77, v78, v194, v34, v31, v28, v79, v80, v81, v82);\n\tv203 = UnityEngine.Screen::get_width();\n\tv205 = v194 * v203;\n\tv208 = 0x10CD180(v186, 0, v73, v74, v75, v76, v77, v78, v205, v34, v31, v28, v79, v80, v81, v82);\n\tv211 = 0x10CCFC4(v186, 0, v73, v74, v75, v76, v77, v78, v205, v34, v31, v28, v79, v80, v81, v82);\n\tv214 = UnityEngine.Screen::get_height();\n\tv216 = v205 * v214;\n\tv219 = 0x10CCFCC(v186, 0, v73, v74, v75, v76, v77, v78, v216, v34, v31, v28, v79, v80, v81, v82);\n\tv222 = 0x10CD188(v186, 0, v73, v74, v75, v76, v77, v78, v216, v34, v31, v28, v79, v80, v81, v82);\n\tv225 = UnityEngine.Screen::get_height();\n\tv123 = v216 * v225;\n\tv130 = 0x10CD190(v186, 0, v73, v74, v75, v76, v77, v78, v123, v34, v31, v28, v79, v80, v81, v82);\n\treturn;\nL_00AA:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_0103: Expected O, but got I
			//IL_0169: Expected O, but got I
			//IL_01cf: Expected O, but got I
			//IL_0235: Expected O, but got I
			//IL_0290: Expected O, but got I
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
				object obj = (long)(IntPtr)this + 128L;
				num3 = left.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			}
			if (!top.IsNone)
			{
				object obj2 = (long)(IntPtr)this + 128L;
				num3 = top.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			}
			if (!width.IsNone)
			{
				object obj3 = (long)(IntPtr)this + 128L;
				num3 = width.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
			}
			if (!height.IsNone)
			{
				object obj4 = (long)(IntPtr)this + 128L;
				num3 = height.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
			}
			if (normalized.Value)
			{
				object obj5 = (long)(IntPtr)this + 128L;
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
		}

		[Token(Token = "0x6000A6A")]
		[Address(RVA = "0xB77F14", Offset = "0xB77F14", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal GUIAction()
		{
		}
	}
}
