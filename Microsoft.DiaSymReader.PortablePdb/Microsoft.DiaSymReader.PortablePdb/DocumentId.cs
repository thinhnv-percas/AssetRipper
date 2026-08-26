using System;
using System.Diagnostics;

namespace Microsoft.DiaSymReader.PortablePdb;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
internal struct DocumentId : IEquatable<DocumentId>
{
	public readonly int Value;

	public bool IsDefault => Value == 0;

	public DocumentId(int id)
	{
		Value = id;
	}

	public bool Equals(DocumentId other)
	{
		return Value == other.Value;
	}

	public override int GetHashCode()
	{
		int value = Value;
		return value.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is DocumentId other)
		{
			return Equals(other);
		}
		return false;
	}

	private object GetDebuggerDisplay()
	{
		return Value;
	}
}
