using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754DFC", Offset = "0x754DFC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754DFC", Offset = "0x754DFC")]
	[Token(Token = "0x20001AA")]
	public class ConvertBoolToInt : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD524", Offset = "0x7AD524")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD524", Offset = "0x7AD524")]
		[Token(Token = "0x4001345")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD584", Offset = "0x7AD584")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD584", Offset = "0x7AD584")]
		[Token(Token = "0x4001346")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt intVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD5E4", Offset = "0x7AD5E4")]
		[Token(Token = "0x4001347")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt falseValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD61C", Offset = "0x7AD61C")]
		[Token(Token = "0x4001348")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt trueValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD654", Offset = "0x7AD654")]
		[Token(Token = "0x4001349")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000910")]
		[Address(RVA = "0xA921D0", Offset = "0xA921D0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.boolVariable = 0;\n\tthis.intVariable = 0;\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.falseValue = v12;\n\tv15 = HutongGames.PlayMaker.FsmInt::op_Implicit(1);\n\tthis.trueValue = v15;\n\tthis.everyFrame = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			boolVariable = null;
			intVariable = null;
			FsmInt fsmInt = 0;
			falseValue = fsmInt;
			FsmInt fsmInt2 = 1;
			trueValue = fsmInt2;
			everyFrame = false;
		}

		[Token(Token = "0x6000911")]
		[Address(RVA = "0xA92214", Offset = "0xA92214", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToInt::DoConvertBoolToInt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertBoolToInt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000912")]
		[Address(RVA = "0xA922B0", Offset = "0xA922B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToInt::DoConvertBoolToInt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertBoolToInt();
		}

		[Token(Token = "0x6000913")]
		[Address(RVA = "0xA92250", Offset = "0xA92250", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.intVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv42 = v16 == 0;\n\tif (v42) goto L_001E;\n\tv54 = this.trueValue;\nL_0014:\n\tv49 = HutongGames.PlayMaker.FsmInt::get_Value(v54);\n\tv14.value = v49;\n\treturn;\nL_001E:\n\tv54 = this.falseValue;\n\tv52 = this.falseValue == 0;\n\tv21 = ~v52;\n\tif (v21) goto L_0014;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertBoolToInt()
		{
			FsmInt fsmInt = intVariable;
			FsmInt fsmInt2;
			if (boolVariable.Value)
			{
				fsmInt2 = trueValue;
			}
			else
			{
				fsmInt2 = falseValue;
				if (falseValue == null)
				{
					throw new NullReferenceException();
				}
			}
			int value = fsmInt2.Value;
			fsmInt.Value = value;
		}

		[Token(Token = "0x6000914")]
		[Address(RVA = "0xA922B4", Offset = "0xA922B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertBoolToInt()
		{
		}
	}
}
