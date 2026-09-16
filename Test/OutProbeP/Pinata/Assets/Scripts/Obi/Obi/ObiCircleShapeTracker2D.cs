using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200001D")]
	public class ObiCircleShapeTracker2D : ObiShapeTracker
	{
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x60")]
		private float radius;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x64")]
		private Vector2 center;

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0xE40584", Offset = "0xE40584", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 1;\n\tv18 = Oni::CreateShape(0);\n\tthis.oniShape = v18;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCircleShapeTracker2D(CircleCollider2D collider)
		{
			base.collider = collider;
			adaptor.is2D = true;
			IntPtr intPtr = Oni.CreateShape(default(Oni.ShapeType));
			oniShape = intPtr;
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0xE405C8", Offset = "0xE405C8", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF2F58]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2024710]) = v46;\nL_0017:\n\tv47 = this.collider;\n\tv48 = this.collider == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv62 = *([v47 @ X8_v3 (UnityEngine.Component)]) != UnityEngine.CircleCollider2D;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tgoto L_003E;\n\tv96 = *([v92 @ X0_v2+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_003E;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003E:\n\tv106 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv108 = v106 == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tv162 = UnityEngine.CircleCollider2D::get_radius(v88);\n\tv130 = v162 != this.radius;\n\tif (v130) goto L_0074;\n\tv249 = UnityEngine.Collider2D::get_offset(v88);\n\tgoto L_006D;\n\tv273 = *([v266 @ X0_v24+E0]);\n\tv274 = v273 == 0;\n\tv275 = ~v274;\n\tif (v275) goto L_006D;\n\tv277 = \"il2cpp_codegen_runtime_class_init\"(v266, v136, v105, v31, v32, v33, v34, v35, v249, v263, v38, v39, v40, v41, v42, v43);\nL_006D:\n\t// 109 MakeStruct v112 @ AGGE406C8_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.center (UnityEngine.Vector2), this.center.y (System.Single)\n\tv154 = UnityEngine.Vector2::op_Inequality(v249, v112);\n\tv156 = v154 == 0;\n\tif (v156) goto L_FFFFFFFF;\nL_0074:\n\tv262 = UnityEngine.CircleCollider2D::get_radius(v88);\n\tthis.radius = v262;\n\tv272 = UnityEngine.Collider2D::get_offset(v88);\n\tthis.center = v272;\n\tthis.center.y = v272.y;\n\tv208 = this + 0x18;\n\tgoto L_008F;\n\tv288 = *([v283 @ X0_v15+E0]);\n\tv289 = v288 == 0;\n\tv290 = ~v289;\n\tif (v290) goto L_008F;\n\tv292 = \"il2cpp_codegen_runtime_class_init\"(v283, v271, v105, v31, v32, v33, v34, v35, v272, v280, v251, v250, v40, v41, v42, v43);\nL_008F:\n\tv188 = UnityEngine.Vector2::op_Implicit(v272);\n\tv298 = 0x102D698(v208, 0, 0, v31, v32, v33, v34, v35, v188, v188.y, v188.z, this.radius, v40, v41, v42, v43);\n\tOni::UpdateShape(this.oniShape, v208);\n\tgoto L_00A6;\nL_00A6:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			Component component = collider;
			UnityEngine.Object obj;
			if ((object)collider != null)
			{
				Component component2 = (((object)component.GetType() != typeof(CircleCollider2D)) ? null : collider);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				float num = ((CircleCollider2D)obj).radius;
				if (num == radius)
				{
					Vector2 offset = ((Collider2D)obj).offset;
					Vector2 vector = default(Vector2);
					vector.x = center.x;
					vector.y = center.y;
					if (!(offset != vector))
					{
						goto IL_01ab;
					}
				}
				float num2 = ((CircleCollider2D)obj).radius;
				radius = num2;
				Vector2 vector2 = (center = ((Collider2D)obj).offset);
				center.y = vector2.y;
				ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				Vector3 vector3 = vector2;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @102D698 (inside Obi.ObiSphereShapeTracker::UpdateIfNeeded +0x1A4)");
				Oni.UpdateShape(OniShape, ref reference);
				return true;
			}
			goto IL_01ab;
			IL_01ab:
			return false;
		}
	}
}
