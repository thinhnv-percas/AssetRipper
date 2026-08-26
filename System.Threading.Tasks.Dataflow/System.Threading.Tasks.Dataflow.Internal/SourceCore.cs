using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
internal sealed class SourceCore<TOutput>
{
	internal sealed class DebuggingInformation
	{
		private SourceCore<TOutput> m_source;

		internal int OutputCount => m_source.m_messages.Count;

		internal IEnumerable<TOutput> OutputQueue => m_source.m_messages.ToList();

		internal Task TaskForOutputProcessing => m_source.m_taskForOutputProcessing;

		internal DataflowBlockOptions DataflowBlockOptions => m_source.m_dataflowBlockOptions;

		internal bool IsDecliningPermanently => m_source.m_decliningPermanently;

		internal bool IsCompleted => m_source.Completion.IsCompleted;

		internal TargetRegistry<TOutput> LinkedTargets => m_source.m_targetRegistry;

		internal ITargetBlock<TOutput> NextMessageReservedFor => m_source.m_nextMessageReservedFor;

		internal DebuggingInformation(SourceCore<TOutput> source)
		{
			m_source = source;
		}
	}

	private readonly TaskCompletionSource<VoidResult> m_completionTask = new TaskCompletionSource<VoidResult>();

	private readonly TargetRegistry<TOutput> m_targetRegistry;

	private readonly System.Threading.Tasks.SingleProducerSingleConsumerQueue<TOutput> m_messages = new System.Threading.Tasks.SingleProducerSingleConsumerQueue<TOutput>();

	private readonly ISourceBlock<TOutput> m_owningSource;

	private readonly DataflowBlockOptions m_dataflowBlockOptions;

	private readonly Action<ISourceBlock<TOutput>> m_completeAction;

	private readonly Action<ISourceBlock<TOutput>, int> m_itemsRemovedAction;

	private readonly Func<ISourceBlock<TOutput>, TOutput, IList<TOutput>, int> m_itemCountingFunc;

	private Task m_taskForOutputProcessing;

	private PaddedInt64 m_nextMessageId = new PaddedInt64
	{
		Value = 1L
	};

	private ITargetBlock<TOutput> m_nextMessageReservedFor;

	private bool m_decliningPermanently;

	private bool m_enableOffering = true;

	private bool m_completionReserved;

	private List<Exception> m_exceptions;

	private object OutgoingLock => m_completionTask;

	private object ValueLock => m_targetRegistry;

	internal Task Completion => m_completionTask.Task;

	internal int OutputCount
	{
		get
		{
			lock (OutgoingLock)
			{
				lock (ValueLock)
				{
					return m_messages.Count;
				}
			}
		}
	}

	internal bool HasExceptions => Volatile.Read(ref m_exceptions) != null;

	internal DataflowBlockOptions DataflowBlockOptions => m_dataflowBlockOptions;

	private bool CanceledOrFaulted
	{
		get
		{
			if (!m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				if (HasExceptions)
				{
					return m_decliningPermanently;
				}
				return false;
			}
			return true;
		}
	}

	private object DebuggerDisplayContent
	{
		get
		{
			IDebuggerDisplay debuggerDisplay = m_owningSource as IDebuggerDisplay;
			return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : m_owningSource)}\"";
		}
	}

	internal SourceCore(ISourceBlock<TOutput> owningSource, DataflowBlockOptions dataflowBlockOptions, Action<ISourceBlock<TOutput>> completeAction, Action<ISourceBlock<TOutput>, int> itemsRemovedAction = null, Func<ISourceBlock<TOutput>, TOutput, IList<TOutput>, int> itemCountingFunc = null)
	{
		m_owningSource = owningSource;
		m_dataflowBlockOptions = dataflowBlockOptions;
		m_itemsRemovedAction = itemsRemovedAction;
		m_itemCountingFunc = itemCountingFunc;
		m_completeAction = completeAction;
		m_targetRegistry = new TargetRegistry<TOutput>(m_owningSource);
	}

	internal IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (linkOptions == null)
		{
			throw new ArgumentNullException("linkOptions");
		}
		if (m_completionTask.Task.IsCompleted)
		{
			if (linkOptions.PropagateCompletion)
			{
				Common.PropagateCompletion(m_completionTask.Task, target, null);
			}
			return Disposables.Nop;
		}
		lock (OutgoingLock)
		{
			if (!m_completionReserved)
			{
				m_targetRegistry.Add(ref target, linkOptions);
				OfferToTargets(target);
				return Common.CreateUnlinker(OutgoingLock, m_targetRegistry, target);
			}
		}
		if (linkOptions.PropagateCompletion)
		{
			Common.PropagateCompletionOnceCompleted(m_completionTask.Task, target);
		}
		return Disposables.Nop;
	}

	internal TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		TOutput result = default(TOutput);
		lock (OutgoingLock)
		{
			if (m_nextMessageReservedFor != target && m_nextMessageReservedFor != null)
			{
				messageConsumed = false;
				return default(TOutput);
			}
			lock (ValueLock)
			{
				if (messageHeader.Id != m_nextMessageId.Value || !m_messages.TryDequeue(out result))
				{
					messageConsumed = false;
					return default(TOutput);
				}
				m_nextMessageReservedFor = null;
				m_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
				if (!m_enableOffering)
				{
					m_enableOffering = true;
				}
				m_nextMessageId.Value++;
				CompleteBlockIfPossible();
				OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
			}
		}
		if (m_itemsRemovedAction != null)
		{
			int arg = ((m_itemCountingFunc == null) ? 1 : m_itemCountingFunc(m_owningSource, result, null));
			m_itemsRemovedAction(m_owningSource, arg);
		}
		messageConsumed = true;
		return result;
	}

	internal bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		lock (OutgoingLock)
		{
			if (m_nextMessageReservedFor == null)
			{
				lock (ValueLock)
				{
					if (messageHeader.Id == m_nextMessageId.Value && !m_messages.IsEmpty)
					{
						m_nextMessageReservedFor = target;
						m_enableOffering = false;
						return true;
					}
				}
			}
		}
		return false;
	}

	internal void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		lock (OutgoingLock)
		{
			if (m_nextMessageReservedFor != target)
			{
				throw new InvalidOperationException(Resource.InvalidOperation_MessageNotReservedByTarget);
			}
			lock (ValueLock)
			{
				if (messageHeader.Id != m_nextMessageId.Value || m_messages.IsEmpty)
				{
					throw new InvalidOperationException(Resource.InvalidOperation_MessageNotReservedByTarget);
				}
				m_nextMessageReservedFor = null;
				m_enableOffering = true;
				OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
				CompleteBlockIfPossible();
			}
		}
	}

	internal bool TryReceive(Predicate<TOutput> filter, out TOutput item)
	{
		item = default(TOutput);
		bool flag = false;
		lock (OutgoingLock)
		{
			if (m_nextMessageReservedFor == null)
			{
				lock (ValueLock)
				{
					if (m_messages.TryDequeueIf(filter, out item))
					{
						m_nextMessageId.Value++;
						if (!m_enableOffering)
						{
							m_enableOffering = true;
						}
						CompleteBlockIfPossible();
						OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
						flag = true;
					}
				}
			}
		}
		if (flag && m_itemsRemovedAction != null)
		{
			int arg = ((m_itemCountingFunc == null) ? 1 : m_itemCountingFunc(m_owningSource, item, null));
			m_itemsRemovedAction(m_owningSource, arg);
		}
		return flag;
	}

	internal bool TryReceiveAll(out IList<TOutput> items)
	{
		items = null;
		int num = 0;
		lock (OutgoingLock)
		{
			if (m_nextMessageReservedFor == null)
			{
				lock (ValueLock)
				{
					if (!m_messages.IsEmpty)
					{
						List<TOutput> list = new List<TOutput>();
						TOutput result;
						while (m_messages.TryDequeue(out result))
						{
							list.Add(result);
						}
						num = list.Count;
						items = list;
						m_nextMessageId.Value++;
						CompleteBlockIfPossible();
					}
				}
			}
		}
		if (num > 0)
		{
			if (m_itemsRemovedAction != null)
			{
				int arg = ((m_itemCountingFunc != null) ? m_itemCountingFunc(m_owningSource, default(TOutput), items) : num);
				m_itemsRemovedAction(m_owningSource, arg);
			}
			return true;
		}
		return false;
	}

	internal void AddMessage(TOutput item)
	{
		if (!m_decliningPermanently)
		{
			m_messages.Enqueue(item);
			Interlocked.MemoryBarrier();
			if (m_taskForOutputProcessing == null)
			{
				OfferAsyncIfNecessaryWithValueLock();
			}
		}
	}

	internal void AddMessages(IEnumerable<TOutput> items)
	{
		if (m_decliningPermanently)
		{
			return;
		}
		if (items is List<TOutput> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				m_messages.Enqueue(list[i]);
			}
		}
		else if (items is TOutput[] array)
		{
			for (int j = 0; j < array.Length; j++)
			{
				m_messages.Enqueue(array[j]);
			}
		}
		else
		{
			foreach (TOutput item in items)
			{
				m_messages.Enqueue(item);
			}
		}
		Interlocked.MemoryBarrier();
		if (m_taskForOutputProcessing == null)
		{
			OfferAsyncIfNecessaryWithValueLock();
		}
	}

	internal void AddException(Exception exception)
	{
		lock (ValueLock)
		{
			Common.AddException(ref m_exceptions, exception);
		}
	}

	internal void AddExceptions(List<Exception> exceptions)
	{
		lock (ValueLock)
		{
			foreach (Exception exception in exceptions)
			{
				Common.AddException(ref m_exceptions, exception);
			}
		}
	}

	internal void AddAndUnwrapAggregateException(AggregateException aggregateException)
	{
		lock (ValueLock)
		{
			Common.AddException(ref m_exceptions, aggregateException, unwrapInnerExceptions: true);
		}
	}

	internal void Complete()
	{
		lock (ValueLock)
		{
			m_decliningPermanently = true;
			Task.Factory.StartNew(delegate(object state)
			{
				SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
				lock (sourceCore.OutgoingLock)
				{
					lock (sourceCore.ValueLock)
					{
						sourceCore.CompleteBlockIfPossible();
					}
				}
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private bool OfferToTargets(ITargetBlock<TOutput> linkToTarget = null)
	{
		if (m_nextMessageReservedFor != null)
		{
			return false;
		}
		DataflowMessageHeader header = default(DataflowMessageHeader);
		TOutput result = default(TOutput);
		bool flag = false;
		if (!Volatile.Read(ref m_enableOffering))
		{
			if (linkToTarget == null)
			{
				return false;
			}
			flag = true;
		}
		if (m_messages.TryPeek(out result))
		{
			header = new DataflowMessageHeader(m_nextMessageId.Value);
		}
		bool messageWasAccepted = false;
		if (header.IsValid)
		{
			if (flag)
			{
				OfferMessageToTarget(header, result, linkToTarget, out messageWasAccepted);
			}
			else
			{
				TargetRegistry<TOutput>.LinkedTargetInfo linkedTargetInfo = m_targetRegistry.FirstTargetNode;
				while (linkedTargetInfo != null)
				{
					TargetRegistry<TOutput>.LinkedTargetInfo next = linkedTargetInfo.Next;
					if (OfferMessageToTarget(header, result, linkedTargetInfo.Target, out messageWasAccepted))
					{
						break;
					}
					linkedTargetInfo = next;
				}
				if (!messageWasAccepted)
				{
					lock (ValueLock)
					{
						m_enableOffering = false;
					}
				}
			}
		}
		if (messageWasAccepted)
		{
			lock (ValueLock)
			{
				if (m_nextMessageId.Value == header.Id)
				{
					m_messages.TryDequeue(out var _);
				}
				m_nextMessageId.Value++;
				if (!m_enableOffering)
				{
					m_enableOffering = true;
				}
				if (linkToTarget != null)
				{
					CompleteBlockIfPossible();
					OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
				}
			}
			if (m_itemsRemovedAction != null)
			{
				int arg = ((m_itemCountingFunc == null) ? 1 : m_itemCountingFunc(m_owningSource, result, null));
				m_itemsRemovedAction(m_owningSource, arg);
			}
		}
		return messageWasAccepted;
	}

	private bool OfferMessageToTarget(DataflowMessageHeader header, TOutput message, ITargetBlock<TOutput> target, out bool messageWasAccepted)
	{
		DataflowMessageStatus dataflowMessageStatus = target.OfferMessage(header, message, m_owningSource, consumeToAccept: false);
		messageWasAccepted = false;
		switch (dataflowMessageStatus)
		{
		case DataflowMessageStatus.Accepted:
			m_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
			messageWasAccepted = true;
			return true;
		case DataflowMessageStatus.DecliningPermanently:
			m_targetRegistry.Remove(target);
			break;
		default:
			if (m_nextMessageReservedFor != null)
			{
				return true;
			}
			break;
		}
		return false;
	}

	private void OfferAsyncIfNecessaryWithValueLock()
	{
		lock (ValueLock)
		{
			OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: false);
		}
	}

	private void OfferAsyncIfNecessary(bool isReplacementReplica, bool outgoingLockKnownAcquired)
	{
		if (m_taskForOutputProcessing == null && m_enableOffering && !m_messages.IsEmpty)
		{
			OfferAsyncIfNecessary_Slow(isReplacementReplica, outgoingLockKnownAcquired);
		}
	}

	private void OfferAsyncIfNecessary_Slow(bool isReplacementReplica, bool outgoingLockKnownAcquired)
	{
		bool flag = true;
		if (outgoingLockKnownAcquired || Monitor.IsEntered(OutgoingLock))
		{
			flag = m_targetRegistry.FirstTargetNode != null;
		}
		if (!flag || CanceledOrFaulted)
		{
			return;
		}
		m_taskForOutputProcessing = new Task(delegate(object thisSourceCore)
		{
			((SourceCore<TOutput>)thisSourceCore).OfferMessagesLoopCore();
		}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.TaskLaunchedForMessageHandling(m_owningSource, m_taskForOutputProcessing, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, m_messages.Count);
		}
		Exception ex = Common.StartTaskSafe(m_taskForOutputProcessing, m_dataflowBlockOptions.TaskScheduler);
		if (ex != null)
		{
			AddException(ex);
			m_taskForOutputProcessing = null;
			m_decliningPermanently = true;
			Task.Factory.StartNew(delegate(object state)
			{
				SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
				lock (sourceCore.OutgoingLock)
				{
					lock (sourceCore.ValueLock)
					{
						sourceCore.CompleteBlockIfPossible();
					}
				}
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
		if (ex != null)
		{
			AddException(ex);
		}
	}

	private void OfferMessagesLoopCore()
	{
		try
		{
			int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
			int num = ((m_dataflowBlockOptions.MaxMessagesPerTask == -1) ? 10 : actualMaxMessagesPerTask);
			int num2 = 0;
			while (num2 < actualMaxMessagesPerTask && !CanceledOrFaulted)
			{
				lock (OutgoingLock)
				{
					int num3 = 0;
					while (num2 < actualMaxMessagesPerTask && num3 < num && !CanceledOrFaulted)
					{
						if (!OfferToTargets())
						{
							return;
						}
						num2++;
						num3++;
					}
				}
			}
		}
		catch (Exception exception)
		{
			AddException(exception);
			m_completeAction(m_owningSource);
		}
		finally
		{
			lock (OutgoingLock)
			{
				lock (ValueLock)
				{
					m_taskForOutputProcessing = null;
					Interlocked.MemoryBarrier();
					OfferAsyncIfNecessary(isReplacementReplica: true, outgoingLockKnownAcquired: true);
					CompleteBlockIfPossible();
				}
			}
		}
	}

	private void CompleteBlockIfPossible()
	{
		if (!m_completionReserved && m_decliningPermanently && m_taskForOutputProcessing == null && m_nextMessageReservedFor == null)
		{
			CompleteBlockIfPossible_Slow();
		}
	}

	private void CompleteBlockIfPossible_Slow()
	{
		if (m_messages.IsEmpty || CanceledOrFaulted)
		{
			m_completionReserved = true;
			Task.Factory.StartNew(delegate(object state)
			{
				((SourceCore<TOutput>)state).CompleteBlockOncePossible();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private void CompleteBlockOncePossible()
	{
		TargetRegistry<TOutput>.LinkedTargetInfo firstTarget;
		List<Exception> exceptions;
		lock (OutgoingLock)
		{
			firstTarget = m_targetRegistry.ClearEntryPoints();
			lock (ValueLock)
			{
				m_messages.Clear();
				exceptions = m_exceptions;
				m_exceptions = null;
			}
		}
		if (exceptions != null)
		{
			m_completionTask.TrySetException(exceptions);
		}
		else if (m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
		{
			m_completionTask.TrySetCanceled();
		}
		else
		{
			m_completionTask.TrySetResult(default(VoidResult));
		}
		m_targetRegistry.PropagateCompletion(firstTarget);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCompleted(m_owningSource);
		}
	}

	internal DebuggingInformation GetDebuggingInformation()
	{
		return new DebuggingInformation(this);
	}
}
