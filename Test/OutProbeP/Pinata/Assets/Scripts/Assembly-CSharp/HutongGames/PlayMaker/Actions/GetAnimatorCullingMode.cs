using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752834", Offset = "0x752834")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752834", Offset = "0x752834")]
	[Token(Token = "0x2000139")]
	public class GetAnimatorCullingMode : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A4420", Offset = "0x7A4420")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4420", Offset = "0x7A4420")]
		[Token(Token = "0x400112C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A44B8", Offset = "0x7A44B8")]
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A44B8", Offset = "0x7A44B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A44B8", Offset = "0x7A44B8")]
		[Token(Token = "0x400112D")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool alwaysAnimate;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A453C", Offset = "0x7A453C")]
		[Token(Token = "0x400112E")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent alwaysAnimateEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4574", Offset = "0x7A4574")]
		[Token(Token = "0x400112F")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent basedOnRenderersEvent;

		[Token(Token = "0x4001130")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x6000708")]
		[Address(RVA = "0xB7E4DC", Offset = "0xB7E4DC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.alwaysAnimateEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			alwaysAnimateEvent = null;
		}

		[Token(Token = "0x6000709")]
		[Address(RVA = "0xB7E4E8", Offset = "0xB7E4E8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF0110]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202298F]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCullingMode::DoCheckCulling(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckCulling();
			}
			Finish();
		}

		[Token(Token = "0x600070A")]
		[Address(RVA = "0xB7E5E4", Offset = "0xB7E5E4", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F08298]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022990]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0031;\n\treturn;\nL_0031:\n\tv128 = UnityEngine.Animator::get_cullingMode(this._animator);\n\tv103 = this.alwaysAnimate;\n\tv87 = v128 == 0;\n\tv103.value = v87;\n\tv150 = v128 == 0;\n\tif (v150) goto L_004A;\n\tv110 = this.basedOnRenderersEvent;\n\tgoto L_0051;\nL_004A:\n\tv110 = this.alwaysAnimateEvent;\nL_0051:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v110);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckCulling()
		{
			if (!(_animator == null))
			{
				AnimatorCullingMode cullingMode = _animator.cullingMode;
				FsmBool fsmBool = alwaysAnimate;
				bool value = cullingMode == AnimatorCullingMode.AlwaysAnimate;
				fsmBool.value = value;
				FsmEvent fsmEvent = ((cullingMode == AnimatorCullingMode.AlwaysAnimate) ? alwaysAnimateEvent : basedOnRenderersEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x600070B")]
		[Address(RVA = "0xB7E6BC", Offset = "0xB7E6BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCullingMode()
		{
		}
	}
}
