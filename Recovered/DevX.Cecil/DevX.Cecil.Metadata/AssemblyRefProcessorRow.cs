namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefProcessorRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Processor;

		public uint AssemblyRef;

		internal AssemblyRefProcessorRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyRefProcessorRow(this);
		}
	}
}
