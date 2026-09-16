using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000055")]
	internal class EditorFacebookGameObject : FacebookGameObject
	{
		[Token(Token = "0x6000202")]
		[Address(RVA = "0xD27FEC", Offset = "0xD27FEC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.CodelessIAPAutoLog::addListenerToIAPButtons(this);\n\treturn;\n")]
		protected override void OnAwake()
		{
			CodelessIAPAutoLog.addListenerToIAPButtons(this);
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0xD27FF0", Offset = "0xD27FF0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA4C08]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BCF]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded += value;
		}

		[Token(Token = "0x6000204")]
		[Address(RVA = "0xD2806C", Offset = "0xD2806C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.CodelessIAPAutoLog::addListenerToIAPButtons(this);\n\treturn;\n")]
		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			CodelessIAPAutoLog.addListenerToIAPButtons(this);
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0xD28070", Offset = "0xD28070", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDCE70]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BD0]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded -= value;
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0xD280EC", Offset = "0xD280EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.CodelessIAPAutoLog::handlePurchaseCompleted(data);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onPurchaseCompleteHandler(object data)
		{
			CodelessIAPAutoLog.handlePurchaseCompleted(data);
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0xD280F4", Offset = "0xD280F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EditorFacebookGameObject()
		{
		}
	}
}
