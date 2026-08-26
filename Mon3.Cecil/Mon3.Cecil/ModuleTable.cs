using Mon3.Cecil.Metadata;

namespace Mon3.Cecil;

internal sealed class ModuleTable : OneRowTable<Row<uint, uint>>
{
	public override void Write(TableHeapBuffer buffer)
	{
		buffer.WriteUInt16(0);
		buffer.WriteString(row.Col1);
		buffer.WriteGuid(row.Col2);
		buffer.WriteUInt16(0);
		buffer.WriteUInt16(0);
	}
}
