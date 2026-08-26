namespace ICSharpCode.NRefactory.TypeSystem;

public interface ISupportsInterning
{
	int GetHashCodeForInterning();

	bool EqualsForInterning(ISupportsInterning other);
}
