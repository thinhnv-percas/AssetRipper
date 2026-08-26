using System;

namespace DevX.Cecil
{
	public abstract class MethodSpecification : MethodReference
	{
		private MethodReference m_elementMethod;

		public MethodReference ElementMethod
		{
			get
			{
				return m_elementMethod;
			}
			set
			{
				m_elementMethod = value;
			}
		}

		public override string Name
		{
			get
			{
				return m_elementMethod.Name;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override MethodCallingConvention CallingConvention
		{
			get
			{
				return m_elementMethod.CallingConvention;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override bool HasThis
		{
			get
			{
				return m_elementMethod.HasThis;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override bool ExplicitThis
		{
			get
			{
				return m_elementMethod.ExplicitThis;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override MethodReturnType ReturnType
		{
			get
			{
				return m_elementMethod.ReturnType;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override TypeReference DeclaringType
		{
			get
			{
				return m_elementMethod.DeclaringType;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override bool HasParameters => m_elementMethod.HasParameters;

		public override ParameterDefinitionCollection Parameters => m_elementMethod.Parameters;

		internal MethodSpecification(MethodReference elemMethod)
			: base(string.Empty)
		{
			m_elementMethod = elemMethod;
		}

		public override MethodReference GetOriginalMethod()
		{
			return m_elementMethod.GetOriginalMethod();
		}
	}
}
