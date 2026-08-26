using Mon3.Cecil.Metadata;

namespace Mon3.Cecil;

internal sealed class MethodImplTable : MetadataTable<Row<uint, uint, uint>>
{
	public override void Write(TableHeapBuffer buffer)
	{
		for (int i = 0; i < length; i++)
		{
			buffer.WriteRID(rows[i].Col1, Table.TypeDef);
			buffer.WriteCodedRID(rows[i].Col2, CodedIndex.MethodDefOrRef);
			buffer.WriteCodedRID(rows[i].Col3, CodedIndex.MethodDefOrRef);
		}
	}
}
