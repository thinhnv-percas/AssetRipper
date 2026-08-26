using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public interface ICompletionContextProvider
	{
		IList<string> ConditionalSymbols
		{
			get;
		}

		void GetCurrentMembers(int offset, out IUnresolvedTypeDefinition currentType, out IUnresolvedMember currentMember);

		Tuple<string, TextLocation> GetMemberTextToCaret(int caretOffset, IUnresolvedTypeDefinition currentType, IUnresolvedMember currentMember);

		CSharpAstResolver GetResolver(CSharpResolver resolver, AstNode rootNode);
	}
}
