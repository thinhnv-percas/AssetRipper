using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754F8C", Offset = "0x754F8C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754F8C", Offset = "0x754F8C")]
	[Token(Token = "0x20001AF")]
	public class ConvertIntToFloat : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADADC", Offset = "0x7ADADC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADADC", Offset = "0x7ADADC")]
		[Token(Token = "0x400135A")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADB3C", Offset = "0x7ADB3C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADB3C", Offset = "0x7ADB3C")]
		[Token(Token = "0x400135B")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat floatVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADB9C", Offset = "0x7ADB9C")]
		[Token(Token = "0x400135C")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000929")]
		[Address(RVA = "0xA92798", Offset = "0xA92798", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.intVariable = 0;\n\tthis.floatVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			intVariable = null;
			floatVariable = null;
		}

		[Token(Token = "0x600092A")]
		[Address(RVA = "0xA927A4", Offset = "0xA927A4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertIntToFloat::DoConvertIntToFloat(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertIntToFloat();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600092B")]
		[Address(RVA = "0xA92828", Offset = "0xA92828", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertIntToFloat::DoConvertIntToFloat(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertIntToFloat();
		}

		[Token(Token = "0x600092C")]
		[Address(RVA = "0xA927E0", Offset = "0xA927E0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.floatVariable;\n\tv14 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertIntToFloat()
		{
			FsmFloat fsmFloat = floatVariable;
			int value = intVariable.Value;
			fsmFloat.Value = value;
		}

		[Token(Token = "0x600092D")]
		[Address(RVA = "0xA9282C", Offset = "0xA9282C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertIntToFloat()
		{
		}
	}
}
