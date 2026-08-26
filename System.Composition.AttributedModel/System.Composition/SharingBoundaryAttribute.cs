using System.Collections.ObjectModel;

namespace System.Composition;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
[MetadataAttribute]
[CLSCompliant(false)]
public sealed class SharingBoundaryAttribute : Attribute
{
	private readonly string[] _sharingBoundaryNames;

	public ReadOnlyCollection<string> SharingBoundaryNames => new ReadOnlyCollection<string>(_sharingBoundaryNames);

	public SharingBoundaryAttribute(params string[] sharingBoundaryNames)
	{
		if (sharingBoundaryNames == null)
		{
			throw new ArgumentNullException("sharingBoundaryNames");
		}
		_sharingBoundaryNames = sharingBoundaryNames;
	}
}
