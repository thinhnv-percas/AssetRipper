using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class NamespaceReference
{
	public string Namespace { get; }

	public AssemblyRef Assembly { get; }

	public NamespaceReference(IAssembly assembly, string @namespace)
	{
		Assembly = assembly.ToAssemblyRef();
		Namespace = @namespace;
	}

	public override bool Equals(object obj)
	{
		return obj is NamespaceReference && StringComparer.Ordinal.Equals(((NamespaceReference)obj).Namespace, Namespace);
	}

	public override int GetHashCode()
	{
		return StringComparer.Ordinal.GetHashCode(Namespace ?? string.Empty);
	}
}
