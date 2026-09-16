using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752924", Offset = "0x752924")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752924", Offset = "0x752924")]
	[Token(Token = "0x200013C")]
	public class GetAnimatorCurrentStateInfoIsTag : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A4BD4", Offset = "0x7A4BD4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4BD4", Offset = "0x7A4BD4")]
		[Token(Token = "0x4001145")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4C6C", Offset = "0x7A4C6C")]
		[Token(Token = "0x4001146")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4CB8", Offset = "0x7A4CB8")]
		[Token(Token = "0x4001147")]
		[FieldOffset(Offset = "0x68")]
		public FsmString tag;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A4CF0", Offset = "0x7A4CF0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A4CF0", Offset = "0x7A4CF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4CF0", Offset = "0x7A4CF0")]
		[Token(Token = "0x4001148")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool tagMatch;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4D64", Offset = "0x7A4D64")]
		[Token(Token = "0x4001149")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent tagMatchEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4D9C", Offset = "0x7A4D9C")]
		[Token(Token = "0x400114A")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent tagDoNotMatchEvent;

		[Token(Token = "0x400114B")]
		[FieldOffset(Offset = "0x88")]
		private Animator _animator;

		[Token(Token = "0x6000716")]
		[Address(RVA = "0xB7EDD8", Offset = "0xB7EDD8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrameOption = 0;\n\tthis.everyFrame = 0;\n\tthis.tagMatchEvent = 0;\n\tthis.tag = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			everyFrame = false;
			tagMatchEvent = null;
			tag = null;
			gameObject = null;
		}

		[Token(Token = "0x6000717")]
		[Address(RVA = "0xB7EDF4", Offset = "0xB7EDF4", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EE7D28]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022995]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentStateInfoIsTag::IsTag(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				IsTag();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000718")]
		[Address(RVA = "0xB7F040", Offset = "0xB7F040", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentStateInfoIsTag::IsTag(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			IsTag();
		}

		[Token(Token = "0x6000719")]
		[Address(RVA = "0xB7EF0C", Offset = "0xB7EF0C", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EB66B0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022996]) = v38;\nL_001E:\n\tgoto L_0027;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v22, v23, v24, v25, v26, v27, v42, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tv60 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0069;\n\tv122 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv209 = UnityEngine.Animator::GetCurrentAnimatorStateInfo(this._animator, v122);\n\tv103 = v209.m_Name;\n\tv211 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tv204 = 0x1638F30(&v103 @ stack_-78_v4 (System.Int32), v211, 0, v23, v24, v25, v26, v27, v209.m_Length, v209.m_Name, v30, v31, v32, v33, v34, v35);\n\tv114 = this.tagMatch;\n\tv213 = v204 & 1;\n\tv214 = v213 == 0;\n\tif (v214) goto L_005D;\n\tv114.value = 1;\n\tv110 = this.fsm;\n\tv108 = this.tagMatchEvent;\n\tgoto L_0063;\nL_005D:\n\tv114.value = 0;\n\tv110 = this.fsm;\n\tv108 = this.tagDoNotMatchEvent;\nL_0063:\n\tHutongGames.PlayMaker.Fsm::Event(v110, v108);\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void IsTag()
		{
			if (_animator != null)
			{
				int value = layerIndex.Value;
				int shortNameHash = _animator.GetCurrentAnimatorStateInfo(value).shortNameHash;
				string value2 = tag.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F30 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xB0)");
				FsmBool fsmBool = tagMatch;
				object obj = default(object);
				Fsm fsm;
				FsmEvent fsmEvent;
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					fsmBool.value = true;
					fsm = Fsm;
					fsmEvent = tagMatchEvent;
				}
				else
				{
					fsmBool.value = false;
					fsm = Fsm;
					fsmEvent = tagDoNotMatchEvent;
				}
				fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x600071A")]
		[Address(RVA = "0xB7F044", Offset = "0xB7F044", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCurrentStateInfoIsTag()
		{
		}
	}
}
