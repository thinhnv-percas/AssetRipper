using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752474", Offset = "0x752474")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752474", Offset = "0x752474")]
	[Token(Token = "0x200012C")]
	public class AnimatorCrossFade : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A33C0", Offset = "0x7A33C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A33C0", Offset = "0x7A33C0")]
		[Token(Token = "0x40010F4")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3458", Offset = "0x7A3458")]
		[Token(Token = "0x40010F5")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stateName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3490", Offset = "0x7A3490")]
		[Token(Token = "0x40010F6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat transitionDuration;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A34C8", Offset = "0x7A34C8")]
		[Token(Token = "0x40010F7")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt layer;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3500", Offset = "0x7A3500")]
		[Token(Token = "0x40010F8")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat normalizedTime;

		[Token(Token = "0x40010F9")]
		[FieldOffset(Offset = "0x78")]
		private Animator _animator;

		[Token(Token = "0x60006D2")]
		[Address(RVA = "0xA874E0", Offset = "0xA874E0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1ED4538]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A1]) = v40;\nL_0016:\n\tthis.gameObject = 0;\n\tthis.stateName = 0;\n\tv43 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.transitionDuration = v43;\n\tv47 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v47);\n\tv47.useVariable = 1;\n\tthis.layer = v47;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 1;\n\tthis.normalizedTime = v55;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			stateName = null;
			FsmFloat fsmFloat = 1f;
			transitionDuration = fsmFloat;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			layer = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			normalizedTime = fsmFloat2;
		}

		[Token(Token = "0x60006D3")]
		[Address(RVA = "0xA87598", Offset = "0xA87598", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EEEAB8]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221A2]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002D;\n\tv103 = *([v99 @ X8_v4+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_002D;\n\tv144 = v99;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v144, v47, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv112 = UnityEngine.Object::op_Equality(v49, 0);\n\tv146 = v112 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_008C;\n\tv171 = UnityEngine.GameObject::GetComponent(v49);\n\tthis._animator = v171;\n\tgoto L_0048;\n\tv182 = *([v178 @ X0_v15+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0048;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v178, v170, v111, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0048:\n\tv162 = UnityEngine.Object::op_Inequality(v171, 0);\n\tv164 = v162 == 0;\n\tif (v164) goto L_008C;\n\tv190 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.layer);\n\tv192 = v190 == 0;\n\tif (v192) goto L_005A;\n\tgoto L_0060;\nL_005A:\n\tv196 = HutongGames.PlayMaker.FsmInt::get_Value(this.layer);\nL_0060:\n\tv199 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.normalizedTime);\n\tv201 = v199 == 0;\n\tif (v201) goto L_006B;\n\tgoto L_0072;\nL_006B:\n\tv204 = HutongGames.PlayMaker.FsmFloat::get_Value(this.normalizedTime);\nL_0072:\n\tv175 = HutongGames.PlayMaker.FsmString::get_Value(this.stateName);\n\tv153 = HutongGames.PlayMaker.FsmFloat::get_Value(this.transitionDuration);\n\tUnityEngine.Animator::CrossFade(this._animator, v175, v153, v95, v57);\nL_008C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && (_animator = ownerDefaultTarget.GetComponent<Animator>()) != null)
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
				float normalizedTimeOffset;
				if (normalizedTime.IsNone)
				{
					normalizedTimeOffset = float.NegativeInfinity;
				}
				else
				{
					float value2 = normalizedTime.Value;
					normalizedTimeOffset = value2;
				}
				string value3 = stateName.Value;
				float value4 = transitionDuration.Value;
				_animator.CrossFade(value3, value4, num, normalizedTimeOffset);
			}
			Finish();
		}

		[Token(Token = "0x60006D4")]
		[Address(RVA = "0xA87740", Offset = "0xA87740", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorCrossFade()
		{
		}
	}
}
