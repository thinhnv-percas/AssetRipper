namespace DecompTools.Decompiler.TypeSystem;

public interface IEvent : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	bool CanAdd { get; }

	bool CanRemove { get; }

	bool CanInvoke { get; }

	IMethod AddAccessor { get; }

	IMethod RemoveAccessor { get; }

	IMethod InvokeAccessor { get; }
}
