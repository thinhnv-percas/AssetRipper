using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}, MaxDegreeOfParallelism = {MaxDegreeOfParallelism}")]
public class ExecutionDataflowBlockOptions : DataflowBlockOptions
{
	internal new static readonly ExecutionDataflowBlockOptions Default = new ExecutionDataflowBlockOptions();

	private int m_maxDegreeOfParallelism = 1;

	private bool m_singleProducerConstrained;

	public int MaxDegreeOfParallelism
	{
		get
		{
			return m_maxDegreeOfParallelism;
		}
		set
		{
			if (value < 1 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			m_maxDegreeOfParallelism = value;
		}
	}

	public bool SingleProducerConstrained
	{
		get
		{
			return m_singleProducerConstrained;
		}
		set
		{
			m_singleProducerConstrained = value;
		}
	}

	internal int ActualMaxDegreeOfParallelism
	{
		get
		{
			if (m_maxDegreeOfParallelism != -1)
			{
				return m_maxDegreeOfParallelism;
			}
			return int.MaxValue;
		}
	}

	internal bool SupportsParallelExecution
	{
		get
		{
			if (m_maxDegreeOfParallelism != -1)
			{
				return m_maxDegreeOfParallelism > 1;
			}
			return true;
		}
	}

	internal new ExecutionDataflowBlockOptions DefaultOrClone()
	{
		if (this != Default)
		{
			ExecutionDataflowBlockOptions executionDataflowBlockOptions = new ExecutionDataflowBlockOptions();
			executionDataflowBlockOptions.TaskScheduler = base.TaskScheduler;
			executionDataflowBlockOptions.CancellationToken = base.CancellationToken;
			executionDataflowBlockOptions.MaxMessagesPerTask = base.MaxMessagesPerTask;
			executionDataflowBlockOptions.BoundedCapacity = base.BoundedCapacity;
			executionDataflowBlockOptions.NameFormat = base.NameFormat;
			executionDataflowBlockOptions.MaxDegreeOfParallelism = MaxDegreeOfParallelism;
			executionDataflowBlockOptions.SingleProducerConstrained = SingleProducerConstrained;
			return executionDataflowBlockOptions;
		}
		return this;
	}
}
