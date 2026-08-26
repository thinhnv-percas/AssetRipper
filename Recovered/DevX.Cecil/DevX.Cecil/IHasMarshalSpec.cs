namespace DevX.Cecil
{
	public interface IHasMarshalSpec : IMetadataTokenProvider
	{
		MarshalSpec MarshalSpec
		{
			get;
			set;
		}
	}
}
