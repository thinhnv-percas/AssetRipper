using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7533C4", Offset = "0x7533C4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7533C4", Offset = "0x7533C4")]
	[Token(Token = "0x200015E")]
	public class SetAnimatorFloat : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A7EC4", Offset = "0x7A7EC4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7EC4", Offset = "0x7A7EC4")]
		[Token(Token = "0x40011F1")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A7F5C", Offset = "0x7A7F5C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7F5C", Offset = "0x7A7F5C")]
		[Token(Token = "0x40011F2")]
		[FieldOffset(Offset = "0x60")]
		public FsmString parameter;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7FBC", Offset = "0x7A7FBC")]
		[Token(Token = "0x40011F3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat Value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A7FF4", Offset = "0x7A7FF4")]
		[Token(Token = "0x40011F4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat dampTime;

		[Token(Token = "0x40011F5")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x40011F6")]
		[FieldOffset(Offset = "0x80")]
		private int _paramID;

		[Token(Token = "0x60007B9")]
		[Address(RVA = "0xB29CA8", Offset = "0xB29CA8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EBE100]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20225FF]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.Actions.FsmStateActionAnimatorBase::Reset(this);\n\tthis.gameObject = 0;\n\tthis.parameter = 0;\n\tv44 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.Value = 0;\n\tthis.dampTime = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			gameObject = null;
			parameter = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			Value = null;
			dampTime = fsmFloat;
		}

		[Token(Token = "0x60007BA")]
		[Address(RVA = "0xB29D2C", Offset = "0xB29D2C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0B260]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022600]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv84 = *([v66 @ X8_v5+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_002B;\n\tv91 = v66;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v91, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv77 = UnityEngine.Object::op_Equality(v45, 0);\n\tv93 = v77 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0067;\n\tv134 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v134;\n\tgoto L_0046;\n\tv139 = *([v135 @ X0_v16+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0046;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v135, v133, v73, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv127 = UnityEngine.Object::op_Equality(v134, 0);\n\tv147 = v127 == 0;\n\tv128 = ~v147;\n\tif (v128) goto L_0067;\n\tv149 = HutongGames.PlayMaker.FsmString::get_Value(this.parameter);\n\tv150 = UnityEngine.Animator::StringToHash(v149);\n\tthis._paramID = v150;\n\tHutongGames.PlayMaker.Actions.SetAnimatorFloat::SetParameter(this);\n\tv111 = ~this.everyFrame;\n\tif (v111) goto L_0067;\n\treturn;\nL_0067:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				string value = parameter.Value;
				int paramID = Animator.StringToHash(value);
				_paramID = paramID;
				SetParameter();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x60007BB")]
		[Address(RVA = "0xB29FA0", Offset = "0xB29FA0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetAnimatorFloat::SetParameter(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			SetParameter();
		}

		[Token(Token = "0x60007BC")]
		[Address(RVA = "0xB29E60", Offset = "0xB29E60", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EF1740]);\n\tv25 = *([v24 @ X8_v9]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022601]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Equality(this._animator, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0037;\n\treturn;\nL_0037:\n\tv160 = HutongGames.PlayMaker.FsmFloat::get_Value(this.dampTime);\n\tv171 = HutongGames.PlayMaker.FsmFloat::get_Value(this.Value);\n\tv81 = v160 <= 0;\n\tif (v81) goto L_0076;\n\tv197 = HutongGames.PlayMaker.FsmFloat::get_Value(this.dampTime);\n\tv188 = UnityEngine.Time::get_deltaTime();\n\tUnityEngine.Animator::SetFloat(this._animator, this._paramID, v171, v197, v188);\n\treturn;\nL_0076:\n\tUnityEngine.Animator::SetFloat(this._animator, this._paramID, v171);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetParameter()
		{
			if (!(_animator == null))
			{
				float value = dampTime.Value;
				float value2 = Value.Value;
				if (value > 0f)
				{
					float value3 = dampTime.Value;
					float deltaTime = Time.deltaTime;
					_animator.SetFloat(_paramID, value2, value3, deltaTime);
				}
				else
				{
					_animator.SetFloat(_paramID, value2);
				}
			}
		}

		[Token(Token = "0x60007BD")]
		[Address(RVA = "0xB29FA4", Offset = "0xB29FA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmStateActionAnimatorBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetAnimatorFloat()
		{
		}
	}
}
