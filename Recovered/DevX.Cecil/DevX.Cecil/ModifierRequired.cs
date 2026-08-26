namespace DevX.Cecil
{
	public sealed class ModifierRequired : ModType
	{
		protected override string ModifierName => "modreq";

		public ModifierRequired(TypeReference elemType, TypeReference modType)
			: base(elemType, modType)
		{
		}
	}
}
