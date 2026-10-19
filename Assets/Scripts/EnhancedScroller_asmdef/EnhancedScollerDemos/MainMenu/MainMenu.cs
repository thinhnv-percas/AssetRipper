using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnhancedScollerDemos.MainMenu
{
	[Token(Token = "0x200001B")]
	public class MainMenu : MonoBehaviour
	{
		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x40238F8", Offset = "0x40238F8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001D;\nL_001D:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(sceneName);\n\treturn;\n")]
		public void SceneButton_OnClick(string sceneName)
		{
			SceneManager.LoadScene(sceneName);
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x4023980", Offset = "0x4023980", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MainMenu()
		{
		}
	}
}
