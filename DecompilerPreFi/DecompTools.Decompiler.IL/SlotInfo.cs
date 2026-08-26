namespace DecompTools.Decompiler.IL;

public class SlotInfo
{
	public static SlotInfo None = new SlotInfo("<no slot>");

	public readonly string Name;

	public readonly bool CanInlineInto;

	public readonly bool IsCollection;

	public SlotInfo(string name, bool canInlineInto = false, bool isCollection = false)
	{
		IsCollection = isCollection;
		Name = name;
		CanInlineInto = canInlineInto;
	}

	public override string ToString()
	{
		return Name;
	}
}
