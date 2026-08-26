using System;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public sealed class FindReferencedEntities : IResolveVisitorNavigator
{
	private readonly Action<AstNode, IMember> memberReferenceFound;

	private readonly Action<AstNode, IType> typeReferenceFound;

	public FindReferencedEntities(Action<AstNode, IEntity> referenceFound)
	{
		if (referenceFound == null)
		{
			throw new ArgumentNullException("referenceFound");
		}
		memberReferenceFound = delegate(AstNode node, IMember member)
		{
			referenceFound(node, member.MemberDefinition);
		};
		typeReferenceFound = delegate(AstNode node, IType type)
		{
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null)
			{
				referenceFound(node, definition);
			}
		};
	}

	public FindReferencedEntities(Action<AstNode, IType> typeReferenceFound, Action<AstNode, IMember> memberReferenceFound)
	{
		if (typeReferenceFound == null)
		{
			throw new ArgumentNullException("typeReferenceFound");
		}
		if (memberReferenceFound == null)
		{
			throw new ArgumentNullException("memberReferenceFound");
		}
		this.typeReferenceFound = typeReferenceFound;
		this.memberReferenceFound = memberReferenceFound;
	}

	public ResolveVisitorNavigationMode Scan(AstNode node)
	{
		return ResolveVisitorNavigationMode.Resolve;
	}

	public void Resolved(AstNode node, ResolveResult result)
	{
		if (ParenthesizedExpression.ActsAsParenthesizedExpression(node))
		{
			return;
		}
		if (result is MemberResolveResult memberResolveResult)
		{
			memberReferenceFound(node, memberResolveResult.Member);
		}
		if (result is TypeResolveResult typeResolveResult)
		{
			typeReferenceFound(node, typeResolveResult.Type);
		}
		if (result is ForEachResolveResult forEachResolveResult)
		{
			Resolved(node, forEachResolveResult.GetEnumeratorCall);
			if (forEachResolveResult.CurrentProperty != null)
			{
				memberReferenceFound(node, forEachResolveResult.CurrentProperty);
			}
			if (forEachResolveResult.MoveNextMethod != null)
			{
				memberReferenceFound(node, forEachResolveResult.MoveNextMethod);
			}
		}
	}

	public void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
	{
		if (conversion.IsUserDefined || conversion.IsMethodGroupConversion)
		{
			memberReferenceFound(expression, conversion.Method);
		}
	}
}
