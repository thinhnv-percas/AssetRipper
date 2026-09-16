using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Attribute(Type = typeof(RequireComponent), RVA = "0x7440A0", Offset = "0x7440A0")]
[Token(Token = "0x2000002")]
public class ObiKinematicVelocities : MonoBehaviour
{
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x18")]
	private Quaternion prevRotation;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x28")]
	private Vector3 prevPosition;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x38")]
	private Rigidbody unityRigidbody;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x1036DB4", Offset = "0x1036DB4", Length = "0x9C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAD3C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20262AB]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityRigidbody = v43;\n\tv46 = UnityEngine.Component::get_transform(this);\n\tv49 = UnityEngine.Transform::get_position(v46);\n\tthis.prevPosition = v49;\n\tthis.prevPosition.y = v49.y;\n\tthis.prevPosition.z = v49.z;\n\tv58 = UnityEngine.Component::get_transform(this);\n\tv72 = UnityEngine.Transform::get_rotation(v58);\n\tthis.prevRotation = v72;\n\tthis.prevRotation.y = v72.y;\n\tthis.prevRotation.z = v72.z;\n\tthis.prevRotation.w = v72.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Rigidbody component = GetComponent<Rigidbody>();
		unityRigidbody = component;
		Transform transform = base.transform;
		Vector3 vector = (prevPosition = transform.position);
		prevPosition.y = vector.y;
		prevPosition.z = vector.z;
		Transform transform2 = base.transform;
		Quaternion quaternion = (prevRotation = transform2.rotation);
		prevRotation.y = quaternion.y;
		prevRotation.z = quaternion.z;
		prevRotation.w = quaternion.w;
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x1036E50", Offset = "0x1036E50", Length = "0x26C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EDA890]);\n\tv35 = *([v34 @ X8_v18]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20262AC]) = v54;\nL_001F:\n\tv58 = UnityEngine.Rigidbody::get_isKinematic(this.unityRigidbody);\n\tv169 = v58 == 0;\n\tif (v169) goto L_00BB;\n\tv152 = UnityEngine.Component::get_transform(this);\n\tv297 = UnityEngine.Transform::get_position(v152);\n\tgoto L_0047;\n\tv311 = *([v305 @ X0_v16+E0]);\n\tv312 = v311 == 0;\n\tv313 = ~v312;\n\tif (v313) goto L_0047;\n\tv315 = \"il2cpp_codegen_runtime_class_init\"(v305, v222, v38, v39, v40, v41, v42, v43, v297, v299, v300, v47, v48, v49, v50, v51);\nL_0047:\n\t// 71 MakeStruct v101 @ AGG1036F18_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.prevPosition (UnityEngine.Vector3), this.prevPosition.y (System.Single), this.prevPosition.z (System.Single)\n\tv322 = UnityEngine.Vector3::op_Subtraction(v297, v101);\n\tv326 = UnityEngine.Time::get_deltaTime();\n\tv143 = UnityEngine.Vector3::op_Division(v322, v326);\n\tUnityEngine.Rigidbody::set_velocity(this.unityRigidbody, v143);\n\tv153 = UnityEngine.Component::get_transform(this);\n\tv334 = UnityEngine.Transform::get_rotation(v153);\n\tgoto L_0082;\n\tv347 = *([v341 @ X0_v24+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_0082;\n\tv351 = \"il2cpp_codegen_runtime_class_init\"(v341, v333, v38, v39, v40, v41, v42, v43, v334, v335, v336, v337, v111, v108, v50, v51);\nL_0082:\n\t// 130 MakeStruct v188 @ AGG1036FBC_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), this.prevRotation (UnityEngine.Quaternion), this.prevRotation.y (System.Single), this.prevRotation.z (System.Single), this.prevRotation.w (System.Single)\n\tv358 = UnityEngine.Quaternion::Inverse(v188);\n\tv367 = UnityEngine.Quaternion::op_Multiply(v334, v358);\n\tv176 = 0;\n\tv372 = 0x1586898(&v176 @ stack_-70_v4, 0, v38, v39, v40, v41, v42, v43, v367, v367.y, v367.z, v367.w, v358, v358.y, v358.z, v358.w);\n\t// 161 MakeStruct v174 @ AGG1037010_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v375 @ stack_-6C, 0\n\tv379 = UnityEngine.Vector3::op_Multiply(v174, 2f);\n\tv383 = UnityEngine.Time::get_deltaTime();\n\tv220 = UnityEngine.Vector3::op_Division(v379, v383);\n\tUnityEngine.Rigidbody::set_angularVelocity(this.unityRigidbody, v220);\nL_00BB:\n\tv154 = UnityEngine.Component::get_transform(this);\n\tv145 = UnityEngine.Transform::get_position(v154);\n\tthis.prevPosition = v145;\n\tthis.prevPosition.y = v145.y;\n\tthis.prevPosition.z = v145.z;\n\tv155 = UnityEngine.Component::get_transform(this);\n\tv285 = UnityEngine.Transform::get_rotation(v155);\n\tthis.prevRotation = v285;\n\tthis.prevRotation.y = v285.y;\n\tthis.prevRotation.z = v285.z;\n\tthis.prevRotation.w = v285.w;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 174 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LateUpdate()
	{
		//IL_016f: Expected O, but got I4
		//IL_0199: Expected F4, but got O
		if (unityRigidbody.isKinematic)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 vector = default(Vector3);
			vector.x = prevPosition.x;
			vector.y = prevPosition.y;
			vector.z = prevPosition.z;
			Vector3 vector2 = position - vector;
			float deltaTime = Time.deltaTime;
			Vector3 velocity = vector2 / deltaTime;
			unityRigidbody.velocity = velocity;
			Transform transform2 = base.transform;
			Quaternion rotation = transform2.rotation;
			Quaternion rotation2 = default(Quaternion);
			rotation2.x = prevRotation.x;
			rotation2.y = prevRotation.y;
			rotation2.z = prevRotation.z;
			rotation2.w = prevRotation.w;
			Quaternion quaternion = Quaternion.Inverse(rotation2);
			Quaternion quaternion2 = rotation * quaternion;
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector3 = default(Vector3);
			vector3.x = 0f;
			object obj2 = default(object);
			vector3.y = (float)obj2;
			vector3.z = 0f;
			Vector3 vector4 = vector3 * 2f;
			float deltaTime2 = Time.deltaTime;
			Vector3 angularVelocity = vector4 / deltaTime2;
			unityRigidbody.angularVelocity = angularVelocity;
		}
		Transform transform3 = base.transform;
		Vector3 vector5 = (prevPosition = transform3.position);
		prevPosition.y = vector5.y;
		prevPosition.z = vector5.z;
		Transform transform4 = base.transform;
		Quaternion quaternion3 = (prevRotation = transform4.rotation);
		prevRotation.y = quaternion3.y;
		prevRotation.z = quaternion3.z;
		prevRotation.w = quaternion3.w;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x10370BC", Offset = "0x10370BC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ObiKinematicVelocities()
	{
	}
}
