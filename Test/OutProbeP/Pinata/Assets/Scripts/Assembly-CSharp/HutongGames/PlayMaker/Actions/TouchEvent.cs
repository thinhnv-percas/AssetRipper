using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755A50", Offset = "0x755A50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755A50", Offset = "0x755A50")]
	[Token(Token = "0x20001D2")]
	public class TouchEvent : FsmStateAction
	{
		[Token(Token = "0x40013E4")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt fingerId;

		[Token(Token = "0x40013E5")]
		[FieldOffset(Offset = "0x58")]
		public TouchPhase touchPhase;

		[Token(Token = "0x40013E6")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent sendEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AF498", Offset = "0x7AF498")]
		[Token(Token = "0x40013E7")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt storeFingerId;

		[Token(Token = "0x60009B1")]
		[Address(RVA = "0x99F6BC", Offset = "0x99F6BC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF0860]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217C4]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.fingerId = v42;\n\tthis.storeFingerId = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			fingerId = fsmInt;
			storeFingerId = null;
		}

		[Token(Token = "0x60009B2")]
		[Address(RVA = "0x99F734", Offset = "0x99F734", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = 0x6D26F0(&v19 @ stack_-88, 0, 0x44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv37 = UnityEngine.Input::get_touchCount();\n\tv48 = v37 < 1;\n\tif (v48) goto L_0090;\n\tv50 = UnityEngine.Input::get_touches();\n\tv200 = v50.Length;\n\tv69 = v50.Length < 1;\n\tif (v69) goto L_0090;\nL_0030:\n\tv227 = v152 < v200;\n\tv184 = ~v227;\n\tif (v184) goto L_0092;\n\tv231 = v152 * 0x44;\n\tv154 = v50 + v231;\n\tv187 = v154 + 0x20;\n\tv233 = 0x6D1DA0(&v19 @ stack_-88, v187, 0x44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv244 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.fingerId);\n\tv246 = v244 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_0060;\n\tv240 = 0x167179C(&v19 @ stack_-88, 0, 0x44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv273 = HutongGames.PlayMaker.FsmInt::get_Value(this.fingerId);\n\tv253 = v240 != v273;\n\tif (v253) goto L_007A;\nL_0060:\n\tv276 = 0x16717C4(&v19 @ stack_-88, 0, 0x44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv161 = v276 != this.touchPhase;\n\tif (v161) goto L_007A;\n\tv149 = this.storeFingerId;\n\tv241 = 0x167179C(&v19 @ stack_-88, 0, 0x44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv149.value = v241;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sendEvent);\nL_007A:\n\tv200 = v50.Length;\n\tv152 = v152 + 1;\n\tv68 = v152 < v50.Length;\n\tif (v68) goto L_0030;\nL_0090:\n\treturn;\n\tv194 = new System.NullReferenceException();\nL_0092:\n\tv218 = new System.IndexOutOfRangeException();\n\tthrow v218;\n\tthrow System.NullReferenceException;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_009b: Expected O, but got I
			//IL_00aa: Expected O, but got I
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
			int num5 = default(int);
			int value2 = default(int);
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
						goto IL_01ad;
					}
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16717C4 (inside UnityEngine.SendMouseEvents::.cctor +0x1A4)");
				if (num5 == (int)touchPhase)
				{
					FsmInt fsmInt = storeFingerId;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @167179C (inside UnityEngine.SendMouseEvents::.cctor +0x17C)");
					fsmInt.Value = value2;
					Fsm.Event(sendEvent);
				}
				goto IL_01ad;
				IL_01ad:
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

		[Token(Token = "0x60009B3")]
		[Address(RVA = "0x99F878", Offset = "0x99F878", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TouchEvent()
		{
		}
	}
}
