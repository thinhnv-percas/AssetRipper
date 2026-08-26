namespace DecompTools.Decompiler.TypeSystem;

public interface IVariable : ISymbol
{
	new string Name { get; }

	IType Type { get; }

	bool IsConst { get; }

	object GetConstantValue(bool throwOnInvalidMetadata = false);
}
