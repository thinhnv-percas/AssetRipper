using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Decompiler.Utils;

public static class StateMachineHelpers
{
	private static readonly UTF8String System_Runtime_CompilerServices = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String IAsyncStateMachine = new UTF8String("IAsyncStateMachine");

	private static readonly UTF8String AsyncStateMachineAttribute = new UTF8String("AsyncStateMachineAttribute");

	private static readonly UTF8String IteratorStateMachineAttribute = new UTF8String("IteratorStateMachineAttribute");

	private static readonly UTF8String stringSystem = new UTF8String("System");

	private static readonly UTF8String stringType = new UTF8String("Type");

	private static readonly UTF8String stringIDisposable = new UTF8String("IDisposable");

	private static readonly UTF8String stringDispose = new UTF8String("Dispose");

	private static readonly UTF8String System_Collections = new UTF8String("System.Collections");

	private static readonly UTF8String System_Collections_Generic = new UTF8String("System.Collections.Generic");

	private static readonly UTF8String IEnumerable = new UTF8String("IEnumerable");

	private static readonly UTF8String IEnumerator = new UTF8String("IEnumerator");

	private static readonly UTF8String IEnumerable_1 = new UTF8String("IEnumerable`1");

	private static readonly UTF8String IEnumerator_1 = new UTF8String("IEnumerator`1");

	private static bool EqualsName(ITypeDefOrRef tdr, UTF8String @namespace, UTF8String name)
	{
		if (tdr is TypeRef typeRef)
		{
			return typeRef.Name == name && typeRef.Namespace == @namespace;
		}
		if (tdr is TypeDef typeDef)
		{
			return typeDef.Name == name && typeDef.Namespace == @namespace;
		}
		return false;
	}

	public static TypeDef GetStateMachineType(MethodDef method)
	{
		TypeDef stateMachineTypeCore = GetStateMachineTypeCore(method);
		if (stateMachineTypeCore == null)
		{
			return null;
		}
		CilBody body = method.Body;
		if (body == null)
		{
			return null;
		}
		foreach (Instruction instruction in body.Instructions)
		{
			if (((instruction.Operand is IMemberDef memberDef) ? memberDef.DeclaringType : null) == stateMachineTypeCore)
			{
				return stateMachineTypeCore;
			}
		}
		return null;
	}

	private static TypeDef GetStateMachineTypeCore(MethodDef method)
	{
		return GetStateMachineTypeFromCustomAttributesCore(method) ?? GetAsyncStateMachineTypeFromInstructionsCore(method) ?? GetIteratorStateMachineTypeFromInstructionsCore(method);
	}

	private static TypeDef GetStateMachineTypeFromCustomAttributesCore(MethodDef method)
	{
		foreach (CustomAttribute customAttribute in method.CustomAttributes)
		{
			if (customAttribute.ConstructorArguments.Count != 1)
			{
				continue;
			}
			ICustomAttributeType constructor = customAttribute.Constructor;
			if (constructor == null || constructor.MethodSig?.Params.Count != 1)
			{
				continue;
			}
			ITypeDefOrRef typeDefOrRef = (customAttribute.Constructor.MethodSig.Params[0] as ClassOrValueTypeSig)?.TypeDefOrRef;
			if (typeDefOrRef == null || !EqualsName(typeDefOrRef, stringSystem, stringType) || !IsStateMachineTypeAttribute(customAttribute.AttributeType))
			{
				continue;
			}
			ITypeDefOrRef typeDefOrRef2 = (customAttribute.ConstructorArguments[0].Value as ClassOrValueTypeSig)?.TypeDefOrRef;
			if (typeDefOrRef2 != null)
			{
				TypeDef typeDef = typeDefOrRef2.Module.Find(typeDefOrRef2);
				if (typeDef?.DeclaringType == method.DeclaringType)
				{
					return typeDef;
				}
			}
		}
		return null;
	}

	private static bool IsStateMachineTypeAttribute(ITypeDefOrRef tdr)
	{
		return EqualsName(tdr, System_Runtime_CompilerServices, AsyncStateMachineAttribute) || EqualsName(tdr, System_Runtime_CompilerServices, IteratorStateMachineAttribute);
	}

	private static TypeDef GetAsyncStateMachineTypeFromInstructionsCore(MethodDef method)
	{
		CilBody body = method.Body;
		if (body == null)
		{
			return null;
		}
		foreach (Local variable in body.Variables)
		{
			if (!(variable.Type.RemovePinnedAndModifiers() is ClassOrValueTypeSig { TypeDef: { } typeDef }) || typeDef.DeclaringType != method.DeclaringType || !ImplementsInterface(typeDef, System_Runtime_CompilerServices, IAsyncStateMachine))
			{
				continue;
			}
			return typeDef;
		}
		return null;
	}

	private static TypeDef GetIteratorStateMachineTypeFromInstructionsCore(MethodDef method)
	{
		if (!IsIteratorReturnType(method.MethodSig.GetRetType().RemovePinnedAndModifiers()))
		{
			return null;
		}
		IList<Instruction> list = method.Body?.Instructions;
		if (list == null)
		{
			return null;
		}
		for (int i = 0; i < list.Count; i++)
		{
			Instruction instruction = list[i];
			if (instruction.OpCode.Code != Code.Newobj || !(instruction.Operand is MethodDef methodDef) || methodDef.DeclaringType.DeclaringType != method.DeclaringType || !ImplementsInterface(methodDef.DeclaringType, stringSystem, stringIDisposable))
			{
				continue;
			}
			MethodDef methodDef2 = FindDispose(methodDef.DeclaringType);
			if (methodDef2 == null)
			{
				continue;
			}
			if (!methodDef2.CustomAttributes.IsDefined("System.Diagnostics.DebuggerHiddenAttribute"))
			{
				string text = methodDef.DeclaringType.Name.String;
				if (!text.StartsWith("<") && !text.StartsWith("VB$StateMachine_"))
				{
					continue;
				}
			}
			return methodDef.DeclaringType;
		}
		return null;
	}

	private static bool IsIteratorReturnType(TypeSig typeSig)
	{
		ITypeDefOrRef typeDefOrRef = (typeSig as ClassSig)?.TypeDefOrRef;
		if (typeDefOrRef == null)
		{
			typeDefOrRef = (typeSig as GenericInstSig)?.GenericType.TypeDefOrRef;
		}
		if (typeDefOrRef == null)
		{
			return false;
		}
		return EqualsName(typeDefOrRef, System_Collections, IEnumerable) || EqualsName(typeDefOrRef, System_Collections, IEnumerator) || EqualsName(typeDefOrRef, System_Collections_Generic, IEnumerable_1) || EqualsName(typeDefOrRef, System_Collections_Generic, IEnumerator_1);
	}

	private static bool ImplementsInterface(TypeDef type, UTF8String @namespace, UTF8String name)
	{
		IList<InterfaceImpl> interfaces = type.Interfaces;
		for (int i = 0; i < interfaces.Count; i++)
		{
			ITypeDefOrRef typeDefOrRef = interfaces[i].Interface;
			if (typeDefOrRef != null && EqualsName(typeDefOrRef, @namespace, name))
			{
				return true;
			}
		}
		return false;
	}

	private static MethodDef FindDispose(TypeDef type)
	{
		foreach (MethodDef method in type.Methods)
		{
			foreach (MethodOverride @override in method.Overrides)
			{
				if (@override.MethodDeclaration.Name != stringDispose || !IsDisposeSig(@override.MethodDeclaration.MethodSig))
				{
					continue;
				}
				return method;
			}
		}
		foreach (MethodDef method2 in type.Methods)
		{
			if (method2.Name != stringDispose || !IsDisposeSig(method2.MethodSig))
			{
				continue;
			}
			return method2;
		}
		return null;
	}

	private static bool IsDisposeSig(MethodSig sig)
	{
		if (sig.GenParamCount != 0)
		{
			return false;
		}
		if (sig.ParamsAfterSentinel != null)
		{
			return false;
		}
		if (sig.Params.Count != 0)
		{
			return false;
		}
		if (sig.RetType.GetElementType() != ElementType.Void)
		{
			return false;
		}
		if (sig.CallingConvention != CallingConvention.HasThis)
		{
			return false;
		}
		return true;
	}

	public static bool TryGetKickoffMethod(MethodDef method, out MethodDef kickoffMethod)
	{
		kickoffMethod = null;
		TypeDef declaringType = method.DeclaringType;
		if (!declaringType.IsNested)
		{
			return false;
		}
		if (ImplementsInterface(declaringType, System_Runtime_CompilerServices, IAsyncStateMachine))
		{
			if (TryGetKickoffMethodFromAttributes(declaringType, out kickoffMethod))
			{
				return true;
			}
			foreach (MethodDef method2 in declaringType.DeclaringType.Methods)
			{
				if (GetAsyncStateMachineTypeFromInstructionsCore(method2) == declaringType)
				{
					kickoffMethod = method2;
					return true;
				}
			}
		}
		else if (ImplementsInterface(declaringType, System_Collections, IEnumerator))
		{
			if (TryGetKickoffMethodFromAttributes(declaringType, out kickoffMethod))
			{
				return true;
			}
			foreach (MethodDef method3 in declaringType.DeclaringType.Methods)
			{
				if (GetIteratorStateMachineTypeFromInstructionsCore(method3) == declaringType)
				{
					kickoffMethod = method3;
					return true;
				}
			}
		}
		return false;
	}

	private static bool TryGetKickoffMethodFromAttributes(TypeDef smType, out MethodDef kickoffMethod)
	{
		foreach (MethodDef method in smType.DeclaringType.Methods)
		{
			if (GetStateMachineTypeFromCustomAttributesCore(method) == smType)
			{
				kickoffMethod = method;
				return true;
			}
		}
		kickoffMethod = null;
		return false;
	}
}
