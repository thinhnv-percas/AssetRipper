namespace DevX.Cecil.Metadata
{
	public interface IMetadataTableVisitable
	{
		void Accept(IMetadataTableVisitor visitor);
	}
}
