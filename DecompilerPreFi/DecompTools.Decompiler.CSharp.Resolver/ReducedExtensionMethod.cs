using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class ReducedExtensionMethod : IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly IMethod baseMethod;

	private List<IParameter> parameters;

	public IMember MemberDefinition => baseMethod.MemberDefinition;

	public IType ReturnType => baseMethod.ReturnType;

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers => baseMethod.ExplicitlyImplementedInterfaceMembers;

	public bool IsExplicitInterfaceImplementation => baseMethod.IsExplicitInterfaceImplementation;

	public bool IsVirtual => baseMethod.IsVirtual;

	public bool IsOverride => baseMethod.IsOverride;

	public bool IsOverridable => baseMethod.IsOverridable;

	public TypeParameterSubstitution Substitution => baseMethod.Substitution;

	public IReadOnlyList<ITypeParameter> TypeParameters => baseMethod.TypeParameters;

	public bool IsExtensionMethod => true;

	public bool IsConstructor => baseMethod.IsConstructor;

	public bool IsDestructor => baseMethod.IsDestructor;

	public bool IsOperator => baseMethod.IsOperator;

	public bool HasBody => baseMethod.HasBody;

	public bool IsAccessor => baseMethod.IsAccessor;

	public IMember AccessorOwner => baseMethod.AccessorOwner;

	public IMethod ReducedFrom => baseMethod;

	public IReadOnlyList<IType> TypeArguments => baseMethod.TypeArguments;

	public IReadOnlyList<IParameter> Parameters
	{
		get
		{
			if (parameters == null)
			{
				parameters = new List<IParameter>(Enumerable.Skip<IParameter>((IEnumerable<IParameter>)baseMethod.Parameters, 1));
			}
			return parameters;
		}
	}

	public EntityHandle MetadataToken => baseMethod.MetadataToken;

	public SymbolKind SymbolKind => baseMethod.SymbolKind;

	public ITypeDefinition DeclaringTypeDefinition => baseMethod.DeclaringTypeDefinition;

	public IType DeclaringType => baseMethod.DeclaringType;

	public IModule ParentModule => baseMethod.ParentModule;

	public bool IsStatic => false;

	public bool IsAbstract => baseMethod.IsAbstract;

	public bool IsSealed => baseMethod.IsSealed;

	public Accessibility Accessibility => baseMethod.Accessibility;

	public string FullName => baseMethod.FullName;

	public string Name => baseMethod.Name;

	public string ReflectionName => baseMethod.ReflectionName;

	public string Namespace => baseMethod.Namespace;

	public ICompilation Compilation => baseMethod.Compilation;

	public ReducedExtensionMethod(IMethod baseMethod)
	{
		this.baseMethod = baseMethod;
	}

	public bool Equals(IMember obj, TypeVisitor typeNormalization)
	{
		if (!(obj is ReducedExtensionMethod reducedExtensionMethod))
		{
			return false;
		}
		return baseMethod.Equals(reducedExtensionMethod.baseMethod, typeNormalization);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is ReducedExtensionMethod reducedExtensionMethod))
		{
			return false;
		}
		return baseMethod.Equals(reducedExtensionMethod.baseMethod);
	}

	public override int GetHashCode()
	{
		return baseMethod.GetHashCode() + 1;
	}

	public override string ToString()
	{
		return $"[ReducedExtensionMethod: ReducedFrom={ReducedFrom}]";
	}

	public IMethod Specialize(TypeParameterSubstitution substitution)
	{
		return new ReducedExtensionMethod(baseMethod.Specialize(substitution));
	}

	IMember IMember.Specialize(TypeParameterSubstitution substitution)
	{
		return Specialize(substitution);
	}

	IEnumerable<IAttribute> IEntity.GetAttributes()
	{
		return baseMethod.GetAttributes();
	}

	IEnumerable<IAttribute> IMethod.GetReturnTypeAttributes()
	{
		return baseMethod.GetReturnTypeAttributes();
	}
}
