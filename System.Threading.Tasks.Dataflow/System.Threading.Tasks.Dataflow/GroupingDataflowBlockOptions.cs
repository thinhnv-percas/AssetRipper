using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}, Greedy = {Greedy}, MaxNumberOfGroups = {MaxNumberOfGroups}")]
public class GroupingDataflowBlockOptions : DataflowBlockOptions
{
	internal new static readonly GroupingDataflowBlockOptions Default = new GroupingDataflowBlockOptions();

	private bool m_greedy = true;

	private long m_maxNumberOfGroups = -1L;

	public bool Greedy
	{
		get
		{
			return m_greedy;
		}
		set
		{
			m_greedy = value;
		}
	}

	public long MaxNumberOfGroups
	{
		get
		{
			return m_maxNumberOfGroups;
		}
		set
		{
			if (value <= 0 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			m_maxNumberOfGroups = value;
		}
	}

	internal long ActualMaxNumberOfGroups
	{
		get
		{
			if (m_maxNumberOfGroups != -1)
			{
				return m_maxNumberOfGroups;
			}
			return long.MaxValue;
		}
	}

	internal new GroupingDataflowBlockOptions DefaultOrClone()
	{
		if (this != Default)
		{
			GroupingDataflowBlockOptions groupingDataflowBlockOptions = new GroupingDataflowBlockOptions();
			groupingDataflowBlockOptions.TaskScheduler = base.TaskScheduler;
			groupingDataflowBlockOptions.CancellationToken = base.CancellationToken;
			groupingDataflowBlockOptions.MaxMessagesPerTask = base.MaxMessagesPerTask;
			groupingDataflowBlockOptions.BoundedCapacity = base.BoundedCapacity;
			groupingDataflowBlockOptions.NameFormat = base.NameFormat;
			groupingDataflowBlockOptions.Greedy = Greedy;
			groupingDataflowBlockOptions.MaxNumberOfGroups = MaxNumberOfGroups;
			return groupingDataflowBlockOptions;
		}
		return this;
	}
}
