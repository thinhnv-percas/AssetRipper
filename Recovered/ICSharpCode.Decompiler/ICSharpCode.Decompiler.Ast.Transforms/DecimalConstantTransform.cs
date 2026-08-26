using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using Mono.Cecil;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class DecimalConstantTransform : DepthFirstAstVisitor<object, object>, IAstTransform
	{
		private static readonly PrimitiveType decimalType = new PrimitiveType("decimal");

		public override object VisitFieldDeclaration(FieldDeclaration fieldDeclaration, object data)
		{
			if ((fieldDeclaration.Modifiers & (Modifiers.Static | Modifiers.Readonly)) == (Modifiers.Static | Modifiers.Readonly) && decimalType.IsMatch(fieldDeclaration.ReturnType))
			{
				foreach (AttributeSection attribute in fieldDeclaration.Attributes)
				{
					foreach (Attribute attribute2 in attribute.Attributes)
					{
						TypeReference typeReference = attribute2.Type.Annotation<TypeReference>();
						if (typeReference != null && typeReference.Name == "DecimalConstantAttribute" && typeReference.Namespace == "System.Runtime.CompilerServices")
						{
							attribute2.Remove();
							if (attribute.Attributes.Count == 0)
							{
								attribute.Remove();
							}
							fieldDeclaration.Modifiers = ((fieldDeclaration.Modifiers & ~(Modifiers.Static | Modifiers.Readonly)) | Modifiers.Const);
							return null;
						}
					}
				}
			}
			return null;
		}

		public void Run(AstNode compilationUnit)
		{
			compilationUnit.AcceptVisitor(this, null);
		}
	}
}
