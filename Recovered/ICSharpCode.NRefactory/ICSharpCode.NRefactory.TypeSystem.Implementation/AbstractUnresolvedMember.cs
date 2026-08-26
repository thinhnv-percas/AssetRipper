using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public abstract class AbstractUnresolvedMember : AbstractUnresolvedEntity, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
	{
		private ITypeReference returnType = SpecialType.UnknownType;

		private IList<IMemberReference> interfaceImplementations;

		public ITypeReference ReturnType
		{
			get
			{
				return returnType;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				ThrowIfFrozen();
				returnType = value;
			}
		}

		public bool IsExplicitInterfaceImplementation
		{
			get
			{
				return flags[64];
			}
			set
			{
				ThrowIfFrozen();
				flags[64] = value;
			}
		}

		public IList<IMemberReference> ExplicitInterfaceImplementations
		{
			get
			{
				if (interfaceImplementations == null)
				{
					interfaceImplementations = new List<IMemberReference>();
				}
				return interfaceImplementations;
			}
		}

		public bool IsVirtual
		{
			get
			{
				return flags[128];
			}
			set
			{
				ThrowIfFrozen();
				flags[128] = value;
			}
		}

		public bool IsOverride
		{
			get
			{
				return flags[256];
			}
			set
			{
				ThrowIfFrozen();
				flags[256] = value;
			}
		}

		public bool IsOverridable
		{
			get
			{
				if ((flags.Data & 0x184) != 0)
				{
					return !base.IsSealed;
				}
				return false;
			}
		}

		ITypeReference IMemberReference.DeclaringTypeReference => base.DeclaringTypeDefinition;

		public override void ApplyInterningProvider(InterningProvider provider)
		{
			base.ApplyInterningProvider(provider);
			interfaceImplementations = provider.InternList(interfaceImplementations);
		}

		protected override void FreezeInternal()
		{
			base.FreezeInternal();
			interfaceImplementations = FreezableHelper.FreezeList(interfaceImplementations);
		}

		public override object Clone()
		{
			AbstractUnresolvedMember abstractUnresolvedMember = (AbstractUnresolvedMember)base.Clone();
			if (interfaceImplementations != null)
			{
				abstractUnresolvedMember.interfaceImplementations = new List<IMemberReference>(interfaceImplementations);
			}
			return abstractUnresolvedMember;
		}

		public abstract IMember CreateResolved(ITypeResolveContext context);

		public virtual IMember Resolve(ITypeResolveContext context)
		{
			ITypeReference explicitInterfaceTypeReference = null;
			if (IsExplicitInterfaceImplementation && ExplicitInterfaceImplementations.Count == 1)
			{
				explicitInterfaceTypeReference = ExplicitInterfaceImplementations[0].DeclaringTypeReference;
			}
			return Resolve(ExtendContextForType(context, base.DeclaringTypeDefinition), base.SymbolKind, base.Name, explicitInterfaceTypeReference);
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return ((IUnresolvedMember)this).Resolve(context);
		}

		protected static ITypeResolveContext ExtendContextForType(ITypeResolveContext assemblyContext, IUnresolvedTypeDefinition typeDef)
		{
			if (typeDef == null)
			{
				return assemblyContext;
			}
			ITypeResolveContext parentContext = (typeDef.DeclaringTypeDefinition == null) ? assemblyContext : ExtendContextForType(assemblyContext, typeDef.DeclaringTypeDefinition);
			ITypeDefinition definition = typeDef.Resolve(assemblyContext).GetDefinition();
			return typeDef.CreateResolveContext(parentContext).WithCurrentTypeDefinition(definition);
		}

		public static IMember Resolve(ITypeResolveContext context, SymbolKind symbolKind, string name, ITypeReference explicitInterfaceTypeReference = null, IList<string> typeParameterNames = null, IList<ITypeReference> parameterTypeReferences = null)
		{
			if (context.CurrentTypeDefinition == null)
			{
				return null;
			}
			if (parameterTypeReferences == null)
			{
				parameterTypeReferences = EmptyList<ITypeReference>.Instance;
			}
			if (typeParameterNames == null || typeParameterNames.Count == 0)
			{
				IList<IType> parameterTypes = parameterTypeReferences.Resolve(context);
				if (explicitInterfaceTypeReference == null)
				{
					foreach (IMember member in context.CurrentTypeDefinition.Members)
					{
						if (!member.IsExplicitInterfaceImplementation && IsNonGenericMatch(member, symbolKind, name, parameterTypes))
						{
							return member;
						}
					}
				}
				else
				{
					IType type = explicitInterfaceTypeReference.Resolve(context);
					foreach (IMember member2 in context.CurrentTypeDefinition.Members)
					{
						if (member2.IsExplicitInterfaceImplementation && member2.ImplementedInterfaceMembers.Count == 1 && IsNonGenericMatch(member2, symbolKind, name, parameterTypes) && type.Equals(member2.ImplementedInterfaceMembers[0].DeclaringType))
						{
							return member2;
						}
					}
				}
			}
			else
			{
				foreach (IMethod method in context.CurrentTypeDefinition.Methods)
				{
					if (method.SymbolKind == symbolKind && !(method.Name != name) && method.Parameters.Count == parameterTypeReferences.Count && typeParameterNames.SequenceEqual(from tp in method.TypeParameters
						select tp.Name))
					{
						ITypeResolveContext context2 = context.WithCurrentMember(method);
						IList<IType> parameterTypes2 = parameterTypeReferences.Resolve(context2);
						if (IsParameterTypeMatch(method, parameterTypes2))
						{
							if (explicitInterfaceTypeReference == null)
							{
								if (!method.IsExplicitInterfaceImplementation)
								{
									return method;
								}
							}
							else if (method.IsExplicitInterfaceImplementation && method.ImplementedInterfaceMembers.Count == 1 && explicitInterfaceTypeReference.Resolve(context2).Equals(method.ImplementedInterfaceMembers[0].DeclaringType))
							{
								return method;
							}
						}
					}
				}
			}
			return null;
		}

		private static bool IsNonGenericMatch(IMember member, SymbolKind symbolKind, string name, IList<IType> parameterTypes)
		{
			if (member.SymbolKind != symbolKind)
			{
				return false;
			}
			if (member.Name != name)
			{
				return false;
			}
			IMethod method = member as IMethod;
			if (method != null && method.TypeParameters.Count > 0)
			{
				return false;
			}
			return IsParameterTypeMatch(member, parameterTypes);
		}

		private static bool IsParameterTypeMatch(IMember member, IList<IType> parameterTypes)
		{
			IParameterizedMember parameterizedMember = member as IParameterizedMember;
			if (parameterizedMember == null)
			{
				return parameterTypes.Count == 0;
			}
			if (parameterTypes.Count == parameterizedMember.Parameters.Count)
			{
				for (int i = 0; i < parameterTypes.Count; i++)
				{
					IType type = parameterTypes[i];
					IType type2 = parameterizedMember.Parameters[i].Type;
					if (!type.Equals(type2))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}
}
