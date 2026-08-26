using dnlib.DotNet.MD;

namespace dnlib.DotNet;

public abstract class Resource : IMDTokenProvider
{
	private uint rid;

	private uint? offset;

	private UTF8String name;

	private ManifestResourceAttributes flags;

	public MDToken MDToken => new MDToken(Table.ManifestResource, rid);

	public uint Rid
	{
		get
		{
			return rid;
		}
		set
		{
			rid = value;
		}
	}

	public uint? Offset
	{
		get
		{
			return offset;
		}
		set
		{
			offset = value;
		}
	}

	public UTF8String Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public ManifestResourceAttributes Attributes
	{
		get
		{
			return flags;
		}
		set
		{
			flags = value;
		}
	}

	public abstract ResourceType ResourceType { get; }

	public ManifestResourceAttributes Visibility
	{
		get
		{
			return flags & ManifestResourceAttributes.VisibilityMask;
		}
		set
		{
			flags = (ManifestResourceAttributes)(((uint)flags & 0xFFFFFFF8u) | (uint)(value & ManifestResourceAttributes.VisibilityMask));
		}
	}

	public bool IsPublic => (flags & ManifestResourceAttributes.VisibilityMask) == ManifestResourceAttributes.Public;

	public bool IsPrivate => (flags & ManifestResourceAttributes.VisibilityMask) == ManifestResourceAttributes.Private;

	protected Resource(UTF8String name, ManifestResourceAttributes flags)
	{
		this.name = name;
		this.flags = flags;
	}
}
