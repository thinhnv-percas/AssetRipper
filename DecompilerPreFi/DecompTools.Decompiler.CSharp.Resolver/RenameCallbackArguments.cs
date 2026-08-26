using System;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class RenameCallbackArguments
{
	public AstNode NodeToReplace { get; private set; }

	public AstNode NewNode { get; private set; }

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
