using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	public sealed class MethodRow : IMetadataRow, IMetadataRowVisitable
	{
		public RVA RVA;

		public MethodImplAttributes ImplFlags;

		public MethodAttributes Flags;

		public uint Name;

		public uint Signature;

		public uint ParamList;

		internal MethodRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMethodRow(this);
		}
	}
}
