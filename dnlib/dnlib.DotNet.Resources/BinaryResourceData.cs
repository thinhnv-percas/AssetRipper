using System.IO;
using System.Runtime.Serialization;

namespace dnlib.DotNet.Resources;

public sealed class BinaryResourceData : UserResourceData
{
	private byte[] data;

	public byte[] Data => data;

	public BinaryResourceData(UserResourceType type, byte[] data)
		: base(type)
	{
		this.data = data;
	}

	public override void WriteData(BinaryWriter writer, IFormatter formatter)
	{
		writer.Write(data);
	}

	public override string ToString()
	{
		return "Binary: Length: " + data.Length;
	}
}
