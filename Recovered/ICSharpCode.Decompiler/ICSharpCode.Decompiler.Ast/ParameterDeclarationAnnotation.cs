using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.Ast
{
	public class ParameterDeclarationAnnotation
	{
		public readonly List<ParameterDeclaration> Parameters = new List<ParameterDeclaration>();

		public ParameterDeclarationAnnotation(ILExpression expr)
		{
			for (int i = 0; i < expr.Arguments.Count - 1; i++)
			{
				ILExpression iLExpression = expr.Arguments[i];
				ILVariable annotation = (ILVariable)iLExpression.Operand;
				TypeReference type = (TypeReference)iLExpression.Arguments[0].Arguments[0].Arguments[0].Operand;
				string name = (string)iLExpression.Arguments[0].Arguments[1].Operand;
				Parameters.Add(new ParameterDeclaration(AstBuilder.ConvertType(type), name).WithAnnotation(annotation));
			}
		}
	}
}
