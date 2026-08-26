using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerTypeProxy(typeof(JoinBlock<, >.DebugView))]
[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
public sealed class JoinBlock<T1, T2> : IReceivableSourceBlock<Tuple<T1, T2>>, ISourceBlock<Tuple<T1, T2>>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly JoinBlock<T1, T2> m_joinBlock;

		private readonly SourceCore<Tuple<T1, T2>>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<Tuple<T1, T2>> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public long JoinsCreated => m_joinBlock.m_sharedResources.m_joinsCreated;

		public Task TaskForInputProcessing => m_joinBlock.m_sharedResources.m_taskForInputProcessing;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsDecliningPermanently => m_joinBlock.m_sharedResources.m_decliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_joinBlock);

		public ITargetBlock<T1> Target1 => m_joinBlock.m_target1;

		public ITargetBlock<T2> Target2 => m_joinBlock.m_target2;

		public TargetRegistry<Tuple<T1, T2>> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<Tuple<T1, T2>> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(JoinBlock<T1, T2> joinBlock)
		{
			m_joinBlock = joinBlock;
			m_sourceDebuggingInformation = joinBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly JoinBlockTargetSharedResources m_sharedResources;

	private readonly SourceCore<Tuple<T1, T2>> m_source;

	private readonly JoinBlockTarget<T1> m_target1;

	private readonly JoinBlockTarget<T2> m_target2;

	public int OutputCount => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	public ITargetBlock<T1> Target1 => m_target1;

	public ITargetBlock<T2> Target2 => m_target2;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, OutputCount={1}", new object[2]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public JoinBlock()
		: this(GroupingDataflowBlockOptions.Default)
	{
	}

	public JoinBlock(GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<ISourceBlock<Tuple<T1, T2>>, int> itemsRemovedAction = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = delegate(ISourceBlock<Tuple<T1, T2>> owningSource, int count)
			{
				((JoinBlock<T1, T2>)owningSource).m_sharedResources.OnItemsRemoved(count);
			};
		}
		m_source = new SourceCore<Tuple<T1, T2>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<T1, T2>> owningSource)
		{
			((JoinBlock<T1, T2>)owningSource).m_sharedResources.CompleteEachTarget();
		}, itemsRemovedAction);
		JoinBlockTargetBase[] array = new JoinBlockTargetBase[2];
		m_sharedResources = new JoinBlockTargetSharedResources(this, array, delegate
		{
			m_source.AddMessage(Tuple.Create(m_target1.GetOneMessage(), m_target2.GetOneMessage()));
		}, delegate(Exception exception)
		{
			Volatile.Write(ref m_sharedResources.m_hasExceptions, value: true);
			m_source.AddException(exception);
		}, dataflowBlockOptions);
		array[0] = (m_target1 = new JoinBlockTarget<T1>(m_sharedResources));
		array[1] = (m_target2 = new JoinBlockTarget<T2>(m_sharedResources));
		Task.Factory.ContinueWhenAll(new Task[2] { m_target1.CompletionTaskInternal, m_target2.CompletionTaskInternal }, delegate
		{
			m_source.Complete();
		}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (JoinBlock<T1, T2>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((JoinBlock<T1, T2>)state).m_sharedResources.CompleteEachTarget();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2>> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<Tuple<T1, T2>> filter, out Tuple<T1, T2> item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<Tuple<T1, T2>> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	public void Complete()
	{
		m_target1.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		m_target2.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		lock (m_sharedResources.IncomingLock)
		{
			if (!m_sharedResources.m_decliningPermanently)
			{
				m_sharedResources.m_exceptionAction(exception);
			}
		}
		Complete();
	}

	Tuple<T1, T2> ISourceBlock<Tuple<T1, T2>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<Tuple<T1, T2>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<Tuple<T1, T2>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
[DebuggerTypeProxy(typeof(JoinBlock<, , >.DebugView))]
[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
public sealed class JoinBlock<T1, T2, T3> : IReceivableSourceBlock<Tuple<T1, T2, T3>>, ISourceBlock<Tuple<T1, T2, T3>>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly JoinBlock<T1, T2, T3> m_joinBlock;

		private readonly SourceCore<Tuple<T1, T2, T3>>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<Tuple<T1, T2, T3>> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public long JoinsCreated => m_joinBlock.m_sharedResources.m_joinsCreated;

		public Task TaskForInputProcessing => m_joinBlock.m_sharedResources.m_taskForInputProcessing;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsDecliningPermanently => m_joinBlock.m_sharedResources.m_decliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_joinBlock);

		public ITargetBlock<T1> Target1 => m_joinBlock.m_target1;

		public ITargetBlock<T2> Target2 => m_joinBlock.m_target2;

		public ITargetBlock<T3> Target3 => m_joinBlock.m_target3;

		public TargetRegistry<Tuple<T1, T2, T3>> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<Tuple<T1, T2, T3>> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(JoinBlock<T1, T2, T3> joinBlock)
		{
			m_joinBlock = joinBlock;
			m_sourceDebuggingInformation = joinBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly JoinBlockTargetSharedResources m_sharedResources;

	private readonly SourceCore<Tuple<T1, T2, T3>> m_source;

	private readonly JoinBlockTarget<T1> m_target1;

	private readonly JoinBlockTarget<T2> m_target2;

	private readonly JoinBlockTarget<T3> m_target3;

	public int OutputCount => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	public ITargetBlock<T1> Target1 => m_target1;

	public ITargetBlock<T2> Target2 => m_target2;

	public ITargetBlock<T3> Target3 => m_target3;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0} OutputCount={1}", new object[2]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public JoinBlock()
		: this(GroupingDataflowBlockOptions.Default)
	{
	}

	public JoinBlock(GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<ISourceBlock<Tuple<T1, T2, T3>>, int> itemsRemovedAction = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = delegate(ISourceBlock<Tuple<T1, T2, T3>> owningSource, int count)
			{
				((JoinBlock<T1, T2, T3>)owningSource).m_sharedResources.OnItemsRemoved(count);
			};
		}
		m_source = new SourceCore<Tuple<T1, T2, T3>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<T1, T2, T3>> owningSource)
		{
			((JoinBlock<T1, T2, T3>)owningSource).m_sharedResources.CompleteEachTarget();
		}, itemsRemovedAction);
		JoinBlockTargetBase[] array = new JoinBlockTargetBase[3];
		m_sharedResources = new JoinBlockTargetSharedResources(this, array, delegate
		{
			m_source.AddMessage(Tuple.Create(m_target1.GetOneMessage(), m_target2.GetOneMessage(), m_target3.GetOneMessage()));
		}, delegate(Exception exception)
		{
			Volatile.Write(ref m_sharedResources.m_hasExceptions, value: true);
			m_source.AddException(exception);
		}, dataflowBlockOptions);
		array[0] = (m_target1 = new JoinBlockTarget<T1>(m_sharedResources));
		array[1] = (m_target2 = new JoinBlockTarget<T2>(m_sharedResources));
		array[2] = (m_target3 = new JoinBlockTarget<T3>(m_sharedResources));
		Task.Factory.ContinueWhenAll(new Task[3] { m_target1.CompletionTaskInternal, m_target2.CompletionTaskInternal, m_target3.CompletionTaskInternal }, delegate
		{
			m_source.Complete();
		}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (JoinBlock<T1, T2, T3>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((JoinBlock<T1, T2, T3>)state).m_sharedResources.CompleteEachTarget();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2, T3>> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<Tuple<T1, T2, T3>> filter, out Tuple<T1, T2, T3> item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<Tuple<T1, T2, T3>> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	public void Complete()
	{
		m_target1.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		m_target2.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		m_target3.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		lock (m_sharedResources.IncomingLock)
		{
			if (!m_sharedResources.m_decliningPermanently)
			{
				m_sharedResources.m_exceptionAction(exception);
			}
		}
		Complete();
	}

	Tuple<T1, T2, T3> ISourceBlock<Tuple<T1, T2, T3>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<Tuple<T1, T2, T3>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<Tuple<T1, T2, T3>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
