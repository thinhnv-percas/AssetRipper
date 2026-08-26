namespace DevX.Cecil
{
	public class TypeReference : MemberReference, ICustomAttributeProvider, IGenericParameterProvider, IMetadataTokenProvider
	{
		private string m_namespace;

		private bool m_fullNameDiscarded;

		private string m_fullName;

		protected bool m_isValueType;

		private IMetadataScope m_scope;

		private ModuleDefinition m_module;

		private CustomAttributeCollection m_customAttrs;

		private GenericParameterCollection m_genparams;

		public override string Name
		{
			get
			{
				return base.Name;
			}
			set
			{
				base.Name = value;
				m_fullNameDiscarded = true;
			}
		}

		public virtual string Namespace
		{
			get
			{
				return m_namespace;
			}
			set
			{
				m_namespace = value;
				m_fullNameDiscarded = true;
			}
		}

		public virtual bool IsValueType
		{
			get
			{
				return m_isValueType;
			}
			set
			{
				m_isValueType = value;
			}
		}

		public virtual ModuleDefinition Module
		{
			get
			{
				return m_module;
			}
			set
			{
				m_module = value;
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

		public bool HasGenericParameters => m_genparams != null && m_genparams.Count > 0;

		public GenericParameterCollection GenericParameters
		{
			get
			{
				if (m_genparams == null)
				{
					m_genparams = new GenericParameterCollection(this);
				}
				return m_genparams;
			}
		}

		public virtual IMetadataScope Scope
		{
			get
			{
				if (DeclaringType != null)
				{
					return DeclaringType.Scope;
				}
				return m_scope;
			}
		}

		public bool IsNested => DeclaringType != null;

		public virtual string FullName
		{
			get
			{
				if (m_fullName != null && !m_fullNameDiscarded)
				{
					return m_fullName;
				}
				if (IsNested)
				{
					return DeclaringType.FullName + "/" + Name;
				}
				if (m_namespace == null || m_namespace.Length == 0)
				{
					return Name;
				}
				m_fullName = m_namespace + "." + Name;
				m_fullNameDiscarded = false;
				return m_fullName;
			}
		}

		protected TypeReference(string name, string ns)
			: base(name)
		{
			m_namespace = ns;
			m_fullNameDiscarded = false;
		}

		internal TypeReference(string name, string ns, IMetadataScope scope)
			: this(name, ns)
		{
			m_scope = scope;
		}

		public TypeReference(string name, string ns, IMetadataScope scope, bool valueType)
			: this(name, ns, scope)
		{
			m_isValueType = valueType;
		}

		public virtual TypeDefinition Resolve()
		{
			return Module?.Resolver.Resolve(this);
		}

		public virtual TypeReference GetOriginalType()
		{
			return this;
		}

		internal void AttachToScope(IMetadataScope scope)
		{
			m_scope = scope;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitTypeReference(this);
		}

		public override string ToString()
		{
			return FullName;
		}
	}
}
