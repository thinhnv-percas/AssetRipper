using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754DAC", Offset = "0x754DAC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754DAC", Offset = "0x754DAC")]
	[Token(Token = "0x20001A9")]
	public class ConvertBoolToFloat : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD3BC", Offset = "0x7AD3BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD3BC", Offset = "0x7AD3BC")]
		[Token(Token = "0x4001340")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD41C", Offset = "0x7AD41C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD41C", Offset = "0x7AD41C")]
		[Token(Token = "0x4001341")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat floatVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD47C", Offset = "0x7AD47C")]
		[Token(Token = "0x4001342")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat falseValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD4B4", Offset = "0x7AD4B4")]
		[Token(Token = "0x4001343")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat trueValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD4EC", Offset = "0x7AD4EC")]
		[Token(Token = "0x4001344")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x600090B")]
		[Address(RVA = "0xA920E4", Offset = "0xA920E4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolVariable = 0;\n\tthis.floatVariable = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.falseValue = v12;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.trueValue = v15;\n\tthis.everyFrame = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			boolVariable = null;
			floatVariable = null;
			FsmFloat fsmFloat = 0f;
			falseValue = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			trueValue = fsmFloat2;
			everyFrame = false;
		}

		[Token(Token = "0x600090C")]
		[Address(RVA = "0xA92128", Offset = "0xA92128", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToFloat::DoConvertBoolToFloat(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertBoolToFloat();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600090D")]
		[Address(RVA = "0xA921C4", Offset = "0xA921C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToFloat::DoConvertBoolToFloat(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertBoolToFloat();
		}

		[Token(Token = "0x600090E")]
		[Address(RVA = "0xA92164", Offset = "0xA92164", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.floatVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv42 = v16 == 0;\n\tif (v42) goto L_001E;\n\tv51 = this.trueValue;\nL_0014:\n\tv44 = HutongGames.PlayMaker.FsmFloat::get_Value(v51);\n\tv14.value = v44;\n\treturn;\nL_001E:\n\tv51 = this.falseValue;\n\tv54 = this.falseValue == 0;\n\tv21 = ~v54;\n\tif (v21) goto L_0014;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertBoolToFloat()
		{
			FsmFloat fsmFloat = floatVariable;
			FsmFloat fsmFloat2;
			if (boolVariable.Value)
			{
				fsmFloat2 = trueValue;
			}
			else
			{
				fsmFloat2 = falseValue;
				if (falseValue == null)
				{
					throw new NullReferenceException();
				}
			}
			float value = fsmFloat2.Value;
			fsmFloat.Value = value;
		}

		[Token(Token = "0x600090F")]
		[Address(RVA = "0xA921C8", Offset = "0xA921C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertBoolToFloat()
		{
		}
	}
}
