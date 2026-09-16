using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758DF8", Offset = "0x758DF8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758DF8", Offset = "0x758DF8")]
	[Token(Token = "0x200026D")]
	public class IntChanged : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B6C9C", Offset = "0x7B6C9C")]
		[Token(Token = "0x4001651")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[Token(Token = "0x4001652")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B6CD8", Offset = "0x7B6CD8")]
		[Token(Token = "0x4001653")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x4001654")]
		[FieldOffset(Offset = "0x68")]
		private int previousValue;

		[Token(Token = "0x6000C1B")]
		[Address(RVA = "0xA3817C", Offset = "0xA3817C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.changedEvent = 0;\n\tthis.storeResult = 0;\n\tthis.intVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			changedEvent = null;
			storeResult = null;
			intVariable = null;
		}

		[Token(Token = "0x6000C1C")]
		[Address(RVA = "0xA38188", Offset = "0xA38188", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.intVariable);\n\tv36 = v13 == 0;\n\tif (v36) goto L_001A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tthis.previousValue = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (intVariable.IsNone)
			{
				Finish();
				return;
			}
			int value = intVariable.Value;
			previousValue = value;
		}

		[Token(Token = "0x6000C1D")]
		[Address(RVA = "0xA381E4", Offset = "0xA381E4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.storeResult;\n\tv10.value = 0;\n\tv52 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv16 = v52 != this.previousValue;\n\tif (v16) goto L_0024;\n\treturn;\nL_0024:\n\tv45 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv49 = this.storeResult;\n\tthis.previousValue = v45;\n\tv49.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = storeResult;
			fsmBool.value = false;
			int value = intVariable.Value;
			if (value != previousValue)
			{
				int value2 = intVariable.Value;
				FsmBool fsmBool2 = storeResult;
				previousValue = value2;
				fsmBool2.value = true;
				Fsm.Event(changedEvent);
			}
		}

		[Token(Token = "0x6000C1E")]
		[Address(RVA = "0xA38270", Offset = "0xA38270", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntChanged()
		{
		}
	}
}
