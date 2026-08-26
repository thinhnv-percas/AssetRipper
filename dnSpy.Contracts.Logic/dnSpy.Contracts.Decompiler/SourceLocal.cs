#define DEBUG
using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Contracts.Decompiler;

public sealed class SourceLocal : ISourceVariable
{
	public Local Local { get; }

	IVariable ISourceVariable.Variable => Local;

	bool ISourceVariable.IsLocal => true;

	bool ISourceVariable.IsParameter => false;

	public string Name { get; }

	public TypeSig Type { get; }

	public FieldDef HoistedField { get; }

	public SourceVariableFlags Flags { get; }

	public bool IsDecompilerGenerated => (Flags & SourceVariableFlags.DecompilerGenerated) != 0;

	public SourceLocal(Local local, string name, TypeSig type, SourceVariableFlags flags)
	{
		Debug.Assert((flags & SourceVariableFlags.DecompilerGenerated) == 0);
		Local = local;
		Name = name ?? throw new ArgumentNullException("name");
		Type = type ?? throw new ArgumentNullException("type");
		flags = ((local != null) ? (flags & ~SourceVariableFlags.DecompilerGenerated) : (flags | SourceVariableFlags.DecompilerGenerated));
		Flags = flags;
	}

	public SourceLocal(Local local, string name, FieldDef hoistedField, SourceVariableFlags flags)
	{
		Debug.Assert((flags & SourceVariableFlags.DecompilerGenerated) == 0);
		Local = local;
		Name = name ?? throw new ArgumentNullException("name");
		HoistedField = hoistedField ?? throw new ArgumentNullException("hoistedField");
		Type = hoistedField.FieldType;
		Flags = flags & ~SourceVariableFlags.DecompilerGenerated;
	}
}
