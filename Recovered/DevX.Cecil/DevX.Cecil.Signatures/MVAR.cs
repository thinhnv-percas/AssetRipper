using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class MVAR : SigType
	{
		public int Index;

		public MVAR(int index)
			: base(ElementType.MVar)
		{
			Index = index;
		}
	}
}
