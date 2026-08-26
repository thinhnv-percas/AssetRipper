using ICSharpCode.Decompiler.Ast.Transforms;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler
{
	internal class RemoveCompilerAttribute : DepthFirstAstVisitor<object, object>, IAstTransform
	{
		public override object VisitAttribute(Attribute attribute, object data)
		{
			AttributeSection attributeSection = (AttributeSection)attribute.Parent;
			SimpleType simpleType = attribute.Type as SimpleType;
			if (attributeSection.AttributeTarget == "assembly" && (simpleType.Identifier == "CompilationRelaxations" || simpleType.Identifier == "RuntimeCompatibility" || simpleType.Identifier == "SecurityPermission" || simpleType.Identifier == "AssemblyVersion" || simpleType.Identifier == "Debuggable"))
			{
				attribute.Remove();
				if (attributeSection.Attributes.Count == 0)
				{
					attributeSection.Remove();
				}
			}
			if (attributeSection.AttributeTarget == "module" && simpleType.Identifier == "UnverifiableCode")
			{
				attribute.Remove();
				if (attributeSection.Attributes.Count == 0)
				{
					attributeSection.Remove();
				}
			}
			return null;
		}

		public void Run(AstNode node)
		{
			node.AcceptVisitor(this, null);
		}
	}
}
