namespace Cpp2IL.Core.ISIL;

public struct StackOffset(int offset) : IOperand
{
    public int Offset = offset;

    /// <summary>
    /// AssetRipper: iteration 067 - how many bytes a store to this slot writes, or 0 when unknown. A slot is named by its
    /// offset alone, so without the width a 16-byte register written over four floats reads as a write of the first.
    /// </summary>
    public int Size;

    public override string ToString() => $"stack[{(Offset < 0 ? ("-" + (-Offset).ToString("X")) : Offset.ToString("X"))}]";
}
