namespace DevX.Cecil.Metadata
{
	public sealed class ModuleRefRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Name;

		internal ModuleRefRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitModuleRefRow(this);
		}
	}
}
