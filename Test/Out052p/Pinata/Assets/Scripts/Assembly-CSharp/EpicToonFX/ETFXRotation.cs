using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EpicToonFX
{
	[Token(Token = "0x2000067")]
	public class ETFXRotation : MonoBehaviour
	{
		[Token(Token = "0x2000475")]
		public enum spaceEnum
		{
			[Token(Token = "0x40020E6")]
			Local = 0,
			[Token(Token = "0x40020E7")]
			World = 1
		}

		[Attribute(Type = typeof(HeaderAttribute), RVA = "0x764D58", Offset = "0x764D58")]
		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x18")]
		public Vector3 rotateVector;

		[Token(Token = "0x40002AF")]
		[FieldOffset(Offset = "0x24")]
		public spaceEnum rotateSpace;

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xA059E8", Offset = "0xA059E8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Start()
		{
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0xA059EC", Offset = "0xA059EC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC3E70]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C8F]) = v46;\nL_0017:\n\tv81 = this.rotateSpace;\n\tv48 = this.rotateSpace == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_004A;\n\tv52 = UnityEngine.Component::get_transform(this);\n\tv96 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0036;\n\tv197 = *([v110 @ X0_v17+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_0036;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v110, v51, v30, v31, v32, v33, v34, v35, v96, v37, v38, v39, v40, v41, v42, v43);\nL_0036:\n\t// 54 MakeStruct v57 @ AGGA05A88_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rotateVector (UnityEngine.Vector3), this.rotateVector.y (System.Single), this.rotateVector.z (System.Single)\n\tv68 = UnityEngine.Vector3::op_Multiply(v57, v96);\n\tUnityEngine.Transform::Rotate(v52, v68);\n\tv81 = this.rotateSpace;\nL_004A:\n\tv94 = v81 != 1;\n\tif (v94) goto L_0085;\n\tv99 = UnityEngine.Component::get_transform(this);\n\tv119 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0067;\n\tv215 = *([v211 @ X0_v6+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tif (v217) goto L_0067;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v211, v98, v30, v31, v32, v33, v34, v35, v119, v63, v61, v59, v40, v41, v42, v43);\nL_0067:\n\t// 103 MakeStruct v146 @ AGGA05B00_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rotateVector (UnityEngine.Vector3), this.rotateVector.y (System.Single), this.rotateVector.z (System.Single)\n\tv166 = UnityEngine.Vector3::op_Multiply(v146, v119);\n\tUnityEngine.Transform::Rotate(v99, v166, 0);\n\treturn;\nL_0085:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			spaceEnum spaceEnum2 = rotateSpace;
			if (rotateSpace == spaceEnum.Local)
			{
				Transform transform = base.transform;
				float deltaTime = Time.deltaTime;
				Vector3 vector = default(Vector3);
				vector.x = rotateVector.x;
				vector.y = rotateVector.y;
				vector.z = rotateVector.z;
				Vector3 eulers = vector * deltaTime;
				transform.Rotate(eulers);
				spaceEnum2 = rotateSpace;
			}
			if (spaceEnum2 == spaceEnum.World)
			{
				Transform transform2 = base.transform;
				float deltaTime2 = Time.deltaTime;
				Vector3 vector2 = default(Vector3);
				vector2.x = rotateVector.x;
				vector2.y = rotateVector.y;
				vector2.z = rotateVector.z;
				Vector3 eulers2 = vector2 * deltaTime2;
				transform2.Rotate(eulers2, default(Space));
			}
		}

		[Token(Token = "0x60002B9")]
		[Address(RVA = "0xA05B44", Offset = "0xA05B44", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECDCB0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C90]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Vector3::get_zero();\n\tthis.rotateVector = v53;\n\tthis.rotateVector.y = v53.y;\n\tthis.rotateVector.z = v53.z;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXRotation()
		{
			Vector3 vector = (rotateVector = Vector3.zero);
			rotateVector.y = vector.y;
			rotateVector.z = vector.z;
		}
	}
}
