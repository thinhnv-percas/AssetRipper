using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753734", Offset = "0x753734")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753734", Offset = "0x753734")]
	[Token(Token = "0x2000169")]
	public class SetAnimatorTrigger : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A8DF8", Offset = "0x7A8DF8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A8DF8", Offset = "0x7A8DF8")]
		[Token(Token = "0x400122D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A8E90", Offset = "0x7A8E90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A8E90", Offset = "0x7A8E90")]
		[Token(Token = "0x400122E")]
		[FieldOffset(Offset = "0x58")]
		public FsmString trigger;

		[Token(Token = "0x400122F")]
		[FieldOffset(Offset = "0x60")]
		private Animator _animator;

		[Token(Token = "0x60007F1")]
		[Address(RVA = "0xB2BC0C", Offset = "0xB2BC0C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.trigger = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			trigger = null;
		}

		[Token(Token = "0x60007F2")]
		[Address(RVA = "0xB2BC14", Offset = "0xB2BC14", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EE5BB0]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022618]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv68 = *([v60 @ X8_v4+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_002B;\n\tv97 = v60;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v97, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv75 = UnityEngine.Object::op_Equality(v45, 0);\n\tv99 = v75 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0055;\n\tv115 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v115;\n\tgoto L_0046;\n\tv120 = *([v116 @ X0_v14+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0046;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v116, v114, v52, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv106 = UnityEngine.Object::op_Equality(v115, 0);\n\tv128 = v106 == 0;\n\tv107 = ~v128;\n\tif (v107) goto L_0055;\n\tHutongGames.PlayMaker.Actions.SetAnimatorTrigger::SetTrigger(this);\nL_0055:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				SetTrigger();
			}
			Finish();
		}

		[Token(Token = "0x60007F3")]
		[Address(RVA = "0xB2BD10", Offset = "0xB2BD10", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF6318]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022619]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_003E;\n\tv67 = HutongGames.PlayMaker.FsmString::get_Value(this.trigger);\n\tUnityEngine.Animator::SetTrigger(this._animator, v67);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetTrigger()
		{
			if (_animator != null)
			{
				string value = trigger.Value;
				_animator.SetTrigger(value);
			}
		}

		[Token(Token = "0x60007F4")]
		[Address(RVA = "0xB2BDC4", Offset = "0xB2BDC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorTrigger()
		{
		}
	}
}
