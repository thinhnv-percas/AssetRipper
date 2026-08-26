using ICSharpCode.NRefactory.Documentation;
using ICSharpCode.NRefactory.Utils;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public abstract class AbstractResolvedMember : AbstractResolvedEntity, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		protected new readonly IUnresolvedMember unresolved;

		protected readonly ITypeResolveContext context;

		private volatile IType returnType;

		private IList<IMember> implementedInterfaceMembers;

		IMember IMember.MemberDefinition => this;

		public IType ReturnType => returnType ?? (returnType = unresolved.ReturnType.Resolve(context));

		public IUnresolvedMember UnresolvedMember => unresolved;

		public IList<IMember> ImplementedInterfaceMembers
		{
			get
			{
				IList<IMember> list = LazyInit.VolatileRead(ref implementedInterfaceMembers);
				if (list != null)
				{
					return list;
				}
				return LazyInit.GetOrSet(ref implementedInterfaceMembers, FindImplementedInterfaceMembers());
			}
		}

		public override DocumentationComment Documentation
		{
			get
			{
				IUnresolvedDocumentationProvider unresolvedDocumentationProvider = unresolved.UnresolvedFile as IUnresolvedDocumentationProvider;
				if (unresolvedDocumentationProvider != null)
				{
					DocumentationComment documentation = unresolvedDocumentationProvider.GetDocumentation(unresolved, this);
					if (documentation != null)
					{
						return documentation;
					}
				}
				return base.Documentation;
			}
		}

		public bool IsExplicitInterfaceImplementation => unresolved.IsExplicitInterfaceImplementation;

		public bool IsVirtual => unresolved.IsVirtual;

		public bool IsOverride => unresolved.IsOverride;

		public bool IsOverridable => unresolved.IsOverridable;

		public TypeParameterSubstitution Substitution => TypeParameterSubstitution.Identity;

		protected AbstractResolvedMember(IUnresolvedMember unresolved, ITypeResolveContext parentContext)
			: base(unresolved, parentContext)
		{
			this.unresolved = unresolved;
			context = parentContext.WithCurrentMember(this);
		}

		private IList<IMember> FindImplementedInterfaceMembers()
		{
			if (unresolved.IsExplicitInterfaceImplementation)
			{
				List<IMember> list = new List<IMember>();
				foreach (IMemberReference explicitInterfaceImplementation in unresolved.ExplicitInterfaceImplementations)
				{
					IMember member = explicitInterfaceImplementation.Resolve(context);
					if (member != null)
					{
						list.Add(member);
					}
				}
				return list.ToArray();
			}
			if (unresolved.IsStatic || !unresolved.IsPublic || base.DeclaringTypeDefinition == null || base.DeclaringTypeDefinition.Kind == TypeKind.Interface)
			{
				return EmptyList<IMember>.Instance;
			}
			IMember[] source = (from m in InheritanceHelper.GetBaseMembers(this, includeImplementedInterfaces: true)
				where m.DeclaringTypeDefinition != null && m.DeclaringTypeDefinition.Kind == TypeKind.Interface
				select m).ToArray();
			IEnumerable<IMember> otherMembers = base.DeclaringTypeDefinition.Members;
			if (base.SymbolKind == SymbolKind.Accessor)
			{
				otherMembers = base.DeclaringTypeDefinition.GetAccessors(null, GetMemberOptions.IgnoreInheritedMembers);
			}
			return (from item in source
				where !otherMembers.Any((IMember m) => m.IsExplicitInterfaceImplementation && m.ImplementedInterfaceMembers.Contains(item))
				select item).ToArray();
		}

		public abstract IMember Specialize(TypeParameterSubstitution substitution);

		IMemberReference IMember.ToReference()
		{
			return (IMemberReference)ToReference();
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
			if (IsExplicitInterfaceImplementation && ImplementedInterfaceMembers.Count == 1)
			{
				return new ExplicitInterfaceImplementationMemberReference(typeReference2, ImplementedInterfaceMembers[0].ToReference());
			}
			return new DefaultMemberReference(base.SymbolKind, typeReference2, base.Name);
		}

		public virtual IMemberReference ToMemberReference()
		{
			return (IMemberReference)ToReference();
		}

		internal IMethod GetAccessor(ref IMethod accessorField, IUnresolvedMethod unresolvedAccessor)
		{
			if (unresolvedAccessor == null)
			{
				return null;
			}
			IMethod method = LazyInit.VolatileRead(ref accessorField);
			if (method != null)
			{
				return method;
			}
			return LazyInit.GetOrSet(ref accessorField, CreateResolvedAccessor(unresolvedAccessor));
		}

		protected virtual IMethod CreateResolvedAccessor(IUnresolvedMethod unresolvedAccessor)
		{
			return (IMethod)unresolvedAccessor.CreateResolved(context);
		}
	}
}
