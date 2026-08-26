using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}")]
public class DataflowBlockOptions
{
	public const int Unbounded = -1;

	private TaskScheduler m_taskScheduler = TaskScheduler.Default;

	private CancellationToken m_cancellationToken = CancellationToken.None;

	private int m_maxMessagesPerTask = -1;

	private int m_boundedCapacity = -1;

	private string m_nameFormat = "{0} Id={1}";

	internal static readonly DataflowBlockOptions Default = new DataflowBlockOptions();

	public TaskScheduler TaskScheduler
	{
		get
		{
			return m_taskScheduler;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			m_taskScheduler = value;
		}
	}

	public CancellationToken CancellationToken
	{
		get
		{
			return m_cancellationToken;
		}
		set
		{
			m_cancellationToken = value;
		}
	}

	public int MaxMessagesPerTask
	{
		get
		{
			return m_maxMessagesPerTask;
		}
		set
		{
			if (value < 1 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			m_maxMessagesPerTask = value;
		}
	}

	internal int ActualMaxMessagesPerTask
	{
		get
		{
			if (m_maxMessagesPerTask != -1)
			{
				return m_maxMessagesPerTask;
			}
			return int.MaxValue;
		}
	}

	public int BoundedCapacity
	{
		get
		{
			return m_boundedCapacity;
		}
		set
		{
			if (value < 1 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			m_boundedCapacity = value;
		}
	}

	public string NameFormat
	{
		get
		{
			return m_nameFormat;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			m_nameFormat = value;
		}
	}

	internal DataflowBlockOptions DefaultOrClone()
	{
		if (this != Default)
		{
			DataflowBlockOptions dataflowBlockOptions = new DataflowBlockOptions();
			dataflowBlockOptions.TaskScheduler = TaskScheduler;
			dataflowBlockOptions.CancellationToken = CancellationToken;
			dataflowBlockOptions.MaxMessagesPerTask = MaxMessagesPerTask;
			dataflowBlockOptions.BoundedCapacity = BoundedCapacity;
			dataflowBlockOptions.NameFormat = NameFormat;
			return dataflowBlockOptions;
		}
		return this;
	}
}
