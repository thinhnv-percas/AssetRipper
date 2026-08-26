namespace DevX.Cecil
{
	public abstract class ModType : TypeSpecification
	{
		private TypeReference m_modifierType;

		public TypeReference ModifierType
		{
			get
			{
				return m_modifierType;
			}
			set
			{
				m_modifierType = value;
			}
		}

		public override string Name => base.Name + Suffix();

		public override string FullName => base.FullName + Suffix();

		protected abstract string ModifierName
		{
			get;
		}

		public ModType(TypeReference elemType, TypeReference modType)
			: base(elemType)
		{
			m_modifierType = modType;
		}

		private string Suffix()
		{
			return " " + ModifierName + "(" + ModifierType.FullName + ")";
		}
	}
}
