using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class LocalDeclarationSpaceVisitor : DepthFirstAstVisitor
	{
		private LocalDeclarationSpace currentDeclarationSpace;

		private Dictionary<AstNode, LocalDeclarationSpace> nodeDeclarationSpaces = new Dictionary<AstNode, LocalDeclarationSpace>();

		public LocalDeclarationSpace GetDeclarationSpace(AstNode node)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			while (node != null)
			{
				if (nodeDeclarationSpaces.TryGetValue(node, out LocalDeclarationSpace value))
				{
					return value;
				}
				node = node.Parent;
			}
			return null;
		}

		private void AddDeclaration(string name, AstNode node)
		{
			if (currentDeclarationSpace != null)
			{
				currentDeclarationSpace.AddDeclaration(name, node);
			}
		}

		public override void VisitVariableInitializer(VariableInitializer variableInitializer)
		{
			AddDeclaration(variableInitializer.Name, variableInitializer);
			base.VisitVariableInitializer(variableInitializer);
		}

		public override void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
		{
			AddDeclaration(parameterDeclaration.Name, parameterDeclaration);
			base.VisitParameterDeclaration(parameterDeclaration);
		}

		private void VisitNewDeclarationSpace(AstNode node)
		{
			LocalDeclarationSpace localDeclarationSpace = currentDeclarationSpace;
			currentDeclarationSpace = new LocalDeclarationSpace();
			localDeclarationSpace?.AddChildSpace(currentDeclarationSpace);
			VisitChildren(node);
			nodeDeclarationSpaces.Add(node, currentDeclarationSpace);
			currentDeclarationSpace = localDeclarationSpace;
		}

		public override void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
		{
			VisitNewDeclarationSpace(methodDeclaration);
		}

		public override void VisitBlockStatement(BlockStatement blockStatement)
		{
			VisitNewDeclarationSpace(blockStatement);
		}

		public override void VisitSwitchStatement(SwitchStatement switchStatement)
		{
			VisitNewDeclarationSpace(switchStatement);
		}

		public override void VisitForeachStatement(ForeachStatement foreachStatement)
		{
			AddDeclaration(foreachStatement.VariableName, foreachStatement);
			VisitNewDeclarationSpace(foreachStatement);
		}

		public override void VisitForStatement(ForStatement forStatement)
		{
			VisitNewDeclarationSpace(forStatement);
		}

		public override void VisitUsingStatement(UsingStatement usingStatement)
		{
			VisitNewDeclarationSpace(usingStatement);
		}

		public override void VisitLambdaExpression(LambdaExpression lambdaExpression)
		{
			VisitNewDeclarationSpace(lambdaExpression);
		}

		public override void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
		{
			VisitNewDeclarationSpace(anonymousMethodExpression);
		}

		public override void VisitEventDeclaration(EventDeclaration eventDeclaration)
		{
			AddDeclaration(eventDeclaration.Name, eventDeclaration);
		}

		public override void VisitCustomEventDeclaration(CustomEventDeclaration eventDeclaration)
		{
			VisitNewDeclarationSpace(eventDeclaration);
		}
	}
}
