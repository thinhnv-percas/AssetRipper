using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7526A4", Offset = "0x7526A4")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7526A4", Offset = "0x7526A4")]
	[Token(Token = "0x2000133")]
	public class AnimatorStopRecording : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A3C24", Offset = "0x7A3C24")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3C24", Offset = "0x7A3C24")]
		[Token(Token = "0x4001112")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A3CBC", Offset = "0x7A3CBC")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A3CBC", Offset = "0x7A3CBC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3CBC", Offset = "0x7A3CBC")]
		[Token(Token = "0x4001113")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat recorderStartTime;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A3D30", Offset = "0x7A3D30")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A3D30", Offset = "0x7A3D30")]
		[Token(Token = "0x4001114")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat recorderStopTime;

		[Token(Token = "0x60006EB")]
		[Address(RVA = "0xA884C0", Offset = "0xA884C0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.recorderStartTime = 0;\n\tthis.recorderStopTime = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			recorderStartTime = null;
			recorderStopTime = null;
			gameObject = null;
		}

		[Token(Token = "0x60006EC")]
		[Address(RVA = "0xA884CC", Offset = "0xA884CC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F10448]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221AD]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv73 = *([v69 @ X8_v4+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_002B;\n\tv108 = v69;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v108, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv83 = UnityEngine.Object::op_Equality(v45, 0);\n\tv110 = v83 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0065;\n\tv133 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0046;\n\tv144 = *([v126 @ X8_v9+E0]);\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0046;\n\tv151 = v126;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v151, v132, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv123 = UnityEngine.Object::op_Inequality(v133, 0);\n\tv125 = v123 == 0;\n\tif (v125) goto L_0065;\n\tUnityEngine.Animator::StopRecording(v133);\n\tv135 = this.recorderStartTime;\n\tv134 = UnityEngine.Animator::get_recorderStartTime(v133);\n\tv135.value = v134;\n\tv116 = this.recorderStopTime;\n\tv113 = UnityEngine.Animator::get_recorderStopTime(v133);\n\tv116.value = v113;\nL_0065:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Animator component = ownerDefaultTarget.GetComponent<Animator>();
				if (component != null)
				{
					component.StopRecording();
					FsmFloat fsmFloat = recorderStartTime;
					float value = component.recorderStartTime;
					fsmFloat.Value = value;
					FsmFloat fsmFloat2 = recorderStopTime;
					float value2 = component.recorderStopTime;
					fsmFloat2.Value = value2;
				}
			}
			Finish();
		}

		[Token(Token = "0x60006ED")]
		[Address(RVA = "0xA88600", Offset = "0xA88600", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimatorStopRecording()
		{
		}
	}
}
