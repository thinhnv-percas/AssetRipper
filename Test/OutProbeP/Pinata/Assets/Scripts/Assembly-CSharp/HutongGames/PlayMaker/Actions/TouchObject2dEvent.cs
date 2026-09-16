using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B040", Offset = "0x75B040")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B040", Offset = "0x75B040")]
	[Token(Token = "0x20002DA")]
	public class TouchObject2dEvent : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C03D8", Offset = "0x7C03D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C03D8", Offset = "0x7C03D8")]
		[Token(Token = "0x40018BD")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0470", Offset = "0x7C0470")]
		[Token(Token = "0x40018BE")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt fingerId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C04A8", Offset = "0x7C04A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C04A8", Offset = "0x7C04A8")]
		[Token(Token = "0x40018BF")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent touchBegan;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0508", Offset = "0x7C0508")]
		[Token(Token = "0x40018C0")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent touchMoved;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0540", Offset = "0x7C0540")]
		[Token(Token = "0x40018C1")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent touchStationary;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0578", Offset = "0x7C0578")]
		[Token(Token = "0x40018C2")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent touchEnded;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C05B0", Offset = "0x7C05B0")]
		[Token(Token = "0x40018C3")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent touchCanceled;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C05E8", Offset = "0x7C05E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C05E8", Offset = "0x7C05E8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C05E8", Offset = "0x7C05E8")]
		[Token(Token = "0x40018C4")]
		[FieldOffset(Offset = "0x88")]
		public FsmInt storeFingerId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C065C", Offset = "0x7C065C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C065C", Offset = "0x7C065C")]
		[Token(Token = "0x40018C5")]
		[FieldOffset(Offset = "0x90")]
		public FsmVector2 storeHitPoint;

		[Token(Token = "0x6000E45")]
		[Address(RVA = "0x99FF5C", Offset = "0x99FF5C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF9CE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217C9]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.fingerId = v42;\n\tthis.storeHitPoint = 0;\n\tthis.touchStationary = 0;\n\tthis.touchCanceled = 0;\n\tthis.touchBegan = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			fingerId = fsmInt;
			storeHitPoint = null;
			touchStationary = null;
			touchCanceled = null;
			touchBegan = null;
		}

		[Token(Token = "0x6000E46")]
		[Address(RVA = "0x99FFE4", Offset = "0x99FFE4", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv40 = *([1EDD1D8]);\n\tv41 = *([v40 @ X8_v37]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([20217CA]) = v60;\nL_001E:\n\tv61 = &v31 @ stack_-10_v2 - 0xB8;\n\tv64 = 0x6D26F0(v61, 0, 0x44, v45, v46, v47, v48, v49, v50, v194, v189, v133, v54, v55, v56, v57);\n\tv70 = UnityEngine.Camera::get_main();\n\tgoto L_0039;\n\tv78 = *([v74 @ X8_v3+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_0039;\n\tv89 = v74;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v89, v63, v62, v45, v46, v47, v48, v49, v65, v51, v52, v53, v54, v55, v56, v57);\nL_0039:\n\tv88 = UnityEngine.Object::op_Equality(v70, 0);\n\tv91 = v88 == 0;\n\tif (v91) goto L_0048;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_0189;\nL_0048:\n\tv98 = UnityEngine.Input::get_touchCount();\n\tv111 = v98 < 1;\n\tif (v111) goto L_0189;\n\tv299 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_006A;\n\tv658 = *([v278 @ X8_v7+E0]);\n\tv659 = v658 == 0;\n\tv660 = ~v659;\n\tif (v660) goto L_006A;\n\tv665 = v278;\n\tv662 = \"il2cpp_codegen_runtime_class_init\"(v665, v297, v298, v45, v46, v47, v48, v49, v65, v51, v52, v53, v54, v55, v56, v57);\nL_006A:\n\tv270 = UnityEngine.Object::op_Equality(v299, 0);\n\tv667 = v270 == 0;\n\tv274 = ~v667;\n\tif (v274) goto L_0189;\n\tv271 = UnityEngine.Input::get_touches();\n\tv656 = v271.Length;\n\tv218 = v271.Length < 1;\n\tif (v218) goto L_0189;\nL_008B:\n\tv684 = v426 < v656;\n\tv466 = ~v684;\n\tif (v466) goto L_01AE;\n\tv685 = v426 * 0x44;\n\tv506 = v271 + v685;\n\tv474 = v506 + 0x20;\n\tv686 = &v31 @ stack_-10_v2 - 0xB8;\n\tv687 = 0x6D1DA0(v686, v474, 0x44, v45, v46, v47, v48, v49, v267, v194, v189, v133, v54, v55, v56, v57);\n\tv689 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fingerId);\n\tv691 = v689 == 0;\n\tv692 = ~v691;\n\tif (v692) goto L_00B9;\n\tv693 = &v31 @ stack_-10_v2 - 0xB8;\n\tv695 = 0x167179C(v693, 0, 0x44, v45, v46, v47, v48, v49, v267, v194, v189, v133, v54, v55, v56, v57);\n\tv710 = HutongGames.PlayMaker.FsmInt::get_Value(this.fingerId);\n\tv698 = v695 != v710;\n\tif (v698) goto L_016B;\nL_00B9:\n\tv715 = &v31 @ stack_-10_v2 - 0xB8;\n\tv717 = 0x16717A4(v715, 0, 0x44, v45, v46, v47, v48, v49, v267, v194, v189, v133, v54, v55, v56, v57);\n\tv719 = UnityEngine.Camera::get_main();\n\tgoto L_00CF;\n\tv743 = *([v736 @ X8_v15+E0]);\n\tv744 = v743 == 0;\n\tv745 = ~v744;\n\tif (v745) goto L_00CF;\n\tv770 = v736;\n\tv747 = \"il2cpp_codegen_runtime_class_init\"(v770, v716, v470, v45, v46, v47, v48, v49, v494, v410, v402, v326, v54, v55, v56, v57);\nL_00CF:\n\t// 207 MakeStruct v407 @ AGG9A01FC_0_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v267 @ V0_v7 (UnityEngine.Vector2), v194 @ V1_v6 (UnityEngine.Vector2)\n\tv729 = UnityEngine.Vector2::op_Implicit(v407);\n\tv771 = &v184 @ stack_-108;\n\tv774 = UnityEngine.Camera::ScreenPointToRay(v719, v729);\n\tv184 = *([v771 @ X8_v16]);\n\tgoto L_00F2;\n\tv779 = *([v775 @ X0_v42+E0]);\n\tv780 = v779 == 0;\n\tv781 = ~v780;\n\tif (v781) goto L_00F2;\n\tv783 = \"il2cpp_codegen_runtime_class_init\"(v775, v773, v470, v45, v46, v47, v48, v49, v729, v722, v721, v326, v54, v55, v56, v57);\nL_00F2:\n\tv792 = UnityEngine.Physics2D::GetRayIntersection(&v184 @ stack_-108, Infinityf);\n\tv363 = v792.m_Centroid;\n\tgoto L_011C;\n\tv802 = *([v797 @ X0_v46+E0]);\n\tv803 = v802 == 0;\n\tv804 = ~v803;\n\tif (v804) goto L_011C;\n\tv806 = \"il2cpp_codegen_runtime_class_init\"(v797, v789, v470, v45, v46, v47, v48, v49, v795, v794, v403, v327, v54, v55, v56, v57);\nL_011C:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v363 @ stack_-130_v7 (UnityEngine.Vector2));\n\tv815 = new System.NullReferenceException();\n\tgoto L_012F;\n\tv819 = *([v507 @ X8_v25+E0]);\n\tv820 = v819 == 0;\n\tv821 = ~v820;\n\tif (v821) goto L_012F;\n\tv826 = v507;\n\tv823 = \"il2cpp_codegen_runtime_class_init\"(v826, v814, v812, v45, v46, v47, v48, v49, v495, v411, v403, v327, v54, v55, v56, v57);\nL_012F:\n\tv763 = UnityEngine.Object::op_Inequality(v815, 0);\n\tv765 = v763 == 0;\n\tif (v765) goto L_016B;\n\tv499 = new System.NullReferenceException();\n\tv830 = UnityEngine.Component::get_gameObject(v499);\n\tgoto L_0149;\n\tv834 = *([v737 @ X8_v26+E0]);\n\tv835 = v834 == 0;\n\tv836 = ~v835;\n\tif (v836) goto L_0149;\n\tv841 = v737;\n\tv838 = \"il2cpp_codegen_runtime_class_init\"(v841, v829, v471, v45, v46, v47, v48, v49, v495, v411, v403, v327, v54, v55, v56, v57);\nL_0149:\n\tv764 = UnityEngine.Object::op_Equality(v830, v299);\n\tv766 = v764 == 0;\n\tif (v766) goto L_016B;\n\tv724 = this.storeFingerId;\n\tv843 = &v31 @ stack_-10_v2 - 0xB8;\n\tv732 = 0x167179C(v843, 0, 0, v45, v46, v47, v48, v49, v792.m_Normal, v363, v792.m_Normal, v363, v54, v55, v56, v57);\n\tv724.value = v732;\n\tv572 = this.storeHitPoint;\n\tv733 = 0x16415A8(&v363 @ stack_-130_v7 (UnityEngine.Vector2), 0, 0, v45, v46, v47, v48, v49, v792.m_Normal, v363, v792.m_Normal, v363, v54, v55, v56, v57);\n\tv845 = &v31 @ stack_-10_v2 - 0xB8;\n\tv572.value = v792.m_Normal;\n\tv572.value.y = v363;\n\tv634 = 0x16717C4(v845, 0, 0, v45, v46, v47, v48, v49, v792.m_Normal, v363, v792.m_Normal, v363, v54, v55, v56, v57);\n\tv846 = v634 < 4;\n\tv613 = ~v846;\n\tv610 = v634 - 4;\n\tv604 = v610 == 0;\n\tv847 = ~v613;\n\tv589 = v847 | v604;\n\tif (v589) goto L_018C;\nL_016B:\n\tv656 = v271.Length;\n\tv426 = v426 + 1;\n\tv216 = v426 < v271.Length;\n\tif (v216) goto L_008B;\nL_0189:\n\treturn;\nL_018C:\n\tv622 = 0x1817000 + 0xF48;\n\tv641 = *([v622 @ X9_v20 (System.Int32)+v634 @ X0_v65*4]) + v622;\n\t// 399 IndirectJump v641 @ X8_v29, v634 @ X0_v65, v634 @ X0_v65, 0, 0, v45 @ X3, v46 @ X4, v47 @ X5, v48 @ X6, v49 @ X7, v792.m_Normal (UnityEngine.Vector2), v363 @ stack_-130_v7 (UnityEngine.Vector2), v792.m_Normal (UnityEngine.Vector2), v363 @ stack_-130_v7 (UnityEngine.Vector2), v54 @ V4, v55 @ V5, v56 @ V6, v57 @ V7\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+60]);\n\tgoto L_01A8;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+68]);\n\tgoto L_01A8;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+70]);\n\tgoto L_01A8;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+78]);\n\tgoto L_01A8;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+80]);\nL_01A8:\n\tX2 = 0;\n\tHutongGames.PlayMaker.Fsm::Event(X0, X1, X2);\n\tgoto L_0189;\n\tv497 = new System.NullReferenceException();\n\tv509 = new System.NullReferenceException();\nL_01AE:\n\tv657 = new System.IndexOutOfRangeException();\n\tthrow v657;\n\treturn;\n// 272 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate()
		{
			//IL_052f: Expected O, but got I
			//IL_012c: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_014a: Expected O, but got I
			//IL_01f5: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_0281: Expected O, but got Ref
			//IL_02a6: Expected O, but got Ref
			//IL_039f: Expected O, but got I
			//IL_03ed: Expected O, but got I
			//IL_044e: Expected O, but got I
			//IL_0508: Expected O, but got I
			object obj2 = default(object);
			object obj = (long)(IntPtr)obj2 - 184L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			Camera main = Camera.main;
			if (main == null)
			{
				LogError("No MainCamera defined!");
				Finish();
				return;
			}
			int touchCount = Input.touchCount;
			if (touchCount < 1)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(this.gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			Touch[] touches = Input.touches;
			int num = touches.Length;
			if (touches.Length < 1)
			{
				return;
			}
			int num2 = 0;
			Vector2 vector = default(Vector2);
			int num4 = default(int);
			Vector2 vector2 = default(Vector2);
			Vector2 vector3 = default(Vector2);
			object obj9 = default(object);
			int value2 = default(int);
			object obj12 = default(object);
			while (num2 < num)
			{
				int num3 = num2 * 68;
				object obj3 = (long)(IntPtr)touches + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 32L;
				object obj5 = (long)(IntPtr)obj2 - 184L;
				Il2CppRuntime.Boundary("SYSTEM_API:memmove", "Method not found @6D1DA0 (native memmove)");
				if (!fingerId.IsNone)
				{
					object obj6 = (long)(IntPtr)obj2 - 184L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
					int value = fingerId.Value;
					if (num4 != value)
					{
						goto IL_04ad;
					}
				}
				object obj7 = (long)(IntPtr)obj2 - 184L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
				Camera main2 = Camera.main;
				vector2.x = vector.x;
				vector2.y = vector3.x;
				Vector3 pos = vector2;
				object obj8 = obj9;
				Ray ray = main2.ScreenPointToRay(pos);
				obj9 = obj8;
				RaycastHit2D rayIntersection = Physics2D.GetRayIntersection((Ray)(&obj9), float.PositiveInfinity);
				Vector2 centroid = rayIntersection.m_Centroid;
				Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&centroid));
				NullReferenceException ex = new NullReferenceException();
				bool flag = (UnityEngine.Object)(object)ex != null;
				bool flag2 = !flag;
				Vector2 vector4 = centroid;
				Vector2 normal = rayIntersection.m_Normal;
				vector3 = centroid;
				vector = rayIntersection.m_Normal;
				if (!flag2)
				{
					NullReferenceException ex2 = new NullReferenceException();
					GameObject gameObject = ((Component)(object)ex2).gameObject;
					bool flag3 = gameObject == ownerDefaultTarget;
					bool flag4 = !flag3;
					vector4 = centroid;
					normal = rayIntersection.m_Normal;
					vector3 = centroid;
					vector = rayIntersection.m_Normal;
					if (!flag4)
					{
						FsmInt fsmInt = storeFingerId;
						object obj10 = (long)(IntPtr)obj2 - 184L;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
						fsmInt.Value = value2;
						FsmVector2 fsmVector = storeHitPoint;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
						object obj11 = (long)(IntPtr)obj2 - 184L;
						fsmVector.value = rayIntersection.m_Normal;
						fsmVector.value.y = centroid.x;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
						bool flag5 = (long)(IntPtr)obj12 < 4L;
						bool flag6 = !flag5;
						object obj13 = (long)(IntPtr)obj12 - 4L;
						bool flag7 = obj13 == null;
						bool flag8 = !flag6;
						bool flag9 = flag8 || flag7;
						vector4 = centroid;
						normal = rayIntersection.m_Normal;
						vector3 = centroid;
						vector = rayIntersection.m_Normal;
						if (flag9)
						{
							int num5 = 25260032 + 3912;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ X9_v20 (System.Int32)+v634 @ X0_v65*4]");
							object obj14 = 0L + (long)num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v641 @ X8_v29 (should have been resolved before IL gen)");
							break;
						}
					}
				}
				goto IL_04ad;
				IL_04ad:
				num = touches.Length;
				num2++;
				if (num2 >= touches.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x6000E47")]
		[Address(RVA = "0x9A0440", Offset = "0x9A0440", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TouchObject2dEvent()
		{
		}
	}
}
