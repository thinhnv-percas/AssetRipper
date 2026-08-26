using System;
using dnlib.IO;

namespace dnlib.DotNet.MD;

public sealed class GuidStream : HeapStream
{
	public GuidStream()
	{
	}

	public GuidStream(DataReaderFactory mdReaderFactory, uint metadataBaseOffset, StreamHeader streamHeader)
		: base(mdReaderFactory, metadataBaseOffset, streamHeader)
	{
	}

	public override bool IsValidIndex(uint index)
	{
		return index == 0 || (index <= 268435456 && IsValidOffset((index - 1) * 16, 16));
	}

	public Guid? Read(uint index)
	{
		if (index == 0 || !IsValidIndex(index))
		{
			return null;
		}
		DataReader dataReader = base.dataReader;
		dataReader.Position = (index - 1) * 16;
		return dataReader.ReadGuid();
	}
}
