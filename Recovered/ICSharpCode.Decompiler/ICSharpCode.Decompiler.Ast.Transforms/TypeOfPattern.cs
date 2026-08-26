using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using System;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	internal sealed class TypeOfPattern : Pattern
	{
		private INode childNode;

		public TypeOfPattern(string groupName)
		{
			childNode = new TypePattern(typeof(Type)).ToType().Invoke("GetTypeFromHandle", new TypeOfExpression(new AnyNode(groupName)).Member("TypeHandle"));
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
}
