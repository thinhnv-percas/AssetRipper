namespace DevX.Cecil.Cil
{
	public sealed class OpCodes
	{
		internal static readonly OpCode[] OneByteOpCode = new OpCode[225];

		internal static readonly OpCode[] TwoBytesOpCode = new OpCode[31];

		public static readonly OpCode Nop = new OpCode(byte.MaxValue, 0, Code.Nop, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Break = new OpCode(byte.MaxValue, 1, Code.Break, FlowControl.Break, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Ldarg_0 = new OpCode(byte.MaxValue, 2, Code.Ldarg_0, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldarg_1 = new OpCode(byte.MaxValue, 3, Code.Ldarg_1, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldarg_2 = new OpCode(byte.MaxValue, 4, Code.Ldarg_2, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldarg_3 = new OpCode(byte.MaxValue, 5, Code.Ldarg_3, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloc_0 = new OpCode(byte.MaxValue, 6, Code.Ldloc_0, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloc_1 = new OpCode(byte.MaxValue, 7, Code.Ldloc_1, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloc_2 = new OpCode(byte.MaxValue, 8, Code.Ldloc_2, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloc_3 = new OpCode(byte.MaxValue, 9, Code.Ldloc_3, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Stloc_0 = new OpCode(byte.MaxValue, 10, Code.Stloc_0, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Stloc_1 = new OpCode(byte.MaxValue, 11, Code.Stloc_1, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Stloc_2 = new OpCode(byte.MaxValue, 12, Code.Stloc_2, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Stloc_3 = new OpCode(byte.MaxValue, 13, Code.Stloc_3, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Ldarg_S = new OpCode(byte.MaxValue, 14, Code.Ldarg_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineParam, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldarga_S = new OpCode(byte.MaxValue, 15, Code.Ldarga_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineParam, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Starg_S = new OpCode(byte.MaxValue, 16, Code.Starg_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineParam, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Ldloc_S = new OpCode(byte.MaxValue, 17, Code.Ldloc_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineVar, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloca_S = new OpCode(byte.MaxValue, 18, Code.Ldloca_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineVar, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Stloc_S = new OpCode(byte.MaxValue, 19, Code.Stloc_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineVar, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Ldnull = new OpCode(byte.MaxValue, 20, Code.Ldnull, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushref);

		public static readonly OpCode Ldc_I4_M1 = new OpCode(byte.MaxValue, 21, Code.Ldc_I4_M1, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_0 = new OpCode(byte.MaxValue, 22, Code.Ldc_I4_0, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_1 = new OpCode(byte.MaxValue, 23, Code.Ldc_I4_1, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_2 = new OpCode(byte.MaxValue, 24, Code.Ldc_I4_2, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_3 = new OpCode(byte.MaxValue, 25, Code.Ldc_I4_3, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_4 = new OpCode(byte.MaxValue, 26, Code.Ldc_I4_4, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_5 = new OpCode(byte.MaxValue, 27, Code.Ldc_I4_5, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_6 = new OpCode(byte.MaxValue, 28, Code.Ldc_I4_6, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_7 = new OpCode(byte.MaxValue, 29, Code.Ldc_I4_7, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_8 = new OpCode(byte.MaxValue, 30, Code.Ldc_I4_8, FlowControl.Next, OpCodeType.Macro, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4_S = new OpCode(byte.MaxValue, 31, Code.Ldc_I4_S, FlowControl.Next, OpCodeType.Macro, OperandType.ShortInlineI, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I4 = new OpCode(byte.MaxValue, 32, Code.Ldc_I4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineI, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldc_I8 = new OpCode(byte.MaxValue, 33, Code.Ldc_I8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineI8, StackBehaviour.Pop0, StackBehaviour.Pushi8);

		public static readonly OpCode Ldc_R4 = new OpCode(byte.MaxValue, 34, Code.Ldc_R4, FlowControl.Next, OpCodeType.Primitive, OperandType.ShortInlineR, StackBehaviour.Pop0, StackBehaviour.Pushr4);

		public static readonly OpCode Ldc_R8 = new OpCode(byte.MaxValue, 35, Code.Ldc_R8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineR, StackBehaviour.Pop0, StackBehaviour.Pushr8);

		public static readonly OpCode Dup = new OpCode(byte.MaxValue, 37, Code.Dup, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push1_push1);

		public static readonly OpCode Pop = new OpCode(byte.MaxValue, 38, Code.Pop, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Jmp = new OpCode(byte.MaxValue, 39, Code.Jmp, FlowControl.Call, OpCodeType.Primitive, OperandType.InlineMethod, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Call = new OpCode(byte.MaxValue, 40, Code.Call, FlowControl.Call, OpCodeType.Primitive, OperandType.InlineMethod, StackBehaviour.Varpop, StackBehaviour.Varpush);

		public static readonly OpCode Calli = new OpCode(byte.MaxValue, 41, Code.Calli, FlowControl.Call, OpCodeType.Primitive, OperandType.InlineSig, StackBehaviour.Varpop, StackBehaviour.Varpush);

		public static readonly OpCode Ret = new OpCode(byte.MaxValue, 42, Code.Ret, FlowControl.Return, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Varpop, StackBehaviour.Push0);

		public static readonly OpCode Br_S = new OpCode(byte.MaxValue, 43, Code.Br_S, FlowControl.Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Brfalse_S = new OpCode(byte.MaxValue, 44, Code.Brfalse_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Brtrue_S = new OpCode(byte.MaxValue, 45, Code.Brtrue_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Beq_S = new OpCode(byte.MaxValue, 46, Code.Beq_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bge_S = new OpCode(byte.MaxValue, 47, Code.Bge_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bgt_S = new OpCode(byte.MaxValue, 48, Code.Bgt_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Ble_S = new OpCode(byte.MaxValue, 49, Code.Ble_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Blt_S = new OpCode(byte.MaxValue, 50, Code.Blt_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bne_Un_S = new OpCode(byte.MaxValue, 51, Code.Bne_Un_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bge_Un_S = new OpCode(byte.MaxValue, 52, Code.Bge_Un_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bgt_Un_S = new OpCode(byte.MaxValue, 53, Code.Bgt_Un_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Ble_Un_S = new OpCode(byte.MaxValue, 54, Code.Ble_Un_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Blt_Un_S = new OpCode(byte.MaxValue, 55, Code.Blt_Un_S, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Br = new OpCode(byte.MaxValue, 56, Code.Br, FlowControl.Branch, OpCodeType.Primitive, OperandType.InlineBrTarget, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Brfalse = new OpCode(byte.MaxValue, 57, Code.Brfalse, FlowControl.Cond_Branch, OpCodeType.Primitive, OperandType.InlineBrTarget, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Brtrue = new OpCode(byte.MaxValue, 58, Code.Brtrue, FlowControl.Cond_Branch, OpCodeType.Primitive, OperandType.InlineBrTarget, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Beq = new OpCode(byte.MaxValue, 59, Code.Beq, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bge = new OpCode(byte.MaxValue, 60, Code.Bge, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bgt = new OpCode(byte.MaxValue, 61, Code.Bgt, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Ble = new OpCode(byte.MaxValue, 62, Code.Ble, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Blt = new OpCode(byte.MaxValue, 63, Code.Blt, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bne_Un = new OpCode(byte.MaxValue, 64, Code.Bne_Un, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bge_Un = new OpCode(byte.MaxValue, 65, Code.Bge_Un, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Bgt_Un = new OpCode(byte.MaxValue, 66, Code.Bgt_Un, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Ble_Un = new OpCode(byte.MaxValue, 67, Code.Ble_Un, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Blt_Un = new OpCode(byte.MaxValue, 68, Code.Blt_Un, FlowControl.Cond_Branch, OpCodeType.Macro, OperandType.InlineBrTarget, StackBehaviour.Pop1_pop1, StackBehaviour.Push0);

		public static readonly OpCode Switch = new OpCode(byte.MaxValue, 69, Code.Switch, FlowControl.Cond_Branch, OpCodeType.Primitive, OperandType.InlineSwitch, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Ldind_I1 = new OpCode(byte.MaxValue, 70, Code.Ldind_I1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_U1 = new OpCode(byte.MaxValue, 71, Code.Ldind_U1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_I2 = new OpCode(byte.MaxValue, 72, Code.Ldind_I2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_U2 = new OpCode(byte.MaxValue, 73, Code.Ldind_U2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_I4 = new OpCode(byte.MaxValue, 74, Code.Ldind_I4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_U4 = new OpCode(byte.MaxValue, 75, Code.Ldind_U4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_I8 = new OpCode(byte.MaxValue, 76, Code.Ldind_I8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi8);

		public static readonly OpCode Ldind_I = new OpCode(byte.MaxValue, 77, Code.Ldind_I, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldind_R4 = new OpCode(byte.MaxValue, 78, Code.Ldind_R4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushr4);

		public static readonly OpCode Ldind_R8 = new OpCode(byte.MaxValue, 79, Code.Ldind_R8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushr8);

		public static readonly OpCode Ldind_Ref = new OpCode(byte.MaxValue, 80, Code.Ldind_Ref, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushref);

		public static readonly OpCode Stind_Ref = new OpCode(byte.MaxValue, 81, Code.Stind_Ref, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stind_I1 = new OpCode(byte.MaxValue, 82, Code.Stind_I1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stind_I2 = new OpCode(byte.MaxValue, 83, Code.Stind_I2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stind_I4 = new OpCode(byte.MaxValue, 84, Code.Stind_I4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stind_I8 = new OpCode(byte.MaxValue, 85, Code.Stind_I8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi8, StackBehaviour.Push0);

		public static readonly OpCode Stind_R4 = new OpCode(byte.MaxValue, 86, Code.Stind_R4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popr4, StackBehaviour.Push0);

		public static readonly OpCode Stind_R8 = new OpCode(byte.MaxValue, 87, Code.Stind_R8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popr8, StackBehaviour.Push0);

		public static readonly OpCode Add = new OpCode(byte.MaxValue, 88, Code.Add, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Sub = new OpCode(byte.MaxValue, 89, Code.Sub, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Mul = new OpCode(byte.MaxValue, 90, Code.Mul, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Div = new OpCode(byte.MaxValue, 91, Code.Div, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Div_Un = new OpCode(byte.MaxValue, 92, Code.Div_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Rem = new OpCode(byte.MaxValue, 93, Code.Rem, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Rem_Un = new OpCode(byte.MaxValue, 94, Code.Rem_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode And = new OpCode(byte.MaxValue, 95, Code.And, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Or = new OpCode(byte.MaxValue, 96, Code.Or, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Xor = new OpCode(byte.MaxValue, 97, Code.Xor, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Shl = new OpCode(byte.MaxValue, 98, Code.Shl, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Shr = new OpCode(byte.MaxValue, 99, Code.Shr, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Shr_Un = new OpCode(byte.MaxValue, 100, Code.Shr_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Neg = new OpCode(byte.MaxValue, 101, Code.Neg, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push1);

		public static readonly OpCode Not = new OpCode(byte.MaxValue, 102, Code.Not, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Push1);

		public static readonly OpCode Conv_I1 = new OpCode(byte.MaxValue, 103, Code.Conv_I1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_I2 = new OpCode(byte.MaxValue, 104, Code.Conv_I2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_I4 = new OpCode(byte.MaxValue, 105, Code.Conv_I4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_I8 = new OpCode(byte.MaxValue, 106, Code.Conv_I8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Conv_R4 = new OpCode(byte.MaxValue, 107, Code.Conv_R4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushr4);

		public static readonly OpCode Conv_R8 = new OpCode(byte.MaxValue, 108, Code.Conv_R8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushr8);

		public static readonly OpCode Conv_U4 = new OpCode(byte.MaxValue, 109, Code.Conv_U4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_U8 = new OpCode(byte.MaxValue, 110, Code.Conv_U8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Callvirt = new OpCode(byte.MaxValue, 111, Code.Callvirt, FlowControl.Call, OpCodeType.Objmodel, OperandType.InlineMethod, StackBehaviour.Varpop, StackBehaviour.Varpush);

		public static readonly OpCode Cpobj = new OpCode(byte.MaxValue, 112, Code.Cpobj, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Ldobj = new OpCode(byte.MaxValue, 113, Code.Ldobj, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popi, StackBehaviour.Push1);

		public static readonly OpCode Ldstr = new OpCode(byte.MaxValue, 114, Code.Ldstr, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineString, StackBehaviour.Pop0, StackBehaviour.Pushref);

		public static readonly OpCode Newobj = new OpCode(byte.MaxValue, 115, Code.Newobj, FlowControl.Call, OpCodeType.Objmodel, OperandType.InlineMethod, StackBehaviour.Varpop, StackBehaviour.Pushref);

		public static readonly OpCode Castclass = new OpCode(byte.MaxValue, 116, Code.Castclass, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref, StackBehaviour.Pushref);

		public static readonly OpCode Isinst = new OpCode(byte.MaxValue, 117, Code.Isinst, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref, StackBehaviour.Pushi);

		public static readonly OpCode Conv_R_Un = new OpCode(byte.MaxValue, 118, Code.Conv_R_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushr8);

		public static readonly OpCode Unbox = new OpCode(byte.MaxValue, 121, Code.Unbox, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineType, StackBehaviour.Popref, StackBehaviour.Pushi);

		public static readonly OpCode Throw = new OpCode(byte.MaxValue, 122, Code.Throw, FlowControl.Throw, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref, StackBehaviour.Push0);

		public static readonly OpCode Ldfld = new OpCode(byte.MaxValue, 123, Code.Ldfld, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Popref, StackBehaviour.Push1);

		public static readonly OpCode Ldflda = new OpCode(byte.MaxValue, 124, Code.Ldflda, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Popref, StackBehaviour.Pushi);

		public static readonly OpCode Stfld = new OpCode(byte.MaxValue, 125, Code.Stfld, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Popref_pop1, StackBehaviour.Push0);

		public static readonly OpCode Ldsfld = new OpCode(byte.MaxValue, 126, Code.Ldsfld, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldsflda = new OpCode(byte.MaxValue, 127, Code.Ldsflda, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Stsfld = new OpCode(byte.MaxValue, 128, Code.Stsfld, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineField, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Stobj = new OpCode(byte.MaxValue, 129, Code.Stobj, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popi_pop1, StackBehaviour.Push0);

		public static readonly OpCode Conv_Ovf_I1_Un = new OpCode(byte.MaxValue, 130, Code.Conv_Ovf_I1_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I2_Un = new OpCode(byte.MaxValue, 131, Code.Conv_Ovf_I2_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I4_Un = new OpCode(byte.MaxValue, 132, Code.Conv_Ovf_I4_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I8_Un = new OpCode(byte.MaxValue, 133, Code.Conv_Ovf_I8_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Conv_Ovf_U1_Un = new OpCode(byte.MaxValue, 134, Code.Conv_Ovf_U1_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U2_Un = new OpCode(byte.MaxValue, 135, Code.Conv_Ovf_U2_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U4_Un = new OpCode(byte.MaxValue, 136, Code.Conv_Ovf_U4_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U8_Un = new OpCode(byte.MaxValue, 137, Code.Conv_Ovf_U8_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Conv_Ovf_I_Un = new OpCode(byte.MaxValue, 138, Code.Conv_Ovf_I_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U_Un = new OpCode(byte.MaxValue, 139, Code.Conv_Ovf_U_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Box = new OpCode(byte.MaxValue, 140, Code.Box, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineType, StackBehaviour.Pop1, StackBehaviour.Pushref);

		public static readonly OpCode Newarr = new OpCode(byte.MaxValue, 141, Code.Newarr, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popi, StackBehaviour.Pushref);

		public static readonly OpCode Ldlen = new OpCode(byte.MaxValue, 142, Code.Ldlen, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref, StackBehaviour.Pushi);

		public static readonly OpCode Ldelema = new OpCode(byte.MaxValue, 143, Code.Ldelema, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_I1 = new OpCode(byte.MaxValue, 144, Code.Ldelem_I1, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_U1 = new OpCode(byte.MaxValue, 145, Code.Ldelem_U1, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_I2 = new OpCode(byte.MaxValue, 146, Code.Ldelem_I2, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_U2 = new OpCode(byte.MaxValue, 147, Code.Ldelem_U2, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_I4 = new OpCode(byte.MaxValue, 148, Code.Ldelem_I4, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_U4 = new OpCode(byte.MaxValue, 149, Code.Ldelem_U4, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_I8 = new OpCode(byte.MaxValue, 150, Code.Ldelem_I8, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi8);

		public static readonly OpCode Ldelem_I = new OpCode(byte.MaxValue, 151, Code.Ldelem_I, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushi);

		public static readonly OpCode Ldelem_R4 = new OpCode(byte.MaxValue, 152, Code.Ldelem_R4, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushr4);

		public static readonly OpCode Ldelem_R8 = new OpCode(byte.MaxValue, 153, Code.Ldelem_R8, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushr8);

		public static readonly OpCode Ldelem_Ref = new OpCode(byte.MaxValue, 154, Code.Ldelem_Ref, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi, StackBehaviour.Pushref);

		public static readonly OpCode Stelem_I = new OpCode(byte.MaxValue, 155, Code.Stelem_I, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stelem_I1 = new OpCode(byte.MaxValue, 156, Code.Stelem_I1, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stelem_I2 = new OpCode(byte.MaxValue, 157, Code.Stelem_I2, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stelem_I4 = new OpCode(byte.MaxValue, 158, Code.Stelem_I4, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Stelem_I8 = new OpCode(byte.MaxValue, 159, Code.Stelem_I8, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popi8, StackBehaviour.Push0);

		public static readonly OpCode Stelem_R4 = new OpCode(byte.MaxValue, 160, Code.Stelem_R4, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popr4, StackBehaviour.Push0);

		public static readonly OpCode Stelem_R8 = new OpCode(byte.MaxValue, 161, Code.Stelem_R8, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popr8, StackBehaviour.Push0);

		public static readonly OpCode Stelem_Ref = new OpCode(byte.MaxValue, 162, Code.Stelem_Ref, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Popref_popi_popref, StackBehaviour.Push0);

		public static readonly OpCode Ldelem_Any = new OpCode(byte.MaxValue, 163, Code.Ldelem_Any, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref_popi, StackBehaviour.Push1);

		public static readonly OpCode Stelem_Any = new OpCode(byte.MaxValue, 164, Code.Stelem_Any, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref_popi_popref, StackBehaviour.Push0);

		public static readonly OpCode Unbox_Any = new OpCode(byte.MaxValue, 165, Code.Unbox_Any, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popref, StackBehaviour.Push1);

		public static readonly OpCode Conv_Ovf_I1 = new OpCode(byte.MaxValue, 179, Code.Conv_Ovf_I1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U1 = new OpCode(byte.MaxValue, 180, Code.Conv_Ovf_U1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I2 = new OpCode(byte.MaxValue, 181, Code.Conv_Ovf_I2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U2 = new OpCode(byte.MaxValue, 182, Code.Conv_Ovf_U2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I4 = new OpCode(byte.MaxValue, 183, Code.Conv_Ovf_I4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U4 = new OpCode(byte.MaxValue, 184, Code.Conv_Ovf_U4, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I8 = new OpCode(byte.MaxValue, 185, Code.Conv_Ovf_I8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Conv_Ovf_U8 = new OpCode(byte.MaxValue, 186, Code.Conv_Ovf_U8, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi8);

		public static readonly OpCode Refanyval = new OpCode(byte.MaxValue, 194, Code.Refanyval, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineType, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Ckfinite = new OpCode(byte.MaxValue, 195, Code.Ckfinite, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushr8);

		public static readonly OpCode Mkrefany = new OpCode(byte.MaxValue, 198, Code.Mkrefany, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineType, StackBehaviour.Popi, StackBehaviour.Push1);

		public static readonly OpCode Ldtoken = new OpCode(byte.MaxValue, 208, Code.Ldtoken, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineTok, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Conv_U2 = new OpCode(byte.MaxValue, 209, Code.Conv_U2, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_U1 = new OpCode(byte.MaxValue, 210, Code.Conv_U1, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_I = new OpCode(byte.MaxValue, 211, Code.Conv_I, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_I = new OpCode(byte.MaxValue, 212, Code.Conv_Ovf_I, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Conv_Ovf_U = new OpCode(byte.MaxValue, 213, Code.Conv_Ovf_U, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Add_Ovf = new OpCode(byte.MaxValue, 214, Code.Add_Ovf, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Add_Ovf_Un = new OpCode(byte.MaxValue, 215, Code.Add_Ovf_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Mul_Ovf = new OpCode(byte.MaxValue, 216, Code.Mul_Ovf, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Mul_Ovf_Un = new OpCode(byte.MaxValue, 217, Code.Mul_Ovf_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Sub_Ovf = new OpCode(byte.MaxValue, 218, Code.Sub_Ovf, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Sub_Ovf_Un = new OpCode(byte.MaxValue, 219, Code.Sub_Ovf_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Push1);

		public static readonly OpCode Endfinally = new OpCode(byte.MaxValue, 220, Code.Endfinally, FlowControl.Return, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Leave = new OpCode(byte.MaxValue, 221, Code.Leave, FlowControl.Branch, OpCodeType.Primitive, OperandType.InlineBrTarget, StackBehaviour.PopAll, StackBehaviour.Push0);

		public static readonly OpCode Leave_S = new OpCode(byte.MaxValue, 222, Code.Leave_S, FlowControl.Branch, OpCodeType.Macro, OperandType.ShortInlineBrTarget, StackBehaviour.PopAll, StackBehaviour.Push0);

		public static readonly OpCode Stind_I = new OpCode(byte.MaxValue, 223, Code.Stind_I, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Conv_U = new OpCode(byte.MaxValue, 224, Code.Conv_U, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Arglist = new OpCode(254, 0, Code.Arglist, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ceq = new OpCode(254, 1, Code.Ceq, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Pushi);

		public static readonly OpCode Cgt = new OpCode(254, 2, Code.Cgt, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Pushi);

		public static readonly OpCode Cgt_Un = new OpCode(254, 3, Code.Cgt_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Pushi);

		public static readonly OpCode Clt = new OpCode(254, 4, Code.Clt, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Pushi);

		public static readonly OpCode Clt_Un = new OpCode(254, 5, Code.Clt_Un, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1_pop1, StackBehaviour.Pushi);

		public static readonly OpCode Ldftn = new OpCode(254, 6, Code.Ldftn, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineMethod, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Ldvirtftn = new OpCode(254, 7, Code.Ldvirtftn, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineMethod, StackBehaviour.Popref, StackBehaviour.Pushi);

		public static readonly OpCode Ldarg = new OpCode(254, 9, Code.Ldarg, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineParam, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldarga = new OpCode(254, 10, Code.Ldarga, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineParam, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Starg = new OpCode(254, 11, Code.Starg, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineParam, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Ldloc = new OpCode(254, 12, Code.Ldloc, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineVar, StackBehaviour.Pop0, StackBehaviour.Push1);

		public static readonly OpCode Ldloca = new OpCode(254, 13, Code.Ldloca, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineVar, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Stloc = new OpCode(254, 14, Code.Stloc, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineVar, StackBehaviour.Pop1, StackBehaviour.Push0);

		public static readonly OpCode Localloc = new OpCode(254, 15, Code.Localloc, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Pushi);

		public static readonly OpCode Endfilter = new OpCode(254, 17, Code.Endfilter, FlowControl.Return, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Unaligned = new OpCode(254, 18, Code.Unaligned, FlowControl.Meta, OpCodeType.Prefix, OperandType.ShortInlineI, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Volatile = new OpCode(254, 19, Code.Volatile, FlowControl.Meta, OpCodeType.Prefix, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Tail = new OpCode(254, 20, Code.Tail, FlowControl.Meta, OpCodeType.Prefix, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Initobj = new OpCode(254, 21, Code.Initobj, FlowControl.Next, OpCodeType.Objmodel, OperandType.InlineType, StackBehaviour.Popi, StackBehaviour.Push0);

		public static readonly OpCode Constrained = new OpCode(254, 22, Code.Constrained, FlowControl.Next, OpCodeType.Prefix, OperandType.InlineType, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Cpblk = new OpCode(254, 23, Code.Cpblk, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode Initblk = new OpCode(254, 24, Code.Initblk, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Popi_popi_popi, StackBehaviour.Push0);

		public static readonly OpCode No = new OpCode(254, 25, Code.No, FlowControl.Next, OpCodeType.Prefix, OperandType.ShortInlineI, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Rethrow = new OpCode(254, 26, Code.Rethrow, FlowControl.Throw, OpCodeType.Objmodel, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		public static readonly OpCode Sizeof = new OpCode(254, 28, Code.Sizeof, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineType, StackBehaviour.Pop0, StackBehaviour.Pushi);

		public static readonly OpCode Refanytype = new OpCode(254, 29, Code.Refanytype, FlowControl.Next, OpCodeType.Primitive, OperandType.InlineNone, StackBehaviour.Pop1, StackBehaviour.Pushi);

		public static readonly OpCode Readonly = new OpCode(254, 30, Code.Readonly, FlowControl.Next, OpCodeType.Prefix, OperandType.InlineNone, StackBehaviour.Pop0, StackBehaviour.Push0);

		private OpCodes()
		{
		}

		public static OpCode GetOpCode(Code code)
		{
			switch (code)
			{
			case Code.Nop:
				return Nop;
			case Code.Break:
				return Break;
			case Code.Ldarg_0:
				return Ldarg_0;
			case Code.Ldarg_1:
				return Ldarg_1;
			case Code.Ldarg_2:
				return Ldarg_2;
			case Code.Ldarg_3:
				return Ldarg_3;
			case Code.Ldloc_0:
				return Ldloc_0;
			case Code.Ldloc_1:
				return Ldloc_1;
			case Code.Ldloc_2:
				return Ldloc_2;
			case Code.Ldloc_3:
				return Ldloc_3;
			case Code.Stloc_0:
				return Stloc_0;
			case Code.Stloc_1:
				return Stloc_1;
			case Code.Stloc_2:
				return Stloc_2;
			case Code.Stloc_3:
				return Stloc_3;
			case Code.Ldarg_S:
				return Ldarg_S;
			case Code.Ldarga_S:
				return Ldarga_S;
			case Code.Starg_S:
				return Starg_S;
			case Code.Ldloc_S:
				return Ldloc_S;
			case Code.Ldloca_S:
				return Ldloca_S;
			case Code.Stloc_S:
				return Stloc_S;
			case Code.Ldnull:
				return Ldnull;
			case Code.Ldc_I4_M1:
				return Ldc_I4_M1;
			case Code.Ldc_I4_0:
				return Ldc_I4_0;
			case Code.Ldc_I4_1:
				return Ldc_I4_1;
			case Code.Ldc_I4_2:
				return Ldc_I4_2;
			case Code.Ldc_I4_3:
				return Ldc_I4_3;
			case Code.Ldc_I4_4:
				return Ldc_I4_4;
			case Code.Ldc_I4_5:
				return Ldc_I4_5;
			case Code.Ldc_I4_6:
				return Ldc_I4_6;
			case Code.Ldc_I4_7:
				return Ldc_I4_7;
			case Code.Ldc_I4_8:
				return Ldc_I4_8;
			case Code.Ldc_I4_S:
				return Ldc_I4_S;
			case Code.Ldc_I4:
				return Ldc_I4;
			case Code.Ldc_I8:
				return Ldc_I8;
			case Code.Ldc_R4:
				return Ldc_R4;
			case Code.Ldc_R8:
				return Ldc_R8;
			case Code.Dup:
				return Dup;
			case Code.Pop:
				return Pop;
			case Code.Jmp:
				return Jmp;
			case Code.Call:
				return Call;
			case Code.Calli:
				return Calli;
			case Code.Ret:
				return Ret;
			case Code.Br_S:
				return Br_S;
			case Code.Brfalse_S:
				return Brfalse_S;
			case Code.Brtrue_S:
				return Brtrue_S;
			case Code.Beq_S:
				return Beq_S;
			case Code.Bge_S:
				return Bge_S;
			case Code.Bgt_S:
				return Bgt_S;
			case Code.Ble_S:
				return Ble_S;
			case Code.Blt_S:
				return Blt_S;
			case Code.Bne_Un_S:
				return Bne_Un_S;
			case Code.Bge_Un_S:
				return Bge_Un_S;
			case Code.Bgt_Un_S:
				return Bgt_Un_S;
			case Code.Ble_Un_S:
				return Ble_Un_S;
			case Code.Blt_Un_S:
				return Blt_Un_S;
			case Code.Br:
				return Br;
			case Code.Brfalse:
				return Brfalse;
			case Code.Brtrue:
				return Brtrue;
			case Code.Beq:
				return Beq;
			case Code.Bge:
				return Bge;
			case Code.Bgt:
				return Bgt;
			case Code.Ble:
				return Ble;
			case Code.Blt:
				return Blt;
			case Code.Bne_Un:
				return Bne_Un;
			case Code.Bge_Un:
				return Bge_Un;
			case Code.Bgt_Un:
				return Bgt_Un;
			case Code.Ble_Un:
				return Ble_Un;
			case Code.Blt_Un:
				return Blt_Un;
			case Code.Switch:
				return Switch;
			case Code.Ldind_I1:
				return Ldind_I1;
			case Code.Ldind_U1:
				return Ldind_U1;
			case Code.Ldind_I2:
				return Ldind_I2;
			case Code.Ldind_U2:
				return Ldind_U2;
			case Code.Ldind_I4:
				return Ldind_I4;
			case Code.Ldind_U4:
				return Ldind_U4;
			case Code.Ldind_I8:
				return Ldind_I8;
			case Code.Ldind_I:
				return Ldind_I;
			case Code.Ldind_R4:
				return Ldind_R4;
			case Code.Ldind_R8:
				return Ldind_R8;
			case Code.Ldind_Ref:
				return Ldind_Ref;
			case Code.Stind_Ref:
				return Stind_Ref;
			case Code.Stind_I1:
				return Stind_I1;
			case Code.Stind_I2:
				return Stind_I2;
			case Code.Stind_I4:
				return Stind_I4;
			case Code.Stind_I8:
				return Stind_I8;
			case Code.Stind_R4:
				return Stind_R4;
			case Code.Stind_R8:
				return Stind_R8;
			case Code.Add:
				return Add;
			case Code.Sub:
				return Sub;
			case Code.Mul:
				return Mul;
			case Code.Div:
				return Div;
			case Code.Div_Un:
				return Div_Un;
			case Code.Rem:
				return Rem;
			case Code.Rem_Un:
				return Rem_Un;
			case Code.And:
				return And;
			case Code.Or:
				return Or;
			case Code.Xor:
				return Xor;
			case Code.Shl:
				return Shl;
			case Code.Shr:
				return Shr;
			case Code.Shr_Un:
				return Shr_Un;
			case Code.Neg:
				return Neg;
			case Code.Not:
				return Not;
			case Code.Conv_I1:
				return Conv_I1;
			case Code.Conv_I2:
				return Conv_I2;
			case Code.Conv_I4:
				return Conv_I4;
			case Code.Conv_I8:
				return Conv_I8;
			case Code.Conv_R4:
				return Conv_R4;
			case Code.Conv_R8:
				return Conv_R8;
			case Code.Conv_U4:
				return Conv_U4;
			case Code.Conv_U8:
				return Conv_U8;
			case Code.Callvirt:
				return Callvirt;
			case Code.Cpobj:
				return Cpobj;
			case Code.Ldobj:
				return Ldobj;
			case Code.Ldstr:
				return Ldstr;
			case Code.Newobj:
				return Newobj;
			case Code.Castclass:
				return Castclass;
			case Code.Isinst:
				return Isinst;
			case Code.Conv_R_Un:
				return Conv_R_Un;
			case Code.Unbox:
				return Unbox;
			case Code.Throw:
				return Throw;
			case Code.Ldfld:
				return Ldfld;
			case Code.Ldflda:
				return Ldflda;
			case Code.Stfld:
				return Stfld;
			case Code.Ldsfld:
				return Ldsfld;
			case Code.Ldsflda:
				return Ldsflda;
			case Code.Stsfld:
				return Stsfld;
			case Code.Stobj:
				return Stobj;
			case Code.Conv_Ovf_I1_Un:
				return Conv_Ovf_I1_Un;
			case Code.Conv_Ovf_I2_Un:
				return Conv_Ovf_I2_Un;
			case Code.Conv_Ovf_I4_Un:
				return Conv_Ovf_I4_Un;
			case Code.Conv_Ovf_I8_Un:
				return Conv_Ovf_I8_Un;
			case Code.Conv_Ovf_U1_Un:
				return Conv_Ovf_U1_Un;
			case Code.Conv_Ovf_U2_Un:
				return Conv_Ovf_U2_Un;
			case Code.Conv_Ovf_U4_Un:
				return Conv_Ovf_U4_Un;
			case Code.Conv_Ovf_U8_Un:
				return Conv_Ovf_U8_Un;
			case Code.Conv_Ovf_I_Un:
				return Conv_Ovf_I_Un;
			case Code.Conv_Ovf_U_Un:
				return Conv_Ovf_U_Un;
			case Code.Box:
				return Box;
			case Code.Newarr:
				return Newarr;
			case Code.Ldlen:
				return Ldlen;
			case Code.Ldelema:
				return Ldelema;
			case Code.Ldelem_I1:
				return Ldelem_I1;
			case Code.Ldelem_U1:
				return Ldelem_U1;
			case Code.Ldelem_I2:
				return Ldelem_I2;
			case Code.Ldelem_U2:
				return Ldelem_U2;
			case Code.Ldelem_I4:
				return Ldelem_I4;
			case Code.Ldelem_U4:
				return Ldelem_U4;
			case Code.Ldelem_I8:
				return Ldelem_I8;
			case Code.Ldelem_I:
				return Ldelem_I;
			case Code.Ldelem_R4:
				return Ldelem_R4;
			case Code.Ldelem_R8:
				return Ldelem_R8;
			case Code.Ldelem_Ref:
				return Ldelem_Ref;
			case Code.Stelem_I:
				return Stelem_I;
			case Code.Stelem_I1:
				return Stelem_I1;
			case Code.Stelem_I2:
				return Stelem_I2;
			case Code.Stelem_I4:
				return Stelem_I4;
			case Code.Stelem_I8:
				return Stelem_I8;
			case Code.Stelem_R4:
				return Stelem_R4;
			case Code.Stelem_R8:
				return Stelem_R8;
			case Code.Stelem_Ref:
				return Stelem_Ref;
			case Code.Ldelem_Any:
				return Ldelem_Any;
			case Code.Stelem_Any:
				return Stelem_Any;
			case Code.Unbox_Any:
				return Unbox_Any;
			case Code.Conv_Ovf_I1:
				return Conv_Ovf_I1;
			case Code.Conv_Ovf_U1:
				return Conv_Ovf_U1;
			case Code.Conv_Ovf_I2:
				return Conv_Ovf_I2;
			case Code.Conv_Ovf_U2:
				return Conv_Ovf_U2;
			case Code.Conv_Ovf_I4:
				return Conv_Ovf_I4;
			case Code.Conv_Ovf_U4:
				return Conv_Ovf_U4;
			case Code.Conv_Ovf_I8:
				return Conv_Ovf_I8;
			case Code.Conv_Ovf_U8:
				return Conv_Ovf_U8;
			case Code.Refanyval:
				return Refanyval;
			case Code.Ckfinite:
				return Ckfinite;
			case Code.Mkrefany:
				return Mkrefany;
			case Code.Ldtoken:
				return Ldtoken;
			case Code.Conv_U2:
				return Conv_U2;
			case Code.Conv_U1:
				return Conv_U1;
			case Code.Conv_I:
				return Conv_I;
			case Code.Conv_Ovf_I:
				return Conv_Ovf_I;
			case Code.Conv_Ovf_U:
				return Conv_Ovf_U;
			case Code.Add_Ovf:
				return Add_Ovf;
			case Code.Add_Ovf_Un:
				return Add_Ovf_Un;
			case Code.Mul_Ovf:
				return Mul_Ovf;
			case Code.Mul_Ovf_Un:
				return Mul_Ovf_Un;
			case Code.Sub_Ovf:
				return Sub_Ovf;
			case Code.Sub_Ovf_Un:
				return Sub_Ovf_Un;
			case Code.Endfinally:
				return Endfinally;
			case Code.Leave:
				return Leave;
			case Code.Leave_S:
				return Leave_S;
			case Code.Stind_I:
				return Stind_I;
			case Code.Conv_U:
				return Conv_U;
			case Code.Arglist:
				return Arglist;
			case Code.Ceq:
				return Ceq;
			case Code.Cgt:
				return Cgt;
			case Code.Cgt_Un:
				return Cgt_Un;
			case Code.Clt:
				return Clt;
			case Code.Clt_Un:
				return Clt_Un;
			case Code.Ldftn:
				return Ldftn;
			case Code.Ldvirtftn:
				return Ldvirtftn;
			case Code.Ldarg:
				return Ldarg;
			case Code.Ldarga:
				return Ldarga;
			case Code.Starg:
				return Starg;
			case Code.Ldloc:
				return Ldloc;
			case Code.Ldloca:
				return Ldloca;
			case Code.Stloc:
				return Stloc;
			case Code.Localloc:
				return Localloc;
			case Code.Endfilter:
				return Endfilter;
			case Code.Unaligned:
				return Unaligned;
			case Code.Volatile:
				return Volatile;
			case Code.Tail:
				return Tail;
			case Code.Initobj:
				return Initobj;
			case Code.Constrained:
				return Constrained;
			case Code.Cpblk:
				return Cpblk;
			case Code.Initblk:
				return Initblk;
			case Code.No:
				return No;
			case Code.Rethrow:
				return Rethrow;
			case Code.Sizeof:
				return Sizeof;
			case Code.Refanytype:
				return Refanytype;
			case Code.Readonly:
				return Readonly;
			default:
				return Nop;
			}
		}
	}
}
