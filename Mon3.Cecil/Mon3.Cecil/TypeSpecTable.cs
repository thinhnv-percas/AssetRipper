using Mon3.Cecil.Metadata;

namespace Mon3.Cecil;

internal sealed class TypeSpecTable : MetadataTable<uint>
{
	public override void Write(TableHeapBuffer buffer)
	{
		for (int i = 0; i < length; i++)
		{
			buffer.WriteBlob(rows[i]);
		}
	}
}
