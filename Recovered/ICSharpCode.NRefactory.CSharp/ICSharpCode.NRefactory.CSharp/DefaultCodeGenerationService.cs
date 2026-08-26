using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	public class DefaultCodeGenerationService : CodeGenerationService
	{
		public override EntityDeclaration GenerateMemberImplementation(RefactoringContext context, IMember member, bool explicitImplementation)
		{
			TypeSystemAstBuilder typeSystemAstBuilder = context.CreateTypeSystemAstBuilder();
			typeSystemAstBuilder.GenerateBody = true;
			typeSystemAstBuilder.ShowModifiers = false;
			typeSystemAstBuilder.ShowAccessibility = true;
			typeSystemAstBuilder.ShowConstantValues = !explicitImplementation;
			typeSystemAstBuilder.ShowTypeParameterConstraints = !explicitImplementation;
			typeSystemAstBuilder.UseCustomEvents = explicitImplementation;
			EntityDeclaration entityDeclaration = typeSystemAstBuilder.ConvertEntity(member);
			if (explicitImplementation)
			{
				entityDeclaration.Modifiers = Modifiers.None;
				entityDeclaration.AddChild(typeSystemAstBuilder.ConvertType(member.DeclaringType ?? SpecialType.UnknownType), EntityDeclaration.PrivateImplementationTypeRole);
			}
			else if (member.DeclaringType != null && member.DeclaringType.Kind == TypeKind.Interface)
			{
				entityDeclaration.Modifiers |= Modifiers.Public;
			}
			else if (!member.ParentAssembly.InternalsVisibleTo(context.Compilation.MainAssembly))
			{
				entityDeclaration.Modifiers &= ~Modifiers.Internal;
			}
			return entityDeclaration;
		}
	}
}
