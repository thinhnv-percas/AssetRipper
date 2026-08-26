using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BufferBlock<>.DebugView))]
public sealed class BufferBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IReceivableSourceBlock<T>, ISourceBlock<T>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly BufferBlock<T> m_bufferBlock;

		private readonly SourceCore<T>.DebuggingInformation m_sourceDebuggingInformation;

		public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages
		{
			get
			{
				if (m_bufferBlock.m_boundingState == null)
				{
					return null;
				}
				return m_bufferBlock.m_boundingState.PostponedMessages;
			}
		}

		public IEnumerable<T> Queue => m_sourceDebuggingInformation.OutputQueue;

		public Task TaskForInputProcessing
		{
			get
			{
				if (m_bufferBlock.m_boundingState == null)
				{
					return null;
				}
				return m_bufferBlock.m_boundingState.TaskForInputProcessing;
			}
		}

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public DataflowBlockOptions DataflowBlockOptions => m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsDecliningPermanently => m_bufferBlock.m_targetDecliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_bufferBlock);

		public TargetRegistry<T> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<T> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(BufferBlock<T> bufferBlock)
		{
			m_bufferBlock = bufferBlock;
			m_sourceDebuggingInformation = bufferBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly SourceCore<T> m_source;

	private readonly BoundingStateWithPostponedAndTask<T> m_boundingState;

	private bool m_targetDecliningPermanently;

	private bool m_targetCompletionReserved;

	private object IncomingLock => m_source;

	public int Count => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	private int CountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, Count={1}", new object[2]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		CountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public BufferBlock()
		: this(DataflowBlockOptions.Default)
	{
	}

	public BufferBlock(DataflowBlockOptions dataflowBlockOptions)
	{
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<ISourceBlock<T>, int> itemsRemovedAction = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = delegate(ISourceBlock<T> owningSource, int count)
			{
				((BufferBlock<T>)owningSource).OnItemsRemoved(count);
			};
			m_boundingState = new BoundingStateWithPostponedAndTask<T>(dataflowBlockOptions.BoundedCapacity);
		}
		m_source = new SourceCore<T>(this, dataflowBlockOptions, delegate(ISourceBlock<T> owningSource)
		{
			((BufferBlock<T>)owningSource).Complete();
		}, itemsRemovedAction);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (BufferBlock<T>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object owningSource)
		{
			((BufferBlock<T>)owningSource).Complete();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
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
				if (m_targetDecliningPermanently)
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

	private void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting, bool revertProcessingState = false)
	{
		lock (IncomingLock)
		{
			if (exception != null && (!m_targetDecliningPermanently || storeExceptionEvenIfAlreadyCompleting))
			{
				m_source.AddException(exception);
			}
			if (revertProcessingState)
			{
				m_boundingState.TaskForInputProcessing = null;
			}
			m_targetDecliningPermanently = true;
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

	public bool TryReceiveAll(out IList<T> items)
	{
		return m_source.TryReceiveAll(out items);
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
		if (m_targetDecliningPermanently || m_boundingState.TaskForInputProcessing != null || m_boundingState.PostponedMessages.Count <= 0 || !m_boundingState.CountIsLessThanBound)
		{
			return;
		}
		m_boundingState.TaskForInputProcessing = new Task(delegate(object state)
		{
			((BufferBlock<T>)state).ConsumeMessagesLoopCore();
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
		if (!m_targetDecliningPermanently || m_targetCompletionReserved || (m_boundingState != null && m_boundingState.TaskForInputProcessing != null))
		{
			return;
		}
		m_targetCompletionReserved = true;
		if (m_boundingState != null && m_boundingState.PostponedMessages.Count > 0)
		{
			Task.Factory.StartNew(delegate(object state)
			{
				BufferBlock<T> bufferBlock = (BufferBlock<T>)state;
				List<Exception> exceptions = null;
				if (bufferBlock.m_boundingState != null)
				{
					Common.ReleaseAllPostponedMessages(bufferBlock, bufferBlock.m_boundingState.PostponedMessages, ref exceptions);
				}
				if (exceptions != null)
				{
					bufferBlock.m_source.AddExceptions(exceptions);
				}
				bufferBlock.m_source.Complete();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
		else
		{
			m_source.Complete();
		}
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
