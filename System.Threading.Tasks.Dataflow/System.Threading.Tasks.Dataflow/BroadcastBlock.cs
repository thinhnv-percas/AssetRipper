using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BroadcastBlock<>.DebugView))]
public sealed class BroadcastBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IReceivableSourceBlock<T>, ISourceBlock<T>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly BroadcastBlock<T> m_broadcastBlock;

		private readonly BroadcastingSourceCore<T>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<T> InputQueue => m_sourceDebuggingInformation.InputQueue;

		public bool HasValue => m_broadcastBlock.HasValueForDebugger;

		public T Value => m_broadcastBlock.ValueForDebugger;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public DataflowBlockOptions DataflowBlockOptions => m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsDecliningPermanently => m_broadcastBlock.m_decliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_broadcastBlock);

		public TargetRegistry<T> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<T> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(BroadcastBlock<T> broadcastBlock)
		{
			m_broadcastBlock = broadcastBlock;
			m_sourceDebuggingInformation = broadcastBlock.m_source.GetDebuggingInformation();
		}
	}

	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	private sealed class BroadcastingSourceCore<TOutput>
	{
		internal sealed class DebuggingInformation
		{
			private BroadcastingSourceCore<TOutput> m_source;

			public bool HasValue => m_source.m_currentMessageIsValid;

			public TOutput Value => m_source.m_currentMessage;

			public int InputCount => m_source.m_messages.Count;

			public IEnumerable<TOutput> InputQueue => m_source.m_messages.ToList();

			public Task TaskForOutputProcessing => m_source.m_taskForOutputProcessing;

			public DataflowBlockOptions DataflowBlockOptions => m_source.m_dataflowBlockOptions;

			public bool IsDecliningPermanently => m_source.m_decliningPermanently;

			public bool IsCompleted => m_source.Completion.IsCompleted;

			public TargetRegistry<TOutput> LinkedTargets => m_source.m_targetRegistry;

			public ITargetBlock<TOutput> NextMessageReservedFor => m_source.m_nextMessageReservedFor;

			public DebuggingInformation(BroadcastingSourceCore<TOutput> source)
			{
				m_source = source;
			}
		}

		private readonly TargetRegistry<TOutput> m_targetRegistry;

		private readonly Queue<TOutput> m_messages = new Queue<TOutput>();

		private readonly TaskCompletionSource<VoidResult> m_completionTask = new TaskCompletionSource<VoidResult>();

		private readonly Action<int> m_itemsRemovedAction;

		private readonly BroadcastBlock<TOutput> m_owningSource;

		private readonly DataflowBlockOptions m_dataflowBlockOptions;

		private readonly Func<TOutput, TOutput> m_cloningFunction;

		private bool m_currentMessageIsValid;

		private TOutput m_currentMessage;

		private ITargetBlock<TOutput> m_nextMessageReservedFor;

		private bool m_enableOffering;

		private bool m_decliningPermanently;

		private Task m_taskForOutputProcessing;

		private List<Exception> m_exceptions;

		private long m_nextMessageId = 1L;

		private bool m_completionReserved;

		private object OutgoingLock => m_completionTask;

		private object ValueLock => m_targetRegistry;

		private bool CanceledOrFaulted
		{
			get
			{
				if (!m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					if (Volatile.Read(ref m_exceptions) != null)
					{
						return m_decliningPermanently;
					}
					return false;
				}
				return true;
			}
		}

		internal Task Completion => m_completionTask.Task;

		internal DataflowBlockOptions DataflowBlockOptions => m_dataflowBlockOptions;

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay owningSource = m_owningSource;
				return $"Block=\"{((owningSource != null) ? owningSource.Content : m_owningSource)}\"";
			}
		}

		internal BroadcastingSourceCore(BroadcastBlock<TOutput> owningSource, Func<TOutput, TOutput> cloningFunction, DataflowBlockOptions dataflowBlockOptions, Action<int> itemsRemovedAction)
		{
			m_owningSource = owningSource;
			m_cloningFunction = cloningFunction;
			m_dataflowBlockOptions = dataflowBlockOptions;
			m_itemsRemovedAction = itemsRemovedAction;
			m_targetRegistry = new TargetRegistry<TOutput>(m_owningSource);
		}

		internal bool TryReceive(Predicate<TOutput> filter, out TOutput item)
		{
			TOutput currentMessage;
			bool currentMessageIsValid;
			lock (OutgoingLock)
			{
				lock (ValueLock)
				{
					currentMessage = m_currentMessage;
					currentMessageIsValid = m_currentMessageIsValid;
				}
			}
			if (currentMessageIsValid && (filter == null || filter(currentMessage)))
			{
				item = CloneItem(currentMessage);
				return true;
			}
			item = default(TOutput);
			return false;
		}

		internal bool TryReceiveAll(out IList<TOutput> items)
		{
			if (TryReceive(null, out var item))
			{
				items = new TOutput[1] { item };
				return true;
			}
			items = null;
			return false;
		}

		internal void AddMessage(TOutput item)
		{
			lock (ValueLock)
			{
				if (!m_decliningPermanently)
				{
					m_messages.Enqueue(item);
					if (m_messages.Count == 1)
					{
						m_enableOffering = true;
					}
					OfferAsyncIfNecessary();
				}
			}
		}

		internal void Complete()
		{
			lock (ValueLock)
			{
				m_decliningPermanently = true;
				Task.Factory.StartNew(delegate(object state)
				{
					BroadcastingSourceCore<TOutput> broadcastingSourceCore = (BroadcastingSourceCore<TOutput>)state;
					lock (broadcastingSourceCore.OutgoingLock)
					{
						lock (broadcastingSourceCore.ValueLock)
						{
							broadcastingSourceCore.CompleteBlockIfPossible();
						}
					}
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private TOutput CloneItem(TOutput item)
		{
			if (m_cloningFunction == null)
			{
				return item;
			}
			return m_cloningFunction(item);
		}

		private void OfferCurrentMessageToNewTarget(ITargetBlock<TOutput> target)
		{
			TOutput currentMessage;
			bool currentMessageIsValid;
			lock (ValueLock)
			{
				currentMessage = m_currentMessage;
				currentMessageIsValid = m_currentMessageIsValid;
			}
			if (!currentMessageIsValid)
			{
				return;
			}
			bool flag = m_cloningFunction != null;
			switch (target.OfferMessage(new DataflowMessageHeader(m_nextMessageId), currentMessage, m_owningSource, flag))
			{
			case DataflowMessageStatus.Accepted:
				if (!flag)
				{
					m_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
				}
				break;
			case DataflowMessageStatus.DecliningPermanently:
				m_targetRegistry.Remove(target);
				break;
			}
		}

		private bool OfferToTargets()
		{
			DataflowMessageHeader header = default(DataflowMessageHeader);
			TOutput message = default(TOutput);
			int num = 0;
			lock (ValueLock)
			{
				if (m_nextMessageReservedFor != null || m_messages.Count <= 0)
				{
					m_enableOffering = false;
					return false;
				}
				if (m_targetRegistry.FirstTargetNode == null)
				{
					while (m_messages.Count > 1)
					{
						m_messages.Dequeue();
						num++;
					}
				}
				message = (m_currentMessage = m_messages.Dequeue());
				num++;
				m_currentMessageIsValid = true;
				header = new DataflowMessageHeader(++m_nextMessageId);
				if (m_messages.Count == 0)
				{
					m_enableOffering = false;
				}
			}
			if (header.IsValid)
			{
				if (m_itemsRemovedAction != null)
				{
					m_itemsRemovedAction(num);
				}
				TargetRegistry<TOutput>.LinkedTargetInfo linkedTargetInfo = m_targetRegistry.FirstTargetNode;
				while (linkedTargetInfo != null)
				{
					TargetRegistry<TOutput>.LinkedTargetInfo next = linkedTargetInfo.Next;
					ITargetBlock<TOutput> target = linkedTargetInfo.Target;
					OfferMessageToTarget(header, message, target);
					linkedTargetInfo = next;
				}
			}
			return true;
		}

		private void OfferMessageToTarget(DataflowMessageHeader header, TOutput message, ITargetBlock<TOutput> target)
		{
			bool flag = m_cloningFunction != null;
			switch (target.OfferMessage(header, message, m_owningSource, flag))
			{
			case DataflowMessageStatus.Accepted:
				if (!flag)
				{
					m_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
				}
				break;
			case DataflowMessageStatus.DecliningPermanently:
				m_targetRegistry.Remove(target);
				break;
			case DataflowMessageStatus.Declined:
			case DataflowMessageStatus.Postponed:
			case DataflowMessageStatus.NotAvailable:
				break;
			}
		}

		private void OfferAsyncIfNecessary(bool isReplacementReplica = false)
		{
			bool flag = m_taskForOutputProcessing != null;
			bool flag2 = m_enableOffering && m_messages.Count > 0;
			if (flag || !flag2 || CanceledOrFaulted)
			{
				return;
			}
			m_taskForOutputProcessing = new Task(delegate(object thisSourceCore)
			{
				((BroadcastingSourceCore<TOutput>)thisSourceCore).OfferMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(m_owningSource, m_taskForOutputProcessing, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, m_messages.Count);
			}
			Exception ex = Common.StartTaskSafe(m_taskForOutputProcessing, m_dataflowBlockOptions.TaskScheduler);
			if (ex == null)
			{
				return;
			}
			AddException(ex);
			m_decliningPermanently = true;
			m_taskForOutputProcessing = null;
			Task.Factory.StartNew(delegate(object state)
			{
				BroadcastingSourceCore<TOutput> broadcastingSourceCore = (BroadcastingSourceCore<TOutput>)state;
				lock (broadcastingSourceCore.OutgoingLock)
				{
					lock (broadcastingSourceCore.ValueLock)
					{
						broadcastingSourceCore.CompleteBlockIfPossible();
					}
				}
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}

		private void OfferMessagesLoopCore()
		{
			try
			{
				int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
				lock (OutgoingLock)
				{
					for (int i = 0; i < actualMaxMessagesPerTask; i++)
					{
						if (CanceledOrFaulted)
						{
							break;
						}
						if (!OfferToTargets())
						{
							break;
						}
					}
				}
			}
			catch (Exception exception)
			{
				m_owningSource.CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: true);
			}
			finally
			{
				lock (OutgoingLock)
				{
					lock (ValueLock)
					{
						m_taskForOutputProcessing = null;
						OfferAsyncIfNecessary(isReplacementReplica: true);
						CompleteBlockIfPossible();
					}
				}
			}
		}

		private void CompleteBlockIfPossible()
		{
			if (!m_completionReserved)
			{
				bool flag = m_taskForOutputProcessing != null;
				bool flag2 = m_decliningPermanently && m_messages.Count == 0;
				if (!flag && (flag2 || CanceledOrFaulted))
				{
					CompleteBlockIfPossible_Slow();
				}
			}
		}

		private void CompleteBlockIfPossible_Slow()
		{
			m_completionReserved = true;
			Task.Factory.StartNew(delegate(object thisSourceCore)
			{
				((BroadcastingSourceCore<TOutput>)thisSourceCore).CompleteBlockOncePossible();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
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
			lock (OutgoingLock)
			{
				if (m_completionReserved)
				{
					OfferCurrentMessageToNewTarget(target);
					if (linkOptions.PropagateCompletion)
					{
						Common.PropagateCompletionOnceCompleted(m_completionTask.Task, target);
					}
					return Disposables.Nop;
				}
				m_targetRegistry.Add(ref target, linkOptions);
				OfferCurrentMessageToNewTarget(target);
				return Common.CreateUnlinker(OutgoingLock, m_targetRegistry, target);
			}
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
			TOutput currentMessage;
			lock (OutgoingLock)
			{
				lock (ValueLock)
				{
					if (messageHeader.Id != m_nextMessageId)
					{
						messageConsumed = false;
						return default(TOutput);
					}
					if (m_nextMessageReservedFor == target)
					{
						m_nextMessageReservedFor = null;
						m_enableOffering = true;
					}
					m_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
					OfferAsyncIfNecessary();
					CompleteBlockIfPossible();
					currentMessage = m_currentMessage;
				}
			}
			messageConsumed = true;
			return CloneItem(currentMessage);
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
						if (messageHeader.Id == m_nextMessageId)
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
				TOutput currentMessage;
				lock (ValueLock)
				{
					if (messageHeader.Id != m_nextMessageId)
					{
						throw new InvalidOperationException(Resource.InvalidOperation_MessageNotReservedByTarget);
					}
					m_nextMessageReservedFor = null;
					m_enableOffering = true;
					currentMessage = m_currentMessage;
					OfferAsyncIfNecessary();
				}
				OfferMessageToTarget(messageHeader, currentMessage, target);
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

		internal DebuggingInformation GetDebuggingInformation()
		{
			return new DebuggingInformation(this);
		}
	}

	private readonly BroadcastingSourceCore<T> m_source;

	private readonly BoundingStateWithPostponedAndTask<T> m_boundingState;

	private bool m_decliningPermanently;

	private bool m_completionReserved;

	private object IncomingLock => m_source;

	public Task Completion => m_source.Completion;

	private bool HasValueForDebugger => m_source.GetDebuggingInformation().HasValue;

	private T ValueForDebugger => m_source.GetDebuggingInformation().Value;

	private object DebuggerDisplayContent => string.Format("{0}, HasValue={1}, Value={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		HasValueForDebugger,
		ValueForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public BroadcastBlock(Func<T, T> cloningFunction)
		: this(cloningFunction, DataflowBlockOptions.Default)
	{
	}

	public BroadcastBlock(Func<T, T> cloningFunction, DataflowBlockOptions dataflowBlockOptions)
	{
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<int> itemsRemovedAction = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = OnItemsRemoved;
			m_boundingState = new BoundingStateWithPostponedAndTask<T>(dataflowBlockOptions.BoundedCapacity);
		}
		m_source = new BroadcastingSourceCore<T>(this, cloningFunction, dataflowBlockOptions, itemsRemovedAction);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (BroadcastBlock<T>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((BroadcastBlock<T>)state).Complete();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public void Complete()
	{
		CompleteCore(null, storeExceptionEvenIfAlreadyCompleting: false);
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: false);
	}

	internal void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting, bool revertProcessingState = false)
	{
		lock (IncomingLock)
		{
			if (exception != null && (!m_decliningPermanently || storeExceptionEvenIfAlreadyCompleting))
			{
				m_source.AddException(exception);
			}
			if (revertProcessingState)
			{
				m_boundingState.TaskForInputProcessing = null;
			}
			m_decliningPermanently = true;
			CompleteTargetIfPossible();
		}
	}

	public IDisposable LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<T> filter, out T item)
	{
		return m_source.TryReceive(filter, out item);
	}

	bool IReceivableSourceBlock<T>.TryReceiveAll(out IList<T> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
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
					CompleteTargetIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (m_boundingState == null || (m_boundingState.CountIsLessThanBound && m_boundingState.PostponedMessages.Count == 0 && m_boundingState.TaskForInputProcessing == null))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					m_source.AddMessage(messageValue);
					if (m_boundingState != null)
					{
						m_boundingState.CurrentCount++;
					}
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					m_boundingState.PostponedMessages.Push(source, messageHeader);
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}
		throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
	}

	private void OnItemsRemoved(int numItemsRemoved)
	{
		if (m_boundingState != null)
		{
			lock (IncomingLock)
			{
				m_boundingState.CurrentCount -= numItemsRemoved;
				ConsumeAsyncIfNecessary();
				CompleteTargetIfPossible();
			}
		}
	}

	internal void ConsumeAsyncIfNecessary(bool isReplacementReplica = false)
	{
		if (m_decliningPermanently || m_boundingState.TaskForInputProcessing != null || m_boundingState.PostponedMessages.Count <= 0 || !m_boundingState.CountIsLessThanBound)
		{
			return;
		}
		m_boundingState.TaskForInputProcessing = new Task(delegate(object state)
		{
			((BroadcastBlock<T>)state).ConsumeMessagesLoopCore();
		}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.TaskLaunchedForMessageHandling(this, m_boundingState.TaskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, m_boundingState.PostponedMessages.Count);
		}
		Exception ex = Common.StartTaskSafe(m_boundingState.TaskForInputProcessing, m_source.DataflowBlockOptions.TaskScheduler);
		if (ex != null)
		{
			Task.Factory.StartNew(delegate(object exc)
			{
				CompleteCore((Exception)exc, storeExceptionEvenIfAlreadyCompleting: true, revertProcessingState: true);
			}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private void ConsumeMessagesLoopCore()
	{
		try
		{
			int actualMaxMessagesPerTask = m_source.DataflowBlockOptions.ActualMaxMessagesPerTask;
			for (int i = 0; i < actualMaxMessagesPerTask; i++)
			{
				if (!ConsumeAndStoreOneMessageIfAvailable())
				{
					break;
				}
			}
		}
		catch (Exception exception)
		{
			CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: true);
		}
		finally
		{
			lock (IncomingLock)
			{
				m_boundingState.TaskForInputProcessing = null;
				ConsumeAsyncIfNecessary(isReplacementReplica: true);
				CompleteTargetIfPossible();
			}
		}
	}

	private bool ConsumeAndStoreOneMessageIfAvailable()
	{
		while (true)
		{
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
			lock (IncomingLock)
			{
				if (!m_boundingState.CountIsLessThanBound)
				{
					return false;
				}
				if (!m_boundingState.PostponedMessages.TryPop(out item))
				{
					return false;
				}
				m_boundingState.CurrentCount++;
			}
			bool messageConsumed = false;
			try
			{
				T item2 = item.Key.ConsumeMessage(item.Value, this, out messageConsumed);
				if (messageConsumed)
				{
					m_source.AddMessage(item2);
					return true;
				}
			}
			finally
			{
				if (!messageConsumed)
				{
					lock (IncomingLock)
					{
						m_boundingState.CurrentCount--;
					}
				}
			}
		}
	}

	private void CompleteTargetIfPossible()
	{
		if (!m_decliningPermanently || m_completionReserved || (m_boundingState != null && m_boundingState.TaskForInputProcessing != null))
		{
			return;
		}
		m_completionReserved = true;
		if (m_boundingState != null && m_boundingState.PostponedMessages.Count > 0)
		{
			Task.Factory.StartNew(delegate(object state)
			{
				BroadcastBlock<T> broadcastBlock = (BroadcastBlock<T>)state;
				List<Exception> exceptions = null;
				if (broadcastBlock.m_boundingState != null)
				{
					Common.ReleaseAllPostponedMessages(broadcastBlock, broadcastBlock.m_boundingState.PostponedMessages, ref exceptions);
				}
				if (exceptions != null)
				{
					broadcastBlock.m_source.AddExceptions(exceptions);
				}
				broadcastBlock.m_source.Complete();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
		else
		{
			m_source.Complete();
		}
	}

	T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
