namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class SpecializedEvent : SpecializedMember, IEvent, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private readonly IEvent eventDefinition;

		private IMethod addAccessor;

		private IMethod removeAccessor;

		private IMethod invokeAccessor;

		public bool CanAdd => eventDefinition.CanAdd;

		public bool CanRemove => eventDefinition.CanRemove;

		public bool CanInvoke => eventDefinition.CanInvoke;

		public IMethod AddAccessor => WrapAccessor(ref addAccessor, eventDefinition.AddAccessor);

		public IMethod RemoveAccessor => WrapAccessor(ref removeAccessor, eventDefinition.RemoveAccessor);

		public IMethod InvokeAccessor => WrapAccessor(ref invokeAccessor, eventDefinition.InvokeAccessor);

		public SpecializedEvent(IEvent eventDefinition, TypeParameterSubstitution substitution)
			: base(eventDefinition)
		{
			this.eventDefinition = eventDefinition;
			AddSubstitution(substitution);
		}
	}
}
