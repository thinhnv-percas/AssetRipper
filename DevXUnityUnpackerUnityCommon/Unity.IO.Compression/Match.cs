namespace Unity.IO.Compression;

internal class Match
{
	private global::MatchState state;

	private int pos;

	private int len;

	private byte symbol;

	internal global::MatchState State
	{
		get
		{
			return state;
		}
		set
		{
			state = value;
		}
	}

	internal int Position
	{
		get
		{
			return pos;
		}
		set
		{
			pos = value;
		}
	}

	internal int Length
	{
		get
		{
			return len;
		}
		set
		{
			len = value;
		}
	}

	internal byte Symbol
	{
		get
		{
			return symbol;
		}
		set
		{
			symbol = value;
		}
	}
}
