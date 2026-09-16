using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754FDC", Offset = "0x754FDC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754FDC", Offset = "0x754FDC")]
	[Token(Token = "0x20001B0")]
	public class ConvertIntToString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ADBD4", Offset = "0x7ADBD4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADBD4", Offset = "0x7ADBD4")]
		[Token(Token = "0x400135D")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ADC34", Offset = "0x7ADC34")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADC34", Offset = "0x7ADC34")]
		[Token(Token = "0x400135E")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADC94", Offset = "0x7ADC94")]
		[Token(Token = "0x400135F")]
		[FieldOffset(Offset = "0x60")]
		public FsmString format;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADCCC", Offset = "0x7ADCCC")]
		[Token(Token = "0x4001360")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x600092E")]
		[Address(RVA = "0xA92834", Offset = "0xA92834", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.stringVariable = 0;\n\tthis.format = 0;\n\tthis.intVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			stringVariable = null;
			format = null;
			intVariable = null;
		}

		[Token(Token = "0x600092F")]
		[Address(RVA = "0xA92844", Offset = "0xA92844", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertIntToString::DoConvertIntToString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertIntToString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000930")]
		[Address(RVA = "0xA9294C", Offset = "0xA9294C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertIntToString::DoConvertIntToString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertIntToString();
		}

		[Token(Token = "0x6000931")]
		[Address(RVA = "0xA92880", Offset = "0xA92880", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.format);\n\tv59 = v16 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_001E;\n\tv84 = HutongGames.PlayMaker.FsmString::get_Value(this.format);\n\tv64 = System.String::IsNullOrEmpty(v84);\n\tv62 = v64 == 0;\n\tif (v62) goto L_0031;\nL_001E:\n\tv95 = this.stringVariable;\n\tv87 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv76 = 0xDC3560(&v87 @ X0_v11 (System.Int32), 0, v19, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0027:\n\tv95.value = v76;\n\treturn;\nL_0031:\n\tv95 = this.stringVariable;\n\tv101 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv103 = HutongGames.PlayMaker.FsmString::get_Value(this.format);\n\tv76 = 0xDC3590(&v101 @ X0_v18 (System.Int32), v103, 0, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv105 = this.stringVariable == 0;\n\tv97 = ~v105;\n\tif (v97) goto L_0027;\n\tv36 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertIntToString()
		{
			FsmString fsmString;
			if (!format.IsNone)
			{
				string value = format.Value;
				if (!string.IsNullOrEmpty(value))
				{
					fsmString = stringVariable;
					int value2 = intVariable.Value;
					string value3 = format.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3590 (inside System.InvalidCastException::.ctor +0x2B8)");
					if (stringVariable == null)
					{
						NullReferenceException ex = new NullReferenceException();
						throw new NullReferenceException();
					}
					goto IL_009d;
				}
			}
			fsmString = stringVariable;
			int value4 = intVariable.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			goto IL_009d;
			IL_009d:
			string value5 = default(string);
			fsmString.Value = value5;
		}

		[Token(Token = "0x6000932")]
		[Address(RVA = "0xA92950", Offset = "0xA92950", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertIntToString()
		{
		}
	}
}
