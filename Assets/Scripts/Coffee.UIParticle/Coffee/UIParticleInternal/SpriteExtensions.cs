using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleInternal
{
	[Token(Token = "0x2000007")]
	internal static class SpriteExtensions
	{
		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3F1F6A0", Offset = "0x3F1F6A0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = UnityEngine.Object::op_Implicit(self);\n\tv58 = ~v51;\n\tif (v58) goto L_003F;\n\treturnVal2 = UnityEngine.Sprite::get_texture(self);\n\treturn returnVal2;\nL_003F:\n\treturn 0;\n")]
		internal static Texture2D GetActualTexture(this Sprite self)
		{
			if ((bool)self)
			{
				return self.texture;
			}
			return null;
		}
	}
}
