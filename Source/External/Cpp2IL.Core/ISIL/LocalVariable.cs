using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.ISIL;

public class LocalVariable(string name, Register register, TypeAnalysisContext? type = null) : IOperand
{
    public string Name = name;
    public Register Register = register;

    /// <summary>
    /// null if typeprop has not been done yet, or if the type could not be determined.
    /// </summary>
    public TypeAnalysisContext? Type = type;

    public bool IsThis = false;
    public bool IsReturn = false;
    public bool IsMethodInfo = false;

    /// <summary>
    /// AssetRipper: iteration 067 - which of the method's declared parameters this local is, or -1. A parameter whose
    /// register nothing reads has no local, so the position of a local in <c>ParameterLocals</c> is not its parameter's.
    /// </summary>
    public int ParameterIndex = -1;

    /// <summary>AssetRipper: the entry value of the hidden return buffer register, which the method's result is written into.</summary>
    public bool IsReturnBuffer = false;

    public override string ToString() => Type == null ? $"{Name} @ {Register}" : $"{Name} @ {Register} ({Type.FullName})";
}
