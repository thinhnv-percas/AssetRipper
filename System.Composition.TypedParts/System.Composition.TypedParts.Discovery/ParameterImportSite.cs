using System.Reflection;

namespace System.Composition.TypedParts.Discovery;

internal class ParameterImportSite
{
	private readonly ParameterInfo _pi;

	public ParameterInfo Parameter => _pi;

	public ParameterImportSite(ParameterInfo pi)
	{
		_pi = pi;
	}

	public override string ToString()
	{
		return _pi.Name;
	}
}
