#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal sealed class MetadataMethod : IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly MetadataModule module;

	private readonly MethodDefinitionHandle handle;

	private readonly MethodAttributes attributes;

	private readonly SymbolKind symbolKind;

	private readonly ITypeParameter[] typeParameters;

	private readonly EntityHandle accessorOwner;

	private ITypeDefinition declaringType;

	private string name;

	private IParameter[] parameters;

	private IType returnType;

	public bool IsExtensionMethod { get; }

	public EntityHandle MetadataToken => handle;

	public string Name
	{
		get
		{
			string text = LazyInit.VolatileRead(ref name);
			if (text != null)
			{
				return text;
			}
			MetadataReader metadata = module.metadata;
			MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
			return LazyInit.GetOrSet(ref name, metadata.GetString(methodDefinition.Name));
		}
	}

	public IReadOnlyList<ITypeParameter> TypeParameters => typeParameters;

	IReadOnlyList<IType> IMethod.TypeArguments => typeParameters;

	public SymbolKind SymbolKind => symbolKind;

	public bool IsConstructor => symbolKind == SymbolKind.Constructor;

	public bool IsDestructor => symbolKind == SymbolKind.Destructor;

	public bool IsOperator => symbolKind == SymbolKind.Operator;

	public bool IsAccessor => symbolKind == SymbolKind.Accessor;

	public bool HasBody => module.metadata.GetMethodDefinition(handle).HasBody();

	public IMember AccessorOwner
	{
		get
		{
			if (accessorOwner.IsNil)
			{
				return null;
			}
			if (accessorOwner.Kind == HandleKind.PropertyDefinition)
			{
				return module.GetDefinition((PropertyDefinitionHandle)accessorOwner);
			}
			if (accessorOwner.Kind == HandleKind.EventDefinition)
			{
				return module.GetDefinition((EventDefinitionHandle)accessorOwner);
			}
			return null;
		}
	}

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

	public bool IsExplicitInterfaceImplementation
	{
		get
		{
			if (Name.IndexOf('.') < 0)
			{
				return false;
			}
			MetadataTypeDefinition metadataTypeDefinition = (MetadataTypeDefinition)DeclaringTypeDefinition;
			return metadataTypeDefinition.HasOverrides(handle);
		}
	}

	public IEnumerable<IMember> ExplicitlyImplementedInterfaceMembers
	{
		get
		{
			MetadataTypeDefinition metadataTypeDefinition = (MetadataTypeDefinition)DeclaringTypeDefinition;
			return metadataTypeDefinition.GetOverrides(handle);
		}
	}

	IMember IMember.MemberDefinition => this;

	IMethod IMethod.ReducedFrom => null;

	TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

	public ITypeDefinition DeclaringTypeDefinition
	{
		get
		{
			ITypeDefinition typeDefinition = LazyInit.VolatileRead(ref declaringType);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
			MethodDefinition methodDefinition = module.metadata.GetMethodDefinition(handle);
			return LazyInit.GetOrSet(ref declaringType, module.GetDefinition(methodDefinition.GetDeclaringType()));
		}
	}

	public IType DeclaringType => DeclaringTypeDefinition;

	public IModule ParentModule => module;

	public ICompilation Compilation => module.Compilation;

	public Accessibility Accessibility => GetAccessibility(attributes);

	public bool IsStatic => (attributes & MethodAttributes.Static) != 0;

	public bool IsAbstract => (attributes & MethodAttributes.Abstract) != 0;

	public bool IsSealed => (attributes & (MethodAttributes.Static | MethodAttributes.Final | MethodAttributes.VtableLayoutMask | MethodAttributes.Abstract)) == MethodAttributes.Final;

	public bool IsVirtual => (attributes & (MethodAttributes.Final | MethodAttributes.Virtual | MethodAttributes.VtableLayoutMask | MethodAttributes.Abstract)) == (MethodAttributes.Virtual | MethodAttributes.VtableLayoutMask);

	public bool IsOverride => (attributes & (MethodAttributes.Virtual | MethodAttributes.VtableLayoutMask)) == MethodAttributes.Virtual;

	public bool IsOverridable => (attributes & (MethodAttributes.Virtual | MethodAttributes.Abstract)) != MethodAttributes.PrivateScope && (attributes & MethodAttributes.Final) == 0;

	public string FullName => DeclaringType?.FullName + "." + Name;

	public string ReflectionName => DeclaringType?.ReflectionName + "." + Name;

	public string Namespace => DeclaringType?.Namespace ?? string.Empty;

	internal MetadataMethod(MetadataModule module, MethodDefinitionHandle handle)
	{
		Debug.Assert(module != null);
		Debug.Assert(!handle.IsNil);
		this.module = module;
		this.handle = handle;
		MetadataReader metadata = module.metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		attributes = methodDefinition.Attributes;
		symbolKind = SymbolKind.Method;
		(EntityHandle, MethodSemanticsAttributes) semantics = module.PEFile.MethodSemanticsLookup.GetSemantics(handle);
		var (entityHandle, _) = semantics;
		if (semantics.Item2 != 0)
		{
			symbolKind = SymbolKind.Accessor;
			accessorOwner = entityHandle;
		}
		else if ((attributes & (MethodAttributes.SpecialName | MethodAttributes.RTSpecialName)) != MethodAttributes.PrivateScope)
		{
			string text = Name;
			if (text == ".cctor" || text == ".ctor")
			{
				symbolKind = SymbolKind.Constructor;
			}
			else if (text.StartsWith("op_", StringComparison.Ordinal))
			{
				symbolKind = SymbolKind.Operator;
			}
		}
		else if ((attributes & (MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig)) == (MethodAttributes.Family | MethodAttributes.Virtual | MethodAttributes.HideBySig))
		{
			string text2 = Name;
			if (text2 == "Finalize" && Parameters.Count == 0)
			{
				symbolKind = SymbolKind.Destructor;
			}
		}
		typeParameters = MetadataTypeParameter.Create(module, this, methodDefinition.GetGenericParameters());
		IsExtensionMethod = (attributes & MethodAttributes.Static) == MethodAttributes.Static && (module.TypeSystemOptions & TypeSystemOptions.ExtensionMethods) == TypeSystemOptions.ExtensionMethods && methodDefinition.GetCustomAttributes().HasKnownAttribute(metadata, KnownAttribute.Extension);
	}

	public override string ToString()
	{
		return $"{MetadataTokens.GetToken(handle):X8} {DeclaringType?.ReflectionName}.{Name}";
	}

	private void DecodeSignature()
	{
		MethodDefinition methodDefinition = module.metadata.GetMethodDefinition(handle);
		MethodSignature<IType> signature = methodDefinition.DecodeSignature<IType, GenericContext>(genericContext: new GenericContext(DeclaringType.TypeParameters, TypeParameters), provider: module.TypeProvider);
		var (newValue, newValue2) = DecodeSignature(module, this, signature, methodDefinition.GetParameters());
		LazyInit.GetOrSet(ref returnType, newValue);
		LazyInit.GetOrSet(ref parameters, newValue2);
	}

	internal static (IType, IParameter[]) DecodeSignature(MetadataModule module, IParameterizedMember owner, MethodSignature<IType> signature, ParameterHandleCollection? parameterHandles)
	{
		MetadataReader metadata = module.metadata;
		int i = 0;
		CustomAttributeHandleCollection? customAttributeHandleCollection = null;
		checked
		{
			IParameter[] array = new IParameter[signature.RequiredParameterCount + ((signature.Header.CallingConvention == SignatureCallingConvention.VarArgs) ? 1 : 0)];
			if (parameterHandles.HasValue)
			{
				foreach (ParameterHandle item2 in parameterHandles.Value)
				{
					Parameter parameter = metadata.GetParameter(item2);
					if (parameter.SequenceNumber == 0)
					{
						customAttributeHandleCollection = parameter.GetCustomAttributes();
					}
					else if (parameter.SequenceNumber > 0 && i < signature.RequiredParameterCount)
					{
						Debug.Assert(i < parameter.SequenceNumber);
						IType type;
						for (; i < parameter.SequenceNumber - 1; i++)
						{
							type = ApplyAttributeTypeVisitor.ApplyAttributesToType(signature.ParameterTypes[i], module.Compilation, null, metadata, module.TypeSystemOptions);
							array[i] = new DefaultParameter(type, string.Empty, owner, null, type.Kind == TypeKind.ByReference);
						}
						type = ApplyAttributeTypeVisitor.ApplyAttributesToType(signature.ParameterTypes[i], module.Compilation, parameter.GetCustomAttributes(), metadata, module.TypeSystemOptions);
						array[i] = new MetadataParameter(module, owner, type, item2);
						i++;
					}
				}
			}
			for (; i < signature.RequiredParameterCount; i++)
			{
				IType type = ApplyAttributeTypeVisitor.ApplyAttributesToType(signature.ParameterTypes[i], module.Compilation, null, metadata, module.TypeSystemOptions);
				array[i] = new DefaultParameter(type, string.Empty, owner, null, type.Kind == TypeKind.ByReference);
			}
			if (signature.Header.CallingConvention == SignatureCallingConvention.VarArgs)
			{
				array[i] = new DefaultParameter(SpecialType.ArgList, string.Empty, owner);
				i++;
			}
			Debug.Assert(i == array.Length);
			IType item = ApplyAttributeTypeVisitor.ApplyAttributesToType(signature.ReturnType, module.Compilation, customAttributeHandleCollection, metadata, module.TypeSystemOptions);
			return (item, array);
		}
	}

	private IType FindInteropType(string name)
	{
		return module.Compilation.FindType(new TopLevelTypeName("System.Runtime.InteropServices", name));
	}

	public IEnumerable<IAttribute> GetAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		MethodImplAttributes methodImplAttributes = methodDefinition.ImplAttributes & (MethodImplAttributes)(-4);
		MethodImport import = methodDefinition.GetImport();
		if ((attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PinvokeImpl && !import.Module.IsNil)
		{
			AttributeBuilder attributeBuilder = new AttributeBuilder(module, KnownAttribute.DllImport);
			attributeBuilder.AddFixedArg(KnownTypeCode.String, metadata.GetString(metadata.GetModuleReference(import.Module).Name));
			MethodImportAttributes methodImportAttributes = import.Attributes;
			if ((methodImportAttributes & MethodImportAttributes.BestFitMappingDisable) == MethodImportAttributes.BestFitMappingDisable)
			{
				attributeBuilder.AddNamedArg("BestFitMapping", KnownTypeCode.Boolean, false);
			}
			if ((methodImportAttributes & MethodImportAttributes.BestFitMappingEnable) == MethodImportAttributes.BestFitMappingEnable)
			{
				attributeBuilder.AddNamedArg("BestFitMapping", KnownTypeCode.Boolean, true);
			}
			CallingConvention callingConvention;
			switch (import.Attributes & MethodImportAttributes.CallingConventionMask)
			{
			case MethodImportAttributes.None:
				Debug.WriteLine($"P/Invoke calling convention not set on: {this}");
				callingConvention = (CallingConvention)0;
				break;
			case MethodImportAttributes.CallingConventionCDecl:
				callingConvention = CallingConvention.Cdecl;
				break;
			case MethodImportAttributes.CallingConventionFastCall:
				callingConvention = CallingConvention.FastCall;
				break;
			case MethodImportAttributes.CallingConventionStdCall:
				callingConvention = CallingConvention.StdCall;
				break;
			case MethodImportAttributes.CallingConventionThisCall:
				callingConvention = CallingConvention.ThisCall;
				break;
			case MethodImportAttributes.CallingConventionWinApi:
				callingConvention = CallingConvention.Winapi;
				break;
			default:
				throw new NotSupportedException("unknown calling convention");
			}
			if (callingConvention != CallingConvention.Winapi)
			{
				IType type = FindInteropType("CallingConvention");
				attributeBuilder.AddNamedArg("CallingConvention", type, (int)callingConvention);
			}
			CharSet charSet = CharSet.None;
			switch (import.Attributes & MethodImportAttributes.CharSetAuto)
			{
			case MethodImportAttributes.CharSetAnsi:
				charSet = CharSet.Ansi;
				break;
			case MethodImportAttributes.CharSetAuto:
				charSet = CharSet.Auto;
				break;
			case MethodImportAttributes.CharSetUnicode:
				charSet = CharSet.Unicode;
				break;
			}
			if (charSet != CharSet.None)
			{
				IType type2 = FindInteropType("CharSet");
				attributeBuilder.AddNamedArg("CharSet", type2, (int)charSet);
			}
			if (!import.Name.IsNil && import.Name != methodDefinition.Name)
			{
				attributeBuilder.AddNamedArg("EntryPoint", KnownTypeCode.String, metadata.GetString(import.Name));
			}
			if ((import.Attributes & MethodImportAttributes.ExactSpelling) == MethodImportAttributes.ExactSpelling)
			{
				attributeBuilder.AddNamedArg("ExactSpelling", KnownTypeCode.Boolean, true);
			}
			if ((methodImplAttributes & MethodImplAttributes.PreserveSig) == MethodImplAttributes.PreserveSig)
			{
				methodImplAttributes &= (MethodImplAttributes)(-129);
			}
			else
			{
				attributeBuilder.AddNamedArg("PreserveSig", KnownTypeCode.Boolean, false);
			}
			if ((import.Attributes & MethodImportAttributes.SetLastError) == MethodImportAttributes.SetLastError)
			{
				attributeBuilder.AddNamedArg("SetLastError", KnownTypeCode.Boolean, true);
			}
			if ((import.Attributes & MethodImportAttributes.ThrowOnUnmappableCharDisable) == MethodImportAttributes.ThrowOnUnmappableCharDisable)
			{
				attributeBuilder.AddNamedArg("ThrowOnUnmappableChar", KnownTypeCode.Boolean, false);
			}
			if ((import.Attributes & MethodImportAttributes.ThrowOnUnmappableCharEnable) == MethodImportAttributes.ThrowOnUnmappableCharEnable)
			{
				attributeBuilder.AddNamedArg("ThrowOnUnmappableChar", KnownTypeCode.Boolean, true);
			}
			attributeListBuilder.Add(attributeBuilder.Build());
		}
		if (methodImplAttributes == MethodImplAttributes.PreserveSig)
		{
			attributeListBuilder.Add(KnownAttribute.PreserveSig);
			methodImplAttributes = MethodImplAttributes.IL;
		}
		if (methodImplAttributes != MethodImplAttributes.IL)
		{
			attributeListBuilder.Add(KnownAttribute.MethodImpl, new TopLevelTypeName("System.Runtime.CompilerServices", "MethodImplOptions"), (int)methodImplAttributes);
		}
		attributeListBuilder.Add(methodDefinition.GetCustomAttributes(), symbolKind);
		attributeListBuilder.AddSecurityAttributes(methodDefinition.GetDeclarativeSecurityAttributes());
		return attributeListBuilder.Build();
	}

	public IEnumerable<IAttribute> GetReturnTypeAttributes()
	{
		AttributeListBuilder attributeListBuilder = new AttributeListBuilder(module);
		MetadataReader metadata = module.metadata;
		ParameterHandleCollection parameterHandleCollection = metadata.GetMethodDefinition(handle).GetParameters();
		if (parameterHandleCollection.Count > 0)
		{
			Parameter parameter = metadata.GetParameter(Enumerable.First<ParameterHandle>((IEnumerable<ParameterHandle>)parameterHandleCollection));
			if (parameter.SequenceNumber == 0)
			{
				attributeListBuilder.AddMarshalInfo(parameter.GetMarshallingDescriptor());
				attributeListBuilder.Add(parameter.GetCustomAttributes(), symbolKind);
			}
		}
		return attributeListBuilder.Build();
	}

	internal static Accessibility GetAccessibility(MethodAttributes attr)
	{
		return (attr & MethodAttributes.MemberAccessMask) switch
		{
			MethodAttributes.Public => Accessibility.Public, 
			MethodAttributes.Assembly => Accessibility.Internal, 
			MethodAttributes.Private => Accessibility.Private, 
			MethodAttributes.Family => Accessibility.Protected, 
			MethodAttributes.FamANDAssem => Accessibility.ProtectedAndInternal, 
			MethodAttributes.FamORAssem => Accessibility.ProtectedOrInternal, 
			_ => Accessibility.None, 
		};
	}

	public override bool Equals(object obj)
	{
		if (obj is MetadataMethod metadataMethod)
		{
			return handle == metadataMethod.handle && module.PEFile == metadataMethod.module.PEFile;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 0x5A00D671 ^ module.PEFile.GetHashCode() ^ handle.GetHashCode();
	}

	bool IMember.Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return Equals(obj);
	}

	public IMethod Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedMethod.Create(this, substitution);
	}

	IMember IMember.Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedMethod.Create(this, substitution);
	}
}
