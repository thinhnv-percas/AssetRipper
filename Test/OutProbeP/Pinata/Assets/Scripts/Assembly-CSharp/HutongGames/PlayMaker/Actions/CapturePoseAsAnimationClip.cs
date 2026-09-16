using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752154", Offset = "0x752154")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x752154", Offset = "0x752154")]
	[Token(Token = "0x2000122")]
	public class CapturePoseAsAnimationClip : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A274C", Offset = "0x7A274C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A274C", Offset = "0x7A274C")]
		[Token(Token = "0x40010C3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A27E4", Offset = "0x7A27E4")]
		[Token(Token = "0x40010C4")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool position;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A281C", Offset = "0x7A281C")]
		[Token(Token = "0x40010C5")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool rotation;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A2854", Offset = "0x7A2854")]
		[Token(Token = "0x40010C6")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool scale;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A288C", Offset = "0x7A288C")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7A288C", Offset = "0x7A288C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A288C", Offset = "0x7A288C")]
		[Token(Token = "0x40010C7")]
		[FieldOffset(Offset = "0x70")]
		public FsmObject storeAnimationClip;

		[Token(Token = "0x600069A")]
		[Address(RVA = "0xA8E78C", Offset = "0xA8E78C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.position = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.rotation = v15;\n\tv18 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.scale = v18;\n\tthis.storeAnimationClip = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			position = fsmBool;
			FsmBool fsmBool2 = true;
			rotation = fsmBool2;
			FsmBool fsmBool3 = false;
			scale = fsmBool3;
			storeAnimationClip = null;
		}

		[Token(Token = "0x600069B")]
		[Address(RVA = "0xA8E7DC", Offset = "0xA8E7DC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::DoCaptureAnimationClip(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoCaptureAnimationClip();
			Finish();
		}

		[Token(Token = "0x600069C")]
		[Address(RVA = "0xA8E804", Offset = "0xA8E804", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED0540]);\n\tv27 = *([v26 @ X8_v33]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20221DC]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002E;\n\tv159 = *([v126 @ X8_v18+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_002E;\n\tv168 = v126;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v168, v49, v50, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002E:\n\tv167 = UnityEngine.Object::op_Equality(v51, 0);\n\tv170 = v167 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0134;\n\tv184 = new UnityEngine.AnimationClip();\n\tUnityEngine.AnimationClip::.ctor(v184);\n\tv114 = UnityEngine.GameObject::get_transform(v51);\n\tv153 = UnityEngine.Transform::GetEnumerator(v114);\n\tv155 = v153 == 0;\n\tif (v155) goto L_00D5;\nL_0050:\n\tgoto L_0077;\n\tv542 = *([v530 @ X8_v22+B0]);\n\tv543 = 0;\n\tv544 = v542 + 8;\n\tv546 = *([v583 @ X11_v28-8]);\n\tv588 = v546 == v531;\n\tif (v588) goto L_0070;\n\tv566 = v582 + 1;\n\tv593 = v566 < v532;\n\tv564 = ~v593;\n\tv568 = v583 + 0x10;\n\tv548 = ~v564;\n\tif (v548) goto L_FFFFFFFF;\n\tv569 = v104;\n\tv570 = 0;\n\tv571 = 0x8909C4(v569, v531, v570, v56, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0077;\nL_0070:\n\tv594 = *([v583 @ X11_v28]);\n\tv595 = v594 << 4;\n\tv596 = v530 + v595;\n\tv597 = v596 + 0x130;\nL_0077:\n\tv393 = System.Collections.IEnumerator::MoveNext(v153);\n\tv395 = v393 == 0;\n\tif (v395) goto L_FFFFFFFF;\n\tv602 = *([v153 @ X0_v36 (System.Collections.IEnumerator)]);\n\tv605 = *([v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v605) goto L_009D;\n\tv647 = *([v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0088:\n\tv652 = *([v647 @ X11_v23-8]) == System.Collections.IEnumerator;\n\tif (v652) goto L_00A0;\n\tv646 = v646 + 1;\n\tv657 = v646 < *([v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv628 = ~v657;\n\tv647 = v647 + 0x10;\n\tv612 = ~v628;\n\tif (v612) goto L_0088;\nL_009D:\n\tv676 = 0x8909C4(v153, System.Collections.IEnumerator, 1, v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00A7;\nL_00A0:\n\tv659 = *([v647 @ X11_v23]) + 1;\n\tv660 = v659 << 4;\n\tv661 = v602 + v660;\n\tv676 = v661 + 0x130;\nL_00A7:\n\t*([v676 @ X0_v41])(v681, v153, *([v676 @ X0_v41+8]), v282, v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv116 = v681 == 0;\n\tif (v116) goto L_00CD;\n\tgoto L_FFFFFFFF;\n\tv694 = v694_asT == 0;\n\tif (v694) goto L_00D3;\nL_00CD:\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::CaptureTransform(this, v681, \"\", v184);\n\tgoto L_0050;\n\tgoto L_00ED;\nL_00D3:\n\tv113 = new System.InvalidCastException();\n\tv123 = new System.NullReferenceException();\nL_00D5:\n\tv158 = new System.NullReferenceException();\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tv181 = v284 != 1;\n\tif (v181) goto L_013B;\n\tv243 = 0x6D2BC0(v158, v284, v282, v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv218 = *([v243 @ X0_v24]);\n\tv325 = 0x6D2490(v243, v284, v282, v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00ED:\n\t// 237 IsInst v401 @ X0_v5 (System.IDisposable), typeof(System.IDisposable), v387 @ X21_v1 (System.Collections.IEnumerator)\n\tv408 = v401 == 0;\n\tif (v408) goto L_011D;\n\tgoto L_011C;\n\tv438 = *([v409 @ X8_v6+B0]);\n\tv439 = 0;\n\tv440 = v438 + 8;\n\tv442 = *([v484 @ X11_v7-8]);\n\tv489 = v442 == v410;\n\tif (v489) goto L_0115;\n\tv462 = v483 + 1;\n\tv534 = v462 < v411;\n\tv460 = ~v534;\n\tv464 = v484 + 0x10;\n\tv444 = ~v460;\n\tif (v444) goto L_FFFFFFFF;\n\tv465 = v222;\n\tv466 = 0;\n\tv467 = 0x8909C4(v465, v410, v466, v188, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_011C;\nL_0115:\n\tv535 = *([v484 @ X11_v7]);\n\tv536 = v535 << 4;\n\tv537 = v409 + v536;\n\tv538 = v537 + 0x130;\nL_011C:\n\tSystem.IDisposable::Dispose(v401);\nL_011D:\n\tv437 = v216 + 1;\n\tv202 = v437 == 0;\n\tv192 = ~v202;\n\tif (v192) goto L_0127;\n\tv468 = v218 == 0;\n\tv405 = ~v468;\n\tif (v405) goto L_013A;\nL_0127:\n\tv232 = this.storeAnimationClip;\n\tv232.value = v234;\nL_0134:\n\treturn;\n\tthrow System.NullReferenceException;\nL_013A:\n\tv287 = new System.TypeLoadException();\nL_013B:\n\tv294 = 0x6D2380(v158, v284, v282, v55, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCaptureAnimationClip()
		{
			//IL_02c4: Expected I4, but got O
			//IL_00ca: Expected I, but got O
			//IL_0105: Expected O, but got I
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Expected O, but got Unknown
			//IL_01b2: Expected O, but got I
			//IL_01c1: Expected O, but got I
			//IL_0151: Expected O, but got I
			//IL_0264: Expected I4, but got O
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			AnimationClip animationClip = new AnimationClip();
			Transform transform = ownerDefaultTarget.transform;
			IEnumerator enumerator = transform.GetEnumerator();
			bool flag = enumerator == null;
			IEnumerator enumerator2 = enumerator;
			int num = 0;
			int num2 = 0;
			AnimationClip value = animationClip;
			if (flag)
			{
				goto IL_027f;
			}
			Transform transform2 = default(Transform);
			AnimationClip animationClip2;
			for (; enumerator.MoveNext(); CaptureTransform(transform2, "", animationClip), animationClip2 = animationClip)
			{
				IntPtr intPtr = (IntPtr)enumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_016a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
				object obj = 0L + 8L;
				int num3 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ X11_v23-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
					{
						break;
					}
					num3++;
					int num4 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v602 @ X8_v25 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					bool flag2 = (long)num4 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_016a;
				}
				object obj2 = obj + 1;
				int num5 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num5;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				num = 0;
				goto IL_03c9;
				IL_016a:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num = 1;
				goto IL_03c9;
				IL_03c9:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v676 @ X0_v41] (should have been resolved before IL gen)");
				if ((object)transform2 == null)
				{
					continue;
				}
				Transform transform3 = transform2 as Transform;
				if ((object)transform3 != null)
				{
					continue;
				}
				goto IL_0245;
			}
			int num6 = 0;
			int num7 = 0;
			enumerator2 = enumerator;
			value = animationClip;
			goto IL_03f5;
			IL_0364:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_027f:
			NullReferenceException ex = new NullReferenceException();
			if (num2 != 1)
			{
				goto IL_0364;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj5 = default(object);
			num7 = (int)obj5;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			num6 = -1;
			goto IL_03f5;
			IL_0245:
			InvalidCastException ex2 = new InvalidCastException();
			enumerator2 = enumerator;
			num2 = (int)typeof(Transform);
			value = animationClip;
			NullReferenceException ex3 = new NullReferenceException();
			goto IL_027f;
			IL_03f5:
			(enumerator2 as IDisposable)?.Dispose();
			if (num6 + 1 != 0 || num7 == 0)
			{
				FsmObject fsmObject = storeAnimationClip;
				fsmObject.Value = value;
				return;
			}
			TypeLoadException ex4 = new TypeLoadException();
			AnimationClip animationClip3 = default(AnimationClip);
			animationClip2 = animationClip3;
			num = 0;
			num2 = 0;
			ex = (NullReferenceException)(object)ex4;
			goto IL_0364;
		}

		[Token(Token = "0x600069D")]
		[Address(RVA = "0xA8EB04", Offset = "0xA8EB04", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EB9448]);\n\tv37 = *([v36 @ X8_v31]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, transform, path, clip, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20221DD]) = v53;\nL_0020:\n\tv57 = UnityEngine.Object::get_name(transform);\n\tv116 = System.String::Concat(path, v57);\n\tv202 = HutongGames.PlayMaker.FsmBool::get_Value(this.position);\n\tv204 = v202 == 0;\n\tif (v204) goto L_0038;\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::CapturePosition(this, transform, v116, v149);\nL_0038:\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.rotation);\n\tv283 = v279 == 0;\n\tif (v283) goto L_0045;\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::CaptureRotation(this, transform, v116, v149);\nL_0045:\n\tv382 = HutongGames.PlayMaker.FsmBool::get_Value(this.scale);\n\tv385 = v382 == 0;\n\tif (v385) goto L_0050;\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::CaptureScale(this, transform, v116, v149);\nL_0050:\n\tv192 = UnityEngine.Transform::GetEnumerator(transform);\n\tv194 = v192 == 0;\n\tif (v194) goto L_00E8;\nL_005E:\n\tgoto L_0085;\n\tv526 = *([v522 @ X8_v15+B0]);\n\tv527 = 0;\n\tv528 = v526 + 8;\n\tv530 = *([v567 @ X11_v24-8]);\n\tv572 = v530 == v523;\n\tif (v572) goto L_007E;\n\tv550 = v566 + 1;\n\tv577 = v550 < v524;\n\tv548 = ~v577;\n\tv552 = v567 + 0x10;\n\tv532 = ~v548;\n\tif (v532) goto L_FFFFFFFF;\n\tv553 = v121;\n\tv554 = 0;\n\tv555 = 0x8909C4(v553, v523, v554, v107, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0085;\nL_007E:\n\tv578 = *([v567 @ X11_v24]);\n\tv579 = v578 << 4;\n\tv580 = v522 + v579;\n\tv581 = v580 + 0x130;\nL_0085:\n\tv367 = System.Collections.IEnumerator::MoveNext(v192);\n\tv369 = v367 == 0;\n\tif (v369) goto L_FFFFFFFF;\n\tv586 = *([v192 @ X0_v38 (System.Collections.IEnumerator)]);\n\tv589 = *([v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v589) goto L_00AB;\n\tv631 = *([v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0096:\n\tv636 = *([v631 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v636) goto L_00AE;\n\tv630 = v630 + 1;\n\tv641 = v630 < *([v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv612 = ~v641;\n\tv631 = v631 + 0x10;\n\tv596 = ~v612;\n\tif (v596) goto L_0096;\nL_00AB:\n\tv659 = 0x8909C4(v192, System.Collections.IEnumerator, 1, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00B5;\nL_00AE:\n\tv643 = *([v631 @ X11_v19]) + 1;\n\tv644 = v643 << 4;\n\tv645 = v586 + v644;\n\tv659 = v645 + 0x130;\nL_00B5:\n\t*([v659 @ X0_v43])(v664, v192, *([v659 @ X0_v43+8]), v109, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv118 = v664 == 0;\n\tif (v118) goto L_00DA;\n\tgoto L_FFFFFFFF;\n\tv677 = v677_asT == 0;\n\tif (v677) goto L_00E5;\nL_00DA:\n\tv691 = System.String::Concat(v116, \"/\");\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::CaptureTransform(this, v664, v691, v149);\n\tgoto L_005E;\n\tgoto L_0101;\nL_00E5:\n\tthrow System.InvalidCastException;\n\tv167 = new System.NullReferenceException();\nL_00E8:\n\tv199 = new System.NullReferenceException();\n\tgoto L_00F7;\n\tgoto L_00F7;\n\tgoto L_00F7;\n\tgoto L_00F7;\n\tgoto L_00F7;\nL_00F7:\n\tv214 = 0 != 1;\n\tif (v214) goto L_014B;\n\tv220 = 0x6D2BC0(v199, 0, v257, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv272 = *([v220 @ X0_v20]);\n\tv281 = 0x6D2490(v220, 0, v257, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0101:\n\t// 257 IsInst v380 @ X0_v4 (System.IDisposable), typeof(System.IDisposable), v371 @ X20_v2 (System.Collections.IEnumerator)\n\tv383 = v380 == 0;\n\tif (v383) goto L_0131;\n\tgoto L_0130;\n\tv422 = *([v386 @ X8_v5+B0]);\n\tv423 = 0;\n\tv424 = v422 + 8;\n\tv426 = *([v464 @ X11_v7-8]);\n\tv469 = v426 == v387;\n\tif (v469) goto L_0129;\n\tv446 = v463 + 1;\n\tv478 = v446 < v388;\n\tv444 = ~v478;\n\tv448 = v464 + 0x10;\n\tv428 = ~v444;\n\tif (v428) goto L_FFFFFFFF;\n\tv449 = v268;\n\tv450 = 0;\n\tv451 = 0x8909C4(v449, v387, v450, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0130;\nL_0129:\n\tv479 = *([v464 @ X11_v7]);\n\tv480 = v479 << 4;\n\tv481 = v386 + v480;\n\tv482 = v481 + 0x130;\nL_0130:\n\tSystem.IDisposable::Dispose(v380);\nL_0131:\n\tv414 = v266 + 1;\n\tv238 = v414 == 0;\n\tv228 = ~v238;\n\tif (v228) goto L_0146;\n\tv452 = v272 == 0;\n\tv264 = ~v452;\n\tif (v264) goto L_014A;\nL_0146:\n\treturn;\nL_014A:\n\tv262 = new System.TypeLoadException();\nL_014B:\n\tv277 = 0x6D2380(v199, v259, v257, v256, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\n// 209 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CaptureTransform(Transform transform, string path, AnimationClip clip)
		{
			//IL_033a: Expected I4, but got O
			//IL_0165: Expected I, but got O
			//IL_01a0: Expected O, but got I
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_024d: Expected O, but got I
			//IL_025c: Expected O, but got I
			//IL_01ec: Expected O, but got I
			string text = transform.name;
			string text2 = path + text;
			bool value = position.Value;
			bool flag = !value;
			string text3 = null;
			AnimationClip animationClip = default(AnimationClip);
			if (!flag)
			{
				CapturePosition(transform, text2, animationClip);
				text3 = text2;
			}
			bool value2 = rotation.Value;
			bool flag2 = !value2;
			AnimationClip animationClip2 = animationClip;
			if (!flag2)
			{
				CaptureRotation(transform, text2, animationClip);
				animationClip2 = animationClip;
				text3 = text2;
			}
			if (scale.Value)
			{
				CaptureScale(transform, text2, animationClip);
				animationClip2 = animationClip;
				text3 = text2;
			}
			IEnumerator enumerator = transform.GetEnumerator();
			bool flag3 = enumerator == null;
			Transform transform2 = null;
			IEnumerator enumerator2 = enumerator;
			int num;
			int num2;
			NullReferenceException ex;
			if (flag3)
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_03aa;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num2 = -1;
			}
			else
			{
				Transform transform3 = default(Transform);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0205;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v631 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ X8_v18 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag4 = (long)num4 < 0L;
						bool flag5 = !flag4;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_0205;
					}
					object obj3 = obj2 + 1;
					int num5 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num5;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num6 = 0;
					goto IL_040e;
					IL_0205:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					num6 = 1;
					goto IL_040e;
					IL_040e:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v659 @ X0_v43] (should have been resolved before IL gen)");
					if ((object)transform3 != null)
					{
						Transform transform4 = transform3 as Transform;
						if ((object)transform4 == null)
						{
							throw new InvalidCastException();
						}
					}
					string path2 = text2 + "/";
					CaptureTransform(transform3, path2, animationClip);
					animationClip2 = animationClip;
				}
				num2 = 0;
				enumerator2 = enumerator;
				num = 0;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num2 + 1 != 0 || num == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			text3 = null;
			transform2 = null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_03aa;
			IL_03aa:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x600069E")]
		[Address(RVA = "0xA8EE40", Offset = "0xA8EE40", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED6E40]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, transform, path, clip, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20221DE]) = v44;\nL_001B:\n\tv48 = UnityEngine.Transform::get_localPosition(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localPosition.x\", v48);\n\tv60 = UnityEngine.Transform::get_localPosition(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localPosition.y\", v60.y);\n\tv98 = UnityEngine.Transform::get_localPosition(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localPosition.z\", v98.z);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CapturePosition(Transform transform, string path, AnimationClip clip)
		{
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localPosition.x", transform.localPosition.x);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localPosition.y", transform.localPosition.y);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localPosition.z", transform.localPosition.z);
		}

		[Token(Token = "0x600069F")]
		[Address(RVA = "0xA8EF0C", Offset = "0xA8EF0C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F07ED8]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, transform, path, clip, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20221DF]) = v44;\nL_001B:\n\tv48 = UnityEngine.Transform::get_localRotation(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localRotation.x\", v48);\n\tv61 = UnityEngine.Transform::get_localRotation(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localRotation.y\", v61.y);\n\tv103 = UnityEngine.Transform::get_localRotation(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localRotation.z\", v103.z);\n\tv114 = UnityEngine.Transform::get_localRotation(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localRotation.w\", v114.w);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CaptureRotation(Transform transform, string path, AnimationClip clip)
		{
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localRotation.x", transform.localRotation.x);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localRotation.y", transform.localRotation.y);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localRotation.z", transform.localRotation.z);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localRotation.w", transform.localRotation.w);
		}

		[Token(Token = "0x60006A0")]
		[Address(RVA = "0xA8F000", Offset = "0xA8F000", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EBBB88]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, transform, path, clip, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([20221E0]) = v44;\nL_001B:\n\tv48 = UnityEngine.Transform::get_localScale(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localScale.x\", v48);\n\tv60 = UnityEngine.Transform::get_localScale(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localScale.y\", v60.y);\n\tv98 = UnityEngine.Transform::get_localScale(transform);\n\tHutongGames.PlayMaker.Actions.CapturePoseAsAnimationClip::SetConstantCurve(transform, clip, path, \"localScale.z\", v98.z);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CaptureScale(Transform transform, string path, AnimationClip clip)
		{
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localScale.x", transform.localScale.x);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localScale.y", transform.localScale.y);
			((CapturePoseAsAnimationClip)(object)transform).SetConstantCurve(clip, path, "localScale.z", transform.localScale.z);
		}

		[Token(Token = "0x60006A1")]
		[Address(RVA = "0xA8F0CC", Offset = "0xA8F0CC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EF3A28]);\n\tv33 = *([v32 @ X8_v13]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, clip, childPath, propertyPath, methodInfo, v36, v37, v38, value, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([20221E1]) = v49;\nL_0020:\n\tv56 = UnityEngine.AnimationCurve::Linear(0f, value, 100f, value);\n\tUnityEngine.AnimationCurve::set_postWrapMode(v56, 2);\n\tgoto L_0039;\n\tv87 = *([v65 @ X0_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0039;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v65, v59, v61, propertyPath, methodInfo, v36, v37, v38, v52, v53, v51, v54, v42, v43, v44, v45);\nL_0039:\n\tv80 = System.Type::GetTypeFromHandle(UnityEngine.Transform);\n\tUnityEngine.AnimationClip::SetCurve(clip, childPath, v80, propertyPath, v56);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetConstantCurve(AnimationClip clip, string childPath, string propertyPath, float value)
		{
			AnimationCurve animationCurve = AnimationCurve.Linear(0f, value, 100f, value);
			animationCurve.postWrapMode = WrapMode.Loop;
			Type typeFromHandle = typeof(Transform);
			clip.SetCurve(childPath, typeFromHandle, propertyPath, animationCurve);
		}

		[Token(Token = "0x60006A2")]
		[Address(RVA = "0xA8F1C4", Offset = "0xA8F1C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CapturePoseAsAnimationClip()
		{
		}
	}
}
