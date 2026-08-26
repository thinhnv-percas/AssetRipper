namespace DevX.Cecil.Cil
{
	public sealed class VariableDefinition : VariableReference
	{
		private MethodDefinition m_method;

		public MethodDefinition Method
		{
			get
			{
				return m_method;
			}
			set
			{
				m_method = value;
			}
		}

		public VariableDefinition(TypeReference variableType)
			: base(variableType)
		{
		}

		public VariableDefinition(string name, int index, MethodDefinition method, TypeReference variableType)
			: base(name, index, variableType)
		{
			m_method = method;
		}

		public override VariableDefinition Resolve()
		{
			return this;
		}

		public override void Accept(ICodeVisitor visitor)
		{
			visitor.VisitVariableDefinition(this);
		}
	}
}
