using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerTypeProxy(typeof(ReorderingBuffer<>.DebugView))]
[DebuggerDisplay("Count={CountForDebugging}")]
internal sealed class ReorderingBuffer<TOutput> : IReorderingBuffer
{
	private sealed class DebugView
	{
		private readonly ReorderingBuffer<TOutput> m_buffer;

		public Dictionary<long, KeyValuePair<bool, TOutput>> ItemsBuffered => m_buffer.m_reorderingBuffer;

		public long NextIdRequired => m_buffer.m_nextReorderedIdToOutput;

		public DebugView(ReorderingBuffer<TOutput> buffer)
		{
			m_buffer = buffer;
		}
	}

	private readonly object m_owningSource;

	private readonly Dictionary<long, KeyValuePair<bool, TOutput>> m_reorderingBuffer = new Dictionary<long, KeyValuePair<bool, TOutput>>();

	private readonly Action<object, TOutput> m_outputAction;

	private long m_nextReorderedIdToOutput;

	private object ValueLock => m_reorderingBuffer;

	private int CountForDebugging => m_reorderingBuffer.Count;

	internal ReorderingBuffer(object owningSource, Action<object, TOutput> outputAction)
	{
		m_owningSource = owningSource;
		m_outputAction = outputAction;
	}

	internal void AddItem(long id, TOutput item, bool itemIsValid)
	{
		lock (ValueLock)
		{
			if (m_nextReorderedIdToOutput == id)
			{
				OutputNextItem(item, itemIsValid);
			}
			else
			{
				m_reorderingBuffer.Add(id, new KeyValuePair<bool, TOutput>(itemIsValid, item));
			}
		}
	}

	internal bool? AddItemIfNextAndTrusted(long id, TOutput item, bool isTrusted)
	{
		lock (ValueLock)
		{
			if (m_nextReorderedIdToOutput == id)
			{
				if (isTrusted)
				{
					OutputNextItem(item, itemIsValid: true);
					return null;
				}
				return true;
			}
			return false;
		}
	}

	public void IgnoreItem(long id)
	{
		AddItem(id, default(TOutput), itemIsValid: false);
	}

	private void OutputNextItem(TOutput theNextItem, bool itemIsValid)
	{
		m_nextReorderedIdToOutput++;
		if (itemIsValid)
		{
			m_outputAction(m_owningSource, theNextItem);
		}
		KeyValuePair<bool, TOutput> value;
		while (m_reorderingBuffer.TryGetValue(m_nextReorderedIdToOutput, out value))
		{
			m_reorderingBuffer.Remove(m_nextReorderedIdToOutput);
			m_nextReorderedIdToOutput++;
			if (value.Key)
			{
				m_outputAction(m_owningSource, value.Value);
			}
		}
	}
}
