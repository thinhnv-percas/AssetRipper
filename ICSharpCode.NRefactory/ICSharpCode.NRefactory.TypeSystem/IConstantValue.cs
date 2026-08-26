using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IConstantValue
{
	ResolveResult Resolve(ITypeResolveContext context);
}
