namespace System.Composition;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class SharedAttribute : PartMetadataAttribute
{
	private const string SharingBoundaryPartMetadataName = "SharingBoundary";

	public string SharingBoundary => (string)base.Value;

	public SharedAttribute()
		: base("SharingBoundary", null)
	{
	}

	public SharedAttribute(string sharingBoundaryName)
		: base("SharingBoundary", sharingBoundaryName)
	{
	}
}
