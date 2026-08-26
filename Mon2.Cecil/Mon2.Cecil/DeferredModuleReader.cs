using Mon2.Cecil.PE;

namespace Mon2.Cecil;

internal sealed class DeferredModuleReader : ModuleReader
{
	public DeferredModuleReader(Image image)
		: base(image, ReadingMode.Deferred)
	{
	}

	protected override void ReadModule()
	{
		module.Read(module, delegate(ModuleDefinition module, MetadataReader reader)
		{
			ReadModuleManifest(reader);
			return module;
		});
	}
}
