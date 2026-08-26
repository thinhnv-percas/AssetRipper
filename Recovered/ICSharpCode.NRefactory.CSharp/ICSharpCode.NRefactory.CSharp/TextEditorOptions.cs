using System;

namespace ICSharpCode.NRefactory.CSharp
{
	public class TextEditorOptions
	{
		public static readonly TextEditorOptions Default = new TextEditorOptions();

		public bool TabsToSpaces
		{
			get;
			set;
		}

		public int TabSize
		{
			get;
			set;
		}

		public int IndentSize
		{
			get;
			set;
		}

		public int ContinuationIndent
		{
			get;
			set;
		}

		public int LabelIndent
		{
			get;
			set;
		}

		public string EolMarker
		{
			get;
			set;
		}

		public bool IndentBlankLines
		{
			get;
			set;
		}

		public int WrapLineLength
		{
			get;
			set;
		}

		public TextEditorOptions()
		{
			TabsToSpaces = false;
			TabSize = 4;
			IndentSize = 4;
			ContinuationIndent = 4;
			WrapLineLength = 0;
			EolMarker = Environment.NewLine;
		}
	}
}
