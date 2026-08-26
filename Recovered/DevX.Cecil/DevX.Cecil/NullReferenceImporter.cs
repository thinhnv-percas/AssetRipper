namespace DevX.Cecil
{
	internal sealed class NullReferenceImporter : IImporter
	{
		public static readonly NullReferenceImporter Instance = new NullReferenceImporter();

		public TypeReference ImportTypeReference(TypeReference type, ImportContext context)
		{
			return type;
		}

		public FieldReference ImportFieldReference(FieldReference field, ImportContext context)
		{
			return field;
		}

		public MethodReference ImportMethodReference(MethodReference method, ImportContext context)
		{
			return method;
		}
	}
}
