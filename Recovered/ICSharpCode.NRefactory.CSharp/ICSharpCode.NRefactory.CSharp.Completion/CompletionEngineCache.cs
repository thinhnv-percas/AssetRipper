using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class CompletionEngineCache
	{
		public List<INamespace> namespaces;

		public ICompletionData[] importCompletion;
	}
}
