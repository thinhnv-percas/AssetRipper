namespace DevX.Cecil
{
	public sealed class PointerType : TypeSpecification
	{
		public override string Name => base.Name + "*";

		public override string FullName => base.FullName + "*";

		public PointerType(TypeReference pType)
			: base(pType)
		{
		}
	}
}
