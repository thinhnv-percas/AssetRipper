using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759758", Offset = "0x759758")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759758", Offset = "0x759758")]
	[Token(Token = "0x200028B")]
	public class IntOperator : FsmStateAction
	{
		[Token(Token = "0x2000490")]
		public enum Operation
		{
			[Token(Token = "0x400218E")]
			Add = 0,
			[Token(Token = "0x400218F")]
			Subtract = 1,
			[Token(Token = "0x4002190")]
			Multiply = 2,
			[Token(Token = "0x4002191")]
			Divide = 3,
			[Token(Token = "0x4002192")]
			Min = 4,
			[Token(Token = "0x4002193")]
			Max = 5
		}

		[RequiredField]
		[Token(Token = "0x40016D7")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt integer1;

		[RequiredField]
		[Token(Token = "0x40016D8")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt integer2;

		[Token(Token = "0x40016D9")]
		[FieldOffset(Offset = "0x60")]
		public Operation operation;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B89E0", Offset = "0x7B89E0")]
		[Token(Token = "0x40016DA")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt storeResult;

		[Token(Token = "0x40016DB")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000CA6")]
		[Address(RVA = "0xA38610", Offset = "0xA38610", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\tthis.operation = 0;\n\tthis.integer1 = 0;\n\tthis.integer2 = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeResult = null;
			everyFrame = false;
			operation = default(Operation);
			integer1 = null;
			integer2 = null;
		}

		[Token(Token = "0x6000CA7")]
		[Address(RVA = "0xA38624", Offset = "0xA38624", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntOperator::DoIntOperator(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIntOperator();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000CA8")]
		[Address(RVA = "0xA387B4", Offset = "0xA387B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntOperator::DoIntOperator(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIntOperator();
		}

		[Token(Token = "0x6000CA9")]
		[Address(RVA = "0xA38660", Offset = "0xA38660", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EDCB68]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E2A]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer1);\n\tv48 = this.integer2 == 0;\n\tif (v48) goto L_005C;\n\tv51 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer2);\n\tv127 = this.operation;\n\tv128 = this.operation < 5;\n\tv106 = ~v128;\n\tv102 = this.operation - 5;\n\tv94 = v102 == 0;\n\tv129 = ~v94;\n\tv74 = v106 & v129;\n\tif (v74) goto L_0077;\n\tv71 = 0x1818000 + 0x878;\n\tv121 = *([v71 @ X9_v2 (System.Int32)+v127 @ X8_v11 (HutongGames.PlayMaker.Actions.IntOperator+Operation)*4]) + v71;\n\t// 50 IndirectJump v121 @ X8_v13, v51 @ X0_v15 (System.Int32), v51 @ X0_v15 (System.Int32), 0, v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX21 = *([X21+68]);\n\tif (TEMP) goto L_005C;\n\tX0 = X20 + X19;\n\tgoto L_0070;\n\tX21 = *([X21+68]);\n\tif (TEMP) goto L_005C;\n\tX0 = X19 - X20;\n\tgoto L_0070;\n\tX21 = *([X21+68]);\n\tif (TEMP) goto L_005C;\n\tX0 = X20 * X19;\n\tgoto L_0070;\n\tX21 = *([X21+68]);\n\tif (TEMP) goto L_005C;\n\tX0 = X19 / X20;\n\tgoto L_0070;\n\tX8 = *([1EEBFB8]);\n\tX21 = *([X21+68]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0054;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX0 = X19;\n\tX1 = X20;\n\tX2 = 0;\n\tX0 = UnityEngine.Mathf::Min(X0, X1, X2);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0070;\nL_005C:\n\tthrow System.NullReferenceException;\n\tv140 = *([v132 @ X0_v9+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_006D;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v132, v54, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006D:\n\tv57 = UnityEngine.Mathf::Max(v44, v3, 0);\n\tv59 = v61 == 0;\n\tif (v59) goto L_005C;\nL_0070:\n\tv61.value = v57;\nL_0077:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIntOperator()
		{
			//IL_00d1: Expected O, but got I
			int value = integer1.Value;
			if (integer2 != null)
			{
				int value2 = integer2.Value;
				Operation operation = this.operation;
				bool flag = this.operation < Operation.Max;
				bool flag2 = !flag;
				int num = (int)(this.operation - 5);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					return;
				}
				int num2 = 25264128 + 2168;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X9_v2 (System.Int32)+v127 @ X8_v11 (HutongGames.PlayMaker.Actions.IntOperator+Operation)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v121 @ X8_v13 (should have been resolved before IL gen)");
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000CAA")]
		[Address(RVA = "0xA387B8", Offset = "0xA387B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntOperator()
		{
		}
	}
}
