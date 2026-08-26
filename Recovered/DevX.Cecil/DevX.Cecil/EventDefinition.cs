namespace DevX.Cecil
{
	public sealed class EventDefinition : EventReference, IAnnotationProvider, ICustomAttributeProvider, IMemberDefinition, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		private EventAttributes m_attributes;

		private CustomAttributeCollection m_customAttrs;

		private MethodDefinition m_addMeth;

		private MethodDefinition m_invMeth;

		private MethodDefinition m_remMeth;

		public EventAttributes Attributes
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

		public MethodDefinition AddMethod
		{
			get
			{
				return m_addMeth;
			}
			set
			{
				m_addMeth = value;
			}
		}

		public MethodDefinition InvokeMethod
		{
			get
			{
				return m_invMeth;
			}
			set
			{
				m_invMeth = value;
			}
		}

		public MethodDefinition RemoveMethod
		{
			get
			{
				return m_remMeth;
			}
			set
			{
				m_remMeth = value;
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

		public bool IsSpecialName
		{
			get
			{
				return (m_attributes & EventAttributes.SpecialName) != (EventAttributes)0;
			}
			set
			{
				if (value)
				{
					m_attributes |= EventAttributes.SpecialName;
				}
				else
				{
					m_attributes &= ~EventAttributes.SpecialName;
				}
			}
		}

		public bool IsRuntimeSpecialName
		{
			get
			{
				return (m_attributes & EventAttributes.RTSpecialName) != (EventAttributes)0;
			}
			set
			{
				if (value)
				{
					m_attributes |= EventAttributes.RTSpecialName;
				}
				else
				{
					m_attributes &= ~EventAttributes.RTSpecialName;
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

		public EventDefinition(string name, TypeReference eventType, EventAttributes attrs)
			: base(name, eventType)
		{
			m_attributes = attrs;
		}

		public override EventDefinition Resolve()
		{
			return this;
		}

		public static MethodDefinition CreateAddMethod(EventDefinition evt)
		{
			return evt.AddMethod = new MethodDefinition("add_" + evt.Name, MethodAttributes.Compilercontrolled, evt.EventType);
		}

		public static MethodDefinition CreateRemoveMethod(EventDefinition evt)
		{
			return evt.RemoveMethod = new MethodDefinition("remove_" + evt.Name, MethodAttributes.Compilercontrolled, evt.EventType);
		}

		public static MethodDefinition CreateInvokeMethod(EventDefinition evt)
		{
			return evt.InvokeMethod = new MethodDefinition("raise_" + evt.Name, MethodAttributes.Compilercontrolled, evt.EventType);
		}

		public EventDefinition Clone()
		{
			return Clone(this, new ImportContext(NullReferenceImporter.Instance, DeclaringType));
		}

		internal static EventDefinition Clone(EventDefinition evt, ImportContext context)
		{
			EventDefinition eventDefinition = new EventDefinition(evt.Name, context.Import(evt.EventType), evt.Attributes);
			if (context.GenericContext.Type is TypeDefinition)
			{
				TypeDefinition typeDefinition = context.GenericContext.Type as TypeDefinition;
				if (evt.AddMethod != null)
				{
					eventDefinition.AddMethod = typeDefinition.Methods.GetMethod(evt.AddMethod.Name)[0];
				}
				if (evt.InvokeMethod != null)
				{
					eventDefinition.InvokeMethod = typeDefinition.Methods.GetMethod(evt.InvokeMethod.Name)[0];
				}
				if (evt.RemoveMethod != null)
				{
					eventDefinition.RemoveMethod = typeDefinition.Methods.GetMethod(evt.RemoveMethod.Name)[0];
				}
			}
			foreach (CustomAttribute customAttribute in evt.CustomAttributes)
			{
				eventDefinition.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
			}
			return eventDefinition;
		}

		public override void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitEventDefinition(this);
			CustomAttributes.Accept(visitor);
		}
	}
}
