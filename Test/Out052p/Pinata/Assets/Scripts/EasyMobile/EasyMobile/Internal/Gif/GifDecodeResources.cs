using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Gif
{
	[Token(Token = "0x2000100")]
	internal class GifDecodeResources
	{
		[Token(Token = "0x400046D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public GCHandle gifMetadataHandle;

		[Token(Token = "0x400046E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public GCHandle[] frameMetadataHandles;

		[Token(Token = "0x400046F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public GCHandle[] imageDataHandles;

		[Token(Token = "0x4000470")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public DecodeCompleteCallback completeCallback;

		[Token(Token = "0x60008E9")]
		[Address(RVA = "0xBFE2F4", Offset = "0xBFE2F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GifDecodeResources()
		{
		}
	}
}
