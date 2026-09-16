using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Lean.Common
{
	[Token(Token = "0x2000005")]
	public static class LeanInput
	{
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x135E524", Offset = "0x135E524", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::get_touchCount();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetTouchCount()
		{
			return Input.touchCount;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x135E52C", Offset = "0x135E52C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = 0;\n\tv27 = UnityEngine.Input::GetTouch(index);\n\tv29 = v27.m_FingerId;\n\tv49 = 0x1854F10(&v25 @ stack_-80_v1 (UnityEngine.Touch), &v29 @ stack_-C8_v1 (System.Int32), 0x44, pressure, set, methodInfo, v51, v52, 0, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = UnityEngine.Touch::get_fingerId(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\t*([id @ X1 (System.Int32&)]) = v62;\n\tv65 = UnityEngine.Touch::get_position(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\t*([position @ X2 (UnityEngine.Vector2&)]) = v65;\n\t*([position @ X2 (UnityEngine.Vector2&)+4]) = v65.y;\n\tv69 = UnityEngine.Touch::get_pressure(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\t*([pressure @ X3 (System.Single&)]) = v69;\n\tv72 = UnityEngine.Touch::get_phase(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\tv73 = v72 == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tv76 = UnityEngine.Touch::get_phase(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\tv78 = v76 != 2;\n\tif (v78) goto L_004D;\n\tgoto L_0058;\nL_004D:\n\tv126 = UnityEngine.Touch::get_phase(&v25 @ stack_-80_v1 (UnityEngine.Touch));\n\tv122 = v126 - 1;\n\tv118 = v122 == 0;\nL_0058:\n\t*([set @ X4 (System.Boolean&)]) = v129;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void GetTouch(int index, out int id, out Vector2 position, out float pressure, out bool set)
		{
			//IL_00a9: Expected Ref, but got F4
			id = default(int);
			position = default(Vector2);
			pressure = default(float);
			set = default(bool);
			Touch touch = default(Touch);
			int fingerId = Input.GetTouch(index).m_FingerId;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
			int fingerId2 = touch.fingerId;
			ref int reference = ref *(int*)fingerId2;
			Vector2 position2 = touch.position;
			ref Vector2 reference2 = ref *(Vector2*)position2;
			_ = position2.y;
			float pressure2 = touch.pressure;
			ref float reference3 = ref *(float*)pressure2;
			bool flag2;
			if (touch.phase != TouchPhase.Began)
			{
				TouchPhase phase = touch.phase;
				if (phase != TouchPhase.Stationary)
				{
					TouchPhase phase2 = touch.phase;
					int num = (int)(phase2 - 1);
					bool flag = num == 0;
					flag2 = flag;
					goto IL_014a;
				}
			}
			flag2 = true;
			goto IL_014a;
			IL_014a:
			ref bool reference4 = ref *(flag2 ? ((bool*)1) : ((bool*)null));
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x135E600", Offset = "0x135E600", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::get_mousePosition();\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetMousePosition()
		{
			return Input.mousePosition;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x135E608", Offset = "0x135E608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetKeyDown(oldKey);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetDown(KeyCode oldKey)
		{
			return Input.GetKeyDown(oldKey);
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x135E610", Offset = "0x135E610", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetKey(oldKey);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetPressed(KeyCode oldKey)
		{
			return Input.GetKey(oldKey);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x135E618", Offset = "0x135E618", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetKeyUp(oldKey);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetUp(KeyCode oldKey)
		{
			return Input.GetKeyUp(oldKey);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x135E620", Offset = "0x135E620", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetMouseButtonDown(index);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetMouseDown(int index)
		{
			return Input.GetMouseButtonDown(index);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x135E628", Offset = "0x135E628", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetMouseButton(index);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetMousePressed(int index)
		{
			return Input.GetMouseButton(index);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x135E630", Offset = "0x135E630", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetMouseButtonUp(index);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetMouseUp(int index)
		{
			return Input.GetMouseButtonUp(index);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x135E638", Offset = "0x135E638", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = UnityEngine.Input::get_mouseScrollDelta();\n\treturn v3.y;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float GetMouseWheelDelta()
		{
			return Input.mouseScrollDelta.y;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x135E650", Offset = "0x135E650", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::get_mousePresent();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetMouseExists()
		{
			return Input.mousePresent;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x135E658", Offset = "0x135E658", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GetKeyboardExists()
		{
			return true;
		}
	}
}
