using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public abstract class AbstractTypeParameter : ITypeParameter, IType, INamedElement, IEquatable<IType>, ISymbol, ICompilationProvider
{
	private readonly ICompilation compilation;

	private readonly SymbolKind ownerType;

	private readonly IEntity owner;

	private readonly int index;

	private readonly string name;

	private readonly VarianceModifier variance;

	private volatile IType effectiveBaseClass;

	private IReadOnlyCollection<IType> effectiveInterfaceSet;

	SymbolKind ISymbol.SymbolKind => SymbolKind.TypeParameter;

	public SymbolKind OwnerType => ownerType;

	public IEntity Owner => owner;

	public int Index => index;

	public VarianceModifier Variance => variance;

	public ICompilation Compilation => compilation;

	public IType EffectiveBaseClass
	{
		get
		{
			if (effectiveBaseClass == null)
			{
				using BusyManager.BusyLock busyLock = BusyManager.Enter(this);
				if (!busyLock.Success)
				{
					return SpecialType.UnknownType;
				}
				effectiveBaseClass = CalculateEffectiveBaseClass();
			}
			return effectiveBaseClass;
		}
	}

	public IReadOnlyCollection<IType> EffectiveInterfaceSet
	{
		get
		{
			IReadOnlyCollection<IType> readOnlyCollection = LazyInit.VolatileRead(ref effectiveInterfaceSet);
			if (readOnlyCollection != null)
			{
				return readOnlyCollection;
			}
			using BusyManager.BusyLock busyLock = BusyManager.Enter(this);
			if (!busyLock.Success)
			{
				return EmptyList<IType>.Instance;
			}
			return LazyInit.GetOrSet(ref effectiveInterfaceSet, CalculateEffectiveInterfaceSet());
		}
	}

	public abstract bool HasDefaultConstructorConstraint { get; }

	public abstract bool HasReferenceTypeConstraint { get; }

	public abstract bool HasValueTypeConstraint { get; }

	public abstract bool HasUnmanagedConstraint { get; }

	public abstract Nullability NullabilityConstraint { get; }

	public TypeKind Kind => TypeKind.TypeParameter;

	public bool? IsReferenceType
	{
		get
		{
			if (HasValueTypeConstraint)
			{
				return false;
			}
			if (HasReferenceTypeConstraint)
			{
				return true;
			}
			IType type = EffectiveBaseClass;
			if (type.Kind == TypeKind.Class || type.Kind == TypeKind.Delegate)
			{
				ITypeDefinition definition = type.GetDefinition();
				if (definition != null)
				{
					KnownTypeCode knownTypeCode = definition.KnownTypeCode;
					if (knownTypeCode == KnownTypeCode.Object || (uint)(knownTypeCode - 23) <= 1u)
					{
						return null;
					}
				}
				return true;
			}
			if (type.Kind == TypeKind.Struct || type.Kind == TypeKind.Enum)
			{
				return false;
			}
			return null;
		}
	}

	bool IType.IsByRefLike => false;

	Nullability IType.Nullability => NullabilityConstraint;

	IType IType.DeclaringType => null;

	int IType.TypeParameterCount => 0;

	IReadOnlyList<ITypeParameter> IType.TypeParameters => EmptyList<ITypeParameter>.Instance;

	IReadOnlyList<IType> IType.TypeArguments => EmptyList<IType>.Instance;

	public abstract IEnumerable<IType> DirectBaseTypes { get; }

	public string Name => name;

	string INamedElement.Namespace => string.Empty;

	string INamedElement.FullName => name;

	public string ReflectionName
	{
		get
		{
			string obj = ((OwnerType == SymbolKind.Method) ? "``" : "`");
			int num = index;
			return obj + num.ToString(CultureInfo.InvariantCulture);
		}
	}

	protected AbstractTypeParameter(IEntity owner, int index, string name, VarianceModifier variance)
	{
		if (owner == null)
		{
			throw new ArgumentNullException("owner");
		}
		this.owner = owner;
		compilation = owner.Compilation;
		ownerType = owner.SymbolKind;
		this.index = index;
		this.name = name ?? (((OwnerType == SymbolKind.Method) ? "!!" : "!") + index.ToString(CultureInfo.InvariantCulture));
		this.variance = variance;
	}

	protected AbstractTypeParameter(ICompilation compilation, SymbolKind ownerType, int index, string name, VarianceModifier variance)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		this.compilation = compilation;
		this.ownerType = ownerType;
		this.index = index;
		this.name = name ?? (((OwnerType == SymbolKind.Method) ? "!!" : "!") + index.ToString(CultureInfo.InvariantCulture));
		this.variance = variance;
	}

	public abstract IEnumerable<IAttribute> GetAttributes();

	private IType CalculateEffectiveBaseClass()
	{
		if (HasValueTypeConstraint)
		{
			return Compilation.FindType(KnownTypeCode.ValueType);
		}
		List<IType> list = new List<IType>();
		foreach (IType directBaseType in DirectBaseTypes)
		{
			if (directBaseType.Kind == TypeKind.Class)
			{
				list.Add(directBaseType);
			}
			else if (directBaseType.Kind == TypeKind.TypeParameter)
			{
				IType type = ((ITypeParameter)directBaseType).EffectiveBaseClass;
				if (type.Kind == TypeKind.Class)
				{
					list.Add(type);
				}
			}
		}
		if (list.Count == 0)
		{
			return Compilation.FindType(KnownTypeCode.Object);
		}
		IType type2 = list[0];
		for (int i = 1; i < list.Count; i = checked(i + 1))
		{
			if (list[i].GetDefinition().IsDerivedFrom(type2.GetDefinition()))
			{
				type2 = list[i];
			}
		}
		return type2;
	}

	private IReadOnlyCollection<IType> CalculateEffectiveInterfaceSet()
	{
		HashSet<IType> val = new HashSet<IType>();
		foreach (IType directBaseType in DirectBaseTypes)
		{
			if (directBaseType.Kind == TypeKind.Interface)
			{
				val.Add(directBaseType);
			}
			else if (directBaseType.Kind == TypeKind.TypeParameter)
			{
				val.UnionWith((IEnumerable<IType>)((ITypeParameter)directBaseType).EffectiveInterfaceSet);
			}
		}
		return Enumerable.ToArray<IType>((IEnumerable<IType>)val);
	}

	public IType ChangeNullability(Nullability nullability)
	{
		if (nullability == NullabilityConstraint)
		{
			return this;
		}
		return new NullabilityAnnotatedTypeParameter(this, nullability);
	}

	ITypeDefinition IType.GetDefinition()
	{
		return null;
	}

	public IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitTypeParameter(this);
	}

	public IType VisitChildren(TypeVisitor visitor)
	{
		return this;
	}

	IEnumerable<IType> IType.GetNestedTypes(Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		return EmptyList<IType>.Instance;
	}

	IEnumerable<IType> IType.GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
	{
		return EmptyList<IType>.Instance;
	}

	public IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			if (HasDefaultConstructorConstraint || HasValueTypeConstraint)
			{
				IMethod method = FakeMethod.CreateDummyConstructor(compilation, this);
				if (filter == null || filter(method))
				{
					return new IMethod[1] { method };
				}
			}
			return EmptyList<IMethod>.Instance;
		}
		return GetMembersHelper.GetConstructors(this, filter, options);
	}

	public IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return GetMembersHelper.GetMethods(this, FilterNonStatic(filter), options);
	}

	public IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return GetMembersHelper.GetMethods(this, typeArguments, FilterNonStatic(filter), options);
	}

	public IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IProperty>.Instance;
		}
		return GetMembersHelper.GetProperties(this, FilterNonStatic(filter), options);
	}

	public IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IField>.Instance;
		}
		return GetMembersHelper.GetFields(this, FilterNonStatic(filter), options);
	}

	public IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IEvent>.Instance;
		}
		return GetMembersHelper.GetEvents(this, FilterNonStatic(filter), options);
	}

	public IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMember>.Instance;
		}
		return GetMembersHelper.GetMembers(this, FilterNonStatic(filter), options);
	}

	public IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return GetMembersHelper.GetAccessors(this, FilterNonStatic(filter), options);
	}

	TypeParameterSubstitution IType.GetSubstitution()
	{
		return TypeParameterSubstitution.Identity;
	}

	private static Predicate<T> FilterNonStatic<T>(Predicate<T> filter) where T : class, IMember
	{
		if (filter == null)
		{
			return (T member) => !member.IsStatic;
		}
		return (T member) => !member.IsStatic && filter(member);
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
		return string.Concat(ReflectionName, " (owner=", owner, ")");
	}
}
