namespace dnSpy.Contracts.Decompiler;

public interface IInstructionBytesReader
{
	bool IsOriginalBytes { get; }

	int ReadByte();

	void SetInstruction(int index, uint offset);
}
