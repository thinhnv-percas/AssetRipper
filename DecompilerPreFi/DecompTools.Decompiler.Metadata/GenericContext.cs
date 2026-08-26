using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace DecompTools.Decompiler.Metadata;

public class GenericContext
{
	private readonly PEFile module;

	private readonly TypeDefinitionHandle declaringType;

	private readonly MethodDefinitionHandle method;

	public static readonly GenericContext Empty = new GenericContext();

	private GenericContext()
	{
	}

	public GenericContext(MethodDefinitionHandle method, PEFile module)
	{
		this.module = module;
		this.method = method;
		declaringType = module.Metadata.GetMethodDefinition(method).GetDeclaringType();
	}

	public GenericContext(TypeDefinitionHandle declaringType, PEFile module)
	{
		this.module = module;
		this.declaringType = declaringType;
	}

	public string GetGenericTypeParameterName(int index)
	{
		GenericParameterHandle genericTypeParameterHandleOrNull = GetGenericTypeParameterHandleOrNull(index);
		if (genericTypeParameterHandleOrNull.IsNil)
		{
			return index.ToString();
		}
		return module.Metadata.GetString(module.Metadata.GetGenericParameter(genericTypeParameterHandleOrNull).Name);
	}

	public string GetGenericMethodTypeParameterName(int index)
	{
		GenericParameterHandle genericMethodTypeParameterHandleOrNull = GetGenericMethodTypeParameterHandleOrNull(index);
		if (genericMethodTypeParameterHandleOrNull.IsNil)
		{
			return index.ToString();
		}
		return module.Metadata.GetString(module.Metadata.GetGenericParameter(genericMethodTypeParameterHandleOrNull).Name);
	}

	public GenericParameterHandle GetGenericTypeParameterHandleOrNull(int index)
	{
		if (!declaringType.IsNil && index >= 0)
		{
			GenericParameterHandleCollection genericParameters;
			GenericParameterHandleCollection genericParameterHandleCollection = (genericParameters = module.Metadata.GetTypeDefinition(declaringType).GetGenericParameters());
			if (index < genericParameterHandleCollection.Count)
			{
				return genericParameters[index];
			}
		}
		return MetadataTokens.GenericParameterHandle(0);
	}

	public GenericParameterHandle GetGenericMethodTypeParameterHandleOrNull(int index)
	{
		if (!method.IsNil && index >= 0)
		{
			GenericParameterHandleCollection genericParameters;
			GenericParameterHandleCollection genericParameterHandleCollection = (genericParameters = module.Metadata.GetMethodDefinition(method).GetGenericParameters());
			if (index < genericParameterHandleCollection.Count)
			{
				return genericParameters[index];
			}
		}
		return MetadataTokens.GenericParameterHandle(0);
	}
}
