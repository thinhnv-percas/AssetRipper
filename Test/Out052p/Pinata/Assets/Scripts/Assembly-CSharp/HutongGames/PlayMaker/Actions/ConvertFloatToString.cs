using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754F3C", Offset = "0x754F3C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754F3C", Offset = "0x754F3C")]
	[Token(Token = "0x20001AE")]
	public class ConvertFloatToString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AD9AC", Offset = "0x7AD9AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AD9AC", Offset = "0x7AD9AC")]
		[Token(Token = "0x4001356")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ADA0C", Offset = "0x7ADA0C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADA0C", Offset = "0x7ADA0C")]
		[Token(Token = "0x4001357")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringVariable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADA6C", Offset = "0x7ADA6C")]
		[Token(Token = "0x4001358")]
		[FieldOffset(Offset = "0x60")]
		public FsmString format;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADAA4", Offset = "0x7ADAA4")]
		[Token(Token = "0x4001359")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000924")]
		[Address(RVA = "0xA92674", Offset = "0xA92674", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.stringVariable = 0;\n\tthis.format = 0;\n\tthis.floatVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			stringVariable = null;
			format = null;
			floatVariable = null;
		}

		[Token(Token = "0x6000925")]
		[Address(RVA = "0xA92684", Offset = "0xA92684", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertFloatToString::DoConvertFloatToString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertFloatToString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000926")]
		[Address(RVA = "0xA9278C", Offset = "0xA9278C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertFloatToString::DoConvertFloatToString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertFloatToString();
		}

		[Token(Token = "0x6000927")]
		[Address(RVA = "0xA926C0", Offset = "0xA926C0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.format);\n\tv62 = v16 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_001E;\n\tv89 = HutongGames.PlayMaker.FsmString::get_Value(this.format);\n\tv67 = System.String::IsNullOrEmpty(v89);\n\tv65 = v67 == 0;\n\tif (v65) goto L_0031;\nL_001E:\n\tv100 = this.stringVariable;\n\tv92 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv81 = 0xBCCEC8(&v92 @ V0_v4 (System.Single), 0, v19, v49, v50, v51, v52, v53, v92, v54, v55, v56, v57, v58, v59, v60);\nL_0027:\n\tv100.value = v81;\n\treturn;\nL_0031:\n\tv100 = this.stringVariable;\n\tv92 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv107 = HutongGames.PlayMaker.FsmString::get_Value(this.format);\n\tv81 = 0xBCCF34(&v92 @ V0_v4 (System.Single), v107, 0, v49, v50, v51, v52, v53, v92, v54, v55, v56, v57, v58, v59, v60);\n\tv109 = this.stringVariable == 0;\n\tv102 = ~v109;\n\tif (v102) goto L_0027;\n\tv40 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertFloatToString()
		{
			FsmString fsmString;
			float value2;
			if (!format.IsNone)
			{
				string value = format.Value;
				if (!string.IsNullOrEmpty(value))
				{
					fsmString = stringVariable;
					value2 = floatVariable.Value;
					string value3 = format.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
					if (stringVariable == null)
					{
						NullReferenceException ex = new NullReferenceException();
						throw new NullReferenceException();
					}
					goto IL_009d;
				}
			}
			fsmString = stringVariable;
			value2 = floatVariable.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCEC8 (inside System.Single::IsNaN +0x2B0)");
			goto IL_009d;
			IL_009d:
			string value4 = default(string);
			fsmString.Value = value4;
		}

		[Token(Token = "0x6000928")]
		[Address(RVA = "0xA92790", Offset = "0xA92790", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertFloatToString()
		{
		}
	}
}
