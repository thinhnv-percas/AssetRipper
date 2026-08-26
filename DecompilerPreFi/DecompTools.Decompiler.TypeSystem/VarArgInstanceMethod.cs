#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public class VarArgInstanceMethod : IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly IMethod baseMethod;

	private readonly IParameter[] parameters;

	public IMethod BaseMethod => baseMethod;

	public int RegularParameterCount => checked(baseMethod.Parameters.Count - 1);

	public IReadOnlyList<IParameter> Parameters => parameters;

	public IReadOnlyList<ITypeParameter> TypeParameters => baseMethod.TypeParameters;

	public IReadOnlyList<IType> TypeArguments => baseMethod.TypeArguments;

	public EntityHandle MetadataToken => baseMethod.MetadataToken;

	public bool IsExtensionMethod => baseMethod.IsExtensionMethod;

	public bool IsConstructor => baseMethod.IsConstructor;

	public bool IsDestructor => baseMethod.IsDestructor;

	public bool IsOperator => baseMethod.IsOperator;

	public bool HasBody => baseMethod.HasBody;

	public bool IsAccessor => baseMethod.IsAccessor;

	public IMember AccessorOwner => baseMethod.AccessorOwner;

	public IMethod ReducedFrom => baseMethod.ReducedFrom;

	public IMember MemberDefinition => baseMethod.MemberDefinition;

	public IType ReturnType => baseMethod.ReturnType;

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers => baseMethod.ExplicitlyImplementedInterfaceMembers;

	public bool IsExplicitInterfaceImplementation => baseMethod.IsExplicitInterfaceImplementation;

	public bool IsVirtual => baseMethod.IsVirtual;

	public bool IsOverride => baseMethod.IsOverride;

	public bool IsOverridable => baseMethod.IsOverridable;

	public TypeParameterSubstitution Substitution => baseMethod.Substitution;

	public SymbolKind SymbolKind => baseMethod.SymbolKind;

	public string Name => baseMethod.Name;

	public ITypeDefinition DeclaringTypeDefinition => baseMethod.DeclaringTypeDefinition;

	public IType DeclaringType => baseMethod.DeclaringType;

	public IModule ParentModule => baseMethod.ParentModule;

	public bool IsStatic => baseMethod.IsStatic;

	public bool IsAbstract => baseMethod.IsAbstract;

	public bool IsSealed => baseMethod.IsSealed;

	public Accessibility Accessibility => baseMethod.Accessibility;

	public string FullName => baseMethod.FullName;

	public string ReflectionName => baseMethod.ReflectionName;

	public string Namespace => baseMethod.Namespace;

	public ICompilation Compilation => baseMethod.Compilation;

	public VarArgInstanceMethod(IMethod baseMethod, IEnumerable<IType> varArgTypes)
	{
		this.baseMethod = baseMethod;
		List<IParameter> list = new List<IParameter>(baseMethod.Parameters);
		Debug.Assert(Enumerable.Last<IParameter>((IEnumerable<IParameter>)list).Type.Kind == TypeKind.ArgList);
		list.RemoveAt(checked(list.Count - 1));
		foreach (IType varArgType in varArgTypes)
		{
			list.Add(new DefaultParameter(varArgType, string.Empty, this));
		}
		parameters = list.ToArray();
	}

	public override bool Equals(object obj)
	{
		return obj is VarArgInstanceMethod varArgInstanceMethod && baseMethod.Equals(varArgInstanceMethod.baseMethod);
	}

	public override int GetHashCode()
	{
		return baseMethod.GetHashCode();
	}

	public bool Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return obj is VarArgInstanceMethod varArgInstanceMethod && baseMethod.Equals(varArgInstanceMethod.baseMethod, typeNormalization);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(SymbolKind);
		if (DeclaringType != null)
		{
			stringBuilder.Append(DeclaringType.ReflectionName);
			stringBuilder.Append('.');
		}
		stringBuilder.Append(Name);
		if (TypeParameters.Count > 0)
		{
			stringBuilder.Append("``");
			stringBuilder.Append(TypeParameters.Count);
		}
		stringBuilder.Append('(');
		for (int i = 0; i < Parameters.Count; i = checked(i + 1))
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			if (i == RegularParameterCount)
			{
				stringBuilder.Append("..., ");
			}
			stringBuilder.Append(Parameters[i].Type.ReflectionName);
		}
		if (Parameters.Count == RegularParameterCount)
		{
			stringBuilder.Append(", ...");
		}
		stringBuilder.Append("):");
		stringBuilder.Append(ReturnType.ReflectionName);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public IMethod Specialize(TypeParameterSubstitution substitution)
	{
		return new VarArgInstanceMethod(baseMethod.Specialize(substitution), Enumerable.ToList<IType>(Enumerable.Select<IParameter, IType>(Enumerable.Skip<IParameter>((IEnumerable<IParameter>)parameters, checked(baseMethod.Parameters.Count - 1)), (Func<IParameter, IType>)((IParameter p) => p.Type.AcceptVisitor(substitution)))));
	}

	IEnumerable<IAttribute> IEntity.GetAttributes()
	{
		return baseMethod.GetAttributes();
	}

	IEnumerable<IAttribute> IMethod.GetReturnTypeAttributes()
	{
		return baseMethod.GetReturnTypeAttributes();
	}

	IMember IMember.Specialize(TypeParameterSubstitution substitution)
	{
		return Specialize(substitution);
	}
}
