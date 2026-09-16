using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7524C4", Offset = "0x7524C4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7524C4", Offset = "0x7524C4")]
	[Token(Token = "0x200012D")]
	public class AnimatorInterruptMatchTarget : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3538", Offset = "0x7A3538")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3538", Offset = "0x7A3538")]
		[Token(Token = "0x40010FA")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A35D0", Offset = "0x7A35D0")]
		[Token(Token = "0x40010FB")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool completeMatch;

		[Token(Token = "0x60006D5")]
		[Address(RVA = "0xA87748", Offset = "0xA87748", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.completeMatch = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			completeMatch = fsmBool;
		}

		[Token(Token = "0x60006D6")]
		[Address(RVA = "0xA87778", Offset = "0xA87778", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EEEC98]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221A3]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv77 = *([v73 @ X8_v4+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv110 = v73;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv87 = UnityEngine.Object::op_Equality(v45, 0);\n\tv112 = v87 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_005D;\n\tv128 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0046;\n\tv135 = *([v66 @ X8_v9+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0046;\n\tv142 = v66;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v142, v127, v86, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv120 = UnityEngine.Object::op_Inequality(v128, 0);\n\tv122 = v120 == 0;\n\tif (v122) goto L_005D;\n\tv131 = HutongGames.PlayMaker.FsmBool::get_Value(this.completeMatch);\n\tUnityEngine.Animator::InterruptMatchTarget(v128, v131);\nL_005D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Animator component = ownerDefaultTarget.GetComponent<Animator>();
				if (component != null)
				{
					bool value = completeMatch.Value;
					component.InterruptMatchTarget(value);
				}
			}
			Finish();
		}

		[Token(Token = "0x60006D7")]
		[Address(RVA = "0xA87890", Offset = "0xA87890", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorInterruptMatchTarget()
		{
		}
	}
}
