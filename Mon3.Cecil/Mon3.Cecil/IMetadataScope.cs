namespace Mon3.Cecil;

public interface IMetadataScope : IMetadataTokenProvider
{
	MetadataScopeType MetadataScopeType { get; }

	string Name { get; set; }
}
