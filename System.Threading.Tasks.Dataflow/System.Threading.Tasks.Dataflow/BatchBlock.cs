using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(BatchBlock<>.DebugView))]
public sealed class BatchBlock<T> : IPropagatorBlock<T, T[]>, ITargetBlock<T>, IReceivableSourceBlock<T[]>, ISourceBlock<T[]>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private BatchBlock<T> m_batchBlock;

		private readonly BatchBlockTargetCore.DebuggingInformation m_targetDebuggingInformation;

		private readonly SourceCore<T[]>.DebuggingInformation m_sourceDebuggingInformation;

		public IEnumerable<T> InputQueue => m_targetDebuggingInformation.InputQueue;

		public IEnumerable<T[]> OutputQueue => m_sourceDebuggingInformation.OutputQueue;

		public long BatchesCompleted => m_targetDebuggingInformation.NumberOfBatchesCompleted;

		public Task TaskForInputProcessing => m_targetDebuggingInformation.TaskForInputProcessing;

		public Task TaskForOutputProcessing => m_sourceDebuggingInformation.TaskForOutputProcessing;

		public GroupingDataflowBlockOptions DataflowBlockOptions => m_targetDebuggingInformation.DataflowBlockOptions;

		public int BatchSize => m_batchBlock.BatchSize;

		public bool IsDecliningPermanently => m_targetDebuggingInformation.IsDecliningPermanently;

		public bool IsCompleted => m_sourceDebuggingInformation.IsCompleted;

		public int Id => Common.GetBlockId(m_batchBlock);

		public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages => m_targetDebuggingInformation.PostponedMessages;

		public TargetRegistry<T[]> LinkedTargets => m_sourceDebuggingInformation.LinkedTargets;

		public ITargetBlock<T[]> NextMessageReservedFor => m_sourceDebuggingInformation.NextMessageReservedFor;

		public DebugView(BatchBlock<T> batchBlock)
		{
			m_batchBlock = batchBlock;
			m_targetDebuggingInformation = batchBlock.m_target.GetDebuggingInformation();
			m_sourceDebuggingInformation = batchBlock.m_source.GetDebuggingInformation();
		}
	}

	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	private sealed class BatchBlockTargetCore
	{
		private sealed class NonGreedyState
		{
			internal readonly QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages;

			internal readonly KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] PostponedMessagesTemp;

			internal readonly List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> ReservedSourcesTemp;

			internal bool AcceptFewerThanBatchSize;

			internal Task TaskForInputProcessing;

			internal NonGreedyState(int batchSize)
			{
				PostponedMessages = new QueuedMap<ISourceBlock<T>, DataflowMessageHeader>(batchSize);
				PostponedMessagesTemp = new KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[batchSize];
				ReservedSourcesTemp = new List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>>(batchSize);
			}
		}

		internal sealed class DebuggingInformation
		{
			private BatchBlockTargetCore m_target;

			public IEnumerable<T> InputQueue => m_target.m_messages.ToList();

			public Task TaskForInputProcessing
			{
				get
				{
					if (m_target.m_nonGreedyState == null)
					{
						return null;
					}
					return m_target.m_nonGreedyState.TaskForInputProcessing;
				}
			}

			public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages
			{
				get
				{
					if (m_target.m_nonGreedyState == null)
					{
						return null;
					}
					return m_target.m_nonGreedyState.PostponedMessages;
				}
			}

			public bool IsDecliningPermanently => m_target.m_decliningPermanently;

			public GroupingDataflowBlockOptions DataflowBlockOptions => m_target.m_dataflowBlockOptions;

			public long NumberOfBatchesCompleted => m_target.m_batchesCompleted;

			public DebuggingInformation(BatchBlockTargetCore target)
			{
				m_target = target;
			}
		}

		private readonly Queue<T> m_messages = new Queue<T>();

		private readonly TaskCompletionSource<VoidResult> m_completionTask = new TaskCompletionSource<VoidResult>();

		private readonly BatchBlock<T> m_owningBatch;

		private readonly int m_batchSize;

		private readonly NonGreedyState m_nonGreedyState;

		private readonly BoundingState m_boundingState;

		private readonly GroupingDataflowBlockOptions m_dataflowBlockOptions;

		private readonly Action<T[]> m_batchCompletedAction;

		private bool m_decliningPermanently;

		private long m_batchesCompleted;

		private bool m_completionReserved;

		private object IncomingLock => m_completionTask;

		internal Task Completion => m_completionTask.Task;

		internal int BatchSize => m_batchSize;

		private bool CanceledOrFaulted
		{
			get
			{
				if (!m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					return m_owningBatch.m_source.HasExceptions;
				}
				return true;
			}
		}

		private int BoundedCapacityAvailable
		{
			get
			{
				if (m_boundingState == null)
				{
					return m_batchSize;
				}
				return m_dataflowBlockOptions.BoundedCapacity - m_boundingState.CurrentCount;
			}
		}

		private bool BatchesNeedProcessing
		{
			get
			{
				bool flag = m_batchesCompleted >= m_dataflowBlockOptions.ActualMaxNumberOfGroups;
				bool flag2 = m_nonGreedyState != null && m_nonGreedyState.TaskForInputProcessing != null;
				if (flag || flag2 || CanceledOrFaulted)
				{
					return false;
				}
				int num = m_batchSize - m_messages.Count;
				int boundedCapacityAvailable = BoundedCapacityAvailable;
				if (num <= 0)
				{
					return true;
				}
				if (m_nonGreedyState != null)
				{
					if (m_nonGreedyState.AcceptFewerThanBatchSize && (m_messages.Count > 0 || (m_nonGreedyState.PostponedMessages.Count > 0 && boundedCapacityAvailable > 0)))
					{
						return true;
					}
					if (m_dataflowBlockOptions.Greedy)
					{
						if (m_nonGreedyState.PostponedMessages.Count > 0 && boundedCapacityAvailable > 0)
						{
							return true;
						}
					}
					else if (m_nonGreedyState.PostponedMessages.Count >= num && boundedCapacityAvailable >= num)
					{
						return true;
					}
				}
				return false;
			}
		}

		private int InputCountForDebugger => m_messages.Count;

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay owningBatch = m_owningBatch;
				return $"Block=\"{((owningBatch != null) ? owningBatch.Content : m_owningBatch)}\"";
			}
		}

		internal BatchBlockTargetCore(BatchBlock<T> owningBatch, int batchSize, Action<T[]> batchCompletedAction, GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			m_owningBatch = owningBatch;
			m_batchSize = batchSize;
			m_batchCompletedAction = batchCompletedAction;
			m_dataflowBlockOptions = dataflowBlockOptions;
			bool flag = dataflowBlockOptions.BoundedCapacity > 0;
			if (!m_dataflowBlockOptions.Greedy || flag)
			{
				m_nonGreedyState = new NonGreedyState(batchSize);
			}
			if (flag)
			{
				m_boundingState = new BoundingState(dataflowBlockOptions.BoundedCapacity);
			}
		}

		internal void TriggerBatch()
		{
			lock (IncomingLock)
			{
				if (!m_decliningPermanently && !m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					if (m_nonGreedyState == null)
					{
						MakeBatchIfPossible(evenIfFewerThanBatchSize: true);
					}
					else
					{
						m_nonGreedyState.AcceptFewerThanBatchSize = true;
						ProcessAsyncIfNecessary();
					}
				}
				CompleteBlockIfPossible();
			}
		}

		internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
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
					if (m_dataflowBlockOptions.Greedy && (m_boundingState == null || (m_boundingState.CountIsLessThanBound && m_nonGreedyState.PostponedMessages.Count == 0 && m_nonGreedyState.TaskForInputProcessing == null)))
					{
						if (consumeToAccept)
						{
							messageValue = source.ConsumeMessage(messageHeader, m_owningBatch, out var messageConsumed);
							if (!messageConsumed)
							{
								return DataflowMessageStatus.NotAvailable;
							}
						}
						m_messages.Enqueue(messageValue);
						if (m_boundingState != null)
						{
							m_boundingState.CurrentCount++;
						}
						if (!m_decliningPermanently && m_batchesCompleted + m_messages.Count / m_batchSize >= m_dataflowBlockOptions.ActualMaxNumberOfGroups)
						{
							m_decliningPermanently = true;
						}
						MakeBatchIfPossible(evenIfFewerThanBatchSize: false);
						CompleteBlockIfPossible();
						return DataflowMessageStatus.Accepted;
					}
					if (source != null)
					{
						m_nonGreedyState.PostponedMessages.Push(source, messageHeader);
						if (!m_dataflowBlockOptions.Greedy)
						{
							ProcessAsyncIfNecessary();
						}
						return DataflowMessageStatus.Postponed;
					}
					return DataflowMessageStatus.Declined;
				}
			}
			throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
		}

		internal void Complete(Exception exception, bool dropPendingMessages, bool releaseReservedMessages, bool revertProcessingState = false)
		{
			lock (IncomingLock)
			{
				if (exception != null && (!m_decliningPermanently || releaseReservedMessages))
				{
					m_owningBatch.m_source.AddException(exception);
				}
				if (dropPendingMessages)
				{
					m_messages.Clear();
				}
			}
			if (releaseReservedMessages)
			{
				try
				{
					ReleaseReservedMessages(throwOnFirstException: false);
				}
				catch (Exception exception2)
				{
					m_owningBatch.m_source.AddException(exception2);
				}
			}
			lock (IncomingLock)
			{
				if (revertProcessingState)
				{
					m_nonGreedyState.TaskForInputProcessing = null;
				}
				m_decliningPermanently = true;
				CompleteBlockIfPossible();
			}
		}

		private void CompleteBlockIfPossible()
		{
			if (m_completionReserved)
			{
				return;
			}
			bool flag = m_nonGreedyState != null && m_nonGreedyState.TaskForInputProcessing != null;
			bool flag2 = m_batchesCompleted >= m_dataflowBlockOptions.ActualMaxNumberOfGroups;
			bool flag3 = m_decliningPermanently && m_messages.Count < m_batchSize;
			if (flag || (!flag2 && !flag3 && !CanceledOrFaulted))
			{
				return;
			}
			m_completionReserved = true;
			m_decliningPermanently = true;
			if (m_messages.Count > 0)
			{
				MakeBatchIfPossible(evenIfFewerThanBatchSize: true);
			}
			Task.Factory.StartNew(delegate(object thisTargetCore)
			{
				BatchBlockTargetCore batchBlockTargetCore = (BatchBlockTargetCore)thisTargetCore;
				List<Exception> exceptions = null;
				if (batchBlockTargetCore.m_nonGreedyState != null)
				{
					Common.ReleaseAllPostponedMessages(batchBlockTargetCore.m_owningBatch, batchBlockTargetCore.m_nonGreedyState.PostponedMessages, ref exceptions);
				}
				if (exceptions != null)
				{
					batchBlockTargetCore.m_owningBatch.m_source.AddExceptions(exceptions);
				}
				batchBlockTargetCore.m_completionTask.TrySetResult(default(VoidResult));
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}

		private void ProcessAsyncIfNecessary(bool isReplacementReplica = false)
		{
			if (BatchesNeedProcessing)
			{
				ProcessAsyncIfNecessary_Slow(isReplacementReplica);
			}
		}

		private void ProcessAsyncIfNecessary_Slow(bool isReplacementReplica)
		{
			m_nonGreedyState.TaskForInputProcessing = new Task(delegate(object thisBatchTarget)
			{
				((BatchBlockTargetCore)thisBatchTarget).ProcessMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(m_owningBatch, m_nonGreedyState.TaskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, m_messages.Count + ((m_nonGreedyState != null) ? m_nonGreedyState.PostponedMessages.Count : 0));
			}
			Exception ex = Common.StartTaskSafe(m_nonGreedyState.TaskForInputProcessing, m_dataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				Task.Factory.StartNew(delegate(object exc)
				{
					Complete((Exception)exc, dropPendingMessages: true, releaseReservedMessages: true, revertProcessingState: true);
				}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void ProcessMessagesLoopCore()
		{
			try
			{
				int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
				int num = 0;
				bool flag2;
				do
				{
					bool flag = Volatile.Read(ref m_nonGreedyState.AcceptFewerThanBatchSize);
					if (!m_dataflowBlockOptions.Greedy)
					{
						RetrievePostponedItemsNonGreedy(flag);
					}
					else
					{
						RetrievePostponedItemsGreedyBounded(flag);
					}
					lock (IncomingLock)
					{
						flag2 = MakeBatchIfPossible(flag);
						if (flag2 || flag)
						{
							m_nonGreedyState.AcceptFewerThanBatchSize = false;
						}
					}
					num++;
				}
				while (flag2 && num < actualMaxMessagesPerTask);
			}
			catch (Exception exception)
			{
				Complete(exception, dropPendingMessages: false, releaseReservedMessages: true);
			}
			finally
			{
				lock (IncomingLock)
				{
					m_nonGreedyState.TaskForInputProcessing = null;
					ProcessAsyncIfNecessary(isReplacementReplica: true);
					CompleteBlockIfPossible();
				}
			}
		}

		private bool MakeBatchIfPossible(bool evenIfFewerThanBatchSize)
		{
			bool flag = m_messages.Count >= m_batchSize;
			if (flag || (evenIfFewerThanBatchSize && m_messages.Count > 0))
			{
				T[] array = new T[flag ? m_batchSize : m_messages.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = m_messages.Dequeue();
				}
				m_batchCompletedAction(array);
				m_batchesCompleted++;
				if (m_batchesCompleted >= m_dataflowBlockOptions.ActualMaxNumberOfGroups)
				{
					m_decliningPermanently = true;
				}
				return true;
			}
			return false;
		}

		private void RetrievePostponedItemsNonGreedy(bool allowFewerThanBatchSize)
		{
			QueuedMap<ISourceBlock<T>, DataflowMessageHeader> postponedMessages = m_nonGreedyState.PostponedMessages;
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] postponedMessagesTemp = m_nonGreedyState.PostponedMessagesTemp;
			List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = m_nonGreedyState.ReservedSourcesTemp;
			reservedSourcesTemp.Clear();
			int num;
			lock (IncomingLock)
			{
				int boundedCapacityAvailable = BoundedCapacityAvailable;
				if (m_decliningPermanently || postponedMessages.Count == 0 || boundedCapacityAvailable <= 0 || (!allowFewerThanBatchSize && (postponedMessages.Count < m_batchSize || boundedCapacityAvailable < m_batchSize)))
				{
					return;
				}
				num = postponedMessages.PopRange(postponedMessagesTemp, 0, m_batchSize);
			}
			for (int i = 0; i < num; i++)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> keyValuePair = postponedMessagesTemp[i];
				if (keyValuePair.Key.ReserveMessage(keyValuePair.Value, m_owningBatch))
				{
					KeyValuePair<DataflowMessageHeader, T> value = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value, default(T));
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value);
					reservedSourcesTemp.Add(item);
				}
			}
			Array.Clear(postponedMessagesTemp, 0, postponedMessagesTemp.Length);
			while (reservedSourcesTemp.Count < m_batchSize)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item2;
				lock (IncomingLock)
				{
					if (!postponedMessages.TryPop(out item2))
					{
						break;
					}
				}
				if (item2.Key.ReserveMessage(item2.Value, m_owningBatch))
				{
					KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(item2.Value, default(T));
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(item2.Key, value2);
					reservedSourcesTemp.Add(item3);
				}
			}
			if (reservedSourcesTemp.Count > 0)
			{
				bool flag = true;
				if (allowFewerThanBatchSize)
				{
					lock (IncomingLock)
					{
						if (!m_decliningPermanently && m_batchesCompleted + 1 >= m_dataflowBlockOptions.ActualMaxNumberOfGroups)
						{
							flag = !m_decliningPermanently;
							m_decliningPermanently = true;
						}
					}
				}
				if (flag && (allowFewerThanBatchSize || reservedSourcesTemp.Count == m_batchSize))
				{
					ConsumeReservedMessagesNonGreedy();
				}
				else
				{
					ReleaseReservedMessages(throwOnFirstException: true);
				}
			}
			reservedSourcesTemp.Clear();
		}

		private void RetrievePostponedItemsGreedyBounded(bool allowFewerThanBatchSize)
		{
			QueuedMap<ISourceBlock<T>, DataflowMessageHeader> postponedMessages = m_nonGreedyState.PostponedMessages;
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] postponedMessagesTemp = m_nonGreedyState.PostponedMessagesTemp;
			List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = m_nonGreedyState.ReservedSourcesTemp;
			reservedSourcesTemp.Clear();
			int num;
			int num2;
			lock (IncomingLock)
			{
				int boundedCapacityAvailable = BoundedCapacityAvailable;
				num = m_batchSize - m_messages.Count;
				if (m_decliningPermanently || postponedMessages.Count == 0 || boundedCapacityAvailable <= 0)
				{
					return;
				}
				if (boundedCapacityAvailable < num)
				{
					num = boundedCapacityAvailable;
				}
				num2 = postponedMessages.PopRange(postponedMessagesTemp, 0, num);
			}
			for (int i = 0; i < num2; i++)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> keyValuePair = postponedMessagesTemp[i];
				KeyValuePair<DataflowMessageHeader, T> value = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value, default(T));
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value);
				reservedSourcesTemp.Add(item);
			}
			Array.Clear(postponedMessagesTemp, 0, postponedMessagesTemp.Length);
			while (reservedSourcesTemp.Count < num)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item2;
				lock (IncomingLock)
				{
					if (!postponedMessages.TryPop(out item2))
					{
						break;
					}
				}
				KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(item2.Value, default(T));
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(item2.Key, value2);
				reservedSourcesTemp.Add(item3);
			}
			if (reservedSourcesTemp.Count > 0)
			{
				bool flag = true;
				if (allowFewerThanBatchSize)
				{
					lock (IncomingLock)
					{
						if (!m_decliningPermanently && m_batchesCompleted + 1 >= m_dataflowBlockOptions.ActualMaxNumberOfGroups)
						{
							flag = !m_decliningPermanently;
							m_decliningPermanently = true;
						}
					}
				}
				if (flag)
				{
					ConsumeReservedMessagesGreedyBounded();
				}
			}
			reservedSourcesTemp.Clear();
		}

		private void ConsumeReservedMessagesNonGreedy()
		{
			List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = m_nonGreedyState.ReservedSourcesTemp;
			for (int i = 0; i < reservedSourcesTemp.Count; i++)
			{
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
				reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
				T value = keyValuePair.Key.ConsumeMessage(keyValuePair.Value.Key, m_owningBatch, out var messageConsumed);
				if (!messageConsumed)
				{
					for (int j = 0; j < i; j++)
					{
						reservedSourcesTemp[j] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
					}
					throw new InvalidOperationException(Resource.InvalidOperation_FailedToConsumeReservedMessage);
				}
				KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value.Key, value);
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> value3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value2);
				reservedSourcesTemp[i] = value3;
			}
			lock (IncomingLock)
			{
				if (m_boundingState != null)
				{
					m_boundingState.CurrentCount += reservedSourcesTemp.Count;
				}
				foreach (KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item in reservedSourcesTemp)
				{
					m_messages.Enqueue(item.Value.Value);
				}
			}
		}

		private void ConsumeReservedMessagesGreedyBounded()
		{
			int num = 0;
			List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = m_nonGreedyState.ReservedSourcesTemp;
			for (int i = 0; i < reservedSourcesTemp.Count; i++)
			{
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
				reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
				T value = keyValuePair.Key.ConsumeMessage(keyValuePair.Value.Key, m_owningBatch, out var messageConsumed);
				if (messageConsumed)
				{
					KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value.Key, value);
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> value3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value2);
					reservedSourcesTemp[i] = value3;
					num++;
				}
			}
			lock (IncomingLock)
			{
				if (m_boundingState != null)
				{
					m_boundingState.CurrentCount += num;
				}
				foreach (KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item in reservedSourcesTemp)
				{
					if (item.Key != null)
					{
						m_messages.Enqueue(item.Value.Value);
					}
				}
			}
		}

		internal void ReleaseReservedMessages(bool throwOnFirstException)
		{
			List<Exception> list = null;
			List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = m_nonGreedyState.ReservedSourcesTemp;
			for (int i = 0; i < reservedSourcesTemp.Count; i++)
			{
				KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
				reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
				ISourceBlock<T> key = keyValuePair.Key;
				KeyValuePair<DataflowMessageHeader, T> value = keyValuePair.Value;
				if (key == null || !value.Key.IsValid)
				{
					continue;
				}
				try
				{
					key.ReleaseReservation(value.Key, m_owningBatch);
				}
				catch (Exception item)
				{
					if (throwOnFirstException)
					{
						throw;
					}
					if (list == null)
					{
						list = new List<Exception>(1);
					}
					list.Add(item);
				}
			}
			if (list != null)
			{
				throw new AggregateException(list);
			}
		}

		internal void OnItemsRemoved(int numItemsRemoved)
		{
			if (m_boundingState != null)
			{
				lock (IncomingLock)
				{
					m_boundingState.CurrentCount -= numItemsRemoved;
					ProcessAsyncIfNecessary();
					CompleteBlockIfPossible();
				}
			}
		}

		internal static int CountItems(T[] singleOutputItem, IList<T[]> multipleOutputItems)
		{
			if (multipleOutputItems == null)
			{
				return singleOutputItem.Length;
			}
			int num = 0;
			foreach (T[] multipleOutputItem in multipleOutputItems)
			{
				num += multipleOutputItem.Length;
			}
			return num;
		}

		internal DebuggingInformation GetDebuggingInformation()
		{
			return new DebuggingInformation(this);
		}
	}

	private readonly BatchBlockTargetCore m_target;

	private readonly SourceCore<T[]> m_source;

	public int OutputCount => m_source.OutputCount;

	public Task Completion => m_source.Completion;

	public int BatchSize => m_target.BatchSize;

	private int OutputCountForDebugger => m_source.GetDebuggingInformation().OutputCount;

	private object DebuggerDisplayContent => string.Format("{0}, BatchSize={1}, OutputCount={2}", new object[3]
	{
		Common.GetNameForDebugger(this, m_source.DataflowBlockOptions),
		BatchSize,
		OutputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public BatchBlock(int batchSize)
		: this(batchSize, GroupingDataflowBlockOptions.Default)
	{
	}

	public BatchBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		if (batchSize < 1)
		{
			throw new ArgumentOutOfRangeException("batchSize", Resource.ArgumentOutOfRange_GenericPositive);
		}
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		if (dataflowBlockOptions.BoundedCapacity > 0 && dataflowBlockOptions.BoundedCapacity < batchSize)
		{
			throw new ArgumentOutOfRangeException("batchSize", Resource.ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity);
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<ISourceBlock<T[]>, int> itemsRemovedAction = null;
		Func<ISourceBlock<T[]>, T[], IList<T[]>, int> itemCountingFunc = null;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			itemsRemovedAction = delegate(ISourceBlock<T[]> owningSource, int count)
			{
				((BatchBlock<T>)owningSource).m_target.OnItemsRemoved(count);
			};
			itemCountingFunc = (ISourceBlock<T[]> owningSource, T[] singleOutputItem, IList<T[]> multipleOutputItems) => BatchBlockTargetCore.CountItems(singleOutputItem, multipleOutputItems);
		}
		m_source = new SourceCore<T[]>(this, dataflowBlockOptions, delegate(ISourceBlock<T[]> owningSource)
		{
			((BatchBlock<T>)owningSource).m_target.Complete(null, dropPendingMessages: true, releaseReservedMessages: false);
		}, itemsRemovedAction, itemCountingFunc);
		m_target = new BatchBlockTargetCore(this, batchSize, delegate(T[] batch)
		{
			m_source.AddMessage(batch);
		}, dataflowBlockOptions);
		m_target.Completion.ContinueWith(delegate
		{
			m_source.Complete();
		}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
		m_source.Completion.ContinueWith(delegate(Task completed, object state)
		{
			IDataflowBlock dataflowBlock = (BatchBlock<T>)state;
			dataflowBlock.Fault(completed.Exception);
		}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
		Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, m_source.Completion, delegate(object state)
		{
			((BatchBlockTargetCore)state).Complete(null, dropPendingMessages: true, releaseReservedMessages: false);
		}, m_target);
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	public void Complete()
	{
		m_target.Complete(null, dropPendingMessages: false, releaseReservedMessages: false);
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		m_target.Complete(exception, dropPendingMessages: true, releaseReservedMessages: false);
	}

	public void TriggerBatch()
	{
		m_target.TriggerBatch();
	}

	public IDisposable LinkTo(ITargetBlock<T[]> target, DataflowLinkOptions linkOptions)
	{
		return m_source.LinkTo(target, linkOptions);
	}

	public bool TryReceive(Predicate<T[]> filter, out T[] item)
	{
		return m_source.TryReceive(filter, out item);
	}

	public bool TryReceiveAll(out IList<T[]> items)
	{
		return m_source.TryReceiveAll(out items);
	}

	DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
	{
		return m_target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
	}

	T[] ISourceBlock<T[]>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target, out bool messageConsumed)
	{
		return m_source.ConsumeMessage(messageHeader, target, out messageConsumed);
	}

	bool ISourceBlock<T[]>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target)
	{
		return m_source.ReserveMessage(messageHeader, target);
	}

	void ISourceBlock<T[]>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target)
	{
		m_source.ReleaseReservation(messageHeader, target);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, m_source.DataflowBlockOptions);
	}
}
