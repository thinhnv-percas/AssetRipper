using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000030")]
	public class IAPShopEventArgs
	{
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x10")]
		public readonly string BundleId;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x18")]
		public PurchaseEventArgs PurchaseEventArgs;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x20")]
		public string Source;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x28")]
		public string MetaData;

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x3C6760C", Offset = "0x3C6760C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.BundleId = bundleId;\n\tthis.Source = source;\n\treturn;\n")]
		public IAPShopEventArgs(string bundleId, string source)
		{
			BundleId = bundleId;
			Source = source;
		}
	}
}
