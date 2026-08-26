using System.Collections.Generic;
using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(JoinBlockTarget<>.DebugView))]
internal sealed class JoinBlockTarget<T> : JoinBlockTargetBase, ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class NonGreedyState
	{
		internal readonly QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages = new QueuedMap<ISourceBlock<T>, DataflowMessageHeader>();

		internal KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> ReservedMessage;

		internal KeyValuePair<bool, T> ConsumedMessage;
	}

	private sealed class DebugView
	{
		private readonly JoinBlockTarget<T> m_joinBlockTarget;

		public IEnumerable<T> InputQueue => m_joinBlockTarget.m_messages;

		public bool IsDecliningPermanently
		{
			get
			{
				if (!m_joinBlockTarget.m_decliningPermanently)
				{
					return m_joinBlockTarget.m_sharedResources.m_decliningPermanently;
				}
				return true;
			}
		}

		public DebugView(JoinBlockTarget<T> joinBlockTarget)
		{
			m_joinBlockTarget = joinBlockTarget;
		}
	}

	private readonly JoinBlockTargetSharedResources m_sharedResources;

	private readonly TaskCompletionSource<VoidResult> m_completionTask = new TaskCompletionSource<VoidResult>();

	private readonly Queue<T> m_messages;

	private readonly NonGreedyState m_nonGreedy;

	private bool m_decliningPermanently;

	internal override bool IsDecliningPermanently => m_decliningPermanently;

	internal override bool HasAtLeastOneMessageAvailable
	{
		get
		{
			if (m_sharedResources.m_dataflowBlockOptions.Greedy)
			{
				return m_messages.Count > 0;
			}
			return m_nonGreedy.ConsumedMessage.Key;
		}
	}

	internal override bool HasAtLeastOnePostponedMessage
	{
		get
		{
			if (m_nonGreedy != null)
			{
				return m_nonGreedy.PostponedMessages.Count > 0;
			}
			return false;
		}
	}

	internal override int NumberOfMessagesAvailableOrPostponed
	{
		get
		{
			if (m_sharedResources.m_dataflowBlockOptions.Greedy)
			{
				return m_messages.Count;
			}
			return m_nonGreedy.PostponedMessages.Count;
		}
	}

	internal override bool HasTheHighestNumberOfMessagesAvailable
	{
		get
		{
			int count = m_messages.Count;
			JoinBlockTargetBase[] targets = m_sharedResources.m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				if (joinBlockTargetBase != this && joinBlockTargetBase.NumberOfMessagesAvailableOrPostponed > count)
				{
					return false;
				}
			}
			return true;
		}
	}

	public Task Completion
	{
		get
		{
			throw new NotSupportedException(Resource.NotSupported_MemberNotNeeded);
		}
	}

	internal Task CompletionTaskInternal => m_completionTask.Task;

	private int InputCountForDebugger
	{
		get
		{
			if (m_messages == null)
			{
				if (!m_nonGreedy.ConsumedMessage.Key)
				{
					return 0;
				}
				return 1;
			}
			return m_messages.Count;
		}
	}

	private object DebuggerDisplayContent
	{
		get
		{
			IDebuggerDisplay debuggerDisplay = m_sharedResources.m_ownerJoin as IDebuggerDisplay;
			return string.Format("{0} InputCount={1}, Join=\"{2}\"", new object[3]
			{
				Common.GetNameForDebugger(this),
				InputCountForDebugger,
				(debuggerDisplay != null) ? debuggerDisplay.Content : m_sharedResources.m_ownerJoin
			});
		}
	}

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	internal JoinBlockTarget(JoinBlockTargetSharedResources sharedResources)
	{
		GroupingDataflowBlockOptions dataflowBlockOptions = sharedResources.m_dataflowBlockOptions;
		m_sharedResources = sharedResources;
		if (!dataflowBlockOptions.Greedy || dataflowBlockOptions.BoundedCapacity > 0)
		{
			m_nonGreedy = new NonGreedyState();
		}
		if (dataflowBlockOptions.Greedy)
		{
			m_messages = new Queue<T>();
		}
	}

	internal T GetOneMessage()
	{
		if (m_sharedResources.m_dataflowBlockOptions.Greedy)
		{
			return m_messages.Dequeue();
		}
		T value = m_nonGreedy.ConsumedMessage.Value;
		m_nonGreedy.ConsumedMessage = new KeyValuePair<bool, T>(key: false, default(T));
		return value;
	}

	internal override bool ReserveOneMessage()
	{
		KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
		lock (m_sharedResources.IncomingLock)
		{
			if (!m_nonGreedy.PostponedMessages.TryPop(out item))
			{
				return false;
			}
		}
		while (!item.Key.ReserveMessage(item.Value, this))
		{
			lock (m_sharedResources.IncomingLock)
			{
				if (!m_nonGreedy.PostponedMessages.TryPop(out item))
				{
					return false;
				}
			}
		}
		m_nonGreedy.ReservedMessage = item;
		return true;
	}

	internal override bool ConsumeReservedMessage()
	{
		T value = m_nonGreedy.ReservedMessage.Key.ConsumeMessage(m_nonGreedy.ReservedMessage.Value, this, out var messageConsumed);
		m_nonGreedy.ReservedMessage = default(KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>);
		if (!messageConsumed)
		{
			m_sharedResources.m_exceptionAction(new InvalidOperationException(Resource.InvalidOperation_FailedToConsumeReservedMessage));
			CompleteOncePossible();
			return false;
		}
		lock (m_sharedResources.IncomingLock)
		{
			m_nonGreedy.ConsumedMessage = new KeyValuePair<bool, T>(key: true, value);
			CompleteIfLastJoinIsFeasible();
		}
		return true;
	}

	internal override bool ConsumeOnePostponedMessage()
	{
		bool hasTheHighestNumberOfMessagesAvailable;
		T item2;
		bool messageConsumed;
		do
		{
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
			lock (m_sharedResources.IncomingLock)
			{
				hasTheHighestNumberOfMessagesAvailable = HasTheHighestNumberOfMessagesAvailable;
				bool flag = m_sharedResources.m_boundingState.CountIsLessThanBound || !hasTheHighestNumberOfMessagesAvailable;
				if (m_decliningPermanently || m_sharedResources.m_decliningPermanently || !flag || !m_nonGreedy.PostponedMessages.TryPop(out item))
				{
					return false;
				}
			}
			item2 = item.Key.ConsumeMessage(item.Value, this, out messageConsumed);
		}
		while (!messageConsumed);
		lock (m_sharedResources.IncomingLock)
		{
			if (hasTheHighestNumberOfMessagesAvailable)
			{
				m_sharedResources.m_boundingState.CurrentCount++;
			}
			m_messages.Enqueue(item2);
			CompleteIfLastJoinIsFeasible();
			return true;
		}
	}

	private void CompleteIfLastJoinIsFeasible()
	{
		int num = (m_sharedResources.m_dataflowBlockOptions.Greedy ? m_messages.Count : (m_nonGreedy.ConsumedMessage.Key ? 1 : 0));
		if (m_sharedResources.m_joinsCreated + num < m_sharedResources.m_dataflowBlockOptions.ActualMaxNumberOfGroups)
		{
			return;
		}
		m_decliningPermanently = true;
		bool flag = true;
		JoinBlockTargetBase[] targets = m_sharedResources.m_targets;
		foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
		{
			if (!joinBlockTargetBase.IsDecliningPermanently)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			m_sharedResources.m_decliningPermanently = true;
		}
	}

	internal override void ReleaseReservedMessage()
	{
		if (m_nonGreedy != null && m_nonGreedy.ReservedMessage.Key != null)
		{
			try
			{
				m_nonGreedy.ReservedMessage.Key.ReleaseReservation(m_nonGreedy.ReservedMessage.Value, this);
			}
			finally
			{
				ClearReservation();
			}
		}
	}

	internal override void ClearReservation()
	{
		m_nonGreedy.ReservedMessage = default(KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>);
	}

	internal override void CompleteOncePossible()
	{
		lock (m_sharedResources.IncomingLock)
		{
			m_decliningPermanently = true;
			if (m_messages != null)
			{
				m_messages.Clear();
			}
		}
		List<Exception> exceptions = null;
		if (m_nonGreedy != null)
		{
			Common.ReleaseAllPostponedMessages(this, m_nonGreedy.PostponedMessages, ref exceptions);
		}
		if (exceptions != null)
		{
			foreach (Exception item in exceptions)
			{
				m_sharedResources.m_exceptionAction(item);
			}
		}
		m_completionTask.TrySetResult(default(VoidResult));
	}

	DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (source != null || !consumeToAccept)
		{
			lock (m_sharedResources.IncomingLock)
			{
				if (m_decliningPermanently || m_sharedResources.m_decliningPermanently)
				{
					m_sharedResources.CompleteBlockIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (m_sharedResources.m_dataflowBlockOptions.Greedy && (m_sharedResources.m_boundingState == null || ((m_sharedResources.m_boundingState.CountIsLessThanBound || !HasTheHighestNumberOfMessagesAvailable) && m_nonGreedy.PostponedMessages.Count == 0 && m_sharedResources.m_taskForInputProcessing == null)))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					if (m_sharedResources.m_boundingState != null && HasTheHighestNumberOfMessagesAvailable)
					{
						m_sharedResources.m_boundingState.CurrentCount++;
					}
					m_messages.Enqueue(messageValue);
					CompleteIfLastJoinIsFeasible();
					if (m_sharedResources.AllTargetsHaveAtLeastOneMessage)
					{
						m_sharedResources.m_joinFilledAction();
						m_sharedResources.m_joinsCreated++;
					}
					m_sharedResources.CompleteBlockIfPossible();
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					m_nonGreedy.PostponedMessages.Push(source, messageHeader);
					m_sharedResources.ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}
		throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
	}

	internal override void CompleteCore(Exception exception, bool dropPendingMessages, bool releaseReservedMessages)
	{
		bool greedy = m_sharedResources.m_dataflowBlockOptions.Greedy;
		lock (m_sharedResources.IncomingLock)
		{
			if (exception != null && ((!m_decliningPermanently && !m_sharedResources.m_decliningPermanently) || releaseReservedMessages))
			{
				m_sharedResources.m_exceptionAction(exception);
			}
			if (dropPendingMessages && greedy)
			{
				m_messages.Clear();
			}
		}
		if (releaseReservedMessages && !greedy)
		{
			JoinBlockTargetBase[] targets = m_sharedResources.m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				try
				{
					joinBlockTargetBase.ReleaseReservedMessage();
				}
				catch (Exception obj)
				{
					m_sharedResources.m_exceptionAction(obj);
				}
			}
		}
		lock (m_sharedResources.IncomingLock)
		{
			m_decliningPermanently = true;
			m_sharedResources.CompleteBlockIfPossible();
		}
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		CompleteCore(exception, dropPendingMessages: true, releaseReservedMessages: false);
	}
}
