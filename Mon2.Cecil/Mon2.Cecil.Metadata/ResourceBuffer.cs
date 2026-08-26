using Mon2.Cecil.PE;

namespace Mon2.Cecil.Metadata;

internal sealed class ResourceBuffer : ByteBuffer
{
	public ResourceBuffer()
		: base(0)
	{
	}

	public uint AddResource(byte[] resource)
	{
		int result = position;
		WriteInt32(resource.Length);
		WriteBytes(resource);
		return (uint)result;
	}
}
