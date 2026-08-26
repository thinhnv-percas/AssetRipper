namespace DevX.Cecil.Signatures
{
	internal abstract class InputOutputItem
	{
		public CustomMod[] CustomMods;

		public bool ByRef;

		public SigType Type;

		public bool TypedByRef;
	}
}
