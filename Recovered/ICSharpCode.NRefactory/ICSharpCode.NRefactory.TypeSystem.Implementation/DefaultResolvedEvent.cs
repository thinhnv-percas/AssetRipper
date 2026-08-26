namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultResolvedEvent : AbstractResolvedMember, IEvent, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		protected new readonly IUnresolvedEvent unresolved;

		private IMethod addAccessor;

		private IMethod removeAccessor;

		private IMethod invokeAccessor;

		public bool CanAdd => unresolved.CanAdd;

		public bool CanRemove => unresolved.CanRemove;

		public bool CanInvoke => unresolved.CanInvoke;

		public IMethod AddAccessor => GetAccessor(ref addAccessor, unresolved.AddAccessor);

		public IMethod RemoveAccessor => GetAccessor(ref removeAccessor, unresolved.RemoveAccessor);

		public IMethod InvokeAccessor => GetAccessor(ref invokeAccessor, unresolved.InvokeAccessor);

		public DefaultResolvedEvent(IUnresolvedEvent unresolved, ITypeResolveContext parentContext)
			: base(unresolved, parentContext)
		{
			this.unresolved = unresolved;
		}

		public override IMember Specialize(TypeParameterSubstitution substitution)
		{
			if (TypeParameterSubstitution.Identity.Equals(substitution) || base.DeclaringTypeDefinition == null || base.DeclaringTypeDefinition.TypeParameterCount == 0)
			{
				return this;
			}
			if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
			{
				substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
			}
			return new SpecializedEvent(this, substitution);
		}
	}
}
