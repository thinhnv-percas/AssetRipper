using System.Collections;

namespace DevX.Cecil
{
	public class DefaultAssemblyResolver : BaseAssemblyResolver
	{
		private IDictionary m_cache;

		public DefaultAssemblyResolver()
		{
			m_cache = new Hashtable();
		}

		public override AssemblyDefinition Resolve(AssemblyNameReference name)
		{
			AssemblyDefinition assemblyDefinition = (AssemblyDefinition)m_cache[name.FullName];
			if (assemblyDefinition == null)
			{
				assemblyDefinition = base.Resolve(name);
				m_cache[name.FullName] = assemblyDefinition;
			}
			return assemblyDefinition;
		}

		protected void RegisterAssembly(AssemblyDefinition assembly)
		{
			string fullName = assembly.Name.FullName;
			if (!m_cache.Contains(fullName))
			{
				m_cache[fullName] = assembly;
			}
		}
	}
}
