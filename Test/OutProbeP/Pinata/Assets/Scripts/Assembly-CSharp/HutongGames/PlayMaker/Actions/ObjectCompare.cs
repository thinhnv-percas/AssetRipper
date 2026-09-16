using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758EE8", Offset = "0x758EE8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758EE8", Offset = "0x758EE8")]
	[Token(Token = "0x2000270")]
	public class ObjectCompare : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6E58", Offset = "0x7B6E58")]
		[Readonly]
		[Token(Token = "0x400165F")]
		[FieldOffset(Offset = "0x50")]
		public FsmObject objectVariable;

		[RequiredField]
		[Token(Token = "0x4001660")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject compareTo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6EB4", Offset = "0x7B6EB4")]
		[Token(Token = "0x4001661")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent equalEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6EEC", Offset = "0x7B6EEC")]
		[Token(Token = "0x4001662")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent notEqualEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6F24", Offset = "0x7B6F24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6F24", Offset = "0x7B6F24")]
		[Token(Token = "0x4001663")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6F74", Offset = "0x7B6F74")]
		[Token(Token = "0x4001664")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000C2A")]
		[Address(RVA = "0xB18F6C", Offset = "0xB18F6C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeResult = 0;\n\tthis.objectVariable = 0;\n\tthis.equalEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeResult = null;
			objectVariable = null;
			equalEvent = null;
		}

		[Token(Token = "0x6000C2B")]
		[Address(RVA = "0xB18F80", Offset = "0xB18F80", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ObjectCompare::DoObjectCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoObjectCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C2C")]
		[Address(RVA = "0xB190A4", Offset = "0xB190A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ObjectCompare::DoObjectCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoObjectCompare();
		}

		[Token(Token = "0x6000C2D")]
		[Address(RVA = "0xB18FBC", Offset = "0xB18FBC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EBE128]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202255B]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmObject::get_Value(this.objectVariable);\n\tv67 = HutongGames.PlayMaker.FsmObject::get_Value(this.compareTo);\n\tgoto L_0031;\n\tv128 = *([v124 @ X8_v8+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0031;\n\tv135 = v124;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v135, v66, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv74 = UnityEngine.Object::op_Equality(v44, v67);\n\tv77 = this.storeResult;\n\tv77.value = v74;\n\tv106 = this + 0x60;\n\tv101 = this + 0x68;\n\tv95 = v74 == 0;\n\tv86 = ~v95;\n\tv83 = ~v86;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_0051;\nL_0051:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v106 @ X9_v7]));\n\treturn;\n\tv55 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoObjectCompare()
		{
			//IL_006b: Expected O, but got I
			//IL_0077: Expected O, but got I
			UnityEngine.Object value = objectVariable.Value;
			UnityEngine.Object value2 = compareTo.Value;
			bool flag = value == value2;
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

		[Token(Token = "0x6000C2E")]
		[Address(RVA = "0xB190A8", Offset = "0xB190A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObjectCompare()
		{
		}
	}
}
