using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public static class TypesHierarchyHelpers
{
	private static readonly UTF8String systemRuntimeCompilerServicesString = new UTF8String("System.Runtime.CompilerServices");

	private static readonly UTF8String internalsVisibleToAttributeString = new UTF8String("InternalsVisibleToAttribute");

	public static bool IsBaseType(TypeDef baseType, TypeDef derivedType, bool resolveTypeArguments)
	{
		if (baseType == null || derivedType == null)
		{
			return false;
		}
		if (resolveTypeArguments)
		{
			return BaseTypes(derivedType).Any((TypeSig t) => t.Resolve() == baseType);
		}
		TypeDef typeDef = baseType.ResolveTypeDef();
		if (typeDef == null)
		{
			return false;
		}
		while (derivedType.BaseType != null)
		{
			TypeDef typeDef2 = derivedType.BaseType.Resolve();
			if (typeDef2 == null)
			{
				return false;
			}
			if (typeDef == typeDef2)
			{
				return true;
			}
			derivedType = typeDef2;
		}
		return false;
	}

	public static bool IsBaseMethod(MethodDef parentMethod, MethodDef childMethod)
	{
		if (parentMethod == null)
		{
			return false;
		}
		if (childMethod == null)
		{
			return false;
		}
		if (parentMethod.Name != childMethod.Name)
		{
			return false;
		}
		int paramCount = parentMethod.MethodSig.GetParamCount();
		int paramCount2 = childMethod.MethodSig.GetParamCount();
		if ((paramCount > 0 || paramCount2 > 0) && (paramCount == 0 || paramCount2 == 0 || paramCount != paramCount2))
		{
			return false;
		}
		return FindBaseMethods(childMethod).Any((MethodDef m) => m == parentMethod);
	}

	public static bool IsBaseProperty(PropertyDef parentProperty, PropertyDef childProperty)
	{
		if (parentProperty == null)
		{
			return false;
		}
		if (childProperty == null)
		{
			return false;
		}
		if (parentProperty.Name != childProperty.Name)
		{
			return false;
		}
		int paramCount = parentProperty.PropertySig.GetParamCount();
		int paramCount2 = childProperty.PropertySig.GetParamCount();
		if ((paramCount > 0 || paramCount2 > 0) && (paramCount == 0 || paramCount2 == 0 || paramCount != paramCount2))
		{
			return false;
		}
		return FindBaseProperties(childProperty).Any((PropertyDef m) => m == parentProperty);
	}

	public static bool IsBaseEvent(EventDef parentEvent, EventDef childEvent)
	{
		if (parentEvent == null || parentEvent.Name != childEvent.Name)
		{
			return false;
		}
		return FindBaseEvents(childEvent).Any((EventDef m) => m == parentEvent);
	}

	public static IEnumerable<MethodDef> FindBaseMethods(MethodDef method)
	{
		if (method == null)
		{
			yield break;
		}
		foreach (TypeSig baseType in BaseTypes(method.DeclaringType))
		{
			TypeDef baseTypeDef = baseType.Resolve();
			if (baseTypeDef == null)
			{
				continue;
			}
			foreach (MethodDef baseMethod in baseTypeDef.Methods)
			{
				if (MatchMethod(baseMethod, Resolve(baseMethod.MethodSig, baseType), method) && IsVisibleFromDerived(baseMethod, method.DeclaringType))
				{
					yield return baseMethod;
					if (baseMethod.IsNewSlot == baseMethod.IsVirtual)
					{
						yield break;
					}
				}
			}
		}
	}

	private static bool MatchMethod(MethodDef mCandidate, MethodBaseSig mCandidateSig, MethodDef mMethod)
	{
		if (mCandidate == null || mCandidateSig == null || mMethod == null)
		{
			return false;
		}
		if (mCandidate.Name != mMethod.Name)
		{
			return false;
		}
		if (mCandidate.HasOverrides)
		{
			return false;
		}
		if (mCandidate.IsSpecialName != mMethod.IsSpecialName)
		{
			return false;
		}
		if ((mCandidate.HasGenericParameters || mMethod.HasGenericParameters) && (!mCandidate.HasGenericParameters || !mMethod.HasGenericParameters || mCandidate.GenericParameters.Count != mMethod.GenericParameters.Count))
		{
			return false;
		}
		if (mMethod.MethodSig == null || mCandidateSig.Params.Count != mMethod.MethodSig.Params.Count)
		{
			return false;
		}
		if (mCandidate.Parameters.Count != mMethod.Parameters.Count)
		{
			return false;
		}
		for (int i = 0; i < mCandidate.Parameters.Count; i++)
		{
			Parameter parameter = mCandidate.Parameters[i];
			Parameter parameter2 = mMethod.Parameters[i];
			if (parameter.IsHiddenThisParameter != parameter2.IsHiddenThisParameter)
			{
				return false;
			}
			if (!parameter.IsHiddenThisParameter)
			{
				ParamDef paramDef = parameter.ParamDef ?? new ParamDefUser();
				ParamDef paramDef2 = parameter2.ParamDef ?? new ParamDefUser();
				if (paramDef.IsIn != paramDef2.IsIn || paramDef.IsOut != paramDef2.IsOut)
				{
					return false;
				}
			}
		}
		return default(SigComparer).Equals(mCandidateSig.Params, mMethod.MethodSig.Params);
	}

	public static bool MatchInterfaceMethod(MethodDef candidate, MethodDef method, ITypeDefOrRef interfaceContextType)
	{
		GenericInstSig genericInstSig = interfaceContextType.TryGetGenericInstSig();
		if (genericInstSig != null)
		{
			return MatchMethod(candidate, GenericArgumentResolver.Resolve(candidate?.MethodSig, genericInstSig.GenericArguments, null), method);
		}
		return MatchMethod(candidate, candidate?.MethodSig, method);
	}

	public static IEnumerable<PropertyDef> FindBaseProperties(PropertyDef property)
	{
		if (property == null || ((property.GetMethod ?? property.SetMethod)?.HasOverrides ?? false))
		{
			yield break;
		}
		bool isIndexer = property.IsIndexer();
		foreach (TypeSig baseType in BaseTypes(property.DeclaringType))
		{
			TypeDef baseTypeDef = baseType.Resolve();
			if (baseTypeDef == null)
			{
				continue;
			}
			foreach (PropertyDef baseProperty in baseTypeDef.Properties)
			{
				if (MatchProperty(baseProperty, Resolve(baseProperty.PropertySig, baseType), property) && IsVisibleFromDerived(baseProperty, property.DeclaringType) && isIndexer == baseProperty.IsIndexer())
				{
					yield return baseProperty;
					MethodDef anyPropertyAccessor = baseProperty.GetMethod ?? baseProperty.SetMethod;
					if (anyPropertyAccessor != null && anyPropertyAccessor.IsNewSlot == anyPropertyAccessor.IsVirtual)
					{
						yield break;
					}
				}
			}
		}
	}

	private static bool MatchProperty(PropertyDef mCandidate, MethodBaseSig mCandidateSig, PropertyDef mProperty)
	{
		if (mCandidate == null || mCandidateSig == null || mProperty == null)
		{
			return false;
		}
		if (mCandidate.Name != mProperty.Name)
		{
			return false;
		}
		MethodDef methodDef = mCandidate.GetMethod ?? mCandidate.SetMethod;
		if (methodDef != null && methodDef.HasOverrides)
		{
			return false;
		}
		if (mProperty.PropertySig == null || mCandidateSig.GenParamCount != mProperty.PropertySig.GenParamCount)
		{
			return false;
		}
		return default(SigComparer).Equals(mCandidateSig.Params, mProperty.PropertySig.Params);
	}

	public static IEnumerable<EventDef> FindBaseEvents(EventDef eventDef)
	{
		if (eventDef == null)
		{
			yield break;
		}
		TypeSig eventType = eventDef.EventType.ToTypeSig();
		foreach (TypeSig baseType in BaseTypes(eventDef.DeclaringType))
		{
			TypeDef baseTypeDef = baseType.Resolve();
			if (baseTypeDef == null)
			{
				continue;
			}
			foreach (EventDef baseEvent in baseTypeDef.Events)
			{
				if (MatchEvent(baseEvent, Resolve(baseEvent.EventType.ToTypeSig(), baseType), eventDef, eventType) && IsVisibleFromDerived(baseEvent, eventDef.DeclaringType))
				{
					yield return baseEvent;
					MethodDef anyEventAccessor = baseEvent.AddMethod ?? baseEvent.RemoveMethod;
					if (anyEventAccessor != null && anyEventAccessor.IsNewSlot == anyEventAccessor.IsVirtual)
					{
						yield break;
					}
				}
			}
		}
	}

	private static bool MatchEvent(EventDef mCandidate, TypeSig mCandidateType, EventDef mEvent, TypeSig mEventType)
	{
		if (mCandidate == null || mCandidateType == null || mEvent == null || mEventType == null)
		{
			return false;
		}
		if (mCandidate.Name != mEvent.Name)
		{
			return false;
		}
		MethodDef methodDef = mCandidate.AddMethod ?? mCandidate.RemoveMethod;
		if (methodDef == null || methodDef.HasOverrides)
		{
			return false;
		}
		if (!default(SigComparer).Equals(mCandidateType, mEventType))
		{
			return false;
		}
		return true;
	}

	public static bool IsVisibleFromDerived(IMemberDef baseMember, TypeDef derivedType)
	{
		if (baseMember == null)
		{
			return false;
		}
		if (derivedType == null)
		{
			return false;
		}
		MethodAttributes methodAttributes = GetAccessAttributes(baseMember) & MethodAttributes.MemberAccessMask;
		if (methodAttributes == MethodAttributes.Private)
		{
			return false;
		}
		if (baseMember.DeclaringType.Module == derivedType.Module)
		{
			return true;
		}
		if (methodAttributes == MethodAttributes.Assembly || methodAttributes == MethodAttributes.FamANDAssem)
		{
			AssemblyDef assembly = derivedType.Module.Assembly;
			AssemblyDef assembly2 = baseMember.DeclaringType.Module.Assembly;
			if (assembly != null && assembly2 != null && assembly2.HasCustomAttributes)
			{
				foreach (CustomAttribute customAttribute in assembly2.CustomAttributes)
				{
					if (!Compare(customAttribute.AttributeType, systemRuntimeCompilerServicesString, internalsVisibleToAttributeString) || customAttribute.ConstructorArguments.Count == 0)
					{
						continue;
					}
					string text = customAttribute.ConstructorArguments[0].Value as UTF8String;
					if (text != null)
					{
						text = text.Split(',')[0];
						if (text == assembly.Name)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
		return true;
	}

	private static bool Compare(ITypeDefOrRef type, UTF8String expNs, UTF8String expName)
	{
		if (type == null)
		{
			return false;
		}
		if (type is TypeRef typeRef)
		{
			return typeRef.Namespace == expNs && typeRef.Name == expName;
		}
		if (type is TypeDef typeDef)
		{
			return typeDef.Namespace == expNs && typeDef.Name == expName;
		}
		return false;
	}

	private static MethodAttributes GetAccessAttributes(IMemberDef member)
	{
		if (member is FieldDef fieldDef)
		{
			return (MethodAttributes)fieldDef.Attributes;
		}
		if (!(member is MethodDef { Attributes: var attributes }))
		{
			if (member is PropertyDef propertyDef)
			{
				return (propertyDef.GetMethod ?? propertyDef.SetMethod)?.Attributes ?? MethodAttributes.PrivateScope;
			}
			if (member is EventDef eventDef)
			{
				return (eventDef.AddMethod ?? eventDef.RemoveMethod)?.Attributes ?? MethodAttributes.PrivateScope;
			}
			if (member is TypeDef typeDef)
			{
				if (typeDef.IsNestedPrivate)
				{
					return MethodAttributes.Private;
				}
				if (typeDef.IsNestedAssembly || typeDef.IsNestedFamilyAndAssembly)
				{
					return MethodAttributes.Assembly;
				}
				return MethodAttributes.Public;
			}
			return MethodAttributes.PrivateScope;
		}
		return attributes;
	}

	private static IEnumerable<TypeSig> BaseTypes(TypeDef typeDef)
	{
		if (typeDef != null && typeDef.BaseType != null)
		{
			TypeSig baseType = typeDef.ToTypeSig();
			do
			{
				baseType = GenericArgumentResolver.Resolve(typeGenArgs: (baseType is GenericInstSig) ? ((GenericInstSig)baseType).GenericArguments : null, typeSig: typeDef.BaseType.ToTypeSig(), methodGenArgs: null);
				yield return baseType;
				typeDef = typeDef.BaseType.ResolveTypeDef();
			}
			while (typeDef != null && typeDef.BaseType != null);
		}
	}

	private static TypeSig Resolve(TypeSig type, TypeSig typeContext)
	{
		IList<TypeSig> typeGenArgs = ((typeContext is GenericInstSig) ? ((GenericInstSig)typeContext).GenericArguments : null);
		return GenericArgumentResolver.Resolve(type, typeGenArgs, null);
	}

	private static MethodBaseSig Resolve(MethodBaseSig method, TypeSig typeContext)
	{
		IList<TypeSig> typeGenArgs = ((typeContext is GenericInstSig) ? ((GenericInstSig)typeContext).GenericArguments : null);
		return GenericArgumentResolver.Resolve(method, typeGenArgs, null);
	}
}
