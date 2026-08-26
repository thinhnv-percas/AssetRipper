using dnlib.DotNet;
using dnlib.IO;
using dnSpy.Contracts.Decompiler;

namespace dnSpy.Decompiler.IL;

internal sealed class OriginalInstructionBytesReader : IInstructionBytesReader
{
	private readonly bool hasReader;

	private DataReader reader;

	public bool IsOriginalBytes => true;

	public OriginalInstructionBytesReader(MethodDef method)
	{
		if (method.Module is ModuleDefMD moduleDefMD)
		{
			reader = moduleDefMD.Metadata.PEImage.CreateReader(method.RVA + method.Body.HeaderSize);
			hasReader = true;
		}
	}

	public int ReadByte()
	{
		if (hasReader)
		{
			return reader.ReadByte();
		}
		return -1;
	}

	public void SetInstruction(int index, uint offset)
	{
		if (hasReader)
		{
			reader.Position = offset;
		}
	}
}
