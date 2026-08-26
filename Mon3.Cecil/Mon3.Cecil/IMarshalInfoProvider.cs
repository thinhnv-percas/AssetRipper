namespace Mon3.Cecil;

public interface IMarshalInfoProvider : IMetadataTokenProvider
{
	bool HasMarshalInfo { get; }

	MarshalInfo MarshalInfo { get; set; }
}
