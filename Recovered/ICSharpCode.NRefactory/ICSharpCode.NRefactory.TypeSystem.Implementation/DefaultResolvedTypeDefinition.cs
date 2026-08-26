using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultResolvedTypeDefinition : ITypeDefinition, IType, INamedElement, IEquatable<IType>, IEntity, ISymbol, ICompilationProvider, IHasAccessibility
	{
		private sealed class MemberList : IList<IMember>, ICollection<IMember>, IEnumerable<IMember>, IEnumerable
		{
			internal readonly ITypeResolveContext[] contextPerMember;

			internal readonly IUnresolvedMember[] unresolvedMembers;

			internal readonly IMember[] resolvedMembers;

			internal readonly int NonPartialMemberCount;

			public IMember this[int index]
			{
				get
				{
					IMember member = LazyInit.VolatileRead(ref resolvedMembers[index]);
					if (member != null)
					{
						return member;
					}
					return LazyInit.GetOrSet(ref resolvedMembers[index], unresolvedMembers[index].CreateResolved(contextPerMember[index]));
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public int Count => resolvedMembers.Length;

			bool ICollection<IMember>.IsReadOnly => true;

			public MemberList(List<ITypeResolveContext> contextPerMember, List<IUnresolvedMember> unresolvedNonPartialMembers, List<PartialMethodInfo> partialMethodInfos)
			{
				NonPartialMemberCount = unresolvedNonPartialMembers.Count;
				this.contextPerMember = contextPerMember.ToArray();
				unresolvedMembers = unresolvedNonPartialMembers.ToArray();
				if (partialMethodInfos == null)
				{
					resolvedMembers = new IMember[unresolvedNonPartialMembers.Count];
					return;
				}
				resolvedMembers = new IMember[unresolvedNonPartialMembers.Count + partialMethodInfos.Count];
				for (int i = 0; i < partialMethodInfos.Count; i++)
				{
					PartialMethodInfo partialMethodInfo = partialMethodInfos[i];
					int num = NonPartialMemberCount + i;
					resolvedMembers[num] = DefaultResolvedMethod.CreateFromMultipleParts(partialMethodInfo.Parts.ToArray(), partialMethodInfo.Contexts.ToArray(), isExtensionMethod: false);
				}
			}

			public int IndexOf(IMember item)
			{
				for (int i = 0; i < Count; i++)
				{
					if (this[i].Equals(item))
					{
						return i;
					}
				}
				return -1;
			}

			void IList<IMember>.Insert(int index, IMember item)
			{
				throw new NotSupportedException();
			}

			void IList<IMember>.RemoveAt(int index)
			{
				throw new NotSupportedException();
			}

			void ICollection<IMember>.Add(IMember item)
			{
				throw new NotSupportedException();
			}

			void ICollection<IMember>.Clear()
			{
				throw new NotSupportedException();
			}

			bool ICollection<IMember>.Contains(IMember item)
			{
				return IndexOf(item) >= 0;
			}

			void ICollection<IMember>.CopyTo(IMember[] array, int arrayIndex)
			{
				for (int i = 0; i < Count; i++)
				{
					array[arrayIndex + i] = this[i];
				}
			}

			bool ICollection<IMember>.Remove(IMember item)
			{
				throw new NotSupportedException();
			}

			public IEnumerator<IMember> GetEnumerator()
			{
				for (int i = 0; i < Count; i++)
				{
					yield return this[i];
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private sealed class PartialMethodInfo
		{
			public readonly string Name;

			public readonly int TypeParameterCount;

			public readonly IList<IParameter> Parameters;

			public readonly List<IUnresolvedMethod> Parts = new List<IUnresolvedMethod>();

			public readonly List<ITypeResolveContext> Contexts = new List<ITypeResolveContext>();

			public PartialMethodInfo(IUnresolvedMethod method, ITypeResolveContext context)
			{
				Name = method.Name;
				TypeParameterCount = method.TypeParameters.Count;
				Parameters = method.Parameters.CreateResolvedParameters(context);
				Parts.Add(method);
				Contexts.Add(context);
			}

			public void AddPart(IUnresolvedMethod method, ITypeResolveContext context)
			{
				if (method.HasBody)
				{
					Parts.Insert(0, method);
					Contexts.Insert(0, context);
				}
				else
				{
					Parts.Add(method);
					Contexts.Add(context);
				}
			}

			public bool IsSameSignature(PartialMethodInfo other, StringComparer nameComparer)
			{
				if (nameComparer.Equals(Name, other.Name) && TypeParameterCount == other.TypeParameterCount)
				{
					return ParameterListComparer.Instance.Equals(Parameters, other.Parameters);
				}
				return false;
			}
		}

		private readonly ITypeResolveContext parentContext;

		private readonly IUnresolvedTypeDefinition[] parts;

		private Accessibility accessibility = Accessibility.Internal;

		private bool isAbstract;

		private bool isSealed;

		private bool isShadowing;

		private bool isSynthetic = true;

		private IList<ITypeParameter> typeParameters;

		private IList<IAttribute> attributes;

		private IList<ITypeDefinition> nestedTypes;

		private MemberList memberList;

		private volatile KnownTypeCode knownTypeCode = (KnownTypeCode)(-1);

		private volatile IType enumUnderlyingType;

		private volatile byte hasExtensionMethods;

		private IList<IType> directBaseTypes;

		public IList<ITypeParameter> TypeParameters
		{
			get
			{
				IList<ITypeParameter> list = LazyInit.VolatileRead(ref typeParameters);
				if (list != null)
				{
					return list;
				}
				ITypeResolveContext typeResolveContext = parts[0].CreateResolveContext(parentContext);
				typeResolveContext = typeResolveContext.WithCurrentTypeDefinition(this);
				if (parentContext.CurrentTypeDefinition == null || parentContext.CurrentTypeDefinition.TypeParameterCount == 0)
				{
					list = parts[0].TypeParameters.CreateResolvedTypeParameters(typeResolveContext);
				}
				else
				{
					ITypeDefinition currentTypeDefinition = parentContext.CurrentTypeDefinition;
					ITypeParameter[] array = new ITypeParameter[parts[0].TypeParameters.Count];
					for (int i = 0; i < array.Length; i++)
					{
						IUnresolvedTypeParameter unresolvedTypeParameter = parts[0].TypeParameters[i];
						if (i < currentTypeDefinition.TypeParameterCount && currentTypeDefinition.TypeParameters[i].Name == unresolvedTypeParameter.Name)
						{
							array[i] = currentTypeDefinition.TypeParameters[i];
						}
						else
						{
							array[i] = unresolvedTypeParameter.CreateResolvedTypeParameter(typeResolveContext);
						}
					}
					list = Array.AsReadOnly(array);
				}
				return LazyInit.GetOrSet(ref typeParameters, list);
			}
		}

		public IList<IAttribute> Attributes
		{
			get
			{
				IList<IAttribute> list = LazyInit.VolatileRead(ref attributes);
				if (list != null)
				{
					return list;
				}
				list = new List<IAttribute>();
				ITypeResolveContext typeResolveContext = parentContext.WithCurrentTypeDefinition(this);
				IUnresolvedTypeDefinition[] array = parts;
				foreach (IUnresolvedTypeDefinition obj in array)
				{
					ITypeResolveContext context = obj.CreateResolveContext(typeResolveContext);
					foreach (IUnresolvedAttribute attribute in obj.Attributes)
					{
						list.Add(attribute.CreateResolvedAttribute(context));
					}
				}
				if (list.Count == 0)
				{
					list = EmptyList<IAttribute>.Instance;
				}
				return LazyInit.GetOrSet(ref attributes, list);
			}
		}

		public IList<IUnresolvedTypeDefinition> Parts => parts;

		public SymbolKind SymbolKind => parts[0].SymbolKind;

		[Obsolete("Use the SymbolKind property instead.")]
		public EntityType EntityType => (EntityType)parts[0].SymbolKind;

		public virtual TypeKind Kind => parts[0].Kind;

		public IList<ITypeDefinition> NestedTypes
		{
			get
			{
				IList<ITypeDefinition> list = LazyInit.VolatileRead(ref nestedTypes);
				if (list != null)
				{
					return list;
				}
				list = ((IEnumerable<ITypeDefinition>)(from part in parts
					from nestedTypeRef in part.NestedTypes
					group nestedTypeRef by new
					{
						nestedTypeRef.Name,
						nestedTypeRef.TypeParameters.Count
					} into g
					select new DefaultResolvedTypeDefinition(new SimpleTypeResolveContext(this), g.ToArray()))).ToList().AsReadOnly();
				return LazyInit.GetOrSet(ref nestedTypes, list);
			}
		}

		public IList<IMember> Members => GetMemberList();

		public IEnumerable<IField> Fields
		{
			get
			{
				MemberList members = GetMemberList();
				for (int i = 0; i < members.unresolvedMembers.Length; i++)
				{
					if (members.unresolvedMembers[i].SymbolKind == SymbolKind.Field)
					{
						yield return (IField)members[i];
					}
				}
			}
		}

		public IEnumerable<IMethod> Methods
		{
			get
			{
				MemberList members = GetMemberList();
				for (int j = 0; j < members.unresolvedMembers.Length; j++)
				{
					if (members.unresolvedMembers[j] is IUnresolvedMethod)
					{
						yield return (IMethod)members[j];
					}
				}
				for (int i = members.unresolvedMembers.Length; i < members.Count; i++)
				{
					yield return (IMethod)members[i];
				}
			}
		}

		public IEnumerable<IProperty> Properties
		{
			get
			{
				MemberList members = GetMemberList();
				for (int i = 0; i < members.unresolvedMembers.Length; i++)
				{
					SymbolKind symbolKind = members.unresolvedMembers[i].SymbolKind;
					if (symbolKind == SymbolKind.Property || symbolKind == SymbolKind.Indexer)
					{
						yield return (IProperty)members[i];
					}
				}
			}
		}

		public IEnumerable<IEvent> Events
		{
			get
			{
				MemberList members = GetMemberList();
				for (int i = 0; i < members.unresolvedMembers.Length; i++)
				{
					if (members.unresolvedMembers[i].SymbolKind == SymbolKind.Event)
					{
						yield return (IEvent)members[i];
					}
				}
			}
		}

		public KnownTypeCode KnownTypeCode
		{
			get
			{
				KnownTypeCode knownTypeCode = this.knownTypeCode;
				if (knownTypeCode == (KnownTypeCode)(-1))
				{
					knownTypeCode = KnownTypeCode.None;
					ICompilation compilation = Compilation;
					for (int i = 0; i < 46; i++)
					{
						if (compilation.FindType((KnownTypeCode)i) == this)
						{
							knownTypeCode = (KnownTypeCode)i;
							break;
						}
					}
					this.knownTypeCode = knownTypeCode;
				}
				return knownTypeCode;
			}
		}

		public IType EnumUnderlyingType
		{
			get
			{
				IType type = enumUnderlyingType;
				if (type == null)
				{
					type = (enumUnderlyingType = ((Kind != TypeKind.Enum) ? SpecialType.UnknownType : CalculateEnumUnderlyingType()));
				}
				return type;
			}
		}

		public bool HasExtensionMethods
		{
			get
			{
				byte b = hasExtensionMethods;
				if (b == 0)
				{
					b = (hasExtensionMethods = (byte)(CalculateHasExtensionMethods() ? 1 : 2));
				}
				return b == 1;
			}
		}

		public bool IsPartial
		{
			get
			{
				if (parts.Length <= 1)
				{
					return parts[0].IsPartial;
				}
				return true;
			}
		}

		public bool? IsReferenceType
		{
			get
			{
				switch (Kind)
				{
				case TypeKind.Class:
				case TypeKind.Interface:
				case TypeKind.Delegate:
				case TypeKind.Module:
					return true;
				case TypeKind.Struct:
				case TypeKind.Enum:
				case TypeKind.Void:
					return false;
				default:
					throw new InvalidOperationException("Invalid value for TypeKind");
				}
			}
		}

		public int TypeParameterCount => parts[0].TypeParameters.Count;

		public IList<IType> TypeArguments => ((IEnumerable<IType>)TypeParameters).ToList();

		public bool IsParameterized => false;

		public IEnumerable<IType> DirectBaseTypes
		{
			get
			{
				IList<IType> list = LazyInit.VolatileRead(ref directBaseTypes);
				if (list != null)
				{
					return list;
				}
				using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
				{
					if (busyLock.Success)
					{
						list = CalculateDirectBaseTypes();
						return LazyInit.GetOrSet(ref directBaseTypes, list);
					}
					return EmptyList<IType>.Instance;
				}
			}
		}

		public string FullName => parts[0].FullName;

		public string Name => parts[0].Name;

		public string ReflectionName => parts[0].ReflectionName;

		public string Namespace => parts[0].Namespace;

		public FullTypeName FullTypeName => parts[0].FullTypeName;

		public DomRegion Region => parts[0].Region;

		public DomRegion BodyRegion => parts[0].BodyRegion;

		public ITypeDefinition DeclaringTypeDefinition => parentContext.CurrentTypeDefinition;

		public IType DeclaringType => parentContext.CurrentTypeDefinition;

		public IAssembly ParentAssembly => parentContext.CurrentAssembly;

		public virtual DocumentationComment Documentation
		{
			get
			{
				IUnresolvedTypeDefinition[] array = parts;
				foreach (IUnresolvedTypeDefinition unresolvedTypeDefinition in array)
				{
					IUnresolvedDocumentationProvider unresolvedDocumentationProvider = unresolvedTypeDefinition.UnresolvedFile as IUnresolvedDocumentationProvider;
					if (unresolvedDocumentationProvider != null)
					{
						DocumentationComment documentation = unresolvedDocumentationProvider.GetDocumentation(unresolvedTypeDefinition, this);
						if (documentation != null)
						{
							return documentation;
						}
					}
				}
				return AbstractResolvedEntity.FindDocumentation(parentContext)?.GetDocumentation(this);
			}
		}

		public ICompilation Compilation => parentContext.Compilation;

		public bool IsStatic
		{
			get
			{
				if (isAbstract)
				{
					return isSealed;
				}
				return false;
			}
		}

		public bool IsAbstract => isAbstract;

		public bool IsSealed => isSealed;

		public bool IsShadowing => isShadowing;

		public bool IsSynthetic => isSynthetic;

		public Accessibility Accessibility => accessibility;

		bool IHasAccessibility.IsPrivate => accessibility == Accessibility.Private;

		bool IHasAccessibility.IsPublic => accessibility == Accessibility.Public;

		bool IHasAccessibility.IsProtected => accessibility == Accessibility.Protected;

		bool IHasAccessibility.IsInternal => accessibility == Accessibility.Internal;

		bool IHasAccessibility.IsProtectedOrInternal => accessibility == Accessibility.ProtectedOrInternal;

		bool IHasAccessibility.IsProtectedAndInternal => accessibility == Accessibility.ProtectedAndInternal;

		public DefaultResolvedTypeDefinition(ITypeResolveContext parentContext, params IUnresolvedTypeDefinition[] parts)
		{
			if (parentContext == null || parentContext.CurrentAssembly == null)
			{
				throw new ArgumentException("Parent context does not specify any assembly", "parentContext");
			}
			if (parts == null || parts.Length == 0)
			{
				throw new ArgumentException("No parts were specified", "parts");
			}
			this.parentContext = parentContext;
			this.parts = parts;
			foreach (IUnresolvedTypeDefinition unresolvedTypeDefinition in parts)
			{
				isAbstract |= unresolvedTypeDefinition.IsAbstract;
				isSealed |= unresolvedTypeDefinition.IsSealed;
				isShadowing |= unresolvedTypeDefinition.IsShadowing;
				isSynthetic &= unresolvedTypeDefinition.IsSynthetic;
				if (accessibility == Accessibility.Internal)
				{
					accessibility = unresolvedTypeDefinition.Accessibility;
				}
			}
		}

		private MemberList GetMemberList()
		{
			MemberList memberList = LazyInit.VolatileRead(ref this.memberList);
			if (memberList != null)
			{
				return memberList;
			}
			List<IUnresolvedMember> list = new List<IUnresolvedMember>();
			List<ITypeResolveContext> list2 = new List<ITypeResolveContext>();
			List<PartialMethodInfo> list3 = null;
			bool flag = false;
			IUnresolvedTypeDefinition[] array = parts;
			foreach (IUnresolvedTypeDefinition unresolvedTypeDefinition in array)
			{
				ITypeResolveContext typeResolveContext = unresolvedTypeDefinition.CreateResolveContext(parentContext).WithCurrentTypeDefinition(this);
				foreach (IUnresolvedMember member in unresolvedTypeDefinition.Members)
				{
					IUnresolvedMethod unresolvedMethod = member as IUnresolvedMethod;
					if (unresolvedMethod != null && unresolvedMethod.IsPartial)
					{
						if (list3 == null)
						{
							list3 = new List<PartialMethodInfo>();
						}
						PartialMethodInfo partialMethodInfo = new PartialMethodInfo(unresolvedMethod, typeResolveContext);
						PartialMethodInfo partialMethodInfo2 = null;
						foreach (PartialMethodInfo item in list3)
						{
							if (partialMethodInfo.IsSameSignature(item, Compilation.NameComparer))
							{
								partialMethodInfo2 = item;
								break;
							}
						}
						if (partialMethodInfo2 != null)
						{
							partialMethodInfo2.AddPart(unresolvedMethod, typeResolveContext);
						}
						else
						{
							list3.Add(partialMethodInfo);
						}
					}
					else
					{
						list.Add(member);
						list2.Add(typeResolveContext);
					}
				}
				flag |= unresolvedTypeDefinition.AddDefaultConstructorIfRequired;
			}
			if (flag)
			{
				TypeKind kind = Kind;
				if ((kind == TypeKind.Class && !IsStatic && !list.Any((IUnresolvedMember m) => m.SymbolKind == SymbolKind.Constructor && !m.IsStatic)) || kind == TypeKind.Enum || kind == TypeKind.Struct)
				{
					list2.Add(parts[0].CreateResolveContext(parentContext).WithCurrentTypeDefinition(this));
					list.Add(DefaultUnresolvedMethod.CreateDefaultConstructor(parts[0]));
				}
			}
			memberList = new MemberList(list2, list, list3);
			return LazyInit.GetOrSet(ref this.memberList, memberList);
		}

		private IType CalculateEnumUnderlyingType()
		{
			IUnresolvedTypeDefinition[] array = parts;
			foreach (IUnresolvedTypeDefinition obj in array)
			{
				ITypeResolveContext context = obj.CreateResolveContext(parentContext).WithCurrentTypeDefinition(this);
				foreach (ITypeReference baseType in obj.BaseTypes)
				{
					IType type = baseType.Resolve(context);
					if (type.Kind != TypeKind.Unknown)
					{
						return type;
					}
				}
			}
			return Compilation.FindType(KnownTypeCode.Int32);
		}

		private bool CalculateHasExtensionMethods()
		{
			bool flag = true;
			IUnresolvedTypeDefinition[] array = parts;
			foreach (IUnresolvedTypeDefinition unresolvedTypeDefinition in array)
			{
				if (unresolvedTypeDefinition.HasExtensionMethods == true)
				{
					return true;
				}
				if (!unresolvedTypeDefinition.HasExtensionMethods.HasValue)
				{
					flag = false;
				}
			}
			if (flag)
			{
				return false;
			}
			return Methods.Any((IMethod m) => m.IsExtensionMethod);
		}

		private IList<IType> CalculateDirectBaseTypes()
		{
			List<IType> list = new List<IType>();
			bool flag = false;
			if (Kind != TypeKind.Enum)
			{
				IUnresolvedTypeDefinition[] array = parts;
				foreach (IUnresolvedTypeDefinition obj in array)
				{
					ITypeResolveContext context = obj.CreateResolveContext(parentContext).WithCurrentTypeDefinition(this);
					foreach (ITypeReference baseType in obj.BaseTypes)
					{
						IType type = baseType.Resolve(context);
						if (type.Kind != TypeKind.Unknown && !list.Contains(type))
						{
							list.Add(type);
							if (type.Kind != TypeKind.Interface)
							{
								flag = true;
							}
						}
					}
				}
			}
			if (!flag && (!(Name == "Object") || !(Namespace == "System") || TypeParameterCount != 0))
			{
				KnownTypeCode typeCode;
				switch (Kind)
				{
				case TypeKind.Enum:
					typeCode = KnownTypeCode.Enum;
					break;
				case TypeKind.Struct:
				case TypeKind.Void:
					typeCode = KnownTypeCode.ValueType;
					break;
				case TypeKind.Delegate:
					typeCode = KnownTypeCode.Delegate;
					break;
				default:
					typeCode = KnownTypeCode.Object;
					break;
				}
				IType type2 = parentContext.Compilation.FindType(typeCode);
				if (type2.Kind != TypeKind.Unknown)
				{
					list.Add(type2);
				}
			}
			return list;
		}

		ITypeDefinition IType.GetDefinition()
		{
			return this;
		}

		IType IType.AcceptVisitor(TypeVisitor visitor)
		{
			return visitor.VisitTypeDefinition(this);
		}

		IType IType.VisitChildren(TypeVisitor visitor)
		{
			return this;
		}

		public ITypeReference ToTypeReference()
		{
			ITypeDefinition declaringTypeDefinition = DeclaringTypeDefinition;
			if (declaringTypeDefinition != null)
			{
				return new NestedTypeReference(declaringTypeDefinition.ToTypeReference(), Name, TypeParameterCount - declaringTypeDefinition.TypeParameterCount);
			}
			IAssembly parentAssembly = ParentAssembly;
			IAssemblyReference assembly = (parentAssembly == null) ? null : new DefaultAssemblyReference(parentAssembly.AssemblyName);
			return new GetClassTypeReference(assembly, Namespace, Name, TypeParameterCount);
		}

		ISymbolReference ISymbol.ToReference()
		{
			return (ISymbolReference)ToTypeReference();
		}

		public IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)) == (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers))
			{
				if (filter == null)
				{
					return NestedTypes;
				}
				return GetNestedTypesImpl(filter);
			}
			return GetMembersHelper.GetNestedTypes(this, filter, options);
		}

		private IEnumerable<IType> GetNestedTypesImpl(Predicate<ITypeDefinition> filter)
		{
			foreach (ITypeDefinition nestedType in NestedTypes)
			{
				if (filter(nestedType))
				{
					yield return nestedType;
				}
			}
		}

		public IEnumerable<IType> GetNestedTypes(IList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			return GetMembersHelper.GetNestedTypes(this, typeArguments, filter, options);
		}

		private IEnumerable<IMember> GetFilteredMembers(Predicate<IUnresolvedMember> filter)
		{
			MemberList members = GetMemberList();
			for (int j = 0; j < members.unresolvedMembers.Length; j++)
			{
				if (filter == null || filter(members.unresolvedMembers[j]))
				{
					yield return members[j];
				}
			}
			for (int i = members.unresolvedMembers.Length; i < members.Count; i++)
			{
				IMethod method = (IMethod)members[i];
				bool flag = false;
				foreach (IUnresolvedMethod part in method.Parts)
				{
					if (filter == null || filter(part))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					yield return method;
				}
			}
		}

		private IEnumerable<IMethod> GetFilteredMethods(Predicate<IUnresolvedMethod> filter)
		{
			MemberList members = GetMemberList();
			for (int j = 0; j < members.unresolvedMembers.Length; j++)
			{
				IUnresolvedMethod unresolvedMethod = members.unresolvedMembers[j] as IUnresolvedMethod;
				if (unresolvedMethod != null && (filter == null || filter(unresolvedMethod)))
				{
					yield return (IMethod)members[j];
				}
			}
			for (int i = members.unresolvedMembers.Length; i < members.Count; i++)
			{
				IMethod method = (IMethod)members[i];
				bool flag = false;
				foreach (IUnresolvedMethod part in method.Parts)
				{
					if (filter == null || filter(part))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					yield return method;
				}
			}
		}

		private IEnumerable<TResolved> GetFilteredNonMethods<TUnresolved, TResolved>(Predicate<TUnresolved> filter) where TUnresolved : class, IUnresolvedMember where TResolved : class, IMember
		{
			MemberList members = GetMemberList();
			for (int i = 0; i < members.unresolvedMembers.Length; i++)
			{
				TUnresolved val = members.unresolvedMembers[i] as TUnresolved;
				if (val != null && (filter == null || filter(val)))
				{
					yield return (TResolved)members[i];
				}
			}
		}

		public virtual IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredMethods(((Predicate<IUnresolvedMethod>)((IUnresolvedMethod m) => !m.IsConstructor)).And(filter));
			}
			return GetMembersHelper.GetMethods(this, filter, options);
		}

		public virtual IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			return GetMembersHelper.GetMethods(this, typeArguments, filter, options);
		}

		public virtual IEnumerable<IMethod> GetConstructors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
		{
			if (ComHelper.IsComImport(this))
			{
				IType coClass = ComHelper.GetCoClass(this);
				using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
				{
					if (busyLock.Success)
					{
						return from m in coClass.GetConstructors(filter, options)
							select new SpecializedMethod(m, m.Substitution)
							{
								DeclaringType = this
							};
					}
				}
				return EmptyList<IMethod>.Instance;
			}
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredMethods(((Predicate<IUnresolvedMethod>)((IUnresolvedMethod m) => m.IsConstructor && !m.IsStatic)).And(filter));
			}
			return GetMembersHelper.GetConstructors(this, filter, options);
		}

		public virtual IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredNonMethods<IUnresolvedProperty, IProperty>(filter);
			}
			return GetMembersHelper.GetProperties(this, filter, options);
		}

		public virtual IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredNonMethods<IUnresolvedField, IField>(filter);
			}
			return GetMembersHelper.GetFields(this, filter, options);
		}

		public virtual IEnumerable<IEvent> GetEvents(Predicate<IUnresolvedEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredNonMethods<IUnresolvedEvent, IEvent>(filter);
			}
			return GetMembersHelper.GetEvents(this, filter, options);
		}

		public virtual IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredMembers(filter);
			}
			return GetMembersHelper.GetMembers(this, filter, options);
		}

		public virtual IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return GetFilteredAccessors(filter);
			}
			return GetMembersHelper.GetAccessors(this, filter, options);
		}

		private IEnumerable<IMethod> GetFilteredAccessors(Predicate<IUnresolvedMethod> filter)
		{
			MemberList members = GetMemberList();
			for (int i = 0; i < members.unresolvedMembers.Length; i++)
			{
				IUnresolvedMember unresolvedMember = members.unresolvedMembers[i];
				IUnresolvedProperty unresolvedProperty = unresolvedMember as IUnresolvedProperty;
				IUnresolvedEvent unresolvedEvent = unresolvedMember as IUnresolvedEvent;
				if (unresolvedProperty != null)
				{
					if (unresolvedProperty.CanGet && (filter == null || filter(unresolvedProperty.Getter)))
					{
						yield return ((IProperty)members[i]).Getter;
					}
					if (unresolvedProperty.CanSet && (filter == null || filter(unresolvedProperty.Setter)))
					{
						yield return ((IProperty)members[i]).Setter;
					}
				}
				else if (unresolvedEvent != null)
				{
					if (unresolvedEvent.CanAdd && (filter == null || filter(unresolvedEvent.AddAccessor)))
					{
						yield return ((IEvent)members[i]).AddAccessor;
					}
					if (unresolvedEvent.CanRemove && (filter == null || filter(unresolvedEvent.RemoveAccessor)))
					{
						yield return ((IEvent)members[i]).RemoveAccessor;
					}
					if (unresolvedEvent.CanInvoke && (filter == null || filter(unresolvedEvent.InvokeAccessor)))
					{
						yield return ((IEvent)members[i]).InvokeAccessor;
					}
				}
			}
		}

		public IMember GetInterfaceImplementation(IMember interfaceMember)
		{
			return GetInterfaceImplementation(new IMember[1]
			{
				interfaceMember
			})[0];
		}

		public IList<IMember> GetInterfaceImplementation(IList<IMember> interfaceMembers)
		{
			interfaceMembers = interfaceMembers.ToList();
			IMember[] array = new IMember[interfaceMembers.Count];
			MultiDictionary<IMember, int> multiDictionary = new MultiDictionary<IMember, int>(SignatureComparer.Ordinal);
			for (int i = 0; i < interfaceMembers.Count; i++)
			{
				multiDictionary.Add(interfaceMembers[i], i);
			}
			foreach (IMember member in GetMembers((IUnresolvedMember m) => !m.IsExplicitInterfaceImplementation))
			{
				foreach (int item in multiDictionary[member])
				{
					array[item] = member;
				}
			}
			foreach (IMember member2 in GetMembers((IUnresolvedMember m) => m.IsExplicitInterfaceImplementation))
			{
				foreach (IMember implementedInterfaceMember in member2.ImplementedInterfaceMembers)
				{
					foreach (int item2 in multiDictionary[implementedInterfaceMember])
					{
						if (implementedInterfaceMember.Equals(interfaceMembers[item2]))
						{
							array[item2] = member2;
						}
					}
				}
			}
			return array;
		}

		public TypeParameterSubstitution GetSubstitution()
		{
			return TypeParameterSubstitution.Identity;
		}

		public TypeParameterSubstitution GetSubstitution(IList<IType> methodTypeArguments)
		{
			return TypeParameterSubstitution.Identity;
		}

		public bool Equals(IType other)
		{
			return this == other;
		}

		public override string ToString()
		{
			return ReflectionName;
		}
	}
}
