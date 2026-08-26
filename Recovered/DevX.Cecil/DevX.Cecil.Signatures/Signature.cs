namespace DevX.Cecil.Signatures
{
	internal abstract class Signature : ISignatureVisitable
	{
		public byte CallingConvention;

		public uint BlobIndex;

		public Signature(uint blobIndex)
		{
			BlobIndex = blobIndex;
		}

		public Signature()
		{
			BlobIndex = 0u;
		}

		public abstract void Accept(ISignatureVisitor visitor);
	}
}
