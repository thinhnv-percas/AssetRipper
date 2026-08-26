using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast;

public static class NRefactoryExtensions
{
	public static T WithAnnotation<T>(this T node, object annotation) where T : AstNode
	{
		if (annotation != null)
		{
			node.AddAnnotation(annotation);
		}
		return node;
	}

	public static T CopyAnnotationsFrom<T>(this T node, AstNode other) where T : AstNode
	{
		foreach (object annotation in other.Annotations)
		{
			node.AddAnnotation(annotation);
		}
		return node;
	}

	public static T Detach<T>(this T node) where T : AstNode
	{
		node.Remove();
		return node;
	}

	public static Expression WithName(this Expression node, string patternGroupName)
	{
		return new NamedNode(patternGroupName, node);
	}

	public static Statement WithName(this Statement node, string patternGroupName)
	{
		return new NamedNode(patternGroupName, node);
	}

	public static void AddNamedArgument(this ICSharpCode.NRefactory.CSharp.Attribute attribute, ModuleDef module, Type attrType, AssemblyRef attrTypeAssemblyRef, Type fieldType, AssemblyRef fieldTypeAssemblyRef, string fieldName, Expression argument)
	{
		IdentifierExpression identifierExpression = new IdentifierExpression(fieldName);
		if (module != null)
		{
			if (attrTypeAssemblyRef == null)
			{
				attrTypeAssemblyRef = module.CorLibTypes.AssemblyRef;
			}
			if (fieldTypeAssemblyRef == null)
			{
				fieldTypeAssemblyRef = module.CorLibTypes.AssemblyRef;
			}
			TypeSig typeSig = module.CorLibTypes.GetCorLibTypeSig(module.Import(fieldType));
			if (typeSig == null)
			{
				TypeRefUser typeDefOrRef = module.UpdateRowId(new TypeRefUser(module, fieldType.Namespace, fieldType.Name, fieldTypeAssemblyRef));
				typeSig = (fieldType.IsValueType ? ((ClassOrValueTypeSig)new ValueTypeSig(typeDefOrRef)) : ((ClassOrValueTypeSig)new ClassSig(typeDefOrRef)));
			}
			MemberRefUser annotation = new MemberRefUser(module, fieldName, new FieldSig(typeSig), module.UpdateRowId(new TypeRefUser(module, attrType.Namespace, attrType.Name, attrTypeAssemblyRef)));
			identifierExpression.AddAnnotation(annotation);
			identifierExpression.IdentifierToken.AddAnnotation(annotation);
		}
		attribute.Arguments.Add(new AssignmentExpression(identifierExpression, argument));
	}

	public static AstType ToType(this Pattern pattern)
	{
		return pattern;
	}

	public static Expression ToExpression(this Pattern pattern)
	{
		return pattern;
	}

	public static Statement ToStatement(this Pattern pattern)
	{
		return pattern;
	}

	public static Statement GetNextStatement(this Statement statement)
	{
		AstNode nextSibling = statement.NextSibling;
		while (nextSibling != null && !(nextSibling is Statement))
		{
			nextSibling = nextSibling.NextSibling;
		}
		return (Statement)nextSibling;
	}

	public static void AddAllRecursiveILSpansTo(this AstNode node, AstNode target)
	{
		if (node != null)
		{
			List<ILSpan> allRecursiveILSpans = node.GetAllRecursiveILSpans();
			if (allRecursiveILSpans.Count > 0)
			{
				target.AddAnnotation(allRecursiveILSpans);
			}
		}
	}

	public static void AddAllRecursiveILSpansTo(this IEnumerable<AstNode> nodes, AstNode target)
	{
		if (nodes != null)
		{
			List<ILSpan> allRecursiveILSpans = nodes.GetAllRecursiveILSpans();
			if (allRecursiveILSpans.Count > 0)
			{
				target.AddAnnotation(allRecursiveILSpans);
			}
		}
	}

	public static List<ILSpan> GetAllRecursiveILSpans(this AstNode node)
	{
		if (node == null)
		{
			return new List<ILSpan>();
		}
		List<ILSpan> list = new List<ILSpan>();
		foreach (AstNode item in node.DescendantsAndSelf)
		{
			item.GetAllILSpans(list);
		}
		return list;
	}

	public static List<ILSpan> GetAllRecursiveILSpans(this IEnumerable<AstNode> nodes)
	{
		if (nodes == null)
		{
			return new List<ILSpan>();
		}
		List<ILSpan> list = new List<ILSpan>();
		foreach (AstNode node in nodes)
		{
			foreach (AstNode item in node.DescendantsAndSelf)
			{
				item.GetAllILSpans(list);
			}
		}
		return list;
	}

	public static List<ILSpan> GetAllILSpans(this AstNode node)
	{
		if (node == null)
		{
			return new List<ILSpan>();
		}
		List<ILSpan> list = new List<ILSpan>();
		node.GetAllILSpans(list);
		return list;
	}

	private static void GetAllILSpans(this AstNode node, List<ILSpan> ilSpans)
	{
		if (node == null)
		{
			return;
		}
		if (node is BlockStatement blockStatement)
		{
			ilSpans.AddRange(blockStatement.HiddenStart.GetAllRecursiveILSpans());
			ilSpans.AddRange(blockStatement.HiddenEnd.GetAllRecursiveILSpans());
		}
		if (node is ForeachStatement foreachStatement)
		{
			ilSpans.AddRange(foreachStatement.HiddenInitializer.GetAllRecursiveILSpans());
			ilSpans.AddRange(foreachStatement.HiddenGetCurrentNode.GetAllRecursiveILSpans());
			ilSpans.AddRange(foreachStatement.HiddenMoveNextNode.GetAllRecursiveILSpans());
			ilSpans.AddRange(foreachStatement.HiddenGetEnumeratorNode.GetAllRecursiveILSpans());
		}
		if (node is SwitchStatement switchStatement)
		{
			ilSpans.AddRange(switchStatement.HiddenEnd.GetAllRecursiveILSpans());
		}
		foreach (object annotation in node.Annotations)
		{
			if (annotation is IList<ILSpan> collection)
			{
				ilSpans.AddRange(collection);
			}
		}
	}

	public static AstNode CreateHidden(List<ILSpan> list, AstNode stmt)
	{
		if (list == null || list.Count == 0)
		{
			return stmt;
		}
		if (stmt == null)
		{
			stmt = new EmptyStatement();
		}
		stmt.AddAnnotation(list);
		return stmt;
	}

	public static AstNode CreateHidden(AstNode stmt, params AstNode[] otherNodes)
	{
		List<ILSpan> list = new List<ILSpan>();
		foreach (AstNode astNode in otherNodes)
		{
			if (astNode != null)
			{
				list.AddRange(astNode.GetAllRecursiveILSpans());
			}
		}
		if (list.Count > 0)
		{
			if (stmt == null)
			{
				stmt = new EmptyStatement();
			}
			stmt.AddAnnotation(list);
		}
		return stmt;
	}

	public static void RemoveAllILSpansRecursive(this AstNode node)
	{
		foreach (AstNode item in node.DescendantsAndSelf)
		{
			item.RemoveAnnotations(typeof(IList<ILSpan>));
		}
	}
}
