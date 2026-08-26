using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Metadata;

public static class MetadataExtensions
{
	internal static readonly TypeProvider minimalCorlibTypeProvider = new TypeProvider(new SimpleCompilation(MinimalCorlib.Instance));

	public static ICustomAttributeTypeProvider<IType> MinimalAttributeTypeProvider => minimalCorlibTypeProvider;

	public static ISignatureTypeProvider<IType, DecompTools.Decompiler.TypeSystem.GenericContext> MinimalSignatureTypeProvider => minimalCorlibTypeProvider;

	private static HashAlgorithm GetHashAlgorithm(this MetadataReader reader)
	{
		return (HashAlgorithm)(reader.GetAssemblyDefinition().HashAlgorithm switch
		{
			AssemblyHashAlgorithm.None => SHA1.Create(), 
			AssemblyHashAlgorithm.MD5 => MD5.Create(), 
			AssemblyHashAlgorithm.Sha1 => SHA1.Create(), 
			AssemblyHashAlgorithm.Sha256 => SHA256.Create(), 
			AssemblyHashAlgorithm.Sha384 => SHA384.Create(), 
			AssemblyHashAlgorithm.Sha512 => SHA512.Create(), 
			_ => SHA1.Create(), 
		});
	}

	private static string CalculatePublicKeyToken(BlobHandle blob, MetadataReader reader)
	{
		byte[] input = reader.GetHashAlgorithm().ComputeHash(reader.GetBlobBytes(blob));
		return Enumerable.Reverse<byte>(input.TakeLast(8)).ToHexString(8);
	}

	public static string GetFullAssemblyName(this MetadataReader reader)
	{
		if (!reader.IsAssembly)
		{
			return string.Empty;
		}
		AssemblyDefinition assemblyDefinition = reader.GetAssemblyDefinition();
		string text = "null";
		if (!assemblyDefinition.PublicKey.IsNil)
		{
			text = CalculatePublicKeyToken(assemblyDefinition.PublicKey, reader);
		}
		return reader.GetString(assemblyDefinition.Name) + ", " + $"Version={assemblyDefinition.Version}, " + "Culture=" + (assemblyDefinition.Culture.IsNil ? "neutral" : reader.GetString(assemblyDefinition.Culture)) + ", PublicKeyToken=" + text;
	}

	public static string GetFullAssemblyName(this System.Reflection.Metadata.AssemblyReference reference, MetadataReader reader)
	{
		string text = "null";
		if (!reference.PublicKeyOrToken.IsNil)
		{
			text = (((reference.Flags & AssemblyFlags.PublicKey) == 0) ? reader.GetBlobBytes(reference.PublicKeyOrToken).ToHexString(8) : CalculatePublicKeyToken(reference.PublicKeyOrToken, reader));
		}
		string text2 = "";
		if ((reference.Flags & AssemblyFlags.Retargetable) != 0)
		{
			text2 = ", Retargetable=true";
		}
		return reader.GetString(reference.Name) + ", " + $"Version={reference.Version}, " + "Culture=" + (reference.Culture.IsNil ? "neutral" : reader.GetString(reference.Culture)) + ", PublicKeyToken=" + text + text2;
	}

	public static string ToHexString(this IEnumerable<byte> bytes, int estimatedLength)
	{
		StringBuilder stringBuilder = new StringBuilder(checked(estimatedLength * 2));
		foreach (byte @byte in bytes)
		{
			stringBuilder.AppendFormat("{0:x2}", @byte);
		}
		return stringBuilder.ToString();
	}

	public static IEnumerable<TypeDefinitionHandle> GetTopLevelTypeDefinitions(this MetadataReader reader)
	{
		foreach (TypeDefinitionHandle handle in reader.TypeDefinitions)
		{
			if (reader.GetTypeDefinition(handle).GetDeclaringType().IsNil)
			{
				yield return handle;
			}
		}
	}

	public static string ToILNameString(this FullTypeName typeName)
	{
		string text;
		if (typeName.IsNested)
		{
			text = typeName.Name;
			int nestedTypeAdditionalTypeParameterCount = typeName.GetNestedTypeAdditionalTypeParameterCount(checked(typeName.NestingLevel - 1));
			if (nestedTypeAdditionalTypeParameterCount > 0)
			{
				text = text + "`" + nestedTypeAdditionalTypeParameterCount;
			}
			text = DisassemblerHelpers.Escape(text);
			return typeName.GetDeclaringType().ToILNameString() + "/" + text;
		}
		if (!string.IsNullOrEmpty(typeName.TopLevelTypeName.Namespace))
		{
			text = typeName.TopLevelTypeName.Namespace + "." + typeName.Name;
			if (typeName.TypeParameterCount > 0)
			{
				text = text + "`" + typeName.TypeParameterCount;
			}
		}
		else
		{
			text = typeName.Name;
			if (typeName.TypeParameterCount > 0)
			{
				text = text + "`" + typeName.TypeParameterCount;
			}
		}
		return DisassemblerHelpers.Escape(text);
	}

	public static IModuleReference GetDeclaringModule(this TypeReferenceHandle handle, MetadataReader reader)
	{
		TypeReference typeReference = reader.GetTypeReference(handle);
		return typeReference.ResolutionScope.Kind switch
		{
			HandleKind.TypeReference => ((TypeReferenceHandle)typeReference.ResolutionScope).GetDeclaringModule(reader), 
			HandleKind.AssemblyReference => new DefaultAssemblyReference(reader.GetString(reader.GetAssemblyReference((AssemblyReferenceHandle)typeReference.ResolutionScope).Name)), 
			HandleKind.ModuleReference => new DefaultAssemblyReference(reader.GetString(reader.GetModuleReference((ModuleReferenceHandle)typeReference.ResolutionScope).Name)), 
			_ => DefaultAssemblyReference.CurrentAssembly, 
		};
	}

	public static PrimitiveTypeCode ToPrimitiveTypeCode(this KnownTypeCode typeCode)
	{
		return typeCode switch
		{
			KnownTypeCode.Object => PrimitiveTypeCode.Object, 
			KnownTypeCode.Boolean => PrimitiveTypeCode.Boolean, 
			KnownTypeCode.Char => PrimitiveTypeCode.Char, 
			KnownTypeCode.SByte => PrimitiveTypeCode.SByte, 
			KnownTypeCode.Byte => PrimitiveTypeCode.Byte, 
			KnownTypeCode.Int16 => PrimitiveTypeCode.Int16, 
			KnownTypeCode.UInt16 => PrimitiveTypeCode.UInt16, 
			KnownTypeCode.Int32 => PrimitiveTypeCode.Int32, 
			KnownTypeCode.UInt32 => PrimitiveTypeCode.UInt32, 
			KnownTypeCode.Int64 => PrimitiveTypeCode.Int64, 
			KnownTypeCode.UInt64 => PrimitiveTypeCode.UInt64, 
			KnownTypeCode.Single => PrimitiveTypeCode.Single, 
			KnownTypeCode.Double => PrimitiveTypeCode.Double, 
			KnownTypeCode.String => PrimitiveTypeCode.String, 
			KnownTypeCode.Void => PrimitiveTypeCode.Void, 
			KnownTypeCode.TypedReference => PrimitiveTypeCode.TypedReference, 
			KnownTypeCode.IntPtr => PrimitiveTypeCode.IntPtr, 
			KnownTypeCode.UIntPtr => PrimitiveTypeCode.UIntPtr, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static KnownTypeCode ToKnownTypeCode(this PrimitiveTypeCode typeCode)
	{
		return typeCode switch
		{
			PrimitiveTypeCode.Boolean => KnownTypeCode.Boolean, 
			PrimitiveTypeCode.Byte => KnownTypeCode.Byte, 
			PrimitiveTypeCode.SByte => KnownTypeCode.SByte, 
			PrimitiveTypeCode.Char => KnownTypeCode.Char, 
			PrimitiveTypeCode.Int16 => KnownTypeCode.Int16, 
			PrimitiveTypeCode.UInt16 => KnownTypeCode.UInt16, 
			PrimitiveTypeCode.Int32 => KnownTypeCode.Int32, 
			PrimitiveTypeCode.UInt32 => KnownTypeCode.UInt32, 
			PrimitiveTypeCode.Int64 => KnownTypeCode.Int64, 
			PrimitiveTypeCode.UInt64 => KnownTypeCode.UInt64, 
			PrimitiveTypeCode.Single => KnownTypeCode.Single, 
			PrimitiveTypeCode.Double => KnownTypeCode.Double, 
			PrimitiveTypeCode.IntPtr => KnownTypeCode.IntPtr, 
			PrimitiveTypeCode.UIntPtr => KnownTypeCode.UIntPtr, 
			PrimitiveTypeCode.Object => KnownTypeCode.Object, 
			PrimitiveTypeCode.String => KnownTypeCode.String, 
			PrimitiveTypeCode.TypedReference => KnownTypeCode.TypedReference, 
			PrimitiveTypeCode.Void => KnownTypeCode.Void, 
			_ => KnownTypeCode.None, 
		};
	}

	public static IEnumerable<ModuleReferenceHandle> GetModuleReferences(this MetadataReader metadata)
	{
		int rowCount = metadata.GetTableRowCount(TableIndex.ModuleRef);
		for (int row = 1; row <= rowCount; row = checked(row + 1))
		{
			yield return MetadataTokens.ModuleReferenceHandle(row);
		}
	}
}
