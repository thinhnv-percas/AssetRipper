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

    public override string ToString()
        => $"{Local.Name}.{string.Join(".", ContainingFields.Select(f => f.Name).Append(Field.Name))} ({Field.FieldType.FullName})";
}
