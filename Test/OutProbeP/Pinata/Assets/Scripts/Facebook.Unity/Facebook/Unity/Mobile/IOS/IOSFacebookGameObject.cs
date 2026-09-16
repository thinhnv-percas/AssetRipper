using AssetRipperInjected;
using Cpp2ILInjected;

namespace Facebook.Unity.Mobile.IOS
{
	[Token(Token = "0x2000066")]
	internal class IOSFacebookGameObject : MobileFacebookGameObject
	{
		[Token(Token = "0x600027E")]
		[Address(RVA = "0xD33894", Offset = "0xD33894", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IOSFacebookGameObject()
		{
		}
	}
}
