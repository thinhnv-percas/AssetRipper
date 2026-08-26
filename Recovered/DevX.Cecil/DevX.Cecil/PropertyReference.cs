namespace DevX.Cecil
{
	public abstract class PropertyReference : MemberReference
	{
		private TypeReference m_propertyType;

		protected ParameterDefinitionCollection m_parameters;

		public TypeReference PropertyType
		{
			get
			{
				return m_propertyType;
			}
			set
			{
				m_propertyType = value;
			}
		}

		public abstract bool HasParameters
		{
			get;
		}

		public abstract ParameterDefinitionCollection Parameters
		{
			get;
		}

		public PropertyReference(string name, TypeReference propertyType)
			: base(name)
		{
			m_propertyType = propertyType;
		}

		public abstract PropertyDefinition Resolve();
	}
}
