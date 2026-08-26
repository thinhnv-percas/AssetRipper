using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.Writer;

public interface IChunk
{
	FileOffset FileOffset { get; }

	RVA RVA { get; }

	void SetOffset(FileOffset offset, RVA rva);

	uint GetFileLength();

	uint GetVirtualSize();

	void WriteTo(DataWriter writer);
}
