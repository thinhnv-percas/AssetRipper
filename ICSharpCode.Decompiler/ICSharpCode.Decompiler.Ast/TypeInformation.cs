using dnlib.DotNet;

namespace ICSharpCode.Decompiler.Ast;

public class TypeInformation
{
	public readonly TypeSig InferredType;

	public readonly TypeSig ExpectedType;

	public TypeInformation(TypeSig inferredType, TypeSig expectedType)
	{
		InferredType = inferredType;
		ExpectedType = expectedType;
	}
}
