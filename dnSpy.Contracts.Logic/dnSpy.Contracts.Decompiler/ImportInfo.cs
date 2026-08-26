namespace dnSpy.Contracts.Decompiler;

public readonly struct ImportInfo
{
	public ImportInfoKind TargetKind { get; }

	public VBImportScopeKind VBImportScopeKind { get; }

	public string Target { get; }

	public string Alias { get; }

	public string ExternAlias { get; }

	public ImportInfo(ImportInfoKind targetKind, string target = null, string alias = null, string externAlias = null, VBImportScopeKind importScopeKind = VBImportScopeKind.None)
	{
		TargetKind = targetKind;
		Target = target;
		Alias = alias;
		ExternAlias = externAlias;
		VBImportScopeKind = importScopeKind;
	}

	public static ImportInfo CreateNamespace(string @namespace)
	{
		return new ImportInfo(ImportInfoKind.Namespace, @namespace);
	}

	public static ImportInfo CreateNamespace(string @namespace, string externAlias)
	{
		return new ImportInfo(ImportInfoKind.Namespace, @namespace, null, externAlias);
	}

	public static ImportInfo CreateType(string type)
	{
		return new ImportInfo(ImportInfoKind.Type, type);
	}

	public static ImportInfo CreateNamespaceAlias(string @namespace, string alias)
	{
		return new ImportInfo(ImportInfoKind.Namespace, @namespace, alias);
	}

	public static ImportInfo CreateTypeAlias(string type, string alias)
	{
		return new ImportInfo(ImportInfoKind.Type, type, alias);
	}

	public static ImportInfo CreateNamespaceAlias(string @namespace, string alias, string externAlias)
	{
		return new ImportInfo(ImportInfoKind.Namespace, @namespace, alias, externAlias);
	}

	public static ImportInfo CreateAssembly(string externAlias)
	{
		return new ImportInfo(ImportInfoKind.Assembly, null, null, externAlias);
	}

	public static ImportInfo CreateAssembly(string externAlias, string assembly)
	{
		return new ImportInfo(ImportInfoKind.Assembly, assembly, null, externAlias);
	}

	public static ImportInfo CreateCurrentNamespace()
	{
		return new ImportInfo(ImportInfoKind.CurrentNamespace, string.Empty);
	}

	public static ImportInfo CreateNamespaceOrType(string namespaceOrType, string alias, VBImportScopeKind importScopeKind)
	{
		return new ImportInfo(ImportInfoKind.NamespaceOrType, namespaceOrType, alias, null, importScopeKind);
	}

	public static ImportInfo CreateXmlNamespace(string xmlNamespace, string alias, VBImportScopeKind importScopeKind)
	{
		return new ImportInfo(ImportInfoKind.XmlNamespace, xmlNamespace, alias, null, importScopeKind);
	}

	public static ImportInfo CreateType(string type, VBImportScopeKind importScopeKind)
	{
		return new ImportInfo(ImportInfoKind.Type, type, null, null, importScopeKind);
	}

	public static ImportInfo CreateNamespace(string @namespace, VBImportScopeKind importScopeKind)
	{
		return new ImportInfo(ImportInfoKind.Namespace, @namespace, null, null, importScopeKind);
	}

	public static ImportInfo CreateMethodToken(string token, VBImportScopeKind importScopeKind)
	{
		return new ImportInfo(ImportInfoKind.MethodToken, token, null, null, importScopeKind);
	}

	public static ImportInfo CreateDefaultNamespace(string @namespace)
	{
		return new ImportInfo(ImportInfoKind.DefaultNamespace, @namespace);
	}
}
