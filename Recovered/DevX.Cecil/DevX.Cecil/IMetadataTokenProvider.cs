using DevX.Cecil.Metadata;

namespace DevX.Cecil
{
	public interface IMetadataTokenProvider
	{
		MetadataToken MetadataToken
		{
			get;
			set;
		}
	}
}
