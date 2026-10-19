using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[Token(Token = "0x200003D")]
	public static class InputProxy
	{
		[Token(Token = "0x17000013")]
		public static Vector3 mousePosition
		{
			[Token(Token = "0x6000131")]
			[Address(RVA = "0x772A8D0", Offset = "0x772A8D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::get_mousePosition();\n\treturn returnVal1;\n")]
			get
			{
				return Input.mousePosition;
			}
		}

		[Token(Token = "0x17000014")]
		public static int touchCount
		{
			[Token(Token = "0x6000133")]
			[Address(RVA = "0x772B5A4", Offset = "0x772B5A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::get_touchCount();\n\treturn returnVal1;\n")]
			get
			{
				return Input.touchCount;
			}
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x7729AB4", Offset = "0x7729AB4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void Init()
		{
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x772AD78", Offset = "0x772AD78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetMouseButtonDown(buttonIndex);\n\treturn returnVal1;\n")]
		public static bool GetMouseButtonDown(int buttonIndex)
		{
			return Input.GetMouseButtonDown(buttonIndex);
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x772B5AC", Offset = "0x772B5AC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Input::GetTouch(touchIndex);\n\tv36 = v9;\n\treturnVal1 = UnityEngine.Touch::get_fingerId(&v36 @ stack_-60_v1 (UnityEngine.Touch));\n\treturn returnVal1;\n")]
		public static int GetFingerIdFromTouch(int touchIndex)
		{
			Touch touch = Input.GetTouch(touchIndex);
			Touch touch2 = touch;
			return touch2.fingerId;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x7732B3C", Offset = "0x7732B3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Input::GetKeyDown(name);\n\treturn returnVal1;\n")]
		public static bool GetKeyDown(string name)
		{
			return Input.GetKeyDown(name);
		}
	}
}
