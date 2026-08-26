using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

public static class TypeSystemExtensions
{
	private sealed class TypeClassificationVisitor : TypeVisitor
	{
		internal bool isOpen;

		internal IEntity typeParameterOwner;

		private int typeParameterOwnerNestingLevel;

		public override IType VisitTypeParameter(ITypeParameter type)
		{
			isOpen = true;
			int nestingLevel = GetNestingLevel(type.Owner);
			if (nestingLevel > typeParameterOwnerNestingLevel)
			{
				typeParameterOwner = type.Owner;
				typeParameterOwnerNestingLevel = nestingLevel;
			}
			return base.VisitTypeParameter(type);
		}

		private static int GetNestingLevel(IEntity entity)
		{
			int num = 0;
			while (entity != null)
			{
				num = checked(num + 1);
				entity = entity.DeclaringTypeDefinition;
			}
			return num;
		}
	}

	public static IEnumerable<IType> GetAllBaseTypes(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		BaseTypeCollector baseTypeCollector = new BaseTypeCollector();
		baseTypeCollector.CollectBaseTypes(type);
		return baseTypeCollector;
	}

	public static IEnumerable<IType> GetNonInterfaceBaseTypes(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		BaseTypeCollector baseTypeCollector = new BaseTypeCollector();
		baseTypeCollector.SkipImplementedInterfaces = true;
		baseTypeCollector.CollectBaseTypes(type);
		return baseTypeCollector;
	}

	public static IEnumerable<ITypeDefinition> GetAllBaseTypeDefinitions(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return Enumerable.Distinct<ITypeDefinition>(Enumerable.Where<ITypeDefinition>(Enumerable.Select<IType, ITypeDefinition>(type.GetAllBaseTypes(), (Func<IType, ITypeDefinition>)((IType t) => t.GetDefinition())), (Func<ITypeDefinition, bool>)((ITypeDefinition d) => d != null)));
	}

	public static bool IsDerivedFrom(this ITypeDefinition type, ITypeDefinition baseType)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (baseType == null)
		{
			return false;
		}
		if (type.Compilation != baseType.Compilation)
		{
			throw new InvalidOperationException("Both arguments to IsDerivedFrom() must be from the same compilation.");
		}
		return Enumerable.Contains<ITypeDefinition>(type.GetAllBaseTypeDefinitions(), baseType);
	}

	public static bool IsDerivedFrom(this ITypeDefinition type, KnownTypeCode baseType)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (baseType == KnownTypeCode.None)
		{
			return false;
		}
		return type.IsDerivedFrom(type.Compilation.FindType(baseType).GetDefinition());
	}

	public static IEnumerable<ITypeDefinition> GetDeclaringTypeDefinitions(this ITypeDefinition definition)
	{
		if (definition == null)
		{
			throw new ArgumentNullException("definition");
		}
		while (definition != null)
		{
			yield return definition;
			definition = definition.DeclaringTypeDefinition;
		}
	}

	public static bool IsOpen(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		TypeClassificationVisitor typeClassificationVisitor = new TypeClassificationVisitor();
		type.AcceptVisitor(typeClassificationVisitor);
		return typeClassificationVisitor.isOpen;
	}

	private static IEntity GetTypeParameterOwner(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		TypeClassificationVisitor typeClassificationVisitor = new TypeClassificationVisitor();
		type.AcceptVisitor(typeClassificationVisitor);
		return typeClassificationVisitor.typeParameterOwner;
	}

	public static bool IsUnbound(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type is ITypeDefinition && type.TypeParameterCount > 0;
	}

	public static bool IsKnownType(this IType type, KnownTypeCode knownType)
	{
		ITypeDefinition definition = type.GetDefinition();
		return definition != null && definition.KnownTypeCode == knownType;
	}

	internal static bool IsKnownType(this IType type, KnownAttribute knownType)
	{
		return type.GetDefinition()?.FullTypeName.IsKnownType(knownType) ?? false;
	}

	public static bool IsKnownType(this FullTypeName typeName, KnownTypeCode knownType)
	{
		return typeName == KnownTypeReference.Get(knownType).TypeName;
	}

	public static bool IsKnownType(this TopLevelTypeName typeName, KnownTypeCode knownType)
	{
		return typeName == KnownTypeReference.Get(knownType).TypeName;
	}

	internal static bool IsKnownType(this FullTypeName typeName, KnownAttribute knownType)
	{
		return typeName == knownType.GetTypeName();
	}

	internal static bool IsKnownType(this TopLevelTypeName typeName, KnownAttribute knownType)
	{
		return typeName == knownType.GetTypeName();
	}

	public static IMethod GetDelegateInvokeMethod(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.Kind == TypeKind.Delegate)
		{
			return Enumerable.FirstOrDefault<IMethod>(type.GetMethods((IMethod m) => m.Name == "Invoke", GetMemberOptions.IgnoreInheritedMembers));
		}
		return null;
	}

	public static IType SkipModifiers(this IType ty)
	{
		while (ty is ModifiedType modifiedType)
		{
			ty = modifiedType.ElementType;
		}
		return ty;
	}

	public static IEnumerable<ITypeDefinition> GetAllTypeDefinitions(this ICompilation compilation)
	{
		return Enumerable.SelectMany<IModule, ITypeDefinition>((IEnumerable<IModule>)compilation.Modules, (Func<IModule, IEnumerable<ITypeDefinition>>)((IModule a) => a.TypeDefinitions));
	}

	public static IEnumerable<ITypeDefinition> GetTopLevelTypeDefinitions(this ICompilation compilation)
	{
		return Enumerable.SelectMany<IModule, ITypeDefinition>((IEnumerable<IModule>)compilation.Modules, (Func<IModule, IEnumerable<ITypeDefinition>>)((IModule a) => a.TopLevelTypeDefinitions));
	}

	public static IReadOnlyList<IType> Resolve(this IList<ITypeReference> typeReferences, ITypeResolveContext context)
	{
		if (typeReferences == null)
		{
			throw new ArgumentNullException("typeReferences");
		}
		if (typeReferences.Count == 0)
		{
			return EmptyList<IType>.Instance;
		}
		return new ProjectedList<ITypeResolveContext, ITypeReference, IType>(context, typeReferences, (ITypeResolveContext c, ITypeReference t) => t.Resolve(c));
	}

	public static IType FindType(this ICompilation compilation, FullTypeName fullTypeName)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		foreach (IModule module in compilation.Modules)
		{
			ITypeDefinition typeDefinition = module.GetTypeDefinition(fullTypeName);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
		}
		return new UnknownType(fullTypeName);
	}

	public static ITypeDefinition GetTypeDefinition(this IModule module, FullTypeName fullTypeName)
	{
		if (module == null)
		{
			throw new ArgumentNullException("assembly");
		}
		TopLevelTypeName topLevelTypeName = fullTypeName.TopLevelTypeName;
		ITypeDefinition typeDefinition = module.GetTypeDefinition(topLevelTypeName);
		if (typeDefinition == null)
		{
			return null;
		}
		int num = topLevelTypeName.TypeParameterCount;
		checked
		{
			for (int i = 0; i < fullTypeName.NestingLevel; i++)
			{
				string nestedTypeName = fullTypeName.GetNestedTypeName(i);
				num += fullTypeName.GetNestedTypeAdditionalTypeParameterCount(i);
				typeDefinition = FindNestedType(typeDefinition, nestedTypeName, num);
				if (typeDefinition == null)
				{
					break;
				}
			}
			return typeDefinition;
		}
	}

	private static ITypeDefinition FindNestedType(ITypeDefinition typeDef, string name, int typeParameterCount)
	{
		foreach (ITypeDefinition nestedType in typeDef.NestedTypes)
		{
			if (nestedType.Name == name && nestedType.TypeParameterCount == typeParameterCount)
			{
				return nestedType;
			}
		}
		return null;
	}

	public static bool HasAttribute(this IEntity entity, KnownAttribute attrType, bool inherit = false)
	{
		return entity.GetAttribute(attrType, inherit) != null;
	}

	public static IAttribute GetAttribute(this IEntity entity, KnownAttribute attributeType, bool inherit = false)
	{
		return Enumerable.FirstOrDefault<IAttribute>(entity.GetAttributes(inherit), (Func<IAttribute, bool>)((IAttribute a) => a.AttributeType.IsKnownType(attributeType)));
	}

	public static IEnumerable<IAttribute> GetAttributes(this IEntity entity, bool inherit)
	{
		if (inherit)
		{
			if (entity is ITypeDefinition typeDef)
			{
				return InheritanceHelper.GetAttributes(typeDef);
			}
			if (entity is IMember member)
			{
				return InheritanceHelper.GetAttributes(member);
			}
			throw new NotSupportedException("Unknown entity type");
		}
		return entity.GetAttributes();
	}

	public static bool HasAttribute(this IParameter parameter, KnownAttribute attrType)
	{
		return parameter.GetAttribute(attrType) != null;
	}

	public static IAttribute GetAttribute(this IParameter parameter, KnownAttribute attributeType)
	{
		return Enumerable.FirstOrDefault<IAttribute>(parameter.GetAttributes(), (Func<IAttribute, bool>)((IAttribute a) => a.AttributeType.IsKnownType(attributeType)));
	}

	public static ITypeDefinition GetTypeDefinition(this IModule module, string namespaceName, string name, int typeParameterCount = 0)
	{
		if (module == null)
		{
			throw new ArgumentNullException("assembly");
		}
		return module.GetTypeDefinition(new TopLevelTypeName(namespaceName, name, typeParameterCount));
	}

	public static ISymbol GetSymbol(this ResolveResult rr)
	{
		if (rr is LocalResolveResult)
		{
			return ((LocalResolveResult)rr).Variable;
		}
		if (rr is MemberResolveResult)
		{
			return ((MemberResolveResult)rr).Member;
		}
		if (rr is TypeResolveResult)
		{
			return ((TypeResolveResult)rr).Type.GetDefinition();
		}
		if (rr is ConversionResolveResult)
		{
			return ((ConversionResolveResult)rr).Input.GetSymbol();
		}
		return null;
	}

	public static IType GetElementTypeFromIEnumerable(this IType collectionType, ICompilation compilation, bool allowIEnumerator, out bool? isGeneric)
	{
		bool flag = false;
		foreach (IType allBaseType in collectionType.GetAllBaseTypes())
		{
			ITypeDefinition definition = allBaseType.GetDefinition();
			if (definition != null)
			{
				KnownTypeCode knownTypeCode = definition.KnownTypeCode;
				if ((knownTypeCode == KnownTypeCode.IEnumerableOfT || (allowIEnumerator && knownTypeCode == KnownTypeCode.IEnumeratorOfT)) && allBaseType is ParameterizedType parameterizedType)
				{
					isGeneric = true;
					return parameterizedType.GetTypeArgument(0);
				}
				if (knownTypeCode == KnownTypeCode.IEnumerable || (allowIEnumerator && knownTypeCode == KnownTypeCode.IEnumerator))
				{
					flag = true;
				}
			}
		}
		if (flag)
		{
			isGeneric = false;
			return compilation.FindType(KnownTypeCode.Object);
		}
		isGeneric = null;
		return SpecialType.UnknownType;
	}

	public static bool FullNameIs(this IMethod method, string type, string name)
	{
		return method.Name == name && method.DeclaringType?.FullName == type;
	}

	public static KnownAttribute IsBuiltinAttribute(this ITypeDefinition type)
	{
		return type.IsKnownAttributeType();
	}
}
