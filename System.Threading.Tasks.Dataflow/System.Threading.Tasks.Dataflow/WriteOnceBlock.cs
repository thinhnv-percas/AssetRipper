using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(WriteOnceBlock<>.DebugView))]
public sealed class WriteOnceBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IReceivableSourceBlock<T>, ISourceBlock<T>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly WriteOnceBlock<T> m_writeOnceBlock;

		public bool IsCompleted => m_writeOnceBlock.Completion.IsCompleted;

		public int Id => Common.GetBlockId(m_writeOnceBlock);

		public bool HasValue => m_writeOnceBlock.HasValue;

		public T Value => m_writeOnceBlock.Value;

		public DataflowBlockOptions DataflowBlockOptions => m_writeOnceBlock.m_dataflowBlockOptions;

		public TargetRegistry<T> LinkedTargets => m_writeOnceBlock.m_targetRegistry;

		public DebugView(WriteOnceBlock<T> writeOnceBlock)
		{
			m_writeOnceBlock = writeOnceBlock;
		}
	}

	private readonly TargetRegistry<T> m_targetRegistry;

	private readonly Func<T, T> m_cloningFunction;

	private readonly DataflowBlockOptions m_dataflowBlockOptions;

	private TaskCompletionSource<VoidResult> m_lazyCompletionTaskSource;

	private bool m_decliningPermanently;

	private bool m_completionReserved;

	private DataflowMessageHeader m_header;

	private T m_value;

	private object ValueLock => m_targetRegistry;

	public Task Completion => CompletionTaskSource.Task;

	private TaskCompletionSource<VoidResult> CompletionTaskSource
	{
		get
		{
			if (m_lazyCompletionTaskSource == null)
			{
				Interlocked.CompareExchange(ref m_lazyCompletionTaskSource, new TaskCompletionSource<VoidResult>(), null);
			}
			return m_lazyCompletionTaskSource;
		}
	}

	private bool HasValue => m_header.IsValid;

	private T Value
	{
		get
		{
			if (!m_header.IsValid)
			{
				return default(T);
			}
			return m_value;
		}
	}

	private object DebuggerDisplayContent => string.Format("{0}, HasValue={1}, Value={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_dataflowBlockOptions),
		HasValue,
		Value
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public WriteOnceBlock(Func<T, T> cloningFunction)
		: this(cloningFunction, DataflowBlockOptions.Default)
	{
	}

	public WriteOnceBlock(Func<T, T> cloningFunction, DataflowBlockOptions dataflowBlockOptions)
	{
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		m_cloningFunction = cloningFunction;
		m_dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		m_targetRegistry = new TargetRegistry<T>(this);
		if (dataflowBlockOptions.CancellationToken.CanBeCanceled)
		{
			m_lazyCompletionTaskSource = new TaskCompletionSource<VoidResult>();
			if (dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				m_completionReserved = (m_decliningPermanently = true);
				m_lazyCompletionTaskSource.SetCanceled();
			}
			else
			{
				Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_lazyCompletionTaskSource.Task, delegate(object state)
				{
					((WriteOnceBlock<T>)state).Complete();
				}, this);
			}
		}
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	private void CompleteBlockAsync(IList<Exception> exceptions)
	{
		if (exceptions == null)
		{
			Task task = new Task(delegate(object state)
			{
				((WriteOnceBlock<T>)state).OfferToTargetsAndCompleteBlock();
			}, this, Common.GetCreationOptionsForTask());
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(this, task, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, m_header.IsValid ? 1 : 0);
			}
			Exception ex = Common.StartTaskSafe(task, m_dataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				CompleteCore(ex, storeExceptionEvenIfAlreadyCompleting: true);
			}
		}
		else
		{
			Task.Factory.StartNew(delegate(object state)
			{
				Tuple<WriteOnceBlock<T>, IList<Exception>> tuple = (Tuple<WriteOnceBlock<T>, IList<Exception>>)state;
				tuple.Item1.CompleteBlock(tuple.Item2);
			}, Tuple.Create(this, exceptions), CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}
	}

	private void OfferToTargetsAndCompleteBlock()
	{
		List<Exception> exceptions = OfferToTargets();
		CompleteBlock(exceptions);
	}

	private void CompleteBlock(IList<Exception> exceptions)
	{
		TargetRegistry<T>.LinkedTargetInfo firstTarget = m_targetRegistry.ClearEntryPoints();
		if (exceptions != null && exceptions.Count > 0)
		{
			CompletionTaskSource.TrySetException(exceptions);
		}
		else if (m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
		{
			CompletionTaskSource.TrySetCanceled();
		}
		else if (Interlocked.CompareExchange(ref m_lazyCompletionTaskSource, Common.CompletedVoidResultTaskCompletionSource, null) != null)
		{
			m_lazyCompletionTaskSource.TrySetResult(default(VoidResult));
		}
		m_targetRegistry.PropagateCompletion(firstTarget);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCompleted(this);
		}
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: false);
	}

	public void Complete()
	{
		CompleteCore(null, storeExceptionEvenIfAlreadyCompleting: false);
	}

	private void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting)
	{
		bool flag = false;
		lock (ValueLock)
		{
			if (m_decliningPermanently && !storeExceptionEvenIfAlreadyCompleting)
			{
				return;
			}
			m_decliningPermanently = true;
			if (!m_completionReserved || storeExceptionEvenIfAlreadyCompleting)
			{
				flag = (m_completionReserved = true);
			}
		}
		if (flag)
		{
			List<Exception> list = null;
			if (exception != null)
			{
				list = new List<Exception>();
				list.Add(exception);
			}
			CompleteBlockAsync(list);
		}
	}

	public bool TryReceive(Predicate<T> filter, out T item)
	{
		if (m_header.IsValid && (filter == null || filter(m_value)))
		{
			item = CloneItem(m_value);
			return true;
		}
		item = default(T);
		return false;
	}

	bool IReceivableSourceBlock<T>.TryReceiveAll(out IList<T> items)
	{
		if (TryReceive(null, out var item))
		{
			items = new T[1] { item };
			return true;
		}
		items = null;
		return false;
	}

	public IDisposable LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (linkOptions == null)
		{
			throw new ArgumentNullException("linkOptions");
		}
		bool hasValue;
		lock (ValueLock)
		{
			hasValue = HasValue;
			bool completionReserved = m_completionReserved;
			if (!hasValue && !completionReserved)
			{
				m_targetRegistry.Add(ref target, linkOptions);
				return Common.CreateUnlinker(ValueLock, m_targetRegistry, target);
			}
		}
		if (hasValue)
		{
			bool consumeToAccept = m_cloningFunction != null;
			target.OfferMessage(m_header, m_value, this, consumeToAccept);
		}
		if (linkOptions.PropagateCompletion)
		{
			Common.PropagateCompletionOnceCompleted(Completion, target);
		}
		return Disposables.Nop;
	}

	DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (source == null && consumeToAccept)
		{
			throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
		}
		bool flag = false;
		lock (ValueLock)
		{
			if (m_decliningPermanently)
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
			m_header = Common.SingleMessageHeader;
			m_value = messageValue;
			m_decliningPermanently = true;
			if (!m_completionReserved)
			{
				flag = (m_completionReserved = true);
			}
		}
		if (flag)
		{
			CompleteBlockAsync(null);
		}
		return DataflowMessageStatus.Accepted;
	}

	T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (m_header.Id == messageHeader.Id)
		{
			messageConsumed = true;
			return CloneItem(m_value);
		}
		messageConsumed = false;
		return default(T);
	}

	bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		return m_header.Id == messageHeader.Id;
	}

	void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
	{
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (m_header.Id != messageHeader.Id)
		{
			throw new InvalidOperationException(Resource.InvalidOperation_MessageNotReservedByTarget);
		}
		bool consumeToAccept = m_cloningFunction != null;
		target.OfferMessage(m_header, m_value, this, consumeToAccept);
	}

	private T CloneItem(T item)
	{
		if (m_cloningFunction == null)
		{
			return item;
		}
		return m_cloningFunction(item);
	}

	private List<Exception> OfferToTargets()
	{
		List<Exception> list = null;
		if (HasValue)
		{
			TargetRegistry<T>.LinkedTargetInfo linkedTargetInfo = m_targetRegistry.FirstTargetNode;
			while (linkedTargetInfo != null)
			{
				TargetRegistry<T>.LinkedTargetInfo next = linkedTargetInfo.Next;
				ITargetBlock<T> target = linkedTargetInfo.Target;
				try
				{
					bool consumeToAccept = m_cloningFunction != null;
					target.OfferMessage(m_header, m_value, this, consumeToAccept);
				}
				catch (Exception ex)
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, m_value);
					Common.AddException(ref list, ex);
				}
				linkedTargetInfo = next;
			}
		}
		return list;
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_dataflowBlockOptions);
	}
}
