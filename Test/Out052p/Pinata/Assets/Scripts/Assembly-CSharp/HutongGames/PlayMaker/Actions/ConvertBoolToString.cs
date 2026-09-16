using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754E4C", Offset = "0x754E4C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754E4C", Offset = "0x754E4C")]
	[Token(Token = "0x20001AB")]
	public class ConvertBoolToString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD68C", Offset = "0x7AD68C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD68C", Offset = "0x7AD68C")]
		[Token(Token = "0x400134A")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool boolVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD6EC", Offset = "0x7AD6EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD6EC", Offset = "0x7AD6EC")]
		[Token(Token = "0x400134B")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD74C", Offset = "0x7AD74C")]
		[Token(Token = "0x400134C")]
		[FieldOffset(Offset = "0x60")]
		public FsmString falseString;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD784", Offset = "0x7AD784")]
		[Token(Token = "0x400134D")]
		[FieldOffset(Offset = "0x68")]
		public FsmString trueString;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD7BC", Offset = "0x7AD7BC")]
		[Token(Token = "0x400134E")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000915")]
		[Address(RVA = "0xA922BC", Offset = "0xA922BC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EABAE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022200]) = v38;\nL_0013:\n\tthis.boolVariable = 0;\n\tthis.stringVariable = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"False\");\n\tthis.falseString = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"True\");\n\tthis.trueString = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			boolVariable = null;
			stringVariable = null;
			FsmString fsmString = "False";
			falseString = fsmString;
			FsmString fsmString2 = "True";
			trueString = fsmString2;
			everyFrame = false;
		}

		[Token(Token = "0x6000916")]
		[Address(RVA = "0xA92334", Offset = "0xA92334", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToString::DoConvertBoolToString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertBoolToString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000917")]
		[Address(RVA = "0xA923D0", Offset = "0xA923D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertBoolToString::DoConvertBoolToString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertBoolToString();
		}

		[Token(Token = "0x6000918")]
		[Address(RVA = "0xA92370", Offset = "0xA92370", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.stringVariable;\n\tv16 = HutongGames.PlayMaker.FsmBool::get_Value(this.boolVariable);\n\tv42 = v16 == 0;\n\tif (v42) goto L_001E;\n\tv54 = this.trueString;\nL_0014:\n\tv49 = HutongGames.PlayMaker.FsmString::get_Value(v54);\n\tv14.value = v49;\n\treturn;\nL_001E:\n\tv54 = this.falseString;\n\tv52 = this.falseString == 0;\n\tv21 = ~v52;\n\tif (v21) goto L_0014;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertBoolToString()
		{
			FsmString fsmString = stringVariable;
			FsmString fsmString2;
			if (boolVariable.Value)
			{
				fsmString2 = trueString;
			}
			else
			{
				fsmString2 = falseString;
				if (falseString == null)
				{
					throw new NullReferenceException();
				}
			}
			string value = fsmString2.Value;
			fsmString.Value = value;
		}

		[Token(Token = "0x6000919")]
		[Address(RVA = "0xA923D4", Offset = "0xA923D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertBoolToString()
		{
		}
	}
}
