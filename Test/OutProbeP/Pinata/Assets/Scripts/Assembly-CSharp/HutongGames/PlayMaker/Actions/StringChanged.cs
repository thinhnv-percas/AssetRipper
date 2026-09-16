using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758F38", Offset = "0x758F38")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758F38", Offset = "0x758F38")]
	[Token(Token = "0x2000271")]
	public class StringChanged : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B6FAC", Offset = "0x7B6FAC")]
		[Token(Token = "0x4001665")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Token(Token = "0x4001666")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B6FE8", Offset = "0x7B6FE8")]
		[Token(Token = "0x4001667")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x4001668")]
		[FieldOffset(Offset = "0x68")]
		private string previousValue;

		[Token(Token = "0x6000C2F")]
		[Address(RVA = "0x99E5A8", Offset = "0x99E5A8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.changedEvent = 0;\n\tthis.storeResult = 0;\n\tthis.stringVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			changedEvent = null;
			storeResult = null;
			stringVariable = null;
		}

		[Token(Token = "0x6000C30")]
		[Address(RVA = "0x99E5B4", Offset = "0x99E5B4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.stringVariable);\n\tv36 = v13 == 0;\n\tif (v36) goto L_001A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tthis.previousValue = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (stringVariable.IsNone)
			{
				Finish();
				return;
			}
			string value = stringVariable.Value;
			previousValue = value;
		}

		[Token(Token = "0x6000C31")]
		[Address(RVA = "0x99E610", Offset = "0x99E610", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tv44 = System.String::op_Inequality(v13, this.previousValue);\n\tv55 = v44 == 0;\n\tif (v55) goto L_0025;\n\tv19 = this.storeResult;\n\tv19.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\treturn;\nL_0025:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			string value = stringVariable.Value;
			if (value != previousValue)
			{
				FsmBool fsmBool = storeResult;
				fsmBool.value = true;
				Fsm.Event(changedEvent);
			}
		}

		[Token(Token = "0x6000C32")]
		[Address(RVA = "0x99E684", Offset = "0x99E684", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringChanged()
		{
		}
	}
}
