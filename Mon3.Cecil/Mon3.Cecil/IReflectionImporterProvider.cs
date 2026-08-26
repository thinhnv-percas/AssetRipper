namespace Mon3.Cecil;

public interface IReflectionImporterProvider
{
	IReflectionImporter GetReflectionImporter(ModuleDefinition module);
}
