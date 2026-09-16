using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7558C0", Offset = "0x7558C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7558C0", Offset = "0x7558C0")]
	[Token(Token = "0x20001CD")]
	public class GetTouchInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AEF68", Offset = "0x7AEF68")]
		[Token(Token = "0x40013B8")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt fingerId;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AEFA0", Offset = "0x7AEFA0")]
		[Token(Token = "0x40013B9")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool normalize;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEFD8", Offset = "0x7AEFD8")]
		[Token(Token = "0x40013BA")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storePosition;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEFEC", Offset = "0x7AEFEC")]
		[Token(Token = "0x40013BB")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeX;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF000", Offset = "0x7AF000")]
		[Token(Token = "0x40013BC")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat storeY;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF014", Offset = "0x7AF014")]
		[Token(Token = "0x40013BD")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 storeDeltaPosition;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF028", Offset = "0x7AF028")]
		[Token(Token = "0x40013BE")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat storeDeltaX;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF03C", Offset = "0x7AF03C")]
		[Token(Token = "0x40013BF")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat storeDeltaY;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF050", Offset = "0x7AF050")]
		[Token(Token = "0x40013C0")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat storeDeltaTime;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF064", Offset = "0x7AF064")]
		[Token(Token = "0x40013C1")]
		[FieldOffset(Offset = "0x98")]
		public FsmInt storeTapCount;

		[Token(Token = "0x40013C2")]
		[FieldOffset(Offset = "0xA0")]
		public bool everyFrame;

		[Token(Token = "0x40013C3")]
		[FieldOffset(Offset = "0xA4")]
		private float screenWidth;

		[Token(Token = "0x40013C4")]
		[FieldOffset(Offset = "0xA8")]
		private float screenHeight;

		[Token(Token = "0x6000998")]
		[Address(RVA = "0xA369E0", Offset = "0xA369E0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA8928]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E1A]) = v40;\nL_0017:\n\tv44 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.fingerId = v44;\n\tv51 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.normalize = v51;\n\tthis.storePosition = 0;\n\tthis.storeDeltaPosition = 0;\n\tthis.storeDeltaTime = 0;\n\tthis.storeTapCount = 0;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			fingerId = fsmInt;
			FsmBool fsmBool = true;
			normalize = fsmBool;
			storePosition = null;
			storeDeltaPosition = null;
			storeDeltaTime = null;
			storeTapCount = null;
			everyFrame = true;
		}

		[Token(Token = "0x6000999")]
		[Address(RVA = "0xA36A78", Offset = "0xA36A78", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Screen::get_width();\n\tthis.screenWidth = v11;\n\tv14 = UnityEngine.Screen::get_height();\n\tthis.screenHeight = v14;\n\tHutongGames.PlayMaker.Actions.GetTouchInfo::DoGetTouchInfo(this);\n\tv19 = ~this.everyFrame;\n\tif (v19) goto L_001E;\n\treturn;\nL_001E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			int width = Screen.width;
			screenWidth = width;
			int height = Screen.height;
			screenHeight = height;
			DoGetTouchInfo();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600099A")]
		[Address(RVA = "0xA36D98", Offset = "0xA36D98", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetTouchInfo::DoGetTouchInfo(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetTouchInfo();
		}

		[Token(Token = "0x600099B")]
		[Address(RVA = "0xA36AD8", Offset = "0xA36AD8", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = 0x6D26F0(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv41 = UnityEngine.Input::get_touchCount();\n\tv52 = v41 < 1;\n\tif (v52) goto L_0102;\n\tv54 = UnityEngine.Input::get_touches();\n\tv309 = v54.Length;\n\tv92 = v54.Length < 1;\n\tif (v92) goto L_0102;\nL_0032:\n\tv326 = v237 < v309;\n\tv286 = ~v326;\n\tif (v286) goto L_0106;\n\tv327 = v237 * 0x44;\n\tv240 = v54 + v327;\n\tv290 = v240 + 0x20;\n\tv329 = 0x6D1DA0(&v23 @ stack_-98, v290, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv331 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fingerId);\n\tv333 = v331 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_0064;\n\tv337 = 0x167179C(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv353 = HutongGames.PlayMaker.FsmInt::get_Value(this.fingerId);\n\tv342 = v337 != v353;\n\tif (v342) goto L_00EA;\nL_0064:\n\tv355 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv403 = 0x16717A4(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv407 = v355 == 0;\n\tif (v407) goto L_0073;\n\tv224 = v372 / this.screenWidth;\nL_0073:\n\tv423 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv425 = 0x16717A4(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv428 = v423 == 0;\n\tif (v428) goto L_0082;\n\tv372 = this.screenHeight;\n\tv211 = v366 / this.screenHeight;\nL_0082:\n\tv432 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storePosition);\n\tv434 = v432 == 0;\n\tv435 = ~v434;\n\tif (v435) goto L_0096;\n\tv373 = this.storePosition;\n\tv358 = 0;\n\tv395 = 0x1586898(&v358 @ stack_-A8_v10 (UnityEngine.Vector3), 0, 0x44, v27, v28, v29, v30, v31, v224, v211, 0, v35, v36, v37, v38, v39);\n\tv373.value = 0;\n\tv373.value.z = 0f;\nL_0096:\n\tv379 = this.storeX;\n\tv379.value = v224;\n\tv242 = this.storeY;\n\tv242.value = v211;\n\tv442 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv444 = 0x16717AC(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv447 = v442 == 0;\n\tif (v447) goto L_00B1;\n\tv225 = v372 / this.screenWidth;\nL_00B1:\n\tv451 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalize);\n\tv453 = 0x16717AC(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv456 = v451 == 0;\n\tif (v456) goto L_00C0;\n\tv372 = this.screenHeight;\n\tv212 = v366 / this.screenHeight;\nL_00C0:\n\tv460 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeDeltaPosition);\n\tv462 = v460 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_00D4;\n\tv374 = this.storeDeltaPosition;\n\tv358 = 0;\n\tv397 = 0x1586898(&v358 @ stack_-A8_v10 (UnityEngine.Vector3), 0, 0x44, v27, v28, v29, v30, v31, v225, v212, 0, v35, v36, v37, v38, v39);\n\tv374.value = 0;\n\tv374.value.z = 0f;\nL_00D4:\n\tv380 = this.storeDeltaX;\n\tv380.value = v225;\n\tv378 = this.storeDeltaY;\n\tv378.value = v212;\n\tv376 = this.storeDeltaTime;\n\tv399 = 0x16717B4(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv376.value = v372;\n\tv377 = this.storeTapCount;\n\tv400 = 0x16717BC(&v23 @ stack_-98, 0, 0x44, v27, v28, v29, v30, v31, v372, v366, v369, v35, v36, v37, v38, v39);\n\tv377.value = v400;\nL_00EA:\n\tv309 = v54.Length;\n\tv237 = v237 + 1;\n\tv91 = v237 < v54.Length;\n\tif (v91) goto L_0032;\nL_0102:\n\treturn;\n\tv299 = new System.NullReferenceException();\n\tv307 = new System.NullReferenceException();\nL_0106:\n\tv317 = new System.IndexOutOfRangeException();\n\tthrow v317;\n\treturn;\n// 180 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetTouchInfo()
		{
			//IL_009b: Expected O, but got I
			//IL_00aa: Expected O, but got I
			//IL_02a1: Expected O, but got I4
			//IL_0446: Expected O, but got I4
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			int touchCount = Input.touchCount;
			if (touchCount < 1)
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
			int num4 = default(int);
			float num6 = default(float);
			float num8 = default(float);
			int value6 = default(int);
			while (num2 < num)
			{
				int num3 = num2 * 68;
				object obj = (long)(IntPtr)touches + (long)num3;
				object obj2 = (long)(IntPtr)obj + 32L;
				Il2CppRuntime.Boundary("SYSTEM_API:memmove", "Method not found @6D1DA0 (native memmove)");
				if (!fingerId.IsNone)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
					int value = fingerId.Value;
					if (num4 != value)
					{
						goto IL_04e6;
					}
				}
				bool value2 = normalize.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
				bool flag = !value2;
				float num5 = num6;
				if (!flag)
				{
					num5 = num6 / screenWidth;
					num6 = screenWidth;
				}
				bool value3 = normalize.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717A4 (inside UnityEngine.SendMouseEvents::.cctor +0x184)");
				bool flag2 = !value3;
				float num7 = num8;
				if (!flag2)
				{
					num6 = screenHeight;
					num7 = num8 / screenHeight;
				}
				if (!storePosition.IsNone)
				{
					FsmVector3 fsmVector = storePosition;
					Vector3 vector = default(Vector3);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					fsmVector.value = default(Vector3);
					fsmVector.value.z = 0f;
					num8 = num7;
					object obj3 = 0;
					num6 = num5;
				}
				FsmFloat fsmFloat = storeX;
				fsmFloat.Value = num5;
				FsmFloat fsmFloat2 = storeY;
				fsmFloat2.Value = num7;
				bool value4 = normalize.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717AC (inside UnityEngine.SendMouseEvents::.cctor +0x18C)");
				bool flag3 = !value4;
				float num9 = num6;
				if (!flag3)
				{
					num9 = num6 / screenWidth;
					num6 = screenWidth;
				}
				bool value5 = normalize.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717AC (inside UnityEngine.SendMouseEvents::.cctor +0x18C)");
				bool flag4 = !value5;
				float num10 = num8;
				if (!flag4)
				{
					num6 = screenHeight;
					num10 = num8 / screenHeight;
				}
				if (!storeDeltaPosition.IsNone)
				{
					FsmVector3 fsmVector2 = storeDeltaPosition;
					Vector3 vector = default(Vector3);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					fsmVector2.value = default(Vector3);
					fsmVector2.value.z = 0f;
					num8 = num10;
					object obj3 = 0;
					num6 = num9;
				}
				FsmFloat fsmFloat3 = storeDeltaX;
				fsmFloat3.Value = num9;
				FsmFloat fsmFloat4 = storeDeltaY;
				fsmFloat4.Value = num10;
				FsmFloat fsmFloat5 = storeDeltaTime;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717B4 (inside UnityEngine.SendMouseEvents::.cctor +0x194)");
				fsmFloat5.Value = num6;
				FsmInt fsmInt = storeTapCount;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717BC (inside UnityEngine.SendMouseEvents::.cctor +0x19C)");
				fsmInt.Value = value6;
				goto IL_04e6;
				IL_04e6:
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

		[Token(Token = "0x600099C")]
		[Address(RVA = "0xA36D9C", Offset = "0xA36D9C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 1;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetTouchInfo()
		{
			everyFrame = true;
		}
	}
}
