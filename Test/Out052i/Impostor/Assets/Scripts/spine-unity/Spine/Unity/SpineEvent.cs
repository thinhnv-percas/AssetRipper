using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000B7")]
	public class SpineEvent : SpineAttributeBase
	{
		[Token(Token = "0x4000431")]
		[FieldOffset(Offset = "0x22")]
		public bool audioOnly;

		[Token(Token = "0x60006AE")]
		[Address(RVA = "0x1570AE0", Offset = "0x1570AE0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.dataField = dataField;\n\tthis.startsWith = startsWith;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\tthis.audioOnly = audioOnly;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineEvent(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false, bool audioOnly = false)
		{
			base.dataField = dataField;
			base.startsWith = startsWith;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
			this.audioOnly = audioOnly;
		}
	}
}
