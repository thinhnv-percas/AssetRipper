namespace HE;

public struct BytePositionInfo
{
	private int _characterPosition;

	private long _index;

	internal int CharacterPosition => _characterPosition;

	internal long Index => _index;

	internal BytePositionInfo(long index, int characterPosition)
	{
		_index = index;
		_characterPosition = characterPosition;
	}
}
