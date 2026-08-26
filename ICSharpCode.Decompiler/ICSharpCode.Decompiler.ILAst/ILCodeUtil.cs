using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ICSharpCode.Decompiler.ILAst;

public static class ILCodeUtil
{
	private static object boxedInt32_M1;

	private static object boxedInt32_0;

	private static object boxedInt32_1;

	private static object boxedInt32_2;

	private static object boxedInt32_3;

	private static object boxedInt32_4;

	private static object boxedInt32_5;

	private static object boxedInt32_6;

	private static object boxedInt32_7;

	private static object boxedInt32_8;

	private static object[] boxedSBytes_Int32;

	public static string GetName(this ILCode code)
	{
		return code.ToString().ToLowerInvariant().TrimStart('_')
			.Replace('_', '.');
	}

	public static bool IsConditionalControlFlow(this ILCode code)
	{
		if ((uint)(code - 43) <= 11u || (uint)(code - 56) <= 12u)
		{
			return true;
		}
		return false;
	}

	public static bool IsUnconditionalControlFlow(this ILCode code)
	{
		switch (code)
		{
		case ILCode.Jmp:
		case ILCode.Ret:
		case ILCode.Br_S:
		case ILCode.Br:
		case ILCode.Throw:
		case ILCode.Endfinally:
		case ILCode.Leave:
		case ILCode.Leave_S:
		case ILCode.Endfilter:
		case ILCode.Rethrow:
		case ILCode.LoopOrSwitchBreak:
		case ILCode.LoopContinue:
		case ILCode.YieldBreak:
			return true;
		default:
			return false;
		}
	}

	static ILCodeUtil()
	{
		boxedInt32_M1 = -1;
		boxedInt32_0 = 0;
		boxedInt32_1 = 1;
		boxedInt32_2 = 2;
		boxedInt32_3 = 3;
		boxedInt32_4 = 4;
		boxedInt32_5 = 5;
		boxedInt32_6 = 6;
		boxedInt32_7 = 7;
		boxedInt32_8 = 8;
		boxedSBytes_Int32 = new object[256];
		for (int i = 0; i < 256; i++)
		{
			boxedSBytes_Int32[i] = (int)(sbyte)(i + -128);
		}
	}

	public static void ExpandMacro(ref ILCode code, ref object operand, MethodDef method)
	{
		CilBody body = method.Body;
		switch (code)
		{
		case ILCode.Ldarg_0:
			code = ILCode.Ldarg;
			operand = method.Parameters[0];
			break;
		case ILCode.Ldarg_1:
			code = ILCode.Ldarg;
			operand = method.Parameters[1];
			break;
		case ILCode.Ldarg_2:
			code = ILCode.Ldarg;
			operand = method.Parameters[2];
			break;
		case ILCode.Ldarg_3:
			code = ILCode.Ldarg;
			operand = method.Parameters[3];
			break;
		case ILCode.Ldloc_0:
			code = ILCode.Ldloc;
			operand = body.Variables[0];
			break;
		case ILCode.Ldloc_1:
			code = ILCode.Ldloc;
			operand = body.Variables[1];
			break;
		case ILCode.Ldloc_2:
			code = ILCode.Ldloc;
			operand = body.Variables[2];
			break;
		case ILCode.Ldloc_3:
			code = ILCode.Ldloc;
			operand = body.Variables[3];
			break;
		case ILCode.Stloc_0:
			code = ILCode.Stloc;
			operand = body.Variables[0];
			break;
		case ILCode.Stloc_1:
			code = ILCode.Stloc;
			operand = body.Variables[1];
			break;
		case ILCode.Stloc_2:
			code = ILCode.Stloc;
			operand = body.Variables[2];
			break;
		case ILCode.Stloc_3:
			code = ILCode.Stloc;
			operand = body.Variables[3];
			break;
		case ILCode.Ldarg_S:
			code = ILCode.Ldarg;
			break;
		case ILCode.Ldarga_S:
			code = ILCode.Ldarga;
			break;
		case ILCode.Starg_S:
			code = ILCode.Starg;
			break;
		case ILCode.Ldloc_S:
			code = ILCode.Ldloc;
			break;
		case ILCode.Ldloca_S:
			code = ILCode.Ldloca;
			break;
		case ILCode.Stloc_S:
			code = ILCode.Stloc;
			break;
		case ILCode.Ldc_I4_M1:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_M1;
			break;
		case ILCode.Ldc_I4_0:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_0;
			break;
		case ILCode.Ldc_I4_1:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_1;
			break;
		case ILCode.Ldc_I4_2:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_2;
			break;
		case ILCode.Ldc_I4_3:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_3;
			break;
		case ILCode.Ldc_I4_4:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_4;
			break;
		case ILCode.Ldc_I4_5:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_5;
			break;
		case ILCode.Ldc_I4_6:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_6;
			break;
		case ILCode.Ldc_I4_7:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_7;
			break;
		case ILCode.Ldc_I4_8:
			code = ILCode.Ldc_I4;
			operand = boxedInt32_8;
			break;
		case ILCode.Ldc_I4_S:
			code = ILCode.Ldc_I4;
			operand = boxedSBytes_Int32[(sbyte)operand - -128];
			break;
		case ILCode.Br_S:
			code = ILCode.Br;
			break;
		case ILCode.Brfalse_S:
			code = ILCode.Brfalse;
			break;
		case ILCode.Brtrue_S:
			code = ILCode.Brtrue;
			break;
		case ILCode.Beq_S:
			code = ILCode.Beq;
			break;
		case ILCode.Bge_S:
			code = ILCode.Bge;
			break;
		case ILCode.Bgt_S:
			code = ILCode.Bgt;
			break;
		case ILCode.Ble_S:
			code = ILCode.Ble;
			break;
		case ILCode.Blt_S:
			code = ILCode.Blt;
			break;
		case ILCode.Bne_Un_S:
			code = ILCode.Bne_Un;
			break;
		case ILCode.Bge_Un_S:
			code = ILCode.Bge_Un;
			break;
		case ILCode.Bgt_Un_S:
			code = ILCode.Bgt_Un;
			break;
		case ILCode.Ble_Un_S:
			code = ILCode.Ble_Un;
			break;
		case ILCode.Blt_Un_S:
			code = ILCode.Blt_Un;
			break;
		case ILCode.Leave_S:
			code = ILCode.Leave;
			break;
		case ILCode.Ldind_I:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.IntPtr.TypeDefOrRef;
			break;
		case ILCode.Ldind_I1:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.SByte.TypeDefOrRef;
			break;
		case ILCode.Ldind_I2:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Int16.TypeDefOrRef;
			break;
		case ILCode.Ldind_I4:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Int32.TypeDefOrRef;
			break;
		case ILCode.Ldind_I8:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Int64.TypeDefOrRef;
			break;
		case ILCode.Ldind_U1:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Byte.TypeDefOrRef;
			break;
		case ILCode.Ldind_U2:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.UInt16.TypeDefOrRef;
			break;
		case ILCode.Ldind_U4:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.UInt32.TypeDefOrRef;
			break;
		case ILCode.Ldind_R4:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Single.TypeDefOrRef;
			break;
		case ILCode.Ldind_R8:
			code = ILCode.Ldobj;
			operand = method.Module.CorLibTypes.Double.TypeDefOrRef;
			break;
		case ILCode.Stind_I:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.IntPtr.TypeDefOrRef;
			break;
		case ILCode.Stind_I1:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Byte.TypeDefOrRef;
			break;
		case ILCode.Stind_I2:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Int16.TypeDefOrRef;
			break;
		case ILCode.Stind_I4:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Int32.TypeDefOrRef;
			break;
		case ILCode.Stind_I8:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Int64.TypeDefOrRef;
			break;
		case ILCode.Stind_R4:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Single.TypeDefOrRef;
			break;
		case ILCode.Stind_R8:
			code = ILCode.Stobj;
			operand = method.Module.CorLibTypes.Double.TypeDefOrRef;
			break;
		}
	}
}
