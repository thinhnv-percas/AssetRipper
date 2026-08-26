using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public interface ISourceVariable
{
	IVariable Variable { get; }

	bool IsLocal { get; }

	bool IsParameter { get; }

	string Name { get; }

	TypeSig Type { get; }

	FieldDef HoistedField { get; }

	SourceVariableFlags Flags { get; }

	bool IsDecompilerGenerated { get; }
}
