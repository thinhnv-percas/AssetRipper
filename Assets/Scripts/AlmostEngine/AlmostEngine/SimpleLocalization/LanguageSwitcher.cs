using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.SimpleLocalization
{
	[Token(Token = "0x2000073")]
	public class LanguageSwitcher : MonoBehaviour
	{
		[Token(Token = "0x6000214")]
		[Address(RVA = "0x3C4B938", Offset = "0x3C4B938", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001C;\nL_001C:\n\tAlmostEngine.SimpleLocalization.SimpleLocalizationLanguagesAsset::SetLanguage(id);\n\treturn;\n")]
		public void Set(string id)
		{
			SimpleLocalizationLanguagesAsset.SetLanguage(id);
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0x3C4B9B8", Offset = "0x3C4B9B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public LanguageSwitcher()
		{
		}
	}
}
