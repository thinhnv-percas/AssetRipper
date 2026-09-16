using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758214", Offset = "0x758214")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758214", Offset = "0x758214")]
	[Token(Token = "0x200024B")]
	public class LoadLevel : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4934", Offset = "0x7B4934")]
		[Token(Token = "0x40015BC")]
		[FieldOffset(Offset = "0x50")]
		public FsmString levelName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4980", Offset = "0x7B4980")]
		[Token(Token = "0x40015BD")]
		[FieldOffset(Offset = "0x58")]
		public bool additive;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B49B8", Offset = "0x7B49B8")]
		[Token(Token = "0x40015BE")]
		[FieldOffset(Offset = "0x59")]
		public bool async;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B49F0", Offset = "0x7B49F0")]
		[Token(Token = "0x40015BF")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent loadedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4A28", Offset = "0x7B4A28")]
		[Token(Token = "0x40015C0")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool dontDestroyOnLoad;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4A60", Offset = "0x7B4A60")]
		[Token(Token = "0x40015C1")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent failedEvent;

		[Token(Token = "0x40015C2")]
		[FieldOffset(Offset = "0x78")]
		private AsyncOperation asyncOperation;

		[Token(Token = "0x6000B7C")]
		[Address(RVA = "0xA3A098", Offset = "0xA3A098", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE7358]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E40]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.levelName = v43;\n\tthis.additive = 0;\n\tthis.loadedEvent = 0;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.dontDestroyOnLoad = v46;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "";
			levelName = fsmString;
			additive = false;
			async = false;
			loadedEvent = null;
			FsmBool fsmBool = false;
			dontDestroyOnLoad = fsmBool;
		}

		[Token(Token = "0x6000B7D")]
		[Address(RVA = "0xA3A108", Offset = "0xA3A108", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF7A40]);\n\tv21 = *([v20 @ X8_v34]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E41]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\n\tv92 = UnityEngine.Application::CanStreamedLevelBeLoaded(v44);\n\tv114 = v92 == 0;\n\tif (v114) goto L_005C;\n\tv148 = HutongGames.PlayMaker.FsmBool::get_Value(this.dontDestroyOnLoad);\n\tv151 = v148 == 0;\n\tif (v151) goto L_004A;\n\tv67 = UnityEngine.GameObject::get_transform(this.owner);\n\tv68 = UnityEngine.Transform::get_root(v67);\n\tv172 = UnityEngine.Component::get_gameObject(v68);\n\tgoto L_0043;\n\tv188 = *([v164 @ X8_v31+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\tif (v190) goto L_0043;\n\tv201 = v164;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v201, v171, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tUnityEngine.Object::DontDestroyOnLoad(v172);\nL_004A:\n\tv167 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\n\tv168 = ~this.additive;\n\tif (v168) goto L_0061;\n\tv169 = ~this.async;\n\tif (v169) goto L_008E;\n\tv102 = UnityEngine.SceneManagement.SceneManager::LoadSceneAsync(v167, 1);\n\tthis.asyncOperation = v102;\n\tv204 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\n\tgoto L_0073;\nL_005C:\n\tv156 = this.fsm;\n\tv154 = this.failedEvent;\n\tgoto L_00C2;\nL_0061:\n\tv170 = ~this.async;\n\tif (v170) goto L_0099;\n\tv103 = UnityEngine.SceneManagement.SceneManager::LoadSceneAsync(v167, 0);\n\tthis.asyncOperation = v103;\n\tv204 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\nL_0073:\n\tv210 = System.String::Concat(*([v206 @ X8_v14 (System.String)]), v204);\n\tgoto L_008A;\n\tv233 = *([v140 @ X8_v18+E0]);\n\tv234 = v233 == 0;\n\tv235 = ~v234;\n\tgoto L_008A;\n\tv246 = v140;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v246, v208, v119, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008A:\n\tUnityEngine.Debug::Log(v210);\n\treturn;\nL_008E:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v167, 1);\n\tv213 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\n\tgoto L_00A5;\nL_0099:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v167, 0);\n\tv213 = HutongGames.PlayMaker.FsmString::get_Value(this.levelName);\nL_00A5:\n\tv220 = System.String::Concat(*([v215 @ X8_v7 (System.String)]), v213);\n\tgoto L_00B6;\n\tv238 = *([v229 @ X8_v11+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tgoto L_00B6;\n\tv247 = v229;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v247, v217, v218, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00B6:\n\tUnityEngine.Debug::Log(v220);\n\tHutongGames.PlayMaker.FsmStateAction::Log(this, \"LOAD COMPLETE\");\n\tv156 = this.fsm;\n\tv154 = this.loadedEvent;\nL_00C2:\n\tHutongGames.PlayMaker.Fsm::Event(v156, v154);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = levelName.Value;
			string value3;
			string text;
			Fsm fsm;
			FsmEvent fsmEvent;
			if (Application.CanStreamedLevelBeLoaded(value))
			{
				if (dontDestroyOnLoad.Value)
				{
					Transform transform = Owner.transform;
					Transform root = transform.root;
					GameObject gameObject = root.gameObject;
					Object.DontDestroyOnLoad(gameObject);
				}
				string value2 = levelName.Value;
				string value4;
				string text2;
				if (additive)
				{
					if (async)
					{
						AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(value2, LoadSceneMode.Additive);
						this.asyncOperation = asyncOperation;
						value3 = levelName.Value;
						text = "LoadLevelAdditiveAsyc: ";
						goto IL_0262;
					}
					SceneManager.LoadScene(value2, LoadSceneMode.Additive);
					value4 = levelName.Value;
					text2 = "LoadLevelAdditive: ";
				}
				else
				{
					if (async)
					{
						AsyncOperation asyncOperation2 = SceneManager.LoadSceneAsync(value2, default(LoadSceneMode));
						this.asyncOperation = asyncOperation2;
						value3 = levelName.Value;
						text = "LoadLevelAsync: ";
						goto IL_0262;
					}
					SceneManager.LoadScene(value2, default(LoadSceneMode));
					value4 = levelName.Value;
					text2 = "LoadLevel: ";
				}
				string message = text2 + value4;
				Debug.Log(message);
				Log("LOAD COMPLETE");
				fsm = Fsm;
				fsmEvent = loadedEvent;
			}
			else
			{
				fsm = Fsm;
				fsmEvent = failedEvent;
			}
			fsm.Event(fsmEvent);
			Finish();
			return;
			IL_0262:
			string message2 = text + value3;
			Debug.Log(message2);
		}

		[Token(Token = "0x6000B7E")]
		[Address(RVA = "0xA3A394", Offset = "0xA3A394", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.AsyncOperation::get_isDone(this.asyncOperation);\n\tv36 = v13 == 0;\n\tif (v36) goto L_0020;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.loadedEvent);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0020:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			if (asyncOperation.isDone)
			{
				Fsm.Event(loadedEvent);
				Finish();
			}
		}

		[Token(Token = "0x6000B7F")]
		[Address(RVA = "0xA3A3F0", Offset = "0xA3A3F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LoadLevel()
		{
		}
	}
}
