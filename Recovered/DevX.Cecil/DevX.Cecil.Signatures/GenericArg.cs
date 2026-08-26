namespace DevX.Cecil.Signatures
{
	internal sealed class GenericArg
	{
		public CustomMod[] CustomMods;

		public SigType Type;

		public GenericArg(SigType type)
		{
			Type = type;
		}
	}
}
