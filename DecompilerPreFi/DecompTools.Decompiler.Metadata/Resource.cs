using System;
using System.IO;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace DecompTools.Decompiler.Metadata;

public struct Resource : IEquatable<Resource>
{
	public PEFile Module { get; }

	public ManifestResourceHandle Handle { get; }

	public bool IsNil => Handle.IsNil;

	public string Name => Module.Metadata.GetString(This().Name);

	public ManifestResourceAttributes Attributes => This().Attributes;

	public ResourceType ResourceType => GetResourceType();

	public Resource(PEFile module, ManifestResourceHandle handle)
	{
		this = default(Resource);
		Module = module ?? throw new ArgumentNullException("module");
		Handle = handle;
	}

	private ManifestResource This()
	{
		return Module.Metadata.GetManifestResource(Handle);
	}

	public bool Equals(Resource other)
	{
		return Module == other.Module && Handle == other.Handle;
	}

	public override bool Equals(object obj)
	{
		if (obj is Resource other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 982451629 * Module.GetHashCode() + 982451653 * MetadataTokens.GetToken(Handle);
	}

	public static bool operator ==(Resource lhs, Resource rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Resource lhs, Resource rhs)
	{
		return !lhs.Equals(rhs);
	}

	public bool HasFlag(ManifestResourceAttributes flag)
	{
		return (Attributes & flag) == flag;
	}

	private ResourceType GetResourceType()
	{
		if (This().Implementation.IsNil)
		{
			return ResourceType.Embedded;
		}
		if (This().Implementation.Kind == HandleKind.AssemblyReference)
		{
			return ResourceType.AssemblyLinked;
		}
		return ResourceType.Linked;
	}

	public unsafe Stream TryOpenStream()
	{
		if (ResourceType != ResourceType.Embedded)
		{
			return null;
		}
		PEHeaders pEHeaders = Module.Reader.PEHeaders;
		DirectoryEntry resourcesDirectory = pEHeaders.CorHeader.ResourcesDirectory;
		PEMemoryBlock sectionData = Module.Reader.GetSectionData(resourcesDirectory.RelativeVirtualAddress);
		if (sectionData.Length == 0)
		{
			throw new BadImageFormatException("RVA could not be found in any section!");
		}
		BlobReader reader = sectionData.GetReader();
		checked
		{
			reader.Offset += (int)This().Offset;
			int num = reader.ReadInt32();
			if (num < 0 || num > reader.RemainingBytes)
			{
				throw new BadImageFormatException("Resource stream length invalid");
			}
			return new ResourceMemoryStream(Module.Reader, reader.CurrentPointer, num);
		}
	}
}
