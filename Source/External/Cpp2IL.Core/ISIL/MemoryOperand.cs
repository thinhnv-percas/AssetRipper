using System;
using System.Text;

namespace Cpp2IL.Core.ISIL;

/// <summary>
/// Memory operand in the format of [base+addend+index*scale]
/// </summary>
public struct MemoryOperand(IOperand? baseRegister = null, IOperand? indexRegister = null, long addend = 0, int scale = 0, int size = 0) : IOperand
{
    public IOperand? Base = baseRegister;
    public IOperand? Index = indexRegister;
    public long Addend = addend;
    public int Scale = scale;

    /// <summary>
    /// AssetRipper: how many bytes the access covers, or 0 when the lifter did not say. A store can be
    /// wider than the field its offset names - two adjacent <c>bool</c>s are written by one <c>strh</c>
    /// - and without the width the fields past the first are silently lost.
    /// </summary>
    public int Size = size;

    public bool IsConstant => Base == null && Index == null && Scale == 0;

    public override string ToString()
    {
        var sb = new StringBuilder("[");
        var needsPlus = false;

        if (Base != null)
        {
            sb.Append(Base);
            needsPlus = true;
        }

        if (Addend != 0)
        {
            if (needsPlus || Addend < 0)
                sb.Append(Addend > 0 ? '+' : '-');
            sb.Append($"{Math.Abs(Addend):X}");
            needsPlus = true;
        }

        if (Index != null)
        {
            if (needsPlus)
                sb.Append('+');
            sb.Append(Index);

            if (Scale > 1)
            {
                sb.Append('*');
                sb.Append(Scale);
            }
        }

        sb.Append(']');
        return sb.ToString();
    }
}
