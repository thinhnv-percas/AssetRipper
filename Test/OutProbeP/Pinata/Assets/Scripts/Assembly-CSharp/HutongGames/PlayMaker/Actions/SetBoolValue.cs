using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7598E8", Offset = "0x7598E8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7598E8", Offset = "0x7598E8")]
	[Token(Token = "0x2000290")]
	public class SetBoolValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8C50", Offset = "0x7B8C50")]
		[Token(Token = "0x40016EB")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[RequiredField]
		[Token(Token = "0x40016EC")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool boolValue;

		[Token(Token = "0x40016ED")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000CBA")]
		[Address(RVA = "0xB2C4F8", Offset = "0xB2C4F8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.boolVariable = 0;\n\tthis.boolValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			boolVariable = null;
			boolValue = null;
		}

		[Token(Token = "0x6000CBB")]
		[Address(RVA = "0xB2C504", Offset = "0xB2C504", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.boolVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolValue);\n\tv14.value = v16;\n\tv42 = ~this.everyFrame;\n\tif (v42) goto L_0021;\n\treturn;\nL_0021:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmBool fsmBool = boolVariable;
			bool value = boolValue.Value;
			fsmBool.value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CBC")]
		[Address(RVA = "0xB2C568", Offset = "0xB2C568", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.boolVariable;\n\tv14 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolValue);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = boolVariable;
			bool value = boolValue.Value;
			fsmBool.value = value;
		}

		[Token(Token = "0x6000CBD")]
		[Address(RVA = "0xB2C5B0", Offset = "0xB2C5B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetBoolValue()
		{
		}
	}
}
