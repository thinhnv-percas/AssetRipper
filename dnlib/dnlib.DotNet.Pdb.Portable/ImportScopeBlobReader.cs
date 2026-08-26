#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using dnlib.DotNet.MD;

namespace dnlib.DotNet.Pdb.Portable;

internal readonly struct ImportScopeBlobReader
{
	private readonly ModuleDef module;

	private readonly BlobStream blobStream;

	public ImportScopeBlobReader(ModuleDef module, BlobStream blobStream)
	{
		this.module = module;
		this.blobStream = blobStream;
	}

	public void Read(uint imports, IList<PdbImport> result)
	{
		if (imports == 0 || !blobStream.TryCreateReader(imports, out var reader))
		{
			return;
		}
		while (reader.Position < reader.Length)
		{
			PdbImportDefinitionKind pdbImportDefinitionKind = ImportDefinitionKindUtils.ToPdbImportDefinitionKind(reader.ReadCompressedUInt32());
			PdbImport pdbImport;
			switch (pdbImportDefinitionKind)
			{
			case PdbImportDefinitionKind.ImportNamespace:
			{
				string targetNamespace = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbImportNamespace(targetNamespace);
				break;
			}
			case PdbImportDefinitionKind.ImportAssemblyNamespace:
			{
				AssemblyRef targetAssembly = TryReadAssemblyRef(reader.ReadCompressedUInt32());
				string targetNamespace = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbImportAssemblyNamespace(targetAssembly, targetNamespace);
				break;
			}
			case PdbImportDefinitionKind.ImportType:
			{
				ITypeDefOrRef targetType = TryReadType(reader.ReadCompressedUInt32());
				pdbImport = new PdbImportType(targetType);
				break;
			}
			case PdbImportDefinitionKind.ImportXmlNamespace:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				string targetNamespace = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbImportXmlNamespace(alias, targetNamespace);
				break;
			}
			case PdbImportDefinitionKind.ImportAssemblyReferenceAlias:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbImportAssemblyReferenceAlias(alias);
				break;
			}
			case PdbImportDefinitionKind.AliasAssemblyReference:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				AssemblyRef targetAssembly = TryReadAssemblyRef(reader.ReadCompressedUInt32());
				pdbImport = new PdbAliasAssemblyReference(alias, targetAssembly);
				break;
			}
			case PdbImportDefinitionKind.AliasNamespace:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				string targetNamespace = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbAliasNamespace(alias, targetNamespace);
				break;
			}
			case PdbImportDefinitionKind.AliasAssemblyNamespace:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				AssemblyRef targetAssembly = TryReadAssemblyRef(reader.ReadCompressedUInt32());
				string targetNamespace = ReadUTF8(reader.ReadCompressedUInt32());
				pdbImport = new PdbAliasAssemblyNamespace(alias, targetAssembly, targetNamespace);
				break;
			}
			case PdbImportDefinitionKind.AliasType:
			{
				string alias = ReadUTF8(reader.ReadCompressedUInt32());
				ITypeDefOrRef targetType = TryReadType(reader.ReadCompressedUInt32());
				pdbImport = new PdbAliasType(alias, targetType);
				break;
			}
			case (PdbImportDefinitionKind)(-1):
				pdbImport = null;
				break;
			default:
				Debug.Fail("Unknown import definition kind: " + pdbImportDefinitionKind);
				pdbImport = null;
				break;
			}
			if (pdbImport != null)
			{
				result.Add(pdbImport);
			}
		}
		Debug.Assert(reader.Position == reader.Length);
	}

	private ITypeDefOrRef TryReadType(uint codedToken)
	{
		bool flag = CodedToken.TypeDefOrRef.Decode(codedToken, out uint token);
		Debug.Assert(flag);
		if (!flag)
		{
			return null;
		}
		ITypeDefOrRef typeDefOrRef = module.ResolveToken(token) as ITypeDefOrRef;
		Debug.Assert(typeDefOrRef != null);
		return typeDefOrRef;
	}

	private AssemblyRef TryReadAssemblyRef(uint rid)
	{
		AssemblyRef assemblyRef = module.ResolveToken(587202560 + rid) as AssemblyRef;
		Debug.Assert(assemblyRef != null);
		return assemblyRef;
	}

	private string ReadUTF8(uint offset)
	{
		if (!blobStream.TryCreateReader(offset, out var reader))
		{
			return string.Empty;
		}
		return reader.ReadUtf8String((int)reader.BytesLeft);
	}
}
