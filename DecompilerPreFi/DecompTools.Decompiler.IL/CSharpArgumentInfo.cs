using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public struct CSharpArgumentInfo
{
	public string Name { get; set; }

	public CSharpArgumentInfoFlags Flags { get; set; }

	public IType CompileTimeType { get; set; }

	public bool HasFlag(CSharpArgumentInfoFlags flag)
	{
		return (Flags & flag) != 0;
	}
}
