namespace DevX.Cecil
{
	internal sealed class ReflectionController
	{
		private ReflectionReader m_reader;

		private ReflectionWriter m_writer;

		private ReflectionHelper m_helper;

		private DefaultImporter m_importer;

		public ReflectionReader Reader => m_reader;

		public ReflectionWriter Writer => m_writer;

		public ReflectionHelper Helper => m_helper;

		public IImporter Importer => m_importer;

		public ReflectionController(ModuleDefinition module)
		{
			m_reader = new AggressiveReflectionReader(module);
			m_writer = new ReflectionWriter(module);
			m_helper = new ReflectionHelper(module);
			m_importer = new DefaultImporter(module);
		}
	}
}
