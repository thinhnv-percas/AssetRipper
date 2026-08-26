namespace DevX.Cecil
{
	public sealed class ReferenceType : TypeSpecification
	{
		public override string Name => base.Name + "&";

		public override string FullName => base.FullName + "&";

		public ReferenceType(TypeReference type)
			: base(type)
		{
		}
	}
}
