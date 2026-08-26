using System;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class RenameCallbackArguments
	{
		public AstNode NodeToReplace
		{
			get;
			private set;
		}

		public AstNode NewNode
		{
			get;
			private set;
		}

		public RenameCallbackArguments(AstNode nodeToReplace, AstNode newNode)
		{
			if (nodeToReplace == null)
			{
				throw new ArgumentNullException("nodeToReplace");
			}
			if (newNode == null)
			{
				throw new ArgumentNullException("newNode");
			}
			NodeToReplace = nodeToReplace;
			NewNode = newNode;
		}
	}
}
