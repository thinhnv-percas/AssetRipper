using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000BE")]
	public class SpineAtlasRegion : PropertyAttribute
	{
		[Token(Token = "0x400043B")]
		[FieldOffset(Offset = "0x10")]
		public string atlasAssetField;

		[Token(Token = "0x60006B8")]
		[Address(RVA = "0x1570F78", Offset = "0x1570F78", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.atlasAssetField = atlasAssetField;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineAtlasRegion(string atlasAssetField = "")
		{
			this.atlasAssetField = atlasAssetField;
		}
	}
}
