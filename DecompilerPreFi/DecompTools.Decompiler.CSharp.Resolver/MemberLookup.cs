#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

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
				return NonMethodIsHidden && MethodsAreHidden;
			}
		}

		public LookupGroup(IType declaringType, List<IType> nestedTypes, List<IParameterizedMember> methods, IMember nonMethod)
		{
			DeclaringType = declaringType;
			NestedTypes = nestedTypes;
			Methods = methods;
			NonMethod = nonMethod;
			MethodsAreHidden = methods == null || methods.Count == 0;
			NonMethodIsHidden = nonMethod == null;
		}
	}

	private readonly ITypeDefinition currentTypeDefinition;

	private readonly IModule currentModule;

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
		return returnType.Kind == TypeKind.Dynamic || returnType.Kind == TypeKind.Delegate;
	}

	public MemberLookup(ITypeDefinition currentTypeDefinition, IModule currentModule, bool isInEnumMemberInitializer = false)
	{
		this.currentTypeDefinition = currentTypeDefinition;
		this.currentModule = currentModule;
		this.isInEnumMemberInitializer = isInEnumMemberInitializer;
	}

	public bool IsProtectedAccessAllowed(ResolveResult targetResolveResult)
	{
		return targetResolveResult is ThisResolveResult || IsProtectedAccessAllowed(targetResolveResult.Type);
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
		{
			for (ITypeDefinition declaringTypeDefinition = currentTypeDefinition; declaringTypeDefinition != null; declaringTypeDefinition = declaringTypeDefinition.DeclaringTypeDefinition)
			{
				if (declaringTypeDefinition.Equals(entity.DeclaringTypeDefinition))
				{
					return true;
				}
			}
			return false;
		}
		case Accessibility.Public:
			return true;
		case Accessibility.Protected:
			return IsProtectedAccessible(allowProtectedAccess, entity);
		case Accessibility.Internal:
			return IsInternalAccessible(entity.ParentModule);
		case Accessibility.ProtectedOrInternal:
			return IsInternalAccessible(entity.ParentModule) || IsProtectedAccessible(allowProtectedAccess, entity);
		case Accessibility.ProtectedAndInternal:
			return IsInternalAccessible(entity.ParentModule) && IsProtectedAccessible(allowProtectedAccess, entity);
		default:
			throw new Exception("Invalid value for Accessibility");
		}
	}

	private bool IsInternalAccessible(IModule module)
	{
		return module != null && currentModule != null && module.InternalsVisibleTo(currentModule);
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
		Dictionary<string, List<LookupGroup>> lookupGroupDict = new Dictionary<string, List<LookupGroup>>();
		foreach (IType type in targetResolveResult.Type.GetNonInterfaceBaseTypes())
		{
			List<IEntity> entities = new List<IEntity>();
			entities.AddRange(type.GetMembers(null, GetMemberOptions.IgnoreInheritedMembers));
			if (!targetIsTypeParameter)
			{
				IEnumerable<IType> nestedTypes = type.GetNestedTypes(null, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers);
				entities.AddRange(Enumerable.Where<ITypeDefinition>(Enumerable.Select<IType, ITypeDefinition>(nestedTypes, (Func<IType, ITypeDefinition>)((IType t) => t.GetDefinition())), (Func<ITypeDefinition, bool>)((ITypeDefinition td) => td != null)));
			}
			foreach (IGrouping<string, IEntity> entityGroup in Enumerable.GroupBy<IEntity, string>((IEnumerable<IEntity>)entities, (Func<IEntity, string>)((IEntity e) => e.Name)))
			{
				List<LookupGroup> lookupGroups = new List<LookupGroup>();
				if (!lookupGroupDict.TryGetValue(entityGroup.Key, out lookupGroups))
				{
					string key = entityGroup.Key;
					List<LookupGroup> value;
					lookupGroups = (value = new List<LookupGroup>());
					lookupGroupDict.Add(key, value);
				}
				List<IType> newNestedTypes = null;
				List<IParameterizedMember> newMethods = null;
				IMember newNonMethod = null;
				IEnumerable<IType> typeBaseTypes = null;
				if (!targetIsTypeParameter)
				{
					AddNestedTypes(type, Enumerable.OfType<IType>((IEnumerable)entityGroup), 0, lookupGroups, ref typeBaseTypes, ref newNestedTypes);
				}
				AddMembers(type, Enumerable.OfType<IMember>((IEnumerable)entityGroup), allowProtectedAccess, lookupGroups, treatAllParameterizedMembersAsMethods: false, ref typeBaseTypes, ref newMethods, ref newNonMethod);
				if (newNestedTypes != null || newMethods != null || newNonMethod != null)
				{
					lookupGroups.Add(new LookupGroup(type, newNestedTypes, newMethods, newNonMethod));
				}
			}
		}
		foreach (List<LookupGroup> lookupGroups2 in lookupGroupDict.Values)
		{
			if (targetIsTypeParameter)
			{
				RemoveInterfaceMembersHiddenByClassMembers(lookupGroups2);
			}
			foreach (LookupGroup lookupGroup in lookupGroups2)
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
				if (lookupGroup.NestedTypes == null)
				{
					continue;
				}
				foreach (IType type2 in lookupGroup.NestedTypes)
				{
					ITypeDefinition typeDef = type2.GetDefinition();
					if (typeDef != null)
					{
						yield return typeDef;
					}
				}
			}
		}
	}

	public ResolveResult LookupType(IType declaringType, string name, IReadOnlyList<IType> typeArguments, bool parameterizeResultType = true)
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
				IEnumerable<IType> nestedTypes = ((!parameterizeResultType) ? nonInterfaceBaseType.GetNestedTypes(filter, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers) : nonInterfaceBaseType.GetNestedTypes(typeArguments, filter, GetMemberOptions.IgnoreInheritedMembers));
				AddNestedTypes(nonInterfaceBaseType, nestedTypes, typeArgumentCount, list, ref typeBaseTypes, ref newNestedTypes);
				if (newNestedTypes != null)
				{
					list.Add(new LookupGroup(nonInterfaceBaseType, newNestedTypes, null, null));
				}
			}
		}
		list.RemoveAll((LookupGroup g) => g.AllHidden);
		Debug.Assert(Enumerable.All<LookupGroup>((IEnumerable<LookupGroup>)list, (Func<LookupGroup, bool>)((LookupGroup g) => g.NestedTypes != null && g.NestedTypes.Count > 0)));
		if (list.Count == 0)
		{
			return new UnknownMemberResolveResult(declaringType, name, typeArguments);
		}
		LookupGroup lookupGroup = list[checked(list.Count - 1)];
		if (lookupGroup.NestedTypes.Count > 1 || list.Count > 1)
		{
			return new AmbiguousTypeResolveResult(lookupGroup.NestedTypes[0]);
		}
		return new TypeResolveResult(lookupGroup.NestedTypes[0]);
	}

	private static int InnerTypeParameterCount(IType type)
	{
		return checked(type.TypeParameterCount - ((type.DeclaringType != null) ? type.DeclaringType.TypeParameterCount : 0));
	}

	public ResolveResult Lookup(ResolveResult targetResolveResult, string name, IReadOnlyList<IType> typeArguments, bool isInvocation)
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
		Predicate<IMember> filter2 = (IMember entity) => entity.SymbolKind != SymbolKind.Indexer && entity.SymbolKind != SymbolKind.Operator && entity.Name == name;
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
					enumerable = Enumerable.Where<IMember>(enumerable, (Func<IMember, bool>)((IMember m) => IsInvocable(m)));
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

	public IReadOnlyList<MethodListWithDeclaringType> LookupIndexers(ResolveResult targetResolveResult)
	{
		if (targetResolveResult == null)
		{
			throw new ArgumentNullException("targetResolveResult");
		}
		IType type = targetResolveResult.Type;
		bool allowProtectedAccess = IsProtectedAccessAllowed(targetResolveResult);
		Predicate<IProperty> filter = (IProperty p) => p.IsIndexer && !p.IsExplicitInterfaceImplementation;
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
		list.RemoveAll((LookupGroup g) => g.MethodsAreHidden || g.Methods.Count == 0);
		MethodListWithDeclaringType[] array = new MethodListWithDeclaringType[list.Count];
		for (int num = 0; num < array.Length; num = checked(num + 1))
		{
			array[num] = new MethodListWithDeclaringType(list[num].DeclaringType, list[num].Methods);
		}
		return array;
	}

	private void AddNestedTypes(IType type, IEnumerable<IType> nestedTypes, int typeArgumentCount, List<LookupGroup> lookupGroups, ref IEnumerable<IType> typeBaseTypes, ref List<IType> newNestedTypes)
	{
		foreach (IType nestedType in nestedTypes)
		{
			foreach (LookupGroup lookupGroup in lookupGroups)
			{
				if (lookupGroup.AllHidden)
				{
					continue;
				}
				if (typeBaseTypes == null)
				{
					typeBaseTypes = type.GetNonInterfaceBaseTypes();
				}
				if (!Enumerable.Contains<IType>(typeBaseTypes, lookupGroup.DeclaringType))
				{
					continue;
				}
				lookupGroup.MethodsAreHidden = true;
				lookupGroup.NonMethodIsHidden = true;
				if (lookupGroup.NestedTypes != null)
				{
					lookupGroup.NestedTypes.RemoveAll((IType t) => InnerTypeParameterCount(t) == typeArgumentCount);
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
		checked
		{
			foreach (IMember member in members)
			{
				if (!IsAccessible(member, allowProtectedAccess))
				{
					continue;
				}
				IParameterizedMember parameterizedMember = ((!treatAllParameterizedMembersAsMethods) ? (member as IMethod) : (member as IParameterizedMember));
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
						if (Enumerable.Contains<IType>(typeBaseTypes, lookupGroup.DeclaringType))
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
				if (flag)
				{
					continue;
				}
				foreach (LookupGroup lookupGroup2 in lookupGroups)
				{
					if (lookupGroup2.AllHidden)
					{
						continue;
					}
					if (typeBaseTypes == null)
					{
						typeBaseTypes = type.GetNonInterfaceBaseTypes();
					}
					if (Enumerable.Contains<IType>(typeBaseTypes, lookupGroup2.DeclaringType))
					{
						lookupGroup2.NestedTypes = null;
						lookupGroup2.NonMethodIsHidden = true;
						if (parameterizedMember == null)
						{
							lookupGroup2.MethodsAreHidden = true;
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

	private void RemoveInterfaceMembersHiddenByClassMembers(List<LookupGroup> lookupGroups)
	{
		foreach (LookupGroup lookupGroup in lookupGroups)
		{
			if (IsInterfaceOrSystemObject(lookupGroup.DeclaringType))
			{
				continue;
			}
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
			else
			{
				if (lookupGroup.MethodsAreHidden)
				{
					continue;
				}
				foreach (IParameterizedMember classMethod in lookupGroup.Methods)
				{
					foreach (LookupGroup lookupGroup3 in lookupGroups)
					{
						if (!IsInterfaceOrSystemObject(lookupGroup3.DeclaringType))
						{
							continue;
						}
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

	private static bool IsInterfaceOrSystemObject(IType type)
	{
		if (type.Kind == TypeKind.Interface)
		{
			return true;
		}
		ITypeDefinition definition = type.GetDefinition();
		return definition != null && definition.KnownTypeCode == KnownTypeCode.Object;
	}

	private ResolveResult CreateResult(ResolveResult targetResolveResult, List<LookupGroup> lookupGroups, string name, IReadOnlyList<IType> typeArguments)
	{
		lookupGroups.RemoveAll((LookupGroup g) => g.AllHidden);
		if (lookupGroups.Count == 0)
		{
			return new UnknownMemberResolveResult(targetResolveResult.Type, name, typeArguments);
		}
		if (Enumerable.Any<LookupGroup>((IEnumerable<LookupGroup>)lookupGroups, (Func<LookupGroup, bool>)((LookupGroup g) => !g.MethodsAreHidden && g.Methods.Count > 0)))
		{
			List<MethodListWithDeclaringType> list = new List<MethodListWithDeclaringType>();
			foreach (LookupGroup lookupGroup2 in lookupGroups)
			{
				if (lookupGroup2.MethodsAreHidden || lookupGroup2.Methods.Count <= 0)
				{
					continue;
				}
				MethodListWithDeclaringType methodListWithDeclaringType = new MethodListWithDeclaringType(lookupGroup2.DeclaringType);
				foreach (IParameterizedMember method in lookupGroup2.Methods)
				{
					methodListWithDeclaringType.Add((IMethod)method);
				}
				list.Add(methodListWithDeclaringType);
			}
			return new MethodGroupResolveResult(targetResolveResult, name, list, typeArguments);
		}
		LookupGroup lookupGroup = lookupGroups[checked(lookupGroups.Count - 1)];
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
		if (isInEnumMemberInitializer && lookupGroup.NonMethod is IField { DeclaringTypeDefinition: not null } field && field.DeclaringTypeDefinition.Kind == TypeKind.Enum)
		{
			return new MemberResolveResult(targetResolveResult, field, field.DeclaringTypeDefinition.EnumUnderlyingType, field.IsConst, field.GetConstantValue());
		}
		return new MemberResolveResult(targetResolveResult, lookupGroup.NonMethod);
	}
}
