using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CFC0", Offset = "0x75CFC0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75CFC0", Offset = "0x75CFC0")]
	[Token(Token = "0x2000338")]
	public class MoveGameObjectToScene : GetSceneActionBase
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7C2C", Offset = "0x7C7C2C")]
		[Token(Token = "0x4001A85")]
		[FieldOffset(Offset = "0x90")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7C78", Offset = "0x7C7C78")]
		[Token(Token = "0x4001A86")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool findRootIfNecessary;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7C7CC4", Offset = "0x7C7CC4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7CC4", Offset = "0x7C7CC4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C7CC4", Offset = "0x7C7CC4")]
		[Token(Token = "0x4001A87")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool success;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7D38", Offset = "0x7C7D38")]
		[Token(Token = "0x4001A88")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent successEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C7D70", Offset = "0x7C7D70")]
		[Token(Token = "0x4001A89")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent failureEvent;

		[Token(Token = "0x4001A8A")]
		[FieldOffset(Offset = "0xB8")]
		private GameObject _go;

		[Token(Token = "0x600101E")]
		[Address(RVA = "0xA3D888", Offset = "0xA3D888", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.MoveGameObjectToScene)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.MoveGameObjectToScene)+84]) = 0;\n\tthis.failureEvent = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.MoveGameObjectToScene)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.MoveGameObjectToScene)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.gameObject = 0;\n\tthis.success = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			failureEvent = null;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			gameObject = null;
			success = null;
		}

		[Token(Token = "0x600101F")]
		[Address(RVA = "0xA3D8CC", Offset = "0xA3D8CC", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EAAC10]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E64]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tv41 = ~this._sceneFound;\n\tif (v41) goto L_0082;\n\tv67 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tthis._go = v67;\n\tv109 = HutongGames.PlayMaker.FsmBool::get_Value(this.findRootIfNecessary);\n\tv96 = this._go;\n\tv134 = v109 == 0;\n\tif (v134) goto L_003C;\n\tv83 = UnityEngine.GameObject::get_transform(this._go);\n\tv84 = UnityEngine.Transform::get_root(v83);\n\tv136 = UnityEngine.Component::get_gameObject(v84);\n\tthis._go = v136;\nL_003C:\n\tv85 = UnityEngine.GameObject::get_transform(v96);\n\tv142 = UnityEngine.Transform::get_parent(v85);\n\tgoto L_0052;\n\tv149 = *([v145 @ X8_v12+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0052;\n\tv159 = v145;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v159, v141, v66, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0052:\n\tv158 = UnityEngine.Object::op_Equality(v142, 0);\n\tv161 = v158 == 0;\n\tif (v161) goto L_0069;\n\tUnityEngine.SceneManagement.SceneManager::MoveGameObjectToScene(this._go, this._scene);\n\tv97 = this.success;\n\tv97.value = 1;\n\tv167 = this.fsm;\n\tv81 = this.successEvent;\n\tgoto L_0073;\nL_0069:\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"GameObject must be a root \");\n\tv98 = this.success;\n\tv98.value = 0;\n\tv167 = this.fsm;\n\tv81 = this.failureEvent;\nL_0073:\n\tHutongGames.PlayMaker.Fsm::Event(v167, v81);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\tthis._go = 0;\nL_0082:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			if (_sceneFound)
			{
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(this.gameObject);
				_go = ownerDefaultTarget;
				bool value = findRootIfNecessary.Value;
				GameObject gameObject = _go;
				if (value)
				{
					Transform transform = _go.transform;
					Transform root = transform.root;
					gameObject = (_go = root.gameObject);
				}
				Transform transform2 = gameObject.transform;
				Transform parent = transform2.parent;
				Fsm fsm;
				FsmEvent fsmEvent;
				if (parent == null)
				{
					SceneManager.MoveGameObjectToScene(_go, _scene);
					FsmBool fsmBool = success;
					fsmBool.value = true;
					fsm = Fsm;
					fsmEvent = successEvent;
				}
				else
				{
					LogError("GameObject must be a root ");
					FsmBool fsmBool2 = success;
					fsmBool2.value = false;
					fsm = Fsm;
					fsmEvent = failureEvent;
				}
				fsm.Event(fsmEvent);
				Fsm.Event(sceneFoundEvent);
				_go = null;
			}
			Finish();
		}

		[Token(Token = "0x6001020")]
		[Address(RVA = "0xA3DA6C", Offset = "0xA3DA6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MoveGameObjectToScene()
		{
		}
	}
}
