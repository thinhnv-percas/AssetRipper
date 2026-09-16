using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758624", Offset = "0x758624")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758624", Offset = "0x758624")]
	[Token(Token = "0x2000258")]
	public class BoolChanged : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B5228", Offset = "0x7B5228")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5228", Offset = "0x7B5228")]
		[Token(Token = "0x40015E5")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5288", Offset = "0x7B5288")]
		[Token(Token = "0x40015E6")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B52C0", Offset = "0x7B52C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B52C0", Offset = "0x7B52C0")]
		[Token(Token = "0x40015E7")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x40015E8")]
		[FieldOffset(Offset = "0x68")]
		private bool previousValue;

		[Token(Token = "0x6000BB4")]
		[Address(RVA = "0xA8C1B0", Offset = "0xA8C1B0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.changedEvent = 0;\n\tthis.storeResult = 0;\n\tthis.boolVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			changedEvent = null;
			storeResult = null;
			boolVariable = null;
		}

		[Token(Token = "0x6000BB5")]
		[Address(RVA = "0xA8C1BC", Offset = "0xA8C1BC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.boolVariable);\n\tv36 = v13 == 0;\n\tif (v36) goto L_001A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_001A:\n\tv51 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tthis.previousValue = v51;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (boolVariable.IsNone)
			{
				Finish();
				return;
			}
			bool value = boolVariable.Value;
			previousValue = value;
		}

		[Token(Token = "0x6000BB6")]
		[Address(RVA = "0xA8C21C", Offset = "0xA8C21C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.storeResult;\n\tv10.value = 0;\n\tv45 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv31 = this.previousValue == 0;\n\tv16 = ~v31;\n\tv87 = v45 ^ v16;\n\tv89 = v87 == 0;\n\tif (v89) goto L_0033;\n\tv49 = this.storeResult;\n\tv49.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = storeResult;
			fsmBool.value = false;
			bool value = boolVariable.Value;
			bool flag = !previousValue;
			bool flag2 = !flag;
			if (value ^ flag2)
			{
				FsmBool fsmBool2 = storeResult;
				fsmBool2.value = true;
				Fsm.Event(changedEvent);
			}
		}

		[Token(Token = "0x6000BB7")]
		[Address(RVA = "0xA8C29C", Offset = "0xA8C29C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolChanged()
		{
		}
	}
}
