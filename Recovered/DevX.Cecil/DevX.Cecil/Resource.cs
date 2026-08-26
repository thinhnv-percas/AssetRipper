using System.Collections;

namespace DevX.Cecil
{
	public abstract class Resource : IAnnotationProvider, IReflectionStructureVisitable
	{
		private string m_name;

		private ManifestResourceAttributes m_attributes;

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

		public ManifestResourceAttributes Flags
		{
			get
			{
				return m_attributes;
			}
			set
			{
				m_attributes = value;
			}
		}

		public bool IsPublic
		{
			get
			{
				return (m_attributes & ManifestResourceAttributes.VisibilityMask) == ManifestResourceAttributes.Public;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~ManifestResourceAttributes.VisibilityMask;
					m_attributes |= ManifestResourceAttributes.Public;
				}
				else
				{
					m_attributes &= ~ManifestResourceAttributes.Public;
				}
			}
		}

		public bool IsPrivate
		{
			get
			{
				return (m_attributes & ManifestResourceAttributes.VisibilityMask) == ManifestResourceAttributes.Private;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~ManifestResourceAttributes.VisibilityMask;
					m_attributes |= ManifestResourceAttributes.Private;
				}
				else
				{
					m_attributes &= ~ManifestResourceAttributes.Private;
				}
			}
		}

		internal Resource(string name, ManifestResourceAttributes attributes)
		{
			m_name = name;
			m_attributes = attributes;
		}

		public abstract void Accept(IReflectionStructureVisitor visitor);
	}
}
