namespace DevX.Cecil
{
	public sealed class ModifierOptional : ModType
	{
		protected override string ModifierName => "modopt";

		public ModifierOptional(TypeReference elemType, TypeReference modType)
			: base(elemType, modType)
		{
		}
	}
}
