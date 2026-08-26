using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public readonly struct MethodDebugConstant
{
	public string Name { get; }

	public TypeSig Type { get; }

	public object Value { get; }

	public MethodDebugConstant(string name, TypeSig type, object value)
	{
		Name = name ?? throw new ArgumentNullException("name");
		Type = type ?? throw new ArgumentNullException("type");
		Value = value;
	}
}
