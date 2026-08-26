namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyProcessorRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Processor;

		internal AssemblyProcessorRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyProcessorRow(this);
		}
	}
}
