using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7595C8", Offset = "0x7595C8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7595C8", Offset = "0x7595C8")]
	[Token(Token = "0x2000286")]
	public class FloatMultiply : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B85B0", Offset = "0x7B85B0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B85B0", Offset = "0x7B85B0")]
		[Token(Token = "0x40016C4")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8610", Offset = "0x7B8610")]
		[Token(Token = "0x40016C5")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat multiplyBy;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B865C", Offset = "0x7B865C")]
		[Token(Token = "0x40016C6")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000C8F")]
		[Address(RVA = "0xB76704", Offset = "0xB76704", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariable = 0;\n\tthis.multiplyBy = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			floatVariable = null;
			multiplyBy = null;
		}

		[Token(Token = "0x6000C90")]
		[Address(RVA = "0xB76710", Offset = "0xB76710", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv18 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv45 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplyBy);\n\tv46 = v18 * v45;\n\tv14.value = v46;\n\tv48 = ~this.everyFrame;\n\tif (v48) goto L_0028;\n\treturn;\nL_0028:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = multiplyBy.Value;
			float value3 = value * value2;
			fsmFloat.Value = value3;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C91")]
		[Address(RVA = "0xB7678C", Offset = "0xB7678C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv18 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv45 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplyBy);\n\tv46 = v18 * v45;\n\tv14.value = v46;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = multiplyBy.Value;
			float value3 = value * value2;
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6000C92")]
		[Address(RVA = "0xB767E8", Offset = "0xB767E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatMultiply()
		{
		}
	}
}
