using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752C94", Offset = "0x752C94")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752C94", Offset = "0x752C94")]
	[Token(Token = "0x2000147")]
	public class GetAnimatorIsHuman : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A5E30", Offset = "0x7A5E30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5E30", Offset = "0x7A5E30")]
		[Token(Token = "0x4001182")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A5EC8", Offset = "0x7A5EC8")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A5EC8", Offset = "0x7A5EC8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5EC8", Offset = "0x7A5EC8")]
		[Token(Token = "0x4001183")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool isHuman;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5F3C", Offset = "0x7A5F3C")]
		[Token(Token = "0x4001184")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent isHumanEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5F74", Offset = "0x7A5F74")]
		[Token(Token = "0x4001185")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent isGenericEvent;

		[Token(Token = "0x4001186")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x600074B")]
		[Address(RVA = "0xB806EC", Offset = "0xB806EC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.isHumanEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			isHumanEvent = null;
		}

		[Token(Token = "0x600074C")]
		[Address(RVA = "0xB806F8", Offset = "0xB806F8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EBB9F8]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229AB]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.GetAnimatorIsHuman::DoCheckIsHuman(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckIsHuman();
			}
			Finish();
		}

		[Token(Token = "0x600074D")]
		[Address(RVA = "0xB807F4", Offset = "0xB807F4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EB7970]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229AC]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0031;\n\treturn;\nL_0031:\n\tv93 = UnityEngine.Animator::get_isHuman(this._animator);\n\tv108 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isHuman);\n\tv114 = v108 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_0044;\n\tv110 = this.isHuman;\n\tv110.value = v93;\nL_0044:\n\tv119 = v93 == 0;\n\tif (v119) goto L_004C;\n\tv74 = this.isHumanEvent;\n\tgoto L_0053;\nL_004C:\n\tv74 = this.isGenericEvent;\nL_0053:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v74);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckIsHuman()
		{
			if (!(_animator == null))
			{
				bool flag = _animator.isHuman;
				if (!isHuman.IsNone)
				{
					FsmBool fsmBool = isHuman;
					fsmBool.value = flag;
				}
				FsmEvent fsmEvent = ((!flag) ? isGenericEvent : isHumanEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x600074E")]
		[Address(RVA = "0xB808E0", Offset = "0xB808E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorIsHuman()
		{
		}
	}
}
