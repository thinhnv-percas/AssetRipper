using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x200003A")]
	public struct UventIAPStoreProductNotFound : IEvent
	{
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x0")]
		public readonly string bundleId;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x8")]
		public readonly string sourceType;

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x3C67920", Offset = "0x3C67920", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.bundleId = bundleId;\n\tthis.sourceType = sourceType;\n\treturn;\n")]
		public UventIAPStoreProductNotFound(string bundleId, string sourceType)
		{
			this.bundleId = bundleId;
			this.sourceType = sourceType;
		}
	}
}
