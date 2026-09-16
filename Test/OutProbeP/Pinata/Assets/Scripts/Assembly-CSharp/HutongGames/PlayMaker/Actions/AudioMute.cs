using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7541F4", Offset = "0x7541F4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7541F4", Offset = "0x7541F4")]
	[Token(Token = "0x2000185")]
	public class AudioMute : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AADA0", Offset = "0x7AADA0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AADA0", Offset = "0x7AADA0")]
		[Token(Token = "0x400129C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AAE38", Offset = "0x7AAE38")]
		[Token(Token = "0x400129D")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool mute;

		[Token(Token = "0x6000864")]
		[Address(RVA = "0xA8A91C", Offset = "0xA8A91C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.mute = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			mute = fsmBool;
		}

		[Token(Token = "0x6000865")]
		[Address(RVA = "0xA8A94C", Offset = "0xA8A94C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECFB08]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221BE]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv88 = *([v66 @ X8_v5+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_002B;\n\tv95 = v66;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v95, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv79 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv97 = v79 == 0;\n\tif (v97) goto L_005C;\n\tv132 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv136 = *([v60 @ X8_v9+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0045;\n\tv143 = v60;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v143, v131, v74, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv125 = UnityEngine.Object::op_Inequality(v132, 0);\n\tv126 = v125 == 0;\n\tif (v126) goto L_005C;\n\tv80 = HutongGames.PlayMaker.FsmBool::get_Value(this.mute);\n\tUnityEngine.AudioSource::set_mute(v132, v80);\nL_005C:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				AudioSource component = ownerDefaultTarget.GetComponent<AudioSource>();
				if (component != null)
				{
					bool value = mute.Value;
					component.mute = value;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000866")]
		[Address(RVA = "0xA8AA68", Offset = "0xA8AA68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AudioMute()
		{
		}
	}
}
