using System;
using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.Transforms;

internal class LocalFunctionDecompiler : IILTransform
{
	private struct FindTypeDecoder : ISignatureTypeProvider<bool, Unit>, ISimpleTypeProvider<bool>, IConstructedTypeProvider<bool>, ISZArrayTypeProvider<bool>
	{
		private TypeDefinitionHandle handle;

		public FindTypeDecoder(TypeDefinitionHandle handle)
		{
			this.handle = handle;
		}

		public bool GetArrayType(bool elementType, ArrayShape shape)
		{
			return elementType;
		}

		public bool GetByReferenceType(bool elementType)
		{
			return elementType;
		}

		public bool GetFunctionPointerType(MethodSignature<bool> signature)
		{
			return false;
		}

		public bool GetGenericInstantiation(bool genericType, ImmutableArray<bool> typeArguments)
		{
			return genericType;
		}

		public bool GetGenericMethodParameter(Unit genericContext, int index)
		{
			return false;
		}

		public bool GetGenericTypeParameter(Unit genericContext, int index)
		{
			return false;
		}

		public bool GetModifiedType(bool modifier, bool unmodifiedType, bool isRequired)
		{
			return unmodifiedType;
		}

		public bool GetPinnedType(bool elementType)
		{
			return elementType;
		}

		public bool GetPointerType(bool elementType)
		{
			return elementType;
		}

		public bool GetPrimitiveType(PrimitiveTypeCode typeCode)
		{
			return false;
		}

		public bool GetSZArrayType(bool elementType)
		{
			return false;
		}

		public bool GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
		{
			return this.handle == handle;
		}

		public bool GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
		{
			return false;
		}

		public bool GetTypeFromSpecification(MetadataReader reader, Unit genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
		{
			return reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
		}
	}

	private static readonly Regex functionNameRegex;

	public void Run(ILFunction function, ILTransformContext context)
	{
		throw new NotImplementedException();
	}

	public static bool IsLocalFunctionMethod(PEFile module, MethodDefinitionHandle methodHandle)
	{
		MetadataReader metadata = module.Metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(methodHandle);
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		if ((methodDefinition.Attributes & MethodAttributes.Assembly) == 0 || (!methodDefinition.IsCompilerGenerated(metadata) && !declaringType.IsCompilerGenerated(metadata)))
		{
			return false;
		}
		if (!ParseLocalFunctionName(metadata.GetString(methodDefinition.Name), out var _, out var _))
		{
			return false;
		}
		return true;
	}

	public static bool IsLocalFunctionDisplayClass(PEFile module, TypeDefinitionHandle typeHandle)
	{
		MetadataReader metadata = module.Metadata;
		TypeDefinition typeDefinition = metadata.GetTypeDefinition(typeHandle);
		if ((typeDefinition.Attributes & TypeAttributes.NestedPrivate) == 0)
		{
			return false;
		}
		if (!typeDefinition.HasGeneratedName(metadata))
		{
			return false;
		}
		TypeDefinitionHandle declaringType = typeDefinition.GetDeclaringType();
		foreach (MethodDefinitionHandle method in metadata.GetTypeDefinition(declaringType).GetMethods())
		{
			if (!IsLocalFunctionMethod(module, method) || !metadata.GetMethodDefinition(method).DecodeSignature(new FindTypeDecoder(typeHandle), default(Unit)).ParameterTypes.Any())
			{
				continue;
			}
			return true;
		}
		return false;
	}

	private static bool ParseLocalFunctionName(string name, out string callerName, out string functionName)
	{
		callerName = null;
		functionName = null;
		if (string.IsNullOrWhiteSpace(name))
		{
			return false;
		}
		Match val = functionNameRegex.Match(name);
		callerName = ((Capture)val.Groups[1]).Value;
		functionName = ((Capture)val.Groups[2]).Value;
		return ((Group)val).Success;
	}

	static LocalFunctionDecompiler()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		functionNameRegex = new Regex("^<(.*)>g__(.*)\\|{0,1}\\d+(_\\d+)?$", (RegexOptions)8);
	}
}
