using ICSharpCode.NRefactory.CSharp.Refactoring;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp
{
	public abstract class CodeGenerationService
	{
		public abstract EntityDeclaration GenerateMemberImplementation(RefactoringContext context, IMember member, bool explicitImplementation);
	}
}
