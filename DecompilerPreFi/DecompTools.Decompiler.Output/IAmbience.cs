using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Output;

public interface IAmbience
{
	ConversionFlags ConversionFlags { get; set; }

	string ConvertSymbol(ISymbol symbol);

	string ConvertType(IType type);

	string ConvertConstantValue(object constantValue);

	string WrapComment(string comment);
}
