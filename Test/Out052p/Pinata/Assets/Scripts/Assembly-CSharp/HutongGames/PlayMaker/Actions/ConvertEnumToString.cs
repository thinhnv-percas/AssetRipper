using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754E9C", Offset = "0x754E9C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754E9C", Offset = "0x754E9C")]
	[Token(Token = "0x20001AC")]
	public class ConvertEnumToString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD7F4", Offset = "0x7AD7F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD7F4", Offset = "0x7AD7F4")]
		[Token(Token = "0x400134F")]
		[FieldOffset(Offset = "0x50")]
		public FsmEnum enumVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD854", Offset = "0x7AD854")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD854", Offset = "0x7AD854")]
		[Token(Token = "0x4001350")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD8B4", Offset = "0x7AD8B4")]
		[Token(Token = "0x4001351")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x600091A")]
		[Address(RVA = "0xA923DC", Offset = "0xA923DC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.enumVariable = 0;\n\tthis.stringVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			enumVariable = null;
			stringVariable = null;
		}

		[Token(Token = "0x600091B")]
		[Address(RVA = "0xA923E8", Offset = "0xA923E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertEnumToString::DoConvertEnumToString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertEnumToString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600091C")]
		[Address(RVA = "0xA924C0", Offset = "0xA924C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertEnumToString::DoConvertEnumToString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertEnumToString();
		}

		[Token(Token = "0x600091D")]
		[Address(RVA = "0xA92424", Offset = "0xA92424", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDF7F8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022201]) = v38;\nL_0016:\n\tv41 = this.stringVariable;\n\tv43 = HutongGames.PlayMaker.FsmEnum::get_Value(this.enumVariable);\n\tv62 = v43 == 0;\n\tif (v62) goto L_0032;\n\tv53 = HutongGames.PlayMaker.FsmEnum::get_Value(this.enumVariable);\n\tv75 = System.Enum::ToString(v53);\nL_0028:\n\tv41.value = v75;\n\treturn;\nL_0032:\n\tv66 = this.stringVariable == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0028;\n\tv51 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertEnumToString()
		{
			FsmString fsmString = stringVariable;
			Enum value = enumVariable.Value;
			string value3;
			if (value != null)
			{
				Enum value2 = enumVariable.Value;
				value3 = value2.ToString();
			}
			else
			{
				bool flag = stringVariable == null;
				bool flag2 = !flag;
				value3 = "";
				if (!flag2)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			fsmString.Value = value3;
		}

		[Token(Token = "0x600091E")]
		[Address(RVA = "0xA924C4", Offset = "0xA924C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertEnumToString()
		{
		}
	}
}
