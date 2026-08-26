using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class ConvertConstructorCallIntoInitializer : DepthFirstAstVisitor<object, object>, IAstTransformPoolObject, IAstTransform
{
	private DecompilerContext context;

	private static readonly ExpressionStatement fieldOrPropInitializerPattern = new ExpressionStatement
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

	public ConvertConstructorCallIntoInitializer(DecompilerContext context)
	{
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		this.context = context;
	}

	public override object VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration, object data)
	{
		if (!(constructorDeclaration.Body.Statements.FirstOrDefault() is ExpressionStatement expressionStatement))
		{
			return null;
		}
		if (!(expressionStatement.Expression is InvocationExpression invocationExpression))
		{
			return null;
		}
		if (invocationExpression.Target is MemberReferenceExpression { MemberName: ".ctor" } memberReferenceExpression)
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
			List<ILSpan> allRecursiveILSpans = expressionStatement.GetAllRecursiveILSpans();
			if (constructorInitializer.ConstructorInitializerType != ConstructorInitializerType.Base || constructorInitializer.Arguments.Count != 0)
			{
				constructorDeclaration.Initializer = constructorInitializer.WithAnnotation(invocationExpression.Annotation<IMethod>());
				constructorInitializer.AddAnnotation(allRecursiveILSpans);
			}
			else
			{
				constructorDeclaration.Body.HiddenStart = NRefactoryExtensions.CreateHidden((!context.CalculateILSpans) ? null : ILSpan.OrderAndCompactList(allRecursiveILSpans), constructorDeclaration.Body.HiddenStart);
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
		if (!context.Settings.AllowFieldInitializers)
		{
			return;
		}
		ConstructorDeclaration[] array = (from c in members.OfType<ConstructorDeclaration>()
			where (c.Modifiers & Modifiers.Static) == 0
			select c).ToArray();
		ConstructorDeclaration[] array2 = array.Where((ConstructorDeclaration ctor) => !thisCallPattern.IsMatch(ctor.Body.Statements.FirstOrDefault())).ToArray();
		if (array2.Length == 0)
		{
			return;
		}
		MethodDef methodDef = array2[0].Annotation<MethodDef>();
		if (methodDef != null && DnlibExtensions.IsValueType(methodDef.DeclaringType))
		{
			return;
		}
		uint num = 0u;
		uint num2 = 0u;
		bool flag;
		do
		{
			Match match = fieldOrPropInitializerPattern.Match(array2[0].Body.FirstOrDefault());
			if (!match.Success)
			{
				break;
			}
			AstNode astNode = match.Get<AstNode>("fieldAccess").Single();
			AstNode astNode2 = null;
			IField field = astNode.Annotation<IField>();
			if (field != null && field.IsField)
			{
				if (field is MemberRef memberRef && !VerifyGenericClass((memberRef.Class as TypeSpec)?.TypeSig.RemovePinnedAndModifiers() as GenericInstSig))
				{
					break;
				}
				FieldDef fieldDef = field.ResolveFieldWithinSameModule();
				if (fieldDef == null || fieldDef.MDToken.Raw <= num)
				{
					break;
				}
				astNode2 = members.FirstOrDefault((AstNode f) => f.Annotation<FieldDef>() == fieldDef);
				num = fieldDef.MDToken.Raw;
			}
			else
			{
				PropertyDef prop = astNode.Annotation<PropertyDef>();
				if (prop != null && prop.MDToken.Raw > num2)
				{
					astNode2 = members.FirstOrDefault((AstNode f) => f.Annotation<PropertyDef>() == prop);
					num2 = prop.MDToken.Raw;
				}
			}
			if (astNode2 == null)
			{
				break;
			}
			Expression expression = match.Get<Expression>("initializer").Single();
			if (expression.DescendantsAndSelf.Any((AstNode n) => n is ThisReferenceExpression || n is BaseReferenceExpression))
			{
				break;
			}
			flag = true;
			for (int num3 = 1; num3 < array2.Length; num3++)
			{
				if (!array[0].Body.First().IsMatch(array2[num3].Body.FirstOrDefault()))
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				continue;
			}
			List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> list = new List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>>(array2.Length);
			foreach (ConstructorDeclaration constructorDeclaration in array2)
			{
				Statement statement = constructorDeclaration.Body.First();
				statement.Remove();
				MethodDebugInfoBuilder methodDebugInfoBuilder = constructorDeclaration.Annotation<MethodDebugInfoBuilder>() ?? constructorDeclaration.Body.Annotation<MethodDebugInfoBuilder>();
				if (methodDebugInfoBuilder != null)
				{
					list.Add(Tuple.Create(methodDebugInfoBuilder, statement.GetAllRecursiveILSpans()));
				}
			}
			if (astNode2 is PropertyDeclaration)
			{
				PropertyDeclaration propertyDeclaration = (PropertyDeclaration)astNode2;
				propertyDeclaration.Variables.Add(new VariableInitializer(null, string.Empty));
			}
			VariableInitializer variableInitializer = astNode2.GetChildrenByRole(Roles.Variable).Single();
			expression.Remove();
			expression.RemoveAllILSpansRecursive();
			variableInitializer.Initializer = expression;
			astNode2.AddAnnotation(list);
		}
		while (flag);
	}

	private void RemoveSingleEmptyConstructor(TypeDeclaration typeDeclaration)
	{
		if (!context.Settings.RemoveEmptyDefaultConstructors || context.Settings.ForceShowAllMembers)
		{
			return;
		}
		ConstructorDeclaration[] array = (from c in typeDeclaration.Members.OfType<ConstructorDeclaration>()
			where (c.Modifiers & Modifiers.Static) == 0
			select c).ToArray();
		if (array.Length == 1)
		{
			ConstructorDeclaration constructorDeclaration = new ConstructorDeclaration();
			constructorDeclaration.Modifiers = (((typeDeclaration.Modifiers & Modifiers.Abstract) == Modifiers.Abstract) ? Modifiers.Protected : Modifiers.Public);
			constructorDeclaration.Body = new BlockStatement();
			if (constructorDeclaration.IsMatch(array[0]))
			{
				array[0].Remove();
			}
		}
	}

	private static bool VerifyGenericClass(GenericInstSig gis)
	{
		if (gis == null)
		{
			return false;
		}
		for (int i = 0; i < gis.GenericArguments.Count; i++)
		{
			if (!(gis.GenericArguments[i] is GenericVar genericVar) || genericVar.Number != i)
			{
				return false;
			}
		}
		return true;
	}

	private void HandleStaticFieldInitializers(IEnumerable<AstNode> members)
	{
		if (!context.Settings.AllowFieldInitializers)
		{
			return;
		}
		ConstructorDeclaration constructorDeclaration = members.OfType<ConstructorDeclaration>().FirstOrDefault((ConstructorDeclaration c) => (c.Modifiers & Modifiers.Static) == Modifiers.Static);
		if (constructorDeclaration == null)
		{
			return;
		}
		MethodDef methodDef = constructorDeclaration.Annotation<MethodDef>();
		uint num = 0u;
		uint num2 = 0u;
		if (methodDef == null)
		{
			return;
		}
		MethodDebugInfoBuilder methodDebugInfoBuilder = constructorDeclaration.Annotation<MethodDebugInfoBuilder>() ?? constructorDeclaration.Body.Annotation<MethodDebugInfoBuilder>();
		while (constructorDeclaration.Body.Statements.FirstOrDefault() is ExpressionStatement { Expression: AssignmentExpression { Operator: AssignmentOperatorType.Assign, Left: var left } expression } expressionStatement)
		{
			IField field = left.Annotation<IField>();
			VariableInitializer variableInitializer;
			EntityDeclaration entityDeclaration;
			if (field != null && field.IsField)
			{
				if (field is MemberRef memberRef && !VerifyGenericClass((memberRef.Class as TypeSpec)?.TypeSig.RemovePinnedAndModifiers() as GenericInstSig))
				{
					break;
				}
				FieldDef fieldDef = field.ResolveFieldWithinSameModule();
				if (fieldDef == null || !fieldDef.IsStatic || fieldDef.MDToken.Raw <= num)
				{
					break;
				}
				FieldDeclaration fieldDeclaration = members.OfType<FieldDeclaration>().FirstOrDefault((FieldDeclaration f) => f.Annotation<FieldDef>() == fieldDef);
				if (fieldDeclaration == null)
				{
					break;
				}
				variableInitializer = fieldDeclaration.Variables.Single();
				entityDeclaration = fieldDeclaration;
				num = fieldDef.MDToken.Raw;
			}
			else
			{
				PropertyDef prop = left.Annotation<PropertyDef>();
				if (prop == null || prop.MDToken.Raw <= num2)
				{
					break;
				}
				PropertyDeclaration propertyDeclaration = members.OfType<PropertyDeclaration>().FirstOrDefault((PropertyDeclaration f) => f.Annotation<PropertyDef>() == prop);
				if (propertyDeclaration == null)
				{
					break;
				}
				entityDeclaration = propertyDeclaration;
				propertyDeclaration.Variables.Add(variableInitializer = new VariableInitializer(null, string.Empty));
				num2 = prop.MDToken.Raw;
			}
			List<ILSpan> allRecursiveILSpans = expression.GetAllRecursiveILSpans();
			expression.RemoveAllILSpansRecursive();
			variableInitializer.Initializer = expression.Right.Detach();
			List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>> list = new List<Tuple<MethodDebugInfoBuilder, List<ILSpan>>>(1);
			if (methodDebugInfoBuilder != null)
			{
				list.Add(Tuple.Create(methodDebugInfoBuilder, allRecursiveILSpans));
			}
			entityDeclaration.AddAnnotation(list);
			expressionStatement.Remove();
		}
		if (!context.Settings.ForceShowAllMembers && context.Settings.RemoveEmptyDefaultConstructors && constructorDeclaration.Body.Statements.Count == 0)
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
