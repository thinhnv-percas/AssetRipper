using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ICSharpCode.Decompiler.ILAst;

internal static class BaseMethodWrapperFixer
{
	public static void FixBaseCalls(TypeDef type, ILBlock block, List<ILExpression> listExpr)
	{
		foreach (ILExpression item in block.GetSelfAndChildrenRecursive(listExpr))
		{
			ILCode code = item.Code;
			if (code != ILCode.Call && code != ILCode.Callvirt && (uint)(code - 247) > 4u)
			{
				continue;
			}
			MethodDef methodDef = (item.Operand as IMethod).ResolveMethodWithinSameModule();
			if (methodDef?.DeclaringType == type && TryGetBaseMethod(methodDef, out var realMethod))
			{
				item.Operand = realMethod;
				switch (item.Code)
				{
				case ILCode.Callvirt:
					item.Code = ILCode.Call;
					break;
				case ILCode.CallvirtGetter:
					item.Code = ILCode.CallGetter;
					break;
				case ILCode.CallvirtSetter:
					item.Code = ILCode.CallSetter;
					break;
				}
			}
		}
	}

	private static bool TryGetBaseMethod(MethodDef method, out IMethod realMethod)
	{
		realMethod = null;
		if (method == null)
		{
			return false;
		}
		if (!IsBaseWrapperMethod(method))
		{
			return false;
		}
		return IsBaseWrapperMethodBody(method.Body, out realMethod);
	}

	private static bool IsBaseWrapperMethodBody(CilBody body, out IMethod calledMethod)
	{
		calledMethod = null;
		if (body == null)
		{
			return false;
		}
		IList<Instruction> instructions = body.Instructions;
		if (instructions.Count < 2)
		{
			return false;
		}
		Instruction instruction = instructions[instructions.Count - 2];
		Instruction instruction2 = instructions[instructions.Count - 1];
		if (instruction2.OpCode.Code != Code.Ret)
		{
			return false;
		}
		if (instruction.OpCode.Code != Code.Call)
		{
			return false;
		}
		calledMethod = instruction.Operand as IMethod;
		return calledMethod != null;
	}

	private static bool IsBaseWrapperMethod(MethodDef method)
	{
		if (!method.IsPrivate || method.IsStatic || method.IsAbstract || method.IsVirtual)
		{
			return false;
		}
		string text = UTF8String.ToSystemStringOrEmpty(method.Name);
		if (text.Length == 0)
		{
			return false;
		}
		bool flag = false;
		switch (text[0])
		{
		case '<':
			if (text.StartsWith("<>n__", StringComparison.Ordinal))
			{
				flag = true;
			}
			else if (text.IndexOf(">__BaseCallProxy", StringComparison.Ordinal) >= 0)
			{
				flag = true;
			}
			break;
		case '$':
			if (text.StartsWith("$VB$ClosureStub_", StringComparison.Ordinal) && text.EndsWith("_MyBase", StringComparison.Ordinal))
			{
				flag = true;
			}
			break;
		}
		if (!flag)
		{
			return false;
		}
		return method.CustomAttributes.IsDefined("System.Runtime.CompilerServices.CompilerGeneratedAttribute");
	}
}
