using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.UncoInput
{
	[Token(Token = "0x2000006")]
	public class UncoStandaloneInputModule : StandaloneInputModule
	{
		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81DE050", Offset = "0x81DE050", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_002C:\n\tv67 = UnityEngine.Object::FindObjectsOfType();\n\tv71 = UnityEngine.Component::GetComponent(this);\n\tv77 = v67.Length < 1;\n\tv99 = v67.Length - 1;\n\tif (v77) goto L_0094;\n\tgoto L_0062;\nL_0043:\n\tUnityEngine.Object::Destroy(v275);\nL_0044:\n\tv181 = v99 - 1;\n\tv154 = v99 <= 0;\n\tv99 = v181;\n\tif (v154) goto L_0094;\nL_0062:\n\tgoto L_0066;\nL_0066:\n\tv247 = UnityEngine.Object::op_Inequality(v67[v99 @ X23_v5], v71);\n\tv249 = ~v247;\n\tif (v249) goto L_0044;\n\tgoto L_0080;\nL_0080:\n\tv275 = UnityEngine.Component::get_gameObject(v67[v99 @ X23_v5]);\n\tgoto L_0043;\nL_0094:\n\treturn;\nL_0024:\n\tUnityEngine.EventSystems.UIBehaviour::Awake(this);\n\tgoto L_002C;\n")]
		protected override void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoStandaloneInputModule::Awake");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81DDE7C", Offset = "0x81DDE7C", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::set_simulateMouseWithTouches(1);\n\tv22 = 0;\n\tUnityEngine.Touch::set_position(&v30 @ stack_-80_v2 (UnityEngine.Touch), vector2);\n\tv43 = v30;\n\tv51 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this, &v43 @ stack_-D0_v1 (UnityEngine.Touch), &v47 @ stack_-31 (System.Boolean), &v22 @ stack_-32_v1 (System.Boolean));\n\tv22 = 0;\n\tUnityEngine.Touch::set_position(&v30 @ stack_-80_v2 (UnityEngine.Touch), vector2);\n\tv43 = v30;\n\tv80 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this, &v43 @ stack_-D0_v1 (UnityEngine.Touch), &v47 @ stack_-31 (System.Boolean), &v22 @ stack_-32_v1 (System.Boolean));\n\tUnityEngine.EventSystems.StandaloneInputModule::ProcessTouchPress(this, v80, 1, 1);\n\treturn;\n")]
		public void Click(Vector2 vector2)
		{
			Input.simulateMouseWithTouches = true;
			bool released = false;
			Touch touch = default(Touch);
			touch.position = vector2;
			Touch touch2 = touch;
			PointerEventData touchPointerEventData = GetTouchPointerEventData(touch2, out var pressed, out released);
			released = false;
			touch.position = vector2;
			touch2 = touch;
			PointerEventData touchPointerEventData2 = GetTouchPointerEventData(touch2, out pressed, out released);
			ProcessTouchPress(touchPointerEventData2, pressed: true, released: true);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81DE1C4", Offset = "0x81DE1C4", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::set_simulateMouseWithTouches(1);\n\tv22 = 0;\n\t// 25 MakeStruct v34 @ AGG81DE214_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), x @ V0 (System.Single), y @ V1 (System.Single)\n\tUnityEngine.Touch::set_position(&v30 @ stack_-80_v2 (UnityEngine.Touch), v34);\n\tv43 = v30;\n\tv51 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this, &v43 @ stack_-D0_v1 (UnityEngine.Touch), &v47 @ stack_-31 (System.Boolean), &v22 @ stack_-32_v1 (System.Boolean));\n\tv22 = 0;\n\t// 54 MakeStruct v64 @ AGG81DE26C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), x @ V0 (System.Single), y @ V1 (System.Single)\n\tUnityEngine.Touch::set_position(&v30 @ stack_-80_v2 (UnityEngine.Touch), v64);\n\tv43 = v30;\n\tv80 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this, &v43 @ stack_-D0_v1 (UnityEngine.Touch), &v47 @ stack_-31 (System.Boolean), &v22 @ stack_-32_v1 (System.Boolean));\n\tUnityEngine.EventSystems.StandaloneInputModule::ProcessTouchPress(this, v80, 1, 1);\n\treturn;\n")]
		public void Click(float x, float y)
		{
			Input.simulateMouseWithTouches = true;
			bool released = false;
			Vector2 position = default(Vector2);
			position.x = x;
			position.y = y;
			Touch touch = default(Touch);
			touch.position = position;
			Touch touch2 = touch;
			PointerEventData touchPointerEventData = GetTouchPointerEventData(touch2, out var pressed, out released);
			released = false;
			Vector2 position2 = default(Vector2);
			position2.x = x;
			position2.y = y;
			touch.position = position2;
			touch2 = touch;
			PointerEventData touchPointerEventData2 = GetTouchPointerEventData(touch2, out pressed, out released);
			ProcessTouchPress(touchPointerEventData2, pressed: true, released: true);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81DE2CC", Offset = "0x81DE2CC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tUnityEngine.Touch::set_position(&v22 @ stack_-70_v2 (UnityEngine.Touch), vector2);\n\tv33 = v22;\n\treturnVal1 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this, &v33 @ stack_-C0_v1 (UnityEngine.Touch), &v37 @ stack_-21 (System.Boolean), &v14 @ stack_-22_v1 (System.Boolean));\n\treturn returnVal1;\n")]
		private PointerEventData GetPointerEventData(Vector2 vector2)
		{
			bool released = false;
			Touch touch = default(Touch);
			touch.position = vector2;
			Touch touch2 = touch;
			bool pressed;
			return GetTouchPointerEventData(touch2, out pressed, out released);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81DDFDC", Offset = "0x81DDFDC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::set_simulateMouseWithTouches(1);\n\tUnityEngine.EventSystems.StandaloneInputModule::ProcessTouchPress(this, data, pressed, released);\n\treturn;\n")]
		public void ProcessTouch(PointerEventData data, bool pressed, bool released)
		{
			Input.simulateMouseWithTouches = true;
			ProcessTouchPress(data, pressed, released);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81DE340", Offset = "0x81DE340", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.EventSystems.StandaloneInputModule::.ctor(this);\n\treturn;\n")]
		public UncoStandaloneInputModule()
		{
		}
	}
}
