using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodStatementReference
{
	public MethodDef Method { get; }

	public uint? Offset { get; }

	public MethodStatementReference(MethodDef method, uint? offset)
	{
		Method = method ?? throw new ArgumentNullException("method");
		Offset = offset;
	}

	public override bool Equals(object obj)
	{
		return obj is MethodStatementReference methodStatementReference && Method == methodStatementReference.Method && Offset == methodStatementReference.Offset;
	}

	public override int GetHashCode()
	{
		return Method.GetHashCode() ^ (int)(Offset ?? 0);
	}
}
