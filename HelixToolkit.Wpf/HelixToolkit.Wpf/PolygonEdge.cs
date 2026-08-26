namespace HelixToolkit.Wpf;

internal class PolygonEdge
{
	private PolygonPoint mPointOne;

	private PolygonPoint mPointTwo;

	public PolygonPoint PointOne
	{
		get
		{
			return mPointOne;
		}
		set
		{
			mPointOne = value;
		}
	}

	public PolygonPoint PointTwo
	{
		get
		{
			return mPointTwo;
		}
		set
		{
			mPointTwo = value;
		}
	}

	public PolygonEdge Last
	{
		get
		{
			if (mPointOne != null && mPointOne.EdgeOne != null)
			{
				return mPointOne.EdgeOne;
			}
			return null;
		}
	}

	public PolygonEdge Next
	{
		get
		{
			if (mPointTwo != null && mPointTwo.EdgeTwo != null)
			{
				return mPointTwo.EdgeTwo;
			}
			return null;
		}
	}

	internal PolygonEdge(PolygonPoint one, PolygonPoint two)
	{
		mPointOne = one;
		mPointTwo = two;
	}

	public override string ToString()
	{
		return string.Concat("From: {", mPointOne, "} To: {", mPointTwo, "}");
	}
}
