using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758854", Offset = "0x758854")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758854", Offset = "0x758854")]
	[Token(Token = "0x200025F")]
	public class FloatChanged : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B5A04", Offset = "0x7B5A04")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5A04", Offset = "0x7B5A04")]
		[Token(Token = "0x4001606")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5A64", Offset = "0x7B5A64")]
		[Token(Token = "0x4001607")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B5A9C", Offset = "0x7B5A9C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5A9C", Offset = "0x7B5A9C")]
		[Token(Token = "0x4001608")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x4001609")]
		[FieldOffset(Offset = "0x68")]
		private float previousValue;

		[Token(Token = "0x6000BD6")]
		[Address(RVA = "0xB75EBC", Offset = "0xB75EBC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.changedEvent = 0;\n\tthis.storeResult = 0;\n\tthis.floatVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			changedEvent = null;
			storeResult = null;
			floatVariable = null;
		}

		[Token(Token = "0x6000BD7")]
		[Address(RVA = "0xB75EC8", Offset = "0xB75EC8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv36 = v13 == 0;\n\tif (v36) goto L_001A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_001A:\n\tv43 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tthis.previousValue = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (floatVariable.IsNone)
			{
				Finish();
				return;
			}
			float value = floatVariable.Value;
			previousValue = value;
		}

		[Token(Token = "0x6000BD8")]
		[Address(RVA = "0xB75F24", Offset = "0xB75F24", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.storeResult;\n\tv10.value = 0;\n\tv55 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv28 = v55 == this.previousValue;\n\tif (v28) goto L_0034;\n\tv43 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv52 = this.storeResult;\n\tthis.previousValue = v43;\n\tv52.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\treturn;\nL_0034:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = storeResult;
			fsmBool.value = false;
			float value = floatVariable.Value;
			if (value != previousValue)
			{
				float value2 = floatVariable.Value;
				FsmBool fsmBool2 = storeResult;
				previousValue = value2;
				fsmBool2.value = true;
				Fsm.Event(changedEvent);
			}
		}

		[Token(Token = "0x6000BD9")]
		[Address(RVA = "0xB75FB0", Offset = "0xB75FB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatChanged()
		{
		}
	}
}
