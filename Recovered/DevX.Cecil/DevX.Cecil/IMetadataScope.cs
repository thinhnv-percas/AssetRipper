namespace DevX.Cecil
{
	public interface IMetadataScope : IMetadataTokenProvider
	{
		string Name
		{
			get;
			set;
		}
	}
}
