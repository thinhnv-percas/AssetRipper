namespace DecompTools.Decompiler.TypeSystem;

public interface IDecompilerTypeSystem : ICompilation
{
	new MetadataModule MainModule { get; }
}
