using System.Collections;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Semantics;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class RemoveCLSCompliantAttribute : IAstTransform
{
	public void Run(AstNode rootNode, TransformContext context)
	{
		foreach (AttributeSection item in Enumerable.OfType<AttributeSection>((IEnumerable)rootNode.Children))
		{
			if (item.AttributeTarget == "assembly")
			{
				continue;
			}
			foreach (Attribute attribute in item.Attributes)
			{
				TypeResolveResult typeResolveResult = attribute.Type.Annotation<TypeResolveResult>();
				if (typeResolveResult != null && typeResolveResult.Type.FullName == "System.CLSCompliantAttribute")
				{
					attribute.Remove();
				}
			}
			if (item.Attributes.Count == 0)
			{
				item.Remove();
			}
		}
	}
}
