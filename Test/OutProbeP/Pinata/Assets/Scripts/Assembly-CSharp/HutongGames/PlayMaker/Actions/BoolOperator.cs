using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7586C4", Offset = "0x7586C4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7586C4", Offset = "0x7586C4")]
	[Token(Token = "0x200025A")]
	public class BoolOperator : FsmStateAction
	{
		[Token(Token = "0x200048E")]
		public enum Operation
		{
			[Token(Token = "0x4002182")]
			AND = 0,
			[Token(Token = "0x4002183")]
			NAND = 1,
			[Token(Token = "0x4002184")]
			OR = 2,
			[Token(Token = "0x4002185")]
			XOR = 3
		}

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5430", Offset = "0x7B5430")]
		[Token(Token = "0x40015ED")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool bool1;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B547C", Offset = "0x7B547C")]
		[Token(Token = "0x40015EE")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool bool2;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B54C8", Offset = "0x7B54C8")]
		[Token(Token = "0x40015EF")]
		[FieldOffset(Offset = "0x60")]
		public Operation operation;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B5500", Offset = "0x7B5500")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5500", Offset = "0x7B5500")]
		[Token(Token = "0x40015F0")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B5560", Offset = "0x7B5560")]
		[Token(Token = "0x40015F1")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000BBD")]
		[Address(RVA = "0xA8C410", Offset = "0xA8C410", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.bool1 = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.bool2 = v15;\n\tthis.operation = 0;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = false;
			bool1 = fsmBool;
			FsmBool fsmBool2 = false;
			bool2 = fsmBool2;
			operation = default(Operation);
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000BBE")]
		[Address(RVA = "0xA8C458", Offset = "0xA8C458", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolOperator::DoBoolOperator(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoBoolOperator();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BBF")]
		[Address(RVA = "0xA8C54C", Offset = "0xA8C54C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.BoolOperator::DoBoolOperator(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoBoolOperator();
		}

		[Token(Token = "0x6000BC0")]
		[Address(RVA = "0xA8C494", Offset = "0xA8C494", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmBool::get_Value(this.bool1);\n\tv44 = HutongGames.PlayMaker.FsmBool::get_Value(this.bool2);\n\tv82 = this.operation;\n\tv90 = this.operation < 3;\n\tv76 = ~v90;\n\tv73 = this.operation - 3;\n\tv67 = v73 == 0;\n\tv91 = ~v67;\n\tv52 = v76 & v91;\n\tif (v52) goto L_0040;\n\tv49 = 0x1818000 + 0xDF8;\n\tv81 = *([v49 @ X9_v2 (System.Int32)+v82 @ X8_v3 (HutongGames.PlayMaker.Actions.BoolOperator+Operation)*4]) + v49;\n\t// 36 IndirectJump v81 @ X8_v5, v44 @ X0_v8 (System.Boolean), v44 @ X0_v8 (System.Boolean), 0, v28 @ X2, v29 @ X3, v30 @ X4, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_0041;\n\tX9 = X19 & X0;\n\tgoto L_0039;\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_0041;\n\tX9 = X19 & X0;\n\tX9 = X9 ^ 1;\n\tgoto L_0039;\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_0041;\n\tX9 = X19 | X0;\n\tgoto L_0039;\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_0041;\n\tX9 = X19 ^ X0;\nL_0039:\n\tX9 = X9 & 1;\n\t*([X8+38]) = X9;\nL_0040:\n\treturn;\nL_0041:\n\t;\n\tv26 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoBoolOperator()
		{
			//IL_00b2: Expected O, but got I
			bool value = bool1.Value;
			bool value2 = bool2.Value;
			Operation operation = this.operation;
			bool flag = this.operation < Operation.XOR;
			bool flag2 = !flag;
			int num = (int)(this.operation - 3);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 3576;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X9_v2 (System.Int32)+v82 @ X8_v3 (HutongGames.PlayMaker.Actions.BoolOperator+Operation)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v81 @ X8_v5 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000BC1")]
		[Address(RVA = "0xA8C550", Offset = "0xA8C550", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoolOperator()
		{
		}
	}
}
