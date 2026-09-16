using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752F64", Offset = "0x752F64")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752F64", Offset = "0x752F64")]
	[Token(Token = "0x2000150")]
	public class GetAnimatorNextStateInfo : FsmStateActionAnimatorBase
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A6B70", Offset = "0x7A6B70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6B70", Offset = "0x7A6B70")]
		[Token(Token = "0x40011AC")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6C08", Offset = "0x7A6C08")]
		[Token(Token = "0x40011AD")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt layerIndex;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7A6C54", Offset = "0x7A6C54")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6C54", Offset = "0x7A6C54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6C54", Offset = "0x7A6C54")]
		[Token(Token = "0x40011AE")]
		[FieldOffset(Offset = "0x68")]
		public FsmString name;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6CC8", Offset = "0x7A6CC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6CC8", Offset = "0x7A6CC8")]
		[Token(Token = "0x40011AF")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt nameHash;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6D18", Offset = "0x7A6D18")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6D18", Offset = "0x7A6D18")]
		[Token(Token = "0x40011B0")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt fullPathHash;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6D68", Offset = "0x7A6D68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6D68", Offset = "0x7A6D68")]
		[Token(Token = "0x40011B1")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt shortPathHash;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6DB8", Offset = "0x7A6DB8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6DB8", Offset = "0x7A6DB8")]
		[Token(Token = "0x40011B2")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt tagHash;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6E08", Offset = "0x7A6E08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6E08", Offset = "0x7A6E08")]
		[Token(Token = "0x40011B3")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isStateLooping;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6E58", Offset = "0x7A6E58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6E58", Offset = "0x7A6E58")]
		[Token(Token = "0x40011B4")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat length;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6EA8", Offset = "0x7A6EA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6EA8", Offset = "0x7A6EA8")]
		[Token(Token = "0x40011B5")]
		[FieldOffset(Offset = "0xA0")]
		public FsmFloat normalizedTime;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6EF8", Offset = "0x7A6EF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6EF8", Offset = "0x7A6EF8")]
		[Token(Token = "0x40011B6")]
		[FieldOffset(Offset = "0xA8")]
		public FsmInt loopCount;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A6F48", Offset = "0x7A6F48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A6F48", Offset = "0x7A6F48")]
		[Token(Token = "0x40011B7")]
		[FieldOffset(Offset = "0xB0")]
		public FsmFloat currentLoopProgress;

		[Token(Token = "0x40011B8")]
		[FieldOffset(Offset = "0xB8")]
		private Animator _animator;

		[Token(Token = "0x6000774")]
		[Address(RVA = "0xB81868", Offset = "0xB81868", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.everyFrameOption = 0;\n\tv7 = this + 0x58;\n\tv10 = 0x6D26F0(v7, 0, 0x60, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_002b: Expected O, but got I
			everyFrame = false;
			everyFrameOption = default(AnimatorFrameUpdateSelector);
			object obj = (long)(IntPtr)this + 88L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6000775")]
		[Address(RVA = "0xB81890", Offset = "0xB81890", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC8848]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20229BD]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv70 = *([v50 @ X8_v4+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002B;\n\tv77 = v50;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v77, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv63 = UnityEngine.Object::op_Equality(v45, 0);\n\tv79 = v63 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_005F;\n\tv123 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._animator = v123;\n\tgoto L_0046;\n\tv128 = *([v124 @ X0_v15+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0046;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v122, v59, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv114 = UnityEngine.Object::op_Equality(v123, 0);\n\tv136 = v114 == 0;\n\tv115 = ~v136;\n\tif (v115) goto L_005F;\n\tHutongGames.PlayMaker.Actions.GetAnimatorNextStateInfo::GetLayerInfo(this);\n\tv98 = ~this.everyFrame;\n\tif (v98) goto L_005F;\n\treturn;\nL_005F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !((_animator = ownerDefaultTarget.GetComponent<Animator>()) == null))
			{
				GetLayerInfo();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000776")]
		[Address(RVA = "0xB81CB8", Offset = "0xB81CB8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAnimatorNextStateInfo::GetLayerInfo(this);\n\treturn;\n")]
		public override void OnActionUpdate()
		{
			GetLayerInfo();
		}

		[Token(Token = "0x6000777")]
		[Address(RVA = "0xB819A8", Offset = "0xB819A8", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EBAAE0]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20229BE]) = v42;\nL_0020:\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v26, v27, v28, v29, v30, v31, v46, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tv64 = UnityEngine.Object::op_Inequality(this._animator, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0112;\n\tv136 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv300 = UnityEngine.Animator::GetNextAnimatorStateInfo(this._animator, v136);\n\tv109 = v300.m_Name;\n\tv302 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fullPathHash);\n\tv304 = v302 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_005D;\n\tv288 = this.fullPathHash;\n\tv267 = 0x1638F08(&v109 @ stack_-88_v4 (System.Int32), 0, 0, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv288.value = v267;\nL_005D:\n\tv310 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.shortPathHash);\n\tv312 = v310 == 0;\n\tv313 = ~v312;\n\tif (v313) goto L_006D;\n\tv289 = this.shortPathHash;\n\tv268 = 0x1638F10(&v109 @ stack_-88_v4 (System.Int32), 0, 0, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv289.value = v268;\nL_006D:\n\tv318 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.nameHash);\n\tv320 = v318 == 0;\n\tv321 = ~v320;\n\tif (v321) goto L_007D;\n\tv290 = this.nameHash;\n\tv269 = 0x1638F10(&v109 @ stack_-88_v4 (System.Int32), 0, 0, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv290.value = v269;\nL_007D:\n\tv325 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv327 = v325 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0096;\n\tv255 = this.name;\n\tv270 = HutongGames.PlayMaker.FsmInt::get_Value(this.layerIndex);\n\tv271 = UnityEngine.Animator::GetLayerName(this._animator, v270);\n\tv255.value = v271;\nL_0096:\n\tv333 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.tagHash);\n\tv335 = v333 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_00A6;\n\tv292 = this.tagHash;\n\tv272 = 0x1638F28(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv292.value = v272;\nL_00A6:\n\tv342 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.length);\n\tv344 = v342 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_00B6;\n\tv293 = this.length;\n\tv273 = 0x1638F20(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv293.value = v300.m_Length;\nL_00B6:\n\tv350 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isStateLooping);\n\tv352 = v350 == 0;\n\tv353 = ~v352;\n\tif (v353) goto L_00C7;\n\tv294 = this.isStateLooping;\n\tv274 = 0x1638F8C(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv357 = v274 & 1;\n\tv294.value = v357;\nL_00C7:\n\tv359 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.normalizedTime);\n\tv361 = v359 == 0;\n\tv362 = ~v361;\n\tif (v362) goto L_00D7;\n\tv295 = this.normalizedTime;\n\tv275 = 0x1638F18(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv295.value = v300.m_Length;\nL_00D7:\n\tv366 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.loopCount);\n\tv368 = v366 == 0;\n\tif (v368) goto L_00E4;\n\tv118 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.currentLoopProgress);\n\tv381 = v118 == 0;\n\tv121 = ~v381;\n\tif (v121) goto L_0112;\nL_00E4:\n\tv296 = this.loopCount;\n\tv373 = 0x1638F18(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v300.m_Length, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tgoto L_00F7;\n\tv382 = *([v376 @ X0_v45+E0]);\n\tv383 = v382 == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_00F7;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v376, v265, v112, v27, v28, v29, v30, v31, v83, v80, v34, v35, v36, v37, v38, v39);\nL_00F7:\n\tv144 = System.Math::Truncate(v300.m_Length);\n\tv296.value = v144;\n\tv126 = this.currentLoopProgress;\n\tv390 = 0x1638F18(&v109 @ stack_-88_v4 (System.Int32), 0, v112, v27, v28, v29, v30, v31, v144, v300.m_Name, v34, v35, v36, v37, v38, v39);\n\tv117 = HutongGames.PlayMaker.FsmInt::get_Value(this.loopCount);\n\tv82 = v144 - v117;\n\tv126.value = v82;\nL_0112:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void GetLayerInfo()
		{
			//IL_01c3: Expected O, but got I4
			//IL_021d: Expected O, but got I4
			//IL_0463: Expected I4, but got F8
			if (_animator != null)
			{
				int value = layerIndex.Value;
				AnimatorStateInfo nextAnimatorStateInfo = _animator.GetNextAnimatorStateInfo(value);
				int shortNameHash = nextAnimatorStateInfo.shortNameHash;
				if (!fullPathHash.IsNone)
				{
					FsmInt fsmInt = fullPathHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F08 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x88)");
					int value2 = default(int);
					fsmInt.Value = value2;
				}
				if (!shortPathHash.IsNone)
				{
					FsmInt fsmInt2 = shortPathHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F10 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x90)");
					int value3 = default(int);
					fsmInt2.Value = value3;
				}
				if (!nameHash.IsNone)
				{
					FsmInt fsmInt3 = nameHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F10 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x90)");
					int value4 = default(int);
					fsmInt3.Value = value4;
				}
				bool isNone = name.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					FsmString fsmString = name;
					int value5 = layerIndex.Value;
					string layerName = _animator.GetLayerName(value5);
					fsmString.Value = layerName;
					obj = 0;
				}
				if (!tagHash.IsNone)
				{
					FsmInt fsmInt4 = tagHash;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F28 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xA8)");
					int value6 = default(int);
					fsmInt4.Value = value6;
				}
				if (!length.IsNone)
				{
					FsmFloat fsmFloat = length;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F20 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0xA0)");
					fsmFloat.Value = nextAnimatorStateInfo.length;
				}
				if (!isStateLooping.IsNone)
				{
					FsmBool fsmBool = isStateLooping;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F8C (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x10C)");
					object obj2 = default(object);
					int value7 = (int)((long)(IntPtr)obj2 & 1L);
					fsmBool.value = (byte)value7 != 0;
				}
				if (!normalizedTime.IsNone)
				{
					FsmFloat fsmFloat2 = normalizedTime;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F18 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x98)");
					fsmFloat2.Value = nextAnimatorStateInfo.length;
				}
				if (!loopCount.IsNone || !currentLoopProgress.IsNone)
				{
					FsmInt fsmInt5 = loopCount;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F18 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x98)");
					double num = Math.Truncate(nextAnimatorStateInfo.length);
					fsmInt5.Value = (int)num;
					FsmFloat fsmFloat3 = currentLoopProgress;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1638F18 (inside UnityEngine.AnimatorOverrideController+OnOverrideControllerDirtyCallback::EndInvoke +0x98)");
					int value8 = loopCount.Value;
					double num2 = num - (double)value8;
					fsmFloat3.Value = (float)num2;
				}
			}
		}

		[Token(Token = "0x6000778")]
		[Address(RVA = "0xB81CBC", Offset = "0xB81CBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAnimatorNextStateInfo()
		{
		}
	}
}
