namespace DevX.Cecil.Metadata
{
	public interface IMetadataVisitable
	{
		void Accept(IMetadataVisitor visitor);
	}
}
