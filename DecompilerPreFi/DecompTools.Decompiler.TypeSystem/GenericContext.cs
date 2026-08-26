using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public readonly struct GenericContext
{
	public readonly IReadOnlyList<ITypeParameter> ClassTypeParameters;

	public readonly IReadOnlyList<ITypeParameter> MethodTypeParameters;

	public GenericContext(IReadOnlyList<ITypeParameter> classTypeParameters)
	{
		ClassTypeParameters = classTypeParameters;
		MethodTypeParameters = null;
	}

	public GenericContext(IReadOnlyList<ITypeParameter> classTypeParameters, IReadOnlyList<ITypeParameter> methodTypeParameters)
	{
		ClassTypeParameters = classTypeParameters;
		MethodTypeParameters = methodTypeParameters;
	}

	internal GenericContext(ITypeResolveContext context)
	{
		ClassTypeParameters = context.CurrentTypeDefinition?.TypeParameters;
		MethodTypeParameters = (context.CurrentMember as IMethod)?.TypeParameters;
	}

	internal GenericContext(IEntity context)
	{
		if (context is ITypeDefinition typeDefinition)
		{
			ClassTypeParameters = typeDefinition.TypeParameters;
			MethodTypeParameters = null;
		}
		else
		{
			ClassTypeParameters = context.DeclaringTypeDefinition?.TypeParameters;
			MethodTypeParameters = (context as IMethod)?.TypeParameters;
		}
	}

	public ITypeParameter GetClassTypeParameter(int index)
	{
		if (index < ClassTypeParameters?.Count)
		{
			return ClassTypeParameters[index];
		}
		return DummyTypeParameter.GetClassTypeParameter(index);
	}

	public ITypeParameter GetMethodTypeParameter(int index)
	{
		if (index < MethodTypeParameters?.Count)
		{
			return MethodTypeParameters[index];
		}
		return DummyTypeParameter.GetMethodTypeParameter(index);
	}

	internal TypeParameterSubstitution ToSubstitution()
	{
		IReadOnlyList<ITypeParameter> classTypeParameters = ClassTypeParameters;
		IReadOnlyList<ITypeParameter> classTypeArguments = ((classTypeParameters != null && classTypeParameters.Count > 0) ? ClassTypeParameters : null);
		IReadOnlyList<ITypeParameter> methodTypeParameters = MethodTypeParameters;
		return new TypeParameterSubstitution(classTypeArguments, (methodTypeParameters != null && methodTypeParameters.Count > 0) ? MethodTypeParameters : null);
	}
}
