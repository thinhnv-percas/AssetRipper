namespace DevX.Cecil.Cil
{
	public abstract class VariableReference : ICodeVisitable
	{
		private string m_name;

		private int m_index;

		private TypeReference m_variableType;

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
			}
		}

		public int Index
		{
			get
			{
				return m_index;
			}
			set
			{
				m_index = value;
			}
		}

		public TypeReference VariableType
		{
			get
			{
				return m_variableType;
			}
			set
			{
				m_variableType = value;
			}
		}

		public VariableReference(TypeReference variableType)
		{
			m_variableType = variableType;
		}

		public VariableReference(string name, int index, TypeReference variableType)
			: this(variableType)
		{
			m_name = name;
			m_index = index;
		}

		public abstract VariableDefinition Resolve();

		public override string ToString()
		{
			if (m_name != null && m_name.Length > 0)
			{
				return m_name;
			}
			return "V_" + m_index;
		}

		public abstract void Accept(ICodeVisitor visitor);
	}
}
