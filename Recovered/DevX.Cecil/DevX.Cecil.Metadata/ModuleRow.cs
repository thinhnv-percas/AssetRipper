namespace DevX.Cecil.Metadata
{
	public sealed class ModuleRow : IMetadataRow, IMetadataRowVisitable
	{
		public ushort Generation;

		public uint Name;

		public uint Mvid;

		public uint EncId;

		public uint EncBaseId;

		internal ModuleRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitModuleRow(this);
		}
	}
}
