using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public class DefaultUnresolvedTypeParameter : IUnresolvedTypeParameter, INamedElement, IFreezable
	{
		private readonly int index;

		private IList<IUnresolvedAttribute> attributes;

		private IList<ITypeReference> constraints;

		private string name;

		private DomRegion region;

		private SymbolKind ownerType;

		private VarianceModifier variance;

		private BitVector16 flags;

		private const ushort FlagFrozen = 1;

		private const ushort FlagReferenceTypeConstraint = 2;

		private const ushort FlagValueTypeConstraint = 4;

		private const ushort FlagDefaultConstructorConstraint = 8;

		public SymbolKind OwnerType => ownerType;

		public int Index => index;

		public bool IsFrozen => flags[1];

		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				name = value;
			}
		}

		string INamedElement.FullName => name;

		string INamedElement.Namespace => string.Empty;

		string INamedElement.ReflectionName
		{
			get
			{
				if (ownerType == SymbolKind.Method)
				{
					return "``" + index.ToString(CultureInfo.InvariantCulture);
				}
				return "`" + index.ToString(CultureInfo.InvariantCulture);
			}
		}

		public IList<IUnresolvedAttribute> Attributes
		{
			get
			{
				if (attributes == null)
				{
					attributes = new List<IUnresolvedAttribute>();
				}
				return attributes;
			}
		}

		public IList<ITypeReference> Constraints
		{
			get
			{
				if (constraints == null)
				{
					constraints = new List<ITypeReference>();
				}
				return constraints;
			}
		}

		public VarianceModifier Variance
		{
			get
			{
				return variance;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				variance = value;
			}
		}

		public DomRegion Region
		{
			get
			{
				return region;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				region = value;
			}
		}

		public bool HasDefaultConstructorConstraint
		{
			get
			{
				return flags[8];
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				flags[8] = value;
			}
		}

		public bool HasReferenceTypeConstraint
		{
			get
			{
				return flags[2];
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				flags[2] = value;
			}
		}

		public bool HasValueTypeConstraint
		{
			get
			{
				return flags[4];
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				flags[4] = value;
			}
		}

		public void Freeze()
		{
			if (!flags[1])
			{
				FreezeInternal();
				flags[1] = true;
			}
		}

		protected virtual void FreezeInternal()
		{
			attributes = FreezableHelper.FreezeListAndElements(attributes);
			constraints = FreezableHelper.FreezeList(constraints);
		}

		public DefaultUnresolvedTypeParameter(SymbolKind ownerType, int index, string name = null)
		{
			this.ownerType = ownerType;
			this.index = index;
			this.name = (name ?? (((ownerType == SymbolKind.Method) ? "!!" : "!") + index.ToString(CultureInfo.InvariantCulture)));
		}

		public virtual void ApplyInterningProvider(InterningProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			FreezableHelper.ThrowIfFrozen(this);
			name = provider.Intern(name);
			attributes = provider.InternList(attributes);
			constraints = provider.InternList(constraints);
		}

		public virtual ITypeParameter CreateResolvedTypeParameter(ITypeResolveContext context)
		{
			IEntity entity = null;
			if (OwnerType == SymbolKind.Method)
			{
				entity = (context.CurrentMember as IMethod);
			}
			else if (OwnerType == SymbolKind.TypeDefinition)
			{
				entity = context.CurrentTypeDefinition;
			}
			if (entity == null)
			{
				throw new InvalidOperationException("Could not determine the type parameter's owner.");
			}
			return new DefaultTypeParameter(entity, index, name, variance, Attributes.CreateResolvedAttributes(context), Region, HasValueTypeConstraint, HasReferenceTypeConstraint, HasDefaultConstructorConstraint, Constraints.Resolve(context));
		}
	}
}
