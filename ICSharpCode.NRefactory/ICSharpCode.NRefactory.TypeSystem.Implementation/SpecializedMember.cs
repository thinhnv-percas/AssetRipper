using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public abstract class SpecializedMember : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	protected readonly IMember baseMember;

	private TypeParameterSubstitution substitution;

	private IType declaringType;

	private IType returnType;

	private IList<IMember> implementedInterfaceMembers;

	public TypeParameterSubstitution Substitution => substitution;

	public IType DeclaringType
	{
		get
		{
			IType type = LazyInit.VolatileRead(ref declaringType);
			if (type != null)
			{
				return type;
			}
			IType type2 = baseMember.DeclaringType;
			if (type2 is ITypeDefinition typeDefinition && type2.TypeParameterCount > 0)
			{
				type = ((substitution.ClassTypeArguments == null || substitution.ClassTypeArguments.Count != type2.TypeParameterCount) ? new ParameterizedType(typeDefinition, typeDefinition.TypeParameters).AcceptVisitor(substitution) : new ParameterizedType(typeDefinition, substitution.ClassTypeArguments));
			}
			else if (type2 != null)
			{
				type = type2.AcceptVisitor(substitution);
			}
			return LazyInit.GetOrSet(ref declaringType, type);
		}
		internal set
		{
			declaringType = value;
		}
	}

	public IMember MemberDefinition => baseMember.MemberDefinition;

	public IUnresolvedMember UnresolvedMember => baseMember.UnresolvedMember;

	public IType ReturnType
	{
		get
		{
			IType type = LazyInit.VolatileRead(ref returnType);
			if (type != null)
			{
				return type;
			}
			return LazyInit.GetOrSet(ref returnType, baseMember.ReturnType.AcceptVisitor(substitution));
		}
		protected set
		{
			returnType = value;
		}
	}

	public bool IsVirtual => baseMember.IsVirtual;

	public bool IsOverride => baseMember.IsOverride;

	public bool IsOverridable => baseMember.IsOverridable;

	public SymbolKind SymbolKind => baseMember.SymbolKind;

	[Obsolete("Use the SymbolKind property instead.")]
	public EntityType EntityType => baseMember.EntityType;

	public DomRegion Region => baseMember.Region;

	public DomRegion BodyRegion => baseMember.BodyRegion;

	public ITypeDefinition DeclaringTypeDefinition => baseMember.DeclaringTypeDefinition;

	public IList<IAttribute> Attributes => baseMember.Attributes;

	public IList<IMember> ImplementedInterfaceMembers => LazyInitializer.EnsureInitialized(ref implementedInterfaceMembers, FindImplementedInterfaceMembers);

	public bool IsExplicitInterfaceImplementation => baseMember.IsExplicitInterfaceImplementation;

	public DocumentationComment Documentation => baseMember.Documentation;

	public Accessibility Accessibility => baseMember.Accessibility;

	public bool IsStatic => baseMember.IsStatic;

	public bool IsAbstract => baseMember.IsAbstract;

	public bool IsSealed => baseMember.IsSealed;

	public bool IsShadowing => baseMember.IsShadowing;

	public bool IsSynthetic => baseMember.IsSynthetic;

	public bool IsPrivate => baseMember.IsPrivate;

	public bool IsPublic => baseMember.IsPublic;

	public bool IsProtected => baseMember.IsProtected;

	public bool IsInternal => baseMember.IsInternal;

	public bool IsProtectedOrInternal => baseMember.IsProtectedOrInternal;

	public bool IsProtectedAndInternal => baseMember.IsProtectedAndInternal;

	public string FullName => baseMember.FullName;

	public string Name => baseMember.Name;

	public string Namespace => baseMember.Namespace;

	public string ReflectionName => baseMember.ReflectionName;

	public ICompilation Compilation => baseMember.Compilation;

	public IAssembly ParentAssembly => baseMember.ParentAssembly;

	protected SpecializedMember(IMember memberDefinition)
	{
		if (memberDefinition == null)
		{
			throw new ArgumentNullException("memberDefinition");
		}
		if (memberDefinition is SpecializedMember)
		{
			throw new ArgumentException("Member definition cannot be specialized. Please use IMember.Specialize() instead of directly constructing SpecializedMember instances.");
		}
		baseMember = memberDefinition;
		substitution = TypeParameterSubstitution.Identity;
	}

	protected void AddSubstitution(TypeParameterSubstitution newSubstitution)
	{
		substitution = TypeParameterSubstitution.Compose(newSubstitution, substitution);
	}

	[Obsolete("Use IMember.Specialize() instead")]
	public static IMember Create(IMember memberDefinition, TypeParameterSubstitution substitution)
	{
		return memberDefinition?.Specialize(substitution);
	}

	public virtual IMemberReference ToMemberReference()
	{
		return ToReference();
	}

	public virtual IMemberReference ToReference()
	{
		return new SpecializingMemberReference(baseMember.ToReference(), ToTypeReference(substitution.ClassTypeArguments));
	}

	ISymbolReference ISymbol.ToReference()
	{
		return ToReference();
	}

	internal static IList<ITypeReference> ToTypeReference(IList<IType> typeArguments)
	{
		return typeArguments?.Select((IType t) => t.ToTypeReference()).ToArray();
	}

	internal IMethod WrapAccessor(ref IMethod cachingField, IMethod accessorDefinition)
	{
		if (accessorDefinition == null)
		{
			return null;
		}
		IMethod method = LazyInit.VolatileRead(ref cachingField);
		if (method != null)
		{
			return method;
		}
		IMethod newValue = accessorDefinition.Specialize(substitution);
		return LazyInit.GetOrSet(ref cachingField, newValue);
	}

	private IList<IMember> FindImplementedInterfaceMembers()
	{
		IList<IMember> list = baseMember.ImplementedInterfaceMembers;
		IMember[] array = new IMember[list.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = list[i].Specialize(substitution);
		}
		return array;
	}

	public virtual IMember Specialize(TypeParameterSubstitution newSubstitution)
	{
		return baseMember.Specialize(TypeParameterSubstitution.Compose(newSubstitution, substitution));
	}

	public override bool Equals(object obj)
	{
		if (!(obj is SpecializedMember specializedMember))
		{
			return false;
		}
		if (baseMember.Equals(specializedMember.baseMember))
		{
			return substitution.Equals(specializedMember.substitution);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 1000000007 * baseMember.GetHashCode() + 1000000009 * substitution.GetHashCode();
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(GetType().Name);
		stringBuilder.Append(' ');
		stringBuilder.Append(DeclaringType.ToString());
		stringBuilder.Append('.');
		stringBuilder.Append(Name);
		stringBuilder.Append(':');
		stringBuilder.Append(ReturnType.ToString());
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}
}
