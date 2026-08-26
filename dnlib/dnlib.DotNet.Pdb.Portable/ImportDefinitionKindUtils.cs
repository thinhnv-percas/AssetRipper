#define DEBUG
using System.Diagnostics;

namespace dnlib.DotNet.Pdb.Portable;

internal static class ImportDefinitionKindUtils
{
	public const PdbImportDefinitionKind UNKNOWN_IMPORT_KIND = (PdbImportDefinitionKind)(-1);

	public static PdbImportDefinitionKind ToPdbImportDefinitionKind(uint value)
	{
		switch (value)
		{
		case 1u:
			return PdbImportDefinitionKind.ImportNamespace;
		case 2u:
			return PdbImportDefinitionKind.ImportAssemblyNamespace;
		case 3u:
			return PdbImportDefinitionKind.ImportType;
		case 4u:
			return PdbImportDefinitionKind.ImportXmlNamespace;
		case 5u:
			return PdbImportDefinitionKind.ImportAssemblyReferenceAlias;
		case 6u:
			return PdbImportDefinitionKind.AliasAssemblyReference;
		case 7u:
			return PdbImportDefinitionKind.AliasNamespace;
		case 8u:
			return PdbImportDefinitionKind.AliasAssemblyNamespace;
		case 9u:
			return PdbImportDefinitionKind.AliasType;
		default:
			Debug.Fail("Unknown import definition kind: 0x" + value.ToString("X"));
			return (PdbImportDefinitionKind)(-1);
		}
	}

	public static bool ToImportDefinitionKind(PdbImportDefinitionKind kind, out uint rawKind)
	{
		switch (kind)
		{
		case PdbImportDefinitionKind.ImportNamespace:
			rawKind = 1u;
			return true;
		case PdbImportDefinitionKind.ImportAssemblyNamespace:
			rawKind = 2u;
			return true;
		case PdbImportDefinitionKind.ImportType:
			rawKind = 3u;
			return true;
		case PdbImportDefinitionKind.ImportXmlNamespace:
			rawKind = 4u;
			return true;
		case PdbImportDefinitionKind.ImportAssemblyReferenceAlias:
			rawKind = 5u;
			return true;
		case PdbImportDefinitionKind.AliasAssemblyReference:
			rawKind = 6u;
			return true;
		case PdbImportDefinitionKind.AliasNamespace:
			rawKind = 7u;
			return true;
		case PdbImportDefinitionKind.AliasAssemblyNamespace:
			rawKind = 8u;
			return true;
		case PdbImportDefinitionKind.AliasType:
			rawKind = 9u;
			return true;
		default:
			rawKind = uint.MaxValue;
			return false;
		}
	}
}
