using ICSharpCode.NRefactory;

namespace ICSharpCode.Decompiler
{
	public interface ITextOutput
	{
		TextLocation Location
		{
			get;
		}

		void Indent();

		void Unindent();

		void Write(char ch);

		void Write(string text);

		void WriteLine();

		void WriteDefinition(string text, object definition, bool isLocal = true);

		void WriteReference(string text, object reference, bool isLocal = false);

		void AddDebugSymbols(MethodDebugSymbols methodDebugSymbols);

		void MarkFoldStart(string collapsedText = "...", bool defaultCollapsed = false);

		void MarkFoldEnd();
	}
}
