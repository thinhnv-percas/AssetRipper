using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000015")]
	public class DraggableTransform : MonoBehaviour
	{
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x20")]
		private Vector2 mousePreviousWorld;

		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x28")]
		private Vector2 mouseDeltaWorld;

		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x30")]
		private Camera mainCamera;

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x150AFBC", Offset = "0x150AFBC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Camera::get_main();\n\tthis.mainCamera = v7;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Camera main = Camera.main;
			mainCamera = main;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x150AFD8", Offset = "0x150AFD8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Input::get_mousePosition();\n\tv22 = UnityEngine.Component::get_transform(this.mainCamera);\n\tv43 = UnityEngine.Transform::get_position(v22);\n\tv75 = -v43.z;\n\t// 30 MakeStruct v52 @ AGG150F02C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v13 @ V0_v1 (UnityEngine.Vector3), v13.y (System.Single), v75 @ V2_v3\n\tv68 = UnityEngine.Camera::ScreenToWorldPoint(this.mainCamera, v52);\n\tthis.mousePreviousWorld = v68;\n\tthis.mousePreviousWorld.y = v68.y;\n\tv64 = v68 - this.mousePreviousWorld;\n\tthis.mouseDeltaWorld = v64;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_003d: Expected O, but got F4
			//IL_006e: Expected F4, but got O
			//IL_00c9: Expected O, but got F4
			Vector3 mousePosition = Input.mousePosition;
			Transform transform = mainCamera.transform;
			object obj = 0f - transform.position.z;
			Vector3 position = default(Vector3);
			position.x = mousePosition.x;
			position.y = mousePosition.y;
			position.z = (float)obj;
			Vector3 vector = (mousePreviousWorld = mainCamera.ScreenToWorldPoint(position));
			mousePreviousWorld.y = vector.y;
			float num = vector.x - mousePreviousWorld.x;
			mouseDeltaWorld = (Vector2)num;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x150B05C", Offset = "0x150B05C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_transform(this);\n\t// 15 MakeStruct v15 @ AGG150F080_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.mouseDeltaWorld (UnityEngine.Vector2), this.mouseDeltaWorld.y (System.Single), 0\n\tUnityEngine.Transform::Translate(v7, v15);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnMouseDrag()
		{
			Transform transform = base.transform;
			Vector3 translation = default(Vector3);
			translation.x = mouseDeltaWorld.x;
			translation.y = mouseDeltaWorld.y;
			translation.z = 0f;
			transform.Translate(translation);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x150B088", Offset = "0x150B088", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DraggableTransform()
		{
		}
	}
}
