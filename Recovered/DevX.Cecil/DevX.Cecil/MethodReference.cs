using System.Text;

namespace DevX.Cecil
{
	public class MethodReference : MemberReference, IGenericParameterProvider, IMetadataTokenProvider, IMethodSignature
	{
		private ParameterDefinitionCollection m_parameters;

		private MethodReturnType m_returnType;

		private bool m_hasThis;

		private bool m_explicitThis;

		private MethodCallingConvention m_callConv;

		private GenericParameterCollection m_genparams;

		public virtual bool HasThis
		{
			get
			{
				return m_hasThis;
			}
			set
			{
				m_hasThis = value;
			}
		}

		public virtual bool ExplicitThis
		{
			get
			{
				return m_explicitThis;
			}
			set
			{
				m_explicitThis = value;
			}
		}

		public virtual MethodCallingConvention CallingConvention
		{
			get
			{
				return m_callConv;
			}
			set
			{
				m_callConv = value;
			}
		}

		public virtual bool HasParameters => m_parameters != null && m_parameters.Count > 0;

		public virtual ParameterDefinitionCollection Parameters
		{
			get
			{
				if (m_parameters == null)
				{
					m_parameters = new ParameterDefinitionCollection(this);
				}
				return m_parameters;
			}
		}

		public bool HasGenericParameters => m_genparams != null && m_genparams.Count > 0;

		public GenericParameterCollection GenericParameters
		{
			get
			{
				if (m_genparams == null)
				{
					m_genparams = new GenericParameterCollection(this);
				}
				return m_genparams;
			}
		}

		public virtual MethodReturnType ReturnType
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

		internal MethodReference(string name, bool hasThis, bool explicitThis, MethodCallingConvention callConv)
			: this(name)
		{
			m_parameters = new ParameterDefinitionCollection(this);
			m_hasThis = hasThis;
			m_explicitThis = explicitThis;
			m_callConv = callConv;
		}

		internal MethodReference(string name)
			: base(name)
		{
			m_returnType = new MethodReturnType(null);
		}

		public MethodReference(string name, TypeReference declaringType, TypeReference returnType, bool hasThis, bool explicitThis, MethodCallingConvention callConv)
			: this(name, hasThis, explicitThis, callConv)
		{
			DeclaringType = declaringType;
			ReturnType.ReturnType = returnType;
		}

		public virtual MethodDefinition Resolve()
		{
			return DeclaringType?.Module.Resolver.Resolve(this);
		}

		public virtual MethodReference GetOriginalMethod()
		{
			return this;
		}

		public int GetSentinel()
		{
			if (HasParameters)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					if (Parameters[i].ParameterType is SentinelType)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override string ToString()
		{
			int sentinel = GetSentinel();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(m_returnType.ReturnType.FullName);
			stringBuilder.Append(" ");
			stringBuilder.Append(base.ToString());
			stringBuilder.Append("(");
			if (HasParameters)
			{
				for (int i = 0; i < Parameters.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					if (i == sentinel)
					{
						stringBuilder.Append("...,");
					}
					stringBuilder.Append(Parameters[i].ParameterType.FullName);
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
}
