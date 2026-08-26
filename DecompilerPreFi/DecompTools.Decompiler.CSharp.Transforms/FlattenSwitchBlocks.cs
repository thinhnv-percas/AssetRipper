using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal class FlattenSwitchBlocks : IAstTransform
{
	public void Run(AstNode rootNode, TransformContext context)
	{
		foreach (SwitchSection item in Enumerable.OfType<SwitchSection>((IEnumerable)rootNode.Descendants))
		{
			if (item.Statements.Count == 1 && Enumerable.First<Statement>((IEnumerable<Statement>)item.Statements) is BlockStatement blockStatement && !Enumerable.Any<Statement>((IEnumerable<Statement>)blockStatement.Statements, (Func<Statement, bool>)((Statement st) => st is VariableDeclarationStatement)))
			{
				blockStatement.Remove();
				blockStatement.Statements.MoveTo(item.Statements);
			}
		}
	}
}
