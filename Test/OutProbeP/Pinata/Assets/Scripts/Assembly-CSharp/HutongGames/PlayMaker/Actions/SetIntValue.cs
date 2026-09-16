using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7599D8", Offset = "0x7599D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7599D8", Offset = "0x7599D8")]
	[Token(Token = "0x2000293")]
	public class SetIntValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8D24", Offset = "0x7B8D24")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8D24", Offset = "0x7B8D24")]
		[Token(Token = "0x40016F4")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8D84", Offset = "0x7B8D84")]
		[Token(Token = "0x40016F5")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt intValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8DD0", Offset = "0x7B8DD0")]
		[Token(Token = "0x40016F6")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000CC6")]
		[Address(RVA = "0x9958A8", Offset = "0x9958A8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.intVariable = 0;\n\tthis.intValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			intVariable = null;
			intValue = null;
		}

		[Token(Token = "0x6000CC7")]
		[Address(RVA = "0x9958B4", Offset = "0x9958B4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.intVariable;\n\tv16 = HutongGames.PlayMaker.FsmInt::get_Value(this.intValue);\n\tv14.value = v16;\n\tv41 = ~this.everyFrame;\n\tif (v41) goto L_0020;\n\treturn;\nL_0020:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmInt fsmInt = intVariable;
			int value = intValue.Value;
			fsmInt.Value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CC8")]
		[Address(RVA = "0x995914", Offset = "0x995914", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.intVariable;\n\tv14 = HutongGames.PlayMaker.FsmInt::get_Value(this.intValue);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmInt fsmInt = intVariable;
			int value = intValue.Value;
			fsmInt.Value = value;
		}

		[Token(Token = "0x6000CC9")]
		[Address(RVA = "0x995958", Offset = "0x995958", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetIntValue()
		{
		}
	}
}
