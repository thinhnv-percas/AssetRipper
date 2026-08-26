namespace DevX.Cecil
{
	public class ImportContext
	{
		private GenericContext m_genContext;

		private IImporter m_importer;

		public GenericContext GenericContext
		{
			get
			{
				return m_genContext;
			}
			set
			{
				m_genContext = value;
			}
		}

		public ImportContext(IImporter importer)
		{
			m_genContext = new GenericContext();
			m_importer = importer;
		}

		public ImportContext(IImporter importer, IGenericParameterProvider provider)
		{
			m_importer = importer;
			m_genContext = new GenericContext(provider);
		}

		public TypeReference Import(TypeReference type)
		{
			return m_importer.ImportTypeReference(type, this);
		}

		public MethodReference Import(MethodReference meth)
		{
			return m_importer.ImportMethodReference(meth, this);
		}

		public FieldReference Import(FieldReference field)
		{
			return m_importer.ImportFieldReference(field, this);
		}
	}
}
