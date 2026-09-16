using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000024")]
public class CharacterControl2D : MonoBehaviour
{
	[Token(Token = "0x40000E7")]
	[FieldOffset(Offset = "0x18")]
	public float acceleration;

	[Token(Token = "0x40000E8")]
	[FieldOffset(Offset = "0x1C")]
	public float maxSpeed;

	[Token(Token = "0x40000E9")]
	[FieldOffset(Offset = "0x20")]
	public float jumpPower;

	[Token(Token = "0x40000EA")]
	[FieldOffset(Offset = "0x28")]
	private Rigidbody unityRigidbody;

	[Token(Token = "0x60000C9")]
	[Address(RVA = "0x9FD814", Offset = "0x9FD814", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECA698]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C41]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityRigidbody = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Awake()
	{
		Rigidbody component = GetComponent<Rigidbody>();
		unityRigidbody = component;
	}

	[Token(Token = "0x60000CA")]
	[Address(RVA = "0x9FD86C", Offset = "0x9FD86C", Length = "0x180")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EDBC58]);\n\tv29 = *([v28 @ X8_v17]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021C42]) = v48;\nL_001D:\n\tv54 = UnityEngine.Input::GetAxis(\"Horizontal\");\n\tv60 = v54 * this.acceleration;\n\tv57 = 0;\n\tv63 = 0x1586898(&v57 @ stack_-60_v1, 0, v32, v33, v34, v35, v36, v37, v60, 0, 0, v41, v42, v43, v44, v45);\n\t// 46 MakeStruct v71 @ AGG9FD900_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v67 @ stack_-5C, 0\n\tUnityEngine.Rigidbody::AddForce(this.unityRigidbody, v71);\n\tv117 = UnityEngine.Rigidbody::get_velocity(this.unityRigidbody);\n\tgoto L_004E;\n\tv169 = *([v165 @ X0_v10+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_004E;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v165, v116, v32, v33, v34, v35, v36, v37, v117, v162, v163, v41, v42, v43, v44, v45);\nL_004E:\n\tv181 = UnityEngine.Vector3::ClampMagnitude(v117, this.maxSpeed);\n\tUnityEngine.Rigidbody::set_velocity(this.unityRigidbody, v181);\n\tv189 = UnityEngine.Input::GetButtonDown(\"Jump\");\n\tv191 = v189 == 0;\n\tif (v191) goto L_0083;\n\tgoto L_0069;\n\tv201 = *([v192 @ X0_v17+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0069;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v192, v98, v32, v33, v34, v35, v36, v37, v181, v182, v183, v179, v42, v43, v44, v45);\nL_0069:\n\tv208 = UnityEngine.Vector3::get_up();\n\tv96 = UnityEngine.Vector3::op_Multiply(v208, this.jumpPower);\n\tUnityEngine.Rigidbody::AddForce(this.unityRigidbody, v96, 2);\nL_0083:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void FixedUpdate()
	{
		//IL_0110: Expected O, but got I4
		//IL_0020: Expected F4, but got O
		float axis = Input.GetAxis("Horizontal");
		float num = axis * acceleration;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Vector3 force = default(Vector3);
		force.x = 0f;
		object obj2 = default(object);
		force.y = (float)obj2;
		force.z = 0f;
		unityRigidbody.AddForce(force);
		Vector3 velocity = unityRigidbody.velocity;
		Vector3 velocity2 = Vector3.ClampMagnitude(velocity, maxSpeed);
		unityRigidbody.velocity = velocity2;
		if (Input.GetButtonDown("Jump"))
		{
			Vector3 up = Vector3.up;
			Vector3 force2 = up * jumpPower;
			unityRigidbody.AddForce(force2, ForceMode.VelocityChange);
		}
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0x9FD9EC", Offset = "0x9FD9EC", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.acceleration = 10f;\n\tthis.jumpPower = 2f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CharacterControl2D()
	{
		acceleration = 10f;
		jumpPower = 2f;
	}
}
