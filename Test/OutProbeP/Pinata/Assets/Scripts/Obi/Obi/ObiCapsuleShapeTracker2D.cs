using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200001C")]
	public class ObiCapsuleShapeTracker2D : ObiShapeTracker
	{
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x60")]
		private CapsuleDirection2D direction;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x64")]
		private Vector2 size;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x6C")]
		private Vector2 center;

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0xE3F804", Offset = "0xE3F804", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 1;\n\tv18 = Oni::CreateShape(2);\n\tthis.oniShape = v18;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCapsuleShapeTracker2D(CapsuleCollider2D collider)
		{
			base.collider = collider;
			adaptor.is2D = true;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Capsule);
			oniShape = intPtr;
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0xE3F848", Offset = "0xE3F848", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1F00018]);\n\tv37 = *([v36 @ X8_v30]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2024708]) = v56;\nL_001C:\n\tv57 = this.collider;\n\tv58 = this.collider == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv72 = *([v57 @ X8_v3 (UnityEngine.Component)]) != UnityEngine.CapsuleCollider2D;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003A;\nL_003A:\n\tgoto L_0043;\n\tv106 = *([v102 @ X0_v2+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tgoto L_0043;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v102, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0043:\n\tv116 = UnityEngine.Object::op_Inequality(v98, 0);\n\tv118 = v116 == 0;\n\tif (v118) goto L_FFFFFFFF;\n\tv184 = UnityEngine.CapsuleCollider2D::get_size(v98);\n\tv150 = this + 0x68;\n\tgoto L_0065;\n\tv321 = *([v275 @ X0_v12+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tif (v323) goto L_0065;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v275, v183, v115, v41, v42, v43, v44, v45, v184, v270, v48, v49, v50, v51, v52, v53);\nL_0065:\n\t// 101 MakeStruct v133 @ AGGE3F944_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.size (UnityEngine.Vector2), this.size.y (System.Single)\n\tv333 = UnityEngine.Vector2::op_Inequality(v184, v133);\n\tv335 = v333 == 0;\n\tif (v335) goto L_006E;\n\tv203 = this + 0x60;\n\tgoto L_009C;\nL_006E:\n\tv339 = UnityEngine.CapsuleCollider2D::get_direction(v98);\n\tv203 = this + 0x60;\n\tv128 = v339 != this.direction;\n\tif (v128) goto L_009C;\n\tv372 = UnityEngine.Collider2D::get_offset(v98);\n\tgoto L_0095;\n\tv388 = *([v377 @ X0_v40+E0]);\n\tv389 = v388 == 0;\n\tv390 = ~v389;\n\tif (v390) goto L_0095;\n\tv392 = \"il2cpp_codegen_runtime_class_init\"(v377, v158, v115, v41, v42, v43, v44, v45, v372, v376, v330, v331, v50, v51, v52, v53);\nL_0095:\n\t// 149 MakeStruct v122 @ AGGE3F9B4_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.center (UnityEngine.Vector2), this.center.y (System.Single)\n\tv176 = UnityEngine.Vector2::op_Inequality(v372, v122);\n\tv178 = v176 == 0;\n\tif (v178) goto L_FFFFFFFF;\nL_009C:\n\tv364 = UnityEngine.CapsuleCollider2D::get_size(v98);\n\tthis.size = v364;\n\tthis.size.y = v364.y;\n\tv370 = UnityEngine.CapsuleCollider2D::get_direction(v98);\n\t*([v203 @ X23_v4]) = v370;\n\tv375 = UnityEngine.Collider2D::get_offset(v98);\n\tthis.center = v375;\n\tthis.center.y = v375.y;\n\tv220 = this + 0x18;\n\tgoto L_00BB;\n\tv395 = *([v384 @ X0_v21+E0]);\n\tv396 = v395 == 0;\n\tv397 = ~v396;\n\tif (v397) goto L_00BB;\n\tv399 = \"il2cpp_codegen_runtime_class_init\"(v384, v374, v115, v41, v42, v43, v44, v45, v375, v381, v342, v341, v50, v51, v52, v53);\nL_00BB:\n\tv405 = UnityEngine.Vector2::op_Implicit(v375);\n\tv411 = UnityEngine.CapsuleCollider2D::get_direction(v98);\n\tv250 = this + 0x64;\n\tv230 = v411 != 1;\n\tif (v230) goto L_FFFFFFFF;\n\tgoto L_00DF;\nL_00DF:\n\tgoto L_00E8;\n\tv432 = *([v417 @ X0_v26+E0]);\n\tv433 = v432 == 0;\n\tv434 = ~v433;\n\tgoto L_00E8;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v417, v410, v115, v41, v42, v43, v44, v45, v405, v407, v408, v341, v50, v51, v52, v53);\nL_00E8:\n\tv440 = UnityEngine.Mathf::Max(this.size, this.size.y);\n\tv443 = UnityEngine.CapsuleCollider2D::get_direction(v98);\n\tv244 = v443 - 1;\n\tv240 = v244 == 0;\n\tv207 = *([v429 @ X8_v16]) * 0.5f;\n\tv201 = ~v240;\n\tv449 = 0x103BB74(v220, v201, 0, v41, v42, v43, v44, v45, v405, v405.y, v405.z, v207, v440, v51, v52, v53);\n\tOni::UpdateShape(this.oniShape, v220);\n\tgoto L_0116;\nL_0116:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_0096: Expected O, but got I
			//IL_011b: Expected O, but got I
			//IL_00fd: Expected O, but got I
			//IL_01e9: Expected O, but got I4
			//IL_0250: Expected O, but got I
			Component component = collider;
			UnityEngine.Object obj;
			if ((object)collider != null)
			{
				Component component2 = (((object)component.GetType() != typeof(CapsuleCollider2D)) ? null : collider);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				Vector2 vector = ((CapsuleCollider2D)obj).size;
				object obj2 = (long)(IntPtr)this + 104L;
				Vector2 vector2 = default(Vector2);
				vector2.x = size.x;
				vector2.y = size.y;
				object obj3;
				if (vector != vector2)
				{
					obj3 = (long)(IntPtr)this + 96L;
				}
				else
				{
					CapsuleDirection2D capsuleDirection2D = ((CapsuleCollider2D)obj).direction;
					obj3 = (long)(IntPtr)this + 96L;
					if (capsuleDirection2D == direction)
					{
						Vector2 offset = ((Collider2D)obj).offset;
						Vector2 vector3 = default(Vector2);
						vector3.x = center.x;
						vector3.y = center.y;
						if (!(offset != vector3))
						{
							goto IL_0324;
						}
					}
				}
				Vector2 vector4 = (size = ((CapsuleCollider2D)obj).size);
				size.y = vector4.y;
				CapsuleDirection2D capsuleDirection2D2 = ((CapsuleCollider2D)obj).direction;
				obj3 = capsuleDirection2D2;
				Vector2 vector5 = (center = ((Collider2D)obj).offset);
				center.y = vector5.y;
				ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				Vector3 vector6 = vector5;
				CapsuleDirection2D capsuleDirection2D3 = ((CapsuleCollider2D)obj).direction;
				object obj4 = (long)(IntPtr)this + 100L;
				object obj5 = ((capsuleDirection2D3 != CapsuleDirection2D.Horizontal) ? obj4 : obj2);
				float num = Mathf.Max(size.x, size.y);
				CapsuleDirection2D capsuleDirection2D4 = ((CapsuleCollider2D)obj).direction;
				int num2 = (int)(capsuleDirection2D4 - 1);
				bool flag = num2 == 0;
				float num3 = (float)obj5 * 0.5f;
				bool flag2 = !flag;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103BB74 (inside Oni::GetProfilingInfo +0xD64)");
				Oni.UpdateShape(OniShape, ref reference);
				return true;
			}
			goto IL_0324;
			IL_0324:
			return false;
		}
	}
}
