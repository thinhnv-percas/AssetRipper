using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7596B8", Offset = "0x7596B8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7596B8", Offset = "0x7596B8")]
	[Token(Token = "0x2000289")]
	public class IntAdd : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8918", Offset = "0x7B8918")]
		[Token(Token = "0x40016D0")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[RequiredField]
		[Token(Token = "0x40016D1")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt add;

		[Token(Token = "0x40016D2")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000C9D")]
		[Address(RVA = "0xA38090", Offset = "0xA38090", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.intVariable = 0;\n\tthis.add = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			intVariable = null;
			add = null;
		}

		[Token(Token = "0x6000C9E")]
		[Address(RVA = "0xA3809C", Offset = "0xA3809C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.intVariable;\n\tv18 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv47 = HutongGames.PlayMaker.FsmInt::get_Value(this.add);\n\tv71 = v47 + v18;\n\tv14.value = v71;\n\tv61 = ~this.everyFrame;\n\tif (v61) goto L_0029;\n\treturn;\nL_0029:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmInt fsmInt = intVariable;
			int value = intVariable.Value;
			int value2 = add.Value;
			int value3 = value2 + value;
			fsmInt.Value = value3;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C9F")]
		[Address(RVA = "0xA3811C", Offset = "0xA3811C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.intVariable;\n\tv16 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv45 = HutongGames.PlayMaker.FsmInt::get_Value(this.add);\n\tv49 = v45 + v16;\n\tv12.value = v49;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmInt fsmInt = intVariable;
			int value = intVariable.Value;
			int value2 = add.Value;
			int value3 = value2 + value;
			fsmInt.Value = value3;
		}

		[Token(Token = "0x6000CA0")]
		[Address(RVA = "0xA38174", Offset = "0xA38174", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntAdd()
		{
		}
	}
}
