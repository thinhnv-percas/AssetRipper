using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D0B0", Offset = "0x75D0B0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D0B0", Offset = "0x75D0B0")]
	[Token(Token = "0x200033B")]
	public class SendSceneUnloadedEvent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7E64", Offset = "0x7C7E64")]
		[Token(Token = "0x4001A93")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sceneUnloaded;

		[Token(Token = "0x4001A94")]
		public static Scene lastUnLoadedScene;

		[Token(Token = "0x600102D")]
		[Address(RVA = "0xB28158", Offset = "0xB28158", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneUnloaded = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sceneUnloaded = null;
		}

		[Token(Token = "0x600102E")]
		[Address(RVA = "0xB28160", Offset = "0xB28160", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC5D88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225ED]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`1<UnityEngine.SceneManagement.Scene>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.SceneManagement.Scene>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneUnloaded(v42);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			UnityAction<Scene> value = SceneManager_sceneUnloaded;
			SceneManager.sceneUnloaded += value;
			Finish();
		}

		[Token(Token = "0x600102F")]
		[Address(RVA = "0xB281E8", Offset = "0xB281E8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EC2570]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, scene, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([20225EE]) = v39;\nL_0016:\n\tv43 = 0x10D454C(&v41 @ stack_-28_v2 (UnityEngine.SceneManagement.Scene), 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0027;\n\tv51 = *([v47 @ X8_v5+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv60 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v60, v42, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tUnityEngine.Debug::Log(v43);\n\tv65.lastUnLoadedScene = v41;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneUnloaded);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SceneManager_sceneUnloaded(Scene scene)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
			object message = default(object);
			Debug.Log(message);
			Scene scene2 = default(Scene);
			lastUnLoadedScene = scene2;
			Fsm.Event(sceneUnloaded);
			Finish();
		}

		[Token(Token = "0x6001030")]
		[Address(RVA = "0xB282B0", Offset = "0xB282B0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE3110]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225EF]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`1<UnityEngine.SceneManagement.Scene>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.SceneManagement.Scene>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneUnloaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			UnityAction<Scene> value = SceneManager_sceneUnloaded;
			SceneManager.sceneUnloaded -= value;
		}

		[Token(Token = "0x6001031")]
		[Address(RVA = "0xB2832C", Offset = "0xB2832C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendSceneUnloadedEvent()
		{
		}
	}
}
