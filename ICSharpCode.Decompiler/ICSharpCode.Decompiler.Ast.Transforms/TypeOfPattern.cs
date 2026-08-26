using System;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

internal sealed class TypeOfPattern : Pattern
{
	private INode childNode;

	public TypeOfPattern(string groupName)
	{
		childNode = new TypePattern(typeof(Type)).ToType().Invoke2(BoxedTextColor.StaticMethod, "GetTypeFromHandle", new TypeOfExpression(new AnyNode(groupName)).Member("TypeHandle", BoxedTextColor.InstanceProperty));
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
