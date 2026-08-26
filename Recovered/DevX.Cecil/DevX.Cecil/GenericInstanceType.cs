using System.Text;

namespace DevX.Cecil
{
	public sealed class GenericInstanceType : TypeSpecification, IGenericInstance, IMetadataTokenProvider
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

		public override bool IsValueType
		{
			get
			{
				return m_isValueType;
			}
			set
			{
				m_isValueType = value;
			}
		}

		public override string FullName
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(base.FullName);
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
				return stringBuilder.ToString();
			}
		}

		public GenericInstanceType(TypeReference elementType)
			: base(elementType)
		{
			m_isValueType = elementType.IsValueType;
		}
	}
}
