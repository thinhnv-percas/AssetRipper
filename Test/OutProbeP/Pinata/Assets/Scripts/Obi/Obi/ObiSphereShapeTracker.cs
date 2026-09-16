using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000024")]
	public class ObiSphereShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x60")]
		private float radius;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x64")]
		private Vector3 center;

		[Token(Token = "0x6000202")]
		[Address(RVA = "0x102D424", Offset = "0x102D424", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 0;\n\tv15 = Oni::CreateShape(0);\n\tthis.oniShape = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiSphereShapeTracker(SphereCollider collider)
		{
			base.collider = collider;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(default(Oni.ShapeType));
			oniShape = intPtr;
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0x102D4F4", Offset = "0x102D4F4", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1ED8ED8]);\n\tv31 = *([v30 @ X8_v29]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2026259]) = v50;\nL_001A:\n\tv52 = this.collider == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0047;\n\tv106 = v106_asT == 0;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tgoto L_0050;\n\tv132 = *([v128 @ X0_v2+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tgoto L_0050;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v128, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0050:\n\tv142 = UnityEngine.Object::op_Inequality(v123, 0);\n\tv144 = v142 == 0;\n\tif (v144) goto L_FFFFFFFF;\n\tv145 = v123 == 0;\n\tif (v145) goto L_00AC;\n\tv206 = UnityEngine.SphereCollider::get_radius(v123);\n\tv174 = v206 != this.radius;\n\tif (v174) goto L_008B;\n\tv354 = UnityEngine.SphereCollider::get_center(v123);\n\tgoto L_0084;\n\tv394 = *([v381 @ X0_v28+E0]);\n\tv395 = v394 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_0084;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v381, v180, v141, v35, v36, v37, v38, v39, v354, v377, v378, v43, v44, v45, v46, v47);\nL_0084:\n\t// 132 MakeStruct v148 @ AGG102D624_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.center (UnityEngine.Vector3), this.center.y (System.Single), this.center.z (System.Single)\n\tv198 = UnityEngine.Vector3::op_Inequality(v354, v148);\n\tv200 = v198 == 0;\n\tif (v200) goto L_FFFFFFFF;\nL_008B:\n\tv363 = UnityEngine.SphereCollider::get_radius(v123);\n\tthis.radius = v363;\n\tv237 = UnityEngine.SphereCollider::get_center(v123);\n\tv255 = this + 0x18;\n\tthis.center = v237;\n\tthis.center.y = v237.y;\n\tthis.center.z = v237.z;\n\tv402 = 0x102D698(v255, 0, 0, v35, v36, v37, v38, v39, v237, v237.y, v237.z, this.radius, this.center.y, this.center.z, v46, v47);\n\tOni::UpdateShape(this.oniShape, v255);\n\tgoto L_00AA;\nL_00AA:\n\treturn returnVal1;\nL_00AC:\n\tv208 = new System.NullReferenceException();\n\tgoto L_00C8;\n\tv365 = *([1EB40D8]);\n\tv366 = *([v365 @ X8_v18]);\n\tv367 = \"il2cpp_codegen_initialize_method\"(v366, v140, v141, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv370 = 0 | 1;\n\t*([20267CC]) = v370;\nL_00C8:\n\t*([v208 @ X0_v10 (System.NullReferenceException)]) = v40;\n\t*([v208 @ X0_v10 (System.NullReferenceException)+4]) = v41;\n\t*([v208 @ X0_v10 (System.NullReferenceException)+8]) = v42;\n\tgoto L_00D8;\n\tv387 = *([v373 @ X0_v12+E0]);\n\tv388 = v387 == 0;\n\tv389 = ~v388;\n\tgoto L_00D8;\n\tv391 = \"il2cpp_codegen_runtime_class_init\"(v373, v140, v141, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00D8:\n\tv393 = UnityEngine.Vector3::get_one();\n\tv331 = UnityEngine.Vector3::op_Multiply(v393, v43);\n\t*([v208 @ X0_v10 (System.NullReferenceException)+C]) = v331;\n\tv208._className = v331.y;\n\t*([v208 @ X0_v10 (System.NullReferenceException)+14]) = v331.z;\n\treturn 0;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_0237: Expected O, but got F4
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				SphereCollider sphereCollider = collider as SphereCollider;
				obj = (((object)sphereCollider == null) ? null : collider);
			}
			if (obj != null)
			{
				if ((object)obj != null)
				{
					float num = ((SphereCollider)obj).radius;
					if (num == radius)
					{
						Vector3 vector = ((SphereCollider)obj).center;
						Vector3 vector2 = default(Vector3);
						vector2.x = center.x;
						vector2.y = center.y;
						vector2.z = center.z;
						if (!(vector != vector2))
						{
							goto IL_01e5;
						}
					}
					float num2 = ((SphereCollider)obj).radius;
					radius = num2;
					Vector3 vector3 = ((SphereCollider)obj).center;
					ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
					center = vector3;
					center.y = vector3.y;
					center.z = vector3.z;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @102D698 (inside Obi.ObiSphereShapeTracker::UpdateIfNeeded +0x1A4)");
					Oni.UpdateShape(OniShape, ref reference);
					return true;
				}
				NullReferenceException ex = new NullReferenceException();
				object obj2 = default(object);
				ex = (NullReferenceException)obj2;
				Vector3 one = Vector3.one;
				float num3 = default(float);
				Vector3 vector4 = one * num3;
				((Exception)ex)._className = (string)vector4.y;
				_ = vector4.z;
				return false;
			}
			goto IL_01e5;
			IL_01e5:
			return false;
		}
	}
}
