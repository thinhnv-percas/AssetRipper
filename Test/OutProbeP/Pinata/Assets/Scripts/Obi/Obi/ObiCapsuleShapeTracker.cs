using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000020")]
	public class ObiCapsuleShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x60")]
		private int direction;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x64")]
		private float radius;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x68")]
		private float height;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x6C")]
		private Vector3 center;

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0xE3F3F4", Offset = "0xE3F3F4", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 0;\n\tv17 = Oni::CreateShape(2);\n\tthis.oniShape = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCapsuleShapeTracker(CapsuleCollider collider)
		{
			base.collider = collider;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Capsule);
			oniShape = intPtr;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0xE3F434", Offset = "0xE3F434", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 0;\n\tv17 = Oni::CreateShape(2);\n\tthis.oniShape = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiCapsuleShapeTracker(CharacterController collider)
		{
			base.collider = collider;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Capsule);
			oniShape = intPtr;
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0xE3F474", Offset = "0xE3F474", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EBBEF0]);\n\tv35 = *([v34 @ X8_v30]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2024707]) = v54;\nL_001C:\n\tv56 = this.collider == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0049;\n\tv110 = v110_asT == 0;\n\tif (v110) goto L_FFFFFFFF;\n\tgoto L_0049;\nL_0049:\n\tgoto L_0052;\n\tv136 = *([v132 @ X0_v2+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tgoto L_0052;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v132, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0052:\n\tv146 = UnityEngine.Object::op_Inequality(v127, 0);\n\tv148 = v146 == 0;\n\tif (v148) goto L_00AD;\n\tv213 = UnityEngine.CapsuleCollider::get_radius(v127);\n\tv310 = v213 != this.radius;\n\tif (v310) goto L_00C1;\n\tv333 = UnityEngine.CapsuleCollider::get_height(v127);\n\tv452 = this + 0x68;\n\tv439 = v333 != this.height;\n\tif (v439) goto L_00C4;\n\tv467 = UnityEngine.CapsuleCollider::get_direction(v127);\n\tv179 = v467 != this.direction;\n\tif (v179) goto L_00C4;\n\tv594 = UnityEngine.CapsuleCollider::get_center(v127);\n\tgoto L_00A6;\n\tv625 = *([v612 @ X0_v47+E0]);\n\tv626 = v625 == 0;\n\tv627 = ~v626;\n\tif (v627) goto L_00A6;\n\tv629 = \"il2cpp_codegen_runtime_class_init\"(v612, v186, v145, v39, v40, v41, v42, v43, v594, v608, v609, v47, v48, v49, v50, v51);\nL_00A6:\n\t// 166 MakeStruct v151 @ AGGE3F5DC_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.center (UnityEngine.Vector3), this.center.y (System.Single), this.center.z (System.Single)\n\tv204 = UnityEngine.Vector3::op_Inequality(v594, v151);\n\tv647 = v204 == 0;\n\tv206 = ~v647;\n\tif (v206) goto L_00C4;\nL_00AD:\n\tv210 = this.collider == 0;\n\tif (v210) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00FA;\nL_00C1:\n\tv452 = this + 0x68;\nL_00C4:\n\tv473 = UnityEngine.CapsuleCollider::get_radius(v127);\n\tthis.radius = v473;\n\tv479 = UnityEngine.CapsuleCollider::get_height(v127);\n\t*([v452 @ X22_v5]) = v479;\n\tv540 = UnityEngine.CapsuleCollider::get_direction(v127);\n\tthis.direction = v540;\n\tv572 = UnityEngine.CapsuleCollider::get_center(v127);\n\tthis.center = v572;\n\tthis.center.y = v572.y;\n\tthis.center.z = v572.z;\n\tv617 = this + 0x18;\n\tv620 = 0x103BB74(v617, this.direction, 0, v39, v40, v41, v42, v43, v572, v572.y, v572.z, this.radius, *([v452 @ X22_v5]), v442, v50, v51);\n\tOni::UpdateShape(this.oniShape, v617);\n\tgoto L_017B;\n\tv324 = v324_asT == 0;\n\tif (v324) goto L_FFFFFFFF;\n\tgoto L_00FA;\nL_00FA:\n\tgoto L_0103;\n\tv421 = *([v327 @ X0_v12+E0]);\n\tv422 = v421 == 0;\n\tv423 = ~v422;\n\tgoto L_0103;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v327, v185, v145, v39, v40, v41, v42, v43, v183, v181, v174, v160, v158, v156, v50, v51);\nL_0103:\n\tv263 = UnityEngine.Object::op_Inequality(v269, 0);\n\tv475 = v263 == 0;\n\tif (v475) goto L_FFFFFFFF;\n\tv543 = UnityEngine.CharacterController::get_radius(v269);\n\tv607 = v543 != this.radius;\n\tif (v607) goto L_0150;\n\tv623 = UnityEngine.CharacterController::get_height(v269);\n\tv635 = this + 0x68;\n\tv507 = v623 != this.height;\n\tif (v507) goto L_0153;\n\tv649 = UnityEngine.CharacterController::get_center(v269);\n\tgoto L_0148;\n\tv663 = *([v657 @ X0_v27+E0]);\n\tv664 = v663 == 0;\n\tv665 = ~v664;\n\tif (v665) goto L_0148;\n\tv667 = \"il2cpp_codegen_runtime_class_init\"(v657, v513, v231, v39, v40, v41, v42, v43, v649, v653, v654, v160, v158, v156, v50, v51);\nL_0148:\n\t// 328 MakeStruct v481 @ AGGE3F764_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.center (UnityEngine.Vector3), this.center.y (System.Single), this.center.z (System.Single)\n\tv531 = UnityEngine.Vector3::op_Inequality(v649, v481);\n\tv675 = v531 == 0;\n\tv533 = ~v675;\n\tif (v533) goto L_0153;\n\tgoto L_017B;\nL_0150:\n\tv635 = this + 0x68;\nL_0153:\n\tv645 = UnityEngine.CharacterController::get_radius(v269);\n\tthis.radius = v645;\n\tv652 = UnityEngine.CharacterController::get_height(v269);\n\t*([v635 @ X21_v6]) = v652;\n\tv571 = UnityEngine.CharacterController::get_center(v269);\n\tthis.center = v571;\n\tthis.center.y = v571.y;\n\tthis.center.z = v571.z;\n\tv547 = this + 0x18;\n\tv673 = 0x103BB74(v547, 1, 0, v39, v40, v41, v42, v43, v571, v571.y, v571.z, this.radius, *([v635 @ X21_v6]), v548, v50, v51);\n\tOni::UpdateShape(this.oniShape, v547);\nL_017B:\n\treturn v590;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 273 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_020d: Expected O, but got I
			//IL_04f0: Expected O, but got F4
			//IL_00cd: Expected O, but got I
			//IL_042c: Expected O, but got I
			//IL_0533: Expected O, but got F4
			//IL_0359: Expected O, but got I
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				CapsuleCollider capsuleCollider = collider as CapsuleCollider;
				obj = (((object)capsuleCollider == null) ? null : collider);
			}
			if (obj != null)
			{
				float num = ((CapsuleCollider)obj).radius;
				float num4 = default(float);
				object obj2;
				if (num == radius)
				{
					float num2 = ((CapsuleCollider)obj).height;
					obj2 = (long)(IntPtr)this + 104L;
					bool flag = num2 != height;
					float num3 = num4;
					if (!flag)
					{
						int num5 = ((CapsuleCollider)obj).direction;
						bool flag2 = num5 != direction;
						num3 = num4;
						if (!flag2)
						{
							Vector3 vector = ((CapsuleCollider)obj).center;
							Vector3 vector2 = default(Vector3);
							vector2.x = center.x;
							vector2.y = center.y;
							vector2.z = center.z;
							bool flag3 = vector != vector2;
							bool flag4 = !flag3;
							bool flag5 = !flag4;
							num4 = center.z;
							num3 = center.z;
							if (!flag5)
							{
								goto IL_01d3;
							}
						}
					}
				}
				else
				{
					obj2 = (long)(IntPtr)this + 104L;
					float num3 = num4;
				}
				float num6 = ((CapsuleCollider)obj).radius;
				radius = num6;
				float num7 = ((CapsuleCollider)obj).height;
				obj2 = num7;
				int num8 = ((CapsuleCollider)obj).direction;
				direction = num8;
				Vector3 vector3 = (center = ((CapsuleCollider)obj).center);
				center.y = vector3.y;
				center.z = vector3.z;
				ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103BB74 (inside Oni::GetProfilingInfo +0xD64)");
				Oni.UpdateShape(OniShape, ref reference);
				return true;
			}
			goto IL_01d3;
			IL_01d3:
			UnityEngine.Object obj3;
			if ((object)collider == null)
			{
				obj3 = null;
			}
			else
			{
				CharacterController characterController = collider as CharacterController;
				obj3 = (((object)characterController == null) ? null : collider);
			}
			if (obj3 != null)
			{
				float num9 = ((CharacterController)obj3).radius;
				object obj4;
				if (num9 == radius)
				{
					float num10 = ((CharacterController)obj3).height;
					obj4 = (long)(IntPtr)this + 104L;
					if (num10 == height)
					{
						Vector3 vector4 = ((CharacterController)obj3).center;
						Vector3 vector5 = default(Vector3);
						vector5.x = center.x;
						vector5.y = center.y;
						vector5.z = center.z;
						bool flag6 = vector4 != vector5;
						bool flag7 = !flag6;
						bool flag8 = !flag7;
						float num4 = center.z;
						if (!flag8)
						{
							goto IL_0412;
						}
					}
				}
				else
				{
					obj4 = (long)(IntPtr)this + 104L;
				}
				float num11 = ((CharacterController)obj3).radius;
				radius = num11;
				float num12 = ((CharacterController)obj3).height;
				obj4 = num12;
				Vector3 vector6 = (center = ((CharacterController)obj3).center);
				center.y = vector6.y;
				center.z = vector6.z;
				ref Oni.Shape reference2 = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103BB74 (inside Oni::GetProfilingInfo +0xD64)");
				Oni.UpdateShape(OniShape, ref reference2);
				return true;
			}
			goto IL_0412;
			IL_0412:
			return false;
		}
	}
}
