namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IField : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility, IVariable
	{
		new string Name
		{
			get;
		}

		new DomRegion Region
		{
			get;
		}

		bool IsReadOnly
		{
			get;
		}

		bool IsVolatile
		{
			get;
		}

		bool IsFixed
		{
			get;
		}

		new IMemberReference ToReference();
	}
}
