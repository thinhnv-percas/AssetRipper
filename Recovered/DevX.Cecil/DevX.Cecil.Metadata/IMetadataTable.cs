namespace DevX.Cecil.Metadata
{
	public interface IMetadataTable : IMetadataTableVisitable
	{
		int Id
		{
			get;
		}

		RowCollection Rows
		{
			get;
			set;
		}
	}
}
