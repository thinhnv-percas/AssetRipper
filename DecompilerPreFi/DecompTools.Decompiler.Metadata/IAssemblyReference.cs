using System;

namespace DecompTools.Decompiler.Metadata;

public interface IAssemblyReference
{
	string Name { get; }

	string FullName { get; }

	Version Version { get; }

	string Culture { get; }

	byte[] PublicKeyToken { get; }

	bool IsWindowsRuntime { get; }

	bool IsRetargetable { get; }
}
