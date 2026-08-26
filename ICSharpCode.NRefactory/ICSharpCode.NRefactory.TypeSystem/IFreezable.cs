namespace ICSharpCode.NRefactory.TypeSystem;

public interface IFreezable
{
	bool IsFrozen { get; }

	void Freeze();
}
