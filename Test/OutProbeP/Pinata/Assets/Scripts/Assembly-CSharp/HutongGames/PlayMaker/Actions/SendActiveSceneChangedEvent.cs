using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D010", Offset = "0x75D010")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D010", Offset = "0x75D010")]
	[Token(Token = "0x2000339")]
	public class SendActiveSceneChangedEvent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7DA8", Offset = "0x7C7DA8")]
		[Token(Token = "0x4001A8B")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent activeSceneChanged;

		[Token(Token = "0x4001A8C")]
		public static Scene lastPreviousActiveScene;

		[Token(Token = "0x4001A8D")]
		public static Scene lastNewActiveScene;

		[Token(Token = "0x6001021")]
		[Address(RVA = "0xB26DA4", Offset = "0xB26DA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.activeSceneChanged = 0;\n\treturn;\n")]
		public override void Reset()
		{
			activeSceneChanged = null;
		}

		[Token(Token = "0x6001022")]
		[Address(RVA = "0xB26DAC", Offset = "0xB26DAC", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F00958]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225E2]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_activeSceneChanged(v42);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			UnityAction<Scene, Scene> value = SceneManager_activeSceneChanged;
			SceneManager.activeSceneChanged += value;
			Finish();
		}

		[Token(Token = "0x6001023")]
		[Address(RVA = "0xB26E34", Offset = "0xB26E34", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EC8AB0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, previousActiveScene, activeScene, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225E3]) = v44;\nL_001B:\n\tv48.lastNewActiveScene = activeScene;\n\tv50.lastPreviousActiveScene = previousActiveScene;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.activeSceneChanged);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SceneManager_activeSceneChanged(Scene previousActiveScene, Scene activeScene)
		{
			lastNewActiveScene = activeScene;
			lastPreviousActiveScene = previousActiveScene;
			Fsm.Event(activeSceneChanged);
			Finish();
		}

		[Token(Token = "0x6001024")]
		[Address(RVA = "0xB26EC4", Offset = "0xB26EC4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED28F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225E4]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_activeSceneChanged(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			UnityAction<Scene, Scene> value = SceneManager_activeSceneChanged;
			SceneManager.activeSceneChanged -= value;
		}

		[Token(Token = "0x6001025")]
		[Address(RVA = "0xB26F40", Offset = "0xB26F40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendActiveSceneChangedEvent()
		{
		}
	}
}
