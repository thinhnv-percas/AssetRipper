namespace DecompTools.Decompiler.TypeSystem;

public interface INamedElement
{
	string FullName { get; }

	string Name { get; }

	string ReflectionName { get; }

	string Namespace { get; }
}
