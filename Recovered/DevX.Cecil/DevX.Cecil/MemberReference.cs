using DevX.Cecil.Metadata;
using System.Collections;

namespace DevX.Cecil
{
	public abstract class MemberReference : IAnnotationProvider, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		private string m_name;

		private TypeReference m_decType;

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

		public virtual string Name
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

		public virtual TypeReference DeclaringType
		{
			get
			{
				return m_decType;
			}
			set
			{
				m_decType = value;
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

		public MemberReference(string name)
		{
			m_name = name;
		}

		public override string ToString()
		{
			if (m_decType == null)
			{
				return m_name;
			}
			return m_decType.FullName + "::" + m_name;
		}

		public virtual void Accept(IReflectionVisitor visitor)
		{
		}
	}
}
