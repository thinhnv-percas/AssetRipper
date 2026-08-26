using System;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IAmbience
{
	ConversionFlags ConversionFlags { get; set; }

	[Obsolete("Use ConvertSymbol() instead")]
	string ConvertEntity(IEntity entity);

	string ConvertSymbol(ISymbol symbol);

	string ConvertType(IType type);

	[Obsolete("Use ConvertSymbol() instead")]
	string ConvertVariable(IVariable variable);

	string ConvertConstantValue(object constantValue);

	string WrapComment(string comment);
}
