using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7525B4", Offset = "0x7525B4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7525B4", Offset = "0x7525B4")]
	[Token(Token = "0x2000130")]
	public class AnimatorStartPlayback : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3A10", Offset = "0x7A3A10")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3A10", Offset = "0x7A3A10")]
		[Token(Token = "0x400110E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x60006E2")]
		[Address(RVA = "0xA88148", Offset = "0xA88148", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x60006E3")]
		[Address(RVA = "0xA88150", Offset = "0xA88150", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED1BB0]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221AA]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v66 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv103 = v66;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v103, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv80 = UnityEngine.Object::op_Equality(v45, 0);\n\tv105 = v80 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0057;\n\tv125 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0046;\n\tv130 = *([v118 @ X8_v9+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0046;\n\tv137 = v118;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v137, v124, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv115 = UnityEngine.Object::op_Inequality(v125, 0);\n\tv117 = v115 == 0;\n\tif (v117) goto L_0057;\n\tUnityEngine.Animator::StartPlayback(v125);\nL_0057:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Animator component = ownerDefaultTarget.GetComponent<Animator>();
				if (component != null)
				{
					component.StartPlayback();
				}
			}
			Finish();
		}

		[Token(Token = "0x60006E4")]
		[Address(RVA = "0xA88254", Offset = "0xA88254", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorStartPlayback()
		{
		}
	}
}
