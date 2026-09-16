using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Facebook.Unity.Mobile.Android
{
	[Token(Token = "0x200006A")]
	internal class AndroidFacebookGameObject : MobileFacebookGameObject
	{
		[Token(Token = "0x600029B")]
		[Address(RVA = "0xD31F14", Offset = "0xD31F14", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC6A8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C6F]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Debug::get_isDebugBuild();\n\tUnityEngine.AndroidJNIHelper::set_debug(v53);\n\tFacebook.Unity.CodelessIAPAutoLog::addListenerToIAPButtons(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnAwake()
		{
			bool isDebugBuild = Debug.isDebugBuild;
			AndroidJNIHelper.debug = isDebugBuild;
			CodelessIAPAutoLog.addListenerToIAPButtons(this);
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xD31F8C", Offset = "0xD31F8C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F02870]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C70]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded += value;
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xD32008", Offset = "0xD32008", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.CodelessIAPAutoLog::addListenerToIAPButtons(this);\n\treturn;\n")]
		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			CodelessIAPAutoLog.addListenerToIAPButtons(this);
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xD3200C", Offset = "0xD3200C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE5BE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C71]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded -= value;
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xD32088", Offset = "0xD32088", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.CodelessIAPAutoLog::handlePurchaseCompleted(data);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void onPurchaseCompleteHandler(object data)
		{
			CodelessIAPAutoLog.handlePurchaseCompleted(data);
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xD32090", Offset = "0xD32090", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidFacebookGameObject()
		{
		}
	}
}
