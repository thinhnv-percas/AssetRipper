using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class ReducedExtensionMethod : IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	[Serializable]
	public sealed class ReducedExtensionMethodMemberReference : IMemberReference, ISymbolReference
	{
		private readonly IMethod baseMethod;

		public ITypeReference DeclaringTypeReference => baseMethod.ToReference().DeclaringTypeReference;

		public ReducedExtensionMethodMemberReference(IMethod baseMethod)
		{
			this.baseMethod = baseMethod;
		}

		public IMember Resolve(ITypeResolveContext context)
		{
			return new ReducedExtensionMethod((IMethod)baseMethod.ToReference().Resolve(context));
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return Resolve(context);
		}
	}

	private readonly IMethod baseMethod;

	private List<IParameter> parameters;

	public IMember MemberDefinition => baseMethod.MemberDefinition;

	public IUnresolvedMember UnresolvedMember => baseMethod.UnresolvedMember;

	public IType ReturnType => baseMethod.ReturnType;

	public IList<IMember> ImplementedInterfaceMembers => baseMethod.ImplementedInterfaceMembers;

	public bool IsExplicitInterfaceImplementation => baseMethod.IsExplicitInterfaceImplementation;

	public bool IsVirtual => baseMethod.IsVirtual;

	public bool IsOverride => baseMethod.IsOverride;

	public bool IsOverridable => baseMethod.IsOverridable;

	public TypeParameterSubstitution Substitution => baseMethod.Substitution;

	public bool IsParameterized => baseMethod.IsParameterized;

	public IList<IUnresolvedMethod> Parts => baseMethod.Parts;

	public IList<IAttribute> ReturnTypeAttributes => baseMethod.ReturnTypeAttributes;

	public IList<ITypeParameter> TypeParameters => baseMethod.TypeParameters;

	public bool IsExtensionMethod => true;

	public bool IsConstructor => baseMethod.IsConstructor;

	public bool IsDestructor => baseMethod.IsDestructor;

	public bool IsOperator => baseMethod.IsOperator;

	public bool IsPartial => baseMethod.IsPartial;

	public bool IsAsync => baseMethod.IsAsync;

	public bool HasBody => baseMethod.HasBody;

	public bool IsAccessor => baseMethod.IsAccessor;

	public IMember AccessorOwner => baseMethod.AccessorOwner;

	public IMethod ReducedFrom => baseMethod;

	public IList<IType> TypeArguments => baseMethod.TypeArguments;

	public IList<IParameter> Parameters
	{
		get
		{
			if (parameters == null)
			{
				parameters = new List<IParameter>(baseMethod.Parameters.Skip(1));
			}
			return parameters;
		}
	}

	public SymbolKind SymbolKind => baseMethod.SymbolKind;

	[Obsolete("Use the SymbolKind property instead.")]
	public EntityType EntityType => baseMethod.EntityType;

	public DomRegion Region => baseMethod.Region;

	public DomRegion BodyRegion => baseMethod.BodyRegion;

	public ITypeDefinition DeclaringTypeDefinition => baseMethod.DeclaringTypeDefinition;

	public IType DeclaringType => baseMethod.DeclaringType;

	public IAssembly ParentAssembly => baseMethod.ParentAssembly;

	public IList<IAttribute> Attributes => baseMethod.Attributes;

	public DocumentationComment Documentation => baseMethod.Documentation;

	public bool IsStatic => false;

	public bool IsAbstract => baseMethod.IsAbstract;

	public bool IsSealed => baseMethod.IsSealed;

	public bool IsShadowing => baseMethod.IsShadowing;

	public bool IsSynthetic => baseMethod.IsSynthetic;

	public Accessibility Accessibility => baseMethod.Accessibility;

	public bool IsPrivate => baseMethod.IsPrivate;

	public bool IsPublic => baseMethod.IsPublic;

	public bool IsProtected => baseMethod.IsProtected;

	public bool IsInternal => baseMethod.IsInternal;

	public bool IsProtectedOrInternal => baseMethod.IsProtectedOrInternal;

	public bool IsProtectedAndInternal => baseMethod.IsProtectedAndInternal;

	public string FullName => baseMethod.FullName;

	public string Name => baseMethod.Name;

	public string ReflectionName => baseMethod.ReflectionName;

	public string Namespace => baseMethod.Namespace;

	public ICompilation Compilation => baseMethod.Compilation;

	public ReducedExtensionMethod(IMethod baseMethod)
	{
		this.baseMethod = baseMethod;
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

	public IMemberReference ToMemberReference()
	{
		return new ReducedExtensionMethodMemberReference(baseMethod);
	}

	public IMemberReference ToReference()
	{
		return new ReducedExtensionMethodMemberReference(baseMethod);
	}

	ISymbolReference ISymbol.ToReference()
	{
		return ToReference();
	}

	public IMethod Specialize(TypeParameterSubstitution substitution)
	{
		return new ReducedExtensionMethod(baseMethod.Specialize(substitution));
	}

	IMember IMember.Specialize(TypeParameterSubstitution substitution)
	{
		return Specialize(substitution);
	}
}
