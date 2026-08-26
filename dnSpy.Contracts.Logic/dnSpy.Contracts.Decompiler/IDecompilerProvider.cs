using System.Collections.Generic;

namespace dnSpy.Contracts.Decompiler;

public interface IDecompilerProvider
{
	IEnumerable<IDecompiler> Create();
}
