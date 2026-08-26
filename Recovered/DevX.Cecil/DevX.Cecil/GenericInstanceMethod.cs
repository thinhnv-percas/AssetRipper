using System.Text;

namespace DevX.Cecil
{
	public sealed class GenericInstanceMethod : MethodSpecification, IGenericInstance, IMetadataTokenProvider
	{
		private GenericArgumentCollection m_genArgs;

		public GenericArgumentCollection GenericArguments
		{
			get
			{
				if (m_genArgs == null)
				{
					m_genArgs = new GenericArgumentCollection(this);
				}
				return m_genArgs;
			}
		}

		public bool HasGenericArguments => m_genArgs != null && m_genArgs.Count > 0;

		public GenericInstanceMethod(MethodReference elemMethod)
			: base(elemMethod)
		{
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			MethodReference elementMethod = base.ElementMethod;
			stringBuilder.Append(elementMethod.ReturnType.ReturnType.FullName);
			stringBuilder.Append(" ");
			stringBuilder.Append(elementMethod.DeclaringType.FullName);
			stringBuilder.Append("::");
			stringBuilder.Append(elementMethod.Name);
			stringBuilder.Append("<");
			for (int i = 0; i < GenericArguments.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(GenericArguments[i].FullName);
			}
			stringBuilder.Append(">");
			stringBuilder.Append("(");
			if (elementMethod.HasParameters)
			{
				for (int j = 0; j < elementMethod.Parameters.Count; j++)
				{
					stringBuilder.Append(elementMethod.Parameters[j].ParameterType.FullName);
					if (j < elementMethod.Parameters.Count - 1)
					{
						stringBuilder.Append(",");
					}
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}
}
