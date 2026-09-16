using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755CC0", Offset = "0x755CC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755CC0", Offset = "0x755CC0")]
	[Token(Token = "0x20001D8")]
	public class ActivateGameObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0068", Offset = "0x7B0068")]
		[Token(Token = "0x4001417")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B00B4", Offset = "0x7B00B4")]
		[Token(Token = "0x4001418")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool activate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0100", Offset = "0x7B0100")]
		[Token(Token = "0x4001419")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool recursive;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0138", Offset = "0x7B0138")]
		[Token(Token = "0x400141A")]
		[FieldOffset(Offset = "0x68")]
		public bool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0170", Offset = "0x7B0170")]
		[Token(Token = "0x400141B")]
		[FieldOffset(Offset = "0x69")]
		public bool everyFrame;

		[Token(Token = "0x400141C")]
		[FieldOffset(Offset = "0x70")]
		private GameObject activatedGameObject;

		[Token(Token = "0x60009CC")]
		[Address(RVA = "0xA11B18", Offset = "0xA11B18", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.activate = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.recursive = v15;\n\tthis.resetOnExit = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			activate = fsmBool;
			FsmBool fsmBool2 = true;
			recursive = fsmBool2;
			resetOnExit = false;
			everyFrame = false;
		}

		[Token(Token = "0x60009CD")]
		[Address(RVA = "0xA11B5C", Offset = "0xA11B5C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ActivateGameObject::DoActivateGameObject(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoActivateGameObject();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60009CE")]
		[Address(RVA = "0xA11C94", Offset = "0xA11C94", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ActivateGameObject::DoActivateGameObject(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoActivateGameObject();
		}

		[Token(Token = "0x60009CF")]
		[Address(RVA = "0xA11C98", Offset = "0xA11C98", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECFF00]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D0D]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.activatedGameObject, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_004F;\n\tv63 = ~this.resetOnExit;\n\tif (v63) goto L_004F;\n\tv110 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tv122 = HutongGames.PlayMaker.FsmBool::get_Value(this.activate);\n\tv127 = v110 == 0;\n\tif (v127) goto L_0052;\n\tv92 = ~v122;\n\tHutongGames.PlayMaker.Actions.ActivateGameObject::SetActiveRecursively(this, this.activatedGameObject, v92);\n\treturn;\nL_004F:\n\treturn;\nL_0052:\n\tv93 = ~v122;\n\tUnityEngine.GameObject::SetActive(this.activatedGameObject, v93);\n\treturn;\n\tv114 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (!(activatedGameObject == null) && resetOnExit)
			{
				bool value = recursive.Value;
				bool value2 = activate.Value;
				if (value)
				{
					bool state = !value2;
					SetActiveRecursively(activatedGameObject, state);
				}
				else
				{
					bool flag = !value2;
					activatedGameObject.SetActive(flag);
				}
			}
		}

		[Token(Token = "0x60009D0")]
		[Address(RVA = "0xA11B98", Offset = "0xA11B98", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECA940]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D0E]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv85 = *([v58 @ X8_v7+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_002B;\n\tv93 = v58;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v93, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv92 = UnityEngine.Object::op_Equality(v45, 0);\n\tv95 = v92 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0051;\n\tv75 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tv76 = HutongGames.PlayMaker.FsmBool::get_Value(this.activate);\n\tv125 = v75 == 0;\n\tif (v125) goto L_0049;\n\tHutongGames.PlayMaker.Actions.ActivateGameObject::SetActiveRecursively(this, v45, v76);\n\tgoto L_004A;\nL_0049:\n\tUnityEngine.GameObject::SetActive(v45, v76);\nL_004A:\n\tthis.activatedGameObject = v45;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoActivateGameObject()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				bool value = recursive.Value;
				bool value2 = activate.Value;
				if (value)
				{
					SetActiveRecursively(ownerDefaultTarget, value2);
				}
				else
				{
					ownerDefaultTarget.SetActive(value2);
				}
				activatedGameObject = ownerDefaultTarget;
			}
		}

		[Token(Token = "0x60009D1")]
		[Address(RVA = "0xA11DA0", Offset = "0xA11DA0", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1ED95D8]);\n\tv29 = *([v28 @ X8_v30]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, go, state, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D0F]) = v46;\nL_001D:\n\tUnityEngine.GameObject::SetActive(go, state);\n\tv112 = UnityEngine.GameObject::get_transform(go);\n\tv156 = UnityEngine.Transform::GetEnumerator(v112);\n\tv158 = v156 == 0;\n\tif (v158) goto L_00B6;\nL_0030:\n\tgoto L_0057;\n\tv266 = *([v260 @ X8_v14+B0]);\n\tv267 = 0;\n\tv268 = v266 + 8;\n\tv270 = *([v345 @ X11_v24-8]);\n\tv350 = v270 == v261;\n\tif (v350) goto L_0050;\n\tv290 = v344 + 1;\n\tv401 = v290 < v262;\n\tv288 = ~v401;\n\tv292 = v345 + 0x10;\n\tv272 = ~v288;\n\tif (v272) goto L_FFFFFFFF;\n\tv293 = v104;\n\tv294 = 0;\n\tv295 = 0x8909C4(v293, v261, v294, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0057;\nL_0050:\n\tv402 = *([v345 @ X11_v24]);\n\tv403 = v402 << 4;\n\tv404 = v260 + v403;\n\tv405 = v404 + 0x130;\nL_0057:\n\tv388 = System.Collections.IEnumerator::MoveNext(v156);\n\tv390 = v388 == 0;\n\tif (v390) goto L_FFFFFFFF;\n\tv411 = *([v156 @ X0_v27 (System.Collections.IEnumerator)]);\n\tv414 = *([v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v414) goto L_007D;\n\tv516 = *([v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_0068:\n\tv521 = *([v516 @ X11_v19-8]) == System.Collections.IEnumerator;\n\tif (v521) goto L_0080;\n\tv515 = v515 + 1;\n\tv548 = v515 < *([v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv466 = ~v548;\n\tv516 = v516 + 0x10;\n\tv450 = ~v466;\n\tif (v450) goto L_0068;\nL_007D:\n\tv566 = 0x8909C4(v156, System.Collections.IEnumerator, 1, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0087;\nL_0080:\n\tv550 = *([v516 @ X11_v19]) + 1;\n\tv551 = v550 << 4;\n\tv552 = v411 + v551;\n\tv566 = v552 + 0x130;\nL_0087:\n\t*([v566 @ X0_v32])(v571, v156, *([v566 @ X0_v32+8]), v96, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_FFFFFFFF;\n\tv231 = v231_asT == 0;\n\tif (v231) goto L_00B2;\n\tv609 = UnityEngine.Component::get_gameObject(v571);\n\tHutongGames.PlayMaker.Actions.ActivateGameObject::SetActiveRecursively(this, v609, state);\n\tgoto L_0030;\n\tgoto L_00D0;\nL_00B2:\n\tv603 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\n\tv136 = new System.NullReferenceException();\nL_00B6:\n\tv162 = new System.NullReferenceException();\n\tgoto L_00C6;\n\tgoto L_00C6;\n\tgoto L_00C6;\n\tgoto L_00C6;\n\tgoto L_00C6;\n\tgoto L_00C6;\nL_00C6:\n\tv172 = 0 != 1;\n\tif (v172) goto L_0117;\n\tv175 = 0x6D2BC0(v162, 0, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv219 = *([v175 @ X0_v20]);\n\tv265 = 0x6D2490(v175, 0, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00D0:\n\t// 208 IsInst v400 @ X0_v4 (System.IDisposable), typeof(System.IDisposable), v392 @ X19_v2 (System.Collections.IEnumerator)\n\tv410 = v400 == 0;\n\tif (v410) goto L_0100;\n\tgoto L_00FF;\n\tv474 = *([v415 @ X8_v5+B0]);\n\tv475 = 0;\n\tv476 = v474 + 8;\n\tv478 = *([v537 @ X11_v7-8]);\n\tv542 = v478 == v416;\n\tif (v542) goto L_00F8;\n\tv498 = v536 + 1;\n\tv572 = v498 < v417;\n\tv496 = ~v572;\n\tv500 = v537 + 0x10;\n\tv480 = ~v496;\n\tif (v480) goto L_FFFFFFFF;\n\tv501 = v217;\n\tv502 = 0;\n\tv503 = 0x8909C4(v501, v416, v502, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00FF;\nL_00F8:\n\tv573 = *([v537 @ X11_v7]);\n\tv574 = v573 << 4;\n\tv575 = v415 + v574;\n\tv576 = v575 + 0x130;\nL_00FF:\n\tSystem.IDisposable::Dispose(v400);\nL_0100:\n\tv443 = v215 + 1;\n\tv193 = v443 == 0;\n\tv183 = ~v193;\n\tif (v183) goto L_0112;\n\tv504 = v219 == 0;\n\tv213 = ~v504;\n\tif (v213) goto L_0116;\nL_0112:\n\treturn;\nL_0116:\n\tv211 = new System.TypeLoadException();\nL_0117:\n\tv224 = 0x6D2380(v162, v208, v206, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetActiveRecursively(GameObject go, bool state)
		{
			//IL_0242: Expected I4, but got O
			//IL_0070: Expected I, but got O
			//IL_00ab: Expected O, but got I
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_0158: Expected O, but got I
			//IL_0167: Expected O, but got I
			//IL_00f7: Expected O, but got I
			go.SetActive(state);
			Transform transform = go.transform;
			IEnumerator enumerator = transform.GetEnumerator();
			bool flag = enumerator == null;
			int num = 0;
			int num2 = 0;
			IEnumerator enumerator2 = enumerator;
			int num3;
			int num4;
			NullReferenceException ex;
			if (flag)
			{
				ex = new NullReferenceException();
				if (0 != 1)
				{
					goto IL_02ba;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num3 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				num4 = -1;
			}
			else
			{
				Component component = default(Component);
				while (enumerator.MoveNext())
				{
					IntPtr intPtr = (IntPtr)enumerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0110;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj2 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v17 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						bool flag2 = (long)num6 < 0L;
						bool flag3 = !flag2;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_0110;
					}
					object obj3 = obj2 + 1;
					int num7 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num7;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					int num8 = 0;
					goto IL_031e;
					IL_0110:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					num8 = 1;
					goto IL_031e;
					IL_031e:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v566 @ X0_v32] (should have been resolved before IL gen)");
					Transform transform2 = component as Transform;
					if ((object)transform2 != null)
					{
						GameObject go2 = component.gameObject;
						SetActiveRecursively(go2, state);
						continue;
					}
					InvalidCastException ex2 = new InvalidCastException();
					throw new NullReferenceException();
				}
				num4 = 0;
				enumerator2 = enumerator;
				num3 = 0;
			}
			(enumerator2 as IDisposable)?.Dispose();
			if (num4 + 1 != 0 || num3 == 0)
			{
				return;
			}
			TypeLoadException ex3 = new TypeLoadException();
			num = 0;
			num2 = 0;
			ex = (NullReferenceException)(object)ex3;
			goto IL_02ba;
			IL_02ba:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60009D2")]
		[Address(RVA = "0xA1203C", Offset = "0xA1203C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ActivateGameObject()
		{
		}
	}
}
