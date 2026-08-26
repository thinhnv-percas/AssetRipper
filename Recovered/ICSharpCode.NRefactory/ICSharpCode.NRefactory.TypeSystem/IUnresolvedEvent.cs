namespace ICSharpCode.NRefactory.TypeSystem
{
	public interface IUnresolvedEvent : IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
	{
		bool CanAdd
		{
			get;
		}

		bool CanRemove
		{
			get;
		}

		bool CanInvoke
		{
			get;
		}

		IUnresolvedMethod AddAccessor
		{
			get;
		}

		IUnresolvedMethod RemoveAccessor
		{
			get;
		}

		IUnresolvedMethod InvokeAccessor
		{
			get;
		}

		new IEvent Resolve(ITypeResolveContext context);
	}
}
