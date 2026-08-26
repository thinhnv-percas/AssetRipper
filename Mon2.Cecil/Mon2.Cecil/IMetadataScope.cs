namespace Mon2.Cecil;

public interface IMetadataScope : IMetadataTokenProvider
{
	MetadataScopeType MetadataScopeType { get; }

	string Name { get; set; }
}
