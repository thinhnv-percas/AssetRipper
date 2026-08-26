namespace DevX.Cecil.Cil
{
	public sealed class ExceptionHandler : ICodeVisitable
	{
		private Instruction m_tryStart;

		private Instruction m_tryEnd;

		private Instruction m_filterStart;

		private Instruction m_filterEnd;

		private Instruction m_handlerStart;

		private Instruction m_handlerEnd;

		private TypeReference m_catchType;

		private ExceptionHandlerType m_type;

		public Instruction TryStart
		{
			get
			{
				return m_tryStart;
			}
			set
			{
				m_tryStart = value;
			}
		}

		public Instruction TryEnd
		{
			get
			{
				return m_tryEnd;
			}
			set
			{
				m_tryEnd = value;
			}
		}

		public Instruction FilterStart
		{
			get
			{
				return m_filterStart;
			}
			set
			{
				m_filterStart = value;
			}
		}

		public Instruction FilterEnd
		{
			get
			{
				return m_filterEnd;
			}
			set
			{
				m_filterEnd = value;
			}
		}

		public Instruction HandlerStart
		{
			get
			{
				return m_handlerStart;
			}
			set
			{
				m_handlerStart = value;
			}
		}

		public Instruction HandlerEnd
		{
			get
			{
				return m_handlerEnd;
			}
			set
			{
				m_handlerEnd = value;
			}
		}

		public TypeReference CatchType
		{
			get
			{
				return m_catchType;
			}
			set
			{
				m_catchType = value;
			}
		}

		public ExceptionHandlerType Type
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type = value;
			}
		}

		public ExceptionHandler(ExceptionHandlerType type)
		{
			m_type = type;
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitExceptionHandler(this);
		}
	}
}
