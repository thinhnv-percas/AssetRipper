using System.Collections.Generic;
using System.Text;
using dnlib.DotNet;
using ICSharpCode.Decompiler.ILAst;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast;

public class ParameterDeclarationAnnotation
{
	private readonly List<ParameterDeclaration> Parameters = new List<ParameterDeclaration>();

	private bool returnedParameters;

	public IEnumerable<ParameterDeclaration> GetParameters()
	{
		if (!returnedParameters)
		{
			returnedParameters = true;
		}
		else
		{
			for (int i = 0; i < Parameters.Count; i++)
			{
				ParameterDeclaration parameterDeclaration = Parameters[i];
				ParameterDeclaration parameterDeclaration2 = parameterDeclaration.Clone();
				parameterDeclaration2.AddAnnotationsFrom(parameterDeclaration);
				Parameters[i] = parameterDeclaration2;
			}
		}
		return Parameters;
	}

	public ParameterDeclarationAnnotation(ILExpression expr, StringBuilder sb)
	{
		for (int i = 0; i < expr.Arguments.Count - 1; i++)
		{
			ILExpression iLExpression = expr.Arguments[i];
			ILVariable annotation = (ILVariable)iLExpression.Operand;
			ITypeDefOrRef type = (ITypeDefOrRef)iLExpression.Arguments[0].Arguments[0].Arguments[0].Operand;
			string name = (string)iLExpression.Arguments[0].Arguments[1].Operand;
			Parameters.Add(new ParameterDeclaration(AstBuilder.ConvertType(type, sb), name).WithAnnotation(annotation));
		}
	}
}
