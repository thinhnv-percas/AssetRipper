using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759938", Offset = "0x759938")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759938", Offset = "0x759938")]
	[Token(Token = "0x2000291")]
	public class SetFloatValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8C9C", Offset = "0x7B8C9C")]
		[Token(Token = "0x40016EE")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Token(Token = "0x40016EF")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat floatValue;

		[Token(Token = "0x40016F0")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000CBE")]
		[Address(RVA = "0x99083C", Offset = "0x99083C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariable = 0;\n\tthis.floatValue = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			floatVariable = null;
			floatValue = null;
		}

		[Token(Token = "0x6000CBF")]
		[Address(RVA = "0x990848", Offset = "0x990848", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv16 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tv14.value = v16;\n\tv42 = ~this.everyFrame;\n\tif (v42) goto L_0020;\n\treturn;\nL_0020:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatValue.Value;
			fsmFloat.Value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CC0")]
		[Address(RVA = "0x9908A8", Offset = "0x9908A8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.floatVariable;\n\tv14 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatValue.Value;
			fsmFloat.Value = value;
		}

		[Token(Token = "0x6000CC1")]
		[Address(RVA = "0x9908EC", Offset = "0x9908EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetFloatValue()
		{
		}
	}
}
