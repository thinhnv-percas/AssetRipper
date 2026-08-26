#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal sealed class ConvertConstructorCallIntoInitializerVisitor : DepthFirstAstVisitor
{
	private readonly TransformContext context;

	private static readonly ExpressionStatement fieldInitializerPattern = new ExpressionStatement
	{
		Expression = new AssignmentExpression
		{
			Left = new Choice
			{
				new NamedNode("fieldAccess", new MemberReferenceExpression
				{
					Target = new ThisReferenceExpression(),
					MemberName = Pattern.AnyString
				}),
				new NamedNode("fieldAccess", new IdentifierExpression(Pattern.AnyString))
			},
			Operator = AssignmentOperatorType.Assign,
			Right = new AnyNode("initializer")
		}
	};

	private static readonly AstNode thisCallPattern = new ExpressionStatement(new InvocationExpression(new MemberReferenceExpression(new ThisReferenceExpression(), ".ctor"), new Repeat(new AnyNode())));

	public ConvertConstructorCallIntoInitializerVisitor(TransformContext context)
	{
		Debug.Assert(context != null);
		this.context = context;
	}

	public override void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
	{
		if (!(Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)constructorDeclaration.Body.Statements) is ExpressionStatement { Expression: InvocationExpression { Target: MemberReferenceExpression { MemberName: ".ctor" } target } expression } expressionStatement))
		{
			return;
		}
		ConstructorInitializer constructorInitializer = new ConstructorInitializer();
		if (target.Target is ThisReferenceExpression)
		{
			constructorInitializer.ConstructorInitializerType = ConstructorInitializerType.This;
		}
		else
		{
			if (!(target.Target is BaseReferenceExpression))
			{
				return;
			}
			constructorInitializer.ConstructorInitializerType = ConstructorInitializerType.Base;
		}
		expression.Arguments.MoveTo(constructorInitializer.Arguments);
		if (constructorInitializer.ConstructorInitializerType != ConstructorInitializerType.Base || constructorInitializer.Arguments.Count != 0)
		{
			constructorDeclaration.Initializer = constructorInitializer.CopyAnnotationsFrom(expression);
		}
		expressionStatement.Remove();
	}

	public override void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
	{
		HandleInstanceFieldInitializers(typeDeclaration.Members);
		base.VisitTypeDeclaration(typeDeclaration);
		RemoveSingleEmptyConstructor(typeDeclaration.Members, (ITypeDefinition)typeDeclaration.GetSymbol());
		HandleStaticFieldInitializers(typeDeclaration.Members);
	}

	internal void HandleInstanceFieldInitializers(IEnumerable<AstNode> members)
	{
		ConstructorDeclaration[] array = Enumerable.ToArray<ConstructorDeclaration>(Enumerable.Where<ConstructorDeclaration>(Enumerable.OfType<ConstructorDeclaration>((IEnumerable)members), (Func<ConstructorDeclaration, bool>)((ConstructorDeclaration c) => (c.Modifiers & Modifiers.Static) == 0)));
		ConstructorDeclaration[] array2 = Enumerable.ToArray<ConstructorDeclaration>(Enumerable.Where<ConstructorDeclaration>((IEnumerable<ConstructorDeclaration>)array, (Func<ConstructorDeclaration, bool>)((ConstructorDeclaration ctor) => !thisCallPattern.IsMatch(Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)ctor.Body.Statements)))));
		if (array2.Length == 0 || (array2[0].GetSymbol() is IMethod method && method.DeclaringType.IsReferenceType == false))
		{
			return;
		}
		bool flag = Enumerable.All<ConstructorDeclaration>((IEnumerable<ConstructorDeclaration>)array2, (Func<ConstructorDeclaration, bool>)((ConstructorDeclaration c) => c.HasModifier(Modifiers.Unsafe)));
		bool flag2;
		do
		{
			Match match = fieldInitializerPattern.Match(Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)array2[0].Body));
			if (!match.Success)
			{
				break;
			}
			IMember fieldOrPropertyOrEvent = (Enumerable.Single<AstNode>(match.Get<AstNode>("fieldAccess")).GetSymbol() as IMember)?.MemberDefinition;
			if ((!(fieldOrPropertyOrEvent is IField) && !(fieldOrPropertyOrEvent is IProperty) && !(fieldOrPropertyOrEvent is IEvent)) || !(Enumerable.FirstOrDefault<AstNode>(members, (Func<AstNode, bool>)((AstNode f) => f.GetSymbol() == fieldOrPropertyOrEvent)) is EntityDeclaration entityDeclaration) || entityDeclaration is CustomEventDeclaration)
			{
				break;
			}
			Expression expression = Enumerable.Single<Expression>(match.Get<Expression>("initializer"));
			if (Enumerable.Any<AstNode>(expression.DescendantsAndSelf, (Func<AstNode, bool>)((AstNode n) => n is ThisReferenceExpression || n is BaseReferenceExpression)))
			{
				break;
			}
			flag2 = true;
			for (int num = 1; num < array2.Length; num = checked(num + 1))
			{
				Match match2 = fieldInitializerPattern.Match(Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)array2[num].Body));
				if (!match2.Success)
				{
					flag2 = false;
					break;
				}
				IMember member = (Enumerable.Single<AstNode>(match2.Get<AstNode>("fieldAccess")).GetSymbol() as IMember)?.MemberDefinition;
				if (!member.Equals(fieldOrPropertyOrEvent))
				{
					flag2 = false;
				}
				if (!expression.IsMatch(Enumerable.Single<AstNode>(match2.Get<AstNode>("initializer"))))
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				ConstructorDeclaration[] array3 = array2;
				foreach (ConstructorDeclaration constructorDeclaration in array3)
				{
					Enumerable.First<Statement>((IEnumerable<Statement>)constructorDeclaration.Body).Remove();
				}
				if (flag && IntroduceUnsafeModifier.IsUnsafe(expression))
				{
					entityDeclaration.Modifiers |= Modifiers.Unsafe;
				}
				if (entityDeclaration is PropertyDeclaration propertyDeclaration)
				{
					propertyDeclaration.Initializer = expression.Detach();
				}
				else
				{
					Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)entityDeclaration.GetChildrenByRole(Roles.Variable)).Initializer = expression.Detach();
				}
			}
		}
		while (flag2);
	}

	internal void RemoveSingleEmptyConstructor(IEnumerable<AstNode> members, ITypeDefinition contextTypeDefinition)
	{
		if (contextTypeDefinition == null)
		{
			return;
		}
		ConstructorDeclaration[] array = Enumerable.ToArray<ConstructorDeclaration>(Enumerable.Where<ConstructorDeclaration>(Enumerable.OfType<ConstructorDeclaration>((IEnumerable)members), (Func<ConstructorDeclaration, bool>)((ConstructorDeclaration c) => (c.Modifiers & Modifiers.Static) == 0)));
		if (array.Length == 1 && (Enumerable.Any<AstNode>(Enumerable.Skip<AstNode>(members, 1)) || array[0].Parent is TypeDeclaration))
		{
			ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
			constructorDeclaration.Modifiers = (contextTypeDefinition.IsAbstract ? Modifiers.Protected : Modifiers.Public);
			if (array[0].HasModifier(Modifiers.Unsafe))
			{
				constructorDeclaration.Modifiers |= Modifiers.Unsafe;
			}
			constructorDeclaration.Body = new BlockStatement();
			if (constructorDeclaration.IsMatch(array[0]))
			{
				array[0].Remove();
			}
		}
	}

	internal void HandleStaticFieldInitializers(IEnumerable<AstNode> members)
	{
		ConstructorDeclaration constructorDeclaration = Enumerable.FirstOrDefault<ConstructorDeclaration>(Enumerable.OfType<ConstructorDeclaration>((IEnumerable)members), (Func<ConstructorDeclaration, bool>)((ConstructorDeclaration c) => (c.Modifiers & Modifiers.Static) == Modifiers.Static));
		if (constructorDeclaration == null)
		{
			return;
		}
		bool flag = constructorDeclaration.HasModifier(Modifiers.Unsafe);
		IMethod method = constructorDeclaration.GetSymbol() as IMethod;
		if (method.MetadataToken.IsNil)
		{
			return;
		}
		MetadataReader metadata = context.TypeSystem.MainModule.PEFile.Metadata;
		TypeDefinition typeDefinition = metadata.GetTypeDefinition(metadata.GetMethodDefinition((MethodDefinitionHandle)method.MetadataToken).GetDeclaringType());
		if (!typeDefinition.HasFlag(TypeAttributes.BeforeFieldInit))
		{
			return;
		}
		while (Enumerable.FirstOrDefault<Statement>((IEnumerable<Statement>)constructorDeclaration.Body.Statements) is ExpressionStatement { Expression: AssignmentExpression { Operator: AssignmentOperatorType.Assign } expression } expressionStatement)
		{
			IMember fieldOrProperty = (expression.Left.GetSymbol() as IMember)?.MemberDefinition;
			if ((!(fieldOrProperty is IField) && !(fieldOrProperty is IProperty)) || !fieldOrProperty.IsStatic || !(Enumerable.FirstOrDefault<AstNode>(members, (Func<AstNode, bool>)((AstNode f) => f.GetSymbol() == fieldOrProperty)) is EntityDeclaration entityDeclaration))
			{
				break;
			}
			if (flag && IntroduceUnsafeModifier.IsUnsafe(expression.Right))
			{
				entityDeclaration.Modifiers |= Modifiers.Unsafe;
			}
			if (entityDeclaration is FieldDeclaration fieldDeclaration)
			{
				Enumerable.Single<VariableInitializer>((IEnumerable<VariableInitializer>)fieldDeclaration.Variables).Initializer = expression.Right.Detach();
			}
			else
			{
				if (!(entityDeclaration is PropertyDeclaration propertyDeclaration))
				{
					break;
				}
				propertyDeclaration.Initializer = expression.Right.Detach();
			}
			expressionStatement.Remove();
		}
		if (constructorDeclaration.Body.Statements.Count == 0)
		{
			constructorDeclaration.Remove();
		}
	}
}
