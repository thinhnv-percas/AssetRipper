#define DEBUG
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal readonly struct AttributeListBuilder
{
	private readonly MetadataModule module;

	private readonly List<IAttribute> attributes;

	private const string InteropServices = "System.Runtime.InteropServices";

	public AttributeListBuilder(MetadataModule module)
	{
		Debug.Assert(module != null);
		this.module = module;
		attributes = new List<IAttribute>();
	}

	public AttributeListBuilder(MetadataModule module, int capacity)
	{
		Debug.Assert(module != null);
		this.module = module;
		attributes = new List<IAttribute>(capacity);
	}

	public void Add(IAttribute attr)
	{
		attributes.Add(attr);
	}

	public void Add(KnownAttribute type)
	{
		Add(module.MakeAttribute(type));
	}

	public void Add(KnownAttribute type, KnownTypeCode argType, object argValue)
	{
		Add(type, ImmutableArray.Create(new CustomAttributeTypedArgument<IType>(module.Compilation.FindType(argType), argValue)));
	}

	public void Add(KnownAttribute type, TopLevelTypeName argType, object argValue)
	{
		Add(type, ImmutableArray.Create(new CustomAttributeTypedArgument<IType>(module.Compilation.FindType(argType), argValue)));
	}

	public void Add(KnownAttribute type, ImmutableArray<CustomAttributeTypedArgument<IType>> fixedArguments)
	{
		Add(new DefaultAttribute(module.GetAttributeType(type), fixedArguments, ImmutableArray.Create<CustomAttributeNamedArgument<IType>>()));
	}

	internal void AddMarshalInfo(BlobHandle marshalInfo)
	{
		if (!marshalInfo.IsNil)
		{
			MetadataReader metadata = module.metadata;
			Add(ConvertMarshalInfo(metadata.GetBlobReader(marshalInfo)));
		}
	}

	private IAttribute ConvertMarshalInfo(BlobReader marshalInfo)
	{
		AttributeBuilder attributeBuilder = new AttributeBuilder(module, KnownAttribute.MarshalAs);
		IType type = module.Compilation.FindType(new TopLevelTypeName("System.Runtime.InteropServices", "UnmanagedType"));
		int num = marshalInfo.ReadByte();
		attributeBuilder.AddFixedArg(type, num);
		switch (num)
		{
		case 30:
		{
			if (!marshalInfo.TryReadCompressedInteger(out var num3))
			{
				num3 = 0;
			}
			attributeBuilder.AddNamedArg("SizeConst", KnownTypeCode.Int32, num3);
			if (marshalInfo.RemainingBytes > 0)
			{
				num = marshalInfo.ReadByte();
				if (num != 102)
				{
					attributeBuilder.AddNamedArg("ArraySubType", type, num);
				}
			}
			break;
		}
		case 29:
			if (marshalInfo.RemainingBytes > 0)
			{
				VarEnum varEnum = (VarEnum)marshalInfo.ReadByte();
				if (varEnum != VarEnum.VT_EMPTY)
				{
					TopLevelTypeName type2 = new TopLevelTypeName("System.Runtime.InteropServices", "VarEnum");
					attributeBuilder.AddNamedArg("SafeArraySubType", type2, (int)varEnum);
				}
			}
			break;
		case 42:
		{
			num = ((marshalInfo.RemainingBytes <= 0) ? 102 : marshalInfo.ReadByte());
			if (num != 80)
			{
				attributeBuilder.AddNamedArg("ArraySubType", type, num);
			}
			int num2 = (marshalInfo.TryReadCompressedInteger(out var value2) ? value2 : (-1));
			int num3 = (marshalInfo.TryReadCompressedInteger(out value2) ? value2 : (-1));
			int num4 = (marshalInfo.TryReadCompressedInteger(out value2) ? value2 : (-1));
			if (num3 >= 0)
			{
				attributeBuilder.AddNamedArg("SizeConst", KnownTypeCode.Int32, num3);
			}
			if (num4 != 0 && num2 >= 0)
			{
				attributeBuilder.AddNamedArg("SizeParamIndex", KnownTypeCode.Int16, checked((short)num2));
			}
			break;
		}
		case 44:
		{
			string text = marshalInfo.ReadSerializedString();
			string text2 = marshalInfo.ReadSerializedString();
			string text3 = marshalInfo.ReadSerializedString();
			string value = marshalInfo.ReadSerializedString();
			if (text3 != null)
			{
				attributeBuilder.AddNamedArg("MarshalType", KnownTypeCode.String, text3);
			}
			if (!string.IsNullOrEmpty(value))
			{
				attributeBuilder.AddNamedArg("MarshalCookie", KnownTypeCode.String, value);
			}
			break;
		}
		case 23:
			attributeBuilder.AddNamedArg("SizeConst", KnownTypeCode.Int32, marshalInfo.ReadCompressedInteger());
			break;
		}
		return attributeBuilder.Build();
	}

	public void Add(CustomAttributeHandleCollection attributes, SymbolKind target)
	{
		MetadataReader metadata = module.metadata;
		foreach (CustomAttributeHandle item in attributes)
		{
			System.Reflection.Metadata.CustomAttribute customAttribute = metadata.GetCustomAttribute(item);
			IMethod method = module.ResolveMethod(customAttribute.Constructor, default(GenericContext));
			IType declaringType = method.DeclaringType;
			if (!IgnoreAttribute(declaringType, target))
			{
				Add(new CustomAttribute(module, method, item));
			}
		}
	}

	private bool IgnoreAttribute(IType attributeType, SymbolKind target)
	{
		if (attributeType.DeclaringType != null || attributeType.TypeParameterCount != 0)
		{
			return false;
		}
		string text = attributeType.Namespace;
		if (!(text == "System.Runtime.CompilerServices"))
		{
			if (text == "System")
			{
				return attributeType.Name == "ParamArrayAttribute" && target == SymbolKind.Parameter;
			}
			return false;
		}
		TypeSystemOptions typeSystemOptions = module.TypeSystemOptions;
		return attributeType.Name switch
		{
			"DynamicAttribute" => (typeSystemOptions & TypeSystemOptions.Dynamic) != 0, 
			"TupleElementNamesAttribute" => (typeSystemOptions & TypeSystemOptions.Tuple) != 0, 
			"ExtensionAttribute" => (typeSystemOptions & TypeSystemOptions.ExtensionMethods) != 0, 
			"DecimalConstantAttribute" => (typeSystemOptions & TypeSystemOptions.DecimalConstants) != TypeSystemOptions.None && (target == SymbolKind.Field || target == SymbolKind.Parameter), 
			"IsReadOnlyAttribute" => (typeSystemOptions & TypeSystemOptions.ReadOnlyStructsAndParameters) != 0, 
			"IsByRefLikeAttribute" => (typeSystemOptions & TypeSystemOptions.RefStructs) != TypeSystemOptions.None && target == SymbolKind.TypeDefinition, 
			"IsUnmanagedAttribute" => (typeSystemOptions & TypeSystemOptions.UnmanagedConstraints) != TypeSystemOptions.None && target == SymbolKind.TypeParameter, 
			"NullableAttribute" => (typeSystemOptions & TypeSystemOptions.NullabilityAnnotations) != 0, 
			_ => false, 
		};
	}

	public void AddSecurityAttributes(DeclarativeSecurityAttributeHandleCollection securityDeclarations)
	{
		MetadataReader metadata = module.metadata;
		foreach (DeclarativeSecurityAttributeHandle item in securityDeclarations)
		{
			if (!item.IsNil)
			{
				try
				{
					AddSecurityAttributes(metadata.GetDeclarativeSecurityAttribute(item));
				}
				catch (EnumUnderlyingTypeResolveException)
				{
				}
			}
		}
	}

	public void AddSecurityAttributes(DeclarativeSecurityAttribute secDecl)
	{
		IType type = module.Compilation.FindType(new TopLevelTypeName("System.Security.Permissions", "SecurityAction"));
		CustomAttributeTypedArgument<IType> securityAction = new CustomAttributeTypedArgument<IType>(type, (int)secDecl.Action);
		MetadataReader metadata = module.metadata;
		BlobReader reader = metadata.GetBlobReader(secDecl.PermissionSet);
		if (reader.ReadByte() == 46)
		{
			int num = reader.ReadCompressedInteger();
			for (int i = 0; i < num; i = checked(i + 1))
			{
				Add(ReadBinarySecurityAttribute(ref reader, securityAction));
			}
		}
		else
		{
			reader.Reset();
			Add(ReadXmlSecurityAttribute(ref reader, securityAction));
		}
	}

	private IAttribute ReadXmlSecurityAttribute(ref BlobReader reader, CustomAttributeTypedArgument<IType> securityAction)
	{
		string value = reader.ReadUTF16(reader.RemainingBytes);
		AttributeBuilder attributeBuilder = new AttributeBuilder(module, KnownAttribute.PermissionSet);
		attributeBuilder.AddFixedArg(securityAction);
		attributeBuilder.AddNamedArg("XML", KnownTypeCode.String, value);
		return attributeBuilder.Build();
	}

	private IAttribute ReadBinarySecurityAttribute(ref BlobReader reader, CustomAttributeTypedArgument<IType> securityAction)
	{
		string name = reader.ReadSerializedString();
		IType typeFromSerializedName = module.TypeProvider.GetTypeFromSerializedName(name);
		reader.ReadCompressedInteger();
		int count = reader.ReadCompressedInteger();
		ImmutableArray<CustomAttributeNamedArgument<IType>> namedArguments = new CustomAttributeDecoder<IType>(module.TypeProvider, module.metadata).DecodeNamedArguments(ref reader, count);
		return new DefaultAttribute(typeFromSerializedName, ImmutableArray.Create(securityAction), namedArguments);
	}

	public IAttribute[] Build()
	{
		if (attributes.Count == 0)
		{
			return Empty<IAttribute>.Array;
		}
		return attributes.ToArray();
	}
}
