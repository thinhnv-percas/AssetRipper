using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753504", Offset = "0x753504")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x753504", Offset = "0x753504")]
	[Token(Token = "0x2000162")]
	public class SetAnimatorLayerWeight : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A8484", Offset = "0x7A8484")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A8484", Offset = "0x7A8484")]
		[Token(Token = "0x4001209")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A851C", Offset = "0x7A851C")]
		[Token(Token = "0x400120A")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt layerIndex;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A8568", Offset = "0x7A8568")]
		[Token(Token = "0x400120B")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat layerWeight;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A85B4", Offset = "0x7A85B4")]
		[Token(Token = "0x400120C")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x400120D")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x60007CD")]
		[Address(RVA = "0xB2A7EC", Offset = "0xB2A7EC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.layerIndex = 0;\n\tthis.layerWeight = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			layerIndex = null;
			layerWeight = null;
			gameObject = null;
		}

		[Token(Token = "0x60007CE")]
		[Address(RVA = "0xB2A7FC", Offset = "0xB2A7FC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA7108]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022607]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.SetAnimatorLayerWeight::DoLayerWeight(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				DoLayerWeight();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x60007CF")]
		[Address(RVA = "0xB2A9E0", Offset = "0xB2A9E0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAnimatorLayerWeight::DoLayerWeight(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoLayerWeight();
		}

		[Token(Token = "0x60007D0")]
		[Address(RVA = "0xB2A914", Offset = "0xB2A914", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EF3840]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022608]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0032;\n\treturn;\nL_0032:\n\tv94 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv66 = HutongGames.PlayMaker.FsmFloat::get_Value(this.layerWeight);\n\tUnityEngine.Animator::SetLayerWeight(this._animator, v94, v66);\n\treturn;\n\tv98 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoLayerWeight()
		{
			if (!(_animator == null))
			{
				int value = layerIndex.Value;
				float value2 = layerWeight.Value;
				_animator.SetLayerWeight(value, value2);
			}
		}

		[Token(Token = "0x60007D1")]
		[Address(RVA = "0xB2A9E4", Offset = "0xB2A9E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorLayerWeight()
		{
		}
	}
}
