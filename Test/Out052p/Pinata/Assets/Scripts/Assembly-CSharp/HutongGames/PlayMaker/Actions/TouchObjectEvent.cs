using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755B14", Offset = "0x755B14")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x755B14", Offset = "0x755B14")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755B14", Offset = "0x755B14")]
	[Token(Token = "0x20001D4")]
	public class TouchObjectEvent : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AF910", Offset = "0x7AF910")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF910", Offset = "0x7AF910")]
		[Token(Token = "0x40013F9")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF9A8", Offset = "0x7AF9A8")]
		[Token(Token = "0x40013FA")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat pickDistance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF9F4", Offset = "0x7AF9F4")]
		[Token(Token = "0x40013FB")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt fingerId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AFA2C", Offset = "0x7AFA2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFA2C", Offset = "0x7AFA2C")]
		[Token(Token = "0x40013FC")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent touchBegan;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFA8C", Offset = "0x7AFA8C")]
		[Token(Token = "0x40013FD")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent touchMoved;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFAC4", Offset = "0x7AFAC4")]
		[Token(Token = "0x40013FE")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent touchStationary;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFAFC", Offset = "0x7AFAFC")]
		[Token(Token = "0x40013FF")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent touchEnded;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFB34", Offset = "0x7AFB34")]
		[Token(Token = "0x4001400")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent touchCanceled;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AFB6C", Offset = "0x7AFB6C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AFB6C", Offset = "0x7AFB6C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFB6C", Offset = "0x7AFB6C")]
		[Token(Token = "0x4001401")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt storeFingerId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AFBE0", Offset = "0x7AFBE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFBE0", Offset = "0x7AFBE0")]
		[Token(Token = "0x4001402")]
		[FieldOffset(Offset = "0x98")]
		public FsmVector3 storeHitPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AFC30", Offset = "0x7AFC30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AFC30", Offset = "0x7AFC30")]
		[Token(Token = "0x4001403")]
		[FieldOffset(Offset = "0xA0")]
		public FsmVector3 storeHitNormal;

		[Token(Token = "0x60009BB")]
		[Address(RVA = "0x9A0448", Offset = "0x9A0448", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC5E30]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217CB]) = v38;\nL_0016:\n\tthis.gameObject = 0;\n\tv42 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.pickDistance = v42;\n\tv46 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fingerId = v46;\n\tthis.storeHitPoint = 0;\n\tthis.touchCanceled = 0;\n\tthis.touchStationary = 0;\n\tthis.touchBegan = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 100f;
			pickDistance = fsmFloat;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			fingerId = fsmInt;
			storeHitPoint = null;
			touchCanceled = null;
			touchStationary = null;
			touchBegan = null;
		}

		[Token(Token = "0x60009BC")]
		[Address(RVA = "0x9A04E8", Offset = "0x9A04E8", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1F0D3F0]);\n\tv37 = *([v36 @ X8_v30]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20217CC]) = v56;\nL_001F:\n\tv61 = 0x6D26F0(&v58 @ stack_-B8, 0, 0x44, v41, v42, v43, v44, v45, v46, v154, v149, v49, v50, v51, v52, v53);\n\tv68 = UnityEngine.Camera::get_main();\n\tgoto L_0038;\n\tv76 = *([v72 @ X8_v3+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0038;\n\tv87 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v87, v60, v59, v41, v42, v43, v44, v45, v62, v47, v48, v49, v50, v51, v52, v53);\nL_0038:\n\tv86 = UnityEngine.Object::op_Equality(v68, 0);\n\tv89 = v86 == 0;\n\tif (v89) goto L_0047;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_016C;\nL_0047:\n\tv96 = UnityEngine.Input::get_touchCount();\n\tv109 = v96 < 1;\n\tif (v109) goto L_016C;\n\tv247 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0069;\n\tv518 = *([v228 @ X8_v7+E0]);\n\tv519 = v518 == 0;\n\tv520 = ~v519;\n\tif (v520) goto L_0069;\n\tv525 = v228;\n\tv522 = \"il2cpp_codegen_runtime_class_init\"(v525, v245, v246, v41, v42, v43, v44, v45, v62, v47, v48, v49, v50, v51, v52, v53);\nL_0069:\n\tv220 = UnityEngine.Object::op_Equality(v247, 0);\n\tv527 = v220 == 0;\n\tv224 = ~v527;\n\tif (v224) goto L_016C;\n\tv221 = UnityEngine.Input::get_touches();\n\tv516 = v221.Length;\n\tv172 = v221.Length < 1;\n\tif (v172) goto L_016C;\nL_0084:\n\tv541 = v325 < v516;\n\tv362 = ~v541;\n\tif (v362) goto L_0191;\n\tv542 = v325 * 0x44;\n\tv399 = v221 + v542;\n\tv370 = v399 + 0x20;\n\tv544 = 0x6D1DA0(&v58 @ stack_-B8, v370, 0x44, v41, v42, v43, v44, v45, v217, v154, v149, v49, v50, v51, v52, v53);\n\tv546 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fingerId);\n\tv548 = v546 == 0;\n\tv549 = ~v548;\n\tif (v549) goto L_00B4;\n\tv552 = 0x167179C(&v58 @ stack_-B8, 0, 0x44, v41, v42, v43, v44, v45, v217, v154, v149, v49, v50, v51, v52, v53);\n\tv567 = HutongGames.PlayMaker.FsmInt::get_Value(this.fingerId);\n\tv555 = v552 != v567;\n\tif (v555) goto L_0150;\nL_00B4:\n\tv574 = 0x16717A4(&v58 @ stack_-B8, 0, 0x44, v41, v42, v43, v44, v45, v217, v154, v149, v49, v50, v51, v52, v53);\n\tv576 = UnityEngine.Camera::get_main();\n\tgoto L_00C8;\n\tv607 = *([v599 @ X8_v15+E0]);\n\tv608 = v607 == 0;\n\tv609 = ~v608;\n\tif (v609) goto L_00C8;\n\tv635 = v599;\n\tv611 = \"il2cpp_codegen_runtime_class_init\"(v635, v573, v366, v41, v42, v43, v44, v45, v384, v307, v298, v49, v50, v51, v52, v53);\nL_00C8:\n\t// 200 MakeStruct v304 @ AGG9A06EC_0_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v217 @ V0_v7 (UnityEngine.RaycastHit), v154 @ V1_v6 (System.Single)\n\tv385 = UnityEngine.Vector2::op_Implicit(v304);\n\tv637 = UnityEngine.Camera::ScreenPointToRay(v576, v385);\n\tv291 = v637.m_Origin;\n\tv639 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pickDistance);\n\tv591 = UnityEngine.Physics::Raycast(&v291 @ stack_-100_v7 (UnityEngine.Vector3), &v586 @ stack_-E8_v8 (UnityEngine.RaycastHit), v639);\n\tv600 = this.fsm;\n\tv600.<RaycastHitInfo>k__BackingField.m_Distance = v643;\n\tv600.<RaycastHitInfo>k__BackingField.m_Normal.y = 0f;\n\tv600.<RaycastHitInfo>k__BackingField = v586;\n\tv651 = new System.NullReferenceException();\n\tgoto L_010A;\n\tv655 = *([v401 @ X8_v20+E0]);\n\tv656 = v655 == 0;\n\tv657 = ~v656;\n\tif (v657) goto L_010A;\n\tv662 = v401;\n\tv659 = \"il2cpp_codegen_runtime_class_init\"(v662, v647, v580, v41, v42, v43, v44, v45, v386, v309, v300, v49, v50, v51, v52, v53);\nL_010A:\n\tv628 = UnityEngine.Object::op_Inequality(v651, 0);\n\tv630 = v628 == 0;\n\tif (v630) goto L_0150;\n\tv391 = new System.NullReferenceException();\n\tv666 = UnityEngine.Component::get_gameObject(v391);\n\tgoto L_0124;\n\tv670 = *([v601 @ X8_v21+E0]);\n\tv671 = v670 == 0;\n\tv672 = ~v671;\n\tif (v672) goto L_0124;\n\tv677 = v601;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v677, v665, v367, v41, v42, v43, v44, v45, v386, v309, v300, v49, v50, v51, v52, v53);\nL_0124:\n\tv629 = UnityEngine.Object::op_Equality(v666, v247);\n\tv631 = v629 == 0;\n\tif (v631) goto L_0150;\n\tv578 = this.storeFingerId;\n\tv592 = 0x167179C(&v58 @ stack_-B8, 0, 0, v41, v42, v43, v44, v45, v586, 0, v586, v49, v50, v51, v52, v53);\n\tv578.value = v592;\n\tv579 = this.storeHitPoint;\n\tv593 = 0x164C878(&v586 @ stack_-E8_v8 (UnityEngine.RaycastHit), 0, 0, v41, v42, v43, v44, v45, v586, 0, v586, v49, v50, v51, v52, v53);\n\tv579.value = v586;\n\tv579.value.y = 0f;\n\tv579.value.z = v586;\n\tv441 = this.storeHitNormal;\n\tv594 = 0x164C884(&v586 @ stack_-E8_v8 (UnityEngine.RaycastHit), 0, 0, v41, v42, v43, v44, v45, v586, 0, v586, v49, v50, v51, v52, v53);\n\tv441.value = v586;\n\tv441.value.y = 0f;\n\tv441.value.z = v586;\n\tv494 = 0x16717C4(&v58 @ stack_-B8, 0, 0, v41, v42, v43, v44, v45, v586, 0, v586, v49, v50, v51, v52, v53);\n\tv683 = v494 < 4;\n\tv476 = ~v683;\n\tv473 = v494 - 4;\n\tv467 = v473 == 0;\n\tv684 = ~v476;\n\tv452 = v684 | v467;\n\tif (v452) goto L_016F;\nL_0150:\n\tv516 = v221.Length;\n\tv325 = v325 + 1;\n\tv170 = v325 < v221.Length;\n\tif (v170) goto L_0084;\nL_016C:\n\treturn;\nL_016F:\n\tv485 = 0x1817000 + 0xF5C;\n\tv501 = *([v485 @ X9_v20 (System.Int32)+v494 @ X0_v63*4]) + v485;\n\t// 370 IndirectJump v501 @ X8_v24, v494 @ X0_v63, v494 @ X0_v63, 0, 0, v41 @ X3, v42 @ X4, v43 @ X5, v44 @ X6, v45 @ X7, v586 @ stack_-E8_v8 (UnityEngine.RaycastHit), 0, v586 @ stack_-E8_v8 (UnityEngine.RaycastHit), v49 @ V3, v50 @ V4, v51 @ V5, v52 @ V6, v53 @ V7\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+68]);\n\tgoto L_018B;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+70]);\n\tgoto L_018B;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+78]);\n\tgoto L_018B;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+80]);\n\tgoto L_018B;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+88]);\nL_018B:\n\tX2 = 0;\n\tHutongGames.PlayMaker.Fsm::Event(X0, X1, X2);\n\tgoto L_016C;\n\tv388 = new System.NullReferenceException();\n\tv403 = new System.NullReferenceException();\nL_0191:\n\tv517 = new System.IndexOutOfRangeException();\n\tthrow v517;\n\treturn;\n// 253 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate()
		{
			//IL_012c: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_01e8: Expected F4, but got O
			//IL_024a: Expected O, but got Ref
			//IL_0274: Expected F4, but got O
			//IL_03c3: Expected F4, but got O
			//IL_040e: Expected F4, but got O
			//IL_0441: Expected O, but got I
			//IL_04ea: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
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
			RaycastHit raycastHit = default(RaycastHit);
			int num4 = default(int);
			Vector2 vector = default(Vector2);
			float y = default(float);
			object obj3 = default(object);
			int value3 = default(int);
			object obj4 = default(object);
			while (num2 < num)
			{
				int num3 = num2 * 68;
				object obj = (long)(IntPtr)touches + (long)num3;
				object obj2 = (long)(IntPtr)obj + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1DA0 (native memmove)");
				if (!fingerId.IsNone)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
					int value = fingerId.Value;
					if (num4 != value)
					{
						goto IL_048f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
				Camera main2 = Camera.main;
				vector.x = (float)raycastHit;
				vector.y = y;
				Vector3 pos = vector;
				Vector3 origin = main2.ScreenPointToRay(pos).m_Origin;
				float value2 = pickDistance.Value;
				bool flag = Physics.Raycast((Ray)(&origin), out var hitInfo, value2);
				Fsm fsm = Fsm;
				fsm.RaycastHitInfo.m_Distance = (float)obj3;
				fsm.RaycastHitInfo.m_Normal.y = 0f;
				fsm.RaycastHitInfo = hitInfo;
				NullReferenceException ex = new NullReferenceException();
				bool flag2 = (UnityEngine.Object)(object)ex != null;
				bool flag3 = !flag2;
				RaycastHit raycastHit2 = hitInfo;
				y = 0f;
				raycastHit = hitInfo;
				if (!flag3)
				{
					NullReferenceException ex2 = new NullReferenceException();
					GameObject gameObject = ((Component)(object)ex2).gameObject;
					bool flag4 = gameObject == ownerDefaultTarget;
					bool flag5 = !flag4;
					raycastHit2 = hitInfo;
					y = 0f;
					raycastHit = hitInfo;
					if (!flag5)
					{
						FsmInt fsmInt = storeFingerId;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
						fsmInt.Value = value3;
						FsmVector3 fsmVector = storeHitPoint;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
						fsmVector.value = (Vector3)hitInfo;
						fsmVector.value.y = 0f;
						fsmVector.value.z = (float)hitInfo;
						FsmVector3 fsmVector2 = storeHitNormal;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
						fsmVector2.value = (Vector3)hitInfo;
						fsmVector2.value.y = 0f;
						fsmVector2.value.z = (float)hitInfo;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
						bool flag6 = (long)(IntPtr)obj4 < 4L;
						bool flag7 = !flag6;
						object obj5 = (long)(IntPtr)obj4 - 4L;
						bool flag8 = obj5 == null;
						bool flag9 = !flag7;
						bool flag10 = flag9 || flag8;
						raycastHit2 = hitInfo;
						y = 0f;
						raycastHit = hitInfo;
						if (flag10)
						{
							int num5 = 25260032 + 3932;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X9_v20 (System.Int32)+v494 @ X0_v63*4]");
							object obj6 = 0L + (long)num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v501 @ X8_v24 (should have been resolved before IL gen)");
							break;
						}
					}
				}
				goto IL_048f;
				IL_048f:
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

		[Token(Token = "0x60009BD")]
		[Address(RVA = "0x9A0924", Offset = "0x9A0924", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TouchObjectEvent()
		{
		}
	}
}
