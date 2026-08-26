using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class CustomMod
	{
		public enum CMODType : byte
		{
			None = 0,
			OPT = 0x20,
			REQD = 0x1F
		}

		public static CustomMod[] EmptyCustomMod = new CustomMod[0];

		public CMODType CMOD;

		public MetadataToken TypeDefOrRef;
	}
}
