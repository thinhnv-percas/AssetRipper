using System.Reflection;

namespace System.Composition.TypedParts.ActivationFeatures;

internal class PropertyImportSite
{
	private readonly PropertyInfo _pi;

	public PropertyInfo Property => _pi;

	public PropertyImportSite(PropertyInfo pi)
	{
		_pi = pi;
	}

	public override string ToString()
	{
		return _pi.Name;
	}
}
