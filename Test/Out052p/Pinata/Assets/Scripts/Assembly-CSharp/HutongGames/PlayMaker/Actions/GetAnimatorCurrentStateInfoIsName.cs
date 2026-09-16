using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7528D4", Offset = "0x7528D4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7528D4", Offset = "0x7528D4")]
	[Token(Token = "0x200013B")]
	public class GetAnimatorCurrentStateInfoIsName : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A49D4", Offset = "0x7A49D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A49D4", Offset = "0x7A49D4")]
		[Token(Token = "0x400113E")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4A6C", Offset = "0x7A4A6C")]
		[Token(Token = "0x400113F")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4AB8", Offset = "0x7A4AB8")]
		[Token(Token = "0x4001140")]
		[FieldOffset(Offset = "0x68")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A4AF0", Offset = "0x7A4AF0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A4AF0", Offset = "0x7A4AF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4AF0", Offset = "0x7A4AF0")]
		[Token(Token = "0x4001141")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool isMatching;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4B64", Offset = "0x7A4B64")]
		[Token(Token = "0x4001142")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent nameMatchEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A4B9C", Offset = "0x7A4B9C")]
		[Token(Token = "0x4001143")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent nameDoNotMatchEvent;

		[Token(Token = "0x4001144")]
		[FieldOffset(Offset = "0x88")]
		private Animator _animator;

		[Token(Token = "0x6000711")]
		[Address(RVA = "0xB7EB24", Offset = "0xB7EB24", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrameOption = 0;\n\tthis.everyFrame = 0;\n\tthis.layerIndex = 0;\n\tthis.name = 0;\n\tthis.gameObject = 0;\n\tthis.nameMatchEvent = 0;\n\tthis.nameDoNotMatchEvent = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			everyFrame = false;
			layerIndex = null;
			name = null;
			gameObject = null;
			nameMatchEvent = null;
			nameDoNotMatchEvent = null;
		}

		[Token(Token = "0x6000712")]
		[Address(RVA = "0xB7EB3C", Offset = "0xB7EB3C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EE8750]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022993]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentStateInfoIsName::IsName(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000713")]
		[Address(RVA = "0xB7EDCC", Offset = "0xB7EDCC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentStateInfoIsName::IsName(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			IsName();
		}

		[Token(Token = "0x6000714")]
		[Address(RVA = "0xB7EC54", Offset = "0xB7EC54", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = *([1EC5800]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022994]) = v40;\nL_001F:\n\tgoto L_0028;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0028;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v44, v31, v32, v33, v34, v35, v36, v37);\nL_0028:\n\tv62 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_007F;\n\tv125 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv222 = UnityEngine.Animator::GetCurrentAnimatorStateInfo(this._animator, v125);\n\tv104 = v222.m_Name;\n\tv223 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isMatching);\n\tv225 = v223 == 0;\n\tif (v225) goto L_0053;\n\tv117 = this + 0x68;\n\tgoto L_0066;\nL_0053:\n\tv117 = this + 0x68;\n\tv208 = this.isMatching;\n\tv232 = HutongGames.PlayMaker.FsmString::get_Value(this.name);\n\tv214 = 0x1638E8C(&v104 @ stack_-88_v4 (System.Int32), v232, 0, v25, v26, v27, v28, v29, v222.m_Length, v222.m_Name, v32, v33, v34, v35, v36, v37);\n\tv230 = v214 & 1;\n\tv208.value = v230;\nL_0066:\n\tv234 = HutongGames.PlayMaker.FsmString::get_Value(*([v117 @ X20_v8]));\n\tv215 = 0x1638E8C(&v104 @ stack_-88_v4 (System.Int32), v234, 0, v25, v26, v27, v28, v29, v222.m_Length, v222.m_Name, v32, v33, v34, v35, v36, v37);\n\tv237 = v215 & 1;\n\tv238 = v237 == 0;\n\tif (v238) goto L_0075;\n\tv109 = this.nameMatchEvent;\n\tgoto L_0078;\nL_0075:\n\tv109 = this.nameDoNotMatchEvent;\nL_0078:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v109);\nL_007F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void IsName()
		{
			//IL_00b4: Expected O, but got I
			//IL_00a3: Expected O, but got I
			if (_animator != null)
			{
				int value = layerIndex.Value;
				int shortNameHash = _animator.GetCurrentAnimatorStateInfo(value).shortNameHash;
				object obj;
				if (isMatching.IsNone)
				{
					obj = (long)(IntPtr)this + 104L;
				}
				else
				{
					obj = (long)(IntPtr)this + 104L;
					FsmBool fsmBool = isMatching;
					string value2 = name.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638E8C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xC)");
					object obj2 = default(object);
					int value3 = (int)((long)(IntPtr)obj2 & 1L);
					fsmBool.value = (byte)value3 != 0;
				}
				string value4 = ((FsmString)obj).Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638E8C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xC)");
				object obj3 = default(object);
				FsmEvent fsmEvent = (((int)((long)(IntPtr)obj3 & 1L) == 0) ? nameDoNotMatchEvent : nameMatchEvent);
				Fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x6000715")]
		[Address(RVA = "0xB7EDD0", Offset = "0xB7EDD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCurrentStateInfoIsName()
		{
		}
	}
}
