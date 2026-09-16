using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

[Token(Token = "0x2000004")]
public class ReloadSceneOnKeyDown : MonoBehaviour
{
	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x20")]
	public KeyCode reloadKey;

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x15086A0", Offset = "0x15086A0", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = UnityEngine.SceneManagement.SceneManager;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A379DC]) = v33;\nL_0012:\n\tv36 = UnityEngine.Input::GetKeyDown(this.reloadKey);\n\tv38 = v36 == 0;\n\tif (v38) goto L_002B;\n\tgoto L_001F;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, v35, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001F:\n\tv62 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv53 = UnityEngine.SceneManagement.Scene::get_buildIndex(&v62 @ X0_v8 (UnityEngine.SceneManagement.Scene));\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v53, 0);\nL_002B:\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKeyDown(reloadKey))
		{
			int buildIndex = SceneManager.GetActiveScene().buildIndex;
			SceneManager.LoadScene(buildIndex, default(LoadSceneMode));
		}
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x1508724", Offset = "0x1508724", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.reloadKey = 0x72;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ReloadSceneOnKeyDown()
	{
		reloadKey = KeyCode.R;
	}
}
