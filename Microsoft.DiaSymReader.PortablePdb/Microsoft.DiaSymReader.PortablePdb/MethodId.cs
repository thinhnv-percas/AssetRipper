using System;
using System.Diagnostics;

namespace Microsoft.DiaSymReader.PortablePdb;

[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
internal struct MethodId : IEquatable<MethodId>, IComparable<MethodId>
{
	public readonly int Value;

	public int Token => MetadataUtilities.MethodDefToken(Value);

	public bool IsDefault => Value == 0;

	public MethodId(int id)
	{
		Value = id;
	}

	public static MethodId FromToken(int methodToken)
	{
		return new MethodId(MetadataUtilities.GetRowId(methodToken));
	}

	public bool Equals(MethodId other)
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
		if (obj is MethodId other)
		{
			return Equals(other);
		}
		return false;
	}

	public int CompareTo(MethodId other)
	{
		int value = Value;
		return value.CompareTo(other.Value);
	}

	public static bool operator ==(MethodId left, MethodId right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(MethodId left, MethodId right)
	{
		return !left.Equals(right);
	}

	public static bool operator <(MethodId left, MethodId right)
	{
		return left.Value < right.Value;
	}

	public static bool operator >(MethodId left, MethodId right)
	{
		return left.Value > right.Value;
	}

	public static bool operator <=(MethodId left, MethodId right)
	{
		return left.Value <= right.Value;
	}

	public static bool operator >=(MethodId left, MethodId right)
	{
		return left.Value >= right.Value;
	}

	private object GetDebuggerDisplay()
	{
		return Value;
	}
}
