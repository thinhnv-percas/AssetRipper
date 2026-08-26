namespace System.Threading.Tasks.Dataflow.Internal;

internal sealed class BatchedJoinBlockTargetSharedResources
{
	internal readonly object m_incomingLock;

	internal readonly int m_batchSize;

	internal readonly Action m_batchSizeReachedAction;

	internal readonly Action m_allTargetsDecliningPermanentlyAction;

	internal readonly Action<Exception> m_exceptionAction;

	internal readonly Action m_completionAction;

	internal int m_remainingItemsInBatch;

	internal int m_remainingAliveTargets;

	internal bool m_decliningPermanently;

	internal long m_batchesCreated;

	internal BatchedJoinBlockTargetSharedResources(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions, Action batchSizeReachedAction, Action allTargetsDecliningAction, Action<Exception> exceptionAction, Action completionAction)
	{
		BatchedJoinBlockTargetSharedResources batchedJoinBlockTargetSharedResources = this;
		m_incomingLock = new object();
		m_batchSize = batchSize;
		m_remainingAliveTargets = 0;
		m_remainingItemsInBatch = batchSize;
		Action allTargetsDecliningPermanentlyAction = delegate
		{
			allTargetsDecliningAction();
			batchedJoinBlockTargetSharedResources.m_decliningPermanently = true;
		};
		m_allTargetsDecliningPermanentlyAction = allTargetsDecliningPermanentlyAction;
		m_batchSizeReachedAction = delegate
		{
			batchSizeReachedAction();
			batchedJoinBlockTargetSharedResources.m_batchesCreated++;
			if (batchedJoinBlockTargetSharedResources.m_batchesCreated >= dataflowBlockOptions.ActualMaxNumberOfGroups)
			{
				batchedJoinBlockTargetSharedResources.m_allTargetsDecliningPermanentlyAction();
			}
			else
			{
				batchedJoinBlockTargetSharedResources.m_remainingItemsInBatch = batchedJoinBlockTargetSharedResources.m_batchSize;
			}
		};
		m_exceptionAction = exceptionAction;
		m_completionAction = completionAction;
	}
}
