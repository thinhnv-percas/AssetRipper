using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BatchedJoinBlockTarget<>.DebugView))]
internal sealed class BatchedJoinBlockTarget<T> : ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly BatchedJoinBlockTarget<T> m_batchedJoinBlockTarget;

		public IEnumerable<T> InputQueue => m_batchedJoinBlockTarget.m_messages;

		public bool IsDecliningPermanently
		{
			get
			{
				if (!m_batchedJoinBlockTarget.m_decliningPermanently)
				{
					return m_batchedJoinBlockTarget.m_sharedResources.m_decliningPermanently;
				}
				return true;
			}
		}

		public DebugView(BatchedJoinBlockTarget<T> batchedJoinBlockTarget)
		{
			m_batchedJoinBlockTarget = batchedJoinBlockTarget;
		}
	}

	private readonly BatchedJoinBlockTargetSharedResources m_sharedResources;

	private bool m_decliningPermanently;

	private IList<T> m_messages = new List<T>();

	internal int Count => m_messages.Count;

	Task IDataflowBlock.Completion
	{
		get
		{
			throw new NotSupportedException(Resource.NotSupported_MemberNotNeeded);
		}
	}

	private object DebuggerDisplayContent => string.Format("{0} InputCount={1}", new object[2]
	{
		Common.GetNameForDebugger(this),
		m_messages.Count
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	internal BatchedJoinBlockTarget(BatchedJoinBlockTargetSharedResources sharedResources)
	{
		m_sharedResources = sharedResources;
		sharedResources.m_remainingAliveTargets++;
	}

	internal IList<T> GetAndEmptyMessages()
	{
		IList<T> messages = m_messages;
		m_messages = new List<T>();
		return messages;
	}

	public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (source != null || !consumeToAccept)
		{
			lock (m_sharedResources.m_incomingLock)
			{
				if (m_decliningPermanently || m_sharedResources.m_decliningPermanently)
				{
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (consumeToAccept)
				{
					messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
					if (!messageConsumed)
					{
						return DataflowMessageStatus.NotAvailable;
					}
				}
				m_messages.Add(messageValue);
				if (--m_sharedResources.m_remainingItemsInBatch == 0)
				{
					m_sharedResources.m_batchSizeReachedAction();
				}
				return DataflowMessageStatus.Accepted;
			}
		}
		throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
	}

	public void Complete()
	{
		lock (m_sharedResources.m_incomingLock)
		{
			if (!m_decliningPermanently)
			{
				m_decliningPermanently = true;
				if (--m_sharedResources.m_remainingAliveTargets == 0)
				{
					m_sharedResources.m_allTargetsDecliningPermanentlyAction();
				}
			}
		}
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		lock (m_sharedResources.m_incomingLock)
		{
			if (!m_decliningPermanently && !m_sharedResources.m_decliningPermanently)
			{
				m_sharedResources.m_exceptionAction(exception);
			}
		}
		m_sharedResources.m_completionAction();
	}
}
