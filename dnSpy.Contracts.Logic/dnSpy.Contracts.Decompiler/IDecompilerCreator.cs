using System.Collections.Generic;

namespace dnSpy.Contracts.Decompiler;

public interface IDecompilerCreator
{
	IEnumerable<IDecompiler> Create();
}
