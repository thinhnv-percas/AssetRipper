using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public abstract class AbstractTypeParameter : ITypeParameter, IType, INamedElement, IEquatable<IType>, ISymbol, ICompilationProvider
	{
		private readonly ICompilation compilation;

		private readonly SymbolKind ownerType;

		private readonly IEntity owner;

		private readonly int index;

		private readonly string name;

		private readonly IList<IAttribute> attributes;

		private readonly DomRegion region;

		private readonly VarianceModifier variance;

		private volatile IType effectiveBaseClass;

		private ICollection<IType> effectiveInterfaceSet;

		private static readonly IList<IType> emptyTypeArguments = new IType[0];

		SymbolKind ISymbol.SymbolKind => SymbolKind.TypeParameter;

		public SymbolKind OwnerType => ownerType;

		public IEntity Owner => owner;

		public int Index => index;

		public IList<IAttribute> Attributes => attributes;

		public VarianceModifier Variance => variance;

		public DomRegion Region => region;

		public ICompilation Compilation => compilation;

		public IType EffectiveBaseClass
		{
			get
			{
				if (effectiveBaseClass == null)
				{
					using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
					{
						if (!busyLock.Success)
						{
							return SpecialType.UnknownType;
						}
						effectiveBaseClass = CalculateEffectiveBaseClass();
					}
				}
				return effectiveBaseClass;
			}
		}

		public ICollection<IType> EffectiveInterfaceSet
		{
			get
			{
				ICollection<IType> collection = LazyInit.VolatileRead(ref effectiveInterfaceSet);
				if (collection != null)
				{
					return collection;
				}
				using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
				{
					if (!busyLock.Success)
					{
						return EmptyList<IType>.Instance;
					}
					return LazyInit.GetOrSet(ref effectiveInterfaceSet, CalculateEffectiveInterfaceSet());
				}
			}
		}

		public abstract bool HasDefaultConstructorConstraint
		{
			get;
		}

		public abstract bool HasReferenceTypeConstraint
		{
			get;
		}

		public abstract bool HasValueTypeConstraint
		{
			get;
		}

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
						if (knownTypeCode == KnownTypeCode.Object || knownTypeCode == KnownTypeCode.ValueType || knownTypeCode == KnownTypeCode.Enum)
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

		IType IType.DeclaringType => null;

		int IType.TypeParameterCount => 0;

		bool IType.IsParameterized => false;

		IList<IType> IType.TypeArguments => emptyTypeArguments;

		public abstract IEnumerable<IType> DirectBaseTypes
		{
			get;
		}

		public string Name => name;

		string INamedElement.Namespace => string.Empty;

		string INamedElement.FullName => name;

		public string ReflectionName => ((OwnerType == SymbolKind.Method) ? "``" : "`") + index.ToString(CultureInfo.InvariantCulture);

		protected AbstractTypeParameter(IEntity owner, int index, string name, VarianceModifier variance, IList<IAttribute> attributes, DomRegion region)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			this.owner = owner;
			compilation = owner.Compilation;
			ownerType = owner.SymbolKind;
			this.index = index;
			this.name = (name ?? (((OwnerType == SymbolKind.Method) ? "!!" : "!") + index.ToString(CultureInfo.InvariantCulture)));
			this.attributes = (attributes ?? EmptyList<IAttribute>.Instance);
			this.region = region;
			this.variance = variance;
		}

		protected AbstractTypeParameter(ICompilation compilation, SymbolKind ownerType, int index, string name, VarianceModifier variance, IList<IAttribute> attributes, DomRegion region)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			this.compilation = compilation;
			this.ownerType = ownerType;
			this.index = index;
			this.name = (name ?? (((OwnerType == SymbolKind.Method) ? "!!" : "!") + index.ToString(CultureInfo.InvariantCulture)));
			this.attributes = (attributes ?? EmptyList<IAttribute>.Instance);
			this.region = region;
			this.variance = variance;
		}

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
			for (int i = 1; i < list.Count; i++)
			{
				if (list[i].GetDefinition().IsDerivedFrom(type2.GetDefinition()))
				{
					type2 = list[i];
				}
			}
			return type2;
		}

		private ICollection<IType> CalculateEffectiveInterfaceSet()
		{
			HashSet<IType> hashSet = new HashSet<IType>();
			foreach (IType directBaseType in DirectBaseTypes)
			{
				if (directBaseType.Kind == TypeKind.Interface)
				{
					hashSet.Add(directBaseType);
				}
				else if (directBaseType.Kind == TypeKind.TypeParameter)
				{
					hashSet.UnionWith(((ITypeParameter)directBaseType).EffectiveInterfaceSet);
				}
			}
			return hashSet;
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

		public ITypeReference ToTypeReference()
		{
			return TypeParameterReference.Create(OwnerType, Index);
		}

		IEnumerable<IType> IType.GetNestedTypes(Predicate<ITypeDefinition> filter, GetMemberOptions options)
		{
			return EmptyList<IType>.Instance;
		}

		IEnumerable<IType> IType.GetNestedTypes(IList<IType> typeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
		{
			return EmptyList<IType>.Instance;
		}

		public IEnumerable<IMethod> GetConstructors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				if ((HasDefaultConstructorConstraint || HasValueTypeConstraint) && (filter == null || filter(DefaultUnresolvedMethod.DummyConstructor)))
				{
					return new IMethod[1]
					{
						DefaultResolvedMethod.GetDummyConstructor(compilation, this)
					};
				}
				return EmptyList<IMethod>.Instance;
			}
			return GetMembersHelper.GetConstructors(this, filter, options);
		}

		public IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return GetMembersHelper.GetMethods(this, FilterNonStatic(filter), options);
		}

		public IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return GetMembersHelper.GetMethods(this, typeArguments, FilterNonStatic(filter), options);
		}

		public IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IProperty>.Instance;
			}
			return GetMembersHelper.GetProperties(this, FilterNonStatic(filter), options);
		}

		public IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IField>.Instance;
			}
			return GetMembersHelper.GetFields(this, FilterNonStatic(filter), options);
		}

		public IEnumerable<IEvent> GetEvents(Predicate<IUnresolvedEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IEvent>.Instance;
			}
			return GetMembersHelper.GetEvents(this, FilterNonStatic(filter), options);
		}

		public IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMember>.Instance;
			}
			return GetMembersHelper.GetMembers(this, FilterNonStatic(filter), options);
		}

		public IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return GetMembersHelper.GetAccessors(this, FilterNonStatic(filter), options);
		}

		public TypeParameterSubstitution GetSubstitution()
		{
			return TypeParameterSubstitution.Identity;
		}

		public TypeParameterSubstitution GetSubstitution(IList<IType> methodTypeArguments)
		{
			return TypeParameterSubstitution.Identity;
		}

		private static Predicate<T> FilterNonStatic<T>(Predicate<T> filter) where T : class, IUnresolvedMember
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

		public virtual ISymbolReference ToReference()
		{
			if (owner == null)
			{
				return TypeParameterReference.Create(ownerType, index);
			}
			return new OwnedTypeParameterReference(owner.ToReference(), index);
		}

		public override string ToString()
		{
			return ReflectionName + " (owner=" + owner + ")";
		}
	}
}
