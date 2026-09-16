using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7529C4", Offset = "0x7529C4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7529C4", Offset = "0x7529C4")]
	[Token(Token = "0x200013E")]
	public class GetAnimatorCurrentTransitionInfoIsName : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A501C", Offset = "0x7A501C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A501C", Offset = "0x7A501C")]
		[Token(Token = "0x4001153")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A50B4", Offset = "0x7A50B4")]
		[Token(Token = "0x4001154")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5100", Offset = "0x7A5100")]
		[Token(Token = "0x4001155")]
		[FieldOffset(Offset = "0x68")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A5138", Offset = "0x7A5138")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A5138", Offset = "0x7A5138")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A5138", Offset = "0x7A5138")]
		[Token(Token = "0x4001156")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool nameMatch;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A51AC", Offset = "0x7A51AC")]
		[Token(Token = "0x4001157")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent nameMatchEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A51E4", Offset = "0x7A51E4")]
		[Token(Token = "0x4001158")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent nameDoNotMatchEvent;

		[Token(Token = "0x4001159")]
		[FieldOffset(Offset = "0x88")]
		private Animator _animator;

		[Token(Token = "0x6000720")]
		[Address(RVA = "0xB7F328", Offset = "0xB7F328", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tthis.nameMatchEvent = 0;\n\tthis.name = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			nameMatchEvent = null;
			name = null;
			gameObject = null;
		}

		[Token(Token = "0x6000721")]
		[Address(RVA = "0xB7F344", Offset = "0xB7F344", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB65A8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022999]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfoIsName::IsName(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000722")]
		[Address(RVA = "0xB7F580", Offset = "0xB7F580", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfoIsName::IsName(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			IsName();
		}

		[Token(Token = "0x6000723")]
		[Address(RVA = "0xB7F45C", Offset = "0xB7F45C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED76C8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202299A]) = v38;\nL_001D:\n\tgoto L_0026;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v41, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0065;\n\tv116 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv196 = UnityEngine.Animator::GetAnimatorTransitionInfo(this._animator, v116);\n\tv97 = v196.m_FullPath;\n\tv198 = HutongGames.PlayMaker.FsmString::get_Value(this.name);\n\tv192 = 0x1638F9C(&v97 @ stack_-60_v4 (System.Int32), v198, 0, v23, v24, v25, v26, v27, v196.m_Duration, v196.m_FullPath, v30, v31, v32, v33, v34, v35);\n\tv108 = this.nameMatch;\n\tv200 = v192 & 1;\n\tv201 = v200 == 0;\n\tif (v201) goto L_0059;\n\tv108.value = 1;\n\tv104 = this.fsm;\n\tv102 = this.nameMatchEvent;\n\tgoto L_005F;\nL_0059:\n\tv108.value = 0;\n\tv104 = this.fsm;\n\tv102 = this.nameDoNotMatchEvent;\nL_005F:\n\tHutongGames.PlayMaker.Fsm::Event(v104, v102);\nL_0065:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void IsName()
		{
			if (_animator != null)
			{
				int value = layerIndex.Value;
				int fullPath = _animator.GetAnimatorTransitionInfo(value).m_FullPath;
				string value2 = name.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1638F9C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x11C)");
				FsmBool fsmBool = nameMatch;
				object obj = default(object);
				Fsm fsm;
				FsmEvent fsmEvent;
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					fsmBool.value = true;
					fsm = Fsm;
					fsmEvent = nameMatchEvent;
				}
				else
				{
					fsmBool.value = false;
					fsm = Fsm;
					fsmEvent = nameDoNotMatchEvent;
				}
				fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000724")]
		[Address(RVA = "0xB7F584", Offset = "0xB7F584", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCurrentTransitionInfoIsName()
		{
		}
	}
}
