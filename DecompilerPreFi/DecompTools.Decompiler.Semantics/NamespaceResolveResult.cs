using System.Globalization;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class NamespaceResolveResult : ResolveResult
{
	private readonly INamespace ns;

	public INamespace Namespace => ns;

	public string NamespaceName => ns.FullName;

	public NamespaceResolveResult(INamespace ns)
		: base(SpecialType.NoType)
	{
		this.ns = ns;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1}]", GetType().Name, ns);
	}
}
