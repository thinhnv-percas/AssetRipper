using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class ConvertConstructorCallIntoInitializer : DepthFirstAstVisitor<object, object>, IAstTransform
	{
		private static readonly ExpressionStatement fieldInitializerPattern = new ExpressionStatement
		{
			Expression = new AssignmentExpression
			{
				Left = new NamedNode("fieldAccess", new MemberReferenceExpression
				{
					Target = new ThisReferenceExpression(),
					MemberName = Pattern.AnyString
				}),
				Operator = AssignmentOperatorType.Assign,
				Right = new AnyNode("initializer")
			}
		};

		private static readonly AstNode thisCallPattern = new ExpressionStatement(new ThisReferenceExpression().Invoke(".ctor", new Repeat(new AnyNode())));

		public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
		{
			ExpressionStatement expressionStatement = constructorDeclaration.Body.Statements.FirstOrDefault() as ExpressionStatement;
			if (expressionStatement == null)
			{
				return null;
			}
			InvocationExpression invocationExpression = expressionStatement.Expression as InvocationExpression;
			if (invocationExpression == null)
			{
				return null;
			}
			MemberReferenceExpression memberReferenceExpression = invocationExpression.Target as MemberReferenceExpression;
			if (memberReferenceExpression != null && memberReferenceExpression.MemberName == ".ctor")
			{
				ConstructorInitializer constructorInitializer = new ConstructorInitializer();
				if (memberReferenceExpression.Target is ThisReferenceExpression)
				{
					constructorInitializer.ConstructorInitializerType = ConstructorInitializerType.This;
				}
				else
				{
					if (!(memberReferenceExpression.Target is BaseReferenceExpression))
					{
						return null;
					}
					constructorInitializer.ConstructorInitializerType = ConstructorInitializerType.Base;
				}
				invocationExpression.Arguments.MoveTo(constructorInitializer.Arguments);
				if (constructorInitializer.ConstructorInitializerType != ConstructorInitializerType.Base || constructorInitializer.Arguments.Count != 0)
				{
					constructorDeclaration.Initializer = constructorInitializer.WithAnnotation(invocationExpression.Annotation<MethodReference>());
				}
				expressionStatement.Remove();
			}
			return null;
		}

		public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
		{
			HandleInstanceFieldInitializers(typeDeclaration.Members);
			base.VisitTypeDeclaration(typeDeclaration, data);
			RemoveSingleEmptyConstructor(typeDeclaration);
			HandleStaticFieldInitializers(typeDeclaration.Members);
			return null;
		}

		private void HandleInstanceFieldInitializers(IEnumerable<AstNode> members)
		{
			ConstructorDeclaration[] array = (from c in members.OfType<ConstructorDeclaration>()
				where (c.Modifiers & Modifiers.Static) == Modifiers.None
				select c).ToArray();
			ConstructorDeclaration[] array2 = (from ctor in array
				where !thisCallPattern.IsMatch(ctor.Body.Statements.FirstOrDefault())
				select ctor).ToArray();
			if (array2.Length == 0)
			{
				return;
			}
			MethodDefinition methodDefinition = array2[0].Annotation<MethodDefinition>();
			if (methodDefinition != null && methodDefinition.DeclaringType.IsValueType)
			{
				return;
			}
			bool flag;
			do
			{
				Match match = fieldInitializerPattern.Match(array2[0].Body.FirstOrDefault());
				if (!match.Success)
				{
					break;
				}
				FieldDefinition fieldDef = match.Get<AstNode>("fieldAccess").Single().Annotation<FieldReference>()
					.ResolveWithinSameModule();
				if (fieldDef == null)
				{
					break;
				}
				AstNode astNode = members.FirstOrDefault((AstNode f) => f.Annotation<FieldDefinition>() == fieldDef);
				if (astNode == null)
				{
					break;
				}
				Expression expression = match.Get<Expression>("initializer").Single();
				if (expression.DescendantsAndSelf.Any((AstNode n) => (!(n is ThisReferenceExpression)) ? (n is BaseReferenceExpression) : true))
				{
					break;
				}
				flag = true;
				for (int i = 1; i < array2.Length; i++)
				{
					if (!array[0].Body.First().IsMatch(array2[i].Body.FirstOrDefault()))
					{
						flag = false;
					}
				}
				if (flag)
				{
					ConstructorDeclaration[] array3 = array2;
					for (int j = 0; j < array3.Length; j++)
					{
						array3[j].Body.First().Remove();
					}
					astNode.GetChildrenByRole(Roles.Variable).Single().Initializer = expression.Detach();
				}
			}
			while (flag);
		}

		private void RemoveSingleEmptyConstructor(TypeDeclaration typeDeclaration)
		{
			ConstructorDeclaration[] array = (from c in typeDeclaration.Members.OfType<ConstructorDeclaration>()
				where (c.Modifiers & Modifiers.Static) == Modifiers.None
				select c).ToArray();
			if (array.Length == 1 && new ConstructorDeclaration
			{
				Modifiers = (((typeDeclaration.Modifiers & Modifiers.Abstract) == Modifiers.Abstract) ? Modifiers.Protected : Modifiers.Public),
				Body = new BlockStatement()
			}.IsMatch(array[0]))
			{
				array[0].Remove();
			}
		}

		private void HandleStaticFieldInitializers(IEnumerable<AstNode> members)
		{
			ConstructorDeclaration constructorDeclaration = members.OfType<ConstructorDeclaration>().FirstOrDefault((ConstructorDeclaration c) => (c.Modifiers & Modifiers.Static) == Modifiers.Static);
			if (constructorDeclaration == null)
			{
				return;
			}
			MethodDefinition methodDefinition = constructorDeclaration.Annotation<MethodDefinition>();
			if (methodDefinition == null || !methodDefinition.DeclaringType.IsBeforeFieldInit)
			{
				return;
			}
			while (true)
			{
				ExpressionStatement expressionStatement = constructorDeclaration.Body.Statements.FirstOrDefault() as ExpressionStatement;
				if (expressionStatement == null)
				{
					break;
				}
				AssignmentExpression assignmentExpression = expressionStatement.Expression as AssignmentExpression;
				if (assignmentExpression == null || assignmentExpression.Operator != 0)
				{
					break;
				}
				FieldDefinition fieldDef = assignmentExpression.Left.Annotation<FieldReference>().ResolveWithinSameModule();
				if (fieldDef == null || !fieldDef.IsStatic)
				{
					break;
				}
				FieldDeclaration fieldDeclaration = members.OfType<FieldDeclaration>().FirstOrDefault((FieldDeclaration f) => f.Annotation<FieldDefinition>() == fieldDef);
				if (fieldDeclaration == null)
				{
					break;
				}
				fieldDeclaration.Variables.Single().Initializer = assignmentExpression.Right.Detach();
				expressionStatement.Remove();
			}
			if (constructorDeclaration.Body.Statements.Count == 0)
			{
				constructorDeclaration.Remove();
			}
		}

		void IAstTransform.Run(AstNode node)
		{
			HandleInstanceFieldInitializers(node.Children);
			HandleStaticFieldInitializers(node.Children);
			node.AcceptVisitor(this, null);
		}
	}
}
