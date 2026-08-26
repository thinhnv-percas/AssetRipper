using System.Text;

namespace HE;

public class FindOptions
{
	private bool _matchCase;

	private string _text;

	public bool IsValid { get; set; }

	public byte[] FindBuffer { get; private set; }

	public byte[] FindBufferLowerCase { get; private set; }

	public byte[] FindBufferUpperCase { get; private set; }

	public bool MatchCase
	{
		get
		{
			return _matchCase;
		}
		set
		{
			_matchCase = value;
			UpdateFindBuffer();
		}
	}

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			UpdateFindBuffer();
		}
	}

	public byte[] Hex { get; set; }

	public FindType Type { get; set; }

	private void UpdateFindBuffer()
	{
		string text = ((Text != null) ? Text : string.Empty);
		FindBuffer = Encoding.ASCII.GetBytes(text);
		FindBufferLowerCase = Encoding.ASCII.GetBytes(text.ToLower());
		FindBufferUpperCase = Encoding.ASCII.GetBytes(text.ToUpper());
	}
}
