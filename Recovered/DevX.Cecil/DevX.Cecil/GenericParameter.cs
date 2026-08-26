using System;

namespace DevX.Cecil
{
	public sealed class GenericParameter : TypeReference
	{
		private int m_position;

		private string m_name;

		private GenericParameterAttributes m_attributes;

		private IGenericParameterProvider m_owner;

		private ConstraintCollection m_constraints;

		public int Position
		{
			get
			{
				return m_position;
			}
			set
			{
				m_position = value;
			}
		}

		public GenericParameterAttributes Attributes
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

		public IGenericParameterProvider Owner => m_owner;

		public bool HasConstraints => m_constraints != null && m_constraints.Count > 0;

		public ConstraintCollection Constraints
		{
			get
			{
				if (m_constraints == null)
				{
					m_constraints = new ConstraintCollection(this);
				}
				return m_constraints;
			}
		}

		public override IMetadataScope Scope
		{
			get
			{
				if (m_owner is TypeReference)
				{
					return ((TypeReference)m_owner).Scope;
				}
				if (m_owner is MethodReference)
				{
					return ((MethodReference)m_owner).DeclaringType.Scope;
				}
				throw new InvalidOperationException();
			}
		}

		public override string Name
		{
			get
			{
				if (m_name != null)
				{
					return m_name;
				}
				if (m_owner is TypeReference)
				{
					return "!" + m_position.ToString();
				}
				if (m_owner is MethodReference)
				{
					return "!!" + m_position.ToString();
				}
				throw new InvalidOperationException();
			}
			set
			{
				m_name = value;
			}
		}

		public override string Namespace
		{
			get
			{
				return string.Empty;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override string FullName => Name;

		public bool IsNonVariant
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.VarianceMask) == GenericParameterAttributes.NonVariant;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~GenericParameterAttributes.VarianceMask;
					m_attributes |= GenericParameterAttributes.NonVariant;
				}
				else
				{
					m_attributes &= (GenericParameterAttributes)65535;
				}
			}
		}

		public bool IsCovariant
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.VarianceMask) == GenericParameterAttributes.Covariant;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~GenericParameterAttributes.VarianceMask;
					m_attributes |= GenericParameterAttributes.Covariant;
				}
				else
				{
					m_attributes &= ~GenericParameterAttributes.Covariant;
				}
			}
		}

		public bool IsContravariant
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.VarianceMask) == GenericParameterAttributes.Contravariant;
			}
			set
			{
				if (value)
				{
					m_attributes &= ~GenericParameterAttributes.VarianceMask;
					m_attributes |= GenericParameterAttributes.Contravariant;
				}
				else
				{
					m_attributes &= ~GenericParameterAttributes.Contravariant;
				}
			}
		}

		public bool HasReferenceTypeConstraint
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.ReferenceTypeConstraint) != GenericParameterAttributes.NonVariant;
			}
			set
			{
				if (value)
				{
					m_attributes |= GenericParameterAttributes.ReferenceTypeConstraint;
				}
				else
				{
					m_attributes &= ~GenericParameterAttributes.ReferenceTypeConstraint;
				}
			}
		}

		public bool HasNotNullableValueTypeConstraint
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != GenericParameterAttributes.NonVariant;
			}
			set
			{
				if (value)
				{
					m_attributes |= GenericParameterAttributes.NotNullableValueTypeConstraint;
				}
				else
				{
					m_attributes &= ~GenericParameterAttributes.NotNullableValueTypeConstraint;
				}
			}
		}

		public bool HasDefaultConstructorConstraint
		{
			get
			{
				return (m_attributes & GenericParameterAttributes.DefaultConstructorConstraint) != GenericParameterAttributes.NonVariant;
			}
			set
			{
				if (value)
				{
					m_attributes |= GenericParameterAttributes.DefaultConstructorConstraint;
				}
				else
				{
					m_attributes &= ~GenericParameterAttributes.DefaultConstructorConstraint;
				}
			}
		}

		internal GenericParameter(int pos, IGenericParameterProvider owner)
			: base(string.Empty, string.Empty)
		{
			m_position = pos;
			m_owner = owner;
		}

		public GenericParameter(string name, IGenericParameterProvider owner)
			: base(string.Empty, string.Empty)
		{
			m_name = name;
			m_owner = owner;
		}

		public override TypeDefinition Resolve()
		{
			return null;
		}

		internal static void CloneInto(IGenericParameterProvider old, IGenericParameterProvider np, ImportContext context)
		{
			foreach (GenericParameter genericParameter2 in old.GenericParameters)
			{
				GenericParameter genericParameter = Clone(genericParameter2, context);
				np.GenericParameters.Add(genericParameter);
				CloneConstraints(genericParameter2, genericParameter, context);
			}
		}

		internal static GenericParameter Clone(GenericParameter gp, ImportContext context)
		{
			GenericParameter genericParameter;
			if (gp.Owner is TypeReference)
			{
				genericParameter = new GenericParameter(gp.m_name, context.GenericContext.Type);
			}
			else
			{
				if (!(gp.Owner is MethodReference))
				{
					throw new NotSupportedException();
				}
				genericParameter = new GenericParameter(gp.m_name, context.GenericContext.Method);
			}
			genericParameter.Position = gp.Owner.GenericParameters.IndexOf(gp);
			genericParameter.Attributes = gp.Attributes;
			if (gp.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in gp.CustomAttributes)
				{
					genericParameter.CustomAttributes.Add(CustomAttribute.Clone(customAttribute, context));
				}
				return genericParameter;
			}
			return genericParameter;
		}

		private static void CloneConstraints(GenericParameter gp, GenericParameter ngp, ImportContext context)
		{
			if (gp.HasConstraints)
			{
				foreach (TypeReference constraint in gp.Constraints)
				{
					ngp.Constraints.Add(context.Import(constraint));
				}
			}
		}
	}
}
