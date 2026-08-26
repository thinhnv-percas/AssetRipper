namespace Mon3.Cecil.Cil;

public enum ImportTargetKind : byte
{
	ImportNamespace = 1,
	ImportNamespaceInAssembly,
	ImportType,
	ImportXmlNamespaceWithAlias,
	ImportAlias,
	DefineAssemblyAlias,
	DefineNamespaceAlias,
	DefineNamespaceInAssemblyAlias,
	DefineTypeAlias
}
