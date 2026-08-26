using ICSharpCode.NRefactory.TypeSystem;
using System.Globalization;

namespace ICSharpCode.NRefactory.Semantics
{
	public class NamespaceResolveResult : ResolveResult
	{
		private readonly INamespace ns;

		public INamespace Namespace => ns;

		public string NamespaceName => ns.FullName;

		public NamespaceResolveResult(INamespace ns)
			: base(SpecialType.UnknownType)
		{
			this.ns = ns;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "[{0} {1}]", new object[2]
			{
				GetType().Name,
				ns
			});
		}
	}
}
