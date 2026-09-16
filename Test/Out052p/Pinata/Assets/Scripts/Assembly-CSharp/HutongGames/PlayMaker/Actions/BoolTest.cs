using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758714", Offset = "0x758714")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758714", Offset = "0x758714")]
	[Token(Token = "0x200025B")]
	public class BoolTest : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5598", Offset = "0x7B5598")]
		[Readonly]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5598", Offset = "0x7B5598")]
		[Token(Token = "0x40015F2")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5608", Offset = "0x7B5608")]
		[Token(Token = "0x40015F3")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent isTrue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5640", Offset = "0x7B5640")]
		[Token(Token = "0x40015F4")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent isFalse;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5678", Offset = "0x7B5678")]
		[Token(Token = "0x40015F5")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BC2")]
		[Address(RVA = "0xA8C558", Offset = "0xA8C558", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.isTrue = 0;\n\tthis.isFalse = 0;\n\tthis.boolVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			isTrue = null;
			isFalse = null;
			boolVariable = null;
		}

		[Token(Token = "0x6000BC3")]
		[Address(RVA = "0xA8C568", Offset = "0xA8C568", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv90 = this + 0x58;\n\tv41 = this + 0x60;\n\tv44 = v16 == 0;\n\tv47 = ~v44;\n\tv48 = ~v47;\n\tif (v48) goto L_FFFFFFFF;\n\tgoto L_0020;\nL_0020:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v90 @ X8_v2]));\n\tv80 = ~this.everyFrame;\n\tif (v80) goto L_0031;\n\treturn;\nL_0031:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0020: Expected O, but got I
			//IL_002c: Expected O, but got I
			bool value = boolVariable.Value;
			object fsmEvent = (long)(IntPtr)this + 88L;
			object obj = (long)(IntPtr)this + 96L;
			if (!value)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BC4")]
		[Address(RVA = "0xA8C5E4", Offset = "0xA8C5E4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv70 = this + 0x58;\n\tv41 = this + 0x60;\n\tv44 = v16 == 0;\n\tv47 = ~v44;\n\tv48 = ~v47;\n\tif (v48) goto L_FFFFFFFF;\n\tgoto L_0025;\nL_0025:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v70 @ X8_v2]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_0020: Expected O, but got I
			//IL_002c: Expected O, but got I
			bool value = boolVariable.Value;
			object fsmEvent = (long)(IntPtr)this + 88L;
			object obj = (long)(IntPtr)this + 96L;
			if (!value)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x6000BC5")]
		[Address(RVA = "0xA8C640", Offset = "0xA8C640", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolTest()
		{
		}
	}
}
