#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public abstract class SpecializedMember : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	protected readonly IMember baseMember;

	private TypeParameterSubstitution substitution;

	private IType declaringType;

	private IType returnType;

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
			Debug.Assert(declaringType == null);
			declaringType = value;
		}
	}

	public IMember MemberDefinition => baseMember.MemberDefinition;

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

	public EntityHandle MetadataToken => baseMember.MetadataToken;

	public bool IsVirtual => baseMember.IsVirtual;

	public bool IsOverride => baseMember.IsOverride;

	public bool IsOverridable => baseMember.IsOverridable;

	public SymbolKind SymbolKind => baseMember.SymbolKind;

	public ITypeDefinition DeclaringTypeDefinition => baseMember.DeclaringTypeDefinition;

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers => Enumerable.Select<IMember, IMember>(baseMember.ExplicitlyImplementedInterfaceMembers, (Func<IMember, IMember>)((IMember m) => m.Specialize(substitution)));

	public bool IsExplicitInterfaceImplementation => baseMember.IsExplicitInterfaceImplementation;

	public Accessibility Accessibility => baseMember.Accessibility;

	public bool IsStatic => baseMember.IsStatic;

	public bool IsAbstract => baseMember.IsAbstract;

	public bool IsSealed => baseMember.IsSealed;

	public string FullName => baseMember.FullName;

	public string Name => baseMember.Name;

	public string Namespace => baseMember.Namespace;

	public string ReflectionName => baseMember.ReflectionName;

	public ICompilation Compilation => baseMember.Compilation;

	public IModule ParentModule => baseMember.ParentModule;

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
		Debug.Assert(declaringType == null);
		Debug.Assert(returnType == null);
		substitution = TypeParameterSubstitution.Compose(newSubstitution, substitution);
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

	IEnumerable<IAttribute> IEntity.GetAttributes()
	{
		return baseMember.GetAttributes();
	}

	public virtual IMember Specialize(TypeParameterSubstitution newSubstitution)
	{
		return baseMember.Specialize(TypeParameterSubstitution.Compose(newSubstitution, substitution));
	}

	public virtual bool Equals(IMember obj, TypeVisitor typeNormalization)
	{
		if (!(obj is SpecializedMember specializedMember))
		{
			return false;
		}
		return baseMember.Equals(specializedMember.baseMember, typeNormalization) && substitution.Equals(specializedMember.substitution, typeNormalization);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is SpecializedMember specializedMember))
		{
			return false;
		}
		return baseMember.Equals(specializedMember.baseMember) && substitution.Equals(specializedMember.substitution);
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
