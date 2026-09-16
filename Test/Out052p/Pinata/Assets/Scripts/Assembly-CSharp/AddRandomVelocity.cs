using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[Attribute(Type = typeof(RequireComponent), RVA = "0x74C844", Offset = "0x74C844")]
[Token(Token = "0x2000019")]
public class AddRandomVelocity : MonoBehaviour
{
	[Token(Token = "0x40000C6")]
	[FieldOffset(Offset = "0x18")]
	public float intensity;

	[Token(Token = "0x600009F")]
	[Address(RVA = "0x9FCD28", Offset = "0x9FCD28", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0B440]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C3D]) = v46;\nL_0019:\n\tv49 = UnityEngine.Input::GetKeyDown(0x20);\n\tv51 = v49 == 0;\n\tif (v51) goto L_005A;\n\tv56 = UnityEngine.Component::GetComponent(this);\n\tv67 = UnityEngine.Random::get_onUnitSphere();\n\tgoto L_003D;\n\tv121 = *([v117 @ X0_v7+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_003D;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v55, v30, v31, v32, v33, v34, v35, v67, v113, v114, v39, v40, v41, v42, v43);\nL_003D:\n\tv97 = UnityEngine.Vector3::op_Multiply(v67, this.intensity);\n\tObi.ObiActor::AddForce(v56, v97, 2);\n\treturn;\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			ObiActor component = GetComponent<ObiActor>();
			Vector3 onUnitSphere = Random.onUnitSphere;
			Vector3 force = onUnitSphere * intensity;
			component.AddForce(force, ForceMode.VelocityChange);
		}
	}

	[Token(Token = "0x60000A0")]
	[Address(RVA = "0x9FCE1C", Offset = "0x9FCE1C", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intensity = 5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AddRandomVelocity()
	{
		intensity = 5f;
	}
}
