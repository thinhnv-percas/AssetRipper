public class DefaultByteCharConverter : IByteCharConverter
{
	internal override char ToChar(byte b)
	{
		if (b <= 31 || (b > 126 && b < 160))
		{
			return '.';
		}
		return (char)b;
	}

	internal override byte ToByte(char c)
	{
		return (byte)c;
	}

	public override string ToString()
	{
		return "ANSI (Default)";
	}
}
