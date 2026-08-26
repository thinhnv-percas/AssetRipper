namespace DevX.Cecil
{
	public sealed class TypeDefinition : TypeReference, IAnnotationProvider, ICustomAttributeProvider, IHasSecurity, IMemberDefinition, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		private TypeAttributes m_attributes;

		private TypeReference m_baseType;

		private bool m_hasInfo;

		private ushort m_packingSize;

		private uint m_classSize;

		private InterfaceCollection m_interfaces;

		private NestedTypeCollection m_nestedTypes;

		private MethodDefinitionCollection m_methods;

		private ConstructorCollection m_ctors;

		private FieldDefinitionCollection m_fields;

		private EventDefinitionCollection m_events;

		private PropertyDefinitionCollection m_properties;

		private SecurityDeclarationCollection m_secDecls;

		public TypeAttributes Attributes
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

		public TypeReference BaseType
		{
			get
			{
				return m_baseType;
			}
			set
			{
				m_baseType = value;
			}
		}

		public bool HasLayoutInfo => m_hasInfo;

		public ushort PackingSize
		{
			get
			{
				return m_packingSize;
			}
			set
			{
				m_hasInfo = true;
				m_packingSize = value;
			}
		}

		public uint ClassSize
		{
			get
			{
				return m_classSize;
			}
			set
			{
				m_hasInfo = true;
				m_classSize = value;
			}
		}

		public bool HasInterfaces => m_interfaces != null && m_interfaces.Count > 0;

		public InterfaceCollection Interfaces
		{
			get
			{
				if (m_interfaces == null)
				{
					m_interfaces = new InterfaceCollection(this);
				}
				return m_interfaces;
			}
		}

		public bool HasNestedTypes => m_nestedTypes != null && m_nestedTypes.Count > 0;

		public NestedTypeCollection NestedTypes
		{
			get
			{
				if (m_nestedTypes == null)
				{
					m_nestedTypes = new NestedTypeCollection(this);
				}
				return m_nestedTypes;
			}
		}

		public bool HasMethods => m_methods != null && m_methods.Count > 0;

		public MethodDefinitionCollection Methods
		{
			get
			{
				if (m_methods == null)
				{
					m_methods = new MethodDefinitionCollection(this);
				}
				return m_methods;
			}
		}

		public bool HasConstructors => m_ctors != null && m_ctors.Count > 0;

		public ConstructorCollection Constructors
		{
			get
			{
				if (m_ctors == null)
				{
					m_ctors = new ConstructorCollection(this);
				}
				return m_ctors;
			}
		}

		public bool HasFields => m_fields != null && m_fields.Count > 0;

		public FieldDefinitionCollection Fields
		{
			get
			{
				if (m_fields == null)
				{
					m_fields = new FieldDefinitionCollection(this);
				}
				return m_fields;
			}
		}

		public bool HasEvents => m_events != null && m_events.Count > 0;

		public EventDefinitionCollection Events
		{
			get
			{
				if (m_events == null)
				{
					m_events = new EventDefinitionCollection(this);
				}
				return m_events;
			}
		}

		public bool HasProperties => m_properties != null && m_properties.Count > 0;

		public PropertyDefinitionCollection Properties
		{
			get
			{
				if (m_properties == null)
				{
					m_properties = new PropertyDefinitionCollection(this);
				}
				return m_properties;
			}
		}

		public bool HasSecurityDeclarations => m_secDecls != null && m_secDecls.Count > 0;

		public SecurityDeclarationCollection SecurityDeclarations
		{
			get
			{
				if (m_secDecls == null)
				{
					m_secDecls = new SecurityDeclarationCollection(this);
				}
				return m_secDecls;
			}
		}

		public bool IsNotPublic
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NotPublic;
				}
				else
				{
					m_attributes &= (TypeAttributes)4294967295u;
				}
			}
		}

		public bool IsPublic
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.Public;
				}
				else
				{
					m_attributes &= ~TypeAttributes.Public;
				}
			}
		}

		public bool IsNestedPublic
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPublic;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NestedPublic;
				}
				else
				{
					m_attributes &= ~TypeAttributes.NestedPublic;
				}
			}
		}

		public bool IsNestedPrivate
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedPrivate;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NestedPrivate;
				}
				else
				{
					m_attributes &= ~(TypeAttributes.Public | TypeAttributes.NestedPublic);
				}
			}
		}

		public bool IsNestedFamily
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamily;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NestedFamily;
				}
				else
				{
					m_attributes &= ~TypeAttributes.NestedFamily;
				}
			}
		}

		public bool IsNestedAssembly
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedAssembly;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NestedAssembly;
				}
				else
				{
					m_attributes &= ~(TypeAttributes.Public | TypeAttributes.NestedFamily);
				}
			}
		}

		public bool IsNestedFamilyAndAssembly
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.NestedFamANDAssem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.NestedFamANDAssem;
				}
				else
				{
					m_attributes &= ~(TypeAttributes.NestedPublic | TypeAttributes.NestedFamily);
				}
			}
		}

		public bool IsNestedFamilyOrAssembly
		{
			get
			{
				return (m_attributes & TypeAttributes.VisibilityMask) == TypeAttributes.VisibilityMask;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
					m_attributes |= TypeAttributes.VisibilityMask;
				}
				else
				{
					m_attributes &= ~TypeAttributes.VisibilityMask;
				}
			}
		}

		public bool IsAutoLayout
		{
			get
			{
				return (m_attributes & TypeAttributes.LayoutMask) == TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.LayoutMask;
					m_attributes |= TypeAttributes.NotPublic;
				}
				else
				{
					m_attributes &= (TypeAttributes)4294967295u;
				}
			}
		}

		public bool IsSequentialLayout
		{
			get
			{
				return (m_attributes & TypeAttributes.LayoutMask) == TypeAttributes.SequentialLayout;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.LayoutMask;
					m_attributes |= TypeAttributes.SequentialLayout;
				}
				else
				{
					m_attributes &= ~TypeAttributes.SequentialLayout;
				}
			}
		}

		public bool IsExplicitLayout
		{
			get
			{
				return (m_attributes & TypeAttributes.LayoutMask) == TypeAttributes.ExplicitLayout;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.LayoutMask;
					m_attributes |= TypeAttributes.ExplicitLayout;
				}
				else
				{
					m_attributes &= ~TypeAttributes.ExplicitLayout;
				}
			}
		}

		public bool IsClass
		{
			get
			{
				return (m_attributes & TypeAttributes.ClassSemanticMask) == TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.ClassSemanticMask;
					m_attributes |= TypeAttributes.NotPublic;
				}
				else
				{
					m_attributes &= (TypeAttributes)4294967295u;
				}
			}
		}

		public bool IsInterface
		{
			get
			{
				return (m_attributes & TypeAttributes.ClassSemanticMask) == TypeAttributes.ClassSemanticMask;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.ClassSemanticMask;
					m_attributes |= TypeAttributes.ClassSemanticMask;
				}
				else
				{
					m_attributes &= ~TypeAttributes.ClassSemanticMask;
				}
			}
		}

		public bool IsAbstract
		{
			get
			{
				return (m_attributes & TypeAttributes.Abstract) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.Abstract;
				}
				else
				{
					m_attributes &= ~TypeAttributes.Abstract;
				}
			}
		}

		public bool IsSealed
		{
			get
			{
				return (m_attributes & TypeAttributes.Sealed) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.Sealed;
				}
				else
				{
					m_attributes &= ~TypeAttributes.Sealed;
				}
			}
		}

		public bool IsSpecialName
		{
			get
			{
				return (m_attributes & TypeAttributes.SpecialName) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.SpecialName;
				}
				else
				{
					m_attributes &= ~TypeAttributes.SpecialName;
				}
			}
		}

		public bool IsImport
		{
			get
			{
				return (m_attributes & TypeAttributes.Import) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.Import;
				}
				else
				{
					m_attributes &= ~TypeAttributes.Import;
				}
			}
		}

		public bool IsSerializable
		{
			get
			{
				return (m_attributes & TypeAttributes.Serializable) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.Serializable;
				}
				else
				{
					m_attributes &= ~TypeAttributes.Serializable;
				}
			}
		}

		public bool IsAnsiClass
		{
			get
			{
				return (m_attributes & TypeAttributes.StringFormatMask) == TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.StringFormatMask;
					m_attributes |= TypeAttributes.NotPublic;
				}
				else
				{
					m_attributes &= (TypeAttributes)4294967295u;
				}
			}
		}

		public bool IsUnicodeClass
		{
			get
			{
				return (m_attributes & TypeAttributes.StringFormatMask) == TypeAttributes.UnicodeClass;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.StringFormatMask;
					m_attributes |= TypeAttributes.UnicodeClass;
				}
				else
				{
					m_attributes &= ~TypeAttributes.UnicodeClass;
				}
			}
		}

		public bool IsAutoClass
		{
			get
			{
				return (m_attributes & TypeAttributes.StringFormatMask) == TypeAttributes.AutoClass;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~TypeAttributes.StringFormatMask;
					m_attributes |= TypeAttributes.AutoClass;
				}
				else
				{
					m_attributes &= ~TypeAttributes.AutoClass;
				}
			}
		}

		public bool IsBeforeFieldInit
		{
			get
			{
				return (m_attributes & TypeAttributes.BeforeFieldInit) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.BeforeFieldInit;
				}
				else
				{
					m_attributes &= ~TypeAttributes.BeforeFieldInit;
				}
			}
		}

		public bool IsRuntimeSpecialName
		{
			get
			{
				return (m_attributes & TypeAttributes.RTSpecialName) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.RTSpecialName;
				}
				else
				{
					m_attributes &= ~TypeAttributes.RTSpecialName;
				}
			}
		}

		public bool HasSecurity
		{
			get
			{
				return (m_attributes & TypeAttributes.HasSecurity) != TypeAttributes.NotPublic;
			}
			set
			{
				if (value)
				{
					m_attributes |= TypeAttributes.HasSecurity;
				}
				else
				{
					m_attributes &= ~TypeAttributes.HasSecurity;
				}
			}
		}

		public bool IsEnum => m_baseType != null && m_baseType.FullName == "System.Enum";

		public override bool IsValueType => m_baseType != null && (m_baseType.FullName == "System.Enum" || (m_baseType.FullName == "System.ValueType" && FullName != "System.Enum"));

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

		internal TypeDefinition(string name, string ns, TypeAttributes attrs)
			: base(name, ns)
		{
			m_hasInfo = false;
			m_attributes = attrs;
		}

		public TypeDefinition(string name, string ns, TypeAttributes attributes, TypeReference baseType)
			: this(name, ns, attributes)
		{
			BaseType = baseType;
		}

		public override TypeDefinition Resolve()
		{
			return this;
		}

		public TypeDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, this));
		}

		internal static TypeDefinition Clone(TypeDefinition type, ImportContext context)
		{
			TypeDefinition typeDefinition = new TypeDefinition(type.Name, type.Namespace, type.Attributes);
			TypeReference type2 = context.GenericContext.Type;
			context.GenericContext.Type = typeDefinition;
			GenericParameter.CloneInto(type, typeDefinition, context);
			if (type.BaseType != null)
			{
				typeDefinition.BaseType = context.Import(type.BaseType);
			}
			if (type.HasLayoutInfo)
			{
				typeDefinition.ClassSize = type.ClassSize;
				typeDefinition.PackingSize = type.PackingSize;
			}
			if (type.HasFields)
			{
				foreach (FieldDefinition field in type.Fields)
				{
					typeDefinition.Fields.Add(FieldDefinition.Clone(field, context));
				}
			}
			if (type.HasConstructors)
			{
				foreach (MethodDefinition constructor in type.Constructors)
				{
					typeDefinition.Constructors.Add(MethodDefinition.Clone(constructor, context));
				}
			}
			if (type.HasMethods)
			{
				foreach (MethodDefinition method in type.Methods)
				{
					typeDefinition.Methods.Add(MethodDefinition.Clone(method, context));
				}
			}
			if (type.HasEvents)
			{
				foreach (EventDefinition @event in type.Events)
				{
					typeDefinition.Events.Add(EventDefinition.Clone(@event, context));
				}
			}
			if (type.HasProperties)
			{
				foreach (PropertyDefinition property in type.Properties)
				{
					typeDefinition.Properties.Add(PropertyDefinition.Clone(property, context));
				}
			}
			if (type.HasInterfaces)
			{
				foreach (TypeReference @interface in type.Interfaces)
				{
					typeDefinition.Interfaces.Add(context.Import(@interface));
				}
			}
			if (type.HasNestedTypes)
			{
				foreach (TypeDefinition nestedType in type.NestedTypes)
				{
					typeDefinition.NestedTypes.Add(Clone(nestedType, context));
				}
			}
			if (type.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in type.CustomAttributes)
				{
					typeDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
				}
			}
			if (type.HasSecurityDeclarations)
			{
				foreach (SecurityDeclaration securityDeclaration in type.SecurityDeclarations)
				{
					typeDefinition.SecurityDeclarations.Add(SecurityDeclaration.Clone(securityDeclaration));
				}
			}
			context.GenericContext.Type = type2;
			return typeDefinition;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitTypeDefinition(this);
			GenericParameters.Accept(visitor);
			Interfaces.Accept(visitor);
			Constructors.Accept(visitor);
			Methods.Accept(visitor);
			Fields.Accept(visitor);
			Properties.Accept(visitor);
			Events.Accept(visitor);
			NestedTypes.Accept(visitor);
			CustomAttributes.Accept(visitor);
			SecurityDeclarations.Accept(visitor);
		}
	}
}
