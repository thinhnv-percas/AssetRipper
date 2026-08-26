using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("Id = {Id}")]
public struct DataflowMessageHeader : IEquatable<DataflowMessageHeader>
{
	private readonly long m_id;

	public bool IsValid => m_id != 0;

	public long Id => m_id;

	public DataflowMessageHeader(long id)
	{
		if (id == 0)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageId, "id");
		}
		m_id = id;
	}

	public bool Equals(DataflowMessageHeader other)
	{
		return this == other;
	}

	public override bool Equals(object obj)
	{
		if (obj is DataflowMessageHeader)
		{
			return this == (DataflowMessageHeader)obj;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)Id;
	}

	public static bool operator ==(DataflowMessageHeader left, DataflowMessageHeader right)
	{
		return left.Id == right.Id;
	}

	public static bool operator !=(DataflowMessageHeader left, DataflowMessageHeader right)
	{
		return left.Id != right.Id;
	}
}
