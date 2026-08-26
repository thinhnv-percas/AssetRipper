using System.Diagnostics;
using System.Linq;

namespace System.Threading.Tasks.Dataflow.Internal;

[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
internal sealed class JoinBlockTargetSharedResources
{
	internal readonly IDataflowBlock m_ownerJoin;

	internal readonly JoinBlockTargetBase[] m_targets;

	internal readonly Action<Exception> m_exceptionAction;

	internal readonly Action m_joinFilledAction;

	internal readonly GroupingDataflowBlockOptions m_dataflowBlockOptions;

	internal readonly BoundingState m_boundingState;

	internal bool m_decliningPermanently;

	internal Task m_taskForInputProcessing;

	internal bool m_hasExceptions;

	internal long m_joinsCreated;

	private bool m_completionReserved;

	internal object IncomingLock => m_targets;

	internal bool AllTargetsHaveAtLeastOneMessage
	{
		get
		{
			JoinBlockTargetBase[] targets = m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				if (!joinBlockTargetBase.HasAtLeastOneMessageAvailable)
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool TargetsHaveAtLeastOneMessageQueuedOrPostponed
	{
		get
		{
			if (m_boundingState == null)
			{
				JoinBlockTargetBase[] targets = m_targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
				{
					if (!joinBlockTargetBase.HasAtLeastOneMessageAvailable && (m_decliningPermanently || joinBlockTargetBase.IsDecliningPermanently || !joinBlockTargetBase.HasAtLeastOnePostponedMessage))
					{
						return false;
					}
				}
				return true;
			}
			bool countIsLessThanBound = m_boundingState.CountIsLessThanBound;
			bool flag = true;
			bool flag2 = false;
			JoinBlockTargetBase[] targets2 = m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
			{
				bool flag3 = !m_decliningPermanently && !joinBlockTargetBase2.IsDecliningPermanently && joinBlockTargetBase2.HasAtLeastOnePostponedMessage;
				if (m_dataflowBlockOptions.Greedy && flag3 && (countIsLessThanBound || !joinBlockTargetBase2.HasTheHighestNumberOfMessagesAvailable))
				{
					return true;
				}
				bool hasAtLeastOneMessageAvailable = joinBlockTargetBase2.HasAtLeastOneMessageAvailable;
				flag &= hasAtLeastOneMessageAvailable || flag3;
				if (hasAtLeastOneMessageAvailable)
				{
					flag2 = true;
				}
			}
			if (flag)
			{
				if (!flag2)
				{
					return countIsLessThanBound;
				}
				return true;
			}
			return false;
		}
	}

	private bool CanceledOrFaulted
	{
		get
		{
			if (!m_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				return m_hasExceptions;
			}
			return true;
		}
	}

	internal bool JoinNeedsProcessing
	{
		get
		{
			if (m_taskForInputProcessing == null && !CanceledOrFaulted)
			{
				return TargetsHaveAtLeastOneMessageQueuedOrPostponed;
			}
			return false;
		}
	}

	private object DebuggerDisplayContent
	{
		get
		{
			IDebuggerDisplay debuggerDisplay = m_ownerJoin as IDebuggerDisplay;
			return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : m_ownerJoin)}\"";
		}
	}

	internal JoinBlockTargetSharedResources(IDataflowBlock ownerJoin, JoinBlockTargetBase[] targets, Action joinFilledAction, Action<Exception> exceptionAction, GroupingDataflowBlockOptions dataflowBlockOptions)
	{
		m_ownerJoin = ownerJoin;
		m_targets = targets;
		m_joinFilledAction = joinFilledAction;
		m_exceptionAction = exceptionAction;
		m_dataflowBlockOptions = dataflowBlockOptions;
		if (dataflowBlockOptions.BoundedCapacity > 0)
		{
			m_boundingState = new BoundingState(dataflowBlockOptions.BoundedCapacity);
		}
	}

	internal void CompleteEachTarget()
	{
		JoinBlockTargetBase[] targets = m_targets;
		foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
		{
			joinBlockTargetBase.CompleteCore(null, dropPendingMessages: true, releaseReservedMessages: false);
		}
	}

	private bool RetrievePostponedItemsNonGreedy()
	{
		lock (IncomingLock)
		{
			if (!TargetsHaveAtLeastOneMessageQueuedOrPostponed)
			{
				return false;
			}
		}
		bool flag = true;
		JoinBlockTargetBase[] targets = m_targets;
		foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
		{
			if (!joinBlockTargetBase.ReserveOneMessage())
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			JoinBlockTargetBase[] targets2 = m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
			{
				if (!joinBlockTargetBase2.ConsumeReservedMessage())
				{
					flag = false;
					break;
				}
			}
		}
		if (!flag)
		{
			JoinBlockTargetBase[] targets3 = m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase3 in targets3)
			{
				joinBlockTargetBase3.ReleaseReservedMessage();
			}
		}
		return flag;
	}

	private bool RetrievePostponedItemsGreedyBounded()
	{
		bool flag = false;
		JoinBlockTargetBase[] targets = m_targets;
		foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
		{
			flag |= joinBlockTargetBase.ConsumeOnePostponedMessage();
		}
		return flag;
	}

	internal void ProcessAsyncIfNecessary(bool isReplacementReplica = false)
	{
		if (JoinNeedsProcessing)
		{
			ProcessAsyncIfNecessary_Slow(isReplacementReplica);
		}
	}

	private void ProcessAsyncIfNecessary_Slow(bool isReplacementReplica)
	{
		m_taskForInputProcessing = new Task(delegate(object thisSharedResources)
		{
			((JoinBlockTargetSharedResources)thisSharedResources).ProcessMessagesLoopCore();
		}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
		DataflowEtwProvider log = DataflowEtwProvider.Log;
		if (log.IsEnabled())
		{
			log.TaskLaunchedForMessageHandling(m_ownerJoin, m_taskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, m_targets.Max((JoinBlockTargetBase t) => t.NumberOfMessagesAvailableOrPostponed));
		}
		Exception ex = Common.StartTaskSafe(m_taskForInputProcessing, m_dataflowBlockOptions.TaskScheduler);
		if (ex != null)
		{
			m_exceptionAction(ex);
			m_taskForInputProcessing = null;
			CompleteBlockIfPossible();
		}
	}

	internal void CompleteBlockIfPossible()
	{
		if (m_completionReserved)
		{
			return;
		}
		bool flag = m_decliningPermanently && !AllTargetsHaveAtLeastOneMessage;
		if (!flag)
		{
			JoinBlockTargetBase[] targets = m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				if (joinBlockTargetBase.IsDecliningPermanently && !joinBlockTargetBase.HasAtLeastOneMessageAvailable)
				{
					flag = true;
					break;
				}
			}
		}
		if (m_taskForInputProcessing != null || (!flag && !CanceledOrFaulted))
		{
			return;
		}
		m_completionReserved = true;
		m_decliningPermanently = true;
		Task.Factory.StartNew(delegate(object state)
		{
			JoinBlockTargetSharedResources joinBlockTargetSharedResources = (JoinBlockTargetSharedResources)state;
			JoinBlockTargetBase[] targets2 = joinBlockTargetSharedResources.m_targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
			{
				joinBlockTargetBase2.CompleteOncePossible();
			}
		}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
	}

	private void ProcessMessagesLoopCore()
	{
		try
		{
			int num = 0;
			int actualMaxMessagesPerTask = m_dataflowBlockOptions.ActualMaxMessagesPerTask;
			bool flag;
			do
			{
				flag = ((!m_dataflowBlockOptions.Greedy) ? RetrievePostponedItemsNonGreedy() : RetrievePostponedItemsGreedyBounded());
				if (flag)
				{
					lock (IncomingLock)
					{
						if (AllTargetsHaveAtLeastOneMessage)
						{
							m_joinFilledAction();
							m_joinsCreated++;
							if (!m_dataflowBlockOptions.Greedy && m_boundingState != null)
							{
								m_boundingState.CurrentCount++;
							}
						}
					}
				}
				num++;
			}
			while (flag && num < actualMaxMessagesPerTask);
		}
		catch (Exception exception)
		{
			m_targets[0].CompleteCore(exception, dropPendingMessages: true, releaseReservedMessages: true);
		}
		finally
		{
			lock (IncomingLock)
			{
				m_taskForInputProcessing = null;
				ProcessAsyncIfNecessary(isReplacementReplica: true);
				CompleteBlockIfPossible();
			}
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
}
