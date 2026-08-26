using DevX.Cecil.Metadata;
using System.Collections;

namespace DevX.Cecil
{
	public abstract class ParameterReference : IAnnotationProvider, IMetadataTokenProvider, IReflectionVisitable
	{
		private string m_name;

		private int m_sequence;

		private TypeReference m_paramType;

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

		public int Sequence
		{
			get
			{
				return m_sequence;
			}
			set
			{
				m_sequence = value;
			}
		}

		public TypeReference ParameterType
		{
			get
			{
				return m_paramType;
			}
			set
			{
				m_paramType = value;
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

		public ParameterReference(string name, int sequence, TypeReference parameterType)
		{
			m_name = name;
			m_sequence = sequence;
			m_paramType = parameterType;
		}

		public abstract ParameterDefinition Resolve();

		public override string ToString()
		{
			if (m_name != null && m_name.Length > 0)
			{
				return m_name;
			}
			return "A_" + m_sequence;
		}

		public abstract void Accept(IReflectionVisitor visitor);
	}
}
