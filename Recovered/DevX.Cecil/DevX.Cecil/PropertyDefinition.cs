using System.Text;

namespace DevX.Cecil
{
	public sealed class PropertyDefinition : PropertyReference, IAnnotationProvider, ICustomAttributeProvider, IHasConstant, IMemberDefinition, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		private PropertyAttributes m_attributes;

		private CustomAttributeCollection m_customAttrs;

		private MethodDefinition m_getMeth;

		private MethodDefinition m_setMeth;

		private bool m_hasConstant;

		private object m_const;

		public PropertyAttributes Attributes
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

		public bool HasCustomAttributes => m_customAttrs != null && m_customAttrs.Count > 0;

		public CustomAttributeCollection CustomAttributes
		{
			get
			{
				if (m_customAttrs == null)
				{
					m_customAttrs = new CustomAttributeCollection(this);
				}
				return m_customAttrs;
			}
		}

		public override bool HasParameters
		{
			get
			{
				if (m_getMeth != null)
				{
					return m_getMeth.HasParameters;
				}
				if (m_setMeth != null)
				{
					return m_setMeth.HasParameters;
				}
				if (m_parameters == null)
				{
					return false;
				}
				return m_parameters.Count > 0;
			}
		}

		public override ParameterDefinitionCollection Parameters
		{
			get
			{
				if (GetMethod != null)
				{
					return CloneParameterCollection(GetMethod.Parameters);
				}
				if (SetMethod != null)
				{
					ParameterDefinitionCollection parameterDefinitionCollection = CloneParameterCollection(SetMethod.Parameters);
					if (parameterDefinitionCollection.Count > 0)
					{
						parameterDefinitionCollection.RemoveAt(parameterDefinitionCollection.Count - 1);
					}
					return parameterDefinitionCollection;
				}
				if (m_parameters == null)
				{
					m_parameters = new ParameterDefinitionCollection(this);
				}
				return m_parameters;
			}
		}

		public MethodDefinition GetMethod
		{
			get
			{
				return m_getMeth;
			}
			set
			{
				m_getMeth = value;
			}
		}

		public MethodDefinition SetMethod
		{
			get
			{
				return m_setMeth;
			}
			set
			{
				m_setMeth = value;
			}
		}

		public bool HasConstant => m_hasConstant;

		public object Constant
		{
			get
			{
				return m_const;
			}
			set
			{
				m_hasConstant = true;
				m_const = value;
			}
		}

		public bool IsSpecialName
		{
			get
			{
				return (m_attributes & PropertyAttributes.SpecialName) != ~(PropertyAttributes.SpecialName | PropertyAttributes.RTSpecialName | PropertyAttributes.HasDefault | PropertyAttributes.Unused);
			}
			set
			{
				if (value)
				{
					m_attributes |= PropertyAttributes.SpecialName;
				}
				else
				{
					m_attributes &= ~PropertyAttributes.SpecialName;
				}
			}
		}

		public bool IsRuntimeSpecialName
		{
			get
			{
				return (m_attributes & PropertyAttributes.RTSpecialName) != ~(PropertyAttributes.SpecialName | PropertyAttributes.RTSpecialName | PropertyAttributes.HasDefault | PropertyAttributes.Unused);
			}
			set
			{
				if (value)
				{
					m_attributes |= PropertyAttributes.RTSpecialName;
				}
				else
				{
					m_attributes &= ~PropertyAttributes.RTSpecialName;
				}
			}
		}

		public bool HasDefault
		{
			get
			{
				return (m_attributes & PropertyAttributes.HasDefault) != ~(PropertyAttributes.SpecialName | PropertyAttributes.RTSpecialName | PropertyAttributes.HasDefault | PropertyAttributes.Unused);
			}
			set
			{
				if (value)
				{
					m_attributes |= PropertyAttributes.HasDefault;
				}
				else
				{
					m_attributes &= ~PropertyAttributes.HasDefault;
				}
			}
		}

		public new TypeDefinition DeclaringType
		{
			get
			{
				return (TypeDefinition)base.DeclaringType;
			}
			set
			{
				base.DeclaringType = value;
			}
		}

		public PropertyDefinition(string name, TypeReference propertyType, PropertyAttributes attrs)
			: base(name, propertyType)
		{
			m_attributes = attrs;
		}

		private ParameterDefinitionCollection CloneParameterCollection(ParameterDefinitionCollection original)
		{
			ParameterDefinitionCollection parameterDefinitionCollection = new ParameterDefinitionCollection(original.Container);
			foreach (ParameterDefinition item in original)
			{
				parameterDefinitionCollection.Add(item);
			}
			return parameterDefinitionCollection;
		}

		public override PropertyDefinition Resolve()
		{
			return this;
		}

		public static MethodDefinition CreateGetMethod(PropertyDefinition prop)
		{
			return prop.GetMethod = new MethodDefinition("get_" + prop.Name, MethodAttributes.Compilercontrolled, prop.PropertyType);
		}

		public static MethodDefinition CreateSetMethod(PropertyDefinition prop)
		{
			return prop.SetMethod = new MethodDefinition("set_" + prop.Name, MethodAttributes.Compilercontrolled, prop.PropertyType);
		}

		public PropertyDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, DeclaringType));
		}

		internal static PropertyDefinition Clone(PropertyDefinition prop, ImportContext context)
		{
			PropertyDefinition propertyDefinition = new PropertyDefinition(prop.Name, context.Import(prop.PropertyType), prop.Attributes);
			if (prop.HasConstant)
			{
				propertyDefinition.Constant = prop.Constant;
			}
			if (context.GenericContext.Type is TypeDefinition)
			{
				TypeDefinition typeDefinition = context.GenericContext.Type as TypeDefinition;
				if (prop.SetMethod != null)
				{
					propertyDefinition.SetMethod = typeDefinition.Methods.GetMethod(prop.SetMethod.Name, prop.SetMethod.Parameters);
				}
				if (prop.GetMethod != null)
				{
					propertyDefinition.GetMethod = typeDefinition.Methods.GetMethod(prop.GetMethod.Name, prop.GetMethod.Parameters);
				}
			}
			foreach (CustomAttribute customAttribute in prop.CustomAttributes)
			{
				propertyDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
			}
			return propertyDefinition;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.PropertyType.ToString());
			stringBuilder.Append(' ');
			if (DeclaringType != null)
			{
				stringBuilder.Append(DeclaringType.ToString());
				stringBuilder.Append("::");
			}
			stringBuilder.Append(Name);
			stringBuilder.Append('(');
			ParameterDefinitionCollection parameters = Parameters;
			for (int i = 0; i < parameters.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append(parameters[i].ParameterType.ToString());
			}
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitPropertyDefinition(this);
			CustomAttributes.Accept(visitor);
		}
	}
}
