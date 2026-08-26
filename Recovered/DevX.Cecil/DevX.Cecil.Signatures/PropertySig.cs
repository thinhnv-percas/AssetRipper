namespace DevX.Cecil.Signatures
{
	internal sealed class PropertySig : Signature
	{
		public bool Property;

		public int ParamCount;

		public CustomMod[] CustomMods;

		public SigType Type;

		public Param[] Parameters;

		public PropertySig()
		{
		}

		public PropertySig(uint blobIndex)
			: base(blobIndex)
		{
		}

		public override void Accept(ISignatureVisitor visitor)
		{
			visitor.VisitPropertySig(this);
		}
	}
}
