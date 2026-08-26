namespace ICSharpCode.NRefactory.Utils;

public class TextSegment : FormatStringSegmentBase
{
	public string Text { get; set; }

	public TextSegment(string text, int startLocation = 0, int? endLocation = null)
	{
		Text = text;
		base.StartLocation = startLocation;
		base.EndLocation = endLocation ?? (startLocation + text.Length);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj.GetType() != typeof(TextSegment))
		{
			return false;
		}
		TextSegment textSegment = (TextSegment)obj;
		return object.Equals(Text, textSegment.Text);
	}

	public bool Equals(TextSegment other)
	{
		if (other == null)
		{
			return false;
		}
		if (object.Equals(Text, other.Text) && base.StartLocation == other.StartLocation)
		{
			return base.EndLocation == other.EndLocation;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = 23;
		num = num * 37 + Text.GetHashCode();
		num = num * 37 + base.StartLocation.GetHashCode();
		return num * 37 + base.EndLocation.GetHashCode();
	}

	public override string ToString()
	{
		return $"[TextSegment: Text={Text}, StartLocation={base.StartLocation}, EndLocation={base.EndLocation}]";
	}
}
