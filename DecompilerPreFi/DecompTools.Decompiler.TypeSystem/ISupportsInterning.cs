namespace DecompTools.Decompiler.TypeSystem;

public interface ISupportsInterning
{
	int GetHashCodeForInterning();

	bool EqualsForInterning(ISupportsInterning other);
}
