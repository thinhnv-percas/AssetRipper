using System;

namespace dnSpy.Contracts.Decompiler;

public interface IDecompilerOption
{
	Guid Guid { get; }

	string Name { get; }

	string Description { get; }

	Type Type { get; }

	object Value { get; set; }
}
