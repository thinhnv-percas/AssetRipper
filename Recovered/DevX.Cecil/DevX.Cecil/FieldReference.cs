namespace DevX.Cecil
{
	public class FieldReference : MemberReference
	{
		private TypeReference m_fieldType;

		public TypeReference FieldType
		{
			get
			{
				return m_fieldType;
			}
			set
			{
				m_fieldType = value;
			}
		}

		internal FieldReference(string name, TypeReference fieldType)
			: base(name)
		{
			m_fieldType = fieldType;
		}

		public FieldReference(string name, TypeReference declaringType, TypeReference fieldType)
			: this(name, fieldType)
		{
			DeclaringType = declaringType;
		}

		public virtual FieldDefinition Resolve()
		{
			return DeclaringType?.Module.Resolver.Resolve(this);
		}

		public override string ToString()
		{
			return m_fieldType.FullName + " " + base.ToString();
		}
	}
}
