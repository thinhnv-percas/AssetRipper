namespace ICSharpCode.NRefactory.MonoCSharp
{
	public enum ExprClass : byte
	{
		Unresolved,
		Value,
		Variable,
		Namespace,
		Type,
		TypeParameter,
		MethodGroup,
		PropertyAccess,
		EventAccess,
		IndexerAccess,
		Nothing
	}
}
