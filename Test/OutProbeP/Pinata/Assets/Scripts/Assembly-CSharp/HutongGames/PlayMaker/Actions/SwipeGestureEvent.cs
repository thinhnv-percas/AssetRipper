using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755A00", Offset = "0x755A00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755A00", Offset = "0x755A00")]
	[Token(Token = "0x20001D1")]
	public class SwipeGestureEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF380", Offset = "0x7AF380")]
		[Token(Token = "0x40013DB")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat minSwipeDistance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF3B8", Offset = "0x7AF3B8")]
		[Token(Token = "0x40013DC")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent swipeLeftEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF3F0", Offset = "0x7AF3F0")]
		[Token(Token = "0x40013DD")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent swipeRightEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF428", Offset = "0x7AF428")]
		[Token(Token = "0x40013DE")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent swipeUpEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AF460", Offset = "0x7AF460")]
		[Token(Token = "0x40013DF")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent swipeDownEvent;

		[Token(Token = "0x40013E0")]
		[FieldOffset(Offset = "0x78")]
		private float screenDiagonalSize;

		[Token(Token = "0x40013E1")]
		[FieldOffset(Offset = "0x7C")]
		private float minSwipeDistancePixels;

		[Token(Token = "0x40013E2")]
		[FieldOffset(Offset = "0x80")]
		private bool touchStarted;

		[Token(Token = "0x40013E3")]
		[FieldOffset(Offset = "0x84")]
		private Vector2 touchStartPos;

		[Token(Token = "0x60009AC")]
		[Address(RVA = "0x99EF40", Offset = "0x99EF40", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.1f);\n\tthis.minSwipeDistance = v13;\n\tthis.swipeUpEvent = 0;\n\tthis.swipeLeftEvent = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0.1f;
			minSwipeDistance = fsmFloat;
			swipeUpEvent = null;
			swipeLeftEvent = null;
		}

		[Token(Token = "0x60009AD")]
		[Address(RVA = "0x99EF7C", Offset = "0x99EF7C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBD178]);\n\tv25 = *([v24 @ X8_v9]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20217C0]) = v44;\nL_0017:\n\tv46 = UnityEngine.Screen::get_width();\n\tv49 = UnityEngine.Screen::get_width();\n\tv52 = UnityEngine.Screen::get_height();\n\tv67 = UnityEngine.Screen::get_height();\n\tgoto L_002F;\n\tv63 = *([v59 @ X8_v5+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002F;\n\tv75 = v59;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002F:\n\tv70 = v49 * v46;\n\tv71 = v67 * v52;\n\tv72 = v70 + v71;\n\tv88 = UnityEngine.Mathf::Sqrt(v72);\n\tv78 = v88 - v88;\n\tv81 = v88 ^ v88;\n\tv82 = v88 ^ v78;\n\tv83 = v81 & v82;\n\tv84 = v83 < 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0042;\n\tv87 = 0x6D2F50(v67, methodInfo, v28, v29, v30, v31, v32, v33, v72, v72, v36, v37, v38, v39, v40, v41);\nL_0042:\n\tthis.screenDiagonalSize = v88;\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.minSwipeDistance);\n\tv96 = v93 * this.screenDiagonalSize;\n\tthis.minSwipeDistancePixels = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0064: Expected O, but got F4
			//IL_0071: Expected O, but got F4
			int width = Screen.width;
			int width2 = Screen.width;
			int height = Screen.height;
			int height2 = Screen.height;
			int num = width2 * width;
			int num2 = height2 * height;
			int num3 = num + num2;
			float num4 = Mathf.Sqrt(num3);
			float num5 = num4 - num4;
			object obj = num4 ^ num4;
			object obj2 = num4 ^ num5;
			int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num6 < 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num4 = num3;
			}
			screenDiagonalSize = num4;
			float value = minSwipeDistance.Value;
			float num7 = value * screenDiagonalSize;
			minSwipeDistancePixels = num7;
		}

		[Token(Token = "0x60009AE")]
		[Address(RVA = "0x99F064", Offset = "0x99F064", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0x6D26F0(&v11 @ stack_-68, 0, 0x44, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv29 = UnityEngine.Input::get_touchCount();\n\tv40 = v29 < 1;\n\tif (v40) goto L_0054;\n\tv42 = UnityEngine.Input::get_touches();\n\tv114 = v42.Length == 0;\n\tif (v114) goto L_0056;\n\tv116 = v42 + 0x20;\n\tv118 = 0x6D1DA0(&v11 @ stack_-68, v116, 0x44, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv87 = 0x16717C4(&v11 @ stack_-68, 0, 0x44, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv126 = v87 == 4;\n\tif (v126) goto L_004F;\n\tv68 = v87 == 3;\n\tif (v68) goto L_0046;\n\tv135 = v87 == 0;\n\tv52 = ~v135;\n\tif (v52) goto L_0054;\n\tthis.touchStarted = 1;\n\tv88 = 0x16717A4(&v11 @ stack_-68, 0, 0x44, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tthis.touchStartPos = v20;\n\tthis.touchStartPos.y = v21;\n\tgoto L_0054;\nL_0046:\n\tv53 = ~this.touchStarted;\n\tif (v53) goto L_0054;\n\tv140 = 0x6D2410(&v138 @ stack_-B0, &v11 @ stack_-68, 0x44, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tHutongGames.PlayMaker.Actions.SwipeGestureEvent::TestForSwipeGesture(this, &v138 @ stack_-B0);\nL_004F:\n\tthis.touchStarted = 0;\nL_0054:\n\treturn;\n\tv115 = new System.NullReferenceException();\nL_0056:\n\tv120 = new System.IndexOutOfRangeException();\n\tthrow v120;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate()
		{
			//IL_0076: Expected O, but got I
			//IL_0167: Expected O, but got Ref
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			int touchCount = Input.touchCount;
			if (touchCount < 1)
			{
				return;
			}
			Touch[] touches = Input.touches;
			if (touches.Length != 0)
			{
				object obj = (long)(IntPtr)touches + 32L;
				Il2CppRuntime.Boundary("SYSTEM_API:memmove", "Method not found @6D1DA0 (native memmove)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				object obj2 = default(object);
				if ((IntPtr)obj2 != (IntPtr)4)
				{
					if ((IntPtr)obj2 != (IntPtr)3)
					{
						if (obj2 == null)
						{
							touchStarted = true;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
							Vector2 vector = default(Vector2);
							touchStartPos = vector;
							float y = default(float);
							touchStartPos.y = y;
						}
						return;
					}
					if (!touchStarted)
					{
						return;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
					object obj3 = default(object);
					TestForSwipeGesture((Touch)(&obj3));
				}
				touchStarted = false;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60009AF")]
		[Address(RVA = "0x99F144", Offset = "0x99F144", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_001B;\n\tv30 = *([1EA9920]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, touch, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20217C1]) = v49;\nL_001B:\n\tv52 = 0x16717A4(touch, 0, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0031;\n\tv63 = *([v59 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0031;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v59, v51, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0031:\n\t// 49 MakeStruct v75 @ AGG99F1D4_0_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v39 @ V0, v40 @ V1\n\t// 50 MakeStruct v76 @ AGG99F1D4_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.touchStartPos (UnityEngine.Vector2), this.touchStartPos.y (System.Single)\n\tv77 = UnityEngine.Vector2::Distance(v75, v76);\n\tv90 = v77 <= this.minSwipeDistancePixels;\n\tif (v90) goto L_00BC;\n\tv96 = v40 - this.touchStartPos.y;\n\tv97 = v39 - this.touchStartPos;\n\tgoto L_0054;\n\tv154 = *([v95 @ X0_v8 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0054;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v95, v51, methodInfo, v34, v35, v36, v37, v38, v93, v94, v72, v73, v43, v44, v45, v46);\nL_0054:\n\tv163 = 0x6D29A0(UnityEngine.Mathf, 0, methodInfo, v34, v35, v36, v37, v38, v97, v96, this.touchStartPos, this.touchStartPos.y, v43, v44, v45, v46);\n\tv209 = v97 * 57.29578f;\n\tv210 = v209 + 360f;\n\tv211 = v210 + -45f;\n\tv212 = 0x6D1F60(v163, 0, methodInfo, v34, v35, v36, v37, v38, v211, 360f, 57.29578f, -45f, v43, v44, v45, v46);\n\tv215 = &v19 @ stack_-10_v2 - 0x14;\n\t*([v18 @ X29_v1-14]) = v211;\n\t// 101 Box v217 @ X0_v13 (System.Object), typeof(System.Single), v215 @ X1_v3\n\tgoto L_0076;\n\tv224 = *([v220 @ X8_v18+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_0076;\n\tv231 = v220;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v231, v215, methodInfo, v34, v35, v36, v37, v38, v211, v131, v129, v127, v43, v44, v45, v46);\nL_0076:\n\tUnityEngine.Debug::Log(v217);\n\tv243 = v211 >= 90f;\n\tif (v243) goto L_0094;\n\tv138 = this.fsm;\n\tv104 = this.swipeRightEvent;\n\tgoto L_00B1;\nL_0094:\n\tv257 = v211 >= 180f;\n\tif (v257) goto L_009D;\n\tv138 = this.fsm;\n\tv104 = this.swipeDownEvent;\n\tgoto L_00B1;\nL_009D:\n\tv138 = this.fsm;\n\tv259 = v211 >= 270f;\n\tif (v259) goto L_00AF;\n\tv104 = this.swipeLeftEvent;\n\tgoto L_00B1;\nL_00AF:\n\tv104 = this.swipeUpEvent;\nL_00B1:\n\tHutongGames.PlayMaker.Fsm::Event(v138, v104);\nL_00BC:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TestForSwipeGesture(Touch touch)
		{
			//IL_001a: Expected F4, but got O
			//IL_0027: Expected F4, but got O
			//IL_0101: Expected O, but got F4
			//IL_0115: Expected O, but got I
			//IL_0123: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
			Vector2 a = default(Vector2);
			object obj3 = default(object);
			a.x = (float)obj3;
			object obj4 = default(object);
			a.y = (float)obj4;
			Vector2 b = default(Vector2);
			b.x = touchStartPos.x;
			b.y = touchStartPos.y;
			float num = Vector2.Distance(a, b);
			if (num > minSwipeDistancePixels)
			{
				float num2 = (float)obj4 - touchStartPos.y;
				float num3 = (float)obj3 - touchStartPos.x;
				Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
				float num4 = num3 * 57.29578f;
				float num5 = num4 + 360f;
				float num6 = num5 + -45f;
				object obj5 = num6 % 360f;
				object obj6 = (long)(IntPtr)obj2 - 20L;
				object message = (float)obj6;
				Debug.Log(message);
				Fsm fsm;
				FsmEvent fsmEvent;
				if (num6 < 90f)
				{
					fsm = Fsm;
					fsmEvent = swipeRightEvent;
				}
				else if (num6 < 180f)
				{
					fsm = Fsm;
					fsmEvent = swipeDownEvent;
				}
				else
				{
					fsm = Fsm;
					fsmEvent = ((!(num6 < 270f)) ? swipeUpEvent : swipeLeftEvent);
				}
				fsm.Event(fsmEvent);
			}
		}

		[Token(Token = "0x60009B0")]
		[Address(RVA = "0x99F320", Offset = "0x99F320", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SwipeGestureEvent()
		{
		}
	}
}
