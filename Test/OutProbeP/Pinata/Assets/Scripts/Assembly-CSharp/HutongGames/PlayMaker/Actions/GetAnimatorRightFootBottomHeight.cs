using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7530A4", Offset = "0x7530A4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7530A4", Offset = "0x7530A4")]
	[Token(Token = "0x2000154")]
	public class GetAnimatorRightFootBottomHeight : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A7378", Offset = "0x7A7378")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7378", Offset = "0x7A7378")]
		[Token(Token = "0x40011C5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A7410", Offset = "0x7A7410")]
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A7410", Offset = "0x7A7410")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7410", Offset = "0x7A7410")]
		[Token(Token = "0x40011C6")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat rightFootHeight;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7494", Offset = "0x7A7494")]
		[Token(Token = "0x40011C7")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x40011C8")]
		[FieldOffset(Offset = "0x68")]
		private Animator _animator;

		[Token(Token = "0x6000788")]
		[Address(RVA = "0xB82284", Offset = "0xB82284", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.rightFootHeight = 0;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			everyFrame = false;
			gameObject = null;
			rightFootHeight = null;
		}

		[Token(Token = "0x6000789")]
		[Address(RVA = "0xB822B0", Offset = "0xB822B0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleLateUpdate(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x600078A")]
		[Address(RVA = "0xB822D0", Offset = "0xB822D0", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA9F70]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229C5]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorRightFootBottomHeight::_getRightFootBottonHeight(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				_getRightFootBottonHeight();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x600078B")]
		[Address(RVA = "0xB82488", Offset = "0xB82488", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorRightFootBottomHeight::_getRightFootBottonHeight(this);\n\treturn;\n")]
		public override void OnLateUpdate()
		{
			_getRightFootBottonHeight();
		}

		[Token(Token = "0x600078C")]
		[Address(RVA = "0xB823E8", Offset = "0xB823E8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F05FB0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229C6]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0035;\n\tv69 = this.rightFootHeight;\n\tv62 = UnityEngine.Animator::get_rightFeetBottomHeight(this._animator);\n\tv69.value = v62;\nL_0035:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _getRightFootBottonHeight()
		{
			if (_animator != null)
			{
				FsmFloat fsmFloat = rightFootHeight;
				float rightFeetBottomHeight = _animator.rightFeetBottomHeight;
				fsmFloat.Value = rightFeetBottomHeight;
			}
		}

		[Token(Token = "0x600078D")]
		[Address(RVA = "0xB8248C", Offset = "0xB8248C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorRightFootBottomHeight()
		{
		}
	}
}
