using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000B5")]
	public class SpineSlot : SpineAttributeBase
	{
		[Token(Token = "0x4000430")]
		[FieldOffset(Offset = "0x22")]
		public bool containsBoundingBoxes;

		[Token(Token = "0x60006AC")]
		[Address(RVA = "0x1570A50", Offset = "0x1570A50", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.dataField = dataField;\n\tthis.startsWith = startsWith;\n\tthis.containsBoundingBoxes = containsBoundingBoxes;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineSlot(string startsWith = "", string dataField = "", bool containsBoundingBoxes = false, bool includeNone = true, bool fallbackToTextField = false)
		{
			base.dataField = dataField;
			base.startsWith = startsWith;
			this.containsBoundingBoxes = containsBoundingBoxes;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
		}
	}
}
