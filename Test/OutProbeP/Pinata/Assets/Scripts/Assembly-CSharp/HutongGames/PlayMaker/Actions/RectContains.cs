using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BB80", Offset = "0x75BB80")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75BB80", Offset = "0x75BB80")]
	[Token(Token = "0x20002FC")]
	public class RectContains : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2074", Offset = "0x7C2074")]
		[Token(Token = "0x4001927")]
		[FieldOffset(Offset = "0x50")]
		public FsmRect rectangle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C20C0", Offset = "0x7C20C0")]
		[Token(Token = "0x4001928")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 point;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C20F8", Offset = "0x7C20F8")]
		[Token(Token = "0x4001929")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2130", Offset = "0x7C2130")]
		[Token(Token = "0x400192A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2168", Offset = "0x7C2168")]
		[Token(Token = "0x400192B")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C21A0", Offset = "0x7C21A0")]
		[Token(Token = "0x400192C")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C21D8", Offset = "0x7C21D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C21D8", Offset = "0x7C21D8")]
		[Token(Token = "0x400192D")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C2228", Offset = "0x7C2228")]
		[Token(Token = "0x400192E")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x6000EFD")]
		[Address(RVA = "0xB1E898", Offset = "0xB1E898", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF8E38]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202258F]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmRect();\n\tHutongGames.PlayMaker.FsmRect::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.rectangle = v46;\n\tv54 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.point = v54;\n\tv64 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v64);\n\tv64.useVariable = 1;\n\tthis.x = v64;\n\tv65 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v65);\n\tv65.useVariable = 1;\n\tthis.falseEvent = 0;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\tthis.y = v65;\n\tthis.trueEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmRect fsmRect = new FsmRect();
			fsmRect.useVariable = true;
			rectangle = fsmRect;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			point = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			falseEvent = null;
			storeResult = null;
			everyFrame = false;
			y = fsmFloat2;
			trueEvent = null;
		}

		[Token(Token = "0x6000EFE")]
		[Address(RVA = "0xB1E990", Offset = "0xB1E990", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectContains::DoRectContains(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRectContains();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000EFF")]
		[Address(RVA = "0xB1EAF0", Offset = "0xB1EAF0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectContains::DoRectContains(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoRectContains();
		}

		[Token(Token = "0x6000F00")]
		[Address(RVA = "0xB1E9CC", Offset = "0xB1E9CC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rectangle);\n\tv70 = v21 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0068;\n\tv37 = HutongGames.PlayMaker.FsmVector3::get_Value(this.point);\n\tv173 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.x);\n\tv175 = v173 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0031;\n\tv178 = HutongGames.PlayMaker.FsmFloat::get_Value(this.x);\nL_0031:\n\tv182 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.y);\n\tv184 = v182 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_003C;\n\tv187 = HutongGames.PlayMaker.FsmFloat::get_Value(this.y);\nL_003C:\n\tv79 = this.rectangle;\n\tv190 = v79.value;\n\tv99 = 0x10CD20C(&v190 @ V0_v7 (UnityEngine.Rect), 0, v58, v59, v60, v61, v62, v63, v28, v82, v37.z, v64, v65, v66, v67, v68);\n\tv77 = this.storeResult;\n\tv74 = v99 & 1;\n\tv77.value = v74;\n\tv129 = this + 0x70;\n\tv126 = this + 0x78;\n\tv140 = v99 & 1;\n\tv120 = v140 == 0;\n\tv111 = ~v120;\n\tv108 = ~v111;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_0060;\nL_0060:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v129 @ X9_v5]));\nL_0068:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRectContains()
		{
			//IL_00a1: Expected O, but got F4
			//IL_015e: Expected O, but got I
			//IL_016a: Expected O, but got I
			if (!rectangle.IsNone)
			{
				Vector3 value = point.Value;
				bool isNone = x.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				Vector3 vector = value;
				if (!flag2)
				{
					float value2 = x.Value;
					vector = (Vector3)value2;
				}
				bool isNone2 = y.IsNone;
				bool flag3 = !isNone2;
				bool flag4 = !flag3;
				float num = value.y;
				if (!flag4)
				{
					float value3 = y.Value;
					num = value3;
				}
				FsmRect fsmRect = rectangle;
				Rect value4 = fsmRect.value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD20C (inside UnityEngine.Rect::MinMaxRect +0x270)");
				FsmBool fsmBool = storeResult;
				object obj = default(object);
				int value5 = (int)((long)(IntPtr)obj & 1L);
				fsmBool.value = (byte)value5 != 0;
				object fsmEvent = (long)(IntPtr)this + 112L;
				object obj2 = (long)(IntPtr)this + 120L;
				if ((int)((long)(IntPtr)obj & 1L) == 0)
				{
					fsmEvent = obj2;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000F01")]
		[Address(RVA = "0xB1EAF4", Offset = "0xB1EAF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectContains()
		{
		}
	}
}
