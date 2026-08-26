namespace DecompTools.Decompiler.IL;

public abstract class TryInstruction : ILInstruction
{
	public static readonly SlotInfo TryBlockSlot = new SlotInfo("TryBlock");

	private ILInstruction tryBlock;

	public ILInstruction TryBlock
	{
		get
		{
			return tryBlock;
		}
		set
		{
			ValidateChild(value);
			SetChildInstruction(ref tryBlock, value, 0);
		}
	}

	protected TryInstruction(OpCode opCode, ILInstruction tryBlock)
		: base(opCode)
	{
		TryBlock = tryBlock;
	}
}
