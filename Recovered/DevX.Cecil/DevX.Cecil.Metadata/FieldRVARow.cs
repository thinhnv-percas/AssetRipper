using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	public sealed class FieldRVARow : IMetadataRow, IMetadataRowVisitable
	{
		public RVA RVA;

		public uint Field;

		internal FieldRVARow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFieldRVARow(this);
		}
	}
}
