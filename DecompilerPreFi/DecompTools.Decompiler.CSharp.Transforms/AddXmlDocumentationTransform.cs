using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Xml;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Documentation;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class AddXmlDocumentationTransform : IAstTransform
{
	public void Run(AstNode rootNode, TransformContext context)
	{
		if (!context.Settings.ShowXmlDocumentation || context.DecompileRun.DocumentationProvider == null)
		{
			return;
		}
		try
		{
			IDocumentationProvider documentationProvider = context.DecompileRun.DocumentationProvider;
			foreach (EntityDeclaration item in Enumerable.OfType<EntityDeclaration>((IEnumerable)rootNode.DescendantsAndSelf))
			{
				if (item.GetSymbol() is IEntity entity)
				{
					string documentation = documentationProvider.GetDocumentation(entity);
					if (documentation != null)
					{
						InsertXmlDocumentation(item, new StringReader(documentation));
					}
				}
			}
		}
		catch (XmlException ex)
		{
			string[] array = (" Exception while reading XmlDoc: " + ex).Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
			AstNode firstChild = rootNode.FirstChild;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				rootNode.InsertChildBefore(firstChild, new Comment(array[i], CommentType.Documentation), Roles.Comment);
			}
		}
	}

	private static void InsertXmlDocumentation(AstNode node, StringReader r)
	{
		string text;
		do
		{
			text = r.ReadLine();
			if (text == null)
			{
				return;
			}
		}
		while (string.IsNullOrWhiteSpace(text));
		checked
		{
			string text2 = text.Substring(0, text.Length - text.TrimStart(Array.Empty<char>()).Length);
			string text3 = text;
			int num = 0;
			while (text3 != null)
			{
				if (string.IsNullOrWhiteSpace(text3))
				{
					num++;
				}
				else
				{
					while (num > 0)
					{
						Comment comment = new Comment(string.Empty, CommentType.Documentation);
						comment.AddAnnotation(node.GetResolveResult());
						node.Parent.InsertChildBefore(node, comment, Roles.Comment);
						num--;
					}
					if (text3.StartsWith(text2, StringComparison.Ordinal))
					{
						text3 = text3.Substring(text2.Length);
					}
					Comment comment2 = new Comment(" " + text3, CommentType.Documentation);
					comment2.AddAnnotation(node.GetResolveResult());
					node.Parent.InsertChildBefore(node, comment2, Roles.Comment);
				}
				text3 = r.ReadLine();
			}
		}
	}
}
