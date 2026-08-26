namespace DevX.Cecil.Signatures
{
	internal sealed class MethodSpec
	{
		public GenericInstSignature Signature;

		public MethodSpec(GenericInstSignature sig)
		{
			Signature = sig;
		}
	}
}
