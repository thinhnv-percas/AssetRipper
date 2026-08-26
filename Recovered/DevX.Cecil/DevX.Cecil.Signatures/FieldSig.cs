namespace DevX.Cecil.Signatures
{
	internal sealed class FieldSig : Signature
	{
		public bool Field;

		public CustomMod[] CustomMods;

		public SigType Type;

		public FieldSig()
		{
		}

		public FieldSig(uint blobIndex)
			: base(blobIndex)
		{
		}

		public override void Accept(ISignatureVisitor visitor)
		{
			visitor.VisitFieldSig(this);
		}
	}
}
