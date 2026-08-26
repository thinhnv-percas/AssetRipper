using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerTypeProxy(typeof(TransformBlock<, >.DebugView))]
[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
public sealed class TransformBlock<TInput, TOutput> : IPropagatorBlock<TInput, TOutput>, ITargetBlock<TInput>, IReceivableSourceBlock<TOutput>, ISourceBlock<TOutput>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly TransformBlock<TInput, TOutput> m_transformBlock;

		private readonly TargetCore<TInput>.DebuggingInformation m_targetDebuggingInformation;

		private readonly SourceCore<TOutput>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<TInput> InputQueue => m_targetDebuggingInformation.InputQueue;

		public QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages => m_targetDebuggingInformation.PostponedMessages;

		public IEnumerable<TOutput> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public int CurrentDegreeOfParallelism => m_targetDebuggingInformation.CurrentDegreeOfParallelism;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public ExecutionDataflowBlockOptions DataflowBlockOptions => m_targetDebuggingInformation.DataflowBlockOptions;

		public bool IsDecliningPermanently => m_targetDebuggingInformation.IsDecliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_transformBlock);

		public TargetRegistry<TOutput> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<TOutput> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(TransformBlock<TInput, TOutput> transformBlock)
		{
			m_transformBlock = transformBlock;
			m_targetDebuggingInformation = transformBlock.m_target.GetDebuggingInformation();
			m_sourceDebuggingInformation = transformBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly TargetCore<TInput> m_target;

	private readonly ReorderingBuffer<TOutput> m_reorderingBuffer;

	private readonly SourceCore<TOutput> m_source;

	public Task Completion => m_source.Completion;

	public int InputCount => m_target.InputCount;

	public int OutputCount => m_source.OutputCount;

	private int InputCountForDebugger => m_target.GetDebuggingInformation().InputCount;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, InputCount={1}, OutputCount={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		InputCountForDebugger,
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public TransformBlock(Func<TInput, TOutput> transform)
		: this(transform, (Func<TInput, Task<TOutput>>)null, ExecutionDataflowBlockOptions.Default)
	{
	}

	public TransformBlock(Func<TInput, TOutput> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this(transform, (Func<TInput, Task<TOutput>>)null, dataflowBlockOptions)
	{
	}

	public TransformBlock(Func<TInput, Task<TOutput>> transform)
		: this((Func<TInput, TOutput>)null, transform, ExecutionDataflowBlockOptions.Default)
	{
	}

	public TransformBlock(Func<TInput, Task<TOutput>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this((Func<TInput, TOutput>)null, transform, dataflowBlockOptions)
	{
	}

	private TransformBlock(Func<TInput, TOutput> transformSync, Func<TInput, Task<TOutput>> transformAsync, ExecutionDataflowBlockOptions dataflowBlockOptions)
	{
		TransformBlock<TInput, TOutput> transformBlock = this;
		if (transformSync == null && transformAsync == null)
		{
			throw new ArgumentNullException("transform");
		}
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<ISourceBlock<TOutput>, int> itemsRemovedAction = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = delegate(ISourceBlock<TOutput> owningSource, int count)
			{
				((TransformBlock<TInput, TOutput>)owningSource).m_target.ChangeBoundingCount(-count);
			};
		}
		m_source = new SourceCore<TOutput>(this, dataflowBlockOptions, delegate(ISourceBlock<TOutput> owningSource)
		{
			((TransformBlock<TInput, TOutput>)owningSource).m_target.Complete(null, dropPendingMessages: true);
		}, itemsRemovedAction);
		if (dataflowBlockOptions.SupportsParallelExecution)
		{
			m_reorderingBuffer = new ReorderingBuffer<TOutput>(this, delegate(object owningSource, TOutput message)
			{
				((TransformBlock<TInput, TOutput>)owningSource).m_source.AddMessage(message);
			});
		}
		if (transformSync != null)
		{
			m_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
			{
				transformBlock.ProcessMessage(transformSync, messageWithId);
			}, m_reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.None);
		}
		else
		{
			m_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
			{
				transformBlock.ProcessMessageWithTask(transformAsync, messageWithId);
			}, m_reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.UsesAsyncCompletion);
		}
		m_target.Completion.ContinueWith(delegate(Task completed, object state)
		{
			SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
			if (completed.IsFaulted)
			{
				sourceCore.AddAndUnwrapAggregateException(completed.Exception);
			}
			sourceCore.Complete();
		}, m_source, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (TransformBlock<TInput, TOutput>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, Completion, delegate(object state)
		{
			((TargetCore<TInput>)state).Complete(null, dropPendingMessages: true);
		}, m_target);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	private void ProcessMessage(Func<TInput, TOutput> transform, KeyValuePair<TInput, long> messageWithId)
	{
		TOutput item = default(TOutput);
		bool flag = false;
		try
		{
			item = transform(messageWithId.Key);
			flag = true;
		}
		catch (Exception exception)
		{
			if (!Common.IsCooperativeCancellation(exception))
			{
				throw;
			}
		}
		finally
		{
			if (!flag)
			{
				m_target.ChangeBoundingCount(-1);
			}
			if (m_reorderingBuffer == null)
			{
				if (flag)
				{
					m_source.AddMessage(item);
				}
			}
			else
			{
				m_reorderingBuffer.AddItem(messageWithId.Value, item, flag);
			}
		}
	}

	private void ProcessMessageWithTask(Func<TInput, Task<TOutput>> transform, KeyValuePair<TInput, long> messageWithId)
	{
		Task<TOutput> task = null;
		Exception ex = null;
		try
		{
			task = transform(messageWithId.Key);
		}
		catch (Exception ex2)
		{
			ex = ex2;
		}
		if (task == null)
		{
			if (ex != null && !Common.IsCooperativeCancellation(ex))
			{
				Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
				m_target.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
			}
			if (m_reorderingBuffer != null)
			{
				m_reorderingBuffer.IgnoreItem(messageWithId.Value);
			}
			m_target.SignalOneAsyncMessageCompleted(-1);
		}
		else
		{
			task.ContinueWith(delegate(Task<TOutput> completed, object state)
			{
				Tuple<TransformBlock<TInput, TOutput>, KeyValuePair<TInput, long>> tuple = (Tuple<TransformBlock<TInput, TOutput>, KeyValuePair<TInput, long>>)state;
				tuple.Item1.AsyncCompleteProcessMessageWithTask(completed, tuple.Item2);
			}, Tuple.Create(this, messageWithId), CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
		}
	}

	private void AsyncCompleteProcessMessageWithTask(Task<TOutput> completed, KeyValuePair<TInput, long> messageWithId)
	{
		bool isBounded = m_target.IsBounded;
		bool flag = false;
		TOutput item = default(TOutput);
		switch (completed.Status)
		{
		case TaskStatus.RanToCompletion:
			item = completed.Result;
			flag = true;
			break;
		case TaskStatus.Faulted:
		{
			AggregateException exception = completed.Exception;
			Common.StoreDataflowMessageValueIntoExceptionData(exception, messageWithId.Key, targetInnerExceptions: true);
			m_target.Complete(exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
			break;
		}
		}
		if (!flag && isBounded)
		{
			m_target.ChangeBoundingCount(-1);
		}
		if (m_reorderingBuffer == null)
		{
			if (flag)
			{
				m_source.AddMessage(item);
			}
		}
		else
		{
			m_reorderingBuffer.AddItem(messageWithId.Value, item, flag);
		}
		m_target.SignalOneAsyncMessageCompleted();
	}

	public void Complete()
	{
		m_target.Complete(null, dropPendingMessages: false);
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		m_target.Complete(exception, dropPendingMessages: true);
	}

	public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<TOutput> filter, out TOutput item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<TOutput> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
	{
		return m_target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
	}

	TOutput ISourceBlock<TOutput>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<TOutput>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<TOutput>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
