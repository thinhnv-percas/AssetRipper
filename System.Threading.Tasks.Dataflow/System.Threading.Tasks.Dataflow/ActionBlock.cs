using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks.Dataflow.Internal;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
[DebuggerTypeProxy(typeof(ActionBlock<>.DebugView))]
public sealed class ActionBlock<TInput> : ITargetBlock<TInput>, IDataflowBlock, IDebuggerDisplay
{
	private sealed class DebugView
	{
		private readonly ActionBlock<TInput> m_actionBlock;

		private readonly TargetCore<TInput>.DebuggingInformation m_defaultDebugInfo;

		private readonly SpscTargetCore<TInput>.DebuggingInformation m_spscDebugInfo;

		public IEnumerable<TInput> InputQueue
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return m_spscDebugInfo.InputQueue;
				}
				return m_defaultDebugInfo.InputQueue;
			}
		}

		public QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return null;
				}
				return m_defaultDebugInfo.PostponedMessages;
			}
		}

		public int CurrentDegreeOfParallelism
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return m_spscDebugInfo.CurrentDegreeOfParallelism;
				}
				return m_defaultDebugInfo.CurrentDegreeOfParallelism;
			}
		}

		public ExecutionDataflowBlockOptions DataflowBlockOptions
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return m_spscDebugInfo.DataflowBlockOptions;
				}
				return m_defaultDebugInfo.DataflowBlockOptions;
			}
		}

		public bool IsDecliningPermanently
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return m_spscDebugInfo.IsDecliningPermanently;
				}
				return m_defaultDebugInfo.IsDecliningPermanently;
			}
		}

		public bool IsCompleted
		{
			get
			{
				if (m_defaultDebugInfo == null)
				{
					return m_spscDebugInfo.IsCompleted;
				}
				return m_defaultDebugInfo.IsCompleted;
			}
		}

		public int Id => Common.GetBlockId(m_actionBlock);

		public DebugView(ActionBlock<TInput> actionBlock)
		{
			m_actionBlock = actionBlock;
			if (m_actionBlock.m_defaultTarget != null)
			{
				m_defaultDebugInfo = actionBlock.m_defaultTarget.GetDebuggingInformation();
			}
			else
			{
				m_spscDebugInfo = actionBlock.m_spscTarget.GetDebuggingInformation();
			}
		}
	}

	private readonly TargetCore<TInput> m_defaultTarget;

	private readonly SpscTargetCore<TInput> m_spscTarget;

	public Task Completion
	{
		get
		{
			if (m_defaultTarget == null)
			{
				return m_spscTarget.Completion;
			}
			return m_defaultTarget.Completion;
		}
	}

	public int InputCount
	{
		get
		{
			if (m_defaultTarget == null)
			{
				return m_spscTarget.InputCount;
			}
			return m_defaultTarget.InputCount;
		}
	}

	private int InputCountForDebugger
	{
		get
		{
			if (m_defaultTarget == null)
			{
				return m_spscTarget.InputCount;
			}
			return m_defaultTarget.GetDebuggingInformation().InputCount;
		}
	}

	private object DebuggerDisplayContent => string.Format("{0}, InputCount={1}", new object[2]
	{
		Common.GetNameForDebugger(this, (m_defaultTarget != null) ? m_defaultTarget.DataflowBlockOptions : m_spscTarget.DataflowBlockOptions),
		InputCountForDebugger
	});

	object IDebuggerDisplay.Content => DebuggerDisplayContent;

	public ActionBlock(Action<TInput> action)
		: this((Delegate)action, ExecutionDataflowBlockOptions.Default)
	{
	}

	public ActionBlock(Action<TInput> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this((Delegate)action, dataflowBlockOptions)
	{
	}

	public ActionBlock(Func<TInput, Task> action)
		: this((Delegate)action, ExecutionDataflowBlockOptions.Default)
	{
	}

	public ActionBlock(Func<TInput, Task> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
		: this((Delegate)action, dataflowBlockOptions)
	{
	}

	private ActionBlock(Delegate action, ExecutionDataflowBlockOptions dataflowBlockOptions)
	{
		if ((object)action == null)
		{
			throw new ArgumentNullException("action");
		}
		if (dataflowBlockOptions == null)
		{
			throw new ArgumentNullException("dataflowBlockOptions");
		}
		dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
		Action<TInput> syncAction = action as Action<TInput>;
		if (syncAction != null && dataflowBlockOptions.SingleProducerConstrained && dataflowBlockOptions.MaxDegreeOfParallelism == 1 && !dataflowBlockOptions.CancellationToken.CanBeCanceled && dataflowBlockOptions.BoundedCapacity == -1)
		{
			m_spscTarget = new SpscTargetCore<TInput>(this, syncAction, dataflowBlockOptions);
		}
		else
		{
			if (syncAction != null)
			{
				m_defaultTarget = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					ProcessMessage(syncAction, messageWithId);
				}, null, dataflowBlockOptions, TargetCoreOptions.RepresentsBlockCompletion);
			}
			else
			{
				Func<TInput, Task> asyncAction = action as Func<TInput, Task>;
				m_defaultTarget = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					ProcessMessageWithTask(asyncAction, messageWithId);
				}, null, dataflowBlockOptions, TargetCoreOptions.UsesAsyncCompletion | TargetCoreOptions.RepresentsBlockCompletion);
			}
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, Completion, delegate(object state)
			{
				((TargetCore<TInput>)state).Complete(null, dropPendingMessages: true);
			}, m_defaultTarget);
		}
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.DataflowBlockCreated(this, dataflowBlockOptions);
		}
	}

	private void ProcessMessage(Action<TInput> action, KeyValuePair<TInput, long> messageWithId)
	{
		try
		{
			action(messageWithId.Key);
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
			if (m_defaultTarget.IsBounded)
			{
				m_defaultTarget.ChangeBoundingCount(-1);
			}
		}
	}

	private void ProcessMessageWithTask(Func<TInput, Task> action, KeyValuePair<TInput, long> messageWithId)
	{
		Task task = null;
		Exception ex = null;
		try
		{
			task = action(messageWithId.Key);
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
				m_defaultTarget.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
			}
			m_defaultTarget.SignalOneAsyncMessageCompleted(-1);
		}
		else if (task.IsCompleted)
		{
			AsyncCompleteProcessMessageWithTask(task);
		}
		else
		{
			task.ContinueWith(delegate(Task completed, object state)
			{
				((ActionBlock<TInput>)state).AsyncCompleteProcessMessageWithTask(completed);
			}, this, CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
		}
	}

	private void AsyncCompleteProcessMessageWithTask(Task completed)
	{
		if (completed.IsFaulted)
		{
			m_defaultTarget.Complete(completed.Exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
		}
		m_defaultTarget.SignalOneAsyncMessageCompleted(-1);
	}

	public void Complete()
	{
		if (m_defaultTarget != null)
		{
			m_defaultTarget.Complete(null, dropPendingMessages: false);
		}
		else
		{
			m_spscTarget.Complete(null);
		}
	}

	void IDataflowBlock.Fault(Exception exception)
	{
		if (exception == null)
		{
			throw new ArgumentNullException("exception");
		}
		if (m_defaultTarget != null)
		{
			m_defaultTarget.Complete(exception, dropPendingMessages: true);
		}
		else
		{
			m_spscTarget.Complete(exception);
		}
	}

	public bool Post(TInput item)
	{
		DataflowMessageStatus dataflowMessageStatus = ((m_defaultTarget != null) ? m_defaultTarget.OfferMessage(Common.SingleMessageHeader, item, null, consumeToAccept: false) : m_spscTarget.OfferMessage(Common.SingleMessageHeader, item, null, consumeToAccept: false));
		return dataflowMessageStatus == DataflowMessageStatus.Accepted;
	}

	DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
	{
		if (m_defaultTarget == null)
		{
			return m_spscTarget.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
		}
		return m_defaultTarget.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
	}

	public override string ToString()
	{
		return Common.GetNameForDebugger(this, (m_defaultTarget != null) ? m_defaultTarget.DataflowBlockOptions : m_spscTarget.DataflowBlockOptions);
	}
}
