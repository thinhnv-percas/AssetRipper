using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	public abstract class CodeActionProvider
	{
		public abstract IEnumerable<CodeAction> GetActions(RefactoringContext context);
	}
}
