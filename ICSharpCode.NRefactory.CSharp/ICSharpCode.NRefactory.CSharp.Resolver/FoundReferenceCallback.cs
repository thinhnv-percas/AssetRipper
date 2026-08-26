using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public delegate void FoundReferenceCallback(AstNode astNode, ResolveResult result);
