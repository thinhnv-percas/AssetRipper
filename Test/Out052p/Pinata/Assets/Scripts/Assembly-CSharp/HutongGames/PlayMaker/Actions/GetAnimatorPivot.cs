using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752FB4", Offset = "0x752FB4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752FB4", Offset = "0x752FB4")]
	[Token(Token = "0x2000151")]
	public class GetAnimatorPivot : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A6F98", Offset = "0x7A6F98")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A6F98", Offset = "0x7A6F98")]
		[Token(Token = "0x40011B9")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A7030", Offset = "0x7A7030")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A7030", Offset = "0x7A7030")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7030", Offset = "0x7A7030")]
		[Token(Token = "0x40011BA")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat pivotWeight;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A70A4", Offset = "0x7A70A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A70A4", Offset = "0x7A70A4")]
		[Token(Token = "0x40011BB")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 pivotPosition;

		[Token(Token = "0x40011BC")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x6000779")]
		[Address(RVA = "0xB81CC4", Offset = "0xB81CC4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.pivotWeight = 0;\n\tthis.pivotPosition = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			pivotWeight = null;
			pivotPosition = null;
			gameObject = null;
		}

		[Token(Token = "0x600077A")]
		[Address(RVA = "0xB81CD8", Offset = "0xB81CD8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC3D80]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229BF]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorPivot::DoCheckPivot(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoCheckPivot();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x600077B")]
		[Address(RVA = "0xB81ED8", Offset = "0xB81ED8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorPivot::DoCheckPivot(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			DoCheckPivot();
		}

		[Token(Token = "0x600077C")]
		[Address(RVA = "0xB81DF0", Offset = "0xB81DF0", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF2268]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229C0]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0055;\n\tv87 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.pivotWeight);\n\tv119 = v87 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_003E;\n\tv125 = this.pivotWeight;\n\tv121 = UnityEngine.Animator::get_pivotWeight(this._animator);\n\tv125.value = v121;\nL_003E:\n\tv74 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.pivotPosition);\n\tv130 = v74 == 0;\n\tv77 = ~v130;\n\tif (v77) goto L_0055;\n\tv79 = this.pivotPosition;\n\tv67 = UnityEngine.Animator::get_pivotPosition(this._animator);\n\tv79.value = v67;\n\tv79.value.y = v67.y;\n\tv79.value.z = v67.z;\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCheckPivot()
		{
			if (!(_animator == null))
			{
				if (!pivotWeight.IsNone)
				{
					FsmFloat fsmFloat = pivotWeight;
					float value = _animator.pivotWeight;
					fsmFloat.Value = value;
				}
				if (!pivotPosition.IsNone)
				{
					FsmVector3 fsmVector = pivotPosition;
					Vector3 vector = (fsmVector.value = _animator.pivotPosition);
					fsmVector.value.y = vector.y;
					fsmVector.value.z = vector.z;
				}
			}
		}

		[Token(Token = "0x600077D")]
		[Address(RVA = "0xB81EDC", Offset = "0xB81EDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorPivot()
		{
		}
	}
}
