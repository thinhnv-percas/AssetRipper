using DevX.Cecil.Metadata;

namespace DevX.Cecil
{
	public sealed class MethodReturnType : ICustomAttributeProvider, IHasConstant, IHasMarshalSpec, IMetadataTokenProvider
	{
		private MethodReference m_method;

		private ParameterDefinition m_param;

		private TypeReference m_returnType;

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

		public TypeReference ReturnType
		{
			get
			{
				return m_returnType;
			}
			set
			{
				m_returnType = value;
			}
		}

		internal ParameterDefinition Parameter
		{
			get
			{
				if (m_param == null)
				{
					m_param = new ParameterDefinition(m_returnType);
					m_param.Method = m_method;
				}
				return m_param;
			}
			set
			{
				m_param = value;
			}
		}

		public MetadataToken MetadataToken
		{
			get
			{
				return Parameter.MetadataToken;
			}
			set
			{
				Parameter.MetadataToken = value;
			}
		}

		public bool HasCustomAttributes => Parameter.HasCustomAttributes;

		public CustomAttributeCollection CustomAttributes => Parameter.CustomAttributes;

		public bool HasConstant => Parameter.HasConstant;

		public object Constant
		{
			get
			{
				return Parameter.Constant;
			}
			set
			{
				Parameter.Constant = value;
			}
		}

		public MarshalSpec MarshalSpec
		{
			get
			{
				return Parameter.MarshalSpec;
			}
			set
			{
				Parameter.MarshalSpec = value;
			}
		}

		public MethodReturnType(TypeReference retType)
		{
			m_returnType = retType;
		}

		public override string ToString()
		{
			return $"[return: {m_returnType}]";
		}
	}
}
