using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000021")]
public class ObjectDragger : MonoBehaviour
{
	[Token(Token = "0x40000DF")]
	[FieldOffset(Offset = "0x18")]
	private Vector3 screenPoint;

	[Token(Token = "0x40000E0")]
	[FieldOffset(Offset = "0x24")]
	private Vector3 offset;

	[Token(Token = "0x60000C2")]
	[Address(RVA = "0x98F148", Offset = "0x98F148", Length = "0x18C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EEE4E8]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202170A]) = v50;\nL_001A:\n\tv52 = UnityEngine.Camera::get_main();\n\tv56 = UnityEngine.Component::get_gameObject(this);\n\tv59 = UnityEngine.GameObject::get_transform(v56);\n\tv102 = UnityEngine.Transform::get_position(v59);\n\tv68 = UnityEngine.Camera::WorldToScreenPoint(v52, v102);\n\tthis.screenPoint = v68;\n\tthis.screenPoint.y = v68.y;\n\tthis.screenPoint.z = v68.z;\n\tv73 = UnityEngine.Component::get_gameObject(this);\n\tv74 = UnityEngine.GameObject::get_transform(v73);\n\tv172 = UnityEngine.Transform::get_position(v74);\n\tv176 = UnityEngine.Camera::get_main();\n\tv178 = UnityEngine.Input::get_mousePosition();\n\tv182 = UnityEngine.Input::get_mousePosition();\n\tv82 = 0;\n\tv108 = 0x1586898(&v82 @ stack_-60_v2, 0, v34, v35, v36, v37, v38, v39, v178, v182.y, this.screenPoint.z, v43, v44, v45, v46, v47);\n\t// 94 MakeStruct v135 @ AGG98F254_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v187 @ stack_-5C, 0\n\tv190 = UnityEngine.Camera::ScreenToWorldPoint(v176, v135);\n\tgoto L_007A;\n\tv202 = *([v198 @ X0_v23+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_007A;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v198, v155, v34, v35, v36, v37, v38, v39, v190, v191, v192, v43, v44, v45, v46, v47);\nL_007A:\n\tv153 = UnityEngine.Vector3::op_Subtraction(v172, v190);\n\tthis.offset = v153;\n\tthis.offset.y = v153.y;\n\tthis.offset.z = v153.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnMouseDown()
	{
		//IL_00c8: Expected O, but got I4
		//IL_00f7: Expected F4, but got O
		Camera main = Camera.main;
		GameObject gameObject = base.gameObject;
		Transform transform = gameObject.transform;
		Vector3 position = transform.position;
		Vector3 vector = (screenPoint = main.WorldToScreenPoint(position));
		screenPoint.y = vector.y;
		screenPoint.z = vector.z;
		GameObject gameObject2 = base.gameObject;
		Transform transform2 = gameObject2.transform;
		Vector3 position2 = transform2.position;
		Camera main2 = Camera.main;
		Vector3 mousePosition = Input.mousePosition;
		Vector3 mousePosition2 = Input.mousePosition;
		object obj = 0;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Vector3 position3 = default(Vector3);
		position3.x = 0f;
		object obj2 = default(object);
		position3.y = (float)obj2;
		position3.z = 0f;
		Vector3 vector2 = main2.ScreenToWorldPoint(position3);
		Vector3 vector3 = (offset = position2 - vector2);
		offset.y = vector3.y;
		offset.z = vector3.z;
	}

	[Token(Token = "0x60000C3")]
	[Address(RVA = "0x98F2D4", Offset = "0x98F2D4", Length = "0x12C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EDEF00]);\n\tv31 = *([v30 @ X8_v11]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202170B]) = v50;\nL_001C:\n\tv54 = UnityEngine.Input::get_mousePosition();\n\tv59 = UnityEngine.Input::get_mousePosition();\n\tv67 = 0x1586898(&v64 @ stack_-60_v2, 0, v34, v35, v36, v37, v38, v39, v54, v59.y, this.screenPoint.z, v43, v44, v45, v46, v47);\n\tv70 = UnityEngine.Component::get_transform(this);\n\tv73 = UnityEngine.Camera::get_main();\n\t// 53 MakeStruct v80 @ AGG98F370_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v64 @ stack_-60_v2, v76 @ stack_-5C, 0\n\tv81 = UnityEngine.Camera::ScreenToWorldPoint(v73, v80);\n\tgoto L_0053;\n\tv132 = *([v91 @ X0_v14+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0053;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v91, v79, v34, v35, v36, v37, v38, v39, v81, v83, v84, v43, v44, v45, v46, v47);\nL_0053:\n\t// 83 MakeStruct v99 @ AGG98F3C4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.offset (UnityEngine.Vector3), this.offset.y (System.Single), this.offset.z (System.Single)\n\tv118 = UnityEngine.Vector3::op_Addition(v81, v99);\n\tUnityEngine.Transform::set_position(v70, v118);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnMouseDrag()
	{
		//IL_002a: Expected F4, but got O
		//IL_0037: Expected F4, but got O
		Vector3 mousePosition = Input.mousePosition;
		Vector3 mousePosition2 = Input.mousePosition;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Transform transform = base.transform;
		Camera main = Camera.main;
		Vector3 position = default(Vector3);
		object obj = default(object);
		position.x = (float)obj;
		object obj2 = default(object);
		position.y = (float)obj2;
		position.z = 0f;
		Vector3 vector = main.ScreenToWorldPoint(position);
		Vector3 vector2 = default(Vector3);
		vector2.x = offset.x;
		vector2.y = offset.y;
		vector2.z = offset.z;
		Vector3 position2 = vector + vector2;
		transform.position = position2;
	}

	[Token(Token = "0x60000C4")]
	[Address(RVA = "0x98F400", Offset = "0x98F400", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ObjectDragger()
	{
	}
}
