using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class SpecializedEvent : SpecializedMember, IEvent, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
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

	public static IEvent Create(IEvent ev, TypeParameterSubstitution substitution)
	{
		if (TypeParameterSubstitution.Identity.Equals(substitution) || ev.DeclaringType.TypeParameterCount == 0)
		{
			return ev;
		}
		if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
		{
			substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
		}
		return new SpecializedEvent(ev, substitution);
	}

	public SpecializedEvent(IEvent eventDefinition, TypeParameterSubstitution substitution)
		: base(eventDefinition)
	{
		this.eventDefinition = eventDefinition;
		AddSubstitution(substitution);
	}
}
