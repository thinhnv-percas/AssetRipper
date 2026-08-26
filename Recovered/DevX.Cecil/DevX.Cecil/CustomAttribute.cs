using System.Collections;

namespace DevX.Cecil
{
	public sealed class CustomAttribute : IAnnotationProvider, IReflectionVisitable, IRequireResolving
	{
		private MethodReference m_ctor;

		private IList m_parameters;

		private IDictionary m_fields;

		private IDictionary m_properties;

		private IDictionary m_fieldTypes;

		private IDictionary m_propTypes;

		private IDictionary m_annotations;

		private bool m_resolved;

		private byte[] m_blob;

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

		public MethodReference Constructor
		{
			get
			{
				return m_ctor;
			}
			set
			{
				m_ctor = value;
			}
		}

		public IList ConstructorParameters
		{
			get
			{
				if (m_parameters == null)
				{
					m_parameters = new ArrayList();
				}
				return m_parameters;
			}
		}

		public IDictionary Fields
		{
			get
			{
				if (m_fields == null)
				{
					m_fields = new Hashtable();
				}
				return m_fields;
			}
		}

		public IDictionary Properties
		{
			get
			{
				if (m_properties == null)
				{
					m_properties = new Hashtable();
				}
				return m_properties;
			}
		}

		internal IDictionary FieldTypes
		{
			get
			{
				if (m_fieldTypes == null)
				{
					m_fieldTypes = new Hashtable();
				}
				return m_fieldTypes;
			}
		}

		internal IDictionary PropertyTypes
		{
			get
			{
				if (m_propTypes == null)
				{
					m_propTypes = new Hashtable();
				}
				return m_propTypes;
			}
		}

		public bool Resolved
		{
			get
			{
				return m_resolved;
			}
			set
			{
				m_resolved = value;
			}
		}

		public byte[] Blob
		{
			get
			{
				return m_blob;
			}
			set
			{
				m_blob = value;
			}
		}

		public CustomAttribute(MethodReference ctor)
		{
			m_ctor = ctor;
			m_resolved = true;
		}

		public CustomAttribute(MethodReference ctor, byte[] blob)
		{
			m_ctor = ctor;
			m_blob = blob;
		}

		public TypeReference GetFieldType(string fieldName)
		{
			return (TypeReference)FieldTypes[fieldName];
		}

		public TypeReference GetPropertyType(string propertyName)
		{
			return (TypeReference)PropertyTypes[propertyName];
		}

		public void SetFieldType(string fieldName, TypeReference type)
		{
			FieldTypes[fieldName] = type;
		}

		public void SetPropertyType(string propertyName, TypeReference type)
		{
			PropertyTypes[propertyName] = type;
		}

		public CustomAttribute Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance));
		}

		private static void Clone(IDictionary original, IDictionary target)
		{
			target.Clear();
			foreach (DictionaryEntry item in original)
			{
				target.Add(item.Key, item.Value);
			}
		}

		internal static CustomAttribute Clone(CustomAttribute custattr, ImportContext context)
		{
			CustomAttribute customAttribute = new CustomAttribute(context.Import(custattr.Constructor));
			custattr.CopyTo(customAttribute);
			return customAttribute;
		}

		private void CopyTo(CustomAttribute target)
		{
			target.Resolved = Resolved;
			if (!Resolved)
			{
				target.Blob = Blob;
				return;
			}
			foreach (object constructorParameter in ConstructorParameters)
			{
				target.ConstructorParameters.Add(constructorParameter);
			}
			Clone(Fields, target.Fields);
			Clone(FieldTypes, target.FieldTypes);
			Clone(Properties, target.Properties);
			Clone(PropertyTypes, target.PropertyTypes);
		}

		public bool Resolve()
		{
			if (Resolved)
			{
				return true;
			}
			ReflectionReader reader = m_ctor.DeclaringType.Module.Controller.Reader;
			CustomAttribute customAttribute = reader.GetCustomAttribute(m_ctor, Blob, resolve: true);
			if (!customAttribute.Resolved)
			{
				return false;
			}
			customAttribute.CopyTo(this);
			return true;
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitCustomAttribute(this);
		}
	}
}
