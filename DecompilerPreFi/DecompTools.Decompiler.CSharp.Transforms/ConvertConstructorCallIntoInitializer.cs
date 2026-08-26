using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.Transforms;

public class ConvertConstructorCallIntoInitializer : IAstTransform
{
	public void Run(AstNode node, TransformContext context)
	{
		ConvertConstructorCallIntoInitializerVisitor convertConstructorCallIntoInitializerVisitor = new ConvertConstructorCallIntoInitializerVisitor(context);
		convertConstructorCallIntoInitializerVisitor.HandleInstanceFieldInitializers(node.Children);
		convertConstructorCallIntoInitializerVisitor.HandleStaticFieldInitializers(node.Children);
		node.AcceptVisitor(convertConstructorCallIntoInitializerVisitor);
		convertConstructorCallIntoInitializerVisitor.RemoveSingleEmptyConstructor(node.Children, context.CurrentTypeDefinition);
	}
}
