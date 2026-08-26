using System.Diagnostics;

namespace System.Threading.Tasks.Dataflow;

[DebuggerDisplay("PropagateCompletion = {PropagateCompletion}, MaxMessages = {MaxMessages}, Append = {Append}")]
public class DataflowLinkOptions
{
	internal const int Unbounded = -1;

	private bool m_propagateCompletion;

	private int m_maxNumberOfMessages = -1;

	private bool m_append = true;

	internal static readonly DataflowLinkOptions Default = new DataflowLinkOptions();

	internal static readonly DataflowLinkOptions UnlinkAfterOneAndPropagateCompletion = new DataflowLinkOptions
	{
		MaxMessages = 1,
		PropagateCompletion = true
	};

	public bool PropagateCompletion
	{
		get
		{
			return m_propagateCompletion;
		}
		set
		{
			m_propagateCompletion = value;
		}
	}

	public int MaxMessages
	{
		get
		{
			return m_maxNumberOfMessages;
		}
		set
		{
			if (value < 1 && value != -1)
			{
				throw new ArgumentOutOfRangeException("value");
			}
			m_maxNumberOfMessages = value;
		}
	}

	public bool Append
	{
		get
		{
			return m_append;
		}
		set
		{
			m_append = value;
		}
	}
}
