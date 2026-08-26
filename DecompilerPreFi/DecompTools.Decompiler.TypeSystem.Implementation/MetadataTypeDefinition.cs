#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataTypeDefinition : ITypeDefinition, IType, INamedElement, IEquatable<IType>, IEntity, ISymbol, ICompilationProvider
{
	private readonly MetadataModule module;

	private readonly TypeDefinitionHandle handle;

	private readonly FullTypeName fullTypeName;

	private readonly TypeAttributes attributes;

	private IMember[] members;

	private IField[] fields;

	private IProperty[] properties;

	private IEvent[] events;

	private IMethod[] methods;

	private List<IType> directBaseTypes;

	private string defaultMemberName;

	private ITypeDefinition[] nestedTypes;

	public TypeKind Kind { get; }

	public bool IsByRefLike { get; }

	public bool IsReadOnly { get; }

	public ITypeDefinition DeclaringTypeDefinition { get; }

	public IReadOnlyList<ITypeParameter> TypeParameters { get; }

	public KnownTypeCode KnownTypeCode { get; }

	public IType EnumUnderlyingType { get; }

	public bool HasExtensionMethods { get; }

	public IReadOnlyList<ITypeDefinition> NestedTypes
	{
		get
		{
			ITypeDefinition[] array = LazyInit.VolatileRead(ref nestedTypes);
			if (array != null)
			{
				return array;
			}
			MetadataReader metadata = module.metadata;
			ImmutableArray<TypeDefinitionHandle> immutableArray = metadata.GetTypeDefinition(handle).GetNestedTypes();
			List<ITypeDefinition> list = new List<ITypeDefinition>(immutableArray.Length);
			foreach (TypeDefinitionHandle item in immutableArray)
			{
				list.Add(module.GetDefinition(item));
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref nestedTypes, list.ToArray());
		}
	}

	public IReadOnlyList<IMember> Members
	{
		get
		{
			IMember[] array = LazyInit.VolatileRead(ref members);
			if (array != null)
			{
				return array;
			}
			array = Enumerable.ToArray<IMember>(Enumerable.Concat<IMember>(Enumerable.Concat<IMember>(Enumerable.Concat<IMember>((IEnumerable<IMember>)Fields, (IEnumerable<IMember>)Methods), (IEnumerable<IMember>)Properties), (IEnumerable<IMember>)Events));
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return array;
			}
			return LazyInit.GetOrSet(ref members, array);
		}
	}

	public IEnumerable<IField> Fields
	{
		get
		{
			IField[] array = LazyInit.VolatileRead(ref fields);
			if (array != null)
			{
				return array;
			}
			MetadataReader metadata = module.metadata;
			FieldDefinitionHandleCollection fieldDefinitionHandleCollection = metadata.GetTypeDefinition(handle).GetFields();
			List<IField> list = new List<IField>(fieldDefinitionHandleCollection.Count);
			foreach (FieldDefinitionHandle item in fieldDefinitionHandleCollection)
			{
				FieldAttributes att = metadata.GetFieldDefinition(item).Attributes;
				if (module.IsVisible(att))
				{
					list.Add(module.GetDefinition(item));
				}
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref fields, list.ToArray());
		}
	}

	public IEnumerable<IProperty> Properties
	{
		get
		{
			IProperty[] array = LazyInit.VolatileRead(ref properties);
			if (array != null)
			{
				return array;
			}
			MetadataReader metadata = module.metadata;
			PropertyDefinitionHandleCollection propertyDefinitionHandleCollection = metadata.GetTypeDefinition(handle).GetProperties();
			List<IProperty> list = new List<IProperty>(propertyDefinitionHandleCollection.Count);
			foreach (PropertyDefinitionHandle item in propertyDefinitionHandleCollection)
			{
				PropertyAccessors accessors = metadata.GetPropertyDefinition(item).GetAccessors();
				bool flag = !accessors.Getter.IsNil && module.IsVisible(metadata.GetMethodDefinition(accessors.Getter).Attributes);
				bool flag2 = !accessors.Setter.IsNil && module.IsVisible(metadata.GetMethodDefinition(accessors.Setter).Attributes);
				if (flag | flag2)
				{
					list.Add(module.GetDefinition(item));
				}
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref properties, list.ToArray());
		}
	}

	public IEnumerable<IEvent> Events
	{
		get
		{
			IEvent[] array = LazyInit.VolatileRead(ref events);
			if (array != null)
			{
				return array;
			}
			MetadataReader metadata = module.metadata;
			EventDefinitionHandleCollection eventDefinitionHandleCollection = metadata.GetTypeDefinition(handle).GetEvents();
			List<IEvent> list = new List<IEvent>(eventDefinitionHandleCollection.Count);
			foreach (EventDefinitionHandle item in eventDefinitionHandleCollection)
			{
				EventAccessors accessors = metadata.GetEventDefinition(item).GetAccessors();
				if (!accessors.Adder.IsNil)
				{
					MethodDefinition methodDefinition = metadata.GetMethodDefinition(accessors.Adder);
					if (module.IsVisible(methodDefinition.Attributes))
					{
						list.Add(module.GetDefinition(item));
					}
				}
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref events, list.ToArray());
		}
	}

	public IEnumerable<IMethod> Methods
	{
		get
		{
			IMethod[] array = LazyInit.VolatileRead(ref methods);
			if (array != null)
			{
				return array;
			}
			MetadataReader metadata = module.metadata;
			MethodDefinitionHandleCollection methodDefinitionHandleCollection = metadata.GetTypeDefinition(handle).GetMethods();
			List<IMethod> list = new List<IMethod>(methodDefinitionHandleCollection.Count);
			MethodSemanticsLookup methodSemanticsLookup = module.PEFile.MethodSemanticsLookup;
			foreach (MethodDefinitionHandle item in methodDefinitionHandleCollection)
			{
				MethodDefinition methodDefinition = metadata.GetMethodDefinition(item);
				if (methodSemanticsLookup.GetSemantics(item).Item2 == (MethodSemanticsAttributes)0 && module.IsVisible(methodDefinition.Attributes))
				{
					list.Add(module.GetDefinition(item));
				}
			}
			if (Kind == TypeKind.Struct || Kind == TypeKind.Enum)
			{
				list.Add(FakeMethod.CreateDummyConstructor(Compilation, this, IsAbstract ? Accessibility.Protected : Accessibility.Public));
			}
			if ((module.TypeSystemOptions & TypeSystemOptions.Uncached) != TypeSystemOptions.None)
			{
				return list;
			}
			return LazyInit.GetOrSet(ref methods, list.ToArray());
		}
	}

	public IType DeclaringType => DeclaringTypeDefinition;

	public bool? IsReferenceType
	{
		get
		{
			TypeKind kind = Kind;
			if (kind == TypeKind.Struct || kind - 5 <= TypeKind.Class)
			{
				return false;
			}
			return true;
		}
	}

	public int TypeParameterCount => TypeParameters.Count;

	IReadOnlyList<IType> IType.TypeArguments => TypeParameters;

	Nullability IType.Nullability => Nullability.Oblivious;

	public IEnumerable<IType> DirectBaseTypes
	{
		get
		{
			List<IType> list = LazyInit.VolatileRead(ref directBaseTypes);
			if (list != null)
			{
				return list;
			}
			MetadataReader metadata = module.metadata;
			TypeDefinition typeDefinition = metadata.GetTypeDefinition(handle);
			GenericContext context = new GenericContext(TypeParameters);
			InterfaceImplementationHandleCollection interfaceImplementations = typeDefinition.GetInterfaceImplementations();
			list = new List<IType>(checked(1 + interfaceImplementations.Count));
			IType type = null;
			try
			{
				EntityHandle baseType = typeDefinition.BaseType;
				if (!baseType.IsNil)
				{
					type = module.ResolveType(baseType, context);
				}
			}
			catch (BadImageFormatException)
			{
				type = SpecialType.UnknownType;
			}
			if (type != null)
			{
				list.Add(type);
			}
			else if (Kind == TypeKind.Interface)
			{
				list.Add(Compilation.FindType(KnownTypeCode.Object));
			}
			foreach (InterfaceImplementationHandle item in interfaceImplementations)
			{
				InterfaceImplementation interfaceImplementation = metadata.GetInterfaceImplementation(item);
				list.Add(module.ResolveType(interfaceImplementation.Interface, context, interfaceImplementation.GetCustomAttributes()));
			}
			return LazyInit.GetOrSet(ref directBaseTypes, list);
		}
	}

	public EntityHandle MetadataToken => handle;

	public FullTypeName FullTypeName => fullTypeName;

	public string Name => fullTypeName.Name;

	public IModule ParentModule => module;

	public string DefaultMemberName
	{
		get
		{
			string text = LazyInit.VolatileRead(ref defaultMemberName);
			if (text != null)
			{
				return text;
			}
			MetadataReader metadata = module.metadata;
			foreach (CustomAttributeHandle customAttribute2 in metadata.GetTypeDefinition(handle).GetCustomAttributes())
			{
				System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(customAttribute2);
				if (customAttribute.IsKnownAttribute(metadata, KnownAttribute.DefaultMember))
				{
					CustomAttributeValue<IType> customAttributeValue = customAttribute.DecodeValue(module.TypeProvider);
					if (customAttributeValue.FixedArguments.Length == 1 && customAttributeValue.FixedArguments[0].Value is string text2)
					{
						text = text2;
						break;
					}
				}
			}
			return LazyInit.GetOrSet(ref defaultMemberName, text ?? "Item");
		}
	}

	public Accessibility Accessibility
	{
		get
		{
			switch (attributes & TypeAttributes.VisibilityMask)
			{
			case TypeAttributes.NotPublic:
			case TypeAttributes.NestedAssembly:
				return Accessibility.Internal;
			case TypeAttributes.Public:
			case TypeAttributes.NestedPublic:
				return Accessibility.Public;
			case TypeAttributes.NestedPrivate:
				return Accessibility.Private;
			case TypeAttributes.NestedFamily:
				return Accessibility.Protected;
			case TypeAttributes.NestedFamANDAssem:
				return Accessibility.ProtectedAndInternal;
			case TypeAttributes.VisibilityMask:
				return Accessibility.ProtectedOrInternal;
			default:
				return Accessibility.None;
			}
		}
	}

	public bool IsStatic => (attributes & (TypeAttributes.Abstract | TypeAttributes.Sealed)) == (TypeAttributes.Abstract | TypeAttributes.Sealed);

	public bool IsAbstract => (attributes & TypeAttributes.Abstract) != 0;

	public bool IsSealed => (attributes & TypeAttributes.Sealed) != 0;

	public SymbolKind SymbolKind => SymbolKind.TypeDefinition;

	public ICompilation Compilation => module.Compilation;

	public string FullName
	{
		get
		{
			if (DeclaringType != null)
			{
				return DeclaringType.FullName + "." + Name;
			}
			if (!string.IsNullOrEmpty(Namespace))
			{
				return Namespace + "." + Name;
			}
			return Name;
		}
	}

	public string ReflectionName => fullTypeName.ReflectionName;

	public string Namespace => fullTypeName.TopLevelTypeName.Namespace;

	internal MetadataTypeDefinition(MetadataModule module, TypeDefinitionHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		this.handle = handle;
		MetadataReader metadata = module.metadata;
		TypeDefinition typeDefinition = metadata.GetTypeDefinition(handle);
		attributes = typeDefinition.Attributes;
		fullTypeName = typeDefinition.GetFullTypeName(metadata);
		if (fullTypeName.IsNested)
		{
			DeclaringTypeDefinition = module.GetDefinition(typeDefinition.GetDeclaringType());
			TypeParameters = MetadataTypeParameter.Create(module, DeclaringTypeDefinition, this, typeDefinition.GetGenericParameters());
		}
		else
		{
			TypeParameters = MetadataTypeParameter.Create(module, this, typeDefinition.GetGenericParameters());
			TopLevelTypeName topLevelTypeName = fullTypeName.TopLevelTypeName;
			for (int i = 0; i < 52; i = checked(i + 1))
			{
				KnownTypeReference knownTypeReference = KnownTypeReference.Get((KnownTypeCode)i);
				if (knownTypeReference != null && knownTypeReference.TypeName == topLevelTypeName)
				{
					KnownTypeCode = (KnownTypeCode)i;
					break;
				}
			}
		}
		PrimitiveTypeCode underlyingType;
		if ((attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
		{
			Kind = TypeKind.Interface;
		}
		else if (typeDefinition.IsEnum(metadata, out underlyingType))
		{
			Kind = TypeKind.Enum;
			EnumUnderlyingType = module.Compilation.FindType(underlyingType.ToKnownTypeCode());
		}
		else if (typeDefinition.IsValueType(metadata))
		{
			if (KnownTypeCode == KnownTypeCode.Void)
			{
				Kind = TypeKind.Void;
				return;
			}
			Kind = TypeKind.Struct;
			IsByRefLike = typeDefinition.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.IsByRefLike);
			IsReadOnly = typeDefinition.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.IsReadOnly);
		}
		else if (typeDefinition.IsDelegate(metadata))
		{
			Kind = TypeKind.Delegate;
		}
		else
		{
			Kind = TypeKind.Class;
			HasExtensionMethods = IsStatic && (module.TypeSystemOptions & TypeSystemOptions.ExtensionMethods) == TypeSystemOptions.ExtensionMethods && typeDefinition.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.Extension);
		}
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} {fullTypeName}";
	}

	public IType ChangeNullability(Nullability nullability)
	{
		if (nullability == Nullability.Oblivious)
		{
			return this;
		}
		return new NullabilityAnnotatedType(this, nullability);
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		TypeDefinition typeDefinition = metadata.GetTypeDefinition(handle);
		if ((typeDefinition.Attributes & TypeAttributes.Serializable) != TypeAttributes.NotPublic)
		{
			attributeListBuilder.Add(KnownAttribute.Serializable);
		}
		if ((typeDefinition.Attributes & TypeAttributes.Import) != TypeAttributes.NotPublic)
		{
			attributeListBuilder.Add(KnownAttribute.ComImport);
		}
		LayoutKind layoutKind = LayoutKind.Auto;
		switch (typeDefinition.Attributes & TypeAttributes.LayoutMask)
		{
		case TypeAttributes.SequentialLayout:
			layoutKind = LayoutKind.Sequential;
			break;
		case TypeAttributes.ExplicitLayout:
			layoutKind = LayoutKind.Explicit;
			break;
		}
		CharSet charSet = CharSet.None;
		switch (typeDefinition.Attributes & TypeAttributes.StringFormatMask)
		{
		case TypeAttributes.NotPublic:
			charSet = CharSet.Ansi;
			break;
		case TypeAttributes.AutoClass:
			charSet = CharSet.Auto;
			break;
		case TypeAttributes.UnicodeClass:
			charSet = CharSet.Unicode;
			break;
		}
		TypeLayout layout = typeDefinition.GetLayout();
		LayoutKind layoutKind2 = ((Kind != TypeKind.Struct) ? LayoutKind.Auto : LayoutKind.Sequential);
		if (layoutKind != layoutKind2 || charSet != CharSet.Ansi || layout.PackingSize > 0 || layout.Size > 0)
		{
			AttributeBuilder attributeBuilder = new AttributeBuilder(module, KnownAttribute.StructLayout);
			attributeBuilder.AddFixedArg(new TopLevelTypeName("System.Runtime.InteropServices", "LayoutKind"), (int)layoutKind);
			if (charSet != CharSet.Ansi)
			{
				IType type = Compilation.FindType(new TopLevelTypeName("System.Runtime.InteropServices", "CharSet"));
				attributeBuilder.AddNamedArg("CharSet", type, (int)charSet);
			}
			if (layout.PackingSize > 0)
			{
				attributeBuilder.AddNamedArg("Pack", KnownTypeCode.Int32, layout.PackingSize);
			}
			if (layout.Size > 0)
			{
				attributeBuilder.AddNamedArg("Size", KnownTypeCode.Int32, layout.Size);
			}
			attributeListBuilder.Add(attributeBuilder.Build());
		}
		attributeListBuilder.Add(typeDefinition.GetCustomAttributes(), SymbolKind.TypeDefinition);
		attributeListBuilder.AddSecurityAttributes(typeDefinition.GetDeclarativeSecurityAttributes());
		return attributeListBuilder.Build();
	}

	ITypeDefinition IType.GetDefinition()
	{
		return this;
	}

	TypeParameterSubstitution IType.GetSubstitution()
	{
		return TypeParameterSubstitution.Identity;
	}

	public IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitTypeDefinition(this);
	}

	IType IType.VisitChildren(TypeVisitor visitor)
	{
		return this;
	}

	public override bool Equals(object obj)
	{
		if (obj is MetadataTypeDefinition metadataTypeDefinition)
		{
			return handle == metadataTypeDefinition.handle && module.PEFile == metadataTypeDefinition.module.PEFile;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 0x2E0520F2 ^ module.PEFile.GetHashCode() ^ handle.GetHashCode();
	}

	bool IEquatable<IType>.Equals(IType other)
	{
		return Equals(other);
	}

	public IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers)) == (GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers))
		{
			return GetFiltered(NestedTypes, filter);
		}
		return GetMembersHelper.GetNestedTypes(this, filter, options);
	}

	public IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return GetMembersHelper.GetNestedTypes(this, typeArguments, filter, options);
	}

	private IEnumerable<T> GetFiltered<T>(IEnumerable<T> input, Predicate<T> filter) where T : class
	{
		if (filter == null)
		{
			return input;
		}
		return ApplyFilter(input, filter);
	}

	private IEnumerable<T> ApplyFilter<T>(IEnumerable<T> input, Predicate<T> filter) where T : class
	{
		foreach (T member in input)
		{
			if (filter(member))
			{
				yield return member;
			}
		}
	}

	public IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IMethod>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Methods, ExtensionMethods.And((IMethod m) => !m.IsConstructor, filter));
		}
		return GetMembersHelper.GetMethods(this, filter, options);
	}

	public IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IMethod>.Instance;
		}
		return GetMembersHelper.GetMethods(this, typeArguments, filter, options);
	}

	public IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IMethod>.Instance;
		}
		if (ComHelper.IsComImport(this))
		{
			IType coClass = ComHelper.GetCoClass(this);
			using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
			{
				if (busyLock.Success)
				{
					return Enumerable.Select<IMethod, SpecializedMethod>(coClass.GetConstructors(filter, options), (Func<IMethod, SpecializedMethod>)((IMethod m) => new SpecializedMethod(m, m.Substitution)
					{
						DeclaringType = this
					}));
				}
			}
			return EmptyList<IMethod>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Methods, ExtensionMethods.And((IMethod m) => m.IsConstructor && !m.IsStatic, filter));
		}
		return GetMembersHelper.GetConstructors(this, filter, options);
	}

	public IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IProperty>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Properties, filter);
		}
		return GetMembersHelper.GetProperties(this, filter, options);
	}

	public IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IField>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Fields, filter);
		}
		return GetMembersHelper.GetFields(this, filter, options);
	}

	public IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IEvent>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Events, filter);
		}
		return GetMembersHelper.GetEvents(this, filter, options);
	}

	public IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IMethod>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFiltered(Members, filter);
		}
		return GetMembersHelper.GetMembers(this, filter, options);
	}

	public IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if (Kind == TypeKind.Void)
		{
			return EmptyList<IMethod>.Instance;
		}
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return GetFilteredAccessors(filter);
		}
		return GetMembersHelper.GetAccessors(this, filter, options);
	}

	private IEnumerable<IMethod> GetFilteredAccessors(Predicate<IMethod> filter)
	{
		foreach (IProperty prop in Properties)
		{
			IMethod getter = prop.Getter;
			if (getter != null && (filter?.Invoke(getter) ?? true))
			{
				yield return getter;
			}
			IMethod setter = prop.Setter;
			if (setter != null && (filter?.Invoke(setter) ?? true))
			{
				yield return setter;
			}
		}
		foreach (IEvent ev in Events)
		{
			IMethod adder = ev.AddAccessor;
			if (adder != null && (filter?.Invoke(adder) ?? true))
			{
				yield return adder;
			}
			IMethod remover = ev.RemoveAccessor;
			if (remover != null && (filter?.Invoke(remover) ?? true))
			{
				yield return remover;
			}
			IMethod invoker = ev.InvokeAccessor;
			if (invoker != null && (filter?.Invoke(invoker) ?? true))
			{
				yield return remover;
			}
		}
	}

	internal IEnumerable<IMethod> GetOverrides(MethodDefinitionHandle method)
	{
		MetadataReader metadata = module.metadata;
		foreach (MethodImplementationHandle implHandle in metadata.GetTypeDefinition(handle).GetMethodImplementations())
		{
			MethodImplementation impl = metadata.GetMethodImplementation(implHandle);
			if (impl.MethodBody == method)
			{
				yield return module.ResolveMethod(impl.MethodDeclaration, new GenericContext(TypeParameters));
			}
		}
	}

	internal bool HasOverrides(MethodDefinitionHandle method)
	{
		MetadataReader metadata = module.metadata;
		foreach (MethodImplementationHandle methodImplementation in metadata.GetTypeDefinition(handle).GetMethodImplementations())
		{
			if (metadata.GetMethodImplementation(methodImplementation).MethodBody == method)
			{
				return true;
			}
		}
		return false;
	}
}
