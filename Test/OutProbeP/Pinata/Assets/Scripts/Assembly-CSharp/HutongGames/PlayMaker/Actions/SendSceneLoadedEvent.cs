using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D060", Offset = "0x75D060")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75D060", Offset = "0x75D060")]
	[Token(Token = "0x200033A")]
	public class SendSceneLoadedEvent : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7DF4", Offset = "0x7C7DF4")]
		[Token(Token = "0x4001A8E")]
		[FieldOffset(Offset = "0x50")]
		public FsmEvent sceneLoaded;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7E2C", Offset = "0x7C7E2C")]
		[Token(Token = "0x4001A8F")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent sceneLoadedSafe;

		[Token(Token = "0x4001A90")]
		public static Scene lastLoadedScene;

		[Token(Token = "0x4001A91")]
		public static LoadSceneMode lastLoadedMode;

		[Token(Token = "0x4001A92")]
		[FieldOffset(Offset = "0x60")]
		private int _loaded;

		[Token(Token = "0x6001026")]
		[Address(RVA = "0xB27EB0", Offset = "0xB27EB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneLoaded = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sceneLoaded = null;
		}

		[Token(Token = "0x6001027")]
		[Address(RVA = "0xB27EB8", Offset = "0xB27EB8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEE990]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225E9]) = v38;\nL_0014:\n\tthis._loaded = 0xFFFFFFFF;\n\tv43 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v43, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v43);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			_loaded = -1;
			UnityAction<Scene, LoadSceneMode> value = SceneManager_sceneLoaded;
			SceneManager.sceneLoaded += value;
		}

		[Token(Token = "0x6001028")]
		[Address(RVA = "0xB27F3C", Offset = "0xB27F3C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F0E0A0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, scene, mode, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225EA]) = v44;\nL_001B:\n\tv48.lastLoadedScene = scene;\n\tv50.lastLoadedMode = mode;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneLoaded);\n\tv57 = UnityEngine.Time::get_frameCount();\n\tthis._loaded = v57;\n\tv59 = this.sceneLoadedSafe == 0;\n\tif (v59) goto L_003C;\n\treturn;\nL_003C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode mode)
		{
			lastLoadedScene = scene;
			lastLoadedMode = mode;
			Fsm.Event(sceneLoaded);
			int frameCount = Time.frameCount;
			_loaded = frameCount;
			if (sceneLoadedSafe == null)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001029")]
		[Address(RVA = "0xB27FF0", Offset = "0xB27FF0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._loaded & 0x80000000;\n\tv12 = v11 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_002F;\n\tv15 = UnityEngine.Time::get_frameCount();\n\tv18 = v15 <= this._loaded;\n\tif (v18) goto L_002F;\n\tthis._loaded = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneLoadedSafe);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_002F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_0014: Expected I4, but got I8
			if ((int)(_loaded & 0x80000000L) == 0)
			{
				int frameCount = Time.frameCount;
				if (frameCount > _loaded)
				{
					_loaded = -1;
					Fsm.Event(sceneLoadedSafe);
					Finish();
				}
			}
		}

		[Token(Token = "0x600102A")]
		[Address(RVA = "0xB2805C", Offset = "0xB2805C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED40F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225EB]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			UnityAction<Scene, LoadSceneMode> value = SceneManager_sceneLoaded;
			SceneManager.sceneLoaded -= value;
		}

		[Token(Token = "0x600102B")]
		[Address(RVA = "0xB280D8", Offset = "0xB280D8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0CD20]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225EC]) = v38;\nL_0014:\n\tv40 = this.sceneLoaded == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_001D;\n\tv43 = this.sceneLoadedSafe == 0;\n\tif (v43) goto L_FFFFFFFF;\nL_001D:\n\tv49 = v48.Empty;\nL_0024:\n\treturn *([v49 @ X8_v9 (System.String)]);\n\tgoto L_0024;\n\treturn X0;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (sceneLoaded != null || sceneLoadedSafe != null)
			{
				return string.Empty;
			}
			return "At least one event setup is required";
		}

		[Token(Token = "0x600102C")]
		[Address(RVA = "0xB28148", Offset = "0xB28148", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._loaded = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SendSceneLoadedEvent()
		{
			_loaded = -1;
		}
	}
}
