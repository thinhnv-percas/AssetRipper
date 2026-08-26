using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class PTR : SigType
	{
		public CustomMod[] CustomMods;

		public SigType PtrType;

		public bool Void;

		public PTR()
			: base(ElementType.Ptr)
		{
		}
	}
}
