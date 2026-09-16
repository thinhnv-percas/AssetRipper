using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BBD0", Offset = "0x75BBD0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75BBD0", Offset = "0x75BBD0")]
	[Token(Token = "0x20002FD")]
	public class RectOverlaps : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2260", Offset = "0x7C2260")]
		[Token(Token = "0x400192F")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect rect1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C22AC", Offset = "0x7C22AC")]
		[Token(Token = "0x4001930")]
		[FieldOffset(Offset = "0x58")]
		public FsmRect rect2;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C22F8", Offset = "0x7C22F8")]
		[Token(Token = "0x4001931")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2330", Offset = "0x7C2330")]
		[Token(Token = "0x4001932")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C2368", Offset = "0x7C2368")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2368", Offset = "0x7C2368")]
		[Token(Token = "0x4001933")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C23B8", Offset = "0x7C23B8")]
		[Token(Token = "0x4001934")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000F02")]
		[Address(RVA = "0xB1EAFC", Offset = "0xB1EAFC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0C230]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022590]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.rect1 = v46;\n\tv52 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.falseEvent = 0;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\tthis.rect2 = v52;\n\tthis.trueEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmRect fsmRect = new FsmRect();
			fsmRect.useVariable = true;
			rect1 = fsmRect;
			FsmRect fsmRect2 = new FsmRect();
			fsmRect2.useVariable = true;
			falseEvent = null;
			storeResult = null;
			everyFrame = false;
			rect2 = fsmRect2;
			trueEvent = null;
		}

		[Token(Token = "0x6000F03")]
		[Address(RVA = "0xB1EBA0", Offset = "0xB1EBA0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectOverlaps::DoRectOverlap(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRectOverlap();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000F04")]
		[Address(RVA = "0xB1EC90", Offset = "0xB1EC90", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectOverlaps::DoRectOverlap(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoRectOverlap();
		}

		[Token(Token = "0x6000F05")]
		[Address(RVA = "0xB1EBDC", Offset = "0xB1EBDC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rect1);\n\tv36 = v13 == 0;\n\tv37 = ~v36;\n\tif (v37) goto L_001B;\n\tv77 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rect2);\n\tv83 = v77 == 0;\n\tif (v83) goto L_001C;\nL_001B:\n\treturn;\nL_001C:\n\tv66 = this.rect1;\n\tv62 = this.rect2;\n\t// 42 MakeStruct v43 @ AGGB1EC40_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v66.value (UnityEngine.Rect), v66.value.m_YMin (System.Single), v66.value.m_Width (System.Single), v66.value.m_Height (System.Single)\n\t// 43 MakeStruct v40 @ AGGB1EC40_1_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), v62.value (UnityEngine.Rect), v62.value.m_YMin (System.Single), v62.value.m_Width (System.Single), v62.value.m_Height (System.Single)\n\tv78 = HutongGames.PlayMaker.Actions.RectOverlaps::Intersect(v43, v40);\n\tv67 = this.storeResult;\n\tv67.value = v78;\n\tv122 = this + 0x60;\n\tv110 = this + 0x68;\n\tv104 = v78 == 0;\n\tv95 = ~v104;\n\tv92 = ~v95;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_004A;\nL_004A:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v122 @ X9_v5]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRectOverlap()
		{
			//IL_0178: Expected O, but got I
			//IL_0184: Expected O, but got I
			if (!rect1.IsNone && !rect2.IsNone)
			{
				FsmRect fsmRect = rect1;
				FsmRect fsmRect2 = rect2;
				Rect a = default(Rect);
				a.x = fsmRect.value.x;
				a.y = fsmRect.value.y;
				a.width = fsmRect.value.width;
				a.height = fsmRect.value.height;
				Rect b = default(Rect);
				b.x = fsmRect2.value.x;
				b.y = fsmRect2.value.y;
				b.width = fsmRect2.value.width;
				b.height = fsmRect2.value.height;
				bool flag = Intersect(a, b);
				FsmBool fsmBool = storeResult;
				fsmBool.value = flag;
				object fsmEvent = (long)(IntPtr)this + 96L;
				object obj = (long)(IntPtr)this + 104L;
				if (!flag)
				{
					fsmEvent = obj;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000F06")]
		[Address(RVA = "0xB1EC94", Offset = "0xB1EC94", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectOverlaps::FlipNegative(&a @ V0 (UnityEngine.Rect));\n\tHutongGames.PlayMaker.Actions.RectOverlaps::FlipNegative(&b @ V4 (UnityEngine.Rect));\n\tv37 = 0x10CD07C(&a @ V0 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv47 = 0x10CD124(&b @ V4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv51 = 0x10CD124(&a @ V0 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv55 = 0x10CD07C(&b @ V4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv58 = a - a;\n\tv59 = v58 < 0;\n\tv60 = v58 == 0;\n\tv61 = a ^ a;\n\tv62 = a ^ v58;\n\tv63 = v61 & v62;\n\tv64 = v63 < 0;\n\tv67 = v59 == v64;\n\tv68 = ~v60;\n\tv69 = v67 & v68;\n\tv71 = 0x10CD084(&a @ V0 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv75 = 0x10CD134(&b @ V4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv78 = a - a;\n\tv79 = v78 < 0;\n\tv88 = 0x10CD134(&a @ V0 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv92 = 0x10CD084(&b @ V4 (UnityEngine.Rect), 0, v38, v39, v40, v41, v42, v43, a, a.m_YMin, a.m_Width, a.m_Height, b, b.m_YMin, b.m_Width, b.m_Height);\n\tv95 = a - a;\n\tv96 = v95 < 0;\n\tv97 = v95 == 0;\n\tv98 = a ^ a;\n\tv99 = a ^ v95;\n\tv100 = v98 & v99;\n\tv101 = v100 < 0;\n\tv102 = v96 == v101;\n\tv103 = ~v97;\n\tv104 = v102 & v103;\n\tv108 = a - a;\n\tv109 = v108 < 0;\n\tv116 = v109 & v69;\n\tv117 = v116 & v79;\n\treturnVal1 = v117 & v104;\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Intersect(Rect a, Rect b)
		{
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			Rect r = default(Rect);
			FlipNegative(ref r);
			Rect r2 = default(Rect);
			FlipNegative(ref r2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			float num = r.x - r.x;
			bool flag = num < 0f;
			bool flag2 = num == 0f;
			object obj = (object)a ^ (object)a;
			object obj2 = a ^ num;
			int num2 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
			float num3 = r.x - r.x;
			bool flag7 = num3 < 0f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
			float num4 = r.x - r.x;
			bool flag8 = num4 < 0f;
			bool flag9 = num4 == 0f;
			object obj3 = (object)a ^ (object)a;
			object obj4 = a ^ num4;
			int num5 = (int)((long)(IntPtr)obj3 & (long)(IntPtr)obj4);
			bool flag10 = num5 < 0;
			bool flag11 = flag8 == flag10;
			bool flag12 = !flag9;
			bool flag13 = flag11 && flag12;
			float num6 = r.x - r.x;
			bool flag14 = num6 < 0f;
			bool flag15 = flag14 && flag6;
			bool flag16 = flag15 && flag7;
			return flag16 && flag13;
		}

		[Token(Token = "0x6000F07")]
		[Address(RVA = "0xB1ED84", Offset = "0xB1ED84", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x10CD178(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv39 = v43 >= 0;\n\tif (v39) goto L_0027;\n\tv42 = 0x10CCFB4(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv58 = 0x10CD178(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv69 = -v43;\n\tv72 = 0x10CD180(r, 0, v16, v17, v18, v19, v20, v21, v69, v23, v24, v25, v26, v27, v28, v29);\n\tv43 = v43 + v43;\n\tv50 = 0x10CCFBC(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\nL_0027:\n\tv55 = 0x10CD188(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv68 = v43 >= 0;\n\tif (v68) goto L_0050;\n\tv75 = 0x10CCFC4(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv85 = 0x10CD188(r, 0, v16, v17, v18, v19, v20, v21, v43, v23, v24, v25, v26, v27, v28, v29);\n\tv103 = -v43;\n\tv106 = 0x10CD190(r, 0, v16, v17, v18, v19, v20, v21, v103, v23, v24, v25, v26, v27, v28, v29);\n\tv89 = v43 + v43;\n\tv95 = 0x10CCFCC(r, 0, v16, v17, v18, v19, v20, v21, v89, v23, v24, v25, v26, v27, v28, v29);\n\treturn;\nL_0050:\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void FlipNegative(ref Rect r)
		{
			//IL_0056: Unsupported input type for neg.
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			//IL_0079: Expected O, but got I
			//IL_00e3: Unsupported input type for neg.
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_0106: Expected O, but got I
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			object obj = default(object);
			if ((long)(IntPtr)obj < 0L)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				object obj2 = 0 - obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD180 (inside UnityEngine.Rect::MinMaxRect +0x1E4)");
				obj = (long)(IntPtr)obj + (long)(IntPtr)obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFBC (inside UnityEngine.Rect::MinMaxRect +0x20)");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			if ((long)(IntPtr)obj < 0L)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				object obj3 = 0 - obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD190 (inside UnityEngine.Rect::MinMaxRect +0x1F4)");
				object obj4 = (long)(IntPtr)obj + (long)(IntPtr)obj;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
			}
		}

		[Token(Token = "0x6000F08")]
		[Address(RVA = "0xB1EE58", Offset = "0xB1EE58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectOverlaps()
		{
		}
	}
}
