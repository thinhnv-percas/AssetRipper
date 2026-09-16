using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteAlways]
	[Token(Token = "0x2000062")]
	public class SkeletonUtilityGroundConstraint : SkeletonUtilityConstraint
	{
		[Tooltip("LayerMask for what objects to raycast against")]
		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x30")]
		public LayerMask groundMask;

		[Tooltip("Use 2D")]
		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x34")]
		public bool use2D;

		[Tooltip("Uses SphereCast for 3D mode and CircleCast for 2D mode")]
		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x35")]
		public bool useRadius;

		[Tooltip("The Radius")]
		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x38")]
		public float castRadius;

		[Tooltip("How high above the target bone to begin casting from")]
		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x3C")]
		public float castDistance;

		[Tooltip("X-Axis adjustment")]
		[Token(Token = "0x4000221")]
		[FieldOffset(Offset = "0x40")]
		public float castOffset;

		[Tooltip("Y-Axis adjustment")]
		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x44")]
		public float groundOffset;

		[Tooltip("How fast the target IK position adjusts to the ground. Use smaller values to prevent snapping")]
		[Token(Token = "0x4000223")]
		[FieldOffset(Offset = "0x48")]
		public float adjustSpeed;

		[Token(Token = "0x4000224")]
		[FieldOffset(Offset = "0x4C")]
		private Vector3 rayOrigin;

		[Token(Token = "0x4000225")]
		[FieldOffset(Offset = "0x58")]
		private Vector3 rayDir;

		[Token(Token = "0x4000226")]
		[FieldOffset(Offset = "0x64")]
		private float hitY;

		[Token(Token = "0x4000227")]
		[FieldOffset(Offset = "0x68")]
		private float lastHitY;

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x151D5D0", Offset = "0x151D5D0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtilityConstraint::OnEnable(this);\n\tv9 = UnityEngine.Component::get_transform(this);\n\tv12 = UnityEngine.Transform::get_position(v9);\n\tthis.lastHitY = v12.y;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnEnable()
		{
			base.OnEnable();
			Transform transform = base.transform;
			lastHitY = transform.position.y;
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0x151D608", Offset = "0x151D608", Length = "0x4CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv32 = UnityEngine.Application;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv64 = UnityEngine.Object;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv68 = UnityEngine.Physics2D;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv336 = UnityEngine.Physics;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v336, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37AA2]) = v52;\nL_0029:\n\tv60 = 0;\n\tv62 = UnityEngine.Component::get_transform(this);\n\tv71 = UnityEngine.Transform::get_position(v62);\n\tv322 = this.hierarchy;\n\tv285 = v71 + this.castOffset;\n\tv276 = v71.y + this.castDistance;\n\tthis.rayOrigin = v285;\n\tthis.rayOrigin.y = v276;\n\tthis.rayOrigin.z = v71.z;\n\tv342 = UnityEngine.Time::get_deltaTime();\n\tv416 = v322.positionScale * this.adjustSpeed;\n\tv702 = v416 * v342;\n\tthis.hitY = -3.4028235E+38f;\n\tv421 = ~this.use2D;\n\tif (v421) goto L_007A;\n\tv424 = ~this.useRadius;\n\tif (v424) goto L_00AA;\n\tv435 = UnityEngine.LayerMask::op_Implicit(this.groundMask);\n\tgoto L_0062;\n\tv489 = v464;\n\tv490 = \"il2cpp_codegen_runtime_class_init\"(v489, v434, v35, v36, v37, v38, v39, v40, v342, v416, v268, v260, v264, v256, v47, v48);\nL_0062:\n\tv492 = this.castDistance + this.groundOffset;\n\t// 107 MakeStruct v501 @ AGG1521754_0_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.rayOrigin (UnityEngine.Vector3), this.rayOrigin.y (System.Single)\n\t// 108 MakeStruct v502 @ AGG1521754_2_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.rayDir (UnityEngine.Vector3), this.rayDir.y (System.Single)\n\tv503 = UnityEngine.Physics2D::CircleCast(v501, this.castRadius, v502, v492, v435);\n\tv551 = v503.m_Centroid;\n\tgoto L_00D1;\nL_007A:\n\tv427 = ~this.useRadius;\n\tif (v427) goto L_00ED;\n\tv452 = UnityEngine.LayerMask::op_Implicit(this.groundMask);\n\tgoto L_0091;\n\tv518 = v478;\n\tv519 = \"il2cpp_codegen_runtime_class_init\"(v518, v451, v35, v36, v37, v38, v39, v40, v425, v416, v268, v260, v264, v256, v47, v48);\nL_0091:\n\tv522 = this.castDistance + this.groundOffset;\n\t// 155 MakeStruct v532 @ AGG15217D4_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rayOrigin (UnityEngine.Vector3), this.rayOrigin.y (System.Single), this.rayOrigin.z (System.Single)\n\t// 156 MakeStruct v533 @ AGG15217D4_2_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rayDir (UnityEngine.Vector3), this.rayDir.y (System.Single), this.rayDir.z (System.Single)\n\tv534 = UnityEngine.Physics::SphereCast(v532, this.castRadius, v533, &v60 @ stack_-C0_v1 (UnityEngine.RaycastHit), v522, v452);\n\tv571 = v534 == 0;\n\tv572 = ~v571;\n\tif (v572) goto L_010A;\n\tgoto L_0143;\nL_00AA:\n\tv442 = UnityEngine.LayerMask::op_Implicit(this.groundMask);\n\tgoto L_00B5;\n\tv504 = v471;\n\tv505 = \"il2cpp_codegen_runtime_class_init\"(v504, v441, v35, v36, v37, v38, v39, v40, v342, v416, v268, v260, v264, v256, v47, v48);\nL_00B5:\n\tv706 = this.castDistance + this.groundOffset;\n\t// 189 MakeStruct v515 @ AGG152183C_0_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.rayOrigin (UnityEngine.Vector3), this.rayOrigin.y (System.Single)\n\t// 190 MakeStruct v516 @ AGG152183C_1_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.rayDir (UnityEngine.Vector3), this.rayDir.y (System.Single)\n\tv517 = UnityEngine.Physics2D::Raycast(v515, v516, v706, v442);\n\tv551 = v517.m_Centroid;\nL_00D1:\n\tv613 = UnityEngine.RaycastHit2D::get_collider(&v551 @ stack_-E8_v8 (UnityEngine.Vector2));\n\tgoto L_00DD;\n\tv667 = v652;\n\tv668 = \"il2cpp_codegen_runtime_class_init\"(v667, v610, v35, v36, v37, v38, v39, v40, v605, v606, v597, v595, v596, v594, v47, v48);\nL_00DD:\n\tv648 = UnityEngine.Object::op_Inequality(v613, 0);\n\tv650 = v648 == 0;\n\tif (v650) goto L_0143;\n\tv711 = UnityEngine.RaycastHit2D::get_point(&v551 @ stack_-E8_v8 (UnityEngine.Vector2));\n\tv708 = v711.y;\n\tgoto L_010F;\nL_00ED:\n\tv460 = UnityEngine.LayerMask::op_Implicit(this.groundMask);\n\tgoto L_00F9;\n\tv535 = v485;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v535, v459, v35, v36, v37, v38, v39, v40, v425, v416, v268, v260, v264, v256, v47, v48);\nL_00F9:\n\tv539 = this.castDistance + this.groundOffset;\n\t// 258 MakeStruct v548 @ AGG1521900_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rayOrigin (UnityEngine.Vector3), this.rayOrigin.y (System.Single), this.rayOrigin.z (System.Single)\n\t// 259 MakeStruct v549 @ AGG1521900_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rayDir (UnityEngine.Vector3), this.rayDir.y (System.Single), this.rayDir.z (System.Single)\n\tv550 = UnityEngine.Physics::Raycast(v548, v549, &v60 @ stack_-C0_v1 (UnityEngine.RaycastHit), v539, v460);\n\tv574 = v550 == 0;\n\tif (v574) goto L_0143;\nL_010A:\n\tv642 = UnityEngine.RaycastHit::get_point(&v60 @ stack_-C0_v1 (UnityEngine.RaycastHit));\n\tv708 = v642.y;\nL_010F:\n\tv721 = v708 + this.groundOffset;\n\tthis.hitY = v721;\n\tgoto L_0119;\n\tv730 = \"il2cpp_codegen_runtime_class_init\"(v723, v712, v680, v36, v37, v38, v39, v40, v721, v708, v707, v705, v706, v704, v681, v682);\nL_0119:\n\tv733 = UnityEngine.Application::get_isPlaying();\n\tv791 = v733 == 0;\n\tif (v791) goto L_017C;\n\tv783 = this.hitY;\n\tv835 = -v702;\n\tv799 = this.hitY - this.lastHitY;\n\t// 298 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv810 = v799 < 0;\n\tif (v810) goto L_0132;\n\tgoto L_0132;\nL_0132:\n\tv784 = this.lastHitY + v835;\n\tv837 = v706 < v702;\n\tv747 = ~v837;\n\tv839 = v706 - v702;\n\tv744 = v839 == 0;\n\tgoto L_0171;\nL_0143:\n\tgoto L_0146;\n\tv663 = \"il2cpp_codegen_runtime_class_init\"(v656, v645, v158, v36, v37, v38, v39, v40, v286, v277, v269, v261, v265, v257, v161, v164);\nL_0146:\n\tv666 = UnityEngine.Application::get_isPlaying();\n\tv728 = v666 == 0;\n\tif (v728) goto L_017C;\n\tv303 = UnityEngine.Component::get_transform(this);\n\tv812 = UnityEngine.Transform::get_position(v303);\n\tv783 = v812.y;\n\tv819 = v812.y - this.lastHitY;\n\tv820 = -v242;\n\t// 351 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv831 = v819 < 0;\n\tif (v831) goto L_FFFFFFFF;\n\tgoto L_0167;\nL_0167:\n\tv784 = this.lastHitY + v863;\n\tv864 = v812.z < v242;\n\tv747 = ~v864;\n\tv858 = v812.z - v242;\n\tv744 = v858 == 0;\nL_0171:\n\tv862 = ~v744;\n\tv739 = v747 & v862;\n\tv738 = ~v739;\n\tif (v738) goto L_FFFFFFFF;\n\tgoto L_0179;\nL_0179:\n\tthis.hitY = v784;\nL_017C:\n\tv304 = UnityEngine.Component::get_transform(this);\n\tv814 = UnityEngine.Transform::get_position(v304);\n\tv87 = this.lastHitY >= this.hitY;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0199;\nL_0199:\n\tv305 = UnityEngine.Component::get_transform(this);\n\tv869 = UnityEngine.Mathf::Min(v814.y, 3.4028235E+38f);\n\tv127 = v814.y - v230;\n\tv122 = v127 < 0;\n\tv92 = ~v122;\n\tv88 = ~v92;\n\tif (v88) goto L_FFFFFFFF;\n\tgoto L_01B2;\nL_01B2:\n\t// 434 MakeStruct v74 @ AGG1521A2C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v814 @ V0_v11 (UnityEngine.Vector3), v280 @ V1_v9 (System.Single), v814.z (System.Single)\n\tUnityEngine.Transform::set_position(v305, v74);\n\tv325 = this.bone;\n\tv332 = v325.bone;\n\tv306 = UnityEngine.Component::get_transform(this);\n\tv290 = UnityEngine.Transform::get_localPosition(v306);\n\tv326 = this.hierarchy;\n\tv291 = v290 / v326.positionScale;\n\tv332.x = v291;\n\tv327 = this.bone;\n\tv333 = v327.bone;\n\tv307 = UnityEngine.Component::get_transform(this);\n\tv292 = UnityEngine.Transform::get_localPosition(v307);\n\tv328 = this.hierarchy;\n\tv876 = v292.y / v328.positionScale;\n\tv333.y = v876;\n\tthis.lastHitY = this.hitY;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 335 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void DoUpdate()
		{
			//IL_0052: Expected O, but got F4
			RaycastHit hitInfo = default(RaycastHit);
			Transform transform = base.transform;
			Vector3 position = transform.position;
			SkeletonUtility skeletonUtility = hierarchy;
			float num = position.x + castOffset;
			float y = position.y + castDistance;
			rayOrigin = (Vector3)num;
			rayOrigin.y = y;
			rayOrigin.z = position.z;
			float deltaTime = Time.deltaTime;
			float num2 = skeletonUtility.PositionScale * adjustSpeed;
			float num3 = num2 * deltaTime;
			hitY = float.MinValue;
			float num4;
			float num5;
			float y2;
			if (use2D)
			{
				Vector2 centroid;
				if (useRadius)
				{
					int layerMask = groundMask;
					float distance = castDistance + groundOffset;
					Vector2 origin = default(Vector2);
					origin.x = rayOrigin.x;
					origin.y = rayOrigin.y;
					Vector2 direction = default(Vector2);
					direction.x = rayDir.x;
					direction.y = rayDir.y;
					centroid = Physics2D.CircleCast(origin, castRadius, direction, distance, layerMask).m_Centroid;
					num4 = rayDir.y;
				}
				else
				{
					int layerMask2 = groundMask;
					num4 = castDistance + groundOffset;
					Vector2 origin2 = default(Vector2);
					origin2.x = rayOrigin.x;
					origin2.y = rayOrigin.y;
					Vector2 direction2 = default(Vector2);
					direction2.x = rayDir.x;
					direction2.y = rayDir.y;
					centroid = Physics2D.Raycast(origin2, direction2, num4, layerMask2).m_Centroid;
				}
				Collider2D collider = ((RaycastHit2D*)(&centroid))->collider;
				bool flag = collider != null;
				bool flag2 = !flag;
				num5 = num3;
				if (!flag2)
				{
					y2 = ((RaycastHit2D*)(&centroid))->point.y;
					goto IL_07db;
				}
			}
			else if (useRadius)
			{
				int layerMask3 = groundMask;
				float maxDistance = castDistance + groundOffset;
				Vector3 origin3 = default(Vector3);
				origin3.x = rayOrigin.x;
				origin3.y = rayOrigin.y;
				origin3.z = rayOrigin.z;
				Vector3 direction3 = default(Vector3);
				direction3.x = rayDir.x;
				direction3.y = rayDir.y;
				direction3.z = rayDir.z;
				bool flag3 = Physics.SphereCast(origin3, castRadius, direction3, out hitInfo, maxDistance, layerMask3);
				bool flag4 = !flag3;
				bool flag5 = !flag4;
				num4 = rayDir.x;
				if (flag5)
				{
					goto IL_04a5;
				}
				num5 = num3;
			}
			else
			{
				int layerMask4 = groundMask;
				float maxDistance2 = castDistance + groundOffset;
				Vector3 origin4 = default(Vector3);
				origin4.x = rayOrigin.x;
				origin4.y = rayOrigin.y;
				origin4.z = rayOrigin.z;
				Vector3 direction4 = default(Vector3);
				direction4.x = rayDir.x;
				direction4.y = rayDir.y;
				direction4.z = rayDir.z;
				bool flag6 = Physics.Raycast(origin4, direction4, out hitInfo, maxDistance2, layerMask4);
				bool flag7 = !flag6;
				num4 = rayDir.y;
				num5 = num3;
				if (!flag7)
				{
					goto IL_04a5;
				}
			}
			if (!Application.isPlaying)
			{
				goto IL_07fb;
			}
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float y3 = position2.y;
			float num6 = position2.y - lastHitY;
			float num7 = 0f - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			float num8 = ((num6 < 0f) ? num7 : num5);
			float num9 = lastHitY + num8;
			bool flag8 = position2.z < num5;
			bool flag9 = !flag8;
			float num10 = position2.z - num5;
			bool flag10 = num10 == 0f;
			goto IL_0921;
			IL_07db:
			float num11 = y2 + groundOffset;
			hitY = num11;
			if (!Application.isPlaying)
			{
				goto IL_07fb;
			}
			y3 = hitY;
			float num12 = 0f - num3;
			float num13 = hitY - lastHitY;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (!(num13 < 0f))
			{
				num12 = num3;
			}
			num9 = lastHitY + num12;
			bool flag11 = num4 < num3;
			flag9 = !flag11;
			float num14 = num4 - num3;
			flag10 = num14 == 0f;
			goto IL_0921;
			IL_0921:
			bool flag12 = !flag10;
			if (!(flag9 && flag12))
			{
				num9 = y3;
			}
			hitY = num9;
			goto IL_07fb;
			IL_07fb:
			Transform transform3 = base.transform;
			Vector3 position3 = transform3.position;
			float num15 = ((!(lastHitY < hitY)) ? hitY : lastHitY);
			Transform transform4 = base.transform;
			float num16 = Mathf.Min(position3.y, float.MaxValue);
			float num17 = position3.y - num15;
			float y4 = ((num17 < 0f) ? num15 : num16);
			Vector3 position4 = default(Vector3);
			position4.x = position3.x;
			position4.y = y4;
			position4.z = position3.z;
			transform4.position = position4;
			SkeletonUtilityBone skeletonUtilityBone = base.bone;
			Bone bone = skeletonUtilityBone.bone;
			Transform transform5 = base.transform;
			Vector3 localPosition = transform5.localPosition;
			SkeletonUtility skeletonUtility2 = hierarchy;
			float x = localPosition.x / skeletonUtility2.PositionScale;
			bone.X = x;
			SkeletonUtilityBone skeletonUtilityBone2 = base.bone;
			Bone bone2 = skeletonUtilityBone2.bone;
			Transform transform6 = base.transform;
			Vector3 localPosition2 = transform6.localPosition;
			SkeletonUtility skeletonUtility3 = hierarchy;
			float y5 = localPosition2.y / skeletonUtility3.PositionScale;
			bone2.Y = y5;
			lastHitY = hitY;
			return;
			IL_04a5:
			y2 = hitInfo.point.y;
			goto IL_07db;
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0x151DAD4", Offset = "0x151DAD4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = this.rayOrigin.y - this.hitY;\n\tv35 = this.castDistance >= v38;\n\tif (v35) goto L_0021;\n\tgoto L_0021;\nL_0021:\n\tv39 = this.rayDir * this.castDistance;\n\tv40 = this.rayDir.y * this.castDistance;\n\tv41 = this.rayDir * v38;\n\tv42 = this.rayDir.y * v38;\n\tv43 = this.rayDir.z * v38;\n\tv44 = this.rayDir.z * this.castDistance;\n\tv45 = this.rayOrigin + v41;\n\tv46 = this.rayOrigin.y + v42;\n\tv47 = this.rayOrigin.z + v43;\n\tv49 = this.rayOrigin.z + v44;\n\tv54 = this.rayOrigin + v39;\n\tv55 = this.rayOrigin.y + v40;\n\t// 50 MakeStruct v56 @ AGG1521B48_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.rayOrigin (UnityEngine.Vector3), this.rayOrigin.y (System.Single), this.rayOrigin.z (System.Single)\n\t// 51 MakeStruct v57 @ AGG1521B48_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v45 @ V13_v1 (System.Single), v46 @ V12_v1 (System.Single), v47 @ V11_v1 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v56, v57);\n\tv59 = ~this.useRadius;\n\tif (v59) goto L_0054;\n\tv64 = v46 - this.groundOffset;\n\tv65 = v45 - this.castRadius;\n\tv66 = v45 + this.castRadius;\n\t// 65 MakeStruct v69 @ AGG1521B78_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v65 @ V0_v5 (System.Single), v64 @ V1_v6 (System.Single), v47 @ V11_v1 (System.Single)\n\t// 66 MakeStruct v70 @ AGG1521B78_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v66 @ V3_v7 (System.Single), v64 @ V1_v6 (System.Single), v47 @ V11_v1 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v69, v70);\n\tv94 = v54 - this.castRadius;\n\tv84 = v54 + this.castRadius;\n\t// 76 MakeStruct v75 @ AGG1521B9C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v94 @ V0_v6 (System.Single), v55 @ V9_v1 (System.Single), v49 @ V10_v1 (System.Single)\n\t// 77 MakeStruct v72 @ AGG1521B9C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v84 @ V3_v8 (System.Single), v55 @ V9_v1 (System.Single), v49 @ V10_v1 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v75, v72);\nL_0054:\n\t// 84 MakeStruct v100 @ AGG1521BB4_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 0, 0, 1f\n\tUnityEngine.Gizmos::set_color(v100);\n\t// 102 MakeStruct v117 @ AGG1521BE4_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v45 @ V13_v1 (System.Single), v46 @ V12_v1 (System.Single), v47 @ V11_v1 (System.Single)\n\t// 103 MakeStruct v118 @ AGG1521BE4_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v54 @ V8_v1 (System.Single), v55 @ V9_v1 (System.Single), v49 @ V10_v1 (System.Single)\n\tUnityEngine.Gizmos::DrawLine(v117, v118);\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDrawGizmos()
		{
			float num = rayOrigin.y - hitY;
			if (castDistance < num)
			{
				num = castDistance;
			}
			float num2 = rayDir.x * castDistance;
			float num3 = rayDir.y * castDistance;
			float num4 = rayDir.x * num;
			float num5 = rayDir.y * num;
			float num6 = rayDir.z * num;
			float num7 = rayDir.z * castDistance;
			float num8 = rayOrigin.x + num4;
			float num9 = rayOrigin.y + num5;
			float z = rayOrigin.z + num6;
			float z2 = rayOrigin.z + num7;
			float num10 = rayOrigin.x + num2;
			float y = rayOrigin.y + num3;
			Vector3 vector = default(Vector3);
			vector.x = rayOrigin.x;
			vector.y = rayOrigin.y;
			vector.z = rayOrigin.z;
			Vector3 to = default(Vector3);
			to.x = num8;
			to.y = num9;
			to.z = z;
			Gizmos.DrawLine(vector, to);
			if (useRadius)
			{
				float y2 = num9 - groundOffset;
				float x = num8 - castRadius;
				float x2 = num8 + castRadius;
				Vector3 vector2 = default(Vector3);
				vector2.x = x;
				vector2.y = y2;
				vector2.z = z;
				Vector3 to2 = default(Vector3);
				to2.x = x2;
				to2.y = y2;
				to2.z = z;
				Gizmos.DrawLine(vector2, to2);
				float x3 = num10 - castRadius;
				float x4 = num10 + castRadius;
				Vector3 vector3 = default(Vector3);
				vector3.x = x3;
				vector3.y = y;
				vector3.z = z2;
				Vector3 to3 = default(Vector3);
				to3.x = x4;
				to3.y = y;
				to3.z = z2;
				Gizmos.DrawLine(vector3, to3);
			}
			Color color = default(Color);
			color.r = 1f;
			color.g = 0f;
			color.b = 0f;
			color.a = 1f;
			Gizmos.color = color;
			Vector3 vector4 = default(Vector3);
			vector4.x = num8;
			vector4.y = num9;
			vector4.z = z;
			Vector3 to4 = default(Vector3);
			to4.x = num10;
			to4.y = y;
			to4.z = z2;
			Gizmos.DrawLine(vector4, to4);
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0x151DBE8", Offset = "0x151DBE8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.adjustSpeed = 5f;\n\tthis.castRadius = 2048.000471496582d;\n\tthis.rayDir = -0.0078125d;\n\tthis.rayDir.z = 0f;\n\tSpine.Unity.SkeletonUtilityConstraint::.ctor(this);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtilityGroundConstraint()
		{
			//IL_0036: Expected O, but got F8
			base._002Ector();
			adjustSpeed = 5f;
			castRadius = 0.1f;
			castDistance = 5f;
			rayDir = (Vector3)(-1.0 / 128.0);
			rayDir.z = 0f;
		}
	}
}
