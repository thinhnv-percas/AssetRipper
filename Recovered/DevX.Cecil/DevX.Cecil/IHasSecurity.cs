namespace DevX.Cecil
{
	public interface IHasSecurity : IMetadataTokenProvider
	{
		SecurityDeclarationCollection SecurityDeclarations
		{
			get;
		}

		bool HasSecurityDeclarations
		{
			get;
		}
	}
}
