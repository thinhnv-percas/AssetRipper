using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000069")]
	public class RequestAuthAtStartup : MonoBehaviour
	{
		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x3C49620", Offset = "0x3C49620", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = AlmostEngine.Screenshot.iOsUtils::HasGalleryAuthorization();\n\tv9 = v7 == 0;\n\tif (v9) goto L_0011;\n\treturn;\nL_0011:\n\tAlmostEngine.Screenshot.iOsUtils::RequestGalleryAuthorization();\n\treturn;\n")]
		private void Start()
		{
			if (!iOsUtils.HasGalleryAuthorization())
			{
				iOsUtils.RequestGalleryAuthorization();
			}
		}

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0x3C49648", Offset = "0x3C49648", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RequestAuthAtStartup()
		{
		}
	}
}
