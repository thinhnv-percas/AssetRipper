using DevX.Cecil.Binary;

namespace DevX.Cecil
{
	public sealed class FieldDefinition : FieldReference, IAnnotationProvider, ICustomAttributeProvider, IHasConstant, IHasMarshalSpec, IMemberDefinition, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		private FieldAttributes m_attributes;

		private CustomAttributeCollection m_customAttrs;

		private bool m_hasInfo;

		private uint m_offset;

		private RVA m_rva;

		private byte[] m_initVal;

		private bool m_hasConstant;

		private object m_const;

		private MarshalSpec m_marshalDesc;

		public bool HasLayoutInfo => m_hasInfo;

		public uint Offset
		{
			get
			{
				return m_offset;
			}
			set
			{
				m_hasInfo = true;
				m_offset = value;
			}
		}

		public RVA RVA
		{
			get
			{
				return m_rva;
			}
			set
			{
				m_rva = value;
			}
		}

		public byte[] InitialValue
		{
			get
			{
				return m_initVal;
			}
			set
			{
				m_initVal = value;
			}
		}

		public FieldAttributes Attributes
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

		public MarshalSpec MarshalSpec
		{
			get
			{
				return m_marshalDesc;
			}
			set
			{
				m_marshalDesc = value;
				if (value != null)
				{
					m_attributes |= FieldAttributes.HasFieldMarshal;
				}
				else
				{
					m_attributes &= FieldAttributes.HasFieldMarshal;
				}
			}
		}

		public bool IsCompilerControlled
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.Compilercontrolled;
				}
				else
				{
					m_attributes &= (FieldAttributes)65535;
				}
			}
		}

		public bool IsPrivate
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Private;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.Private;
				}
				else
				{
					m_attributes &= ~FieldAttributes.Private;
				}
			}
		}

		public bool IsFamilyAndAssembly
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamANDAssem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.FamANDAssem;
				}
				else
				{
					m_attributes &= ~FieldAttributes.FamANDAssem;
				}
			}
		}

		public bool IsAssembly
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Assembly;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.Assembly;
				}
				else
				{
					m_attributes &= ~(FieldAttributes.Private | FieldAttributes.FamANDAssem);
				}
			}
		}

		public bool IsFamily
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Family;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.Family;
				}
				else
				{
					m_attributes &= ~FieldAttributes.Family;
				}
			}
		}

		public bool IsFamilyOrAssembly
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamORAssem;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.FamORAssem;
				}
				else
				{
					m_attributes &= ~(FieldAttributes.Private | FieldAttributes.Family);
				}
			}
		}

		public bool IsPublic
		{
			get
			{
				return (m_attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~FieldAttributes.FieldAccessMask;
					m_attributes |= FieldAttributes.Public;
				}
				else
				{
					m_attributes &= ~(FieldAttributes.FamANDAssem | FieldAttributes.Family);
				}
			}
		}

		public bool IsStatic
		{
			get
			{
				return (m_attributes & FieldAttributes.Static) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.Static;
				}
				else
				{
					m_attributes &= ~FieldAttributes.Static;
				}
			}
		}

		public bool IsInitOnly
		{
			get
			{
				return (m_attributes & FieldAttributes.InitOnly) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.InitOnly;
				}
				else
				{
					m_attributes &= ~FieldAttributes.InitOnly;
				}
			}
		}

		public bool IsLiteral
		{
			get
			{
				return (m_attributes & FieldAttributes.Literal) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.Literal;
				}
				else
				{
					m_attributes &= ~FieldAttributes.Literal;
				}
			}
		}

		public bool IsNotSerialized
		{
			get
			{
				return (m_attributes & FieldAttributes.NotSerialized) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.NotSerialized;
				}
				else
				{
					m_attributes &= ~FieldAttributes.NotSerialized;
				}
			}
		}

		public bool IsSpecialName
		{
			get
			{
				return (m_attributes & FieldAttributes.SpecialName) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.SpecialName;
				}
				else
				{
					m_attributes &= ~FieldAttributes.SpecialName;
				}
			}
		}

		public bool IsPInvokeImpl
		{
			get
			{
				return (m_attributes & FieldAttributes.PInvokeImpl) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.PInvokeImpl;
				}
				else
				{
					m_attributes &= ~FieldAttributes.PInvokeImpl;
				}
			}
		}

		public bool IsRuntimeSpecialName
		{
			get
			{
				return (m_attributes & FieldAttributes.RTSpecialName) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.RTSpecialName;
				}
				else
				{
					m_attributes &= ~FieldAttributes.RTSpecialName;
				}
			}
		}

		public bool HasDefault
		{
			get
			{
				return (m_attributes & FieldAttributes.HasDefault) != FieldAttributes.Compilercontrolled;
			}
			set
			{
				if (value)
				{
					m_attributes |= FieldAttributes.HasDefault;
				}
				else
				{
					m_attributes &= ~FieldAttributes.HasDefault;
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

		public FieldDefinition(string name, TypeReference fieldType, FieldAttributes attrs)
			: base(name, fieldType)
		{
			m_attributes = attrs;
		}

		public override FieldDefinition Resolve()
		{
			return this;
		}

		public FieldDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, DeclaringType));
		}

		internal static FieldDefinition Clone(FieldDefinition field, ImportContext context)
		{
			FieldDefinition fieldDefinition = new FieldDefinition(field.Name, context.Import(field.FieldType), field.Attributes);
			if (field.HasConstant)
			{
				fieldDefinition.Constant = field.Constant;
			}
			if (field.MarshalSpec != null)
			{
				fieldDefinition.MarshalSpec = field.MarshalSpec.CloneInto(fieldDefinition);
			}
			if (field.RVA != RVA.Zero)
			{
				fieldDefinition.InitialValue = field.InitialValue;
			}
			else
			{
				fieldDefinition.InitialValue = new byte[0];
			}
			if (field.HasLayoutInfo)
			{
				fieldDefinition.Offset = field.Offset;
			}
			foreach (CustomAttribute customAttribute in field.CustomAttributes)
			{
				fieldDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
			}
			return fieldDefinition;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitFieldDefinition(this);
			if (MarshalSpec != null)
			{
				MarshalSpec.Accept(visitor);
			}
			CustomAttributes.Accept(visitor);
		}
	}
}
