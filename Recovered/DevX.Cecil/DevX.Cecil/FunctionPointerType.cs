using System;
using System.Text;

namespace DevX.Cecil
{
	public sealed class FunctionPointerType : TypeSpecification, IMethodSignature
	{
		private MethodReference m_function;

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

		public override string Name
		{
			get
			{
				return m_function.Name;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override string Namespace
		{
			get
			{
				return string.Empty;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override IMetadataScope Scope => m_function.DeclaringType.Scope;

		public override string FullName
		{
			get
			{
				int sentinel = GetSentinel();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(m_function.Name);
				stringBuilder.Append(" ");
				stringBuilder.Append(m_function.ReturnType.ReturnType.FullName);
				stringBuilder.Append(" *(");
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

		public FunctionPointerType(bool hasThis, bool explicitThis, MethodCallingConvention callConv, MethodReturnType retType)
			: base(retType.ReturnType)
		{
			m_function = new MethodReference("method", hasThis, explicitThis, callConv);
			m_function.ReturnType = retType;
		}

		public int GetSentinel()
		{
			return m_function.GetSentinel();
		}
	}
}
