using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755AA0", Offset = "0x755AA0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755AA0", Offset = "0x755AA0")]
	[Obsolete]
	[Token(Token = "0x20001D3")]
	public class TouchGUIEvent : FsmStateAction
	{
		[Token(Token = "0x2000489")]
		public enum OffsetOptions
		{
			[Token(Token = "0x400216E")]
			TopLeft = 0,
			[Token(Token = "0x400216F")]
			Center = 1,
			[Token(Token = "0x4002170")]
			TouchStart = 2
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7AF4AC", Offset = "0x7AF4AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF4AC", Offset = "0x7AF4AC")]
		[Token(Token = "0x40013E8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF544", Offset = "0x7AF544")]
		[Token(Token = "0x40013E9")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt fingerId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF57C", Offset = "0x7AF57C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF57C", Offset = "0x7AF57C")]
		[Token(Token = "0x40013EA")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent touchBegan;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF5DC", Offset = "0x7AF5DC")]
		[Token(Token = "0x40013EB")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent touchMoved;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF614", Offset = "0x7AF614")]
		[Token(Token = "0x40013EC")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent touchStationary;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF64C", Offset = "0x7AF64C")]
		[Token(Token = "0x40013ED")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent touchEnded;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF684", Offset = "0x7AF684")]
		[Token(Token = "0x40013EE")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent touchCanceled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF6BC", Offset = "0x7AF6BC")]
		[Token(Token = "0x40013EF")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent notTouching;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF6F4", Offset = "0x7AF6F4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF6F4", Offset = "0x7AF6F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF6F4", Offset = "0x7AF6F4")]
		[Token(Token = "0x40013F0")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt storeFingerId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF768", Offset = "0x7AF768")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF768", Offset = "0x7AF768")]
		[Token(Token = "0x40013F1")]
		[FieldOffset(Offset = "0x98")]
		public FsmVector3 storeHitPoint;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF7B8", Offset = "0x7AF7B8")]
		[Token(Token = "0x40013F2")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool normalizeHitPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF7F0", Offset = "0x7AF7F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF7F0", Offset = "0x7AF7F0")]
		[Token(Token = "0x40013F3")]
		[FieldOffset(Offset = "0xA8")]
		public FsmVector3 storeOffset;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF840", Offset = "0x7AF840")]
		[Token(Token = "0x40013F4")]
		[FieldOffset(Offset = "0xB0")]
		public OffsetOptions relativeTo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF878", Offset = "0x7AF878")]
		[Token(Token = "0x40013F5")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool normalizeOffset;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7AF8B0", Offset = "0x7AF8B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF8B0", Offset = "0x7AF8B0")]
		[Token(Token = "0x40013F6")]
		[FieldOffset(Offset = "0xC0")]
		public bool everyFrame;

		[Token(Token = "0x40013F7")]
		[FieldOffset(Offset = "0xC4")]
		private Vector3 touchStartPos;

		[Token(Token = "0x40013F8")]
		[FieldOffset(Offset = "0xD0")]
		private GUIElement guiElement;

		[Token(Token = "0x60009B4")]
		[Address(RVA = "0x99F880", Offset = "0x99F880", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF72F8]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217C5]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tv44 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.fingerId = v44;\n\tthis.touchCanceled = 0;\n\tthis.touchBegan = 0;\n\tthis.touchStationary = 0;\n\tthis.storeFingerId = 0;\n\tthis.storeHitPoint = 0;\n\tv52 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.normalizeHitPoint = v52;\n\tthis.storeOffset = 0;\n\tthis.relativeTo = 1;\n\tv57 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalizeOffset = v57;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			fingerId = fsmInt;
			touchCanceled = null;
			touchBegan = null;
			touchStationary = null;
			storeFingerId = null;
			storeHitPoint = null;
			FsmBool fsmBool = false;
			normalizeHitPoint = fsmBool;
			storeOffset = null;
			relativeTo = OffsetOptions.Center;
			FsmBool fsmBool2 = true;
			normalizeOffset = fsmBool2;
			everyFrame = true;
		}

		[Token(Token = "0x60009B5")]
		[Address(RVA = "0x99F938", Offset = "0x99F938", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.TouchGUIEvent::DoTouchGUIEvent(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoTouchGUIEvent();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60009B6")]
		[Address(RVA = "0x99FB04", Offset = "0x99FB04", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.TouchGUIEvent::DoTouchGUIEvent(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoTouchGUIEvent();
		}

		[Token(Token = "0x60009B7")]
		[Address(RVA = "0x99F974", Offset = "0x99F974", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EF7DD8]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217C6]) = v42;\nL_0016:\n\tv44 = UnityEngine.Input::get_touchCount();\n\tv55 = v44 < 1;\n\tif (v55) goto L_009F;\n\tv128 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_003A;\n\tv209 = *([v114 @ X8_v6+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_003A;\n\tv216 = v114;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v216, v126, v127, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003A:\n\tv104 = UnityEngine.Object::op_Equality(v128, 0);\n\tv218 = v104 == 0;\n\tv109 = ~v218;\n\tif (v109) goto L_009F;\n\tv223 = UnityEngine.GameObject::GetComponent(v128);\n\tv225 = v223 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_0050;\n\tv231 = UnityEngine.GameObject::GetComponent(v128);\nL_0050:\n\tthis.guiElement = v60;\n\tgoto L_005E;\n\tv240 = *([v236 @ X0_v18+E0]);\n\tv241 = v240 == 0;\n\tv242 = ~v241;\n\tgoto L_005E;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v236, v233, v69, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005E:\n\tv105 = UnityEngine.Object::op_Equality(v60, 0);\n\tv248 = v105 == 0;\n\tv110 = ~v248;\n\tif (v110) goto L_009F;\n\tv106 = UnityEngine.Input::get_touches();\n\tv160 = v106.Length;\n\tv77 = v106.Length < 1;\n\tif (v77) goto L_009F;\nL_0077:\n\tv264 = v130 < v160;\n\tv154 = ~v264;\n\tif (v154) goto L_00A0;\n\tv108 = v130 * 0x44;\n\tv265 = v106 + v108;\n\tv266 = v265 + 0x20;\n\tv269 = 0x6D1DA0(&v268 @ stack_-78, v266, 0x44, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tHutongGames.PlayMaker.Actions.TouchGUIEvent::DoTouch(this, &v268 @ stack_-78);\n\tv160 = v106.Length;\n\tv130 = v130 + 1;\n\tv76 = v130 < v106.Length;\n\tif (v76) goto L_0077;\nL_009F:\n\treturn;\nL_00A0:\n\tv270 = new System.IndexOutOfRangeException();\n\tthrow v270;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoTouchGUIEvent()
		{
			//IL_0143: Expected O, but got I
			//IL_0152: Expected O, but got I
			//IL_0166: Expected O, but got Ref
			int touchCount = Input.touchCount;
			if (touchCount < 1)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			GUITexture component = ownerDefaultTarget.GetComponent<GUITexture>();
			bool flag = (object)component == null;
			bool flag2 = !flag;
			UnityEngine.Object obj = component;
			if (!flag2)
			{
				GUIText component2 = ownerDefaultTarget.GetComponent<GUIText>();
				obj = component2;
			}
			guiElement = (GUIElement)obj;
			if (obj == null)
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
			object obj4 = default(object);
			while (num2 < num)
			{
				int num3 = num2 * 68;
				object obj2 = (long)(IntPtr)touches + (long)num3;
				object obj3 = (long)(IntPtr)obj2 + 32L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1DA0 (native memmove)");
				DoTouch((Touch)(&obj4));
				num = touches.Length;
				num2++;
				if (num2 >= touches.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60009B8")]
		[Address(RVA = "0x99FB08", Offset = "0x99FB08", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EDB3A0]);\n\tv29 = *([v28 @ X8_v19]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, touch, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20217C7]) = v47;\nL_001C:\n\tv51 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fingerId);\n\tv119 = v51 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0038;\n\tv145 = 0x167179C(touch, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv172 = HutongGames.PlayMaker.FsmInt::get_Value(this.fingerId);\n\tv160 = v145 != v172;\n\tif (v160) goto L_00BC;\nL_0038:\n\tv176 = 0x16717A4(touch, 0, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_004A;\n\tv271 = *([v181 @ X0_v13+E0]);\n\tv272 = v271 == 0;\n\tv273 = ~v272;\n\tif (v273) goto L_004A;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v181, v101, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004A:\n\t// 74 MakeStruct v61 @ AGG99FBCC_0_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v37 @ V0, v38 @ V1\n\tv67 = UnityEngine.Vector2::op_Implicit(v61);\n\tv285 = UnityEngine.GUIElement::HitTest(this.guiElement, v67);\n\tv287 = v285 == 0;\n\tif (v287) goto L_00B1;\n\tv290 = 0x16717C4(touch, 0, methodInfo, v32, v33, v34, v35, v36, v67, v67.y, v67.z, v40, v41, v42, v43, v44);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_0066;\n\tthis.touchStartPos = v67;\n\tthis.touchStartPos.y = v67.y;\n\tthis.touchStartPos.z = v67.z;\nL_0066:\n\tv116 = this.storeFingerId;\n\tv146 = 0x167179C(touch, 0, methodInfo, v32, v33, v34, v35, v36, v67, v67.y, v67.z, v40, v41, v42, v43, v44);\n\tv116.value = v146;\n\tv294 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalizeHitPoint);\n\tv296 = v294 == 0;\n\tif (v296) goto L_007D;\n\tv298 = UnityEngine.Screen::get_width();\n\tv300 = v67 / v298;\n\tv302 = UnityEngine.Screen::get_height();\n\tv131 = v67.y / v302;\nL_007D:\n\tv154 = this.storeHitPoint;\n\tv154.value = v129;\n\tv154.value.y = v131;\n\tv154.value.z = v67.z;\n\t// 135 MakeStruct v194 @ AGG99FC80_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v129 @ V9_v8 (UnityEngine.Vector3), v131 @ V8_v8 (System.Single), v67.z (System.Single)\n\tHutongGames.PlayMaker.Actions.TouchGUIEvent::DoTouchOffset(this, v194);\n\tv251 = 0x16717C4(touch, 0, methodInfo, v32, v33, v34, v35, v36, v129, v131, v67.z, v40, v41, v42, v43, v44);\n\tv307 = v251 < 4;\n\tv244 = ~v307;\n\tv241 = v251 - 4;\n\tv235 = v241 == 0;\n\tv308 = ~v235;\n\tv220 = v244 & v308;\n\tif (v220) goto L_00BC;\n\tv191 = 0x1817000 + 0xF34;\n\tv262 = *([v191 @ X9_v2 (System.Int32)+v251 @ X0_v28*4]) + v191;\n\t// 157 IndirectJump v262 @ X8_v14, v251 @ X0_v28, v251 @ X0_v28, 0, methodInfo @ X2 (Il2CppMethodInfo), v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v129 @ V9_v8 (UnityEngine.Vector3), v131 @ V8_v8 (System.Single), v67.z (System.Single), v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+60]);\n\tgoto L_00B1;\nL_00B1:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.notTouching);\n\treturn;\nL_00BC:\n\treturn;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+68]);\n\tgoto L_00B1;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+70]);\n\tgoto L_00B1;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+78]);\n\tgoto L_00B1;\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = *([X19+80]);\n\tgoto L_00B1;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoTouch(Touch touch)
		{
			//IL_0095: Expected F4, but got O
			//IL_00a2: Expected F4, but got O
			//IL_0297: Expected O, but got I
			//IL_01e9: Expected O, but got F4
			//IL_02f0: Expected O, but got I
			if (!fingerId.IsNone)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
				int value = fingerId.Value;
				int num = default(int);
				if (num != value)
				{
					return;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
			Vector2 vector = default(Vector2);
			object obj = default(object);
			vector.x = (float)obj;
			object obj2 = default(object);
			vector.y = (float)obj2;
			Vector3 vector2 = vector;
			if (guiElement.HitTest(vector2))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj3 = default(object);
				if (obj3 == null)
				{
					touchStartPos = vector2;
					touchStartPos.y = vector2.y;
					touchStartPos.z = vector2.z;
				}
				FsmInt fsmInt = storeFingerId;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
				int value2 = default(int);
				fsmInt.Value = value2;
				bool value3 = normalizeHitPoint.Value;
				bool flag = !value3;
				Vector3 value4 = vector2;
				float y = vector2.y;
				if (!flag)
				{
					int width = Screen.width;
					float num2 = vector2.x / (float)width;
					int height = Screen.height;
					y = vector2.y / (float)height;
					value4 = (Vector3)num2;
				}
				FsmVector3 fsmVector = storeHitPoint;
				fsmVector.value = value4;
				fsmVector.value.y = y;
				fsmVector.value.z = vector2.z;
				Vector3 touchPos = default(Vector3);
				touchPos.x = value4.x;
				touchPos.y = y;
				touchPos.z = vector2.z;
				DoTouchOffset(touchPos);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj4 = default(object);
				bool flag2 = (long)(IntPtr)obj4 < 4L;
				bool flag3 = !flag2;
				object obj5 = (long)(IntPtr)obj4 - 4L;
				bool flag4 = obj5 == null;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					int num3 = 25260032 + 3892;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X9_v2 (System.Int32)+v251 @ X0_v28*4]");
					object obj6 = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v262 @ X8_v14 (should have been resolved before IL gen)");
				}
			}
			else
			{
				Fsm.Event(notTouching);
			}
		}

		[Token(Token = "0x60009B9")]
		[Address(RVA = "0x99FD4C", Offset = "0x99FD4C", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv36 = *([1EBCFF0]);\n\tv37 = *([v36 @ X8_v19]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, touchPos, v0, v2, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20217C8]) = v53;\nL_0026:\n\tv61 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeOffset);\n\tv140 = v61 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_00B9;\n\tv223 = UnityEngine.GUIElement::GetScreenRect(this.guiElement);\n\tv137 = v223.m_YMin;\n\tv135 = v223.m_Width;\n\tv115 = v223.m_Height;\n\tv267 = this.relativeTo == 2;\n\tif (v267) goto L_005B;\n\tv276 = this.relativeTo == 1;\n\tif (v276) goto L_0061;\n\tv287 = this.relativeTo == 0;\n\tv288 = ~v287;\n\tif (v288) goto L_FFFFFFFF;\n\tv326 = 0x10CCFB4(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv352 = touchPos - v223;\n\tv353 = 0x10CCFC4(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv173 = touchPos.y - v223;\n\tgoto L_009C;\nL_005B:\n\tv298 = this.touchStartPos;\n\tv296 = this.touchStartPos.y;\n\tv294 = this.touchStartPos.z;\n\tgoto L_0080;\nL_0061:\n\tv291 = 0x10CCFB4(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv332 = 0x10CD178(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv365 = 0x10CCFC4(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv371 = 0x10CD188(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v223, v223.m_YMin, v223.m_Width, v223.m_Height, v71, v69, v49, v50);\n\tv375 = v223 * 0.5f;\n\tv376 = v223 * 0.5f;\n\tv309 = v223 + v375;\n\tv319 = v223 + v376;\n\tv313 = 0x1586898(&v293 @ stack_-70_v7 (UnityEngine.Vector3), 0, v40, v41, v42, v43, v44, v45, v309, v319, 0, v223.m_Height, v71, v69, v49, v50);\nL_0080:\n\tgoto L_008E;\n\tv333 = *([v320 @ X0_v12+E0]);\n\tv334 = v333 == 0;\n\tv335 = ~v334;\n\tgoto L_008E;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v320, v310, v40, v41, v42, v43, v44, v45, v308, v318, v316, v261, v47, v48, v49, v50);\nL_008E:\n\t// 142 MakeStruct v348 @ AGG99FECC_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v298 @ V13_v5 (UnityEngine.Vector3), v296 @ V11_v5 (System.Single), v294 @ V12_v5 (System.Single)\n\ttouchPos = UnityEngine.Vector3::op_Subtraction(touchPos, v348);\n\tv137 = touchPos.y;\n\tv135 = touchPos.z;\n\tgoto L_009C;\nL_009C:\n\tv367 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalizeOffset);\n\tv373 = v367 == 0;\n\tif (v373) goto L_00A8;\n\tv380 = 0x10CD178(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, touchPos, v137, v135, v115, v296, v294, v49, v50);\n\tv171 = v171 / touchPos;\n\tv382 = 0x10CD188(&v223 @ V0_v4 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, touchPos, v137, v135, v115, v296, v294, v49, v50);\n\tv173 = v173 / touchPos;\nL_00A8:\n\tv176 = this.storeOffset;\n\tv176.value = v171;\n\tv176.value.y = v173;\n\tv176.value.z = v131;\nL_00B9:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoTouchOffset(Vector3 touchPos)
		{
			//IL_0135: Expected O, but got F4
			if (storeOffset.IsNone)
			{
				return;
			}
			Rect screenRect = guiElement.GetScreenRect();
			float y = screenRect.y;
			float width = screenRect.width;
			float height = screenRect.height;
			float num2;
			Vector3 vector = default(Vector3);
			Vector3 vector2;
			float z;
			float z2;
			float y2;
			Vector3 vector3;
			if (relativeTo != OffsetOptions.TouchStart)
			{
				if (relativeTo != OffsetOptions.Center)
				{
					if (relativeTo == OffsetOptions.TopLeft)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
						float num = vector.x - screenRect.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
						num2 = touchPos.y - screenRect.x;
						vector = (Vector3)screenRect;
						vector2 = (Vector3)num;
						z = 0f;
					}
					else
					{
						vector = (Vector3)screenRect;
						vector2 = default(Vector3);
						num2 = 0f;
						z = 0f;
					}
					goto IL_02d0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				float num3 = screenRect.x * 0.5f;
				float num4 = screenRect.x * 0.5f;
				float num5 = screenRect.x + num3;
				float num6 = screenRect.x + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				z2 = 0f;
				float num7 = default(float);
				y2 = num7;
				Vector3 vector4 = default(Vector3);
				vector3 = vector4;
			}
			else
			{
				vector3 = touchStartPos;
				y2 = touchStartPos.y;
				z2 = touchStartPos.z;
			}
			Vector3 vector5 = default(Vector3);
			vector5.x = vector3.x;
			vector5.y = y2;
			vector5.z = z2;
			vector = touchPos - vector5;
			y = touchPos.y;
			width = touchPos.z;
			height = vector3.x;
			vector2 = touchPos;
			num2 = touchPos.y;
			z = touchPos.z;
			goto IL_02d0;
			IL_02d0:
			if (normalizeOffset.Value)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
				vector2 = (Vector3)((object)vector2 / (object)touchPos);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
				num2 /= vector.x;
			}
			FsmVector3 fsmVector = storeOffset;
			fsmVector.value = vector2;
			fsmVector.value.y = num2;
			fsmVector.value.z = z;
		}

		[Token(Token = "0x60009BA")]
		[Address(RVA = "0x99FF54", Offset = "0x99FF54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TouchGUIEvent()
		{
		}
	}
}
