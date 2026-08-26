using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem;

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
				num++;
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
		return (from t in type.GetAllBaseTypes()
			select t.GetDefinition() into d
			where d != null
			select d).Distinct();
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
		return type.GetAllBaseTypeDefinitions().Contains(baseType);
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
		if (type is ITypeDefinition)
		{
			return type.TypeParameterCount > 0;
		}
		return false;
	}

	public static bool IsKnownType(this IType type, KnownTypeCode knownType)
	{
		ITypeDefinition definition = type.GetDefinition();
		if (definition != null)
		{
			return definition.KnownTypeCode == knownType;
		}
		return false;
	}

	public static ISymbol Import(this ICompilation compilation, ISymbol symbol)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (symbol == null)
		{
			return null;
		}
		switch (symbol.SymbolKind)
		{
		case SymbolKind.TypeParameter:
			return (ITypeParameter)compilation.Import((IType)symbol);
		case SymbolKind.Variable:
		{
			IVariable variable = (IVariable)symbol;
			return new DefaultVariable(compilation.Import(variable.Type), variable.Name, variable.Region, variable.IsConst, variable.ConstantValue);
		}
		case SymbolKind.Parameter:
		{
			IParameter parameter = (IParameter)symbol;
			if (parameter.Owner != null)
			{
				int num = parameter.Owner.Parameters.IndexOf(parameter);
				IParameterizedMember parameterizedMember = (IParameterizedMember)compilation.Import(parameter.Owner);
				if (parameterizedMember == null || num < 0 || num >= parameterizedMember.Parameters.Count)
				{
					return null;
				}
				return parameterizedMember.Parameters[num];
			}
			return new DefaultParameter(compilation.Import(parameter.Type), parameter.Name, null, parameter.Region, null, parameter.IsRef, parameter.IsOut, parameter.IsParams, isOptional: false, null, parameter.IsIn);
		}
		case SymbolKind.Namespace:
			return compilation.Import((INamespace)symbol);
		default:
			if (symbol is IEntity)
			{
				return compilation.Import((IEntity)symbol);
			}
			throw new NotSupportedException("Unsupported symbol kind: " + symbol.SymbolKind);
		}
	}

	public static IType Import(this ICompilation compilation, IType type)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (type == null)
		{
			return null;
		}
		if (type is ICompilationProvider compilationProvider && compilationProvider.Compilation == compilation)
		{
			return type;
		}
		IEntity typeParameterOwner = GetTypeParameterOwner(type);
		IEntity entity = compilation.Import(typeParameterOwner);
		if (entity != null)
		{
			return type.ToTypeReference().Resolve(new SimpleTypeResolveContext(entity));
		}
		return type.ToTypeReference().Resolve(compilation.TypeResolveContext);
	}

	public static ITypeDefinition Import(this ICompilation compilation, ITypeDefinition typeDefinition)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (typeDefinition == null)
		{
			return null;
		}
		if (typeDefinition.Compilation == compilation)
		{
			return typeDefinition;
		}
		return typeDefinition.ToTypeReference().Resolve(compilation.TypeResolveContext).GetDefinition();
	}

	public static IEntity Import(this ICompilation compilation, IEntity entity)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (entity == null)
		{
			return null;
		}
		if (entity.Compilation == compilation)
		{
			return entity;
		}
		if (entity is IMember)
		{
			return ((IMember)entity).ToReference().Resolve(compilation.TypeResolveContext);
		}
		if (entity is ITypeDefinition)
		{
			return ((ITypeDefinition)entity).ToTypeReference().Resolve(compilation.TypeResolveContext).GetDefinition();
		}
		throw new NotSupportedException("Unknown entity type");
	}

	public static IMember Import(this ICompilation compilation, IMember member)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (member == null)
		{
			return null;
		}
		if (member.Compilation == compilation)
		{
			return member;
		}
		return member.ToReference().Resolve(compilation.TypeResolveContext);
	}

	public static IMethod Import(this ICompilation compilation, IMethod method)
	{
		return (IMethod)compilation.Import((IMember)method);
	}

	public static IField Import(this ICompilation compilation, IField field)
	{
		return (IField)compilation.Import((IMember)field);
	}

	public static IEvent Import(this ICompilation compilation, IEvent ev)
	{
		return (IEvent)compilation.Import((IMember)ev);
	}

	public static IProperty Import(this ICompilation compilation, IProperty property)
	{
		return (IProperty)compilation.Import((IMember)property);
	}

	public static INamespace Import(this ICompilation compilation, INamespace ns)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (ns == null)
		{
			return null;
		}
		if (ns.ParentNamespace == null)
		{
			return compilation.GetNamespaceForExternAlias(ns.ExternAlias);
		}
		return compilation.Import(ns.ParentNamespace)?.GetChildNamespace(ns.Name);
	}

	public static IMethod GetDelegateInvokeMethod(this IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.Kind == TypeKind.Delegate)
		{
			return type.GetMethods((IUnresolvedMethod m) => m.Name == "Invoke", GetMemberOptions.IgnoreInheritedMembers).FirstOrDefault();
		}
		return null;
	}

	public static IEnumerable<IUnresolvedTypeDefinition> GetAllTypeDefinitions(this IUnresolvedFile file)
	{
		return TreeTraversal.PreOrder(file.TopLevelTypeDefinitions, (IUnresolvedTypeDefinition t) => t.NestedTypes);
	}

	public static IEnumerable<IUnresolvedTypeDefinition> GetAllTypeDefinitions(this IUnresolvedAssembly assembly)
	{
		return TreeTraversal.PreOrder(assembly.TopLevelTypeDefinitions, (IUnresolvedTypeDefinition t) => t.NestedTypes);
	}

	public static IEnumerable<ITypeDefinition> GetAllTypeDefinitions(this IAssembly assembly)
	{
		return TreeTraversal.PreOrder(assembly.TopLevelTypeDefinitions, (ITypeDefinition t) => t.NestedTypes);
	}

	public static IEnumerable<ITypeDefinition> GetAllTypeDefinitions(this ICompilation compilation)
	{
		return compilation.Assemblies.SelectMany((IAssembly a) => a.GetAllTypeDefinitions());
	}

	public static IEnumerable<ITypeDefinition> GetTopLevelTypeDefinitons(this ICompilation compilation)
	{
		return compilation.Assemblies.SelectMany((IAssembly a) => a.TopLevelTypeDefinitions);
	}

	public static IUnresolvedTypeDefinition GetInnermostTypeDefinition(this IUnresolvedFile file, int line, int column)
	{
		return file.GetInnermostTypeDefinition(new TextLocation(line, column));
	}

	public static IUnresolvedMember GetMember(this IUnresolvedFile file, int line, int column)
	{
		return file.GetMember(new TextLocation(line, column));
	}

	public static IList<IAttribute> CreateResolvedAttributes(this IList<IUnresolvedAttribute> attributes, ITypeResolveContext context)
	{
		if (attributes == null)
		{
			throw new ArgumentNullException("attributes");
		}
		if (attributes.Count == 0)
		{
			return EmptyList<IAttribute>.Instance;
		}
		return new ProjectedList<ITypeResolveContext, IUnresolvedAttribute, IAttribute>(context, attributes, (ITypeResolveContext c, IUnresolvedAttribute a) => a.CreateResolvedAttribute(c));
	}

	public static IList<ITypeParameter> CreateResolvedTypeParameters(this IList<IUnresolvedTypeParameter> typeParameters, ITypeResolveContext context)
	{
		if (typeParameters == null)
		{
			throw new ArgumentNullException("typeParameters");
		}
		if (typeParameters.Count == 0)
		{
			return EmptyList<ITypeParameter>.Instance;
		}
		return new ProjectedList<ITypeResolveContext, IUnresolvedTypeParameter, ITypeParameter>(context, typeParameters, (ITypeResolveContext c, IUnresolvedTypeParameter a) => a.CreateResolvedTypeParameter(c));
	}

	public static IList<IParameter> CreateResolvedParameters(this IList<IUnresolvedParameter> parameters, ITypeResolveContext context)
	{
		if (parameters == null)
		{
			throw new ArgumentNullException("parameters");
		}
		if (parameters.Count == 0)
		{
			return EmptyList<IParameter>.Instance;
		}
		return new ProjectedList<ITypeResolveContext, IUnresolvedParameter, IParameter>(context, parameters, (ITypeResolveContext c, IUnresolvedParameter a) => a.CreateResolvedParameter(c));
	}

	public static IList<IType> Resolve(this IList<ITypeReference> typeReferences, ITypeResolveContext context)
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

	public static IList<ResolveResult> Resolve(this IList<IConstantValue> constantValues, ITypeResolveContext context)
	{
		if (constantValues == null)
		{
			throw new ArgumentNullException("constantValues");
		}
		if (constantValues.Count == 0)
		{
			return EmptyList<ResolveResult>.Instance;
		}
		return new ProjectedList<ITypeResolveContext, IConstantValue, ResolveResult>(context, constantValues, (ITypeResolveContext c, IConstantValue t) => t.Resolve(c));
	}

	public static IEnumerable<ITypeDefinition> GetSubTypeDefinitions(this IType baseType)
	{
		if (baseType == null)
		{
			throw new ArgumentNullException("baseType");
		}
		ITypeDefinition definition = baseType.GetDefinition();
		if (definition == null)
		{
			return Enumerable.Empty<ITypeDefinition>();
		}
		return definition.GetSubTypeDefinitions();
	}

	public static IEnumerable<ITypeDefinition> GetSubTypeDefinitions(this ITypeDefinition baseType)
	{
		if (baseType == null)
		{
			throw new ArgumentNullException("baseType");
		}
		foreach (ITypeDefinition allTypeDefinition in baseType.Compilation.GetAllTypeDefinitions())
		{
			if (allTypeDefinition.IsDerivedFrom(baseType))
			{
				yield return allTypeDefinition;
			}
		}
	}

	public static IType FindType(this ICompilation compilation, FullTypeName fullTypeName)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		foreach (IAssembly assembly in compilation.Assemblies)
		{
			ITypeDefinition typeDefinition = assembly.GetTypeDefinition(fullTypeName);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
		}
		return new UnknownType(fullTypeName);
	}

	public static ITypeDefinition GetTypeDefinition(this IAssembly assembly, FullTypeName fullTypeName)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		TopLevelTypeName topLevelTypeName = fullTypeName.TopLevelTypeName;
		ITypeDefinition typeDefinition = assembly.GetTypeDefinition(topLevelTypeName);
		if (typeDefinition == null)
		{
			return null;
		}
		int num = topLevelTypeName.TypeParameterCount;
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

	public static IType Resolve(this ITypeReference reference, ICompilation compilation)
	{
		if (reference == null)
		{
			throw new ArgumentNullException("reference");
		}
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		return reference.Resolve(compilation.TypeResolveContext);
	}

	public static IAttribute GetAttribute(this IEntity entity, IType attributeType, bool inherit = true)
	{
		return entity.GetAttributes(attributeType, inherit).FirstOrDefault();
	}

	public static IEnumerable<IAttribute> GetAttributes(this IEntity entity, IType attributeType, bool inherit = true)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		if (attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		return GetAttributes(entity, attributeType.Equals, inherit);
	}

	public static IAttribute GetAttribute(this IEntity entity, FullTypeName attributeType, bool inherit = true)
	{
		return entity.GetAttributes(attributeType, inherit).FirstOrDefault();
	}

	public static IEnumerable<IAttribute> GetAttributes(this IEntity entity, FullTypeName attributeType, bool inherit = true)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		return GetAttributes(entity, delegate(IType attrType)
		{
			ITypeDefinition definition = attrType.GetDefinition();
			return definition != null && definition.FullTypeName == attributeType;
		}, inherit);
	}

	public static IEnumerable<IAttribute> GetAttributes(this IEntity entity, bool inherit = true)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		return GetAttributes(entity, (IType a) => true, inherit);
	}

	private static IEnumerable<IAttribute> GetAttributes(IEntity entity, Predicate<IType> attributeTypePredicate, bool inherit)
	{
		if (!inherit)
		{
			foreach (IAttribute attribute in entity.Attributes)
			{
				if (attributeTypePredicate(attribute.AttributeType))
				{
					yield return attribute;
				}
			}
			yield break;
		}
		if (entity is ITypeDefinition type)
		{
			foreach (IType item in type.GetNonInterfaceBaseTypes().Reverse())
			{
				ITypeDefinition definition = item.GetDefinition();
				if (definition == null)
				{
					continue;
				}
				foreach (IAttribute attribute2 in definition.Attributes)
				{
					if (attributeTypePredicate(attribute2.AttributeType))
					{
						yield return attribute2;
					}
				}
			}
			yield break;
		}
		IMember member = entity as IMember;
		if (member != null)
		{
			HashSet<IMember> visitedMembers = new HashSet<IMember>();
			IMember baseMember;
			do
			{
				member = member.MemberDefinition;
				if (!visitedMembers.Add(member))
				{
					break;
				}
				foreach (IAttribute attribute3 in member.Attributes)
				{
					if (attributeTypePredicate(attribute3.AttributeType))
					{
						yield return attribute3;
					}
				}
				if (member.IsOverride)
				{
					member = (baseMember = InheritanceHelper.GetBaseMember(member));
					continue;
				}
				break;
			}
			while (baseMember != null);
			yield break;
		}
		throw new NotSupportedException("Unknown entity type");
	}

	public static ITypeDefinition GetTypeDefinition(this IAssembly assembly, string namespaceName, string name, int typeParameterCount = 0)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		return assembly.GetTypeDefinition(new TopLevelTypeName(namespaceName, name, typeParameterCount));
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
		return null;
	}
}
