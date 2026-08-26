using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Threading.Tasks.Dataflow.Internal;

internal sealed class EnumerableDebugView<TKey, TValue>
{
	private readonly IEnumerable<KeyValuePair<TKey, TValue>> m_enumerable;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public KeyValuePair<TKey, TValue>[] Items => m_enumerable.ToArray();

	public EnumerableDebugView(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
	{
		m_enumerable = enumerable;
	}
}
internal sealed class EnumerableDebugView<T>
{
	private readonly IEnumerable<T> m_enumerable;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public T[] Items => m_enumerable.ToArray();

	public EnumerableDebugView(IEnumerable<T> enumerable)
	{
		m_enumerable = enumerable;
	}
}
