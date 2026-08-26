using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class DecimalConstantTransform : DepthFirstAstVisitor, IAstTransform
{
	private static readonly PrimitiveType decimalType = new PrimitiveType("decimal");

	public override void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
	{
		if ((fieldDeclaration.Modifiers & (Modifiers.Static | Modifiers.Readonly)) != (Modifiers.Static | Modifiers.Readonly) || !decimalType.IsMatch(fieldDeclaration.ReturnType))
		{
			return;
		}
		foreach (AttributeSection attribute in fieldDeclaration.Attributes)
		{
			foreach (Attribute attribute2 in attribute.Attributes)
			{
				if (attribute2.Type.GetSymbol() is IType { Name: "DecimalConstantAttribute", Namespace: "System.Runtime.CompilerServices" })
				{
					attribute2.Remove();
					if (attribute.Attributes.Count == 0)
					{
						attribute.Remove();
					}
					fieldDeclaration.Modifiers = (fieldDeclaration.Modifiers & ~(Modifiers.Static | Modifiers.Readonly)) | Modifiers.Const;
					return;
				}
			}
		}
	}

	public void Run(AstNode rootNode, TransformContext context)
	{
		if (context.Settings.DecimalConstants)
		{
			rootNode.AcceptVisitor(this);
		}
	}
}
