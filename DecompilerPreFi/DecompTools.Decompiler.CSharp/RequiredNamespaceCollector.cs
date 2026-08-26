using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.CSharp;

internal class RequiredNamespaceCollector
{
	private static readonly DecompTools.Decompiler.TypeSystem.GenericContext genericContext = default(DecompTools.Decompiler.TypeSystem.GenericContext);

	public static void CollectNamespaces(MetadataModule module, HashSet<string> namespaces)
	{
		foreach (ITypeDefinition typeDefinition in module.TypeDefinitions)
		{
			CollectNamespaces(typeDefinition, module, namespaces);
		}
		CollectAttributeNamespaces(module, namespaces);
	}

	public static void CollectAttributeNamespaces(MetadataModule module, HashSet<string> namespaces)
	{
		HandleAttributes(module.GetAssemblyAttributes(), namespaces);
		HandleAttributes(module.GetModuleAttributes(), namespaces);
	}

	public static void CollectNamespaces(IEntity entity, MetadataModule module, HashSet<string> namespaces, CodeMappingInfo mappingInfo = null)
	{
		if (entity == null || entity.MetadataToken.IsNil)
		{
			return;
		}
		if (entity == null)
		{
			return;
		}
		if (!(entity is ITypeDefinition typeDefinition))
		{
			if (!(entity is IField field))
			{
				if (!(entity is IMethod method))
				{
					if (!(entity is IProperty property))
					{
						if (entity is IEvent obj)
						{
							IEvent obj2 = obj;
							HandleAttributes(obj2.GetAttributes(), namespaces);
							CollectNamespaces(obj2.AddAccessor, module, namespaces);
							CollectNamespaces(obj2.RemoveAccessor, module, namespaces);
						}
					}
					else
					{
						IProperty property2 = property;
						HandleAttributes(property2.GetAttributes(), namespaces);
						CollectNamespaces(property2.Getter, module, namespaces);
						CollectNamespaces(property2.Setter, module, namespaces);
					}
					return;
				}
				IMethod method2 = method;
				HandleAttributes(method2.GetAttributes(), namespaces);
				HandleAttributes(method2.GetReturnTypeAttributes(), namespaces);
				CollectNamespacesForTypeReference(method2.ReturnType, namespaces);
				foreach (IParameter parameter in method2.Parameters)
				{
					HandleAttributes(parameter.GetAttributes(), namespaces);
					CollectNamespacesForTypeReference(parameter.Type, namespaces);
				}
				HandleTypeParameters(method2.TypeParameters, namespaces);
				if (method2.MetadataToken.IsNil)
				{
					return;
				}
				if (mappingInfo == null)
				{
					mappingInfo = CSharpDecompiler.GetCodeMappingInfo(entity.ParentModule.PEFile, entity.MetadataToken);
				}
				PEReader reader = module.PEFile.Reader;
				List<MethodDefinitionHandle> list = Enumerable.ToList<MethodDefinitionHandle>(mappingInfo.GetMethodParts((MethodDefinitionHandle)method2.MetadataToken));
				{
					foreach (MethodDefinitionHandle item in list)
					{
						HandleOverrides(item.GetMethodImplementations(module.metadata), module, namespaces);
						MethodDefinition methodDefinition = module.metadata.GetMethodDefinition(item);
						if (method2.HasBody)
						{
							MethodBodyBlock methodBody;
							try
							{
								methodBody = reader.GetMethodBody(methodDefinition.RelativeVirtualAddress);
							}
							catch (BadImageFormatException)
							{
								continue;
							}
							CollectNamespacesFromMethodBody(methodBody, module, namespaces);
						}
					}
					return;
				}
			}
			IField field2 = field;
			HandleAttributes(field2.GetAttributes(), namespaces);
			CollectNamespacesForTypeReference(field2.ReturnType, namespaces);
			return;
		}
		ITypeDefinition typeDefinition2 = typeDefinition;
		if (mappingInfo == null)
		{
			mappingInfo = CSharpDecompiler.GetCodeMappingInfo(entity.ParentModule.PEFile, entity.MetadataToken);
		}
		namespaces.Add(typeDefinition2.Namespace);
		HandleAttributes(typeDefinition2.GetAttributes(), namespaces);
		HandleTypeParameters(typeDefinition2.TypeParameters, namespaces);
		foreach (IType directBaseType in typeDefinition2.DirectBaseTypes)
		{
			CollectNamespacesForTypeReference(directBaseType, namespaces);
		}
		foreach (ITypeDefinition nestedType in typeDefinition2.NestedTypes)
		{
			CollectNamespaces(nestedType, module, namespaces, mappingInfo);
		}
		foreach (IField field3 in typeDefinition2.Fields)
		{
			CollectNamespaces(field3, module, namespaces, mappingInfo);
		}
		foreach (IProperty property3 in typeDefinition2.Properties)
		{
			CollectNamespaces(property3, module, namespaces, mappingInfo);
		}
		foreach (IEvent @event in typeDefinition2.Events)
		{
			CollectNamespaces(@event, module, namespaces, mappingInfo);
		}
		foreach (IMethod method3 in typeDefinition2.Methods)
		{
			CollectNamespaces(method3, module, namespaces, mappingInfo);
		}
	}

	private static void HandleOverrides(ImmutableArray<MethodImplementationHandle> immutableArray, MetadataModule module, HashSet<string> namespaces)
	{
		foreach (MethodImplementationHandle item in immutableArray)
		{
			MethodImplementation methodImplementation = module.metadata.GetMethodImplementation(item);
			CollectNamespacesForTypeReference(module.ResolveType(methodImplementation.Type, genericContext), namespaces);
			CollectNamespacesForMemberReference(module.ResolveMethod(methodImplementation.MethodBody, genericContext), module, namespaces);
			CollectNamespacesForMemberReference(module.ResolveMethod(methodImplementation.MethodDeclaration, genericContext), module, namespaces);
		}
	}

	private static void CollectNamespacesForTypeReference(IType type, HashSet<string> namespaces)
	{
		if (type != null)
		{
			if (type is ParameterizedType parameterizedType)
			{
				ParameterizedType parameterizedType2 = parameterizedType;
				namespaces.Add(parameterizedType2.Namespace);
				CollectNamespacesForTypeReference(parameterizedType2.GenericType, namespaces);
				{
					foreach (IType typeArgument in parameterizedType2.TypeArguments)
					{
						CollectNamespacesForTypeReference(typeArgument, namespaces);
					}
					return;
				}
			}
			if (type is TypeWithElementType typeWithElementType)
			{
				TypeWithElementType typeWithElementType2 = typeWithElementType;
				CollectNamespacesForTypeReference(typeWithElementType2.ElementType, namespaces);
				return;
			}
			if (type is TupleType tupleType)
			{
				TupleType tupleType2 = tupleType;
				foreach (IType elementType in tupleType2.ElementTypes)
				{
					CollectNamespacesForTypeReference(elementType, namespaces);
				}
				return;
			}
		}
		namespaces.Add(type.Namespace);
	}

	public static void CollectNamespaces(EntityHandle entity, MetadataModule module, HashSet<string> namespaces)
	{
		if (!entity.IsNil)
		{
			CollectNamespaces(module.ResolveEntity(entity, genericContext), module, namespaces);
		}
	}

	public static void HandleAttributes(IEnumerable<IAttribute> attributes, HashSet<string> namespaces)
	{
		foreach (IAttribute attribute in attributes)
		{
			namespaces.Add(attribute.AttributeType.Namespace);
			foreach (CustomAttributeTypedArgument<IType> fixedArgument in attribute.FixedArguments)
			{
				HandleAttributeValue(fixedArgument.Type, fixedArgument.Value, namespaces);
			}
			foreach (CustomAttributeNamedArgument<IType> namedArgument in attribute.NamedArguments)
			{
				HandleAttributeValue(namedArgument.Type, namedArgument.Value, namespaces);
			}
		}
	}

	private static void HandleAttributeValue(IType type, object value, HashSet<string> namespaces)
	{
		CollectNamespacesForTypeReference(type, namespaces);
		if (value is IType type2)
		{
			CollectNamespacesForTypeReference(type2, namespaces);
		}
		if (value is ImmutableArray<CustomAttributeTypedArgument<IType>> immutableArray)
		{
			foreach (CustomAttributeTypedArgument<IType> item in immutableArray)
			{
				HandleAttributeValue(item.Type, item.Value, namespaces);
			}
		}
	}

	private static void HandleTypeParameters(IEnumerable<ITypeParameter> typeParameters, HashSet<string> namespaces)
	{
		foreach (ITypeParameter typeParameter in typeParameters)
		{
			HandleAttributes(typeParameter.GetAttributes(), namespaces);
			foreach (IType directBaseType in typeParameter.DirectBaseTypes)
			{
				CollectNamespacesForTypeReference(directBaseType, namespaces);
			}
		}
	}

	private static void CollectNamespacesFromMethodBody(MethodBodyBlock method, MetadataModule module, HashSet<string> namespaces)
	{
		MetadataReader metadata = module.metadata;
		BlobReader blob = method.GetILReader();
		if (!method.LocalSignature.IsNil)
		{
			ImmutableArray<IType> immutableArray;
			try
			{
				immutableArray = module.DecodeLocalSignature(method.LocalSignature, genericContext);
			}
			catch (BadImageFormatException)
			{
				immutableArray = ImmutableArray<IType>.Empty;
			}
			foreach (IType item in immutableArray)
			{
				CollectNamespacesForTypeReference(item, namespaces);
			}
		}
		foreach (ExceptionRegion exceptionRegion in method.ExceptionRegions)
		{
			if (!exceptionRegion.CatchType.IsNil)
			{
				IType type;
				try
				{
					type = module.ResolveType(exceptionRegion.CatchType, genericContext);
				}
				catch (BadImageFormatException)
				{
					continue;
				}
				CollectNamespacesForTypeReference(type, namespaces);
			}
		}
		while (blob.RemainingBytes > 0)
		{
			ILOpCode opCode;
			try
			{
				opCode = blob.DecodeOpCode();
			}
			catch (BadImageFormatException)
			{
				break;
			}
			switch (opCode.GetOperandType())
			{
			case OperandType.Field:
			case OperandType.Method:
			case OperandType.Sig:
			case OperandType.Tok:
			case OperandType.Type:
			{
				EntityHandle entityHandle = MetadataTokenHelpers.EntityHandleOrNil(blob.ReadInt32());
				if (entityHandle.IsNil)
				{
					break;
				}
				switch (entityHandle.Kind)
				{
				case HandleKind.TypeReference:
				case HandleKind.TypeDefinition:
				case HandleKind.TypeSpecification:
				{
					IType type2;
					try
					{
						type2 = module.ResolveType(entityHandle, genericContext);
					}
					catch (BadImageFormatException)
					{
						break;
					}
					CollectNamespacesForTypeReference(type2, namespaces);
					break;
				}
				case HandleKind.FieldDefinition:
				case HandleKind.MethodDefinition:
				case HandleKind.MemberReference:
				case HandleKind.MethodSpecification:
				{
					IMember member;
					try
					{
						member = module.ResolveEntity(entityHandle, genericContext) as IMember;
					}
					catch (BadImageFormatException)
					{
						break;
					}
					CollectNamespacesForMemberReference(member, module, namespaces);
					break;
				}
				case HandleKind.StandaloneSignature:
				{
					StandaloneSignature standaloneSignature;
					try
					{
						standaloneSignature = metadata.GetStandaloneSignature((StandaloneSignatureHandle)entityHandle);
					}
					catch (BadImageFormatException)
					{
						break;
					}
					if (standaloneSignature.GetKind() == StandaloneSignatureKind.Method)
					{
						MethodSignature<IType> methodSignature;
						try
						{
							methodSignature = module.DecodeMethodSignature((StandaloneSignatureHandle)entityHandle, genericContext);
						}
						catch (BadImageFormatException)
						{
							break;
						}
						CollectNamespacesForTypeReference(methodSignature.ReturnType, namespaces);
						foreach (IType parameterType in methodSignature.ParameterTypes)
						{
							CollectNamespacesForTypeReference(parameterType, namespaces);
						}
					}
					break;
				}
				}
				break;
			}
			default:
				try
				{
					blob.SkipOperand(opCode);
				}
				catch (BadImageFormatException)
				{
					return;
				}
				break;
			}
		}
	}

	private static void CollectNamespacesForMemberReference(IMember member, MetadataModule module, HashSet<string> namespaces)
	{
		if (member == null)
		{
			return;
		}
		if (!(member is IField field))
		{
			if (!(member is IMethod method))
			{
				return;
			}
			IMethod method2 = method;
			CollectNamespacesForTypeReference(method2.DeclaringType, namespaces);
			CollectNamespacesForTypeReference(method2.ReturnType, namespaces);
			foreach (IParameter parameter in method2.Parameters)
			{
				CollectNamespacesForTypeReference(parameter.Type, namespaces);
			}
			{
				foreach (IType typeArgument in method2.TypeArguments)
				{
					CollectNamespacesForTypeReference(typeArgument, namespaces);
				}
				return;
			}
		}
		IField field2 = field;
		CollectNamespacesForTypeReference(field2.DeclaringType, namespaces);
		CollectNamespacesForTypeReference(field2.ReturnType, namespaces);
	}
}
