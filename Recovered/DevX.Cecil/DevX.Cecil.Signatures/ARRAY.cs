using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class ARRAY : SigType
	{
		public CustomMod[] CustomMods;

		public SigType Type;

		public ArrayShape Shape;

		public ARRAY()
			: base(ElementType.Array)
		{
		}
	}
}
