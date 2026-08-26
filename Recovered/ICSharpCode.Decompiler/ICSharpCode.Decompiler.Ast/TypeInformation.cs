using Mono.Cecil;

namespace ICSharpCode.Decompiler.Ast
{
	public class TypeInformation
	{
		public readonly TypeReference InferredType;

		public readonly TypeReference ExpectedType;

		public TypeInformation(TypeReference inferredType, TypeReference expectedType)
		{
			InferredType = inferredType;
			ExpectedType = expectedType;
		}
	}
}
