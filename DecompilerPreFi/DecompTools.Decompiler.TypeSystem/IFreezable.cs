namespace DecompTools.Decompiler.TypeSystem;

public interface IFreezable
{
	bool IsFrozen { get; }

	void Freeze();
}
