namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IVariable : ISymbol
	{
		new string Name
		{
			get;
		}

		DomRegion Region
		{
			get;
		}

		IType Type
		{
			get;
		}

		bool IsConst
		{
			get;
		}

		object ConstantValue
		{
			get;
		}
	}
}
