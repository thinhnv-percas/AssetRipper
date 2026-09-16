using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7582B4", Offset = "0x7582B4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7582B4", Offset = "0x7582B4")]
	[Token(Token = "0x200024D")]
	public class RestartLevel : FsmStateAction
	{
		[Token(Token = "0x6000B83")]
		[Address(RVA = "0xB24230", Offset = "0xB24230", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv15 = 0x10D454C(&v11 @ X0_v2 (UnityEngine.SceneManagement.Scene), 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v15, 0);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Scene activeScene = SceneManager.GetActiveScene();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
			string sceneName = default(string);
			SceneManager.LoadScene(sceneName, default(LoadSceneMode));
			Finish();
		}

		[Token(Token = "0x6000B84")]
		[Address(RVA = "0xB2427C", Offset = "0xB2427C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RestartLevel()
		{
		}
	}
}
