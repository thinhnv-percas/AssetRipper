using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200001F")]
	public class ObiBoxShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x60")]
		private Vector3 size;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x6C")]
		private Vector3 center;

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xE3EF64", Offset = "0xE3EF64", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 0;\n\tv17 = Oni::CreateShape(1);\n\tthis.oniShape = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiBoxShapeTracker(BoxCollider collider)
		{
			base.collider = collider;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Box);
			oniShape = intPtr;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0xE3EFA4", Offset = "0xE3EFA4", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1EC2358]);\n\tv33 = *([v32 @ X8_v20]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2024705]) = v52;\nL_001B:\n\tv54 = this.collider == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0048;\n\tv108 = v108_asT == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_0048;\nL_0048:\n\tgoto L_0051;\n\tv134 = *([v130 @ X0_v2+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tgoto L_0051;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v130, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0051:\n\tv144 = UnityEngine.Object::op_Inequality(v125, 0);\n\tv146 = v144 == 0;\n\tif (v146) goto L_FFFFFFFF;\n\tv197 = UnityEngine.BoxCollider::get_size(v125);\n\tgoto L_0076;\n\tv293 = *([v261 @ X0_v12+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0076;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v261, v196, v143, v37, v38, v39, v40, v41, v197, v254, v255, v45, v46, v47, v48, v49);\nL_0076:\n\t// 118 MakeStruct v156 @ AGGE3F0C0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.size (UnityEngine.Vector3), this.size.y (System.Single), this.size.z (System.Single)\n\tv307 = UnityEngine.Vector3::op_Inequality(v197, v156);\n\tv309 = v307 == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_00A0;\n\tv312 = UnityEngine.BoxCollider::get_center(v125);\n\tgoto L_0099;\n\tv334 = *([v326 @ X0_v24+E0]);\n\tv335 = v334 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_0099;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v326, v187, v143, v37, v38, v39, v40, v41, v312, v324, v325, v303, v304, v305, v48, v49);\nL_0099:\n\t// 153 MakeStruct v150 @ AGGE3F11C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.center (UnityEngine.Vector3), this.center.y (System.Single), this.center.z (System.Single)\n\tv189 = UnityEngine.Vector3::op_Inequality(v312, v150);\n\tv191 = v189 == 0;\n\tif (v191) goto L_FFFFFFFF;\nL_00A0:\n\tv323 = UnityEngine.BoxCollider::get_size(v125);\n\tthis.size = v323;\n\tthis.size.y = v323.y;\n\tthis.size.z = v323.z;\n\tv230 = UnityEngine.BoxCollider::get_center(v125);\n\tv242 = this + 0x18;\n\tthis.center = v230;\n\tthis.center.y = v230.y;\n\tthis.center.z = v230.z;\n\tv343 = 0x103BB64(v242, 0, 0, v37, v38, v39, v40, v41, v230, v230.y, v230.z, this.size, this.size.y, this.size.z, v48, v49);\n\tOni::UpdateShape(this.oniShape, v242);\n\tgoto L_00C8;\nL_00C8:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				BoxCollider boxCollider = collider as BoxCollider;
				obj = (((object)boxCollider == null) ? null : collider);
			}
			if (obj != null)
			{
				Vector3 vector = ((BoxCollider)obj).size;
				Vector3 vector2 = default(Vector3);
				vector2.x = size.x;
				vector2.y = size.y;
				vector2.z = size.z;
				if (!(vector != vector2))
				{
					Vector3 vector3 = ((BoxCollider)obj).center;
					Vector3 vector4 = default(Vector3);
					vector4.x = center.x;
					vector4.y = center.y;
					vector4.z = center.z;
					if (!(vector3 != vector4))
					{
						goto IL_0247;
					}
				}
				Vector3 vector5 = (size = ((BoxCollider)obj).size);
				size.y = vector5.y;
				size.z = vector5.z;
				Vector3 vector6 = ((BoxCollider)obj).center;
				ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				center = vector6;
				center.y = vector6.y;
				center.z = vector6.z;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103BB64 (inside Oni::GetProfilingInfo +0xD54)");
				Oni.UpdateShape(OniShape, ref reference);
				return true;
			}
			goto IL_0247;
			IL_0247:
			return false;
		}
	}
}
