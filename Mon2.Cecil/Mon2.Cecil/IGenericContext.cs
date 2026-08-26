namespace Mon2.Cecil;

internal interface IGenericContext
{
	bool IsDefinition { get; }

	IGenericParameterProvider Type { get; }

	IGenericParameterProvider Method { get; }
}
