namespace DevX.Cecil.Cil
{
	public class SequencePoint
	{
		private Document m_document;

		private int m_startLine;

		private int m_startColumn;

		private int m_endLine;

		private int m_endColumn;

		public int StartLine
		{
			get
			{
				return m_startLine;
			}
			set
			{
				m_startLine = value;
			}
		}

		public int StartColumn
		{
			get
			{
				return m_startColumn;
			}
			set
			{
				m_startColumn = value;
			}
		}

		public int EndLine
		{
			get
			{
				return m_endLine;
			}
			set
			{
				m_endLine = value;
			}
		}

		public int EndColumn
		{
			get
			{
				return m_endColumn;
			}
			set
			{
				m_endColumn = value;
			}
		}

		public Document Document
		{
			get
			{
				return m_document;
			}
			set
			{
				m_document = value;
			}
		}

		public SequencePoint(Document document)
		{
			m_document = document;
		}

		public SequencePoint(Document doc, int startLine, int startCol, int endLine, int endCol)
			: this(doc)
		{
			m_startLine = startLine;
			m_startColumn = startCol;
			m_endLine = endLine;
			m_endColumn = endCol;
		}
	}
}
