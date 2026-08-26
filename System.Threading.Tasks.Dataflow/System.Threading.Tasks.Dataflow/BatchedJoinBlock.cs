using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BatchedJoinBlock<, >.DebugView))]
public sealed class BatchedJoinBlock<T1, T2> : IReceivableSourceBlock<Tuple<IList<T1>, IList<T2>>>, ISourceBlock<Tuple<IList<T1>, IList<T2>>>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly BatchedJoinBlock<T1, T2> m_batchedJoinBlock;

		private readonly SourceCore<Tuple<IList<T1>, IList<T2>>>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<Tuple<IList<T1>, IList<T2>>> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public long BatchesCreated => m_batchedJoinBlock.m_sharedResources.m_batchesCreated;

		public int RemainingItemsForBatch => m_batchedJoinBlock.m_sharedResources.m_remainingItemsInBatch;

		public int BatchSize => m_batchedJoinBlock.m_batchSize;

		public ITargetBlock<T1> Target1 => m_batchedJoinBlock.m_target1;

		public ITargetBlock<T2> Target2 => m_batchedJoinBlock.m_target2;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_batchedJoinBlock);

		public TargetRegistry<Tuple<IList<T1>, IList<T2>>> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<Tuple<IList<T1>, IList<T2>>> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(BatchedJoinBlock<T1, T2> batchedJoinBlock)
		{
			m_batchedJoinBlock = batchedJoinBlock;
			m_sourceDebuggingInformation = batchedJoinBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly int m_batchSize;

	private readonly BatchedJoinBlockTargetSharedResources m_sharedResources;

	private readonly BatchedJoinBlockTarget<T1> m_target1;

	private readonly BatchedJoinBlockTarget<T2> m_target2;

	private readonly SourceCore<Tuple<IList<T1>, IList<T2>>> m_source;

	public int BatchSize => m_batchSize;

	public ITargetBlock<T1> Target1 => m_target1;

	public ITargetBlock<T2> Target2 => m_target2;

	public int OutputCount => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, BatchSize={1}, OutputCount={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		BatchSize,
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public BatchedJoinBlock(int batchSize)
		: this(batchSize, GroupingDataflowBlockOptions.Default)
	{
	}

	public BatchedJoinBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		if (batchSize < 1)
		{
			throw new ArgumentOutOfRangeException("batchSize", Resource.ArgumentOutOfRange_GenericPositive);
		}
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		if (!dataflowBlockOptions.Greedy)
		{
			throw new ArgumentException(Resource.Argument_NonGreedyNotSupported, "dataflowBlockOptions");
		}
		if (dataflowBlockOptions.BoundedCapacity != -1)
		{
			throw new ArgumentException(Resource.Argument_BoundedCapacityNotSupported, "dataflowBlockOptions");
		}
		m_batchSize = batchSize;
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		m_source = new SourceCore<Tuple<IList<T1>, IList<T2>>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<IList<T1>, IList<T2>>> owningSource)
		{
			((BatchedJoinBlock<T1, T2>)owningSource).CompleteEachTarget();
		});
		Action createBatchAction = delegate
		{
			if (m_target1.Count > 0 || m_target2.Count > 0)
			{
				m_source.AddMessage(Tuple.Create(m_target1.GetAndEmptyMessages(), m_target2.GetAndEmptyMessages()));
			}
		};
		m_sharedResources = new BatchedJoinBlockTargetSharedResources(batchSize, dataflowBlockOptions, createBatchAction, delegate
		{
			createBatchAction();
			m_source.Complete();
		}, m_source.AddException, Complete);
		m_target1 = new BatchedJoinBlockTarget<T1>(m_sharedResources);
		m_target2 = new BatchedJoinBlockTarget<T2>(m_sharedResources);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (BatchedJoinBlock<T1, T2>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((BatchedJoinBlock<T1, T2>)state).CompleteEachTarget();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public IDisposable LinkTo(ITargetBlock<Tuple<IList<T1>, IList<T2>>> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<Tuple<IList<T1>, IList<T2>>> filter, out Tuple<IList<T1>, IList<T2>> item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<Tuple<IList<T1>, IList<T2>>> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	public void Complete()
	{
		m_target1.Complete();
		m_target2.Complete();
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		lock (m_sharedResources.m_incomingLock)
		{
			if (!m_sharedResources.m_decliningPermanently)
			{
				m_source.AddException(exception);
			}
		}
		Complete();
	}

	Tuple<IList<T1>, IList<T2>> ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	private void CompleteEachTarget()
	{
		m_target1.Complete();
		m_target2.Complete();
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BatchedJoinBlock<, , >.DebugView))]
public sealed class BatchedJoinBlock<T1, T2, T3> : IReceivableSourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>, ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly BatchedJoinBlock<T1, T2, T3> m_batchedJoinBlock;

		private readonly SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<Tuple<IList<T1>, IList<T2>, IList<T3>>> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public long BatchesCreated => m_batchedJoinBlock.m_sharedResources.m_batchesCreated;

		public int RemainingItemsForBatch => m_batchedJoinBlock.m_sharedResources.m_remainingItemsInBatch;

		public int BatchSize => m_batchedJoinBlock.m_batchSize;

		public ITargetBlock<T1> Target1 => m_batchedJoinBlock.m_target1;

		public ITargetBlock<T2> Target2 => m_batchedJoinBlock.m_target2;

		public ITargetBlock<T3> Target3 => m_batchedJoinBlock.m_target3;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)m_sourceDebuggingInformation.DataflowBlockOptions;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_batchedJoinBlock);

		public TargetRegistry<Tuple<IList<T1>, IList<T2>, IList<T3>>> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(BatchedJoinBlock<T1, T2, T3> batchedJoinBlock)
		{
			m_sourceDebuggingInformation = batchedJoinBlock.m_source.GetDebuggingInformation();
			m_batchedJoinBlock = batchedJoinBlock;
		}
	}

	private readonly int m_batchSize;

	private readonly BatchedJoinBlockTargetSharedResources m_sharedResources;

	private readonly BatchedJoinBlockTarget<T1> m_target1;

	private readonly BatchedJoinBlockTarget<T2> m_target2;

	private readonly BatchedJoinBlockTarget<T3> m_target3;

	private readonly SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>> m_source;

	public int BatchSize => m_batchSize;

	public ITargetBlock<T1> Target1 => m_target1;

	public ITargetBlock<T2> Target2 => m_target2;

	public ITargetBlock<T3> Target3 => m_target3;

	public int OutputCount => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, BatchSize={1}, OutputCount={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		BatchSize,
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public BatchedJoinBlock(int batchSize)
		: this(batchSize, GroupingDataflowBlockOptions.Default)
	{
	}

	public BatchedJoinBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		if (batchSize < 1)
		{
			throw new ArgumentOutOfRangeException("batchSize", Resource.ArgumentOutOfRange_GenericPositive);
		}
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		if (!dataflowBlockOptions.Greedy || dataflowBlockOptions.BoundedCapacity != -1)
		{
			throw new ArgumentException(Resource.Argument_NonGreedyNotSupported, "dataflowBlockOptions");
		}
		m_batchSize = batchSize;
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		m_source = new SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> owningSource)
		{
			((BatchedJoinBlock<T1, T2, T3>)owningSource).CompleteEachTarget();
		});
		Action createBatchAction = delegate
		{
			if (m_target1.Count > 0 || m_target2.Count > 0 || m_target3.Count > 0)
			{
				m_source.AddMessage(Tuple.Create(m_target1.GetAndEmptyMessages(), m_target2.GetAndEmptyMessages(), m_target3.GetAndEmptyMessages()));
			}
		};
		m_sharedResources = new BatchedJoinBlockTargetSharedResources(batchSize, dataflowBlockOptions, createBatchAction, delegate
		{
			createBatchAction();
			m_source.Complete();
		}, m_source.AddException, Complete);
		m_target1 = new BatchedJoinBlockTarget<T1>(m_sharedResources);
		m_target2 = new BatchedJoinBlockTarget<T2>(m_sharedResources);
		m_target3 = new BatchedJoinBlockTarget<T3>(m_sharedResources);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (BatchedJoinBlock<T1, T2, T3>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((BatchedJoinBlock<T1, T2, T3>)state).CompleteEachTarget();
		}, this);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public IDisposable LinkTo(ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<Tuple<IList<T1>, IList<T2>, IList<T3>>> filter, out Tuple<IList<T1>, IList<T2>, IList<T3>> item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<Tuple<IList<T1>, IList<T2>, IList<T3>>> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	public void Complete()
	{
		m_target1.Complete();
		m_target2.Complete();
		m_target3.Complete();
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		lock (m_sharedResources.m_incomingLock)
		{
			if (!m_sharedResources.m_decliningPermanently)
			{
				m_source.AddException(exception);
			}
		}
		Complete();
	}

	Tuple<IList<T1>, IList<T2>, IList<T3>> ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	private void CompleteEachTarget()
	{
		m_target1.Complete();
		m_target2.Complete();
		m_target3.Complete();
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
