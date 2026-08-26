namespace DevX.Cecil
{
	public class GenericContext
	{
		private TypeReference m_type;

		private MethodReference m_method;

		public TypeReference Type
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

		public MethodReference Method
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

		public bool AllowCreation => m_type != null && m_type.GetType() == typeof(TypeReference);

		public bool Null => m_type == null && m_method == null;

		public GenericContext()
		{
		}

		public GenericContext(TypeReference type, MethodReference meth)
		{
			m_type = type;
			m_method = meth;
		}

		public GenericContext(IGenericParameterProvider provider)
		{
			if (provider is TypeReference)
			{
				m_type = (provider as TypeReference);
			}
			else if (provider is MethodReference)
			{
				m_type = (m_method = (provider as MethodReference)).DeclaringType;
			}
		}

		internal void CheckProvider(IGenericParameterProvider provider, int count)
		{
			if (AllowCreation)
			{
				for (int i = provider.GenericParameters.Count; i < count; i++)
				{
					provider.GenericParameters.Add(new GenericParameter(i, provider));
				}
			}
		}

		public GenericContext Clone()
		{
			GenericContext genericContext = new GenericContext();
			genericContext.Type = m_type;
			genericContext.Method = m_method;
			return genericContext;
		}
	}
}
