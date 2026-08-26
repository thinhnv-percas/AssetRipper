using System;
using System.Collections.Generic;
using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.Writer;

public sealed class UniqueChunkList<T> : ChunkListBase<T> where T : class, IChunk
{
	private Dictionary<Elem, Elem> dict;

	public UniqueChunkList()
		: this((IEqualityComparer<T>)EqualityComparer<T>.Default)
	{
	}

	public UniqueChunkList(IEqualityComparer<T> chunkComparer)
	{
		chunks = new List<Elem>();
		dict = new Dictionary<Elem, Elem>(new ElemEqualityComparer(chunkComparer));
	}

	public override void SetOffset(FileOffset offset, RVA rva)
	{
		dict = null;
		base.SetOffset(offset, rva);
	}

	public T Add(T chunk, uint alignment)
	{
		if (setOffsetCalled)
		{
			throw new InvalidOperationException("SetOffset() has already been called");
		}
		if (chunk == null)
		{
			return null;
		}
		Elem elem = new Elem(chunk, alignment);
		if (dict.TryGetValue(elem, out var value))
		{
			return value.chunk;
		}
		dict[elem] = elem;
		chunks.Add(elem);
		return elem.chunk;
	}
}
