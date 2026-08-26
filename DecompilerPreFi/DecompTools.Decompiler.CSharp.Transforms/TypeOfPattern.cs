using System;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal sealed class TypeOfPattern : Pattern
{
	private INode childNode;

	public TypeOfPattern(string groupName)
	{
		childNode = new MemberReferenceExpression(new InvocationExpression(new MemberReferenceExpression(new TypeReferenceExpression
		{
			Type = new TypePattern(typeof(Type)).ToType()
		}, "GetTypeFromHandle"), new TypeOfExpression(new AnyNode(groupName))), "TypeHandle");
	}

	public override bool DoMatch(INode other, Match match)
	{
		return childNode.DoMatch(other, match);
	}

	public override string ToString()
	{
		return "typeof(...)";
	}
}
