using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
internal sealed class SpscTargetCore<TInput>
{
	internal sealed class DebuggingInformation
	{
		private readonly SpscTargetCore<TInput> m_target;

		internal int InputCount => m_target.InputCount;

		internal IEnumerable<TInput> InputQueue => m_target.m_messages.ToList();

		internal int CurrentDegreeOfParallelism
		{
			get
			{
				if (m_target.m_activeConsumer == null || m_target.Completion.IsCompleted)
				{
					return 0;
				}
				return 1;
			}
		}

		internal ExecutionDataflowBlockOptions DataflowBlockOptions => m_target.m_dataflowBlockOptions;

		internal bool IsDecliningPermanently => m_target.m_decliningPermanently;

		internal bool IsCompleted => m_target.Completion.IsCompleted;

		internal DebuggingInformation(SpscTargetCore<TInput> target)
		{
			m_target = target;
		}
	}

	private readonly ITargetBlock<TInput> m_owningTarget;

	private readonly System.Threading.Tasks.SingleProducerSingleConsumerQueue<TInput> m_messages = new System.Threading.Tasks.SingleProducerSingleConsumerQueue<TInput>();

	private readonly ExecutionDataflowBlockOptions m_dataflowBlockOptions;

	private readonly Action<TInput> m_action;

	private volatile List<Exception> m_exceptions;

	private volatile bool m_decliningPermanently;

	private volatile bool m_completionReserved;

	private volatile Task m_activeConsumer;

	private TaskCompletionSource<VoidResult> m_completionTask;

	internal int InputCount => m_messages.Count;

	internal Task Completion => CompletionSource.Task;

	private TaskCompletionSource<VoidResult> CompletionSource => LazyInitializer.EnsureInitialized(ref m_completionTask, () => new TaskCompletionSource<VoidResult>());

	internal ExecutionDataflowBlockOptions DataflowBlockOptions => m_dataflowBlockOptions;

	private object DebuggerDisplayContent
	{
		get
		{
			IDebuggerDisplay debuggerDisplay = m_owningTarget as IDebuggerDisplay;
			return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : m_owningTarget)}\"";
		}
	}

	internal SpscTargetCore(ITargetBlock<TInput> owningTarget, Action<TInput> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
	{
		m_owningTarget = owningTarget;
		m_action = action;
		m_dataflowBlockOptions = dataflowBlockOptions;
	}

	internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
	{
		if (!m_decliningPermanently && !consumeToAccept)
		{
			m_messages.Enqueue(messageValue);
			Interlocked.MemoryBarrier();
			if (m_activeConsumer == null)
			{
				ScheduleConsumerIfNecessary(isReplica: false);
			}
			return DataflowMessageStatus.Accepted;
		}
		return OfferMessage_Slow(messageHeader, messageValue, source, consumeToAccept);
	}

	private DataflowMessageStatus OfferMessage_Slow(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
	{
		if (m_decliningPermanently)
		{
			return DataflowMessageStatus.DecliningPermanently;
		}
		if (!messageHeader.IsValid)
		{
			throw new ArgumentException(Resource.Argument_InvalidMessageHeader, "messageHeader");
		}
		if (consumeToAccept)
		{
			if (source == null)
			{
				throw new ArgumentException(Resource.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			messageValue = source.ConsumeMessage(messageHeader, m_owningTarget, out var messageConsumed);
			if (!messageConsumed)
			{
				return DataflowMessageStatus.NotAvailable;
			}
		}
		m_messages.Enqueue(messageValue);
		Interlocked.MemoryBarrier();
		if (m_activeConsumer == null)
		{
			ScheduleConsumerIfNecessary(isReplica: false);
		}
		return DataflowMessageStatus.Accepted;
	}

	private void ScheduleConsumerIfNecessary(bool isReplica)
	{
		if (m_activeConsumer != null)
		{
			return;
		}
		Task task = new Task(delegate(object state)
		{
			((SpscTargetCore<TInput>)state).ProcessMessagesLoopCore();
		}, this, CancellationToken.None, Common.GetCreationOptionsForTask(isReplica));
		if (Interlocked.CompareExchange(ref m_activeConsumer, task, null) == null)
		{
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(m_owningTarget, task, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, m_messages.Count);
			}
			task.Start(m_dataflowBlockOptions.TaskScheduler);
		}
	}

	private void ProcessMessagesLoopCore()
	{
		int num = 0;
		int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
		bool flag = true;
		while (flag)
		{
			flag = false;
			TInput result = default(TInput);
			try
			{
				while (m_exceptions == null && num < actualMaxMessagesPerTask && m_messages.TryDequeue(out result))
				{
					num++;
					m_action(result);
				}
			}
			catch (Exception ex)
			{
				if (!Common.IsCooperativeCancellation(ex))
				{
					m_decliningPermanently = true;
					Common.StoreDataflowMessageValueIntoExceptionData(ex, result);
					StoreException(ex);
				}
			}
			finally
			{
				if (!m_messages.IsEmpty && m_exceptions == null && num < actualMaxMessagesPerTask)
				{
					flag = true;
				}
				else
				{
					bool decliningPermanently = m_decliningPermanently;
					if ((decliningPermanently && m_messages.IsEmpty) || m_exceptions != null)
					{
						if (!m_completionReserved)
						{
							m_completionReserved = true;
							CompleteBlockOncePossible();
						}
					}
					else
					{
						Interlocked.Exchange(ref m_activeConsumer, null);
						if (!m_messages.IsEmpty || (!decliningPermanently && m_decliningPermanently) || m_exceptions != null)
						{
							ScheduleConsumerIfNecessary(isReplica: true);
						}
					}
				}
			}
		}
	}

	internal void Complete(Exception exception)
	{
		if (!m_decliningPermanently)
		{
			if (exception != null)
			{
				StoreException(exception);
			}
			m_decliningPermanently = true;
			ScheduleConsumerIfNecessary(isReplica: false);
		}
	}

	private void StoreException(Exception exception)
	{
		lock (LazyInitializer.EnsureInitialized(ref m_exceptions, () => new List<Exception>()))
		{
			m_exceptions.Add(exception);
		}
	}

	private void CompleteBlockOncePossible()
	{
		TInput result;
		while (m_messages.TryDequeue(out result))
		{
		}
		if (m_exceptions != null)
		{
			Exception[] exceptions;
			lock (m_exceptions)
			{
				exceptions = m_exceptions.ToArray();
			}
			CompletionSource.TrySetException(exceptions);
		}
		else
		{
			CompletionSource.TrySetResult(default(VoidResult));
		}
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCompleted(m_owningTarget);
		}
	}

	internal DebuggingInformation GetDebuggingInformation()
	{
		return new DebuggingInformation(this);
	}
}
