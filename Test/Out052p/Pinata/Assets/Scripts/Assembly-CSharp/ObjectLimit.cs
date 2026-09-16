using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000022")]
public class ObjectLimit : MonoBehaviour
{
	[Token(Token = "0x40000E1")]
	[FieldOffset(Offset = "0x18")]
	public float minX;

	[Token(Token = "0x40000E2")]
	[FieldOffset(Offset = "0x1C")]
	public float maxX;

	[Token(Token = "0x40000E3")]
	[FieldOffset(Offset = "0x20")]
	public float minY;

	[Token(Token = "0x40000E4")]
	[FieldOffset(Offset = "0x24")]
	public float maxY;

	[Token(Token = "0x40000E5")]
	[FieldOffset(Offset = "0x28")]
	public float minZ;

	[Token(Token = "0x40000E6")]
	[FieldOffset(Offset = "0x2C")]
	public float maxZ;

	[Token(Token = "0x60000C5")]
	[Address(RVA = "0x98F408", Offset = "0x98F408", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB1018]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202170C]) = v44;\nL_0018:\n\tv47 = UnityEngine.Component::get_transform(this);\n\tv51 = UnityEngine.Component::get_gameObject(this);\n\tv54 = UnityEngine.GameObject::get_transform(v51);\n\tv119 = UnityEngine.Transform::get_localPosition(v54);\n\tgoto L_003A;\n\tv161 = *([v125 @ X0_v12+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_003A;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v125, v118, v28, v29, v30, v31, v32, v33, v119, v120, v121, v37, v38, v39, v40, v41);\nL_003A:\n\tv71 = UnityEngine.Mathf::Clamp(v119, this.minX, this.maxX);\n\tv79 = UnityEngine.Component::get_gameObject(this);\n\tv80 = UnityEngine.GameObject::get_transform(v79);\n\tv171 = UnityEngine.Transform::get_localPosition(v80);\n\tv72 = UnityEngine.Mathf::Clamp(v171.y, this.minY, this.maxY);\n\tv81 = UnityEngine.Component::get_gameObject(this);\n\tv82 = UnityEngine.GameObject::get_transform(v81);\n\tv178 = UnityEngine.Transform::get_localPosition(v82);\n\tv185 = UnityEngine.Mathf::Clamp(v178.z, this.minZ, this.maxZ);\n\tv94 = 0;\n\tv112 = 0x1586898(&v94 @ stack_-50_v2, 0, v28, v29, v30, v31, v32, v33, v71, v72, v185, this.maxZ, v38, v39, v40, v41);\n\t// 114 MakeStruct v132 @ AGG98F564_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v187 @ stack_-4C, 0\n\tUnityEngine.Transform::set_localPosition(v47, v132);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		//IL_00f2: Expected O, but got I4
		//IL_011c: Expected F4, but got O
		Transform transform = base.transform;
		GameObject gameObject = base.gameObject;
		Transform transform2 = gameObject.transform;
		float num = Mathf.Clamp(transform2.localPosition.x, minX, maxX);
		GameObject gameObject2 = base.gameObject;
		Transform transform3 = gameObject2.transform;
		float num2 = Mathf.Clamp(transform3.localPosition.y, minY, maxY);
		GameObject gameObject3 = base.gameObject;
		Transform transform4 = gameObject3.transform;
		float num3 = Mathf.Clamp(transform4.localPosition.z, minZ, maxZ);
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
		Vector3 localPosition = default(Vector3);
		localPosition.x = 0f;
		object obj2 = default(object);
		localPosition.y = (float)obj2;
		localPosition.z = 0f;
		transform.localPosition = localPosition;
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0x98F58C", Offset = "0x98F58C", Length = "0x18")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxX = 1f;\n\tthis.maxY = 1f;\n\tthis.maxZ = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ObjectLimit()
	{
		maxX = 1f;
		maxY = 1f;
		maxZ = 1f;
	}
}
