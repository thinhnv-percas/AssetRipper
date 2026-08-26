namespace DevX.Cecil.Signatures
{
	internal interface ISignatureVisitable
	{
		void Accept(ISignatureVisitor visitor);
	}
}
