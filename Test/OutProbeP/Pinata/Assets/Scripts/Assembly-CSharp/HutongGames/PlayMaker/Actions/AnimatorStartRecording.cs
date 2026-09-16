using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752604", Offset = "0x752604")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752604", Offset = "0x752604")]
	[Token(Token = "0x2000131")]
	public class AnimatorStartRecording : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3AA8", Offset = "0x7A3AA8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3AA8", Offset = "0x7A3AA8")]
		[Token(Token = "0x400110F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3B40", Offset = "0x7A3B40")]
		[Token(Token = "0x4001110")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt frameCount;

		[Token(Token = "0x60006E5")]
		[Address(RVA = "0xA8825C", Offset = "0xA8825C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.frameCount = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			frameCount = fsmInt;
		}

		[Token(Token = "0x60006E6")]
		[Address(RVA = "0xA8828C", Offset = "0xA8828C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EED550]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221AB]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv77 = *([v73 @ X8_v4+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002B;\n\tv110 = v73;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v110, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv87 = UnityEngine.Object::op_Equality(v45, 0);\n\tv112 = v87 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_005D;\n\tv128 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0046;\n\tv134 = *([v66 @ X8_v9+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tif (v136) goto L_0046;\n\tv141 = v66;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v141, v127, v86, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv120 = UnityEngine.Object::op_Inequality(v128, 0);\n\tv122 = v120 == 0;\n\tif (v122) goto L_005D;\n\tv130 = HutongGames.PlayMaker.FsmInt::get_Value(this.frameCount);\n\tUnityEngine.Animator::StartRecording(v128, v130);\nL_005D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Animator component = ownerDefaultTarget.GetComponent<Animator>();
				if (component != null)
				{
					int value = frameCount.Value;
					component.StartRecording(value);
				}
			}
			Finish();
		}

		[Token(Token = "0x60006E7")]
		[Address(RVA = "0xA883A4", Offset = "0xA883A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorStartRecording()
		{
		}
	}
}
