#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public abstract class AbstractType : IType, INamedElement, IEquatable<IType>
{
	public virtual string FullName
	{
		get
		{
			string text = Namespace;
			string name = Name;
			if (string.IsNullOrEmpty(text))
			{
				return name;
			}
			return text + "." + name;
		}
	}

	public abstract string Name { get; }

	public virtual string Namespace => string.Empty;

	public virtual string ReflectionName => FullName;

	public abstract bool? IsReferenceType { get; }

	public virtual bool IsByRefLike => false;

	public virtual Nullability Nullability => Nullability.Oblivious;

	public abstract TypeKind Kind { get; }

	public virtual int TypeParameterCount => 0;

	public virtual IReadOnlyList<ITypeParameter> TypeParameters => EmptyList<ITypeParameter>.Instance;

	public virtual IReadOnlyList<IType> TypeArguments => EmptyList<IType>.Instance;

	public virtual IType DeclaringType => null;

	public virtual IEnumerable<IType> DirectBaseTypes => EmptyList<IType>.Instance;

	public virtual IType ChangeNullability(Nullability nullability)
	{
		Debug.Assert(nullability == Nullability.Oblivious);
		return this;
	}

	public virtual ITypeDefinition GetDefinition()
	{
		return null;
	}

	public virtual IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IType>.Instance;
	}

	public virtual IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IType>.Instance;
	}

	public virtual IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IMethod>.Instance;
	}

	public virtual IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IMethod>.Instance;
	}

	public virtual IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		return EmptyList<IMethod>.Instance;
	}

	public virtual IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IProperty>.Instance;
	}

	public virtual IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IField>.Instance;
	}

	public virtual IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IEvent>.Instance;
	}

	public virtual IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		IEnumerable<IMember> methods = GetMethods(filter, options);
		return Enumerable.Concat<IMember>(Enumerable.Concat<IMember>(Enumerable.Concat<IMember>(methods, (IEnumerable<IMember>)GetProperties(filter, options)), (IEnumerable<IMember>)GetFields(filter, options)), (IEnumerable<IMember>)GetEvents(filter, options));
	}

	public virtual IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return EmptyList<IMethod>.Instance;
	}

	public TypeParameterSubstitution GetSubstitution()
	{
		return TypeParameterSubstitution.Identity;
	}

	public TypeParameterSubstitution GetSubstitution(IReadOnlyList<IType> methodTypeArguments)
	{
		return TypeParameterSubstitution.Identity;
	}

	public sealed override bool Equals(object obj)
	{
		return Equals(obj as IType);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual bool Equals(IType other)
	{
		return this == other;
	}

	public override string ToString()
	{
		return ReflectionName;
	}

	public virtual IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitOtherType(this);
	}

	public virtual IType VisitChildren(TypeVisitor visitor)
	{
		return this;
	}
}
