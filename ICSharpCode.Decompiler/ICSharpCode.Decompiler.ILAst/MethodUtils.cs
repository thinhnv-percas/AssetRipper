using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal static class MethodUtils
{
	private static readonly UTF8String name_get_Current = new UTF8String("get_Current");

	private static readonly UTF8String name_GetEnumerator = new UTF8String("GetEnumerator");

	private static readonly UTF8String name_Dispose = new UTF8String("Dispose");

	private static readonly UTF8String name_MoveNext = new UTF8String("MoveNext");

	private static bool IsMethod(MethodDef method, UTF8String name)
	{
		if (method.Name == name)
		{
			return true;
		}
		foreach (MethodOverride @override in method.Overrides)
		{
			if (@override.MethodDeclaration.Name == name)
			{
				return true;
			}
		}
		return false;
	}

	public static IEnumerable<MethodDef> GetMethod_get_Current(TypeDef type)
	{
		foreach (MethodDef method in type.Methods)
		{
			if (method.IsVirtual && method.MethodSig.GetParamCount() == 0 && IsMethod(method, name_get_Current))
			{
				yield return method;
			}
		}
	}

	public static IEnumerable<MethodDef> GetMethod_GetEnumerator(TypeDef type)
	{
		foreach (MethodDef method in type.Methods)
		{
			if (method.IsVirtual && method.MethodSig.GetParamCount() == 0 && IsMethod(method, name_GetEnumerator))
			{
				yield return method;
			}
		}
	}

	public static IEnumerable<MethodDef> GetMethod_Dispose(TypeDef type)
	{
		foreach (MethodDef method in type.Methods)
		{
			if (method.IsVirtual && method.MethodSig.GetParamCount() == 0 && method.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() == ElementType.Void && IsMethod(method, name_Dispose))
			{
				yield return method;
			}
		}
	}

	public static IEnumerable<MethodDef> GetMethod_MoveNext(TypeDef type)
	{
		foreach (MethodDef method in type.Methods)
		{
			if (method.IsVirtual && method.MethodSig.GetParamCount() == 0 && method.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() == ElementType.Boolean && IsMethod(method, name_MoveNext))
			{
				yield return method;
			}
		}
	}
}
