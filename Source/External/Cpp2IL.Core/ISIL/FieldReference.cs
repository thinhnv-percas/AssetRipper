using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.ISIL;

public class FieldReference(FieldAnalysisContext field, LocalVariable local, int offset) : IOperand
{
    public FieldAnalysisContext Field = field;
    public LocalVariable Local = local;
    public int Offset = offset;

    /// <summary>
    /// The value type fields <see cref="Field"/> sits inside, outermost first, when the offset
    /// landed in the interior of a field rather than on its boundary. Empty for a direct field.
    /// </summary>
    public IReadOnlyList<FieldAnalysisContext> ContainingFields = [];

    /// <summary>
    /// AssetRipper: how many bytes the access that resolved to this field covered, or 0 when unknown.
    /// A store wider than the field reaches the fields that follow it as well.
    /// </summary>
    public int AccessSize;

    /// <summary>
    /// AssetRipper: the index into <see cref="Local"/> when the field is reached through an array
    /// element rather than off the local itself - <c>array[i].x</c> rather than <c>value.x</c>.
    /// </summary>
    /// <remarks>
    /// <see cref="Local"/> stays the array, so every pass that substitutes it - copy coalescing, SSA
    /// simplification - keeps working unchanged and substitutes the array, which is what it should do.
    /// Only the index is new, and it is walked wherever <see cref="ArrayAccess.Index"/> already is.
    /// The alternative, widening <see cref="Local"/> to an <c>IOperand</c>, breaks every one of those
    /// substitutions.
    /// </remarks>
    public IOperand? ElementIndex;

    public override string ToString()
    {
        var root = ElementIndex is null ? Local.Name : $"{Local.Name}[{ElementIndex}]";
        return $"{root}.{string.Join(".", ContainingFields.Select(f => f.Name).Append(Field.Name))} ({Field.FieldType.FullName})";
    }
}
