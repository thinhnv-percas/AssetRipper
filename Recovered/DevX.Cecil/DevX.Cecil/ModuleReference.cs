using DevX.Cecil.Metadata;
using System.Collections;

namespace DevX.Cecil
{
	public class ModuleReference : IAnnotationProvider, IMetadataScope, IMetadataTokenProvider, IReflectionStructureVisitable
	{
		private string m_name;

		private MetadataToken m_token;

		private IDictionary m_annotations;

		IDictionary IAnnotationProvider.Annotations
		{
			get
			{
				if (m_annotations == null)
				{
					m_annotations = new Hashtable();
				}
				return m_annotations;
			}
		}

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
			}
		}

		public MetadataToken MetadataToken
		{
			get
			{
				return m_token;
			}
			set
			{
				m_token = value;
			}
		}

		public ModuleReference(string name)
		{
			m_name = name;
		}

		public virtual void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitModuleReference(this);
		}
	}
}
