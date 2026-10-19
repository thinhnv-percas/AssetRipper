using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000013")]
	public abstract class ImageView : MonoBehaviour
	{
		[Token(Token = "0x600003F")]
		public abstract void SetImage(Sprite sprite);

		[Token(Token = "0x6000040")]
		public abstract void SetColor(Color color);

		[Token(Token = "0x6000041")]
		public abstract Sprite GetImage();

		[Token(Token = "0x6000042")]
		public abstract void SetActive(bool isActive);

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81C1CC0", Offset = "0x81C1CC0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal ImageView()
		{
		}
	}
}
