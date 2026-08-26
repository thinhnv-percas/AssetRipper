using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

public sealed class ModuleCreationOptions
{
	internal static readonly ModuleCreationOptions Default = new ModuleCreationOptions();

	internal const PdbReaderOptions DefaultPdbReaderOptions = PdbReaderOptions.None;

	public ModuleContext Context { get; set; }

	public PdbReaderOptions PdbOptions { get; set; } = PdbReaderOptions.None;

	public object PdbFileOrData { get; set; }

	public bool TryToLoadPdbFromDisk { get; set; } = true;

	public AssemblyRef CorLibAssemblyRef { get; set; }

	public ModuleCreationOptions()
	{
	}

	public ModuleCreationOptions(ModuleContext context)
	{
		Context = context;
	}
}
