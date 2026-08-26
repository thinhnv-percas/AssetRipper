namespace Mon3.Cecil;

public interface IMetadataImporterProvider
{
	IMetadataImporter GetMetadataImporter(ModuleDefinition module);
}
