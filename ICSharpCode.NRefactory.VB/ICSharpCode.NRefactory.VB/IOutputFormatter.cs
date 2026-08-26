using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.NRefactory.VB;

public interface IOutputFormatter
{
	int NextPosition { get; }

	void StartNode(AstNode node);

	void EndNode(AstNode node);

	void WriteIdentifier(string identifier, object data, object extraData = null);

	void WriteKeyword(string keyword);

	void WriteToken(string token, object data);

	void Space();

	void Indent();

	void Unindent();

	void NewLine();

	void WriteComment(bool isDocumentation, string content, CommentReference[] refs);

	void DebugStart(AstNode node);

	void DebugHidden(object hiddenILSpans);

	void DebugExpression(AstNode node);

	void DebugEnd(AstNode node);

	void AddHighlightedKeywordReference(object reference, int start, int end);

	void AddBracePair(int leftStart, int leftEnd, int rightStart, int rightEnd, CodeBracesRangeFlags flags);

	void AddBlock(int start, int end, CodeBracesRangeFlags flags);

	void AddLineSeparator(int position);
}
