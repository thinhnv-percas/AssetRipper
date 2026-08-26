namespace DevX.Cecil.Metadata
{
	public sealed class StandAloneSigRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Signature;

		internal StandAloneSigRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitStandAloneSigRow(this);
		}
	}
}
