using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultResolvedProperty : AbstractResolvedMember, IProperty, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		protected new readonly IUnresolvedProperty unresolved;

		private readonly IList<IParameter> parameters;

		private IMethod getter;

		private IMethod setter;

		private const Accessibility InvalidAccessibility = (Accessibility)255;

		private volatile Accessibility cachedAccessiblity = (Accessibility)255;

		public IList<IParameter> Parameters => parameters;

		public override Accessibility Accessibility
		{
			get
			{
				Accessibility accessibility = cachedAccessiblity;
				if (accessibility == (Accessibility)255)
				{
					return cachedAccessiblity = ComputeAccessibility();
				}
				return accessibility;
			}
		}

		public bool CanGet => unresolved.CanGet;

		public bool CanSet => unresolved.CanSet;

		public IMethod Getter => GetAccessor(ref getter, unresolved.Getter);

		public IMethod Setter => GetAccessor(ref setter, unresolved.Setter);

		public bool IsIndexer => unresolved.IsIndexer;

		public DefaultResolvedProperty(IUnresolvedProperty unresolved, ITypeResolveContext parentContext)
			: base(unresolved, parentContext)
		{
			this.unresolved = unresolved;
			parameters = unresolved.Parameters.CreateResolvedParameters(context);
		}

		private Accessibility ComputeAccessibility()
		{
			Accessibility accessibility = base.Accessibility;
			if (base.IsOverride && (!CanGet || !CanSet))
			{
				foreach (IMember baseMember in InheritanceHelper.GetBaseMembers(this, includeImplementedInterfaces: false))
				{
					if (!baseMember.IsOverride)
					{
						return baseMember.Accessibility;
					}
				}
				return accessibility;
			}
			return accessibility;
		}

		public override ISymbolReference ToReference()
		{
			IType declaringType = DeclaringType;
			object typeReference;
			if (declaringType == null)
			{
				ITypeReference unknownType = SpecialType.UnknownType;
				typeReference = unknownType;
			}
			else
			{
				typeReference = declaringType.ToTypeReference();
			}
			ITypeReference typeReference2 = (ITypeReference)typeReference;
			if (base.IsExplicitInterfaceImplementation && base.ImplementedInterfaceMembers.Count == 1)
			{
				return new ExplicitInterfaceImplementationMemberReference(typeReference2, base.ImplementedInterfaceMembers[0].ToReference());
			}
			return new DefaultMemberReference(base.SymbolKind, typeReference2, base.Name, 0, (from p in Parameters
				select p.Type.ToTypeReference()).ToList());
		}

		public override IMember Specialize(TypeParameterSubstitution substitution)
		{
			if (TypeParameterSubstitution.Identity.Equals(substitution) || base.DeclaringTypeDefinition == null || base.DeclaringTypeDefinition.TypeParameterCount == 0)
			{
				return this;
			}
			if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
			{
				substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
			}
			return new SpecializedProperty(this, substitution);
		}
	}
}
