using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752A14", Offset = "0x752A14")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752A14", Offset = "0x752A14")]
	[Token(Token = "0x200013F")]
	public class GetAnimatorCurrentTransitionInfoIsUserName : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A521C", Offset = "0x7A521C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A521C", Offset = "0x7A521C")]
		[Token(Token = "0x400115A")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A52B4", Offset = "0x7A52B4")]
		[Token(Token = "0x400115B")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5300", Offset = "0x7A5300")]
		[Token(Token = "0x400115C")]
		[FieldOffset(Offset = "0x68")]
		public FsmString userName;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A5338", Offset = "0x7A5338")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5338", Offset = "0x7A5338")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5338", Offset = "0x7A5338")]
		[Token(Token = "0x400115D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool nameMatch;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A53AC", Offset = "0x7A53AC")]
		[Token(Token = "0x400115E")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent nameMatchEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A53E4", Offset = "0x7A53E4")]
		[Token(Token = "0x400115F")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent nameDoNotMatchEvent;

		[Token(Token = "0x4001160")]
		[FieldOffset(Offset = "0x88")]
		private Animator _animator;

		[Token(Token = "0x6000725")]
		[Address(RVA = "0xB7F58C", Offset = "0xB7F58C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.nameMatchEvent = 0;\n\tthis.userName = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			nameMatchEvent = null;
			userName = null;
			gameObject = null;
		}

		[Token(Token = "0x6000726")]
		[Address(RVA = "0xB7F5A8", Offset = "0xB7F5A8", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF5F90]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202299B]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfoIsUserName::IsName(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				IsName();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000727")]
		[Address(RVA = "0xB7F7F8", Offset = "0xB7F7F8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfoIsUserName::IsName(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			IsName();
		}

		[Token(Token = "0x6000728")]
		[Address(RVA = "0xB7F6C0", Offset = "0xB7F6C0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED1D98]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202299C]) = v38;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v41, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_006E;\n\tv117 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv199 = UnityEngine.Animator::GetAnimatorTransitionInfo(this._animator, v117);\n\tv97 = v199.m_FullPath;\n\tv201 = HutongGames.PlayMaker.FsmString::get_Value(this.userName);\n\tv191 = 0x1639030(&v97 @ stack_-60_v4 (System.Int32), v201, 0, v23, v24, v25, v26, v27, v199.m_Duration, v199.m_FullPath, v30, v31, v32, v33, v34, v35);\n\tv192 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.nameMatch);\n\tv205 = v192 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_005D;\n\tv196 = this.nameMatch;\n\tv207 = v191 & 1;\n\tv196.value = v207;\nL_005D:\n\tv209 = v191 & 1;\n\tv210 = v209 == 0;\n\tif (v210) goto L_0066;\n\tv102 = this.nameMatchEvent;\n\tgoto L_0068;\nL_0066:\n\tv102 = this.nameDoNotMatchEvent;\nL_0068:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v102);\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void IsName()
		{
			if (_animator != null)
			{
				int value = layerIndex.Value;
				int fullPath = _animator.GetAnimatorTransitionInfo(value).m_FullPath;
				string value2 = userName.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1639030 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x1B0)");
				object obj = default(object);
				if (!nameMatch.IsNone)
				{
					FsmBool fsmBool = nameMatch;
					int value3 = (int)((long)(IntPtr)obj & 1L);
					fsmBool.value = (byte)value3 != 0;
				}
				FsmEvent fsmEvent = (((int)((long)(IntPtr)obj & 1L) == 0) ? nameDoNotMatchEvent : nameMatchEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000729")]
		[Address(RVA = "0xB7F7FC", Offset = "0xB7F7FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCurrentTransitionInfoIsUserName()
		{
		}
	}
}
