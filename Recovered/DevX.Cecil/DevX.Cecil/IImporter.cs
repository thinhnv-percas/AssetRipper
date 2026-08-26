namespace DevX.Cecil
{
	public interface IImporter
	{
		TypeReference ImportTypeReference(TypeReference type, ImportContext context);

		FieldReference ImportFieldReference(FieldReference field, ImportContext context);

		MethodReference ImportMethodReference(MethodReference method, ImportContext context);
	}
}
