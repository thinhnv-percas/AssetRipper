using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759618", Offset = "0x759618")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759618", Offset = "0x759618")]
	[Token(Token = "0x2000287")]
	public class FloatOperator : FsmStateAction
	{
		[Token(Token = "0x200048F")]
		public enum Operation
		{
			[Token(Token = "0x4002187")]
			Add = 0,
			[Token(Token = "0x4002188")]
			Subtract = 1,
			[Token(Token = "0x4002189")]
			Multiply = 2,
			[Token(Token = "0x400218A")]
			Divide = 3,
			[Token(Token = "0x400218B")]
			Min = 4,
			[Token(Token = "0x400218C")]
			Max = 5
		}

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8694", Offset = "0x7B8694")]
		[Token(Token = "0x40016C7")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat float1;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B86E0", Offset = "0x7B86E0")]
		[Token(Token = "0x40016C8")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat float2;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B872C", Offset = "0x7B872C")]
		[Token(Token = "0x40016C9")]
		[FieldOffset(Offset = "0x60")]
		public Operation operation;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B8764", Offset = "0x7B8764")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B8764", Offset = "0x7B8764")]
		[Token(Token = "0x40016CA")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B87C4", Offset = "0x7B87C4")]
		[Token(Token = "0x40016CB")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000C93")]
		[Address(RVA = "0xB767F0", Offset = "0xB767F0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\tthis.operation = 0;\n\tthis.float1 = 0;\n\tthis.float2 = 0;\n\treturn;\n")]
		public override void Reset()
		{
			storeResult = null;
			everyFrame = false;
			operation = default(Operation);
			float1 = null;
			float2 = null;
		}

		[Token(Token = "0x6000C94")]
		[Address(RVA = "0xB76804", Offset = "0xB76804", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatOperator::DoFloatOperator(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatOperator();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C95")]
		[Address(RVA = "0xB76990", Offset = "0xB76990", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatOperator::DoFloatOperator(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatOperator();
		}

		[Token(Token = "0x6000C96")]
		[Address(RVA = "0xB76840", Offset = "0xB76840", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE3548]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202292F]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float1);\n\tv57 = HutongGames.PlayMaker.FsmFloat::get_Value(this.float2);\n\tv103 = this.operation;\n\tv108 = this.operation < 5;\n\tv88 = ~v108;\n\tv85 = this.operation - 5;\n\tv79 = v85 == 0;\n\tv109 = ~v79;\n\tv64 = v88 & v109;\n\tif (v64) goto L_0078;\n\tv61 = 0x1819000 + 0xA38;\n\tv102 = *([v61 @ X9_v2 (System.Int32)+v103 @ X8_v3 (HutongGames.PlayMaker.Actions.FloatOperator+Operation)*4]) + v61;\n\t// 50 IndirectJump v102 @ X8_v5, this.float2 (HutongGames.PlayMaker.FsmFloat), this.float2 (HutongGames.PlayMaker.FsmFloat), 0, v26 @ X2, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v57 @ V0_v3 (System.Single), v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tX19 = *([X19+68]);\n\tif (TEMP) goto L_005B;\n\tV0 = V8 + V9;\n\tgoto L_0070;\n\tX19 = *([X19+68]);\n\tif (TEMP) goto L_005B;\n\tV0 = V8 - V9;\n\tgoto L_0070;\n\tX19 = *([X19+68]);\n\tif (TEMP) goto L_005B;\n\tV0 = V8 * V9;\n\tgoto L_0070;\n\tX19 = *([X19+68]);\n\tif (TEMP) goto L_005B;\n\tV0 = V8 / V9;\n\tgoto L_0070;\n\tX8 = *([1EEBFB8]);\n\tX19 = *([X19+68]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0054;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tV0 = V8;\n\tV1 = V9;\n\tX0 = 0;\n\tV0 = UnityEngine.Mathf::Min(V0, V1, X0);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0070;\nL_005B:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EEBFB8]);\n\tX19 = *([X19+68]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006A:\n\tV0 = V8;\n\tV1 = V9;\n\tX0 = 0;\n\tV0 = UnityEngine.Mathf::Max(V0, V1, X0);\n\tif (TEMP) goto L_005B;\nL_0070:\n\t*([X19+38]) = V0;\nL_0078:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatOperator()
		{
			//IL_00b7: Expected O, but got I
			float value = float1.Value;
			float value2 = float2.Value;
			Operation operation = this.operation;
			bool flag = this.operation < Operation.Max;
			bool flag2 = !flag;
			int num = (int)(this.operation - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25268224 + 2616;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X9_v2 (System.Int32)+v103 @ X8_v3 (HutongGames.PlayMaker.Actions.FloatOperator+Operation)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v102 @ X8_v5 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000C97")]
		[Address(RVA = "0xB76994", Offset = "0xB76994", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatOperator()
		{
		}
	}
}
