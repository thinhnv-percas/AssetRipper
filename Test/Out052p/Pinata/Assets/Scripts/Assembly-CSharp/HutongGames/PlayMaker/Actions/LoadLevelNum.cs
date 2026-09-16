using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758264", Offset = "0x758264")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758264", Offset = "0x758264")]
	[Token(Token = "0x200024C")]
	public class LoadLevelNum : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4A98", Offset = "0x7B4A98")]
		[Token(Token = "0x40015C3")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt levelIndex;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4AE4", Offset = "0x7B4AE4")]
		[Token(Token = "0x40015C4")]
		[FieldOffset(Offset = "0x58")]
		public bool additive;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4B1C", Offset = "0x7B4B1C")]
		[Token(Token = "0x40015C5")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent loadedEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4B54", Offset = "0x7B4B54")]
		[Token(Token = "0x40015C6")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool dontDestroyOnLoad;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4B8C", Offset = "0x7B4B8C")]
		[Token(Token = "0x40015C7")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent failedEvent;

		[Token(Token = "0x6000B80")]
		[Address(RVA = "0xA3A3F8", Offset = "0xA3A3F8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.levelIndex = 0;\n\tthis.additive = 0;\n\tthis.loadedEvent = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.dontDestroyOnLoad = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			levelIndex = null;
			additive = false;
			loadedEvent = null;
			FsmBool fsmBool = false;
			dontDestroyOnLoad = fsmBool;
		}

		[Token(Token = "0x6000B81")]
		[Address(RVA = "0xA3A430", Offset = "0xA3A430", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB5D20]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E42]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmInt::get_Value(this.levelIndex);\n\tv77 = UnityEngine.Application::CanStreamedLevelBeLoaded(v42);\n\tv79 = v77 == 0;\n\tif (v79) goto L_004D;\n\tv100 = HutongGames.PlayMaker.FsmBool::get_Value(this.dontDestroyOnLoad);\n\tv103 = v100 == 0;\n\tif (v103) goto L_0048;\n\tv58 = UnityEngine.GameObject::get_transform(this.owner);\n\tv59 = UnityEngine.Transform::get_root(v58);\n\tv123 = UnityEngine.Component::get_gameObject(v59);\n\tgoto L_0042;\n\tv129 = *([v115 @ X8_v8+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0042;\n\tv134 = v115;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v134, v122, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tUnityEngine.Object::DontDestroyOnLoad(v123);\nL_0048:\n\tv118 = HutongGames.PlayMaker.FsmInt::get_Value(this.levelIndex);\n\tv119 = ~this.additive;\n\tif (v119) goto L_FFFFFFFF;\n\tgoto L_0054;\nL_004D:\n\tv107 = this.fsm;\n\tv105 = this.failedEvent;\n\tgoto L_005A;\nL_0054:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v118, v54);\n\tv107 = this.fsm;\n\tv105 = this.loadedEvent;\nL_005A:\n\tHutongGames.PlayMaker.Fsm::Event(v107, v105);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			int value = levelIndex.Value;
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
				int value2 = levelIndex.Value;
				LoadSceneMode mode = (additive ? LoadSceneMode.Additive : default(LoadSceneMode));
				SceneManager.LoadScene(value2, mode);
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
		}

		[Token(Token = "0x6000B82")]
		[Address(RVA = "0xA3A558", Offset = "0xA3A558", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LoadLevelNum()
		{
		}
	}
}
