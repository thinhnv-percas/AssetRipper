using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class FNPTR : SigType
	{
		public MethodSig Method;

		public FNPTR()
			: base(ElementType.FnPtr)
		{
		}
	}
}
