using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public class DefaultUnresolvedEvent : AbstractUnresolvedMember, IUnresolvedEvent, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	private IUnresolvedMethod addAccessor;

	private IUnresolvedMethod removeAccessor;

	private IUnresolvedMethod invokeAccessor;

	public bool CanAdd => addAccessor != null;

	public bool CanRemove => removeAccessor != null;

	public bool CanInvoke => invokeAccessor != null;

	public IUnresolvedMethod AddAccessor
	{
		get
		{
			return addAccessor;
		}
		set
		{
			ThrowIfFrozen();
			addAccessor = value;
		}
	}

	public IUnresolvedMethod RemoveAccessor
	{
		get
		{
			return removeAccessor;
		}
		set
		{
			ThrowIfFrozen();
			removeAccessor = value;
		}
	}

	public IUnresolvedMethod InvokeAccessor
	{
		get
		{
			return invokeAccessor;
		}
		set
		{
			ThrowIfFrozen();
			invokeAccessor = value;
		}
	}

	protected override void FreezeInternal()
	{
		base.FreezeInternal();
		FreezableHelper.Freeze(addAccessor);
		FreezableHelper.Freeze(removeAccessor);
		FreezableHelper.Freeze(invokeAccessor);
	}

	public DefaultUnresolvedEvent()
	{
		base.SymbolKind = SymbolKind.Event;
	}

	public DefaultUnresolvedEvent(IUnresolvedTypeDefinition declaringType, string name)
	{
		base.SymbolKind = SymbolKind.Event;
		base.DeclaringTypeDefinition = declaringType;
		base.Name = name;
		if (declaringType != null)
		{
			base.UnresolvedFile = declaringType.UnresolvedFile;
		}
	}

	public override IMember CreateResolved(ITypeResolveContext context)
	{
		return new DefaultResolvedEvent(this, context);
	}

	IEvent IUnresolvedEvent.Resolve(ITypeResolveContext context)
	{
		return (IEvent)Resolve(context);
	}
}
