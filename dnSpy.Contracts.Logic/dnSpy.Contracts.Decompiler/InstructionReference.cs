using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace dnSpy.Contracts.Decompiler;

public sealed class InstructionReference : IEquatable<InstructionReference>
{
	public MethodDef Method { get; }

	public Instruction Instruction { get; }

	public InstructionReference(MethodDef method, Instruction instruction)
	{
		Method = method ?? throw new ArgumentNullException("method");
		Instruction = instruction ?? throw new ArgumentNullException("instruction");
	}

	public bool Equals(InstructionReference other)
	{
		return other != null && Method == other.Method && Instruction == other.Instruction;
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as InstructionReference);
	}

	public override int GetHashCode()
	{
		return Method.GetHashCode() ^ Instruction.GetHashCode();
	}
}
