using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[ExecuteInEditMode]
[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74C970", Offset = "0x74C970")]
[Token(Token = "0x200001D")]
public class DebugParticleFrames : MonoBehaviour
{
	[Token(Token = "0x40000CD")]
	[FieldOffset(Offset = "0x18")]
	private ObiActor actor;

	[Token(Token = "0x40000CE")]
	[FieldOffset(Offset = "0x20")]
	public float size;

	[Token(Token = "0x60000B0")]
	[Address(RVA = "0x9FE6CC", Offset = "0x9FE6CC", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAFA80]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C4E]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.actor = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Awake()
	{
		ObiActor component = GetComponent<ObiActor>();
		actor = component;
	}

	[Token(Token = "0x60000B1")]
	[Address(RVA = "0x9FE724", Offset = "0x9FE724", Length = "0x29C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv34 = *([1EA5BC8]);\n\tv35 = *([v34 @ X8_v15]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021C4F]) = v54;\nL_0022:\n\tv193 = 0;\n\tv68 = 0x158BA74(&v193 @ stack_-70_v5 (UnityEngine.Vector4), 0, v38, v39, v40, v41, v42, v43, 1f, 0, 0, 0, v48, v49, v50, v51);\n\tv76 = 0x158BA74(&v267 @ stack_-80_v6 (UnityEngine.Vector4), 0, v38, v39, v40, v41, v42, v43, 0, 1f, 0, 0, v48, v49, v50, v51);\n\tv84 = 0x158BA74(&v249 @ stack_-90_v6 (UnityEngine.Vector4), 0, v38, v39, v40, v41, v42, v43, 0, 0, 1f, 0, v48, v49, v50, v51);\n\tv271 = this.actor;\nL_0047:\n\tv91 = v280 >= v271.m_ActiveParticleCount;\n\tif (v91) goto L_0107;\n\tv277 = v271.solverIndices;\n\tv433 = v280 < v277.Length;\n\tv240 = ~v433;\n\tif (v240) goto L_0109;\n\tv437 = Obi.ObiActor::GetParticlePosition(v271, v277[v280 @ X20_v6 (System.Int32)]);\n\tObi.ObiActor::GetParticleAnisotropy(this.actor, v280, &v193 @ stack_-70_v5 (UnityEngine.Vector4), &v267 @ stack_-80_v6 (UnityEngine.Vector4), &v249 @ stack_-90_v6 (UnityEngine.Vector4));\n\tv448 = UnityEngine.Color::get_red();\n\tUnityEngine.Gizmos::set_color(v448);\n\tgoto L_0086;\n\tv459 = *([v453 @ X0_v21+E0]);\n\tv460 = v459 == 0;\n\tv461 = ~v460;\n\tif (v461) goto L_0086;\n\tv463 = \"il2cpp_codegen_runtime_class_init\"(v453, v252, v205, v190, v187, v184, v42, v43, v448, v449, v450, v451, v166, v151, v50, v51);\nL_0086:\n\t// 134 MakeStruct v161 @ AGG9FE88C_0_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v193 @ stack_-70_v5 (UnityEngine.Vector4), v454 @ stack_-6C, 0, v455 @ stack_-64 (System.Single)\n\tv471 = UnityEngine.Vector4::op_Multiply(v161, v455);\n\tv477 = UnityEngine.Vector4::op_Multiply(v471, this.size);\n\tv482 = UnityEngine.Vector4::op_Implicit(v477);\n\tUnityEngine.Gizmos::DrawRay(v437, v482);\n\tv493 = UnityEngine.Color::get_green();\n\tUnityEngine.Gizmos::set_color(v493);\n\t// 175 MakeStruct v134 @ AGG9FE8E4_0_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v267 @ stack_-80_v6 (UnityEngine.Vector4), v503 @ stack_-7C, 0, v500 @ stack_-74 (System.Single)\n\tv506 = UnityEngine.Vector4::op_Multiply(v134, v500);\n\tv512 = UnityEngine.Vector4::op_Multiply(v506, this.size);\n\tv517 = UnityEngine.Vector4::op_Implicit(v512);\n\tUnityEngine.Gizmos::DrawRay(v437, v517);\n\tv528 = UnityEngine.Color::get_blue();\n\tUnityEngine.Gizmos::set_color(v528);\n\t// 216 MakeStruct v110 @ AGG9FE93C_0_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v249 @ stack_-90_v6 (UnityEngine.Vector4), v538 @ stack_-8C, 0, v535 @ stack_-84 (System.Single)\n\tv541 = UnityEngine.Vector4::op_Multiply(v110, v535);\n\tv547 = UnityEngine.Vector4::op_Multiply(v541, this.size);\n\tv552 = UnityEngine.Vector4::op_Implicit(v547);\n\tUnityEngine.Gizmos::DrawRay(v437, v552);\n\tv271 = this.actor;\n\tv280 = v280 + 1;\n\tv556 = this.actor == 0;\n\tv273 = ~v556;\n\tif (v273) goto L_0047;\n\tthrow System.NullReferenceException;\nL_0107:\n\treturn;\n\tv443 = new System.NullReferenceException();\nL_0109:\n\tv445 = new System.IndexOutOfRangeException();\n\tthrow v445;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDrawGizmos()
	{
		//IL_00d3: Expected F4, but got O
		//IL_016c: Expected F4, but got O
		//IL_0205: Expected F4, but got O
		Vector4 b = default(Vector4);
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
		ObiActor obiActor = actor;
		int num = 0;
		Vector4 b2 = default(Vector4);
		Vector4 b3 = default(Vector4);
		Vector4 vector = default(Vector4);
		object obj = default(object);
		float num2 = default(float);
		Vector4 vector4 = default(Vector4);
		object obj2 = default(object);
		float num3 = default(float);
		Vector4 vector7 = default(Vector4);
		object obj3 = default(object);
		float num4 = default(float);
		while (true)
		{
			if (num < obiActor.activeParticleCount)
			{
				int[] solverIndices = obiActor.solverIndices;
				if (num >= solverIndices.Length)
				{
					break;
				}
				Vector3 particlePosition = obiActor.GetParticlePosition(solverIndices[num]);
				actor.GetParticleAnisotropy(num, ref b, ref b2, ref b3);
				Color red = Color.red;
				Gizmos.color = red;
				vector.x = b.x;
				vector.y = (float)obj;
				vector.z = 0f;
				vector.w = num2;
				Vector4 vector2 = vector * num2;
				Vector4 vector3 = vector2 * size;
				Vector3 direction = vector3;
				Gizmos.DrawRay(particlePosition, direction);
				Color green = Color.green;
				Gizmos.color = green;
				vector4.x = b2.x;
				vector4.y = (float)obj2;
				vector4.z = 0f;
				vector4.w = num3;
				Vector4 vector5 = vector4 * num3;
				Vector4 vector6 = vector5 * size;
				Vector3 direction2 = vector6;
				Gizmos.DrawRay(particlePosition, direction2);
				Color blue = Color.blue;
				Gizmos.color = blue;
				vector7.x = b3.x;
				vector7.y = (float)obj3;
				vector7.z = 0f;
				vector7.w = num4;
				Vector4 vector8 = vector7 * num4;
				Vector4 vector9 = vector8 * size;
				Vector3 direction3 = vector9;
				Gizmos.DrawRay(particlePosition, direction3);
				obiActor = actor;
				num++;
				if ((object)actor == null)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x60000B2")]
	[Address(RVA = "0x9FE9C0", Offset = "0x9FE9C0", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.size = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DebugParticleFrames()
	{
		size = 1f;
	}
}
