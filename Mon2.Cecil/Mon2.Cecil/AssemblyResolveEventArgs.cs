using System;

namespace Mon2.Cecil;

public sealed class AssemblyResolveEventArgs : EventArgs
{
	private readonly AssemblyNameReference reference;

	public AssemblyNameReference AssemblyReference => reference;

	public AssemblyResolveEventArgs(AssemblyNameReference reference)
	{
		this.reference = reference;
	}
}
