using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000080")]
	public class ObiRopeAttach : MonoBehaviour
	{
		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x18")]
		public ObiPathSmoother generator;

		[Attribute(Type = typeof(RangeAttribute), RVA = "0x746C80", Offset = "0x746C80")]
		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0x20")]
		public float m;

		[Token(Token = "0x60004FE")]
		[Address(RVA = "0xC38244", Offset = "0xC38244", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EBAAF8]);\n\tv35 = *([v34 @ X8_v15]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20231BB]) = v54;\nL_0020:\n\tv60 = Obi.ObiPathSmoother::GetSectionAt(this.generator, this.m);\n\tv202 = UnityEngine.Component::get_transform(this);\n\tv184 = UnityEngine.Component::get_transform(this.generator);\n\tv181 = UnityEngine.Transform::TransformPoint(v184, v60.position);\n\tUnityEngine.Transform::set_position(v202, v181);\n\tv293 = UnityEngine.Component::get_transform(this);\n\tv185 = UnityEngine.Component::get_transform(this.generator);\n\tv305 = UnityEngine.Transform::get_rotation(v185);\n\tgoto L_0081;\n\tv315 = *([v311 @ X0_v18+E0]);\n\tv316 = v315 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_0081;\n\tv319 = \"il2cpp_codegen_runtime_class_init\"(v311, v287, v38, v39, v40, v41, v42, v43, v305, v306, v307, v308, v48, v49, v50, v51);\nL_0081:\n\tv328 = UnityEngine.Quaternion::LookRotation(v60.tangent, v60.binormal);\n\tv271 = UnityEngine.Quaternion::op_Multiply(v305, v328);\n\tUnityEngine.Transform::set_rotation(v293, v271);\n\treturn;\n\tv183 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			ObiPathFrame sectionAt = generator.GetSectionAt(m);
			Transform transform = base.transform;
			Transform transform2 = generator.transform;
			Vector3 position = transform2.TransformPoint(sectionAt.position);
			transform.position = position;
			Transform transform3 = base.transform;
			Transform transform4 = generator.transform;
			Quaternion rotation = transform4.rotation;
			Quaternion quaternion = Quaternion.LookRotation(sectionAt.tangent, sectionAt.binormal);
			Quaternion rotation2 = rotation * quaternion;
			transform3.rotation = rotation2;
		}

		[Token(Token = "0x60004FF")]
		[Address(RVA = "0xC383E8", Offset = "0xC383E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeAttach()
		{
		}
	}
}
