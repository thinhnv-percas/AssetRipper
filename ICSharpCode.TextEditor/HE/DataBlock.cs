namespace HE;

internal abstract class DataBlock
{
	internal DataMap _map;

	internal DataBlock _nextBlock;

	internal DataBlock _previousBlock;

	internal abstract long Length { get; }

	internal DataMap Map => _map;

	internal DataBlock NextBlock => _nextBlock;

	internal DataBlock PreviousBlock => _previousBlock;

	internal abstract void RemoveBytes(long position, long count);
}
