using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnhancedScrollerDemos.MainMenu
{
	[Token(Token = "0x200001C")]
	public class ReturnToMainMenu : MonoBehaviour
	{
		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x4023988", Offset = "0x4023988", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv45 = 0xB2F7000 + 0x610;\n\tgoto L_001A;\nL_001A:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(*([v45 @ X20_v6 (System.Int32)]));\n\treturn;\n")]
		public void ReturnToMainMenuButton_OnClick()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ReturnToMainMenu::ReturnToMainMenuButton_OnClick");
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x4023A1C", Offset = "0x4023A1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ReturnToMainMenu()
		{
		}
	}
}
