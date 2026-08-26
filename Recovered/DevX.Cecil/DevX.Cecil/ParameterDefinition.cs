namespace DevX.Cecil
{
	public sealed class ParameterDefinition : ParameterReference, ICustomAttributeProvider, IHasConstant, IHasMarshalSpec, IMetadataTokenProvider
	{
		private ParameterAttributes m_attributes;

		private bool m_hasConstant;

		private object m_const;

		private MethodReference m_method;

		private CustomAttributeCollection m_customAttrs;

		private MarshalSpec m_marshalDesc;

		public ParameterAttributes Attributes
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

		public MethodReference Method
		{
			get
			{
				return m_method;
			}
			set
			{
				m_method = value;
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
					m_attributes |= ParameterAttributes.HasFieldMarshal;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.HasFieldMarshal;
				}
			}
		}

		public bool IsIn
		{
			get
			{
				return (m_attributes & ParameterAttributes.In) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.In;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.In;
				}
			}
		}

		public bool IsOut
		{
			get
			{
				return (m_attributes & ParameterAttributes.Out) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.Out;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.Out;
				}
			}
		}

		public bool IsRetval
		{
			get
			{
				return (m_attributes & ParameterAttributes.Retval) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.Retval;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.Retval;
				}
			}
		}

		public bool IsLcid
		{
			get
			{
				return (m_attributes & ParameterAttributes.Lcid) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.Lcid;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.Lcid;
				}
			}
		}

		public bool IsOptional
		{
			get
			{
				return (m_attributes & ParameterAttributes.Optional) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.Optional;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.Optional;
				}
			}
		}

		public bool HasDefault
		{
			get
			{
				return (m_attributes & ParameterAttributes.HasDefault) != ParameterAttributes.None;
			}
			set
			{
				if (value)
				{
					m_attributes |= ParameterAttributes.HasDefault;
				}
				else
				{
					m_attributes &= ~ParameterAttributes.HasDefault;
				}
			}
		}

		public ParameterDefinition(TypeReference paramType)
			: this(string.Empty, -1, ParameterAttributes.None, paramType)
		{
		}

		public ParameterDefinition(string name, int seq, ParameterAttributes attrs, TypeReference paramType)
			: base(name, seq, paramType)
		{
			m_attributes = attrs;
		}

		public override ParameterDefinition Resolve()
		{
			return this;
		}

		public ParameterDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, m_method));
		}

		internal static ParameterDefinition Clone(ParameterDefinition param, ImportContext context)
		{
			ParameterDefinition parameterDefinition = new ParameterDefinition(param.Name, param.Sequence, param.Attributes, context.Import(param.ParameterType));
			if (param.HasConstant)
			{
				parameterDefinition.Constant = param.Constant;
			}
			if (param.MarshalSpec != null)
			{
				parameterDefinition.MarshalSpec = param.MarshalSpec.CloneInto(parameterDefinition);
			}
			foreach (CustomAttribute customAttribute in param.CustomAttributes)
			{
				parameterDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
			}
			return parameterDefinition;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitParameterDefinition(this);
			if (MarshalSpec != null)
			{
				MarshalSpec.Accept(visitor);
			}
			CustomAttributes.Accept(visitor);
		}
	}
}
