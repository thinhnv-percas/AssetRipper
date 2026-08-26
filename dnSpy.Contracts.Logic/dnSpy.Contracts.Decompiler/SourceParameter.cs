using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class SourceParameter : ISourceVariable
{
	public Parameter Parameter { get; }

	IVariable ISourceVariable.Variable => Parameter;

	bool ISourceVariable.IsLocal => false;

	bool ISourceVariable.IsParameter => true;

	bool ISourceVariable.IsDecompilerGenerated => (Flags & SourceVariableFlags.DecompilerGenerated) != 0;

	public string Name { get; }

	public TypeSig Type { get; }

	public FieldDef HoistedField { get; }

	public SourceVariableFlags Flags { get; }

	public SourceParameter(Parameter parameter, string name, TypeSig type, SourceVariableFlags flags)
	{
		Parameter = parameter ?? throw new ArgumentNullException("parameter");
		Name = name ?? throw new ArgumentNullException("name");
		Type = type ?? throw new ArgumentNullException("type");
		Flags = flags;
	}

	public SourceParameter(Parameter parameter, string name, FieldDef hoistedField, SourceVariableFlags flags)
	{
		Parameter = parameter ?? throw new ArgumentNullException("parameter");
		Name = name ?? throw new ArgumentNullException("name");
		HoistedField = hoistedField ?? throw new ArgumentNullException("hoistedField");
		Type = hoistedField.FieldType;
		Flags = flags;
	}
}
