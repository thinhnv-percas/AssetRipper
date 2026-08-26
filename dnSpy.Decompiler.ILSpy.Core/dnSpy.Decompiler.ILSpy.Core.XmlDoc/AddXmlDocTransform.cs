using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler.XmlDoc;
using ICSharpCode.NRefactory.CSharp;

namespace dnSpy.Decompiler.ILSpy.Core.XmlDoc;

internal struct AddXmlDocTransform
{
	private readonly StringBuilder stringBuilder;

	public AddXmlDocTransform(StringBuilder sb)
	{
		stringBuilder = sb;
	}

	public void Run(AstNode node)
	{
		if (node is EntityDeclaration)
		{
			IMemberRef memberRef = node.Annotation<IMemberRef>();
			if (memberRef != null && memberRef.Module != null)
			{
				XmlDocumentationProvider xmlDocumentationProvider = XmlDocLoader.LoadDocumentation(memberRef.Module);
				if (xmlDocumentationProvider != null)
				{
					string documentation = xmlDocumentationProvider.GetDocumentation(XmlDocKeyProvider.GetKey(memberRef, stringBuilder));
					if (!string.IsNullOrEmpty(documentation))
					{
						InsertXmlDocumentation(node, documentation);
					}
				}
			}
			if (!(node is TypeDeclaration))
			{
				return;
			}
		}
		foreach (AstNode child in node.Children)
		{
			Run(child);
		}
	}

	private void InsertXmlDocumentation(AstNode node, string doc)
	{
		foreach (SubString? item in new XmlDocLine(doc))
		{
			stringBuilder.Clear();
			if (item.HasValue)
			{
				stringBuilder.Append(' ');
				item.Value.WriteTo(stringBuilder);
			}
			node.Parent.InsertChildBefore(node, new Comment(stringBuilder.ToString(), CommentType.Documentation), Roles.Comment);
		}
	}
}
