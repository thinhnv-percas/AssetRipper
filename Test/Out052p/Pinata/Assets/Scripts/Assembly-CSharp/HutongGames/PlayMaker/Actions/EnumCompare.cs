using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7587B4", Offset = "0x7587B4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7587B4", Offset = "0x7587B4")]
	[Token(Token = "0x200025D")]
	public class EnumCompare : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B583C", Offset = "0x7B583C")]
		[Token(Token = "0x40015FC")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum enumVariable;

		[AttributeAttribute(Type = typeof(MatchFieldTypeAttribute), RVA = "0x7B5878", Offset = "0x7B5878")]
		[Token(Token = "0x40015FD")]
		[FieldOffset(Offset = "0x58")]
		public FsmEnum compareTo;

		[Token(Token = "0x40015FE")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent equalEvent;

		[Token(Token = "0x40015FF")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent notEqualEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B58B0", Offset = "0x7B58B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B58B0", Offset = "0x7B58B0")]
		[Token(Token = "0x4001600")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5900", Offset = "0x7B5900")]
		[Token(Token = "0x4001601")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000BCC")]
		[Address(RVA = "0xB74848", Offset = "0xB74848", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeResult = 0;\n\tthis.enumVariable = 0;\n\tthis.equalEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeResult = null;
			enumVariable = null;
			equalEvent = null;
		}

		[Token(Token = "0x6000BCD")]
		[Address(RVA = "0xB7485C", Offset = "0xB7485C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EnumCompare::DoEnumCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoEnumCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BCE")]
		[Address(RVA = "0xB74938", Offset = "0xB74938", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EnumCompare::DoEnumCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoEnumCompare();
		}

		[Token(Token = "0x6000BCF")]
		[Address(RVA = "0xB74898", Offset = "0xB74898", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.enumVariable == 0;\n\tif (v13) goto L_0039;\n\tv15 = this.compareTo == 0;\n\tif (v15) goto L_0039;\n\tv41 = HutongGames.PlayMaker.FsmEnum::get_Value(this.enumVariable);\n\tv70 = HutongGames.PlayMaker.FsmEnum::get_Value(this.compareTo);\n\tv35 = System.Object::Equals(v41, v70);\n\tv29 = this.storeResult;\n\tv88 = this.storeResult == 0;\n\tif (v88) goto L_0020;\n\tv29.value = v35;\nL_0020:\n\tv91 = v35 == 0;\n\tif (v91) goto L_0030;\n\tv52 = this.equalEvent;\n\tv33 = this.equalEvent == 0;\n\tif (v33) goto L_0039;\nL_002E:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v52);\n\treturn;\nL_0030:\n\tv52 = this.notEqualEvent;\n\tv92 = this.notEqualEvent == 0;\n\tv32 = ~v92;\n\tif (v32) goto L_002E;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoEnumCompare()
		{
			if (enumVariable == null || compareTo == null)
			{
				return;
			}
			Enum value = enumVariable.Value;
			Enum value2 = compareTo.Value;
			bool flag = object.Equals(value, value2);
			FsmBool fsmBool = storeResult;
			if (storeResult != null)
			{
				fsmBool.value = flag;
			}
			FsmEvent fsmEvent;
			if (flag)
			{
				fsmEvent = equalEvent;
				if (equalEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = notEqualEvent;
				if (notEqualEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000BD0")]
		[Address(RVA = "0xB7493C", Offset = "0xB7493C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnumCompare()
		{
		}
	}
}
