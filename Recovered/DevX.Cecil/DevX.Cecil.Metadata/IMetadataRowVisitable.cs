namespace DevX.Cecil.Metadata
{
	public interface IMetadataRowVisitable
	{
		void Accept(IMetadataRowVisitor visitor);
	}
}
