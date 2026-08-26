namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedAttribute
{
	DomRegion Region { get; }

	IAttribute CreateResolvedAttribute(ITypeResolveContext context);
}
