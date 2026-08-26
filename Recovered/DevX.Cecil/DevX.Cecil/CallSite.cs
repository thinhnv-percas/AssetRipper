using DevX.Cecil.Metadata;
using System.Collections;
using System.Text;

namespace DevX.Cecil
{
	public sealed class CallSite : IAnnotationProvider, IMetadataTokenProvider, IMethodSignature
	{
		private MethodReference m_function;

		IDictionary IAnnotationProvider.Annotations => ((IAnnotationProvider)m_function).Annotations;

		public bool HasThis
		{
			get
			{
				return m_function.HasThis;
			}
			set
			{
				m_function.HasThis = value;
			}
		}

		public bool ExplicitThis
		{
			get
			{
				return m_function.ExplicitThis;
			}
			set
			{
				m_function.ExplicitThis = value;
			}
		}

		public MethodCallingConvention CallingConvention
		{
			get
			{
				return m_function.CallingConvention;
			}
			set
			{
				m_function.CallingConvention = value;
			}
		}

		public bool HasParameters => m_function.HasParameters;

		public ParameterDefinitionCollection Parameters => m_function.Parameters;

		public MethodReturnType ReturnType
		{
			get
			{
				return m_function.ReturnType;
			}
			set
			{
				m_function.ReturnType = value;
			}
		}

		public MetadataToken MetadataToken
		{
			get
			{
				return m_function.MetadataToken;
			}
			set
			{
				m_function.MetadataToken = value;
			}
		}

		public CallSite(bool hasThis, bool explicitThis, MethodCallingConvention callConv, MethodReturnType retType)
		{
			m_function = new MethodReference(string.Empty, hasThis, explicitThis, callConv);
			m_function.ReturnType = retType;
		}

		public int GetSentinel()
		{
			return m_function.GetSentinel();
		}

		public override string ToString()
		{
			int sentinel = GetSentinel();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(m_function.ReturnType.ReturnType.FullName);
			stringBuilder.Append("(");
			if (m_function.HasParameters)
			{
				for (int i = 0; i < m_function.Parameters.Count; i++)
				{
					if (i > 0)
					{
						stringBuilder.Append(",");
					}
					if (i == sentinel)
					{
						stringBuilder.Append("...,");
					}
					stringBuilder.Append(m_function.Parameters[i].ParameterType.FullName);
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
}
