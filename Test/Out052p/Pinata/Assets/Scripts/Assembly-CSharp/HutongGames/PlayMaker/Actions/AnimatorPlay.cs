using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752564", Offset = "0x752564")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752564", Offset = "0x752564")]
	[Token(Token = "0x200012F")]
	public class AnimatorPlay : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3898", Offset = "0x7A3898")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3898", Offset = "0x7A3898")]
		[Token(Token = "0x4001108")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3930", Offset = "0x7A3930")]
		[Token(Token = "0x4001109")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stateName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3968", Offset = "0x7A3968")]
		[Token(Token = "0x400110A")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layer;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A39A0", Offset = "0x7A39A0")]
		[Token(Token = "0x400110B")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat normalizedTime;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A39D8", Offset = "0x7A39D8")]
		[Token(Token = "0x400110C")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x400110D")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x60006DD")]
		[Address(RVA = "0xA87E88", Offset = "0xA87E88", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EA84D8]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A7]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.stateName = 0;\n\tv44 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.layer = v44;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.normalizedTime = v52;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			stateName = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			layer = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			normalizedTime = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x60006DE")]
		[Address(RVA = "0xA87F34", Offset = "0xA87F34", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECB7C8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221A8]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv67 = *([v48 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002A;\n\tv74 = v48;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v74, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv60 = UnityEngine.Object::op_Equality(v43, 0);\n\tv76 = v60 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0049;\n\tv109 = UnityEngine.GameObject::GetComponent(v43);\n\tthis._animator = v109;\n\tHutongGames.PlayMaker.Actions.AnimatorPlay::DoAnimatorPlay(this);\n\tv90 = ~this.everyFrame;\n\tif (v90) goto L_0049;\n\treturn;\nL_0049:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Animator component = ownerDefaultTarget.GetComponent<Animator>();
				_animator = component;
				DoAnimatorPlay();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x60006DF")]
		[Address(RVA = "0xA8813C", Offset = "0xA8813C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimatorPlay::DoAnimatorPlay(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoAnimatorPlay();
		}

		[Token(Token = "0x60006E0")]
		[Address(RVA = "0xA88010", Offset = "0xA88010", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EA6C70]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A9]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0038;\n\tv69 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.layer);\n\tv125 = v69 == 0;\n\tif (v125) goto L_003D;\n\tgoto L_0043;\nL_0038:\n\treturn;\nL_003D:\n\tv133 = HutongGames.PlayMaker.FsmInt::get_Value(this.layer);\nL_0043:\n\tv136 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.normalizedTime);\n\tv138 = v136 == 0;\n\tif (v138) goto L_004E;\n\tgoto L_0055;\nL_004E:\n\tv141 = HutongGames.PlayMaker.FsmFloat::get_Value(this.normalizedTime);\nL_0055:\n\tv127 = HutongGames.PlayMaker.FsmString::get_Value(this.stateName);\n\tUnityEngine.Animator::Play(this._animator, v127, v91, v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAnimatorPlay()
		{
			if (_animator != null)
			{
				int num;
				if (layer.IsNone)
				{
					num = -1;
				}
				else
				{
					int value = layer.Value;
					num = value;
				}
				float num2;
				if (normalizedTime.IsNone)
				{
					num2 = float.NegativeInfinity;
				}
				else
				{
					float value2 = normalizedTime.Value;
					num2 = value2;
				}
				string value3 = stateName.Value;
				_animator.Play(value3, num, num2);
			}
		}

		[Token(Token = "0x60006E1")]
		[Address(RVA = "0xA88140", Offset = "0xA88140", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorPlay()
		{
		}
	}
}
