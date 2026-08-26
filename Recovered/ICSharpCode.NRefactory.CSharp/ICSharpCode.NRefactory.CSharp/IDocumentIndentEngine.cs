using ICSharpCode.NRefactory.Editor;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public interface IDocumentIndentEngine : ICloneable
	{
		IDocument Document
		{
			get;
		}

		string ThisLineIndent
		{
			get;
		}

		string NextLineIndent
		{
			get;
		}

		string CurrentIndent
		{
			get;
		}

		bool NeedsReindent
		{
			get;
		}

		int Offset
		{
			get;
		}

		TextLocation Location
		{
			get;
		}

		bool EnableCustomIndentLevels
		{
			get;
			set;
		}

		void Push(char ch);

		void Reset();

		void Update(int offset);

		new IDocumentIndentEngine Clone();
	}
}
