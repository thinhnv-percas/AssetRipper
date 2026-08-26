namespace dnSpy.Contracts.Decompiler;

public sealed class CSharpMetadataTextColorProvider : MetadataTextColorProvider
{
	public static readonly CSharpMetadataTextColorProvider Instance = new CSharpMetadataTextColorProvider();

	private CSharpMetadataTextColorProvider()
	{
	}
}
