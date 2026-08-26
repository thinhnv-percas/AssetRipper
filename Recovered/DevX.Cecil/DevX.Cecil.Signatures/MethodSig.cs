namespace DevX.Cecil.Signatures
{
	internal abstract class MethodSig : Signature
	{
		public bool HasThis;

		public bool ExplicitThis;

		public MethodCallingConvention MethCallConv;

		public int ParamCount;

		public RetType RetType;

		public Param[] Parameters;

		public MethodSig()
		{
		}

		public MethodSig(uint blobIndex)
			: base(blobIndex)
		{
		}
	}
}
