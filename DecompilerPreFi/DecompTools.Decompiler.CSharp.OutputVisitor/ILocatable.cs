using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

public interface ILocatable
{
	TextLocation Location { get; }
}
