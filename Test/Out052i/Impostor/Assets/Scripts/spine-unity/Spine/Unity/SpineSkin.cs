using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000BB")]
	public class SpineSkin : SpineAttributeBase
	{
		[Token(Token = "0x4000432")]
		[FieldOffset(Offset = "0x22")]
		public bool defaultAsEmptyString;

		[Token(Token = "0x60006B2")]
		[Address(RVA = "0x1570BF0", Offset = "0x1570BF0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.dataField = dataField;\n\tthis.startsWith = startsWith;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\tthis.defaultAsEmptyString = defaultAsEmptyString;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineSkin(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false, bool defaultAsEmptyString = false)
		{
			base.dataField = dataField;
			base.startsWith = startsWith;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
			this.defaultAsEmptyString = defaultAsEmptyString;
		}
	}
}
