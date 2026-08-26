using dnlib.DotNet;

namespace dnSpy.Contracts.Utilities;

public readonly struct GacFileInfo
{
	public IAssembly Assembly { get; }

	public string Path { get; }

	internal GacFileInfo(IAssembly asm, string path)
	{
		Assembly = asm;
		Path = path;
	}
}
