using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752974", Offset = "0x752974")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752974", Offset = "0x752974")]
	[Token(Token = "0x200013D")]
	public class GetAnimatorCurrentTransitionInfo : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A4DD4", Offset = "0x7A4DD4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4DD4", Offset = "0x7A4DD4")]
		[Token(Token = "0x400114C")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4E6C", Offset = "0x7A4E6C")]
		[Token(Token = "0x400114D")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7A4EB8", Offset = "0x7A4EB8")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4EB8", Offset = "0x7A4EB8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4EB8", Offset = "0x7A4EB8")]
		[Token(Token = "0x400114E")]
		[FieldOffset(Offset = "0x68")]
		public FsmString name;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4F2C", Offset = "0x7A4F2C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4F2C", Offset = "0x7A4F2C")]
		[Token(Token = "0x400114F")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt nameHash;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4F7C", Offset = "0x7A4F7C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4F7C", Offset = "0x7A4F7C")]
		[Token(Token = "0x4001150")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt userNameHash;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7A4FCC", Offset = "0x7A4FCC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A4FCC", Offset = "0x7A4FCC")]
		[Token(Token = "0x4001151")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat normalizedTime;

		[Token(Token = "0x4001152")]
		[FieldOffset(Offset = "0x88")]
		private Animator _animator;

		[Token(Token = "0x600071B")]
		[Address(RVA = "0xB7F04C", Offset = "0xB7F04C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrameOption = 0;\n\tthis.everyFrame = 0;\n\tthis.userNameHash = 0;\n\tthis.name = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			everyFrame = false;
			userNameHash = null;
			name = null;
			gameObject = null;
		}

		[Token(Token = "0x600071C")]
		[Address(RVA = "0xB7F068", Offset = "0xB7F068", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EAA2B0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022997]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfo::GetTransitionInfo(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				GetTransitionInfo();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x600071D")]
		[Address(RVA = "0xB7F31C", Offset = "0xB7F31C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorCurrentTransitionInfo::GetTransitionInfo(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			GetTransitionInfo();
		}

		[Token(Token = "0x600071E")]
		[Address(RVA = "0xB7F180", Offset = "0xB7F180", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv20 = *([1EA4198]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022998]) = v40;\nL_001E:\n\tgoto L_0027;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0027;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v24, v25, v26, v27, v28, v29, v43, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tv61 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_0093;\n\tv124 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv225 = UnityEngine.Animator::GetAnimatorTransitionInfo(this._animator, v124);\n\tv98 = v225.m_FullPath;\n\tv226 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv228 = v226 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0061;\n\tv206 = this.name;\n\tv212 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv213 = UnityEngine.Animator::GetLayerName(this._animator, v212);\n\tv206.value = v213;\nL_0061:\n\tv234 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.nameHash);\n\tv236 = v234 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0071;\n\tv221 = this.nameHash;\n\tv214 = 0x163908C(&v98 @ stack_-70_v4 (System.Int32), 0, v101, v25, v26, v27, v28, v29, v225.m_Duration, v225.m_FullPath, v32, v33, v34, v35, v36, v37);\n\tv221.value = v214;\nL_0071:\n\tv243 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.userNameHash);\n\tv245 = v243 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_0081;\n\tv222 = this.userNameHash;\n\tv215 = 0x1639094(&v98 @ stack_-70_v4 (System.Int32), 0, v101, v25, v26, v27, v28, v29, v225.m_Duration, v225.m_FullPath, v32, v33, v34, v35, v36, v37);\n\tv222.value = v215;\nL_0081:\n\tv107 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.normalizedTime);\n\tv251 = v107 == 0;\n\tv110 = ~v251;\n\tif (v110) goto L_0093;\n\tv112 = this.normalizedTime;\n\tv106 = 0x163909C(&v98 @ stack_-70_v4 (System.Int32), 0, v101, v25, v26, v27, v28, v29, v225.m_Duration, v225.m_FullPath, v32, v33, v34, v35, v36, v37);\n\tv112.value = v225.m_Duration;\nL_0093:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetTransitionInfo()
		{
			//IL_009d: Expected O, but got I4
			//IL_00f7: Expected O, but got I4
			if (_animator != null)
			{
				int value = layerIndex.Value;
				AnimatorTransitionInfo animatorTransitionInfo = _animator.GetAnimatorTransitionInfo(value);
				int fullPath = animatorTransitionInfo.m_FullPath;
				bool isNone = name.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					FsmString fsmString = name;
					int value2 = layerIndex.Value;
					string layerName = _animator.GetLayerName(value2);
					fsmString.Value = layerName;
					obj = 0;
				}
				if (!nameHash.IsNone)
				{
					FsmInt fsmInt = nameHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163908C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x20C)");
					int value3 = default(int);
					fsmInt.Value = value3;
				}
				if (!userNameHash.IsNone)
				{
					FsmInt fsmInt2 = userNameHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1639094 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x214)");
					int value4 = default(int);
					fsmInt2.Value = value4;
				}
				if (!normalizedTime.IsNone)
				{
					FsmFloat fsmFloat = normalizedTime;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163909C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x21C)");
					fsmFloat.Value = animatorTransitionInfo.m_Duration;
				}
			}
		}

		[Token(Token = "0x600071F")]
		[Address(RVA = "0xB7F320", Offset = "0xB7F320", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorCurrentTransitionInfo()
		{
		}
	}
}
