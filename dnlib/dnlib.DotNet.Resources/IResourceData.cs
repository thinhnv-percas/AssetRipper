using System.IO;
using System.Runtime.Serialization;
using dnlib.IO;

namespace dnlib.DotNet.Resources;

public interface IResourceData : IFileSection
{
	ResourceTypeCode Code { get; }

	new FileOffset StartOffset { get; set; }

	new FileOffset EndOffset { get; set; }

	void WriteData(BinaryWriter writer, IFormatter formatter);
}
