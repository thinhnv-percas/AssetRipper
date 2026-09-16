using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000B6")]
	public class SpineAnimation : SpineAttributeBase
	{
		[Token(Token = "0x60006AD")]
		[Address(RVA = "0x1570AA0", Offset = "0x1570AA0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.dataField = dataField;\n\tthis.startsWith = startsWith;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineAnimation(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			base.dataField = dataField;
			base.startsWith = startsWith;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
		}
	}
}
