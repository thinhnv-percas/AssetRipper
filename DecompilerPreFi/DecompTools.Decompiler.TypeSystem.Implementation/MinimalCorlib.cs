using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public sealed class MinimalCorlib : IModule, ISymbol, ICompilationProvider
{
	private sealed class CorlibModuleReference : IModuleReference
	{
		IModule IModuleReference.Resolve(ITypeResolveContext context)
		{
			return new MinimalCorlib(context.Compilation);
		}
	}

	private sealed class CorlibNamespace : INamespace, ISymbol, ICompilationProvider
	{
		private readonly MinimalCorlib corlib;

		internal List<INamespace> childNamespaces = new List<INamespace>();

		public INamespace ParentNamespace { get; }

		public string FullName { get; }

		public string Name { get; }

		string INamespace.ExternAlias => string.Empty;

		IEnumerable<INamespace> INamespace.ChildNamespaces => childNamespaces;

		IEnumerable<ITypeDefinition> INamespace.Types => Enumerable.Where<ITypeDefinition>(corlib.TopLevelTypeDefinitions, (Func<ITypeDefinition, bool>)((ITypeDefinition td) => td.Namespace == FullName));

		IEnumerable<IModule> INamespace.ContributingModules => new MinimalCorlib[1] { corlib };

		SymbolKind ISymbol.SymbolKind => SymbolKind.Namespace;

		ICompilation ICompilationProvider.Compilation => corlib.Compilation;

		public CorlibNamespace(MinimalCorlib corlib, INamespace parentNamespace, string fullName, string name)
		{
			this.corlib = corlib;
			ParentNamespace = parentNamespace;
			FullName = fullName;
			Name = name;
		}

		INamespace INamespace.GetChildNamespace(string name)
		{
			return childNamespaces.FirstOrDefault((INamespace ns) => ns.Name == name);
		}

		ITypeDefinition INamespace.GetTypeDefinition(string name, int typeParameterCount)
		{
			return corlib.GetTypeDefinition(FullName, name, typeParameterCount);
		}
	}

	private sealed class CorlibTypeDefinition : ITypeDefinition, IType, INamedElement, IEquatable<IType>, IEntity, ISymbol, ICompilationProvider
	{
		private readonly MinimalCorlib corlib;

		private readonly KnownTypeCode typeCode;

		private readonly TypeKind typeKind;

		IReadOnlyList<ITypeDefinition> ITypeDefinition.NestedTypes => EmptyList<ITypeDefinition>.Instance;

		IReadOnlyList<IMember> ITypeDefinition.Members => EmptyList<IMember>.Instance;

		IEnumerable<IField> ITypeDefinition.Fields => EmptyList<IField>.Instance;

		IEnumerable<IMethod> ITypeDefinition.Methods => EmptyList<IMethod>.Instance;

		IEnumerable<IProperty> ITypeDefinition.Properties => EmptyList<IProperty>.Instance;

		IEnumerable<IEvent> ITypeDefinition.Events => EmptyList<IEvent>.Instance;

		KnownTypeCode ITypeDefinition.KnownTypeCode => typeCode;

		IType ITypeDefinition.EnumUnderlyingType => SpecialType.UnknownType;

		public FullTypeName FullTypeName => KnownTypeReference.Get(typeCode).TypeName;

		ITypeDefinition IEntity.DeclaringTypeDefinition => null;

		IType ITypeDefinition.DeclaringType => null;

		IType IType.DeclaringType => null;

		IType IEntity.DeclaringType => null;

		bool ITypeDefinition.HasExtensionMethods => false;

		bool ITypeDefinition.IsReadOnly => false;

		TypeKind IType.Kind => typeKind;

		bool? IType.IsReferenceType
		{
			get
			{
				switch (typeKind)
				{
				case TypeKind.Class:
				case TypeKind.Interface:
					return true;
				case TypeKind.Struct:
				case TypeKind.Enum:
					return false;
				default:
					return null;
				}
			}
		}

		bool IType.IsByRefLike => false;

		Nullability IType.Nullability => Nullability.Oblivious;

		int IType.TypeParameterCount => KnownTypeReference.Get(typeCode).TypeParameterCount;

		IReadOnlyList<ITypeParameter> IType.TypeParameters => DummyTypeParameter.GetClassTypeParameterList(KnownTypeReference.Get(typeCode).TypeParameterCount);

		IReadOnlyList<IType> IType.TypeArguments => DummyTypeParameter.GetClassTypeParameterList(KnownTypeReference.Get(typeCode).TypeParameterCount);

		IEnumerable<IType> IType.DirectBaseTypes
		{
			get
			{
				KnownTypeCode baseType = KnownTypeReference.Get(typeCode).baseType;
				if (baseType != KnownTypeCode.None)
				{
					return new CorlibTypeDefinition[1] { corlib.typeDefinitions[(int)baseType] };
				}
				return EmptyList<IType>.Instance;
			}
		}

		EntityHandle IEntity.MetadataToken => MetadataTokens.TypeDefinitionHandle(0);

		public string Name => KnownTypeReference.Get(typeCode).Name;

		IModule IEntity.ParentModule => corlib;

		Accessibility IEntity.Accessibility => Accessibility.Public;

		bool IEntity.IsStatic => false;

		bool IEntity.IsAbstract => typeKind == TypeKind.Interface;

		bool IEntity.IsSealed => typeKind == TypeKind.Struct;

		SymbolKind ISymbol.SymbolKind => SymbolKind.TypeDefinition;

		ICompilation ICompilationProvider.Compilation => corlib.Compilation;

		string INamedElement.FullName
		{
			get
			{
				KnownTypeReference knownTypeReference = KnownTypeReference.Get(typeCode);
				return knownTypeReference.Namespace + "." + knownTypeReference.Name;
			}
		}

		string INamedElement.ReflectionName => KnownTypeReference.Get(typeCode).TypeName.ReflectionName;

		string INamedElement.Namespace => KnownTypeReference.Get(typeCode).Namespace;

		public CorlibTypeDefinition(MinimalCorlib corlib, KnownTypeCode typeCode)
		{
			this.corlib = corlib;
			this.typeCode = typeCode;
			typeKind = KnownTypeReference.Get(typeCode).typeKind;
		}

		IType IType.ChangeNullability(Nullability nullability)
		{
			if (nullability == Nullability.Oblivious)
			{
				return this;
			}
			return new NullabilityAnnotatedType(this, nullability);
		}

		bool IEquatable<IType>.Equals(IType other)
		{
			return this == other;
		}

		IEnumerable<IMethod> IType.GetAccessors(Predicate<IMethod> filter, GetMemberOptions options)
		{
			return EmptyList<IMethod>.Instance;
		}

		IEnumerable<IAttribute> IEntity.GetAttributes()
		{
			return EmptyList<IAttribute>.Instance;
		}

		IEnumerable<IMethod> IType.GetConstructors(Predicate<IMethod> filter, GetMemberOptions options)
		{
			return EmptyList<IMethod>.Instance;
		}

		IEnumerable<IEvent> IType.GetEvents(Predicate<IEvent> filter, GetMemberOptions options)
		{
			return EmptyList<IEvent>.Instance;
		}

		IEnumerable<IField> IType.GetFields(Predicate<IField> filter, GetMemberOptions options)
		{
			return EmptyList<IField>.Instance;
		}

		IEnumerable<IMember> IType.GetMembers(Predicate<IMember> filter, GetMemberOptions options)
		{
			return EmptyList<IMember>.Instance;
		}

		IEnumerable<IMethod> IType.GetMethods(Predicate<IMethod> filter, GetMemberOptions options)
		{
			return EmptyList<IMethod>.Instance;
		}

		IEnumerable<IMethod> IType.GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter, GetMemberOptions options)
		{
			return EmptyList<IMethod>.Instance;
		}

		IEnumerable<IType> IType.GetNestedTypes(Predicate<ITypeDefinition> filter, GetMemberOptions options)
		{
			return EmptyList<IType>.Instance;
		}

		IEnumerable<IType> IType.GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter, GetMemberOptions options)
		{
			return EmptyList<IType>.Instance;
		}

		IEnumerable<IProperty> IType.GetProperties(Predicate<IProperty> filter, GetMemberOptions options)
		{
			return EmptyList<IProperty>.Instance;
		}

		ITypeDefinition IType.GetDefinition()
		{
			return this;
		}

		TypeParameterSubstitution IType.GetSubstitution()
		{
			return TypeParameterSubstitution.Identity;
		}

		IType IType.AcceptVisitor(TypeVisitor visitor)
		{
			return visitor.VisitTypeDefinition(this);
		}

		IType IType.VisitChildren(TypeVisitor visitor)
		{
			return this;
		}
	}

	public static readonly IModuleReference Instance = new CorlibModuleReference();

	private CorlibTypeDefinition[] typeDefinitions;

	private readonly CorlibNamespace rootNamespace;

	public ICompilation Compilation { get; }

	bool IModule.IsMainModule => Compilation.MainModule == this;

	string IModule.AssemblyName => "corlib";

	string IModule.FullAssemblyName => "corlib";

	string ISymbol.Name => "corlib";

	SymbolKind ISymbol.SymbolKind => SymbolKind.Module;

	PEFile IModule.PEFile => null;

	INamespace IModule.RootNamespace => rootNamespace;

	public IEnumerable<ITypeDefinition> TopLevelTypeDefinitions => Enumerable.Where<CorlibTypeDefinition>((IEnumerable<CorlibTypeDefinition>)typeDefinitions, (Func<CorlibTypeDefinition, bool>)((CorlibTypeDefinition td) => td != null));

	public IEnumerable<ITypeDefinition> TypeDefinitions => TopLevelTypeDefinitions;

	private MinimalCorlib(ICompilation compilation)
	{
		Compilation = compilation;
		typeDefinitions = new CorlibTypeDefinition[52];
		rootNamespace = new CorlibNamespace(this, null, string.Empty, string.Empty);
		for (int i = 0; i < 52; i = checked(i + 1))
		{
			if (KnownTypeReference.Get((KnownTypeCode)i) != null)
			{
				typeDefinitions[i] = new CorlibTypeDefinition(this, (KnownTypeCode)i);
			}
		}
	}

	public ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName)
	{
		CorlibTypeDefinition[] array = typeDefinitions;
		foreach (CorlibTypeDefinition corlibTypeDefinition in array)
		{
			if (corlibTypeDefinition != null && corlibTypeDefinition.FullTypeName == topLevelTypeName)
			{
				return corlibTypeDefinition;
			}
		}
		return null;
	}

	IEnumerable<IAttribute> IModule.GetAssemblyAttributes()
	{
		return EmptyList<IAttribute>.Instance;
	}

	IEnumerable<IAttribute> IModule.GetModuleAttributes()
	{
		return EmptyList<IAttribute>.Instance;
	}

	bool IModule.InternalsVisibleTo(IModule module)
	{
		return module == this;
	}
}
