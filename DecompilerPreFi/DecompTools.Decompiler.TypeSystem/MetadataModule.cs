#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

[DebuggerDisplay("<MetadataModule: {AssemblyName}>")]
public class MetadataModule : IModule, ISymbol, ICompilationProvider
{
	internal readonly MetadataReader metadata;

	private readonly TypeSystemOptions options;

	internal readonly TypeProvider TypeProvider;

	private readonly MetadataNamespace rootNamespace;

	private readonly MetadataTypeDefinition[] typeDefs;

	private readonly MetadataField[] fieldDefs;

	private readonly MetadataMethod[] methodDefs;

	private readonly MetadataProperty[] propertyDefs;

	private readonly MetadataEvent[] eventDefs;

	private string[] internalsVisibleTo;

	private static readonly NormalizeTypeVisitor normalizeTypeVisitor = new NormalizeTypeVisitor
	{
		ReplaceClassTypeParametersWithDummy = true,
		ReplaceMethodTypeParametersWithDummy = true
	};

	private readonly IType[] knownAttributeTypes = new IType[42];

	private readonly IAttribute[] knownAttributes = new IAttribute[42];

	public ICompilation Compilation { get; }

	public TypeSystemOptions TypeSystemOptions => options;

	public PEFile PEFile { get; }

	public bool IsMainModule => this == Compilation.MainModule;

	public string AssemblyName { get; }

	public string FullAssemblyName { get; }

	string ISymbol.Name => AssemblyName;

	SymbolKind ISymbol.SymbolKind => SymbolKind.Module;

	public INamespace RootNamespace => rootNamespace;

	public IEnumerable<ITypeDefinition> TopLevelTypeDefinitions => Enumerable.Where<ITypeDefinition>(TypeDefinitions, (Func<ITypeDefinition, bool>)((ITypeDefinition td) => td.DeclaringTypeDefinition == null));

	public IEnumerable<ITypeDefinition> TypeDefinitions
	{
		get
		{
			foreach (TypeDefinitionHandle tdHandle in metadata.TypeDefinitions)
			{
				yield return GetDefinition(tdHandle);
			}
		}
	}

	internal bool IncludeInternalMembers => (options & TypeSystemOptions.OnlyPublicAPI) == 0;

	internal MetadataModule(ICompilation compilation, PEFile peFile, TypeSystemOptions options)
	{
		Compilation = compilation;
		PEFile = peFile;
		metadata = peFile.Metadata;
		this.options = options;
		TypeProvider = new TypeProvider(this);
		if (metadata.IsAssembly)
		{
			AssemblyDefinition assemblyDefinition = metadata.GetAssemblyDefinition();
			AssemblyName = metadata.GetString(assemblyDefinition.Name);
			FullAssemblyName = metadata.GetFullAssemblyName();
		}
		else
		{
			ModuleDefinition moduleDefinition = metadata.GetModuleDefinition();
			AssemblyName = metadata.GetString(moduleDefinition.Name);
			FullAssemblyName = AssemblyName;
		}
		rootNamespace = new MetadataNamespace(this, null, string.Empty, metadata.GetNamespaceDefinitionRoot());
		checked
		{
			if (!options.HasFlag(TypeSystemOptions.Uncached))
			{
				typeDefs = new MetadataTypeDefinition[metadata.TypeDefinitions.Count + 1];
				fieldDefs = new MetadataField[metadata.FieldDefinitions.Count + 1];
				methodDefs = new MetadataMethod[metadata.MethodDefinitions.Count + 1];
				propertyDefs = new MetadataProperty[metadata.PropertyDefinitions.Count + 1];
				eventDefs = new MetadataEvent[metadata.EventDefinitions.Count + 1];
			}
		}
	}

	internal string GetString(StringHandle name)
	{
		return metadata.GetString(name);
	}

	public ITypeDefinition GetTypeDefinition(TopLevelTypeName topLevelTypeName)
	{
		TypeDefinitionHandle typeDefinition = PEFile.GetTypeDefinition(topLevelTypeName);
		if (typeDefinition.IsNil)
		{
			ExportedTypeHandle typeForwarder = PEFile.GetTypeForwarder(topLevelTypeName);
			if (!typeForwarder.IsNil)
			{
				ExportedType exportedType = metadata.GetExportedType(typeForwarder);
				return ResolveForwardedType(exportedType).GetDefinition();
			}
		}
		return GetDefinition(typeDefinition);
	}

	public bool InternalsVisibleTo(IModule module)
	{
		if (this == module)
		{
			return true;
		}
		string[] array = GetInternalsVisibleTo();
		foreach (string b in array)
		{
			if (string.Equals(module.AssemblyName, b, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private string[] GetInternalsVisibleTo()
	{
		string[] array = LazyInit.VolatileRead(ref internalsVisibleTo);
		if (array != null)
		{
			return array;
		}
		if (metadata.IsAssembly)
		{
			List<string> list = new List<string>();
			foreach (CustomAttributeHandle customAttribute2 in metadata.GetAssemblyDefinition().GetCustomAttributes())
			{
				System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(customAttribute2);
				if (customAttribute.IsKnownAttribute(metadata, KnownAttribute.InternalsVisibleTo))
				{
					CustomAttributeValue<IType> customAttributeValue = customAttribute.DecodeValue(TypeProvider);
					if (customAttributeValue.FixedArguments.Length == 1 && customAttributeValue.FixedArguments[0].Value is string fullAssemblyName)
					{
						list.Add(GetShortName(fullAssemblyName));
					}
				}
			}
			array = list.ToArray();
		}
		else
		{
			array = Empty<string>.Array;
		}
		return LazyInit.GetOrSet(ref internalsVisibleTo, array);
	}

	private static string GetShortName(string fullAssemblyName)
	{
		if (fullAssemblyName == null)
		{
			return null;
		}
		int num = fullAssemblyName.IndexOf(',');
		if (num < 0)
		{
			return fullAssemblyName;
		}
		return fullAssemblyName.Substring(0, num);
	}

	public ITypeDefinition GetDefinition(TypeDefinitionHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (typeDefs == null)
		{
			return new MetadataTypeDefinition(this, handle);
		}
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		if (rowNumber >= typeDefs.Length)
		{
			HandleOutOfRange(handle);
		}
		MetadataTypeDefinition metadataTypeDefinition = LazyInit.VolatileRead(ref typeDefs[rowNumber]);
		if (metadataTypeDefinition != null)
		{
			return metadataTypeDefinition;
		}
		metadataTypeDefinition = new MetadataTypeDefinition(this, handle);
		return LazyInit.GetOrSet(ref typeDefs[rowNumber], metadataTypeDefinition);
	}

	public IField GetDefinition(FieldDefinitionHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (fieldDefs == null)
		{
			return new MetadataField(this, handle);
		}
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		if (rowNumber >= fieldDefs.Length)
		{
			HandleOutOfRange(handle);
		}
		MetadataField metadataField = LazyInit.VolatileRead(ref fieldDefs[rowNumber]);
		if (metadataField != null)
		{
			return metadataField;
		}
		metadataField = new MetadataField(this, handle);
		return LazyInit.GetOrSet(ref fieldDefs[rowNumber], metadataField);
	}

	public IMethod GetDefinition(MethodDefinitionHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (methodDefs == null)
		{
			return new MetadataMethod(this, handle);
		}
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		Debug.Assert(rowNumber != 0);
		if (rowNumber >= methodDefs.Length)
		{
			HandleOutOfRange(handle);
		}
		MetadataMethod metadataMethod = LazyInit.VolatileRead(ref methodDefs[rowNumber]);
		if (metadataMethod != null)
		{
			return metadataMethod;
		}
		metadataMethod = new MetadataMethod(this, handle);
		return LazyInit.GetOrSet(ref methodDefs[rowNumber], metadataMethod);
	}

	public IProperty GetDefinition(PropertyDefinitionHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (propertyDefs == null)
		{
			return new MetadataProperty(this, handle);
		}
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		Debug.Assert(rowNumber != 0);
		if (rowNumber >= methodDefs.Length)
		{
			HandleOutOfRange(handle);
		}
		MetadataProperty metadataProperty = LazyInit.VolatileRead(ref propertyDefs[rowNumber]);
		if (metadataProperty != null)
		{
			return metadataProperty;
		}
		metadataProperty = new MetadataProperty(this, handle);
		return LazyInit.GetOrSet(ref propertyDefs[rowNumber], metadataProperty);
	}

	public IEvent GetDefinition(EventDefinitionHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (eventDefs == null)
		{
			return new MetadataEvent(this, handle);
		}
		int rowNumber = MetadataTokens.GetRowNumber(handle);
		Debug.Assert(rowNumber != 0);
		if (rowNumber >= methodDefs.Length)
		{
			HandleOutOfRange(handle);
		}
		MetadataEvent metadataEvent = LazyInit.VolatileRead(ref eventDefs[rowNumber]);
		if (metadataEvent != null)
		{
			return metadataEvent;
		}
		metadataEvent = new MetadataEvent(this, handle);
		return LazyInit.GetOrSet(ref eventDefs[rowNumber], metadataEvent);
	}

	private void HandleOutOfRange(EntityHandle handle)
	{
		throw new BadImageFormatException("Handle with invalid row number.");
	}

	public IType ResolveType(EntityHandle typeRefDefSpec, GenericContext context, CustomAttributeHandleCollection? typeAttributes = null)
	{
		return ResolveType(typeRefDefSpec, context, options, typeAttributes);
	}

	public IType ResolveType(EntityHandle typeRefDefSpec, GenericContext context, TypeSystemOptions customOptions, CustomAttributeHandleCollection? typeAttributes = null)
	{
		if (typeRefDefSpec.IsNil)
		{
			return SpecialType.UnknownType;
		}
		IType inputType;
		switch (typeRefDefSpec.Kind)
		{
		case HandleKind.TypeDefinition:
			inputType = TypeProvider.GetTypeFromDefinition(metadata, (TypeDefinitionHandle)typeRefDefSpec, 0);
			break;
		case HandleKind.TypeReference:
			inputType = TypeProvider.GetTypeFromReference(metadata, (TypeReferenceHandle)typeRefDefSpec, 0);
			break;
		case HandleKind.TypeSpecification:
			inputType = metadata.GetTypeSpecification((TypeSpecificationHandle)typeRefDefSpec).DecodeSignature(TypeProvider, context);
			break;
		case HandleKind.ExportedType:
			return ResolveForwardedType(metadata.GetExportedType((ExportedTypeHandle)typeRefDefSpec));
		default:
			throw new BadImageFormatException("Not a type handle");
		}
		return ApplyAttributeTypeVisitor.ApplyAttributesToType(inputType, Compilation, typeAttributes, metadata, customOptions);
	}

	private IType ResolveDeclaringType(EntityHandle declaringTypeReference, GenericContext context)
	{
		IType inputType = ResolveType(declaringTypeReference, context, options & ~(TypeSystemOptions.Dynamic | TypeSystemOptions.Tuple | TypeSystemOptions.NullabilityAnnotations));
		return ApplyAttributeTypeVisitor.ApplyAttributesToType(inputType, Compilation, null, metadata, options, typeChildrenOnly: true);
	}

	private IType IntroduceTupleTypes(IType ty)
	{
		return ApplyAttributeTypeVisitor.ApplyAttributesToType(ty, Compilation, null, metadata, options);
	}

	public IMethod ResolveMethod(EntityHandle methodReference, GenericContext context)
	{
		if (methodReference.IsNil)
		{
			throw new ArgumentNullException("methodReference");
		}
		return methodReference.Kind switch
		{
			HandleKind.MethodDefinition => ResolveMethodDefinition((MethodDefinitionHandle)methodReference, expandVarArgs: true), 
			HandleKind.MemberReference => ResolveMethodReference((MemberReferenceHandle)methodReference, context), 
			HandleKind.MethodSpecification => ResolveMethodSpecification((MethodSpecificationHandle)methodReference, context, expandVarArgs: true), 
			_ => throw new BadImageFormatException("Metadata token must be either a methoddef, memberref or methodspec"), 
		};
	}

	private IMethod ResolveMethodDefinition(MethodDefinitionHandle methodDefHandle, bool expandVarArgs)
	{
		IMethod method = GetDefinition(methodDefHandle);
		if (expandVarArgs)
		{
			IParameter parameter = Enumerable.LastOrDefault<IParameter>((IEnumerable<IParameter>)method.Parameters);
			if (parameter != null && parameter.Type.Kind == TypeKind.ArgList)
			{
				method = new VarArgInstanceMethod(method, EmptyList<IType>.Instance);
			}
		}
		return method;
	}

	private IMethod ResolveMethodSpecification(MethodSpecificationHandle methodSpecHandle, GenericContext context, bool expandVarArgs)
	{
		MethodSpecification methodSpecification = metadata.GetMethodSpecification(methodSpecHandle);
		IType[] methodTypeArguments = methodSpecification.DecodeSignature(TypeProvider, context).SelectReadOnlyArray(IntroduceTupleTypes);
		if (methodSpecification.Method.Kind == HandleKind.MethodDefinition)
		{
			IMethod method = ResolveMethodDefinition((MethodDefinitionHandle)methodSpecification.Method, expandVarArgs);
			return method.Specialize(new TypeParameterSubstitution(null, methodTypeArguments));
		}
		return ResolveMethodReference((MemberReferenceHandle)methodSpecification.Method, context, methodTypeArguments, expandVarArgs);
	}

	private IMethod ResolveMethodReference(MemberReferenceHandle memberRefHandle, GenericContext context, IReadOnlyList<IType> methodTypeArguments = null, bool expandVarArgs = true)
	{
		MemberReference memberReference = metadata.GetMemberReference(memberRefHandle);
		Debug.Assert(memberReference.GetKind() == MemberReferenceKind.Method);
		IReadOnlyList<IType> readOnlyList = null;
		IMethod method;
		MethodSignature<IType> signature;
		if (memberReference.Parent.Kind == HandleKind.MethodDefinition)
		{
			method = ResolveMethodDefinition((MethodDefinitionHandle)memberReference.Parent, expandVarArgs: false);
			signature = memberReference.DecodeMethodSignature(TypeProvider, context);
		}
		else
		{
			IType type = ResolveDeclaringType(memberReference.Parent, context);
			ITypeDefinition definition = type.GetDefinition();
			if (type.TypeArguments.Count > 0)
			{
				readOnlyList = type.TypeArguments;
			}
			string name = metadata.GetString(memberReference.Name);
			signature = memberReference.DecodeMethodSignature(TypeProvider, new GenericContext(definition?.TypeParameters));
			if (definition != null)
			{
				IEnumerable<IMethod> enumerable = ((name == ".ctor") ? definition.GetConstructors() : ((!(name == ".cctor")) ? Enumerable.Concat<IMethod>(definition.GetMethods((IMethod m) => m.Name == name, GetMemberOptions.IgnoreInheritedMembers), definition.GetAccessors((IMethod m) => m.Name == name, GetMemberOptions.IgnoreInheritedMembers)) : Enumerable.Where<IMethod>(definition.Methods, (Func<IMethod, bool>)((IMethod m) => m.IsConstructor && m.IsStatic))));
				ImmutableArray<IType> parameterTypes = ((signature.Header.CallingConvention != SignatureCallingConvention.VarArgs) ? signature.ParameterTypes : Enumerable.Concat<IType>(Enumerable.Take<IType>((IEnumerable<IType>)signature.ParameterTypes, signature.RequiredParameterCount), (IEnumerable<IType>)new SpecialType[1] { SpecialType.ArgList }).ToImmutableArray());
				method = null;
				foreach (IMethod item in enumerable)
				{
					if (item.TypeParameters.Count != signature.GenericParameterCount || !CompareSignatures(item.Parameters, parameterTypes) || !CompareTypes(item.ReturnType, signature.ReturnType))
					{
						continue;
					}
					method = item;
					break;
				}
			}
			else
			{
				method = null;
			}
			if (method == null)
			{
				method = CreateFakeMethod(type, name, signature);
			}
		}
		if (readOnlyList != null || methodTypeArguments != null)
		{
			method = method.Specialize(new TypeParameterSubstitution(readOnlyList, methodTypeArguments));
		}
		if (expandVarArgs && signature.Header.CallingConvention == SignatureCallingConvention.VarArgs)
		{
			method = new VarArgInstanceMethod(method, Enumerable.Skip<IType>((IEnumerable<IType>)signature.ParameterTypes, signature.RequiredParameterCount));
		}
		return method;
	}

	private static bool CompareTypes(IType a, IType b)
	{
		IType type = a.AcceptVisitor(normalizeTypeVisitor);
		IType other = b.AcceptVisitor(normalizeTypeVisitor);
		return type.Equals(other);
	}

	private static bool CompareSignatures(IReadOnlyList<IParameter> parameters, ImmutableArray<IType> parameterTypes)
	{
		if (parameterTypes.Length != parameters.Count)
		{
			return false;
		}
		for (int i = 0; i < parameterTypes.Length; i = checked(i + 1))
		{
			if (!CompareTypes(parameterTypes[i], parameters[i].Type))
			{
				return false;
			}
		}
		return true;
	}

	private IMethod CreateFakeMethod(IType declaringType, string name, MethodSignature<IType> signature)
	{
		SymbolKind symbolKind = SymbolKind.Method;
		if (name == ".ctor" || name == ".cctor")
		{
			symbolKind = SymbolKind.Constructor;
		}
		FakeMethod fakeMethod = new FakeMethod(Compilation, symbolKind);
		fakeMethod.DeclaringType = declaringType;
		fakeMethod.Name = name;
		fakeMethod.ReturnType = signature.ReturnType;
		fakeMethod.IsStatic = !signature.Header.IsInstance;
		TypeParameterSubstitution typeParameterSubstitution = null;
		checked
		{
			if (signature.GenericParameterCount > 0)
			{
				List<ITypeParameter> list = new List<ITypeParameter>();
				for (int i = 0; i < signature.GenericParameterCount; i++)
				{
					list.Add(new DefaultTypeParameter(fakeMethod, i));
				}
				fakeMethod.TypeParameters = list;
				typeParameterSubstitution = new TypeParameterSubstitution(null, list);
			}
			List<IParameter> list2 = new List<IParameter>();
			for (int j = 0; j < signature.RequiredParameterCount; j++)
			{
				IType type = signature.ParameterTypes[j];
				if (typeParameterSubstitution != null)
				{
					type = type.AcceptVisitor(typeParameterSubstitution);
				}
				list2.Add(new DefaultParameter(type, ""));
			}
			fakeMethod.Parameters = list2;
			return fakeMethod;
		}
	}

	public IEntity ResolveEntity(EntityHandle entityHandle, GenericContext context = default(GenericContext))
	{
		switch (entityHandle.Kind)
		{
		case HandleKind.TypeReference:
		case HandleKind.TypeDefinition:
		case HandleKind.TypeSpecification:
		case HandleKind.ExportedType:
			return ResolveType(entityHandle, context).GetDefinition();
		case HandleKind.MemberReference:
		{
			MemberReferenceHandle memberReferenceHandle = (MemberReferenceHandle)entityHandle;
			return metadata.GetMemberReference(memberReferenceHandle).GetKind() switch
			{
				MemberReferenceKind.Method => ResolveMethodReference(memberReferenceHandle, context, null, expandVarArgs: false), 
				MemberReferenceKind.Field => ResolveFieldReference(memberReferenceHandle, context), 
				_ => throw new BadImageFormatException("Unknown MemberReferenceKind"), 
			};
		}
		case HandleKind.MethodDefinition:
			return GetDefinition((MethodDefinitionHandle)entityHandle);
		case HandleKind.MethodSpecification:
			return ResolveMethodSpecification((MethodSpecificationHandle)entityHandle, context, expandVarArgs: false);
		case HandleKind.FieldDefinition:
			return GetDefinition((FieldDefinitionHandle)entityHandle);
		case HandleKind.EventDefinition:
			return GetDefinition((EventDefinitionHandle)entityHandle);
		case HandleKind.PropertyDefinition:
			return GetDefinition((PropertyDefinitionHandle)entityHandle);
		default:
			return null;
		}
	}

	private IField ResolveFieldReference(MemberReferenceHandle memberReferenceHandle, GenericContext context)
	{
		MemberReference memberReference = metadata.GetMemberReference(memberReferenceHandle);
		IType type = ResolveDeclaringType(memberReference.Parent, context);
		ITypeDefinition definition = type.GetDefinition();
		string name = metadata.GetString(memberReference.Name);
		IType signature = memberReference.DecodeFieldSignature(TypeProvider, new GenericContext(definition?.TypeParameters));
		IField field = Enumerable.FirstOrDefault<IField>(type.GetFields((IField f) => f.Name == name && CompareTypes(f.ReturnType, signature), GetMemberOptions.IgnoreInheritedMembers));
		if (field == null)
		{
			field = new FakeField(Compilation)
			{
				ReturnType = signature,
				Name = name,
				DeclaringType = type
			};
		}
		return field;
	}

	public MethodSignature<IType> DecodeMethodSignature(StandaloneSignatureHandle handle, GenericContext genericContext)
	{
		StandaloneSignature standaloneSignature = metadata.GetStandaloneSignature(handle);
		if (standaloneSignature.GetKind() != StandaloneSignatureKind.Method)
		{
			throw new BadImageFormatException("Expected Method signature");
		}
		MethodSignature<IType> methodSignature = standaloneSignature.DecodeMethodSignature(TypeProvider, genericContext);
		return new MethodSignature<IType>(methodSignature.Header, IntroduceTupleTypes(methodSignature.ReturnType), methodSignature.RequiredParameterCount, methodSignature.GenericParameterCount, ImmutableArray.CreateRange(methodSignature.ParameterTypes, IntroduceTupleTypes));
	}

	public ImmutableArray<IType> DecodeLocalSignature(StandaloneSignatureHandle handle, GenericContext genericContext)
	{
		StandaloneSignature standaloneSignature = metadata.GetStandaloneSignature(handle);
		if (standaloneSignature.GetKind() != StandaloneSignatureKind.LocalVariables)
		{
			throw new BadImageFormatException("Expected LocalVariables signature");
		}
		ImmutableArray<IType> items = standaloneSignature.DecodeLocalSignature(TypeProvider, genericContext);
		return ImmutableArray.CreateRange(items, IntroduceTupleTypes);
	}

	public IEnumerable<IAttribute> GetAssemblyAttributes()
	{
		AttributeListBuilder b = new AttributeListBuilder(this);
		if (metadata.IsAssembly)
		{
			AssemblyDefinition assemblyDefinition = metadata.GetAssemblyDefinition();
			b.Add(metadata.GetCustomAttributes(Handle.AssemblyDefinition), SymbolKind.Module);
			b.AddSecurityAttributes(assemblyDefinition.GetDeclarativeSecurityAttributes());
			if (assemblyDefinition.Version != null)
			{
				b.Add(KnownAttribute.AssemblyVersion, KnownTypeCode.String, assemblyDefinition.Version.ToString());
			}
			AddTypeForwarderAttributes(ref b);
		}
		return b.Build();
	}

	public IEnumerable<IAttribute> GetModuleAttributes()
	{
		AttributeListBuilder b = new AttributeListBuilder(this);
		b.Add(metadata.GetCustomAttributes(Handle.ModuleDefinition), SymbolKind.Module);
		if (!metadata.IsAssembly)
		{
			AddTypeForwarderAttributes(ref b);
		}
		return b.Build();
	}

	private void AddTypeForwarderAttributes(ref AttributeListBuilder b)
	{
		foreach (ExportedTypeHandle exportedType2 in metadata.ExportedTypes)
		{
			ExportedType exportedType = metadata.GetExportedType(exportedType2);
			if (exportedType.IsForwarder)
			{
				b.Add(KnownAttribute.TypeForwardedTo, KnownTypeCode.Type, ResolveForwardedType(exportedType));
			}
		}
	}

	private IType ResolveForwardedType(ExportedType forwarder)
	{
		IModule module = ResolveModule(forwarder);
		FullTypeName fullTypeName = forwarder.GetFullTypeName(metadata);
		if (module == null)
		{
			return new UnknownType(fullTypeName);
		}
		using (BusyManager.BusyLock busyLock = BusyManager.Enter(this))
		{
			if (busyLock.Success)
			{
				ITypeDefinition typeDefinition = module.GetTypeDefinition(fullTypeName);
				if (typeDefinition != null)
				{
					return typeDefinition;
				}
			}
		}
		return new UnknownType(fullTypeName);
		IModule ResolveModule(ExportedType type)
		{
			switch (type.Implementation.Kind)
			{
			case HandleKind.AssemblyFile:
				return this;
			case HandleKind.ExportedType:
			{
				ExportedType exportedType = metadata.GetExportedType((ExportedTypeHandle)type.Implementation);
				return ResolveModule(exportedType);
			}
			case HandleKind.AssemblyReference:
			{
				System.Reflection.Metadata.AssemblyReference assemblyReference = metadata.GetAssemblyReference((AssemblyReferenceHandle)type.Implementation);
				string b = metadata.GetString(assemblyReference.Name);
				foreach (IModule module2 in Compilation.Modules)
				{
					if (string.Equals(module2.AssemblyName, b, StringComparison.OrdinalIgnoreCase))
					{
						return module2;
					}
				}
				return null;
			}
			default:
				throw new BadImageFormatException("Expected implementation to be either an AssemblyFile, ExportedType or AssemblyReference.");
			}
		}
	}

	internal IType GetAttributeType(KnownAttribute attr)
	{
		IType type = LazyInit.VolatileRead(ref knownAttributeTypes[(int)attr]);
		if (type != null)
		{
			return type;
		}
		type = Compilation.FindType(attr.GetTypeName());
		return LazyInit.GetOrSet(ref knownAttributeTypes[(int)attr], type);
	}

	internal IAttribute MakeAttribute(KnownAttribute type)
	{
		IAttribute attribute = LazyInit.VolatileRead(ref knownAttributes[(int)type]);
		if (attribute != null)
		{
			return attribute;
		}
		attribute = new DefaultAttribute(GetAttributeType(type), ImmutableArray.Create<CustomAttributeTypedArgument<IType>>(), ImmutableArray.Create<CustomAttributeNamedArgument<IType>>());
		return LazyInit.GetOrSet(ref knownAttributes[(int)type], attribute);
	}

	internal bool IsVisible(FieldAttributes att)
	{
		att &= FieldAttributes.FieldAccessMask;
		return IncludeInternalMembers || att == FieldAttributes.Public || att == FieldAttributes.Family || att == FieldAttributes.FamORAssem;
	}

	internal bool IsVisible(MethodAttributes att)
	{
		att &= MethodAttributes.MemberAccessMask;
		return IncludeInternalMembers || att == MethodAttributes.Public || att == MethodAttributes.Family || att == MethodAttributes.FamORAssem;
	}
}
