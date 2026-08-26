using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public class DefaultUnresolvedProperty : AbstractUnresolvedMember, IUnresolvedProperty, IUnresolvedParameterizedMember, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
	{
		private IUnresolvedMethod getter;

		private IUnresolvedMethod setter;

		private IList<IUnresolvedParameter> parameters;

		public bool IsIndexer => base.SymbolKind == SymbolKind.Indexer;

		public IList<IUnresolvedParameter> Parameters
		{
			get
			{
				if (parameters == null)
				{
					parameters = new List<IUnresolvedParameter>();
				}
				return parameters;
			}
		}

		public bool CanGet => getter != null;

		public bool CanSet => setter != null;

		public IUnresolvedMethod Getter
		{
			get
			{
				return getter;
			}
			set
			{
				ThrowIfFrozen();
				getter = value;
			}
		}

		public IUnresolvedMethod Setter
		{
			get
			{
				return setter;
			}
			set
			{
				ThrowIfFrozen();
				setter = value;
			}
		}

		protected override void FreezeInternal()
		{
			parameters = FreezableHelper.FreezeListAndElements(parameters);
			FreezableHelper.Freeze(getter);
			FreezableHelper.Freeze(setter);
			base.FreezeInternal();
		}

		public override object Clone()
		{
			DefaultUnresolvedProperty defaultUnresolvedProperty = (DefaultUnresolvedProperty)base.Clone();
			if (parameters != null)
			{
				defaultUnresolvedProperty.parameters = new List<IUnresolvedParameter>(parameters);
			}
			return defaultUnresolvedProperty;
		}

		public override void ApplyInterningProvider(InterningProvider provider)
		{
			base.ApplyInterningProvider(provider);
			parameters = provider.InternList(parameters);
		}

		public DefaultUnresolvedProperty()
		{
			base.SymbolKind = SymbolKind.Property;
		}

		public DefaultUnresolvedProperty(IUnresolvedTypeDefinition declaringType, string name)
		{
			base.SymbolKind = SymbolKind.Property;
			base.DeclaringTypeDefinition = declaringType;
			base.Name = name;
			if (declaringType != null)
			{
				base.UnresolvedFile = declaringType.UnresolvedFile;
			}
		}

		public override IMember CreateResolved(ITypeResolveContext context)
		{
			return new DefaultResolvedProperty(this, context);
		}

		public override IMember Resolve(ITypeResolveContext context)
		{
			ITypeReference explicitInterfaceTypeReference = null;
			if (base.IsExplicitInterfaceImplementation && base.ExplicitInterfaceImplementations.Count == 1)
			{
				explicitInterfaceTypeReference = base.ExplicitInterfaceImplementations[0].DeclaringTypeReference;
			}
			return AbstractUnresolvedMember.Resolve(AbstractUnresolvedMember.ExtendContextForType(context, base.DeclaringTypeDefinition), base.SymbolKind, base.Name, explicitInterfaceTypeReference, null, (from p in Parameters
				select p.Type).ToList());
		}

		IProperty IUnresolvedProperty.Resolve(ITypeResolveContext context)
		{
			return (IProperty)Resolve(context);
		}
	}
}
