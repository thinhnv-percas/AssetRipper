#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataProperty : IProperty, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private const Accessibility InvalidAccessibility = (Accessibility)byte.MaxValue;

	private readonly MetadataModule module;

	private readonly PropertyDefinitionHandle propertyHandle;

	private readonly IMethod getter;

	private readonly IMethod setter;

	private readonly string name;

	private readonly SymbolKind symbolKind;

	private volatile Accessibility cachedAccessiblity = (Accessibility)byte.MaxValue;

	private IParameter[] parameters;

	private IType returnType;

	public EntityHandle MetadataToken => propertyHandle;

	public string Name => name;

	public bool CanGet => getter != null;

	public bool CanSet => setter != null;

	public IMethod Getter => getter;

	public IMethod Setter => setter;

	private IMethod AnyAccessor => getter ?? setter;

	public bool IsIndexer => symbolKind == SymbolKind.Indexer;

	public SymbolKind SymbolKind => symbolKind;

	public IReadOnlyList<IParameter> Parameters
	{
		get
		{
			IParameter[] array = LazyInit.VolatileRead(ref parameters);
			if (array != null)
			{
				return array;
			}
			DecodeSignature();
			return parameters;
		}
	}

	public IType ReturnType
	{
		get
		{
			IType type = LazyInit.VolatileRead(ref returnType);
			if (type != null)
			{
				return type;
			}
			DecodeSignature();
			return returnType;
		}
	}

	public bool IsExplicitInterfaceImplementation => AnyAccessor?.IsExplicitInterfaceImplementation ?? false;

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers => GetInterfaceMembersFromAccessor(AnyAccessor);

	public ITypeDefinition DeclaringTypeDefinition => AnyAccessor?.DeclaringTypeDefinition;

	public IType DeclaringType => AnyAccessor?.DeclaringType;

	IMember IMember.MemberDefinition => this;

	TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

	public Accessibility Accessibility
	{
		get
		{
			Accessibility accessibility = cachedAccessiblity;
			if (accessibility == (Accessibility)byte.MaxValue)
			{
				return cachedAccessiblity = ComputeAccessibility();
			}
			return accessibility;
		}
	}

	public bool IsStatic => AnyAccessor?.IsStatic ?? false;

	public bool IsAbstract => AnyAccessor?.IsAbstract ?? false;

	public bool IsSealed => AnyAccessor?.IsSealed ?? false;

	public bool IsVirtual => AnyAccessor?.IsVirtual ?? false;

	public bool IsOverride => AnyAccessor?.IsOverride ?? false;

	public bool IsOverridable => AnyAccessor?.IsOverridable ?? false;

	public IModule ParentModule => module;

	public ICompilation Compilation => module.Compilation;

	public string FullName => DeclaringType?.FullName + "." + Name;

	public string ReflectionName => DeclaringType?.ReflectionName + "." + Name;

	public string Namespace => DeclaringType?.Namespace ?? string.Empty;

	internal MetadataProperty(MetadataModule module, PropertyDefinitionHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		propertyHandle = handle;
		MetadataReader metadata = module.metadata;
		PropertyDefinition propertyDefinition = metadata.GetPropertyDefinition(handle);
		PropertyAccessors accessors = propertyDefinition.GetAccessors();
		getter = module.GetDefinition(accessors.Getter);
		setter = module.GetDefinition(accessors.Setter);
		name = metadata.GetString(propertyDefinition.Name);
		if (DetermineIsIndexer(name))
		{
			symbolKind = SymbolKind.Indexer;
		}
		else if (name.IndexOf('.') >= 0)
		{
			symbolKind = (Enumerable.FirstOrDefault<IMember>(ExplicitlyImplementedInterfaceMembers) as IProperty)?.SymbolKind ?? SymbolKind.Property;
		}
		else
		{
			symbolKind = SymbolKind.Property;
		}
	}

	private bool DetermineIsIndexer(string name)
	{
		if (name != (DeclaringTypeDefinition as MetadataTypeDefinition)?.DefaultMemberName)
		{
			return false;
		}
		return Parameters.Count > 0;
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(propertyHandle):X8} {DeclaringType?.ReflectionName}.{Name}";
	}

	private void DecodeSignature()
	{
		PropertyDefinition propertyDefinition = module.metadata.GetPropertyDefinition(propertyHandle);
		MethodSignature<IType> signature = propertyDefinition.DecodeSignature<IType, GenericContext>(genericContext: new GenericContext(DeclaringType.TypeParameters), provider: module.TypeProvider);
		PropertyAccessors accessors = propertyDefinition.GetAccessors();
		ParameterHandleCollection? parameterHandles = ((!accessors.Getter.IsNil) ? new ParameterHandleCollection?(module.metadata.GetMethodDefinition(accessors.Getter).GetParameters()) : (accessors.Setter.IsNil ? ((ParameterHandleCollection?)null) : new ParameterHandleCollection?(module.metadata.GetMethodDefinition(accessors.Setter).GetParameters())));
		var (newValue, newValue2) = MetadataMethod.DecodeSignature(module, this, signature, parameterHandles);
		LazyInit.GetOrSet(ref returnType, newValue);
		LazyInit.GetOrSet(ref parameters, newValue2);
	}

	internal static IEnumerable<IMember> GetInterfaceMembersFromAccessor(IMethod method)
	{
		if (method == null)
		{
			return EmptyList<IMember>.Instance;
		}
		return Enumerable.Where<IMember>(Enumerable.Select<IMember, IMember>(method.ExplicitlyImplementedInterfaceMembers, (Func<IMember, IMember>)((IMember m) => ((IMethod)m).AccessorOwner)), (Func<IMember, bool>)((IMember m) => m != null));
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		PropertyDefinition propertyDefinition = metadata.GetPropertyDefinition(propertyHandle);
		if (IsIndexer && Name != "Item" && !IsExplicitInterfaceImplementation)
		{
			attributeListBuilder.Add(KnownAttribute.IndexerName, KnownTypeCode.String, Name);
		}
		attributeListBuilder.Add(propertyDefinition.GetCustomAttributes(), symbolKind);
		return attributeListBuilder.Build();
	}

	private Accessibility ComputeAccessibility()
	{
		if (IsOverride && (getter == null || setter == null))
		{
			foreach (IMember baseMember in InheritanceHelper.GetBaseMembers(this, includeImplementedInterfaces: false))
			{
				if (!baseMember.IsOverride)
				{
					return baseMember.Accessibility;
				}
			}
		}
		return MergePropertyAccessibility(Getter?.Accessibility ?? Accessibility.None, Setter?.Accessibility ?? Accessibility.None);
	}

	internal static Accessibility MergePropertyAccessibility(Accessibility left, Accessibility right)
	{
		if (left == Accessibility.Public || right == Accessibility.Public)
		{
			return Accessibility.Public;
		}
		if (left == Accessibility.ProtectedOrInternal || right == Accessibility.ProtectedOrInternal)
		{
			return Accessibility.ProtectedOrInternal;
		}
		if ((left == Accessibility.Protected && right == Accessibility.Internal) || (left == Accessibility.Internal && right == Accessibility.Protected))
		{
			return Accessibility.ProtectedOrInternal;
		}
		if (left == Accessibility.Protected || right == Accessibility.Protected)
		{
			return Accessibility.Protected;
		}
		if (left == Accessibility.Internal || right == Accessibility.Internal)
		{
			return Accessibility.Internal;
		}
		if (left == Accessibility.ProtectedAndInternal || right == Accessibility.ProtectedAndInternal)
		{
			return Accessibility.ProtectedAndInternal;
		}
		if (left == Accessibility.Private || right == Accessibility.Private)
		{
			return Accessibility.Private;
		}
		return left;
	}

	public override bool Equals(object obj)
	{
		if (obj is MetadataProperty metadataProperty)
		{
			return propertyHandle == metadataProperty.propertyHandle && module.PEFile == metadataProperty.module.PEFile;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 0x32B6A76C ^ module.PEFile.GetHashCode() ^ propertyHandle.GetHashCode();
	}

	bool IMember.Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return Equals(obj);
	}

	public IMember Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedProperty.Create(this, substitution);
	}
}
