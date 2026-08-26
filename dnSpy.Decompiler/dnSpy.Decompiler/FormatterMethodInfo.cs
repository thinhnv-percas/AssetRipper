using System.Collections.Generic;
using dnlib.DotNet;

namespace dnSpy.Decompiler;

internal readonly struct FormatterMethodInfo
{
	public readonly ModuleDef ModuleDef;

	public readonly IList<TypeSig> TypeGenericParams;

	public readonly IList<TypeSig> MethodGenericParams;

	public readonly MethodDef MethodDef;

	public readonly MethodSig MethodSig;

	public readonly bool RetTypeIsLastArgType;

	public readonly bool IncludeReturnTypeInArgsList;

	public FormatterMethodInfo(IMethod method, bool retTypeIsLastArgType = false, bool includeReturnTypeInArgsList = false)
	{
		ModuleDef = method.Module;
		TypeGenericParams = null;
		MethodGenericParams = null;
		MethodSig = method.MethodSig ?? new MethodSig(CallingConvention.Default);
		RetTypeIsLastArgType = retTypeIsLastArgType;
		IncludeReturnTypeInArgsList = includeReturnTypeInArgsList;
		MethodDef = method as MethodDef;
		MethodSpec methodSpec = method as MethodSpec;
		MemberRef memberRef = method as MemberRef;
		if (methodSpec != null)
		{
			TypeSpec typeSpec = ((methodSpec.Method == null) ? null : (methodSpec.Method.DeclaringType as TypeSpec));
			if (typeSpec != null && typeSpec.TypeSig.RemovePinnedAndModifiers() is GenericInstSig genericInstSig)
			{
				TypeGenericParams = genericInstSig.GenericArguments;
			}
			GenericInstMethodSig genericInstMethodSig = methodSpec.GenericInstMethodSig;
			if (genericInstMethodSig != null)
			{
				MethodGenericParams = genericInstMethodSig.GenericArguments;
			}
			MethodDef = methodSpec.Method.ResolveMethodDef();
		}
		else if (memberRef != null)
		{
			if (memberRef.DeclaringType is TypeSpec typeSpec2 && typeSpec2.TypeSig.RemovePinnedAndModifiers() is GenericInstSig genericInstSig2)
			{
				TypeGenericParams = genericInstSig2.GenericArguments;
			}
			MethodDef = memberRef.ResolveMethod();
		}
	}
}
