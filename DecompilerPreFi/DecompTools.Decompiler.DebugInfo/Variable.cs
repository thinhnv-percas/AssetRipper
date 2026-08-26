namespace DecompTools.Decompiler.DebugInfo;

public struct Variable
{
	public int Index { get; }

	public string Name { get; }

	public Variable(int index, string name)
	{
		Index = index;
		Name = name;
	}
}
