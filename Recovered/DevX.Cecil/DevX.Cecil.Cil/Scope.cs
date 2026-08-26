namespace DevX.Cecil.Cil
{
	public class Scope : ICodeVisitable, IScopeProvider, IVariableDefinitionProvider
	{
		private Instruction m_start;

		private Instruction m_end;

		private Scope m_parent;

		private ScopeCollection m_scopes;

		private VariableDefinitionCollection m_variables;

		public Instruction Start
		{
			get
			{
				return m_start;
			}
			set
			{
				m_start = value;
			}
		}

		public Instruction End
		{
			get
			{
				return m_end;
			}
			set
			{
				m_end = value;
			}
		}

		public Scope Parent
		{
			get
			{
				return m_parent;
			}
			set
			{
				m_parent = value;
			}
		}

		public ScopeCollection Scopes
		{
			get
			{
				if (m_scopes == null)
				{
					m_scopes = new ScopeCollection(this);
				}
				return m_scopes;
			}
		}

		public VariableDefinitionCollection Variables
		{
			get
			{
				if (m_variables == null)
				{
					m_variables = new VariableDefinitionCollection(this);
				}
				return m_variables;
			}
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitScope(this);
		}
	}
}
