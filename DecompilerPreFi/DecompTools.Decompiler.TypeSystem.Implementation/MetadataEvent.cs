#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataEvent : IEvent, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly MetadataModule module;

	private readonly EventDefinitionHandle handle;

	private readonly EventAccessors accessors;

	private readonly string name;

	private IType returnType;

	public EntityHandle MetadataToken => handle;

	public string Name => name;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Event;

	public bool CanAdd => !accessors.Adder.IsNil;

	public bool CanRemove => !accessors.Remover.IsNil;

	public bool CanInvoke => !accessors.Raiser.IsNil;

	public IMethod AddAccessor => module.GetDefinition(accessors.Adder);

	public IMethod RemoveAccessor => module.GetDefinition(accessors.Remover);

	public IMethod InvokeAccessor => module.GetDefinition(accessors.Raiser);

	private IMethod AnyAccessor => module.GetDefinition(accessors.GetAny());

	public IType ReturnType
	{
		get
		{
			IType type = LazyInit.VolatileRead(ref returnType);
			if (type != null)
			{
				return type;
			}
			MetadataReader metadata = module.metadata;
			EventDefinition eventDefinition = metadata.GetEventDefinition(handle);
			GenericContext context = new GenericContext(DeclaringTypeDefinition?.TypeParameters);
			type = module.ResolveType(eventDefinition.Type, context, eventDefinition.GetCustomAttributes());
			return LazyInit.GetOrSet(ref returnType, type);
		}
	}

	public bool IsExplicitInterfaceImplementation => AnyAccessor?.IsExplicitInterfaceImplementation ?? false;

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers => GetInterfaceMembersFromAccessor(AnyAccessor);

	public ITypeDefinition DeclaringTypeDefinition => AnyAccessor?.DeclaringTypeDefinition;

	public IType DeclaringType => AnyAccessor?.DeclaringType;

	IMember IMember.MemberDefinition => this;

	TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

	public Accessibility Accessibility => AnyAccessor?.Accessibility ?? Accessibility.None;

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

	internal MetadataEvent(MetadataModule module, EventDefinitionHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		this.handle = handle;
		MetadataReader metadata = module.metadata;
		EventDefinition eventDefinition = metadata.GetEventDefinition(handle);
		accessors = eventDefinition.GetAccessors();
		name = metadata.GetString(eventDefinition.Name);
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} {DeclaringType?.ReflectionName}.{Name}";
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
		attributeListBuilder.Add(metadata.GetEventDefinition(handle).GetCustomAttributes(), SymbolKind.Event);
		return attributeListBuilder.Build();
	}

	public override bool Equals(object obj)
	{
		if (obj is MetadataEvent metadataEvent)
		{
			return handle == metadataEvent.handle && module.PEFile == metadataEvent.module.PEFile;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 0x7937039A ^ module.PEFile.GetHashCode() ^ handle.GetHashCode();
	}

	bool IMember.Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return Equals(obj);
	}

	public IMember Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedEvent.Create(this, substitution);
	}
}
