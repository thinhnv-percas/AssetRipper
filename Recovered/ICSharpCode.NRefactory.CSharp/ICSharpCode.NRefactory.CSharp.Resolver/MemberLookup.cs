using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class MemberLookup
	{
		private sealed class LookupGroup
		{
			public readonly IType DeclaringType;

			public List<IType> NestedTypes;

			public readonly List<IParameterizedMember> Methods;

			public bool MethodsAreHidden;

			public IMember NonMethod;

			public bool NonMethodIsHidden;

			public bool AllHidden
			{
				get
				{
					if (NestedTypes != null && NestedTypes.Count > 0)
					{
						return false;
					}
					if (NonMethodIsHidden)
					{
						return MethodsAreHidden;
					}
					return false;
				}
			}

			public LookupGroup(IType declaringType, List<IType> nestedTypes, List<IParameterizedMember> methods, IMember nonMethod)
			{
				DeclaringType = declaringType;
				NestedTypes = nestedTypes;
				Methods = methods;
				NonMethod = nonMethod;
				MethodsAreHidden = (methods == null || methods.Count == 0);
				NonMethodIsHidden = (nonMethod == null);
			}
		}

		private readonly ITypeDefinition currentTypeDefinition;

		private readonly IAssembly currentAssembly;

		private readonly bool isInEnumMemberInitializer;

		public static bool IsInvocable(IMember member)
		{
			if (member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (member is IEvent || member is IMethod)
			{
				return true;
			}
			IType returnType = member.ReturnType;
			if (returnType.Kind != TypeKind.Dynamic)
			{
				return returnType.Kind == TypeKind.Delegate;
			}
			return true;
		}

		public MemberLookup(ITypeDefinition currentTypeDefinition, IAssembly currentAssembly, bool isInEnumMemberInitializer = false)
		{
			this.currentTypeDefinition = currentTypeDefinition;
			this.currentAssembly = currentAssembly;
			this.isInEnumMemberInitializer = isInEnumMemberInitializer;
		}

		public bool IsProtectedAccessAllowed(ResolveResult targetResolveResult)
		{
			if (!(targetResolveResult is ThisResolveResult))
			{
				return IsProtectedAccessAllowed(targetResolveResult.Type);
			}
			return true;
		}

		public bool IsProtectedAccessAllowed(IType targetType)
		{
			if (targetType.Kind == TypeKind.TypeParameter)
			{
				targetType = ((ITypeParameter)targetType).EffectiveBaseClass;
			}
			ITypeDefinition definition = targetType.GetDefinition();
			if (definition == null)
			{
				return false;
			}
			for (ITypeDefinition declaringTypeDefinition = currentTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
			{
				if (definition.IsDerivedFrom(declaringTypeDefinition))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAccessible(IEntity entity, bool allowProtectedAccess)
		{
			if (entity == null)
			{
				throw new ArgumentNullException("entity");
			}
			switch (entity.Accessibility)
			{
			case Accessibility.None:
				return false;
			case Accessibility.Private:
				for (ITypeDefinition declaringTypeDefinition = currentTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
				{
					if (declaringTypeDefinition.Equals(entity.DeclaringTypeDefinition))
					{
						return true;
					}
				}
				return false;
			case Accessibility.Public:
				return true;
			case Accessibility.Protected:
				return IsProtectedAccessible(allowProtectedAccess, entity);
			case Accessibility.Internal:
				return IsInternalAccessible(entity.ParentAssembly);
			case Accessibility.ProtectedOrInternal:
				if (!IsInternalAccessible(entity.ParentAssembly))
				{
					return IsProtectedAccessible(allowProtectedAccess, entity);
				}
				return true;
			case Accessibility.ProtectedAndInternal:
				if (IsInternalAccessible(entity.ParentAssembly))
				{
					return IsProtectedAccessible(allowProtectedAccess, entity);
				}
				return false;
			default:
				throw new Exception("Invalid value for Accessibility");
			}
		}

		private bool IsInternalAccessible(IAssembly assembly)
		{
			if (assembly != null && currentAssembly != null)
			{
				return assembly.InternalsVisibleTo(currentAssembly);
			}
			return false;
		}

		private bool IsProtectedAccessible(bool allowProtectedAccess, IEntity entity)
		{
			if (entity.IsStatic || entity.SymbolKind == SymbolKind.TypeDefinition)
			{
				allowProtectedAccess = true;
			}
			for (ITypeDefinition declaringTypeDefinition = currentTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
			{
				if (declaringTypeDefinition.Equals(entity.DeclaringTypeDefinition))
				{
					return true;
				}
				if (allowProtectedAccess && declaringTypeDefinition.IsDerivedFrom(entity.DeclaringTypeDefinition))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<IEntity> GetAccessibleMembers(ResolveResult targetResolveResult)
		{
			if (targetResolveResult == null)
			{
				throw new ArgumentNullException("targetResolveResult");
			}
			bool targetIsTypeParameter = targetResolveResult.Type.Kind == TypeKind.TypeParameter;
			bool allowProtectedAccess = IsProtectedAccessAllowed(targetResolveResult);
			Dictionary<string, List<LookupGroup>> dictionary = new Dictionary<string, List<LookupGroup>>();
			foreach (IType nonInterfaceBaseType in targetResolveResult.Type.GetNonInterfaceBaseTypes())
			{
				List<IEntity> list = new List<IEntity>();
				list.AddRange(nonInterfaceBaseType.GetMembers(null, GetMemberOptions.IgnoreInheritedMembers));
				if (!targetIsTypeParameter)
				{
					IEnumerable<IType> nestedTypes = nonInterfaceBaseType.GetNestedTypes(null, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers);
					list.AddRange(from t in nestedTypes
						select t.GetDefinition() into td
						where td != null
						select td);
				}
				foreach (IGrouping<string, IEntity> item in from e in list
					group e by e.Name)
				{
					List<LookupGroup> value = new List<LookupGroup>();
					if (!dictionary.TryGetValue(item.Key, out value))
					{
						dictionary.Add(item.Key, value = new List<LookupGroup>());
					}
					List<IType> newNestedTypes = null;
					List<IParameterizedMember> newMethods = null;
					IMember newNonMethod = null;
					IEnumerable<IType> typeBaseTypes = null;
					if (!targetIsTypeParameter)
					{
						AddNestedTypes(nonInterfaceBaseType, item.OfType<IType>(), 0, value, ref typeBaseTypes, ref newNestedTypes);
					}
					AddMembers(nonInterfaceBaseType, item.OfType<IMember>(), allowProtectedAccess, value, treatAllParameterizedMembersAsMethods: false, ref typeBaseTypes, ref newMethods, ref newNonMethod);
					if (newNestedTypes != null || newMethods != null || newNonMethod != null)
					{
						value.Add(new LookupGroup(nonInterfaceBaseType, newNestedTypes, newMethods, newNonMethod));
					}
				}
			}
			foreach (List<LookupGroup> value2 in dictionary.Values)
			{
				if (targetIsTypeParameter)
				{
					RemoveInterfaceMembersHiddenByClassMembers(value2);
				}
				foreach (LookupGroup lookupGroup in value2)
				{
					if (!lookupGroup.MethodsAreHidden)
					{
						foreach (IMethod method in lookupGroup.Methods)
						{
							yield return method;
						}
					}
					if (!lookupGroup.NonMethodIsHidden)
					{
						yield return lookupGroup.NonMethod;
					}
					if (lookupGroup.NestedTypes != null)
					{
						foreach (IType nestedType in lookupGroup.NestedTypes)
						{
							ITypeDefinition definition = nestedType.GetDefinition();
							if (definition != null)
							{
								yield return definition;
							}
						}
					}
				}
			}
		}

		public ResolveResult LookupType(IType declaringType, string name, IList<IType> typeArguments, bool parameterizeResultType = true)
		{
			if (declaringType == null)
			{
				throw new ArgumentNullException("declaringType");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (typeArguments == null)
			{
				throw new ArgumentNullException("typeArguments");
			}
			int typeArgumentCount = typeArguments.Count;
			Predicate<ITypeDefinition> filter = (ITypeDefinition d) => InnerTypeParameterCount(d) == typeArgumentCount && d.Name == name && IsAccessible(d, allowProtectedAccess: true);
			List<LookupGroup> list = new List<LookupGroup>();
			if (declaringType.Kind != TypeKind.TypeParameter)
			{
				foreach (IType nonInterfaceBaseType in declaringType.GetNonInterfaceBaseTypes())
				{
					List<IType> newNestedTypes = null;
					IEnumerable<IType> typeBaseTypes = null;
					IEnumerable<IType> nestedTypes = (!parameterizeResultType) ? nonInterfaceBaseType.GetNestedTypes(filter, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers) : nonInterfaceBaseType.GetNestedTypes(typeArguments, filter, GetMemberOptions.IgnoreInheritedMembers);
					AddNestedTypes(nonInterfaceBaseType, nestedTypes, typeArgumentCount, list, ref typeBaseTypes, ref newNestedTypes);
					if (newNestedTypes != null)
					{
						list.Add(new LookupGroup(nonInterfaceBaseType, newNestedTypes, null, null));
					}
				}
			}
			list.RemoveAll((LookupGroup g) => g.AllHidden);
			if (list.Count == 0)
			{
				return new UnknownMemberResolveResult(declaringType, name, typeArguments);
			}
			LookupGroup lookupGroup = list[list.Count - 1];
			if (lookupGroup.NestedTypes.Count > 1 || list.Count > 1)
			{
				return new AmbiguousTypeResolveResult(lookupGroup.NestedTypes[0]);
			}
			return new TypeResolveResult(lookupGroup.NestedTypes[0]);
		}

		private static int InnerTypeParameterCount(IType type)
		{
			return type.TypeParameterCount - ((type.DeclaringType != null) ? type.DeclaringType.TypeParameterCount : 0);
		}

		public ResolveResult Lookup(ResolveResult targetResolveResult, string name, IList<IType> typeArguments, bool isInvocation)
		{
			if (targetResolveResult == null)
			{
				throw new ArgumentNullException("targetResolveResult");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (typeArguments == null)
			{
				throw new ArgumentNullException("typeArguments");
			}
			bool flag = targetResolveResult.Type.Kind == TypeKind.TypeParameter;
			bool allowProtectedAccess = IsProtectedAccessAllowed(targetResolveResult);
			Predicate<ITypeDefinition> filter = (ITypeDefinition entity) => entity.Name == name && IsAccessible(entity, allowProtectedAccess);
			Predicate<IUnresolvedMember> filter2 = (IUnresolvedMember entity) => entity.SymbolKind != SymbolKind.Indexer && entity.SymbolKind != SymbolKind.Operator && entity.Name == name;
			List<LookupGroup> list = new List<LookupGroup>();
			foreach (IType nonInterfaceBaseType in targetResolveResult.Type.GetNonInterfaceBaseTypes())
			{
				List<IType> newNestedTypes = null;
				List<IParameterizedMember> newMethods = null;
				IMember newNonMethod = null;
				IEnumerable<IType> typeBaseTypes = null;
				if (!isInvocation && !flag)
				{
					IEnumerable<IType> nestedTypes = nonInterfaceBaseType.GetNestedTypes(typeArguments, filter, GetMemberOptions.IgnoreInheritedMembers);
					AddNestedTypes(nonInterfaceBaseType, nestedTypes, typeArguments.Count, list, ref typeBaseTypes, ref newNestedTypes);
				}
				IEnumerable<IMember> enumerable;
				if (typeArguments.Count == 0)
				{
					enumerable = nonInterfaceBaseType.GetMembers(filter2, GetMemberOptions.IgnoreInheritedMembers);
					if (isInvocation)
					{
						enumerable = from m in enumerable
							where IsInvocable(m)
							select m;
					}
				}
				else
				{
					enumerable = nonInterfaceBaseType.GetMethods(typeArguments, filter2, GetMemberOptions.IgnoreInheritedMembers);
				}
				AddMembers(nonInterfaceBaseType, enumerable, allowProtectedAccess, list, treatAllParameterizedMembersAsMethods: false, ref typeBaseTypes, ref newMethods, ref newNonMethod);
				if (newNestedTypes != null || newMethods != null || newNonMethod != null)
				{
					list.Add(new LookupGroup(nonInterfaceBaseType, newNestedTypes, newMethods, newNonMethod));
				}
			}
			if (flag)
			{
				RemoveInterfaceMembersHiddenByClassMembers(list);
			}
			return CreateResult(targetResolveResult, list, name, typeArguments);
		}

		public IList<MethodListWithDeclaringType> LookupIndexers(ResolveResult targetResolveResult)
		{
			if (targetResolveResult == null)
			{
				throw new ArgumentNullException("targetResolveResult");
			}
			IType type = targetResolveResult.Type;
			bool allowProtectedAccess = IsProtectedAccessAllowed(targetResolveResult);
			Predicate<IUnresolvedProperty> filter = (IUnresolvedProperty p) => p.IsIndexer;
			List<LookupGroup> list = new List<LookupGroup>();
			foreach (IType nonInterfaceBaseType in type.GetNonInterfaceBaseTypes())
			{
				List<IParameterizedMember> newMethods = null;
				IMember newNonMethod = null;
				IEnumerable<IType> typeBaseTypes = null;
				IEnumerable<IProperty> properties = nonInterfaceBaseType.GetProperties(filter, GetMemberOptions.IgnoreInheritedMembers);
				AddMembers(nonInterfaceBaseType, properties, allowProtectedAccess, list, treatAllParameterizedMembersAsMethods: true, ref typeBaseTypes, ref newMethods, ref newNonMethod);
				if (newMethods != null || newNonMethod != null)
				{
					list.Add(new LookupGroup(nonInterfaceBaseType, null, newMethods, newNonMethod));
				}
			}
			if (type.Kind == TypeKind.TypeParameter)
			{
				RemoveInterfaceMembersHiddenByClassMembers(list);
			}
			list.RemoveAll((LookupGroup g) => (!g.MethodsAreHidden) ? (g.Methods.Count == 0) : true);
			MethodListWithDeclaringType[] array = new MethodListWithDeclaringType[list.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new MethodListWithDeclaringType(list[i].DeclaringType, list[i].Methods);
			}
			return array;
		}

		private void AddNestedTypes(IType type, IEnumerable<IType> nestedTypes, int typeArgumentCount, List<LookupGroup> lookupGroups, ref IEnumerable<IType> typeBaseTypes, ref List<IType> newNestedTypes)
		{
			foreach (IType nestedType in nestedTypes)
			{
				foreach (LookupGroup lookupGroup in lookupGroups)
				{
					if (!lookupGroup.AllHidden)
					{
						if (typeBaseTypes == null)
						{
							typeBaseTypes = type.GetNonInterfaceBaseTypes();
						}
						if (typeBaseTypes.Contains(lookupGroup.DeclaringType))
						{
							lookupGroup.MethodsAreHidden = true;
							lookupGroup.NonMethodIsHidden = true;
							if (lookupGroup.NestedTypes != null)
							{
								lookupGroup.NestedTypes.RemoveAll((IType t) => InnerTypeParameterCount(t) == typeArgumentCount);
							}
						}
					}
				}
				if (newNestedTypes == null)
				{
					newNestedTypes = new List<IType>();
				}
				newNestedTypes.Add(nestedType);
			}
		}

		private void AddMembers(IType type, IEnumerable<IMember> members, bool allowProtectedAccess, List<LookupGroup> lookupGroups, bool treatAllParameterizedMembersAsMethods, ref IEnumerable<IType> typeBaseTypes, ref List<IParameterizedMember> newMethods, ref IMember newNonMethod)
		{
			foreach (IMember member in members)
			{
				if (IsAccessible(member, allowProtectedAccess))
				{
					IParameterizedMember parameterizedMember = (!treatAllParameterizedMembersAsMethods) ? (member as IMethod) : (member as IParameterizedMember);
					bool flag = false;
					if (member.IsOverride)
					{
						int num = lookupGroups.Count - 1;
						while (num >= 0 && !flag)
						{
							if (typeBaseTypes == null)
							{
								typeBaseTypes = type.GetNonInterfaceBaseTypes();
							}
							LookupGroup lookupGroup = lookupGroups[num];
							if (typeBaseTypes.Contains(lookupGroup.DeclaringType))
							{
								if (parameterizedMember != null)
								{
									for (int i = 0; i < lookupGroup.Methods.Count; i++)
									{
										if (SignatureComparer.Ordinal.Equals(parameterizedMember, lookupGroup.Methods[i]))
										{
											lookupGroup.Methods[i] = parameterizedMember;
											flag = true;
											break;
										}
									}
								}
								else if (lookupGroup.NonMethod != null && lookupGroup.NonMethod.SymbolKind == member.SymbolKind)
								{
									lookupGroup.NonMethod = member;
									flag = true;
									break;
								}
							}
							num--;
						}
					}
					if (!flag)
					{
						foreach (LookupGroup lookupGroup2 in lookupGroups)
						{
							if (!lookupGroup2.AllHidden)
							{
								if (typeBaseTypes == null)
								{
									typeBaseTypes = type.GetNonInterfaceBaseTypes();
								}
								if (typeBaseTypes.Contains(lookupGroup2.DeclaringType))
								{
									lookupGroup2.NestedTypes = null;
									lookupGroup2.NonMethodIsHidden = true;
									if (parameterizedMember == null)
									{
										lookupGroup2.MethodsAreHidden = true;
									}
								}
							}
						}
						if (parameterizedMember != null)
						{
							if (newMethods == null)
							{
								newMethods = new List<IParameterizedMember>();
							}
							newMethods.Add(parameterizedMember);
						}
						else
						{
							newNonMethod = member;
						}
					}
				}
			}
		}

		private void RemoveInterfaceMembersHiddenByClassMembers(List<LookupGroup> lookupGroups)
		{
			foreach (LookupGroup lookupGroup in lookupGroups)
			{
				if (!IsInterfaceOrSystemObject(lookupGroup.DeclaringType))
				{
					if ((lookupGroup.NestedTypes != null && lookupGroup.NestedTypes.Count > 0) || !lookupGroup.NonMethodIsHidden)
					{
						foreach (LookupGroup lookupGroup2 in lookupGroups)
						{
							if (IsInterfaceOrSystemObject(lookupGroup2.DeclaringType))
							{
								lookupGroup2.NestedTypes = null;
								lookupGroup2.NonMethodIsHidden = true;
								lookupGroup2.MethodsAreHidden = true;
							}
						}
					}
					else if (!lookupGroup.MethodsAreHidden)
					{
						foreach (IParameterizedMember classMethod in lookupGroup.Methods)
						{
							foreach (LookupGroup lookupGroup3 in lookupGroups)
							{
								if (IsInterfaceOrSystemObject(lookupGroup3.DeclaringType))
								{
									lookupGroup3.NestedTypes = null;
									lookupGroup3.NonMethodIsHidden = true;
									if (lookupGroup3.Methods != null && !lookupGroup3.MethodsAreHidden)
									{
										lookupGroup3.Methods.RemoveAll((IParameterizedMember m) => SignatureComparer.Ordinal.Equals(classMethod, m));
									}
								}
							}
						}
					}
				}
			}
		}

		private static bool IsInterfaceOrSystemObject(IType type)
		{
			if (type.Kind == TypeKind.Interface)
			{
				return true;
			}
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null)
			{
				return definition.KnownTypeCode == KnownTypeCode.Object;
			}
			return false;
		}

		private ResolveResult CreateResult(ResolveResult targetResolveResult, List<LookupGroup> lookupGroups, string name, IList<IType> typeArguments)
		{
			lookupGroups.RemoveAll((LookupGroup g) => g.AllHidden);
			if (lookupGroups.Count == 0)
			{
				return new UnknownMemberResolveResult(targetResolveResult.Type, name, typeArguments);
			}
			if (lookupGroups.Any((LookupGroup g) => !g.MethodsAreHidden && g.Methods.Count > 0))
			{
				List<MethodListWithDeclaringType> list = new List<MethodListWithDeclaringType>();
				foreach (LookupGroup lookupGroup2 in lookupGroups)
				{
					if (!lookupGroup2.MethodsAreHidden && lookupGroup2.Methods.Count > 0)
					{
						MethodListWithDeclaringType methodListWithDeclaringType = new MethodListWithDeclaringType(lookupGroup2.DeclaringType);
						foreach (IParameterizedMember method in lookupGroup2.Methods)
						{
							methodListWithDeclaringType.Add((IMethod)method);
						}
						list.Add(methodListWithDeclaringType);
					}
				}
				return new MethodGroupResolveResult(targetResolveResult, name, list, typeArguments);
			}
			LookupGroup lookupGroup = lookupGroups[lookupGroups.Count - 1];
			if (lookupGroup.NestedTypes != null && lookupGroup.NestedTypes.Count > 0)
			{
				if (lookupGroup.NestedTypes.Count > 1 || !lookupGroup.NonMethodIsHidden || lookupGroups.Count > 1)
				{
					return new AmbiguousTypeResolveResult(lookupGroup.NestedTypes[0]);
				}
				return new TypeResolveResult(lookupGroup.NestedTypes[0]);
			}
			if (lookupGroup.NonMethod.IsStatic && targetResolveResult is ThisResolveResult)
			{
				targetResolveResult = new TypeResolveResult(targetResolveResult.Type);
			}
			if (lookupGroups.Count > 1)
			{
				return new AmbiguousMemberResolveResult(targetResolveResult, lookupGroup.NonMethod);
			}
			if (isInEnumMemberInitializer)
			{
				IField field = lookupGroup.NonMethod as IField;
				if (field != null && field.DeclaringTypeDefinition != null && field.DeclaringTypeDefinition.Kind == TypeKind.Enum)
				{
					return new MemberResolveResult(targetResolveResult, field, field.DeclaringTypeDefinition.EnumUnderlyingType, field.IsConst, field.ConstantValue);
				}
			}
			return new MemberResolveResult(targetResolveResult, lookupGroup.NonMethod);
		}
	}
}
