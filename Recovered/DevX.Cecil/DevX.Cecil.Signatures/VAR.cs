using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class VAR : SigType
	{
		public int Index;

		public VAR(int index)
			: base(ElementType.Var)
		{
			Index = index;
		}
	}
}
