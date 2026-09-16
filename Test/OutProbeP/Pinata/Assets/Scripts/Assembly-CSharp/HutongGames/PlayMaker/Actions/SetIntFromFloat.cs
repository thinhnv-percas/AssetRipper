using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759988", Offset = "0x759988")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759988", Offset = "0x759988")]
	[Token(Token = "0x2000292")]
	public class SetIntFromFloat : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8CE8", Offset = "0x7B8CE8")]
		[Token(Token = "0x40016F1")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[Token(Token = "0x40016F2")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat floatValue;

		[Token(Token = "0x40016F3")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000CC2")]
		[Address(RVA = "0x9957E8", Offset = "0x9957E8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.intVariable = 0;\n\tthis.floatValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			intVariable = null;
			floatValue = null;
		}

		[Token(Token = "0x6000CC3")]
		[Address(RVA = "0x9957F4", Offset = "0x9957F4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.intVariable;\n\tv16 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tv14.value = v16;\n\tv43 = ~this.everyFrame;\n\tif (v43) goto L_0021;\n\treturn;\nL_0021:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_002b: Expected I4, but got F4
			FsmInt fsmInt = intVariable;
			float value = floatValue.Value;
			fsmInt.Value = (int)value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CC4")]
		[Address(RVA = "0x995858", Offset = "0x995858", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.intVariable;\n\tv14 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_002b: Expected I4, but got F4
			FsmInt fsmInt = intVariable;
			float value = floatValue.Value;
			fsmInt.Value = (int)value;
		}

		[Token(Token = "0x6000CC5")]
		[Address(RVA = "0x9958A0", Offset = "0x9958A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetIntFromFloat()
		{
		}
	}
}
