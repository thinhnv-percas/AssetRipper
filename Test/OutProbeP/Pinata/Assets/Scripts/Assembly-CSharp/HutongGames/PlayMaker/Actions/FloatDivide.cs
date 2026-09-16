using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759528", Offset = "0x759528")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759528", Offset = "0x759528")]
	[Token(Token = "0x2000284")]
	public class FloatDivide : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B82E0", Offset = "0x7B82E0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B82E0", Offset = "0x7B82E0")]
		[Token(Token = "0x40016B8")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8340", Offset = "0x7B8340")]
		[Token(Token = "0x40016B9")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat divideBy;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B838C", Offset = "0x7B838C")]
		[Token(Token = "0x40016BA")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000C87")]
		[Address(RVA = "0xB763B4", Offset = "0xB763B4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.floatVariable = 0;\n\tthis.divideBy = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			floatVariable = null;
			divideBy = null;
		}

		[Token(Token = "0x6000C88")]
		[Address(RVA = "0xB763C0", Offset = "0xB763C0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv18 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv45 = HutongGames.PlayMaker.FsmFloat::get_Value(this.divideBy);\n\tv46 = v18 / v45;\n\tv14.value = v46;\n\tv48 = ~this.everyFrame;\n\tif (v48) goto L_0028;\n\treturn;\nL_0028:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = divideBy.Value;
			float value3 = value / value2;
			fsmFloat.Value = value3;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C89")]
		[Address(RVA = "0xB7643C", Offset = "0xB7643C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv18 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv45 = HutongGames.PlayMaker.FsmFloat::get_Value(this.divideBy);\n\tv46 = v18 / v45;\n\tv14.value = v46;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmFloat fsmFloat = floatVariable;
			float value = floatVariable.Value;
			float value2 = divideBy.Value;
			float value3 = value / value2;
			fsmFloat.Value = value3;
		}

		[Token(Token = "0x6000C8A")]
		[Address(RVA = "0xB76498", Offset = "0xB76498", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatDivide()
		{
		}
	}
}
