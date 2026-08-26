using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	public static class ILCodeUtil
	{
		public static string GetName(this ILCode code)
		{
			return code.ToString().ToLowerInvariant().TrimStart('_')
				.Replace('_', '.');
		}

		public static bool IsConditionalControlFlow(this ILCode code)
		{
			switch (code)
			{
			case ILCode.__Brfalse_S:
			case ILCode.__Brtrue_S:
			case ILCode.__Beq_S:
			case ILCode.__Bge_S:
			case ILCode.__Bgt_S:
			case ILCode.__Ble_S:
			case ILCode.__Blt_S:
			case ILCode.__Bne_Un_S:
			case ILCode.__Bge_Un_S:
			case ILCode.__Bgt_Un_S:
			case ILCode.__Ble_Un_S:
			case ILCode.__Blt_Un_S:
			case ILCode.__Brfalse:
			case ILCode.Brtrue:
			case ILCode.__Beq:
			case ILCode.__Bge:
			case ILCode.__Bgt:
			case ILCode.__Ble:
			case ILCode.__Blt:
			case ILCode.__Bne_Un:
			case ILCode.__Bge_Un:
			case ILCode.__Bgt_Un:
			case ILCode.__Ble_Un:
			case ILCode.__Blt_Un:
			case ILCode.Switch:
				return true;
			default:
				return false;
			}
		}

		public static bool IsUnconditionalControlFlow(this ILCode code)
		{
			switch (code)
			{
			case ILCode.Ret:
			case ILCode.__Br_S:
			case ILCode.Br:
			case ILCode.Throw:
			case ILCode.Endfinally:
			case ILCode.Leave:
			case ILCode.__Leave_S:
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

		public static void ExpandMacro(ref ILCode code, ref object operand, MethodBody methodBody)
		{
			switch (code)
			{
			case ILCode.__Ldarg_0:
				code = ILCode.__Ldarg;
				operand = methodBody.GetParameter(0);
				break;
			case ILCode.__Ldarg_1:
				code = ILCode.__Ldarg;
				operand = methodBody.GetParameter(1);
				break;
			case ILCode.__Ldarg_2:
				code = ILCode.__Ldarg;
				operand = methodBody.GetParameter(2);
				break;
			case ILCode.__Ldarg_3:
				code = ILCode.__Ldarg;
				operand = methodBody.GetParameter(3);
				break;
			case ILCode.__Ldloc_0:
				code = ILCode.Ldloc;
				operand = methodBody.Variables[0];
				break;
			case ILCode.__Ldloc_1:
				code = ILCode.Ldloc;
				operand = methodBody.Variables[1];
				break;
			case ILCode.__Ldloc_2:
				code = ILCode.Ldloc;
				operand = methodBody.Variables[2];
				break;
			case ILCode.__Ldloc_3:
				code = ILCode.Ldloc;
				operand = methodBody.Variables[3];
				break;
			case ILCode.__Stloc_0:
				code = ILCode.Stloc;
				operand = methodBody.Variables[0];
				break;
			case ILCode.__Stloc_1:
				code = ILCode.Stloc;
				operand = methodBody.Variables[1];
				break;
			case ILCode.__Stloc_2:
				code = ILCode.Stloc;
				operand = methodBody.Variables[2];
				break;
			case ILCode.__Stloc_3:
				code = ILCode.Stloc;
				operand = methodBody.Variables[3];
				break;
			case ILCode.__Ldarg_S:
				code = ILCode.__Ldarg;
				break;
			case ILCode.__Ldarga_S:
				code = ILCode.__Ldarga;
				break;
			case ILCode.__Starg_S:
				code = ILCode.__Starg;
				break;
			case ILCode.__Ldloc_S:
				code = ILCode.Ldloc;
				break;
			case ILCode.__Ldloca_S:
				code = ILCode.Ldloca;
				break;
			case ILCode.__Stloc_S:
				code = ILCode.Stloc;
				break;
			case ILCode.__Ldc_I4_M1:
				code = ILCode.Ldc_I4;
				operand = -1;
				break;
			case ILCode.__Ldc_I4_0:
				code = ILCode.Ldc_I4;
				operand = 0;
				break;
			case ILCode.__Ldc_I4_1:
				code = ILCode.Ldc_I4;
				operand = 1;
				break;
			case ILCode.__Ldc_I4_2:
				code = ILCode.Ldc_I4;
				operand = 2;
				break;
			case ILCode.__Ldc_I4_3:
				code = ILCode.Ldc_I4;
				operand = 3;
				break;
			case ILCode.__Ldc_I4_4:
				code = ILCode.Ldc_I4;
				operand = 4;
				break;
			case ILCode.__Ldc_I4_5:
				code = ILCode.Ldc_I4;
				operand = 5;
				break;
			case ILCode.__Ldc_I4_6:
				code = ILCode.Ldc_I4;
				operand = 6;
				break;
			case ILCode.__Ldc_I4_7:
				code = ILCode.Ldc_I4;
				operand = 7;
				break;
			case ILCode.__Ldc_I4_8:
				code = ILCode.Ldc_I4;
				operand = 8;
				break;
			case ILCode.__Ldc_I4_S:
				code = ILCode.Ldc_I4;
				operand = (int)(sbyte)operand;
				break;
			case ILCode.__Br_S:
				code = ILCode.Br;
				break;
			case ILCode.__Brfalse_S:
				code = ILCode.__Brfalse;
				break;
			case ILCode.__Brtrue_S:
				code = ILCode.Brtrue;
				break;
			case ILCode.__Beq_S:
				code = ILCode.__Beq;
				break;
			case ILCode.__Bge_S:
				code = ILCode.__Bge;
				break;
			case ILCode.__Bgt_S:
				code = ILCode.__Bgt;
				break;
			case ILCode.__Ble_S:
				code = ILCode.__Ble;
				break;
			case ILCode.__Blt_S:
				code = ILCode.__Blt;
				break;
			case ILCode.__Bne_Un_S:
				code = ILCode.__Bne_Un;
				break;
			case ILCode.__Bge_Un_S:
				code = ILCode.__Bge_Un;
				break;
			case ILCode.__Bgt_Un_S:
				code = ILCode.__Bgt_Un;
				break;
			case ILCode.__Ble_Un_S:
				code = ILCode.__Ble_Un;
				break;
			case ILCode.__Blt_Un_S:
				code = ILCode.__Blt_Un;
				break;
			case ILCode.__Leave_S:
				code = ILCode.Leave;
				break;
			case ILCode.__Ldind_I:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.IntPtr;
				break;
			case ILCode.__Ldind_I1:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.SByte;
				break;
			case ILCode.__Ldind_I2:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Int16;
				break;
			case ILCode.__Ldind_I4:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Int32;
				break;
			case ILCode.__Ldind_I8:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Int64;
				break;
			case ILCode.__Ldind_U1:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Byte;
				break;
			case ILCode.__Ldind_U2:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.UInt16;
				break;
			case ILCode.__Ldind_U4:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.UInt32;
				break;
			case ILCode.__Ldind_R4:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Single;
				break;
			case ILCode.__Ldind_R8:
				code = ILCode.Ldobj;
				operand = methodBody.Method.Module.TypeSystem.Double;
				break;
			case ILCode.__Stind_I:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.IntPtr;
				break;
			case ILCode.__Stind_I1:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Byte;
				break;
			case ILCode.__Stind_I2:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Int16;
				break;
			case ILCode.__Stind_I4:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Int32;
				break;
			case ILCode.__Stind_I8:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Int64;
				break;
			case ILCode.__Stind_R4:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Single;
				break;
			case ILCode.__Stind_R8:
				code = ILCode.Stobj;
				operand = methodBody.Method.Module.TypeSystem.Double;
				break;
			}
		}

		public static ParameterDefinition GetParameter(this MethodBody self, int index)
		{
			MethodDefinition method = self.Method;
			if (method.HasThis)
			{
				if (index == 0)
				{
					return self.ThisParameter;
				}
				index--;
			}
			Collection<ParameterDefinition> parameters = method.Parameters;
			if (index < 0 || index >= parameters.Count)
			{
				return null;
			}
			return parameters[index];
		}
	}
}
