using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752B04", Offset = "0x752B04")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752B04", Offset = "0x752B04")]
	[Token(Token = "0x2000142")]
	public class GetAnimatorFloat : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A564C", Offset = "0x7A564C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A564C", Offset = "0x7A564C")]
		[Token(Token = "0x4001168")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A56E4", Offset = "0x7A56E4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A56E4", Offset = "0x7A56E4")]
		[Token(Token = "0x4001169")]
		[FieldOffset(Offset = "0x60")]
		public FsmString parameter;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A5744", Offset = "0x7A5744")]
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A5744", Offset = "0x7A5744")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A5744", Offset = "0x7A5744")]
		[Token(Token = "0x400116A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat result;

		[Token(Token = "0x400116B")]
		[FieldOffset(Offset = "0x70")]
		private Animator _animator;

		[Token(Token = "0x400116C")]
		[FieldOffset(Offset = "0x78")]
		private int _paramID;

		[Token(Token = "0x6000733")]
		[Address(RVA = "0xB7FB90", Offset = "0xB7FB90", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.parameter = 0;\n\tthis.result = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			parameter = null;
			result = null;
			gameObject = null;
		}

		[Token(Token = "0x6000734")]
		[Address(RVA = "0xB7FBA4", Offset = "0xB7FBA4", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF09C8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229A1]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv84 = *([v66 @ X8_v5+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_002B;\n\tv91 = v66;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v91, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv77 = UnityEngine.Object::op_Equality(v45, 0);\n\tv93 = v77 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0067;\n\tv134 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v134;\n\tgoto L_0046;\n\tv139 = *([v135 @ X0_v16+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0046;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v73, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv127 = UnityEngine.Object::op_Equality(v134, 0);\n\tv147 = v127 == 0;\n\tv128 = ~v147;\n\tif (v128) goto L_0067;\n\tv149 = HutongGames.PlayMaker.FsmString::get_Value(this.parameter);\n\tv150 = UnityEngine.Animator::StringToHash(v149);\n\tthis._paramID = v150;\n\tHutongGames.PlayMaker.Actions.GetAnimatorFloat::GetParameter(this);\n\tv111 = ~this.everyFrame;\n\tif (v111) goto L_0067;\n\treturn;\nL_0067:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				string value = parameter.Value;
				int paramID = Animator.StringToHash(value);
				_paramID = paramID;
				GetParameter();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000735")]
		[Address(RVA = "0xB7FD7C", Offset = "0xB7FD7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorFloat::GetParameter(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			GetParameter();
		}

		[Token(Token = "0x6000736")]
		[Address(RVA = "0xB7FCD8", Offset = "0xB7FCD8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EC3F00]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229A2]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0036;\n\tv71 = this.result;\n\tv62 = UnityEngine.Animator::GetFloat(this._animator, this._paramID);\n\tv71.value = v62;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetParameter()
		{
			if (_animator != null)
			{
				FsmFloat fsmFloat = result;
				float value = _animator.GetFloat(_paramID);
				fsmFloat.Value = value;
			}
		}

		[Token(Token = "0x6000737")]
		[Address(RVA = "0xB7FD80", Offset = "0xB7FD80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorFloat()
		{
		}
	}
}
