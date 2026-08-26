using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
internal sealed class TargetCore<TInput>
{
	internal sealed class DebuggingInformation
	{
		private readonly TargetCore<TInput> m_target;

		internal int InputCount => m_target.m_messages.Count;

		internal IEnumerable<TInput> InputQueue => m_target.m_messages.Select((KeyValuePair<TInput, long> kvp) => kvp.Key).ToList();

		internal QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages
		{
			get
			{
				if (m_target.m_boundingState == null)
				{
					return null;
				}
				return m_target.m_boundingState.PostponedMessages;
			}
		}

		internal int CurrentDegreeOfParallelism => m_target.m_numberOfOutstandingOperations - m_target.m_numberOfOutstandingServiceTasks;

		internal ExecutionDataflowBlockOptions DataflowBlockOptions => m_target.m_dataflowBlockOptions;

		internal bool IsDecliningPermanently => m_target.m_decliningPermanently;

		internal bool IsCompleted => m_target.Completion.IsCompleted;

		internal DebuggingInformation(TargetCore<TInput> target)
		{
			m_target = target;
		}
	}

	private static readonly Common.KeepAlivePredicate<TargetCore<TInput>, KeyValuePair<TInput, long>> s_keepAlivePredicate = delegate(TargetCore<TInput> thisTargetCore, out KeyValuePair<TInput, long> messageWithId)
	{
		return thisTargetCore.TryGetNextAvailableOrPostponedMessage(out messageWithId);
	};

	private readonly TaskCompletionSource<VoidResult> m_completionSource = new TaskCompletionSource<VoidResult>();

	private readonly ITargetBlock<TInput> m_owningTarget;

	private readonly System.Threading.Tasks.IProducerConsumerQueue<KeyValuePair<TInput, long>> m_messages;

	private readonly ExecutionDataflowBlockOptions m_dataflowBlockOptions;

	private readonly Action<KeyValuePair<TInput, long>> m_callAction;

	private readonly TargetCoreOptions m_targetCoreOptions;

	private readonly BoundingStateWithPostponed<TInput> m_boundingState;

	private readonly IReorderingBuffer m_reorderingBuffer;

	private List<Exception> m_exceptions;

	private bool m_decliningPermanently;

	private int m_numberOfOutstandingOperations;

	private int m_numberOfOutstandingServiceTasks;

	private PaddedInt64 m_nextAvailableInputMessageId;

	private bool m_completionReserved;

	private int m_keepAliveBanCounter;

	private object IncomingLock => m_messages;

	internal Task Completion => m_completionSource.Task;

	internal int InputCount => m_messages.GetCountSafe(IncomingLock);

	private bool UsesAsyncCompletion => (m_targetCoreOptions & TargetCoreOptions.UsesAsyncCompletion) != 0;

	private bool HasRoomForMoreOperations => m_numberOfOutstandingOperations - m_numberOfOutstandingServiceTasks < m_dataflowBlockOptions.ActualMaxDegreeOfParallelism;

	private bool HasRoomForMoreServiceTasks
	{
		get
		{
			if (!UsesAsyncCompletion)
			{
				return HasRoomForMoreOperations;
			}
			if (HasRoomForMoreOperations)
			{
				return m_numberOfOutstandingServiceTasks < m_dataflowBlockOptions.ActualMaxDegreeOfParallelism;
			}
			return false;
		}
	}

	private bool CanceledOrFaulted
	{
		get
		{
			if (!m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				return Volatile.Read(ref m_exceptions) != null;
			}
			return true;
		}
	}

	internal bool IsBounded => m_boundingState != null;

	private object DebuggerDisplayContent
	{
		get
		{
			IDebuggerDisplay debuggerDisplay = m_owningTarget as IDebuggerDisplay;
			return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : m_owningTarget)}\"";
		}
	}

	internal ExecutionDataflowBlockOptions DataflowBlockOptions => m_dataflowBlockOptions;

	internal TargetCore(ITargetBlock<TInput> owningTarget, Action<KeyValuePair<TInput, long>> callAction, IReorderingBuffer reorderingBuffer, ExecutionDataflowBlockOptions dataflowBlockOptions, TargetCoreOptions targetCoreOptions)
	{
		m_owningTarget = owningTarget;
		m_callAction = callAction;
		m_reorderingBuffer = reorderingBuffer;
		m_dataflowBlockOptions = dataflowBlockOptions;
		m_targetCoreOptions = targetCoreOptions;
		object messages;
		if (dataflowBlockOptions.MaxDegreeOfParallelism != 1)
		{
			System.Threading.Tasks.IProducerConsumerQueue<KeyValuePair<TInput, long>> producerConsumerQueue = new System.Threading.Tasks.MultiProducerMultiConsumerQueue<KeyValuePair<TInput, long>>();
			messages = producerConsumerQueue;
		}
		else
		{
			messages = new System.Threading.Tasks.SingleProducerSingleConsumerQueue<KeyValuePair<TInput, long>>();
		}
		m_messages = (System.Threading.Tasks.IProducerConsumerQueue<KeyValuePair<TInput, long>>)messages;
		if (m_dataflowBlockOptions.BoundedCapacity != -1)
		{
			m_boundingState = new BoundingStateWithPostponed<TInput>(m_dataflowBlockOptions.BoundedCapacity);
		}
	}

	internal void Complete(Exception exception, bool dropPendingMessages, bool storeExceptionEvenIfAlreadyCompleting = false, bool unwrapInnerExceptions = false, bool revertProcessingState = false)
	{
		lock (IncomingLock)
		{
			if (exception != null && (!m_decliningPermanently || storeExceptionEvenIfAlreadyCompleting))
			{
				Common.AddException(ref m_exceptions, exception, unwrapInnerExceptions);
			}
			if (dropPendingMessages)
			{
				KeyValuePair<TInput, long> result;
				while (m_messages.TryDequeue(out result))
				{
				}
			}
			if (revertProcessingState)
			{
				m_numberOfOutstandingOperations--;
				if (UsesAsyncCompletion)
				{
					m_numberOfOutstandingServiceTasks--;
				}
			}
			m_decliningPermanently = true;
			CompleteBlockIfPossible();
		}
	}

	internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (source != null || !consumeToAccept)
		{
			lock (IncomingLock)
			{
				if (m_decliningPermanently)
				{
					CompleteBlockIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (m_boundingState == null || (m_boundingState.OutstandingTransfers == 0 && m_boundingState.CountIsLessThanBound && m_boundingState.PostponedMessages.Count == 0))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, m_owningTarget, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					long value = m_nextAvailableInputMessageId.Value++;
					if (m_boundingState != null)
					{
						m_boundingState.CurrentCount++;
					}
					m_messages.Enqueue(new KeyValuePair<TInput, long>(messageValue, value));
					ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					m_boundingState.PostponedMessages.Push(source, messageHeader);
					ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}
		throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
	}

	internal void SignalOneAsyncMessageCompleted()
	{
		SignalOneAsyncMessageCompleted(0);
	}

	internal void SignalOneAsyncMessageCompleted(int boundingCountChange)
	{
		lock (IncomingLock)
		{
			if (m_numberOfOutstandingOperations > 0)
			{
				m_numberOfOutstandingOperations--;
			}
			if (m_boundingState != null && boundingCountChange != 0)
			{
				m_boundingState.CurrentCount += boundingCountChange;
			}
			ProcessAsyncIfNecessary(repeat: true);
			CompleteBlockIfPossible();
		}
	}

	private void ProcessAsyncIfNecessary(bool repeat = false)
	{
		if (HasRoomForMoreServiceTasks)
		{
			ProcessAsyncIfNecessary_Slow(repeat);
		}
	}

	private void ProcessAsyncIfNecessary_Slow(bool repeat)
	{
		if ((m_messages.IsEmpty && (m_decliningPermanently || m_boundingState == null || !m_boundingState.CountIsLessThanBound || m_boundingState.PostponedMessages.Count <= 0)) || CanceledOrFaulted)
		{
			return;
		}
		m_numberOfOutstandingOperations++;
		if (UsesAsyncCompletion)
		{
			m_numberOfOutstandingServiceTasks++;
		}
		Task task = new Task(delegate(object thisTargetCore)
		{
			((TargetCore<TInput>)thisTargetCore).ProcessMessagesLoopCore();
		}, this, Common.GetCreationOptionsForTask(repeat));
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.TaskLaunchedForMessageHandling(m_owningTarget, task, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, m_messages.Count + ((m_boundingState != null) ? m_boundingState.PostponedMessages.Count : 0));
		}
		Exception ex = Common.StartTaskSafe(task, m_dataflowBlockOptions.TaskScheduler);
		if (ex != null)
		{
			Task.Factory.StartNew(delegate(object exc)
			{
				Complete((Exception)exc, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: false, revertProcessingState: true);
			}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private void ProcessMessagesLoopCore()
	{
		KeyValuePair<TInput, long> messageWithId = default(KeyValuePair<TInput, long>);
		try
		{
			bool usesAsyncCompletion = UsesAsyncCompletion;
			bool flag = m_boundingState != null && m_boundingState.BoundedCapacity > 1;
			int num = 0;
			int num2 = 0;
			int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
			while (num < actualMaxMessagesPerTask && !CanceledOrFaulted)
			{
				if (flag && TryConsumePostponedMessage(forPostponementTransfer: true, out var result))
				{
					lock (IncomingLock)
					{
						m_boundingState.OutstandingTransfers--;
						m_messages.Enqueue(result);
						ProcessAsyncIfNecessary();
					}
				}
				if (usesAsyncCompletion)
				{
					if (!TryGetNextMessageForNewAsyncOperation(out messageWithId))
					{
						break;
					}
				}
				else if (!TryGetNextAvailableOrPostponedMessage(out messageWithId))
				{
					if (m_dataflowBlockOptions.MaxDegreeOfParallelism != 1 || num2 > 1)
					{
						break;
					}
					if (m_keepAliveBanCounter > 0)
					{
						m_keepAliveBanCounter--;
						break;
					}
					num2 = 0;
					if (!Common.TryKeepAliveUntil(s_keepAlivePredicate, this, out messageWithId))
					{
						m_keepAliveBanCounter = 1000;
						break;
					}
				}
				num++;
				num2++;
				m_callAction(messageWithId);
			}
		}
		catch (Exception ex)
		{
			Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
			Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
		}
		finally
		{
			lock (IncomingLock)
			{
				m_numberOfOutstandingOperations--;
				if (UsesAsyncCompletion)
				{
					m_numberOfOutstandingServiceTasks--;
				}
				ProcessAsyncIfNecessary(repeat: true);
				CompleteBlockIfPossible();
			}
		}
	}

	private bool TryGetNextMessageForNewAsyncOperation(out KeyValuePair<TInput, long> messageWithId)
	{
		bool hasRoomForMoreOperations;
		lock (IncomingLock)
		{
			hasRoomForMoreOperations = HasRoomForMoreOperations;
			if (hasRoomForMoreOperations)
			{
				m_numberOfOutstandingOperations++;
			}
		}
		messageWithId = default(KeyValuePair<TInput, long>);
		if (hasRoomForMoreOperations)
		{
			bool flag = false;
			try
			{
				flag = TryGetNextAvailableOrPostponedMessage(out messageWithId);
			}
			catch
			{
				SignalOneAsyncMessageCompleted();
				throw;
			}
			if (!flag)
			{
				SignalOneAsyncMessageCompleted();
			}
			return flag;
		}
		return false;
	}

	private bool TryGetNextAvailableOrPostponedMessage(out KeyValuePair<TInput, long> messageWithId)
	{
		if (m_messages.TryDequeue(out messageWithId))
		{
			return true;
		}
		if (m_boundingState != null && TryConsumePostponedMessage(forPostponementTransfer: false, out messageWithId))
		{
			return true;
		}
		messageWithId = default(KeyValuePair<TInput, long>);
		return false;
	}

	private bool TryConsumePostponedMessage(bool forPostponementTransfer, out KeyValuePair<TInput, long> result)
	{
		bool flag = false;
		long num = -1L;
		while (true)
		{
			KeyValuePair<ISourceBlock<TInput>, DataflowMessageHeader> item;
			lock (IncomingLock)
			{
				if (m_decliningPermanently)
				{
					break;
				}
				if (!forPostponementTransfer && m_messages.TryDequeue(out result))
				{
					return true;
				}
				if (!m_boundingState.CountIsLessThanBound || !m_boundingState.PostponedMessages.TryPop(out item))
				{
					if (flag)
					{
						flag = false;
						m_boundingState.CurrentCount--;
					}
					break;
				}
				if (!flag)
				{
					flag = true;
					num = m_nextAvailableInputMessageId.Value++;
					m_boundingState.CurrentCount++;
					if (forPostponementTransfer)
					{
						m_boundingState.OutstandingTransfers++;
					}
				}
				goto IL_00d2;
			}
			IL_00d2:
			TInput key = item.Key.ConsumeMessage(item.Value, m_owningTarget, out var messageConsumed);
			if (messageConsumed)
			{
				result = new KeyValuePair<TInput, long>(key, num);
				return true;
			}
			if (forPostponementTransfer)
			{
				m_boundingState.OutstandingTransfers--;
			}
		}
		if (m_reorderingBuffer != null && num != -1)
		{
			m_reorderingBuffer.IgnoreItem(num);
		}
		if (flag)
		{
			ChangeBoundingCount(-1);
		}
		result = default(KeyValuePair<TInput, long>);
		return false;
	}

	private void CompleteBlockIfPossible()
	{
		if ((m_decliningPermanently && m_messages.IsEmpty) || CanceledOrFaulted)
		{
			CompleteBlockIfPossible_Slow();
		}
	}

	private void CompleteBlockIfPossible_Slow()
	{
		if (m_numberOfOutstandingOperations == 0 && !m_completionReserved)
		{
			m_completionReserved = true;
			m_decliningPermanently = true;
			Task.Factory.StartNew(delegate(object state)
			{
				((TargetCore<TInput>)state).CompleteBlockOncePossible();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private void CompleteBlockOncePossible()
	{
		if (m_boundingState != null)
		{
			Common.ReleaseAllPostponedMessages(m_owningTarget, m_boundingState.PostponedMessages, ref m_exceptions);
		}
		System.Threading.Tasks.IProducerConsumerQueue<KeyValuePair<TInput, long>> messages = m_messages;
		KeyValuePair<TInput, long> result;
		while (messages.TryDequeue(out result))
		{
		}
		if (Volatile.Read(ref m_exceptions) != null)
		{
			m_completionSource.TrySetException(Volatile.Read(ref m_exceptions));
		}
		else if (m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
		{
			m_completionSource.TrySetCanceled();
		}
		else
		{
			m_completionSource.TrySetResult(default(VoidResult));
		}
		DataflowEtwProvider log;
		if ((m_targetCoreOptions & TargetCoreOptions.RepresentsBlockCompletion) != TargetCoreOptions.None && (log = DataflowEtwProvider.Log).IsEnabled())
		{
			log.DataflowBlockCompleted(m_owningTarget);
		}
	}

	internal void ChangeBoundingCount(int count)
	{
		if (m_boundingState != null)
		{
			lock (IncomingLock)
			{
				m_boundingState.CurrentCount += count;
				ProcessAsyncIfNecessary();
				CompleteBlockIfPossible();
			}
		}
	}

	internal DebuggingInformation GetDebuggingInformation()
	{
		return new DebuggingInformation(this);
	}
}
