using System.IO;

namespace DecompTools.Decompiler.Util;

public class ResourceSerializedObject
{
	private readonly ResourcesFile file;

	private readonly long position;

	public string TypeName { get; }

	internal ResourceSerializedObject(string typeName, ResourcesFile file, long position)
	{
		TypeName = typeName;
		this.file = file;
		this.position = position;
	}

	public Stream GetStream()
	{
		return new MemoryStream(file.GetBytesForSerializedObject(position), writable: false);
	}

	public byte[] GetBytes()
	{
		return file.GetBytesForSerializedObject(position);
	}
}
