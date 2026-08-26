using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class SZARRAY : SigType
	{
		public CustomMod[] CustomMods;

		public SigType Type;

		public SZARRAY()
			: base(ElementType.SzArray)
		{
		}
	}
}
