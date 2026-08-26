using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Metadata;

public class AssemblyReference : IAssemblyReference
{
	private static readonly SHA1 sha1 = SHA1.Create();

	public PEFile Module { get; }

	public AssemblyReferenceHandle Handle { get; }

	public bool IsWindowsRuntime => (This().Flags & AssemblyFlags.WindowsRuntime) != 0;

	public bool IsRetargetable => (This().Flags & AssemblyFlags.Retargetable) != 0;

	public string Name => Module.Metadata.GetString(This().Name);

	public string FullName => This().GetFullAssemblyName(Module.Metadata);

	public Version Version => This().Version;

	public string Culture => Module.Metadata.GetString(This().Culture);

	byte[] IAssemblyReference.PublicKeyToken => GetPublicKeyToken();

	private System.Reflection.Metadata.AssemblyReference This()
	{
		return Module.Metadata.GetAssemblyReference(Handle);
	}

	public byte[] GetPublicKeyToken()
	{
		System.Reflection.Metadata.AssemblyReference assemblyReference = This();
		if (assemblyReference.PublicKeyOrToken.IsNil)
		{
			return Empty<byte>.Array;
		}
		byte[] blobBytes = Module.Metadata.GetBlobBytes(assemblyReference.PublicKeyOrToken);
		if ((assemblyReference.Flags & AssemblyFlags.PublicKey) != 0)
		{
			return Enumerable.ToArray<byte>(Enumerable.Skip<byte>((IEnumerable<byte>)((HashAlgorithm)sha1).ComputeHash(blobBytes), 12));
		}
		return blobBytes;
	}

	public AssemblyReference(PEFile module, AssemblyReferenceHandle handle)
	{
		Module = module ?? throw new ArgumentNullException("module");
		if (handle.IsNil)
		{
			throw new ArgumentNullException("handle");
		}
		Handle = handle;
	}

	public override string ToString()
	{
		return FullName;
	}
}
