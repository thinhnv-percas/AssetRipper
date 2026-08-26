using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerTypeProxy(typeof(TransformManyBlock<, >.DebugView))]
[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
public sealed class TransformManyBlock<TInput, TOutput> : IPropagatorBlock<TInput, TOutput>, ITargetBlock<TInput>, IReceivableSourceBlock<TOutput>, ISourceBlock<TOutput>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly TransformManyBlock<TInput, TOutput> m_transformManyBlock;

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

		public int Id => Common.GetBlockId(m_transformManyBlock);

		public TargetRegistry<TOutput> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<TOutput> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(TransformManyBlock<TInput, TOutput> transformManyBlock)
		{
			m_transformManyBlock = transformManyBlock;
			m_targetDebuggingInformation = transformManyBlock.m_target.GetDebuggingInformation();
			m_sourceDebuggingInformation = transformManyBlock.m_source.GetDebuggingInformation();
		}
	}

	private readonly TargetCore<TInput> m_target;

	private readonly ReorderingBuffer<IEnumerable<TOutput>> m_reorderingBuffer;

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

	public TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transform)
		: this(transform, (Func<TInput, Task<IEnumerable<TOutput>>>)null, ExecutionDataflowBlockOptions.Default)
	{
	}

	public TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this(transform, (Func<TInput, Task<IEnumerable<TOutput>>>)null, dataflowBlockOptions)
	{
	}

	public TransformManyBlock(Func<TInput, Task<IEnumerable<TOutput>>> transform)
		: this((Func<TInput, IEnumerable<TOutput>>)null, transform, ExecutionDataflowBlockOptions.Default)
	{
	}

	public TransformManyBlock(Func<TInput, Task<IEnumerable<TOutput>>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this((Func<TInput, IEnumerable<TOutput>>)null, transform, dataflowBlockOptions)
	{
	}

	private TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transformSync, Func<TInput, Task<IEnumerable<TOutput>>> transformAsync, ExecutionDataflowBlockOptions dataflowBlockOptions)
	{
		TransformManyBlock<TInput, TOutput> transformManyBlock = this;
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
				((TransformManyBlock<TInput, TOutput>)owningSource).m_target.ChangeBoundingCount(-count);
			};
		}
		m_source = new SourceCore<TOutput>(this, dataflowBlockOptions, delegate(ISourceBlock<TOutput> owningSource)
		{
			((TransformManyBlock<TInput, TOutput>)owningSource).m_target.Complete(null, dropPendingMessages: true);
		}, itemsRemovedAction);
		if (dataflowBlockOptions.SupportsParallelExecution)
		{
			m_reorderingBuffer = new ReorderingBuffer<IEnumerable<TOutput>>(this, delegate(object source, IEnumerable<TOutput> messages)
			{
				((TransformManyBlock<TInput, TOutput>)source).m_source.AddMessages(messages);
			});
		}
		if (transformSync != null)
		{
			m_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
			{
				transformManyBlock.ProcessMessage(transformSync, messageWithId);
			}, m_reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.None);
		}
		else
		{
			m_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
			{
				transformManyBlock.ProcessMessageWithTask(transformAsync, messageWithId);
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
			IDataflowBlock dataflowBlock = (TransformManyBlock<TInput, TOutput>)state;
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

	private void ProcessMessage(Func<TInput, IEnumerable<TOutput>> transformFunction, KeyValuePair<TInput, long> messageWithId)
	{
		bool flag = false;
		try
		{
			IEnumerable<TOutput> outputItems = transformFunction(messageWithId.Key);
			flag = true;
			StoreOutputItems(messageWithId, outputItems);
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
				StoreOutputItems(messageWithId, null);
			}
		}
	}

	private void ProcessMessageWithTask(Func<TInput, Task<IEnumerable<TOutput>>> function, KeyValuePair<TInput, long> messageWithId)
	{
		Task<IEnumerable<TOutput>> task = null;
		Exception ex = null;
		try
		{
			task = function(messageWithId.Key);
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
				StoreOutputItems(messageWithId, null);
				m_target.SignalOneAsyncMessageCompleted();
			}
			else
			{
				m_target.SignalOneAsyncMessageCompleted(-1);
			}
		}
		else
		{
			task.ContinueWith(delegate(Task<IEnumerable<TOutput>> completed, object state)
			{
				Tuple<TransformManyBlock<TInput, TOutput>, KeyValuePair<TInput, long>> tuple = (Tuple<TransformManyBlock<TInput, TOutput>, KeyValuePair<TInput, long>>)state;
				tuple.Item1.AsyncCompleteProcessMessageWithTask(completed, tuple.Item2);
			}, Tuple.Create(this, messageWithId), CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), m_source.DataflowBlockOptions.TaskScheduler);
		}
	}

	private void AsyncCompleteProcessMessageWithTask(Task<IEnumerable<TOutput>> completed, KeyValuePair<TInput, long> messageWithId)
	{
		switch (completed.Status)
		{
		case TaskStatus.RanToCompletion:
		{
			IEnumerable<TOutput> result = completed.Result;
			try
			{
				StoreOutputItems(messageWithId, result);
			}
			catch (Exception ex)
			{
				if (!Common.IsCooperativeCancellation(ex))
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
					m_target.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
				}
			}
			break;
		}
		case TaskStatus.Faulted:
		{
			AggregateException exception = completed.Exception;
			Common.StoreDataflowMessageValueIntoExceptionData(exception, messageWithId.Key, targetInnerExceptions: true);
			m_target.Complete(exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
			goto case TaskStatus.Canceled;
		}
		case TaskStatus.Canceled:
			StoreOutputItems(messageWithId, null);
			break;
		}
		m_target.SignalOneAsyncMessageCompleted();
	}

	private void StoreOutputItems(KeyValuePair<TInput, long> messageWithId, IEnumerable<TOutput> outputItems)
	{
		if (m_reorderingBuffer != null)
		{
			StoreOutputItemsReordered(messageWithId.Value, outputItems);
		}
		else if (outputItems != null)
		{
			if (outputItems is TOutput[] || outputItems is List<TOutput>)
			{
				StoreOutputItemsNonReorderedAtomic(outputItems);
			}
			else
			{
				StoreOutputItemsNonReorderedWithIteration(outputItems);
			}
		}
		else if (m_target.IsBounded)
		{
			m_target.ChangeBoundingCount(-1);
		}
	}

	private void StoreOutputItemsReordered(long id, IEnumerable<TOutput> item)
	{
		TargetCore<TInput> target = m_target;
		bool isBounded = target.IsBounded;
		if (item == null)
		{
			m_reorderingBuffer.AddItem(id, null, itemIsValid: false);
			if (isBounded)
			{
				target.ChangeBoundingCount(-1);
			}
			return;
		}
		IList<TOutput> list = item as TOutput[];
		if (list == null)
		{
			list = item as List<TOutput>;
		}
		if (list != null && isBounded)
		{
			UpdateBoundingCountWithOutputCount(list.Count);
		}
		bool? flag = m_reorderingBuffer.AddItemIfNextAndTrusted(id, list, list != null);
		if (!flag.HasValue)
		{
			return;
		}
		bool value = flag.Value;
		List<TOutput> list2 = null;
		try
		{
			if (value)
			{
				StoreOutputItemsNonReorderedWithIteration(item);
				return;
			}
			if (list != null)
			{
				list2 = list.ToList();
				return;
			}
			int count = 0;
			try
			{
				list2 = item.ToList();
				count = list2.Count;
			}
			finally
			{
				if (isBounded)
				{
					UpdateBoundingCountWithOutputCount(count);
				}
			}
		}
		finally
		{
			m_reorderingBuffer.AddItem(id, list2, list2 != null);
		}
	}

	private void StoreOutputItemsNonReorderedAtomic(IEnumerable<TOutput> outputItems)
	{
		if (m_target.IsBounded)
		{
			UpdateBoundingCountWithOutputCount(((ICollection<TOutput>)outputItems).Count);
		}
		m_source.AddMessages(outputItems);
	}

	private void StoreOutputItemsNonReorderedWithIteration(IEnumerable<TOutput> outputItems)
	{
		if (m_target.IsBounded)
		{
			bool flag = false;
			try
			{
				foreach (TOutput outputItem in outputItems)
				{
					if (flag)
					{
						m_target.ChangeBoundingCount(1);
					}
					else
					{
						flag = true;
					}
					m_source.AddMessage(outputItem);
				}
				return;
			}
			finally
			{
				if (!flag)
				{
					m_target.ChangeBoundingCount(-1);
				}
			}
		}
		foreach (TOutput outputItem2 in outputItems)
		{
			m_source.AddMessage(outputItem2);
		}
	}

	private void UpdateBoundingCountWithOutputCount(int count)
	{
		if (count > 1)
		{
			m_target.ChangeBoundingCount(count - 1);
		}
		else if (count == 0)
		{
			m_target.ChangeBoundingCount(-1);
		}
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
